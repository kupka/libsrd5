# Team flags on Battleground combatants

## Problem

Several spells need to know whether a given combatant is hostile to the caster
(e.g. `FaithfulHound`, `GuardianOfFaith` in
[Spells_4th.cs](libsrd5/ogl/Spells_4th.cs)). Today this is guessed from the
.NET type of the combatant:

```csharp
bool isHero = caster is CharacterSheet;
bool isVillain = caster is Monster;
foreach (Combatant other in ground.combatants) {
    if (isHero && other is CharacterSheet) continue;
    if (isVillain && other is Monster) continue;
    ...
}
```

This breaks down as soon as a fight isn't strictly "party of `CharacterSheet`
vs. a pile of `Monster`s":

- A summoned/charmed `Monster` fighting on the party's side (`ConjureAnimals`,
  `DominateBeast`, `AnimalFriendship`, ...) is still treated as hostile.
- An NPC `CharacterSheet` (e.g. a hired mercenary, or a mind-controlled party
  member) can't be on the monsters' side.
- Monster vs. monster fights, or 3+ faction encounters, aren't representable
  at all.

## Proposal

Add an explicit **Team** that is assigned when a `Combatant` is added to a
`Battleground`, rather than inferring it from the combatant's C# type.
Ownership lives on the `Battleground`, not on `Combatant`, because the same
`Monster`/`CharacterSheet` instance could conceivably fight on different sides
in different encounters, and the existing parallel bookkeeping arrays
(`locations`, `coords`, `initiativeRolls`) already follow that pattern.

### 1. New `Team` type

```csharp
// libsrd5/Battleground.cs (or a new Team.cs)
public enum Team {
    NONE,
    A,
    B,
    C,
    D
}
```

Keep it a small, generic set of labels (not "Heroes"/"Villains") so it also
works for monster-vs-monster or multi-faction fights. `NONE` is the default
for any combatant added through an overload that doesn't specify a team, see
below.

### 2. Track team per combatant in `Battleground`

In the abstract `Battleground` base class (around the existing `combatants`,
`initiativeRolls` arrays):

```csharp
private Team[] teams = new Team[0];

public void AddCombatant(Combatant combatant, Team team) {
    if (Array.IndexOf(combatants, combatant) > -1) return;
    Utils.Push<Combatant>(ref combatants, combatant);
    Utils.Push<Team>(ref teams, team);
    int roll = D20.Value + combatant.Dexterity.Modifier;
    Utils.Push<int>(ref initiativeRolls, roll);
    GlobalEvents.RolledInitiative(combatant, roll);
}

public Team GetTeam(Combatant combatant) {
    int index = Array.IndexOf(combatants, combatant);
    return index > -1 ? teams[index] : Team.NONE;
}

/// <summary>
/// Two combatants are hostile if they have different, specifically assigned
/// teams. Combatants with Team.NONE are considered hostile to everyone
/// (preserves today's "no team means fight everyone" behavior for ad-hoc
/// tests/spells that don't care about teams).
/// </summary>
public bool IsHostile(Combatant a, Combatant b) {
    if (a.Equals(b)) return false;
    Team teamA = GetTeam(a), teamB = GetTeam(b);
    if (teamA == Team.NONE || teamB == Team.NONE) return true;
    return teamA != teamB;
}

public bool IsAlly(Combatant a, Combatant b) => !IsHostile(a, b);
```

The existing no-argument `AddCombatant(Combatant combatant)` becomes a
convenience overload that calls `AddCombatant(combatant, Team.NONE)`, so every
call site that doesn't care about teams keeps compiling and behaving as
before (a combatant with no team is hostile to everyone, which is a safe
default for solo monster tests, etc.).

### 3. Update the two concrete `Battleground` subclasses

`BattleGroundClassic.AddCombatant(Combatant, ClassicLocation.Row)` and
`Battleground2D.AddCombatant(Combatant, int, int)` both currently forward to
the base `AddCombatant(Combatant)`. Add `Team`-accepting overloads that
forward to `AddCombatant(Combatant, Team)` instead, e.g.:

```csharp
// BattleGroundClassic
public void AddCombatant(Combatant combatant, ClassicLocation.Row row, Team team = Team.NONE) {
    AddCombatant(combatant, team);
    Utils.Push<ClassicLocation>(ref locations, new ClassicLocation(row));
}

// Battleground2D
public void AddCombatant(Combatant combatant, int x, int y, Team team = Team.NONE) {
    AddCombatant(combatant, team);
    Utils.Push<Coord>(ref coords, new Coord(x, y));
}
```

Using an optional parameter (rather than a second overload) avoids touching
the ~120 existing `AddCombatant(...)` call sites across
[libsrd5.tests](libsrd5.tests) that don't pass a team today.

As a convenience, `BattleGroundClassic` could default
`ClassicLocation.Row.FRONT_LEFT`/`BACK_LEFT` to `Team.A` and
`FRONT_RIGHT`/`BACK_RIGHT` to `Team.B` when no explicit team is given, since
that's the "left = party, right = enemies" convention the row names already
imply. This is optional sugar, not required for the core feature.

### 4. Replace the `isHero`/`isVillain` heuristic in spells

In [Spells_4th.cs](libsrd5/ogl/Spells_4th.cs), both `FaithfulHound` and
`GuardianOfFaith` change from:

```csharp
bool isHero = caster is CharacterSheet;
bool isVillain = caster is Monster;
foreach (Combatant other in ground.combatants) {
    if (other.Dead) continue;
    if (isHero && other is CharacterSheet) continue;
    if (isVillain && other is Monster) continue;
    ...
}
```

to:

```csharp
foreach (Combatant other in ground.combatants) {
    if (other.Dead) continue;
    if (!ground.IsHostile(caster, other)) continue;
    ...
}
```

Any other spell added later that needs "friend or foe" logic should use
`ground.IsHostile`/`ground.IsAlly` instead of re-inventing a type check.

### 5. Interaction with charm/domination effects

Spells like `DominateBeast`, `CharmPerson`, `AnimalFriendship` currently only
set a `ConditionType.CHARMED` condition; they don't change who the creature
will fight. Once `IsHostile` is team-based, charming a creature should also
temporarily flip its `Team` (and flip it back when the condition ends) so
that reactive effects (Faithful Hound, Guardian of Faith, future opportunity
attacks, etc.) treat it as an ally for the duration. This isn't required for
the initial `Team` plumbing, but should be called out as follow-up work once
`Battleground` exposes a way to change a combatant's team after the fact
(e.g. `SetTeam(Combatant, Team)`).

## Migration plan

1. Add `Team` enum and the `teams` array / `AddCombatant(Combatant, Team)` /
   `GetTeam` / `IsHostile` / `IsAlly` members to `Battleground`.
2. Add optional `Team` parameters to `BattleGroundClassic.AddCombatant` and
   `Battleground2D.AddCombatant`, defaulting to `Team.NONE` so no existing
   call site needs to change.
3. Update `FaithfulHound` and `GuardianOfFaith` to call `ground.IsHostile`.
4. Add targeted tests exercising `IsHostile`/`IsAlly` directly (mixed-type
   teams: a `Monster` ally and a `CharacterSheet` enemy) and update/extend
   `FaithfulHoundTest` / `GuardianOfFaithTest` to cover a `Monster` ally
   placed on the caster's team.
5. (Follow-up, optional) Add `Battleground.SetTeam` and wire it into
   charm/domination spells so charmed creatures are treated as allies while
   the condition lasts.

## Open questions

- Do we need more than a handful of `Team` values, or would a plain `int`
  (or `string`) be more future-proof for arbitrary multi-faction scenarios?
  An enum is consistent with the rest of the codebase's style (see
  `SpellSchool`, `DamageType`, etc.) but is less flexible.
- Should `Team.NONE` mean "hostile to everyone" (as proposed) or "neutral/
  hostile to no one"? The former preserves existing spell behavior in tests
  that don't set up teams at all; the latter might be more intuitive but
  would silently change behavior for any spell relying on the old
  type-based heuristic until it's migrated.
- Should team assignment also live on `Combatant` as a default/last-used
  team (for convenience when re-adding the same instance to a new
  `Battleground`), or should it always be purely `Battleground`-scoped as
  described above?

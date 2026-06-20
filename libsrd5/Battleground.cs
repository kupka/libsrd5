using System;
using System.Collections;
using static srd5.Die;
using static srd5.Effect;

namespace srd5 {
    public class Tile {

    }

    public class Coord : Location {
        public int X;

        public int Y;

        public Coord(int x, int y) {
            X = x;
            Y = y;
        }

        public override int Distance(Location another) {
            if (!(another is Coord)) throw new Srd5ArgumentException("another must be a Coord.");
            Coord anotherCoord = (Coord)another;
            double dX = this.X - anotherCoord.X;
            double dY = this.Y - anotherCoord.Y;
            double distance = Math.Sqrt(dX * dX + dY * dY);
            // one tile is 5ft x 5ft - round before multiply to have distance % 5 == 0
            return (int)Math.Round(distance) * 5;
        }
    }

    public abstract class Location {
        public abstract int Distance(Location another);
    }

    /// <summary>
    /// Has front and back lines for left (usually heroes) and right (enemies) side of the screen. Classic JRPG-style.
    /// </summary>
    public class ClassicLocation : Location {
        public enum Row {
            BACK_LEFT = 0,
            FRONT_LEFT = 25,
            FRONT_RIGHT = 30,
            BACK_RIGHT = 55
        }

        public static readonly ClassicLocation BackLeft = new ClassicLocation(Row.BACK_LEFT);
        public static readonly ClassicLocation FrontLeft = new ClassicLocation(Row.FRONT_LEFT);
        public static readonly ClassicLocation FrontRight = new ClassicLocation(Row.FRONT_RIGHT);
        public static readonly ClassicLocation BackRight = new ClassicLocation(Row.BACK_RIGHT);

        public Row Location { get; internal set; }

        public ClassicLocation(Row row) {
            Location = row;
        }

        public override int Distance(Location another) {
            if (!(another is ClassicLocation)) throw new Srd5ArgumentException("another must be a ClassicLocation.");
            ClassicLocation classicAnother = (ClassicLocation)another;
            return Math.Max(Math.Abs((int)classicAnother.Location - (int)this.Location), 5);
        }
    }

    internal class ReverseComparer : System.Collections.IComparer {
        int IComparer.Compare(object x, object y) {
            return new CaseInsensitiveComparer().Compare(y, x);
        }
    }

    public class BattleGroundClassic : Battleground {
        private ClassicLocation[] locations = new ClassicLocation[0];

        public override void Initialize() {
            base.Initialize();
            Array.Sort(initiativeRolls, locations, new ReverseComparer());
            Turn = 1;
        }

        public override Location LocateCombatant(Combatant combatant) {
            return locations[Array.IndexOf(combatants, combatant)];
        }

        public ClassicLocation LocateClassicCombatant(Combatant combatant) {
            return locations[Array.IndexOf(combatants, combatant)];
        }


        protected override void SetCurrentLocation(Location location) {
            SetLocation(CurrentCombatant, location);
        }

        protected override void SetLocation(Combatant combatant, Location location) {
            locations[Array.IndexOf(combatants, combatant)] = (ClassicLocation)location;
        }

        public void AddCombatant(Combatant combatant, ClassicLocation.Row row) {
            AddCombatant(combatant);
            Utils.Push<ClassicLocation>(ref locations, new ClassicLocation(row));
        }

        public override void Push(Location source, Combatant target, int distance) {
            if (LocateClassicCombatant(target).Location == ClassicLocation.Row.FRONT_LEFT) {
                SetLocation(target, ClassicLocation.BackLeft);
            } else if (LocateClassicCombatant(target).Location == ClassicLocation.Row.FRONT_RIGHT) {
                SetLocation(target, ClassicLocation.BackRight);
            }
        }
    }

    public class Battleground2D : Battleground {
        public Coord[] Offsets = new Coord[]{
            new Coord(0, 1), // TOP
            new Coord(1,1), // TOP RIGHT
            new Coord(1, 0), // RIGHT
            new Coord(1, -1), // BOTTOM RIGHT
            new Coord(0, -1), // BOTTOM
            new Coord(-1, -1), // BOTTOM LEFT
            new Coord(-1, 0), // LEFT
            new Coord(-1, 1) // TOP LEFT
        };

        public Tile[,] Tiles { get; internal set; }
        private Coord[] coords = new Coord[0];

        public Battleground2D(int x, int y) {
            Tiles = new Tile[x, y];
            for (int i = 0; i < x; i++) {
                for (int j = 0; j < y; j++) {
                    Tiles[i, j] = new Tile();
                }
            }
        }

        public override void Initialize() {
            base.Initialize();
            Array.Sort(initiativeRolls, coords, new ReverseComparer());
            Turn = 1;
        }

        public override Location LocateCombatant(Combatant combatant) {
            return coords[Array.IndexOf(combatants, combatant)];
        }

        public Coord LocateCombatant2D(Combatant combatant) {
            return coords[Array.IndexOf(combatants, combatant)];
        }

        public void AddCombatant(Combatant combatant, int x, int y) {
            AddCombatant(combatant);
            Utils.Push<Coord>(ref coords, new Coord(x, y));
        }

        public void AddCombatantNextTo(Combatant combatant, int x, int y) {
            AddCombatant(combatant);
            bool occupied = true;
            int i = 0;
            while (occupied) {
                int mult = i / 8 + 1;
                Coord offset = Offsets[i % 8];
                int x2 = x + offset.X * mult;
                int y2 = y + offset.Y * mult;
                occupied = false;
                foreach (Coord coord in coords) {
                    if (coord.X == x2 && coord.Y == y2) {
                        occupied = true;
                        break;
                    }
                }
                if (!occupied) {
                    Utils.Push<Coord>(ref coords, new Coord(x2, y2));
                } else {
                    i++;
                }
            }
        }

        protected override void SetCurrentLocation(Location location) {
            SetLocation(CurrentCombatant, location);
        }

        protected override void SetLocation(Combatant combatant, Location location) {
            coords[Array.IndexOf(combatants, combatant)] = (Coord)location;
        }

        public override void Push(Location source, Combatant target, int distance) {
            // For simplicity, this assumes either a straight line or 45° angle. 
            Coord sourceCoord = (Coord)source;
            Coord targetCoord = LocateCombatant2D(target);
            Coord destination = targetCoord;
            distance /= 5;
            if (targetCoord.X == sourceCoord.X) {
                if (targetCoord.Y <= sourceCoord.Y) { // push down
                    destination = new Coord(targetCoord.X, targetCoord.Y - distance);
                } else { // push up
                    destination = new Coord(targetCoord.X, targetCoord.Y + distance);
                }
            } else if (targetCoord.Y == sourceCoord.Y) {
                if (targetCoord.X <= sourceCoord.X) { // push left
                    destination = new Coord(targetCoord.X - distance, targetCoord.Y);
                } else { // push right
                    destination = new Coord(targetCoord.X + distance, targetCoord.Y);
                }
            } else if (targetCoord.X < sourceCoord.X) { // push left
                distance /= 2;
                if (distance == 0) distance = 1;
                if (targetCoord.Y < sourceCoord.Y) { // push down
                    destination = new Coord(targetCoord.X - distance, targetCoord.Y - distance);
                } else if (targetCoord.Y > sourceCoord.Y) { // push up
                    destination = new Coord(targetCoord.X - distance, targetCoord.Y + distance);
                }
            } else { // push right
                distance /= 2;
                if (distance == 0) distance = 1;
                if (targetCoord.Y < sourceCoord.Y) { // push down
                    destination = new Coord(targetCoord.X + distance, targetCoord.Y - distance);
                } else if (targetCoord.Y > sourceCoord.Y) { // push up
                    destination = new Coord(targetCoord.X + distance, targetCoord.Y + distance);
                }
            }
            SetLocation(target, destination);
        }
    }

    public enum TurnPhase {
        MOVE,
        ACTION,
        BONUS_ACTION
    }

    public class CombatantChangedEvent : BattlegroundEvent {
        public Combatant CurrentCombatant { get; internal set; }
    }

    public class BattlegroundEvent : EventArgs {
    }

    public abstract class Battleground {

        internal Combatant[] combatants = new Combatant[0];

        public int Turn { get; internal set; } = 0;
        protected int[] initiativeRolls = new int[0];
        public Combatant CurrentCombatant {
            get {
                return combatants[currentCombatant];
            }
        }
        protected int currentCombatant = 0;
        public int RemainingSpeed {
            get {
                return remainingSpeed;
            }
        }
        protected int remainingSpeed = 0;
        protected TurnPhase currentPhase = TurnPhase.MOVE;

        public virtual void Initialize() {
            if (Turn > 0) return;
            // Sort Combatants and Coords according to Initiative Rolls
            int[] backup = new int[initiativeRolls.Length];
            Array.Copy(initiativeRolls, backup, initiativeRolls.Length);
            Array.Sort(backup, combatants, new ReverseComparer());
            currentCombatant = 0;
            currentPhase = TurnPhase.MOVE;
            remainingSpeed = CurrentCombatant.Speed;
        }

        private void nextCombatant() {
            currentCombatant++;
            currentCombatant %= combatants.Length;
            if (currentCombatant == 0) Turn++;
            currentPhase = TurnPhase.MOVE;
            remainingSpeed = CurrentCombatant.Speed;
            onCurrentCombatantChanged();
        }

        /// <summary>
        /// Add a combatant to the battlefield and roll initiative
        /// </summary>
        public void AddCombatant(Combatant combatant) {
            if (Array.IndexOf(combatants, combatant) > -1) return;
            Utils.Push<Combatant>(ref combatants, combatant);
            int roll = D20.Value + combatant.Dexterity.Modifier;
            Utils.Push<int>(ref initiativeRolls, roll);
            GlobalEvents.RolledInitiative(combatant, roll);
        }

        /// <summary>
        /// Move on to the next phase (MOVE -> ACTION -> BONUS ACTION -> Next Combatant)
        /// </summary>
        public TurnPhase NextPhase() {
            switch (currentPhase) {
                case TurnPhase.MOVE:
                    remainingSpeed = 0;
                    currentPhase = TurnPhase.ACTION;
                    break;
                case TurnPhase.ACTION:
                    currentPhase = TurnPhase.BONUS_ACTION;
                    break;
                case TurnPhase.BONUS_ACTION:
                    nextCombatant();
                    break;
            }
            return currentPhase;
        }

        /// <summary>
        /// Move the current combatant to the target destination if able
        /// </summary>
        public bool MoveAction(Location destination) {
            if (CurrentCombatant.HasEffect(CANNOT_TAKE_ACTIONS)) return false;
            if (destination == null) throw new Srd5ArgumentException("destination cannot be null");
            int distance = destination.Distance(LocateCombatant(CurrentCombatant));
            if (distance > remainingSpeed) return false;
            remainingSpeed -= distance;
            SetCurrentLocation(destination);
            return true;
        }

        /// <summary>
        /// Current combatant melee attacks a target if able
        /// </summary>
        public bool MeleeAttackAction(Combatant target) {
            if (CurrentCombatant.HasEffect(CANNOT_TAKE_ACTIONS)) return false;
            if (CurrentCombatant.HasEffect(CANNOT_MELEE_ATTACK)) return false;
            if (currentPhase == TurnPhase.MOVE) return false;
            if (target == null) throw new Srd5ArgumentException("target cannot be null");
            if (target == CurrentCombatant) throw new Srd5ArgumentException("cannot attack self");
            if (target.HasEffect(CANNOT_BE_MELEE_ATTACKED)) return false;
            bool success = false;
            if (currentPhase == TurnPhase.ACTION)
                success = doFullMeleeAttack(target);
            else
                success = doBonusMeleeAttack(target);
            if (success) NextPhase();
            return success;
        }

        /// <summary>
        /// Current combatant uses their ranged attack against the target if able
        /// </summary>
        public bool RangedAttackAction(Combatant target) {
            if (target == null) throw new Srd5ArgumentException("target cannot be null");
            if (CurrentCombatant.HasEffect(CANNOT_TAKE_ACTIONS)) {
                GlobalEvents.FailAction(CurrentCombatant, GlobalEvents.ActionFailed.Reasons.CANNOT_TAKE_ACTIONS);
                return false;
            }
            if (currentPhase == TurnPhase.MOVE) {
                GlobalEvents.FailAction(CurrentCombatant, GlobalEvents.ActionFailed.Reasons.WRONG_PHASE);
                return false;
            }
            if (target == CurrentCombatant) throw new Srd5ArgumentException("cannot attack self");
            bool success = false;
            if (currentPhase == TurnPhase.ACTION)
                success = doFullRangedAttack(target);
            else
                success = doBonusRangedAttack(target);
            if (!success) {
                GlobalEvents.FailAction(CurrentCombatant, GlobalEvents.ActionFailed.Reasons.TARGET_OUT_OF_RANGE);
            }
            if (success) NextPhase();
            return success;
        }

        /// <summary>
        /// Current combatant casts a spell if able. Checks all relevant constraints, such as range and if the spell is prepared
        /// <summary>
        public bool SpellCastAction(Spell spell, SpellLevel slot, AvailableSpells availableSpells, params Combatant[] targets) {
            if (CurrentCombatant.HasEffect(CANNOT_TAKE_ACTIONS)) {
                GlobalEvents.FailAction(CurrentCombatant, GlobalEvents.ActionFailed.Reasons.CANNOT_TAKE_ACTIONS);
                return false;
            }
            // check if phase is valid for spell
            if (currentPhase == TurnPhase.BONUS_ACTION && spell.CastingTime != CastingTime.BONUS_ACTION) {
                GlobalEvents.FailAction(CurrentCombatant, GlobalEvents.ActionFailed.Reasons.WRONG_PHASE);
                return false;
            } else if (currentPhase == TurnPhase.MOVE) {
                GlobalEvents.FailAction(CurrentCombatant, GlobalEvents.ActionFailed.Reasons.WRONG_PHASE);
                return false;
            }
            // check if spell is known
            if (Array.IndexOf(availableSpells.KnownSpells, spell) == -1) {
                GlobalEvents.FailAction(CurrentCombatant, GlobalEvents.ActionFailed.Reasons.SPELL_NOT_KNOWN);
                return false;
            }
            // check if spell is prepared
            if (availableSpells.CharacterClass.MustPrepareSpells == true
                    && Array.IndexOf(availableSpells.PreparedSpells, spell) == -1
                    && Array.IndexOf(availableSpells.BonusPreparedSpells, spell) == -1) {
                GlobalEvents.FailAction(CurrentCombatant, GlobalEvents.ActionFailed.Reasons.SPELL_NOT_PREPARED);
                return false;
            }
            // check if spell allows amount of targets
            if (spell.MaximumTargets < targets.Length) {
                GlobalEvents.FailAction(CurrentCombatant, GlobalEvents.ActionFailed.Reasons.WRONG_NUMBER_OF_TARGETS);
                return false;
            }
            // check that a target is set when the spells requires so
            if (spell.MaximumTargets > 0 && targets.Length == 0) {
                GlobalEvents.FailAction(CurrentCombatant, GlobalEvents.ActionFailed.Reasons.WRONG_NUMBER_OF_TARGETS);
                return false;
            }
            // check if targets are in range
            foreach (Combatant target in targets) {
                int distance = Distance(target);
                if (distance > spell.Range) {
                    GlobalEvents.FailAction(CurrentCombatant, GlobalEvents.ActionFailed.Reasons.TARGET_OUT_OF_RANGE);
                    return false;
                }
            }
            // if the spell has an area of effect, check that all targets are within this area of the first target
            if (spell.AreaOfEffect > 0) {
                for (int i = 1; i < targets.Length; i++) {
                    int distance = Distance(targets[0], targets[i]);
                    if (distance > spell.AreaOfEffect) {
                        GlobalEvents.FailAction(CurrentCombatant, GlobalEvents.ActionFailed.Reasons.TARGET_OUT_OF_RANGE);
                        return false;
                    }
                }
            }
            // Check if slot is sufficient for spell
            if (slot < spell.Level) {
                GlobalEvents.FailAction(CurrentCombatant, GlobalEvents.ActionFailed.Reasons.SPELLSLOT_INVALID);
                return false;
            }
            InnateSpellcasting innate = null;
            if (CurrentCombatant is Monster monster) {
                innate = monster.InnateSpellcastingBySpell(spell);
            }
            // Check if innate Spell casting is available
            if (innate != null && innate.Frequency == InnateSpellcasting.Frequencies.AT_WILL) {
                // can cast at will, nothing to do
            } else if (innate != null) {
                // requires available use
                int maxUses = (int)(((Monster)CurrentCombatant).InnateSpellcastingBySpell(spell).Frequency);
                if (maxUses == innate.Uses) {
                    GlobalEvents.FailAction(CurrentCombatant, GlobalEvents.ActionFailed.Reasons.INSUFFICIENT_USES);
                    return false;
                }
                innate.Uses++;
            } else if (availableSpells.SlotsCurrent[(int)slot] <= 0) { // otherwise, check if slot is available
                GlobalEvents.FailAction(CurrentCombatant, GlobalEvents.ActionFailed.Reasons.SPELLSLOT_EMPTY);
                return false;
            } else {
                // Expend slot if not Cantrip
                if (slot != SpellLevel.CANTRIP) availableSpells.SlotsCurrent[(int)slot]--;
            }
            // Cast Spell
            int modifier = availableSpells.GetSpellcastingModifier(CurrentCombatant);
            if (targets.Length > 0) {
                spell.Cast(this, CurrentCombatant, availableSpells.GetSpellCastDC(CurrentCombatant), slot, modifier, targets);
            } else {
                spell.Cast(CurrentCombatant, availableSpells.GetSpellCastDC(CurrentCombatant), slot, modifier);
            }
            NextPhase();
            return true;
        }

        private bool doBonusMeleeAttack(Combatant target) {
            bool success = false;
            int distance = Distance(target);
            Attack attack = CurrentCombatant.BonusAttack;
            if (attack == null || distance > attack.Reach) return false;
            success = true;
            CurrentCombatant.Attack(attack, target, distance);
            return success;
        }

        private bool doBonusRangedAttack(Combatant target) {
            bool success = false;
            int distance = Distance(target);
            Attack attack = CurrentCombatant.BonusAttack;
            if (attack == null || distance > attack.RangeLong) return false;
            success = true;
            CurrentCombatant.Attack(attack, target, distance, true);
            return success;
        }

        private bool doFullMeleeAttack(Combatant target) {
            bool success = false;
            int distance = Distance(target);
            foreach (Attack attack in CurrentCombatant.MeleeAttacks) {
                if (distance > attack.Reach) continue; // skip attack when out of reach
                success = true;
                CurrentCombatant.Attack(attack, target, distance);
            }
            return success;
        }

        private bool doFullRangedAttack(Combatant target) {
            bool success = false;
            int distance = Distance(target);
            foreach (Attack attack in CurrentCombatant.RangedAttacks) {
                if (distance > attack.RangeLong) continue; // skip attack when out of range
                success = true;
                CurrentCombatant.Attack(attack, target, distance, true);
            }
            return success;
        }

        /// <summary>
        /// Returns the Location of the given combatant
        /// </summary>
        public abstract Location LocateCombatant(Combatant combatant);

        /// <summary>
        /// Set the location of the current active combatant
        /// </summary>
        protected abstract void SetCurrentLocation(Location location);

        /// <summary>
        /// Set the location of the combatant
        /// </summary>
        protected abstract void SetLocation(Combatant combatant, Location location);


        /// <summary>
        /// Get the location of the current active combatant
        /// </summary>
        public virtual Location GetCurrentLocation() {
            return LocateCombatant(CurrentCombatant);
        }

        /// <summary>
        /// Returns the distance between the current combatant and the target.
        /// </summary>
        public int Distance(Combatant target) {
            return GetCurrentLocation().Distance(LocateCombatant(target));
        }

        /// <summary>
        /// Returns the distance between two combatants.
        /// </summary>
        public int Distance(Combatant combatant1, Combatant combatant2) {
            return LocateCombatant(combatant1).Distance(LocateCombatant(combatant2));
        }

        // Events
        public event EventHandler<BattlegroundEvent> EventSubscription;
        private void onCurrentCombatantChanged() {
            if (EventSubscription == null) return;
            CombatantChangedEvent bgEvent = new CombatantChangedEvent();
            bgEvent.CurrentCombatant = this.CurrentCombatant;
            EventSubscription(this, bgEvent);
        }

        /// <summary>
        /// Pushes the target away from the source by the distance.
        /// </summar>)
        public abstract void Push(Location source, Combatant target, int distance);
    }
}
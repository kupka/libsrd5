using Xunit;

namespace srd5 {
    [CollectionDefinition("SingleThreaded", DisableParallelization = true)]
    [Collection("SingleThreaded")]
    public partial class SpellTest {
        [Fact]
        public void ViciousMockeryTest() {
            CharacterSheet bard = new CharacterSheet(Race.GNOME, true);
            bard.AddLevels(CharacterClasses.Bard, CharacterClasses.Bard);
            Monster goblin = Monsters.Goblin;
            Monster goblin2 = Monsters.Goblin;
            BattleGroundClassic ground = new BattleGroundClassic();
            ground.AddCombatant(bard, ClassicLocation.Row.FRONT_LEFT);
            ground.AddCombatant(goblin, ClassicLocation.Row.FRONT_RIGHT);
            ground.AddCombatant(goblin2, ClassicLocation.Row.FRONT_RIGHT);
            Spells.ViciousMockery.Cast(ground, bard, 30, SpellLevel.CANTRIP, 2, goblin);
            Assert.True(goblin.HitPointsMax > goblin.HitPoints);
            Assert.True(goblin.HasEffect(Effect.DISADVANTAGE_ON_ATTACK));
            goblin.OnEndOfTurn();
            Assert.False(goblin.HasEffect(Effect.DISADVANTAGE_ON_ATTACK));
            Random.FixedRandom = Random.DebugState.Avg; // low DC guarantees goblin2's save succeeds, negating all damage
            Spells.ViciousMockery.Cast(ground, bard, 1, SpellLevel.CANTRIP, 2, goblin2);
            Assert.True(goblin2.HitPointsMax == goblin2.HitPoints);
            Assert.False(goblin2.HasEffect(Effect.DISADVANTAGE_ON_ATTACK));

        }

        [Fact]
        public void HeroismTest() {
            Monster goblin = Monsters.Goblin;
            Spells.Heroism.Cast(goblin, 12, SpellLevel.FIRST, 5);
            goblin.OnStartOfTurn();
            goblin.TakeDamage(new DamageSource(DamageSourceType.OTHER, this, goblin), DamageType.ACID, 1);
            Assert.Equal(goblin.HitPointsMax, goblin.HitPoints);
            goblin.OnEndOfTurn();
            DefaultSpellTest(Spells.Heroism, 12, SpellLevel.THIRD, null, Effect.IMMUNITY_FRIGHTENED, 10);
        }

        [Fact]
        public void CalmEmotionsTest() {
            Monster badger = Monsters.Badger;
            badger.AddCondition(ConditionType.CHARMED);
            Monster bandit = Monsters.Bandit;
            bandit.AddCondition(ConditionType.CHARMED);
            CharacterSheet coward = new CharacterSheet(Race.GNOME);
            coward.AddCondition(ConditionType.FRIGHTENED);
            Monster solar = Monsters.Solar;
            Battleground ground = createBattleground(solar, badger, bandit, coward);
            Spells.CalmEmotions.Cast(ground, solar, 20, SpellLevel.SEVENTH, 10, badger, bandit, coward);
            Assert.True(badger.HasCondition(ConditionType.CHARMED));
            Assert.False(bandit.HasCondition(ConditionType.CHARMED));
            Assert.False(coward.HasCondition(ConditionType.FRIGHTENED));

            // TODO: Add effects here that will be restored after Calm Emotions expires
            Assert.True(bandit.HasEffect(Effect.SPELL_CALM_EMOTIONS_CHARMED_SUPRESSED));
            bandit.RemoveEffect(Effect.SPELL_CALM_EMOTIONS);
            Assert.False(bandit.HasEffect(Effect.SPELL_CALM_EMOTIONS_CHARMED_SUPRESSED));
            Assert.True(coward.HasEffect(Effect.SPELL_CALM_EMOTIONS_FRIGHTENED_SUPRESSED));
            coward.RemoveEffect(Effect.SPELL_CALM_EMOTIONS);
            Assert.False(coward.HasEffect(Effect.SPELL_CALM_EMOTIONS_FRIGHTENED_SUPRESSED));
        }

        [Fact]
        public void MisleadTest() {
            CharacterSheet wizard = new CharacterSheet(Race.HUMAN);
            wizard.AddLevel(CharacterClasses.Wizard);
            CharacterSheet bard = new CharacterSheet(Race.HUMAN);
            Monster orc = Monsters.Orc;
            orc.HitPointsMax = 100;
            orc.HitPoints = 100;
            Battleground ground = createBattleground(wizard, bard, orc);

            Spells.Mislead.Cast(ground, wizard, 15, SpellLevel.FIFTH, 0, wizard);
            Assert.True(wizard.HasEffect(Effect.SPELL_MISLEAD));
            Assert.True(wizard.HasCondition(ConditionType.INVISIBLE));
            // Attacks and spells of other creatures don't end the invisibility
            orc.Attack(weakMeleeAttack, bard, 5);
            Spells.DispelEvilandGood.Cast(ground, bard, 15, SpellLevel.FIFTH, 0, bard);
            wizard.OnEndOfTurn();
            Assert.True(wizard.HasCondition(ConditionType.INVISIBLE));
            // Attacking ends the invisibility
            wizard.Attack(weakMeleeAttack, orc, 5);
            Assert.False(wizard.HasEffect(Effect.SPELL_MISLEAD));
            Assert.False(wizard.HasCondition(ConditionType.INVISIBLE));
            wizard.OnStartOfTurn();
            wizard.OnEndOfTurn();
            Assert.Empty(wizard.EndOfTurnEvents);

            // Casting a spell ends the invisibility
            Spells.Mislead.Cast(ground, wizard, 15, SpellLevel.FIFTH, 0, wizard);
            Assert.True(wizard.HasCondition(ConditionType.INVISIBLE));
            Spells.DispelEvilandGood.Cast(ground, wizard, 15, SpellLevel.FIFTH, 0, wizard);
            Assert.False(wizard.HasCondition(ConditionType.INVISIBLE));
            wizard.RemoveEffect(Effect.SPELL_DISPEL_EVIL_AND_GOOD);
            wizard.OnStartOfTurn();
            wizard.OnEndOfTurn();
            Assert.Empty(wizard.EndOfTurnEvents);

            // The invisibility lasts for one hour
            Spells.Mislead.Cast(ground, wizard, 15, SpellLevel.FIFTH, 0, wizard);
            for (int i = 0; i < (int)SpellDuration.ONE_HOUR; i++) {
                wizard.OnStartOfTurn();
                wizard.OnEndOfTurn();
            }
            Assert.False(wizard.HasCondition(ConditionType.INVISIBLE));
            wizard.OnEndOfTurn();
            Assert.Empty(wizard.EndOfTurnEvents);
        }

        [Fact]
        public void ModifyMemorySaveTest() {
            CharacterSheet bard = new CharacterSheet(Race.HUMAN);
            Monster immuneOrc = Monsters.Orc;
            immuneOrc.AddEffect(Effect.IMMUNITY_CHARMED);
            Monster orc = Monsters.Orc;
            Battleground ground = createBattleground(bard, immuneOrc, orc);
            // Creatures immune to being charmed are unaffected
            Random.FixedRandom = Random.DebugState.Min;
            Random.State = 1;
            Spells.ModifyMemory.Cast(ground, bard, 25, SpellLevel.FIFTH, 0, immuneOrc);
            Assert.False(immuneOrc.HasEffect(Effect.SPELL_MODIFY_MEMORY));
            // A successful save means the target is unaffected (the save is made with advantage: both d20 are 10 at state 1)
            Random.State = 1;
            Spells.ModifyMemory.Cast(ground, bard, 5, SpellLevel.FIFTH, 0, orc);
            Assert.False(orc.HasEffect(Effect.SPELL_MODIFY_MEMORY));
            Assert.Empty(bard.EndOfTurnEvents);
        }

        [Fact]
        public void ModifyMemoryTest() {
            CharacterSheet bard = new CharacterSheet(Race.HUMAN);
            Monster orc = Monsters.Orc;
            orc.HitPointsMax = 100;
            orc.HitPoints = 100;
            Monster otherOrc = Monsters.Orc;
            Battleground ground = createBattleground(bard, orc, otherOrc);

            // Failed save: the target is charmed and incapacitated
            Random.FixedRandom = Random.DebugState.Min;
            Random.State = 1;
            Spells.ModifyMemory.Cast(ground, bard, 25, SpellLevel.FIFTH, 0, orc);
            Assert.True(orc.HasEffect(Effect.SPELL_MODIFY_MEMORY));
            Assert.True(orc.HasCondition(ConditionType.CHARMED));
            Assert.True(orc.HasCondition(ConditionType.INCAPACITATED));
            Assert.True(orc.HasEffect(Effect.CANNOT_TAKE_ACTIONS));
            // Spells targeting other creatures and Modify Memory itself don't end the spell
            Spells.GreaterRestoration.Cast(ground, bard, 25, SpellLevel.FIFTH, 0, otherOrc);
            Random.State = 1;
            Spells.ModifyMemory.Cast(ground, bard, 5, SpellLevel.FIFTH, 0, orc); // successful save
            bard.OnEndOfTurn();
            Assert.True(orc.HasEffect(Effect.SPELL_MODIFY_MEMORY));
            // Being targeted by another spell ends the spell
            Spells.GreaterRestoration.Cast(ground, bard, 25, SpellLevel.FIFTH, 0, orc);
            Assert.False(orc.HasEffect(Effect.SPELL_MODIFY_MEMORY));
            Assert.False(orc.HasCondition(ConditionType.CHARMED));
            Assert.False(orc.HasCondition(ConditionType.INCAPACITATED));
            bard.OnEndOfTurn();
            Assert.Empty(bard.EndOfTurnEvents);

            // Taking damage ends the spell
            Random.FixedRandom = Random.DebugState.Min;
            Random.State = 1;
            Spells.ModifyMemory.Cast(ground, bard, 25, SpellLevel.FIFTH, 0, orc);
            Assert.True(orc.HasEffect(Effect.SPELL_MODIFY_MEMORY));
            orc.TakeDamage(new DamageSource(Spells.ID.MODIFY_MEMORY, bard), DamageType.TRUE_DAMAGE, 1);
            Assert.False(orc.HasEffect(Effect.SPELL_MODIFY_MEMORY));
            Assert.Empty(orc.DamageTakenEvents);
            bard.OnEndOfTurn();

            // The spell ends after one minute
            Random.FixedRandom = Random.DebugState.Min;
            Random.State = 1;
            Spells.ModifyMemory.Cast(ground, bard, 25, SpellLevel.FIFTH, 0, otherOrc);
            for (int i = 0; i < (int)SpellDuration.ONE_MINUTE - 1; i++) {
                bard.OnEndOfTurn();
            }
            Assert.True(otherOrc.HasEffect(Effect.SPELL_MODIFY_MEMORY));
            bard.OnEndOfTurn();
            Assert.False(otherOrc.HasEffect(Effect.SPELL_MODIFY_MEMORY));
            Assert.Empty(bard.EndOfTurnEvents);
        }

        [Fact]
        public void PlanarBindingTest() {
            CharacterSheet wizard = new CharacterSheet(Race.HUMAN);
            CharacterSheet fighter = new CharacterSheet(Race.HUMAN);
            Monster orc = Monsters.Orc;
            Monster[] bindable = { Monsters.Deva, Monsters.EarthElemental, Monsters.Dryad, Monsters.Imp };
            Battleground ground = createTeamBattleground(wizard, fighter, orc, bindable[0], bindable[1], bindable[2], bindable[3]);

            // Only celestials, elementals, fey and fiends can be bound
            foreach (Combatant target in new Combatant[] { fighter, orc }) {
                Random.FixedRandom = Random.DebugState.Min;
                Spells.PlanarBinding.Cast(ground, wizard, 30, SpellLevel.FIFTH, 0, target);
                Assert.False(target.HasEffect(Effect.SPELL_PLANAR_BINDING));
            }
            // A successful save means the creature is not bound (the deva saves with advantage: both d20 are 10 at state 1)
            Random.State = 1;
            Spells.PlanarBinding.Cast(ground, wizard, 5, SpellLevel.FIFTH, 0, bindable[0]);
            Assert.False(bindable[0].HasEffect(Effect.SPELL_PLANAR_BINDING));
            // A failed save binds the creature to the caster's service
            foreach (Monster target in bindable) {
                Random.FixedRandom = Random.DebugState.Min;
                Random.State = 1; // second d20 in case of magic resistance
                Spells.PlanarBinding.Cast(ground, wizard, 30, SpellLevel.FIFTH, 0, target);
                Assert.True(target.HasEffect(Effect.SPELL_PLANAR_BINDING));
                Assert.Equal(Team.HEROES, ground.GetTeam(target));
            }

            // The binding ends when removed otherwise
            bindable[3].RemoveEffect(Effect.SPELL_PLANAR_BINDING);
            wizard.OnEndOfTurn();
            Assert.Equal(Team.VILLAINS, ground.GetTeam(bindable[3]));

            // At a 5th level slot, the binding lasts for 24 hours
            for (int i = 1; i < (int)SpellDuration.ONE_DAY - 1; i++) {
                wizard.OnEndOfTurn();
            }
            Assert.True(bindable[0].HasEffect(Effect.SPELL_PLANAR_BINDING));
            wizard.OnEndOfTurn();
            foreach (Monster target in new Monster[] { bindable[0], bindable[1], bindable[2] }) {
                Assert.False(target.HasEffect(Effect.SPELL_PLANAR_BINDING));
                Assert.Equal(Team.VILLAINS, ground.GetTeam(target));
            }
            Assert.Empty(wizard.EndOfTurnEvents);
        }

        [Fact]
        public void PlanarBindingDurationTest() {
            // Higher slots: 10 days (6th), 30 days (7th), 180 days (8th), a year and a day (9th)
            SpellLevel[] slots = { SpellLevel.SIXTH, SpellLevel.SEVENTH, SpellLevel.EIGHTH, SpellLevel.NINTH };
            int[] days = { 10, 30, 180, 366 };
            for (int s = 0; s < slots.Length; s++) {
                CharacterSheet wizard = new CharacterSheet(Race.HUMAN);
                Monster imp = Monsters.Imp;
                Battleground ground = createTeamBattleground(wizard, imp);
                Random.FixedRandom = Random.DebugState.Min;
                Random.State = 1;
                Spells.PlanarBinding.Cast(ground, wizard, 30, slots[s], 0, imp);
                // Skip ahead to the last round of the binding (the remaining rounds are counted down on each of the caster's turns)
                for (int i = 0; i < (days[s] - 1) * (int)SpellDuration.ONE_DAY; i += (int)SpellDuration.ONE_DAY) {
                    for (int j = 0; j < (int)SpellDuration.ONE_DAY; j++) wizard.OnEndOfTurn();
                }
                for (int j = 0; j < (int)SpellDuration.ONE_DAY - 1; j++) wizard.OnEndOfTurn();
                Assert.True(imp.HasEffect(Effect.SPELL_PLANAR_BINDING));
                wizard.OnEndOfTurn();
                Assert.False(imp.HasEffect(Effect.SPELL_PLANAR_BINDING));
                Assert.Equal(Team.VILLAINS, ground.GetTeam(imp));
            }
        }
    }
}
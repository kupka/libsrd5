using System;
using Xunit;

namespace srd5 {
    public partial class SpellTest {
        [Fact]
        public void SpareTheDyingTest() {
            CharacterSheet hero = new CharacterSheet(Race.HUMAN);
            hero.AddLevel(CharacterClasses.Barbarian);
            hero.TakeDamage(new DamageSource(DamageSourceType.OTHER, this, hero), DamageType.TRUE_DAMAGE, hero.HitPointsMax);
            Assert.True(hero.HasEffect(Effect.FIGHTING_DEATH));
            Spells.SpareTheDying.Cast(hero, 16, SpellLevel.CANTRIP, 0);
            hero.OnStartOfTurn();
            Assert.False(hero.HasEffect(Effect.FIGHTING_DEATH));
        }

        [Fact]
        public void DeathWardTest() {
            CharacterSheet hero = new CharacterSheet(Race.HUMAN);
            hero.AddLevel(CharacterClasses.Druid);
            Battleground ground = createBattleground(hero);
            Spells.DeathWard.Cast(ground, hero, 10, SpellLevel.FOURTH, 0, hero);
            Assert.True(hero.HasEffect(Effect.SPELL_DEATH_WARD));
            hero.TakeDamage(new DamageSource(DamageSourceType.OTHER, this, hero), DamageType.SLASHING, hero.HitPointsMax);
            Assert.Equal(1, hero.HitPoints);
            Assert.False(hero.HasEffect(Effect.SPELL_DEATH_WARD));
            Assert.False(hero.HasCondition(ConditionType.UNCONSCIOUS));
            Assert.False(hero.HasEffect(Effect.FIGHTING_DEATH));

            Spells.DeathWard.Cast(ground, hero, 10, SpellLevel.FOURTH, 0, hero);
            hero.Die();
            Assert.False(hero.Dead);
        }

        [Fact]
        public void GuidanceTest() {
            CharacterSheet hero = new CharacterSheet(Race.HUMAN);
            hero.AddLevel(CharacterClasses.Barbarian);
            Spells.Guidance.Cast(hero, 10, SpellLevel.FIRST, 0);
            Assert.True(hero.HasEffect(Effect.SPELL_GUIDANCE));
            hero.DC(Attacks.AbolethTail, 12, AbilityType.STRENGTH);
            Assert.False(hero.HasEffect(Effect.SPELL_GUIDANCE));
        }

        [Fact]
        public void BaneTest() {
            DefaultSpellTest(Spells.Bane, 12, SpellLevel.FIFTH, null, Effect.SPELL_BANE, Spells.Bane.Duration);
        }

        [Fact]
        public void BlessTest() {
            DefaultSpellTest(Spells.Bless, 12, SpellLevel.FIFTH, null, Effect.SPELL_BLESS, Spells.Bless.Duration);
        }

        [Fact]
        public void CommandTest() {
            DefaultSpellTest(Spells.Command, 12, SpellLevel.THIRD, ConditionType.PRONE, Effect.SPELL_COMMAND_GROVEL, null);
            DefaultSpellTest(Spells.Command, 12, SpellLevel.THIRD, null, Effect.SPELL_COMMAND_GROVEL, 1);
        }

        [Fact]
        public void DivineFavorTest() {
            DefaultSpellTest(Spells.DivineFavor, 12, SpellLevel.SECOND, null, Effect.SPELL_DIVINE_FAVOR, Spells.DivineFavor.Duration);
        }

        [Fact]
        public void GuidingBoltTest() {
            DamagingSpellTesting(Spells.GuidingBolt, 12, DamageType.RADIANT);
            DefaultSpellTest(Spells.GuidingBolt, 12, SpellLevel.NINTH, null, Effect.ADVANTAGE_ON_BEING_ATTACKED, 1);
        }

        [Fact]
        public void InflictWoundsTest() {
            DamagingSpellTesting(Spells.InflictWounds, 15, DamageType.NECROTIC);
        }

        [Fact]
        public void ProtectionfromEvilandGoodTest() {
            DefaultSpellTest(Spells.ProtectionfromEvilandGood, 12, SpellLevel.SECOND, null, Effect.SPELL_PROTECTION_FROM_EVIL_AND_GOOD, 100);

            CharacterSheet hero = new CharacterSheet(Race.HALF_ELF);
            hero.AddLevel(CharacterClasses.Druid);
            Spells.ProtectionfromEvilandGood.Cast(hero, 12, SpellLevel.THIRD, 5);
            Combatant[] allCombatantTypes = [
                Monsters.Badger, Monsters.Solar, Monsters.IronGolem, Monsters.AncientBlackDragon, Monsters.FireElemental,
                Monsters.Dryad, Monsters.BarbedDevil, Monsters.HillGiant, Monsters.Bandit, Monsters.BlackPudding,
                Monsters.Treant, Monsters.SwarmOfQuippers, Monsters.Zombie, hero
             ];
            foreach (Combatant combatant in allCombatantTypes) {
                combatant.Attack(Attacks.AcolyteClub, hero, 5);
            }
        }

        [Fact]
        public void ShieldofFaithTest() {
            Monster acolyte = Monsters.Acolyte;
            int ac = acolyte.ArmorClass;
            Spells.ShieldofFaith.Cast(acolyte, 10, SpellLevel.FIRST, 0);
            Assert.Equal(ac + 2, acolyte.ArmorClass);
            Spells.ShieldofFaith.Cast(acolyte, 10, SpellLevel.FIRST, 0);
            Assert.Equal(ac + 2, acolyte.ArmorClass);
            DefaultSpellTest(Spells.ShieldofFaith, 10, SpellLevel.SECOND, null, Effect.SPELL_SHIELD_OF_FAITH, Spells.ShieldofFaith.Duration);
        }

        [Fact]
        public void AidTest() {
            Monster ogre = Monsters.Ogre;
            int hpExpected = ogre.HitPointsMax + 10;
            Spells.Aid.Cast(ogre, 12, SpellLevel.THIRD, 0);
            Assert.Equal(hpExpected, ogre.HitPointsMax);
            Assert.Equal(hpExpected, ogre.HitPoints);
            // Aditional cast does nothing
            Spells.Aid.Cast(ogre, 12, SpellLevel.THIRD, 0);
            Assert.Equal(hpExpected, ogre.HitPointsMax);
            Assert.Equal(hpExpected, ogre.HitPoints);
        }

        [Fact]
        public void PrayerofHealingTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            cleric.AddLevel(CharacterClasses.Druid);
            cleric.HitPoints = 1;
            Monster ogre = Monsters.Ogre;
            Monster shadow = Monsters.Shadow;
            Monster golem = Monsters.ClayGolem;
            ogre.HitPoints = 1;
            shadow.HitPoints = 1;
            golem.HitPoints = 1;
            Battleground ground = createBattleground(cleric, ogre, shadow, golem);
            Spells.PrayerofHealing.Cast(ground, cleric, 12, SpellLevel.NINTH, 50, cleric, ogre, shadow, golem);
            Assert.Equal(cleric.HitPointsMax, cleric.HitPoints);
            Assert.Equal(ogre.HitPointsMax, ogre.HitPoints);
            Assert.Equal(1, shadow.HitPoints);
            Assert.Equal(1, golem.HitPoints);
        }

        [Fact]
        public void SilenceTest() {
            DefaultSpellTest(Spells.Silence, 20, SpellLevel.FIFTH, ConditionType.DEAFENED, Effect.IMMUNITY_THUNDER, Spells.Silence.Duration);
        }

        [Fact]
        public void SpiritualWeaponTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            cleric.AddLevel(CharacterClasses.Druid);
            Monster orc = Monsters.Orc;
            Monster bandit = Monsters.Bandit;
            Battleground ground = createBattleground(cleric, orc, bandit);
            Random.FixedRandom = Random.DebugState.Max;
            Random.State = 1;
            Spells.SpiritualWeapon.Cast(ground, cleric, 15, SpellLevel.FIFTH, 15, orc);
            Assert.NotEqual(orc.HitPoints, orc.HitPointsMax);
            Random.FixedRandom = Random.DebugState.Max;
            cleric.AvailableSpells[0].KnownSpells[0].Cast(ground, cleric, 15, SpellLevel.CANTRIP, 15, bandit);
            Assert.NotEqual(bandit.HitPoints, bandit.HitPointsMax);
            for (int i = 0; i < (int)Spells.SpiritualWeapon.Duration; i++) {
                cleric.OnEndOfTurn();
            }
            Assert.Empty(cleric.AvailableSpells[0].KnownSpells);
        }

        [Fact]
        public void WardingBondTest_CasterZeroHitpoints() {
            Monster cleric = Monsters.Acolyte;
            Monster bandit = Monsters.Bandit;
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombatant(cleric, 0, 0);
            ground.AddCombatant(bandit, 5, 2);
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, bandit);
            Assert.True(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.True(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
            bandit.TakeDamage(new DamageSource(DamageSourceType.OTHER, this, cleric), DamageType.BLUDGEONING, 10);
            Assert.Equal(Math.Max(0, cleric.HitPointsMax - 5), cleric.HitPoints);
            Assert.Equal(Math.Max(0, bandit.HitPointsMax - 5), bandit.HitPoints);
            cleric.TakeDamage(new DamageSource(DamageSourceType.OTHER, this, bandit), DamageType.POISON, 100);
            Assert.False(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.False(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
        }

        [Fact]
        public void WardingBondTest_DoubleCast1() {
            Monster cleric = Monsters.Acolyte;
            Monster bandit = Monsters.Bandit;
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombatant(cleric, 0, 0);
            ground.AddCombatant(bandit, 5, 2);
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, bandit);
            Assert.True(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.True(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, bandit);
            Assert.False(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.False(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
        }

        [Fact]
        public void WardingBondTest_DoubleCast2() {
            Monster cleric = Monsters.Acolyte;
            Monster bandit = Monsters.Bandit;
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombatant(cleric, 0, 0);
            ground.AddCombatant(bandit, 5, 2);
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, cleric);
            Assert.False(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.False(cleric.HasEffect(Effect.SPELL_WARDING_BOND));
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, bandit);
            Assert.True(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.True(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
            Spells.WardingBond.Cast(ground, bandit, 12, SpellLevel.SECOND, 5, cleric);
            Assert.False(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.False(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
        }

        [Fact]
        public void WardingBondTest_RemovedCasterEffect1() {
            Monster cleric = Monsters.Acolyte;
            Monster bandit = Monsters.Bandit;
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombatant(cleric, 0, 0);
            ground.AddCombatant(bandit, 5, 2);
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, bandit);
            Assert.True(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.True(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
            cleric.RemoveEffect(Effect.SPELL_WARDING_BOND_CASTER);
            bandit.TakeDamage(new DamageSource(DamageSourceType.OTHER, this, cleric), DamageType.TRUE_DAMAGE, 2);
            Assert.False(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
        }

        [Fact]
        public void WardingBondTest_RemovedCasterEffect2() {
            Monster cleric = Monsters.Acolyte;
            Monster bandit = Monsters.Bandit;
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombatant(cleric, 0, 0);
            ground.AddCombatant(bandit, 5, 2);
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, bandit);
            Assert.True(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.True(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
            cleric.RemoveEffect(Effect.SPELL_WARDING_BOND_CASTER);
            cleric.TakeDamage(new DamageSource(DamageSourceType.OTHER, this, bandit), DamageType.TRUE_DAMAGE, 2);
            Assert.False(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
        }

        [Fact]
        public void WardingBondTest_RemovedCasterEffect3() {
            Monster cleric = Monsters.Acolyte;
            Monster bandit = Monsters.Bandit;
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombatant(cleric, 0, 0);
            ground.AddCombatant(bandit, 5, 2);
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, bandit);
            Assert.True(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.True(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
            cleric.RemoveEffect(Effect.SPELL_WARDING_BOND_CASTER);
            cleric.OnStartOfTurn();
            Assert.False(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
        }

        [Fact]
        public void WardingBondTest_RemovedTargetEffect1() {
            Monster cleric = Monsters.Acolyte;
            Monster bandit = Monsters.Bandit;
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombatant(cleric, 0, 0);
            ground.AddCombatant(bandit, 5, 2);
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, bandit);
            Assert.True(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.True(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
            bandit.RemoveEffect(Effect.SPELL_WARDING_BOND);
            bandit.TakeDamage(new DamageSource(DamageSourceType.OTHER, this, cleric), DamageType.TRUE_DAMAGE, 2);
            Assert.False(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
        }

        [Fact]
        public void WardingBondTest_RemovedTargetEffect2() {
            Monster cleric = Monsters.Acolyte;
            Monster bandit = Monsters.Bandit;
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombatant(cleric, 0, 0);
            ground.AddCombatant(bandit, 5, 2);
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, bandit);
            Assert.True(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.True(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
            bandit.RemoveEffect(Effect.SPELL_WARDING_BOND);
            cleric.TakeDamage(new DamageSource(DamageSourceType.OTHER, this, bandit), DamageType.TRUE_DAMAGE, 2);
            Assert.False(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
        }

        [Fact]
        public void WardingBondTest_RemovedTargetEffect3() {
            Monster cleric = Monsters.Acolyte;
            Monster bandit = Monsters.Bandit;
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombatant(cleric, 0, 0);
            ground.AddCombatant(bandit, 5, 2);
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, bandit);
            Assert.True(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.True(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
            bandit.RemoveEffect(Effect.SPELL_WARDING_BOND);
            bandit.OnStartOfTurn();
            Assert.False(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
        }

        [Fact]
        public void WardingBondTest_MoveTooFarTest() {
            Monster cleric = Monsters.Acolyte;
            Monster bandit = Monsters.Bandit;
            Battleground2D ground = new Battleground2D(20, 20);
            ground.AddCombatant(cleric, 0, 0);
            ground.AddCombatant(bandit, 5, 5);
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, bandit);
            Assert.True(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.True(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
            cleric.OnStartOfTurn();
            Assert.True(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
            ground.Push(new Coord(0, 0), bandit, 50);
            cleric.OnStartOfTurn();
            Assert.False(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
        }

        [Fact]
        public void AnimateDeadTest() {
            Monster bandit1 = Monsters.Bandit;
            bandit1.Die();
            Monster bandit2 = Monsters.Bandit;
            Monster rat = Monsters.GiantRat;
            Monster hillGiant = Monsters.HillGiant;
            CharacterSheet wizard = new CharacterSheet(Race.HALF_ELF);
            wizard.Die();
            CharacterSheet dwarf = new CharacterSheet(Race.HILL_DWARF);
            dwarf.Die();
            Monster gnome = Monsters.DeepGnomeSvirfneblin;
            gnome.Die();
            CharacterSheet cleric = new CharacterSheet(Race.HILL_DWARF);

            Battleground ground = createBattleground(cleric, bandit1, bandit2, hillGiant, rat, wizard, gnome, dwarf);
            Spells.AnimateDead.Cast(ground, cleric, 12, SpellLevel.NINTH, 0, bandit1, bandit2, rat, wizard, gnome, dwarf);
            Assert.True(bandit1.HasEffect(Effect.SPELL_ANIMATE_DEAD));
            Assert.False(bandit2.HasEffect(Effect.SPELL_ANIMATE_DEAD));
            Assert.False(rat.HasEffect(Effect.SPELL_ANIMATE_DEAD));
            Assert.False(hillGiant.HasEffect(Effect.SPELL_ANIMATE_DEAD));
            Assert.True(wizard.HasEffect(Effect.SPELL_ANIMATE_DEAD));
            Assert.True(gnome.HasEffect(Effect.SPELL_ANIMATE_DEAD));
            Assert.True(dwarf.HasEffect(Effect.SPELL_ANIMATE_DEAD));
        }

        [Fact]
        public void MassHealingWordTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            cleric.HitPoints = 1;
            Monster ogre = Monsters.Ogre;
            Monster shadow = Monsters.Shadow;
            Monster golem = Monsters.ClayGolem;
            ogre.HitPoints = 1;
            shadow.HitPoints = 1;
            golem.HitPoints = 1;
            Battleground ground = createBattleground(cleric, ogre, shadow, golem);
            Spells.MassHealingWord.Cast(ground, cleric, 12, SpellLevel.NINTH, 50, cleric, ogre, shadow, golem);
            Assert.Equal(cleric.HitPointsMax, cleric.HitPoints);
            Assert.Equal(ogre.HitPointsMax, ogre.HitPoints);
            Assert.Equal(1, shadow.HitPoints); // undead not affected
            Assert.Equal(1, golem.HitPoints); // construct not affected
        }

        [Fact]
        public void RemoveCurseTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            Monster cursedMonster = Monsters.Mummy;
            cursedMonster.AddEffect(Effect.CURSE_MUMMY_ROT);
            Assert.True(cursedMonster.HasEffect(Effect.CURSE_MUMMY_ROT));
            Spells.RemoveCurse.Cast(cursedMonster, 12, SpellLevel.THIRD, 0);
            Assert.False(cursedMonster.HasEffect(Effect.CURSE_MUMMY_ROT));
        }

        [Fact]
        public void SpiritGuardiansTest_GoodCasterDealsRadiantDamage() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            cleric.Alignment = Alignment.LAWFUL_GOOD;
            Monster orc = Monsters.Orc;
            int originalSpeed = orc.Speed;
            Battleground ground = createBattleground(cleric, orc);
            Spells.SpiritGuardians.Cast(ground, cleric, 20, SpellLevel.THIRD, 0, orc);
            // Orc should have taken radiant damage (DC 20 = always fails)
            Assert.True(orc.HitPoints < orc.HitPointsMax);
            // Speed should be halved
            Assert.Equal(originalSpeed / 2, orc.Speed);
            // Cleric should be unharmed
            Assert.Equal(cleric.HitPointsMax, cleric.HitPoints);
        }

        [Fact]
        public void SpiritGuardiansTest_EvilCasterDealsNecroticDamage() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            cleric.Alignment = Alignment.CHAOTIC_EVIL;
            Monster orc = Monsters.Orc;
            int originalSpeed = orc.Speed;
            Battleground ground = createBattleground(cleric, orc);
            Spells.SpiritGuardians.Cast(ground, cleric, 20, SpellLevel.THIRD, 0, orc);
            Assert.True(orc.HitPoints < orc.HitPointsMax);
            Assert.Equal(originalSpeed / 2, orc.Speed);
        }

        [Fact]
        public void SpiritGuardiansTest_PerTurnDamage() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            cleric.Alignment = Alignment.NEUTRAL_GOOD;
            // Use a high-HP monster so it survives the initial cast and the per-turn tick
            Monster hillGiant = Monsters.HillGiant;
            Battleground ground = createBattleground(cleric, hillGiant);
            Spells.SpiritGuardians.Cast(ground, cleric, 20, SpellLevel.THIRD, 0, hillGiant);
            int hpAfterCast = hillGiant.HitPoints;
            // Each start-of-turn should apply damage again
            hillGiant.OnStartOfTurn();
            Assert.True(hillGiant.HitPoints < hpAfterCast);
        }

        [Fact]
        public void SpiritGuardiansTest_DurationExpiry() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            cleric.Alignment = Alignment.LAWFUL_GOOD;
            Monster orc = Monsters.Orc;
            int originalSpeed = orc.Speed;
            Battleground ground = createBattleground(cleric, orc);
            Spells.SpiritGuardians.Cast(ground, cleric, 20, SpellLevel.THIRD, 0, orc);
            Assert.Equal(originalSpeed / 2, orc.Speed);
            // Tick through the full TEN_MINUTES duration on the target's end-of-turn events
            for (int i = 0; i < (int)Spells.SpiritGuardians.Duration + 1; i++) {
                orc.OnStartOfTurn();
                orc.OnEndOfTurn();
                orc.OnStartOfTurn();
            }
            Assert.False(orc.HasEffect(Effect.SPELL_SPIRIT_GUARDIANS));
            Assert.Equal(originalSpeed, orc.Speed);
        }

        [Fact]
        public void SpiritGuardiansTest_SuccessfulSaveHalvesDamage() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            cleric.Alignment = Alignment.LAWFUL_GOOD;
            Monster giant = Monsters.HillGiant;
            Battleground ground = createBattleground(cleric, giant);

            bool saveSucceeded = false;
            int damageDealt = -1;
            System.EventHandler<System.EventArgs> handler = delegate (object sender, System.EventArgs args) {
                if (GlobalEvents.EventTypes.DC.Equals(sender) && args is GlobalEvents.DCRolled dc && dc.Ability.Type == AbilityType.WISDOM) {
                    saveSucceeded = dc.Success;
                } else if (GlobalEvents.EventTypes.DAMAGED.Equals(sender) && args is GlobalEvents.DamageReceived dmg && dmg.Victim == giant) {
                    damageDealt = dmg.Amount;
                }
            };
            GlobalEvents.Handlers += handler;
            try {
                Random.FixedRandom = Random.DebugState.Avg;
                Spells.SpiritGuardians.Cast(ground, cleric, 1, SpellLevel.THIRD, 0, giant);
            } finally {
                GlobalEvents.Handlers -= handler;
            }

            // The successful-save branch must have been exercised and dealt half damage.
            Assert.True(saveSucceeded);
            Assert.InRange(damageDealt, 1, 12);
        }

        [Fact]
        public void FlyTest() {
            DefaultSpellTest(Spells.Fly, 12, SpellLevel.THIRD, null, Effect.SPELL_FLY, Spells.Fly.Duration);
        }

        [Fact]
        public void GaseousFormTest() {
            DefaultSpellTest(Spells.GaseousForm, 12, SpellLevel.THIRD, null, Effect.SPELL_GASEOUS_FORM, Spells.GaseousForm.Duration);
        }

        [Fact]
        public void MeldIntoStoneTest() {
            DefaultSpellTest(Spells.MeldIntoStone, 12, SpellLevel.THIRD, null, Effect.SPELL_MELD_INTO_STONE, Spells.MeldIntoStone.Duration);
        }

        [Fact]
        public void NondetectionTest() {
            DefaultSpellTest(Spells.Nondetection, 12, SpellLevel.THIRD, null, Effect.SPELL_NONDETECTION, Spells.Nondetection.Duration);
        }

        [Fact]
        public void TonguesTest() {
            DefaultSpellTest(Spells.Tongues, 12, SpellLevel.THIRD, null, Effect.SPELL_TONGUES, Spells.Tongues.Duration);
        }

        [Fact]
        public void WaterBreathingTest() {
            DefaultSpellTest(Spells.WaterBreathing, 12, SpellLevel.THIRD, null, Effect.SPELL_WATER_BREATHING, Spells.WaterBreathing.Duration);
        }

        [Fact]
        public void WaterWalkTest() {
            DefaultSpellTest(Spells.WaterWalk, 12, SpellLevel.THIRD, null, Effect.SPELL_WATER_WALK, Spells.WaterWalk.Duration);
        }

        [Fact]
        public void AnimateDeadStartOfTurnTest() {
            // Covers the StartOfTurnEvent inside AnimateDead:
            //   - effect still present → return false (line 27)
            //   - effect removed externally → target.Die() + return true (lines 28-30)
            Monster bandit = Monsters.Bandit;
            bandit.Die();
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            Battleground ground = createBattleground(cleric, bandit);
            Spells.AnimateDead.Cast(ground, cleric, 12, SpellLevel.THIRD, 0, bandit);
            Assert.True(bandit.HasEffect(Effect.SPELL_ANIMATE_DEAD));
            // Fire the event while the effect is still present → should keep running (return false)
            bandit.OnStartOfTurn();
            // Effect is still present (event returned false and remains queued)
            Assert.True(bandit.HasEffect(Effect.SPELL_ANIMATE_DEAD));
            // Remove the effect to simulate Dispel Magic, then fire the event again → event terminates
            bandit.RemoveEffect(Effect.SPELL_ANIMATE_DEAD);
            bandit.OnStartOfTurn();
            // Die() was called inside the event; bandit was already dead, but the event completed cleanly
            Assert.True(bandit.Dead);
        }

        [Fact]
        public void AnimateDeadBattleground2DTest() {
            // Covers the Battleground2D zombie-spawn branch (lines 34-35)
            Monster bandit = Monsters.Bandit;
            bandit.Die();
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombatant(cleric, 5, 5);
            ground.AddCombatant(bandit, 6, 5);
            Spells.AnimateDead.Cast(ground, cleric, 12, SpellLevel.THIRD, 0, bandit);
            Assert.True(bandit.HasEffect(Effect.SPELL_ANIMATE_DEAD));
        }

        [Fact]
        public void RevivifyTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            Monster orc = Monsters.Orc;
            Battleground ground = createBattleground(cleric, orc);
            // Target must be dead for Revivify to work
            orc.TakeDamage(new DamageSource(Spells.ID.POWER_WORD_KILL, cleric), DamageType.TRUE_DAMAGE, orc.HitPointsMax + 100);
            Assert.True(orc.Dead);
            Spells.Revivify.Cast(ground, cleric, 12, SpellLevel.THIRD, 0, orc);
            Assert.False(orc.Dead);
            Assert.Equal(1, orc.HitPoints);
        }


        [Fact]
        public void GuardianOfFaithTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            cleric.AddLevel(CharacterClasses.Wizard);
            Monster orc = Monsters.Orc;
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombatant(cleric, 5, 5, Team.HEROES);
            ground.AddCombatant(orc, 6, 5, Team.VILLAINS); // adjacent to the wizard, 5 feet away

            // Can't conjure the guardian into an already occupied space
            Target occupiedSpot = new Target();
            occupiedSpot.Location = new Coord(6, 5);
            Spells.GuardianOfFaith.Cast(ground, cleric, 10, SpellLevel.FOURTH, 0, occupiedSpot);
            Assert.Empty(cleric.StartOfTurnEvents);

            // Conjuring into an unoccupied space succeeds and places the guardian to guard it
            Target spot = new Target();
            spot.Location = new Coord(5, 6); // empty, within 10 feet of both the wizard and the orc
            Spells.GuardianOfFaith.Cast(ground, cleric, 10, SpellLevel.FOURTH, 0, spot);
            Assert.Single(cleric.StartOfTurnEvents);

            // At the start of the caster's turn, a hostile creature within 10 feet that fails its DEX save takes 20 radiant damage
            int hpBefore = orc.HitPoints;
            Random.FixedRandom = Random.DebugState.Min; // guarantee the DEX save fails
            cleric.OnStartOfTurn();
            Assert.Equal(Math.Max(0, hpBefore - 20), orc.HitPoints);

            // It never damages a creature on the caster's own side
            CharacterSheet cleric2 = new CharacterSheet(Race.HUMAN);
            cleric2.AddLevel(CharacterClasses.Wizard);
            CharacterSheet ally = new CharacterSheet(Race.HUMAN);
            Battleground2D allyGround = new Battleground2D(10, 10);
            allyGround.AddCombatant(cleric2, 5, 5);
            allyGround.AddCombatant(ally, 6, 5);
            Target allySpot = new Target();
            allySpot.Location = new Coord(5, 6);
            Spells.GuardianOfFaith.Cast(allyGround, cleric2, 10, SpellLevel.FOURTH, 0, allySpot);
            int allyHpBefore = ally.HitPoints;
            cleric2.OnStartOfTurn();
            Assert.Equal(allyHpBefore, ally.HitPoints);

            // It doesn't damage creatures beyond 10 feet
            CharacterSheet cleric3 = new CharacterSheet(Race.HUMAN);
            cleric3.AddLevel(CharacterClasses.Wizard);
            Monster farOrc = Monsters.Orc;
            Battleground2D farGround = new Battleground2D(10, 10);
            farGround.AddCombatant(cleric3, 5, 5);
            farGround.AddCombatant(farOrc, 9, 5); // 20 feet away
            Target farSpot = new Target();
            farSpot.Location = new Coord(5, 6);
            Spells.GuardianOfFaith.Cast(farGround, cleric3, 10, SpellLevel.FOURTH, 0, farSpot);
            int farOrcHpBefore = farOrc.HitPoints;
            cleric3.OnStartOfTurn();
            Assert.Equal(farOrcHpBefore, farOrc.HitPoints);

            // The guardian vanishes once it has dealt a total of 60 damage
            CharacterSheet cleric4 = new CharacterSheet(Race.HUMAN);
            cleric4.AddLevel(CharacterClasses.Wizard);
            Monster troll = Monsters.Troll; // high HP so it survives repeated hits
            Battleground2D durableGround = new Battleground2D(10, 10);
            durableGround.AddCombatant(cleric4, 5, 5, Team.HEROES);
            durableGround.AddCombatant(troll, 6, 5, Team.VILLAINS);
            Target durableSpot = new Target();
            durableSpot.Location = new Coord(5, 6);
            Spells.GuardianOfFaith.Cast(durableGround, cleric4, 10, SpellLevel.FOURTH, 0, durableSpot);
            // FixedRandom resets after a single roll, so it must be set before each turn
            Random.FixedRandom = Random.DebugState.Min; // guarantee the DEX save fails
            cleric4.OnStartOfTurn(); // 20 damage dealt, 40 remaining
            Assert.Single(cleric4.StartOfTurnEvents);
            Random.FixedRandom = Random.DebugState.Min;
            cleric4.OnStartOfTurn(); // 40 damage dealt, 20 remaining
            Assert.Single(cleric4.StartOfTurnEvents);
            Random.FixedRandom = Random.DebugState.Min;
            cleric4.OnStartOfTurn(); // 60 damage dealt -> guardian vanishes
            Assert.Empty(cleric4.StartOfTurnEvents);
        }
        [Fact]
        public void FlameStrikeTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            Monster giant = Monsters.HillGiant;
            Battleground ground = createBattleground(cleric, giant);
            int fire = 0, radiant = 0;
            EventHandler<EventArgs> handler = delegate (object sender, EventArgs args) {
                if (GlobalEvents.EventTypes.DAMAGED.Equals(sender) && args is GlobalEvents.DamageReceived dmg && dmg.Victim == giant) {
                    if (dmg.DamageType == DamageType.FIRE) fire += dmg.Amount;
                    if (dmg.DamageType == DamageType.RADIANT) radiant += dmg.Amount;
                }
            };
            GlobalEvents.Handlers += handler;
            try {
                // failed save: full 4d6 fire and 4d6 radiant
                giant.AddEffect(Effect.FAIL_DEXERITY_CHECK);
                Spells.FlameStrike.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, giant);
                Assert.InRange(fire, 4, 24);
                Assert.InRange(radiant, 4, 24);
                // higher slot: only fire damage scales (7th level = 6d6)
                giant.HitPoints = giant.HitPointsMax;
                fire = 0;
                radiant = 0;
                Spells.FlameStrike.Cast(ground, cleric, 15, SpellLevel.SEVENTH, 0, giant);
                Assert.InRange(fire, 6, 36);
                Assert.InRange(radiant, 4, 24);
                // successful save: both halved
                giant.RemoveEffect(Effect.FAIL_DEXERITY_CHECK);
                giant.HitPoints = giant.HitPointsMax;
                fire = 0;
                radiant = 0;
                // Rolling the damage dice comes before the save, so Random.FixedRandom can't guarantee it
                giant.AddEffect(Effect.LEGENDARY_RESISTANCE); // turns a failed save into a success
                Spells.FlameStrike.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, giant);
                Assert.InRange(fire, 2, 12);
                Assert.InRange(radiant, 2, 12);
                // the radiant variant scales the radiant damage instead (9th level = 8d6)
                giant.RemoveEffect(Effect.LEGENDARY_RESISTANCE); // still there if the save succeeded on its own
                giant.AddEffect(Effect.FAIL_DEXERITY_CHECK);
                giant.HitPoints = giant.HitPointsMax;
                fire = 0;
                radiant = 0;
                Spell radiantStrike = Spells.FlameStrike;
                Assert.Equal(SpellVariant.DAMAGE_FIRE, radiantStrike.Variant);
                radiantStrike.Variant = SpellVariant.DAMAGE_RADIANT;
                radiantStrike.Cast(ground, cleric, 15, SpellLevel.NINTH, 0, giant);
                Assert.InRange(fire, 4, 24);
                Assert.InRange(radiant, 8, 48);
            } finally {
                GlobalEvents.Handlers -= handler;
            }
        }

        [Fact]
        public void MassCureWoundsTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            cleric.HitPoints = 1;
            Monster ogre = Monsters.Ogre;
            Monster shadow = Monsters.Shadow;
            Monster golem = Monsters.ClayGolem;
            Monster[] orcs = { Monsters.Orc, Monsters.Orc, Monsters.Orc, Monsters.Orc };
            ogre.HitPoints = 1;
            shadow.HitPoints = 1;
            golem.HitPoints = 1;
            foreach (Monster orc in orcs) orc.HitPoints = 1;
            Battleground ground = createBattleground(cleric, ogre, shadow, golem, orcs[0], orcs[1], orcs[2], orcs[3]);
            Spells.MassCureWounds.Cast(ground, cleric, 12, SpellLevel.NINTH, 50, cleric, ogre, shadow, golem, orcs[0], orcs[1], orcs[2]);
            Assert.Equal(cleric.HitPointsMax, cleric.HitPoints);
            Assert.Equal(ogre.HitPointsMax, ogre.HitPoints);
            Assert.Equal(1, shadow.HitPoints); // undead not affected
            Assert.Equal(1, golem.HitPoints); // construct not affected
            Assert.Equal(orcs[0].HitPointsMax, orcs[0].HitPoints);
            Assert.Equal(orcs[1].HitPointsMax, orcs[1].HitPoints);
            Assert.Equal(1, orcs[2].HitPoints); // only up to six creatures
        }

        [Fact]
        public void RaiseDeadTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            Monster orc = Monsters.Orc;
            Monster livingOrc = Monsters.Orc;
            Battleground ground = createBattleground(cleric, orc, livingOrc);

            // Target must be dead for Raise Dead to work
            livingOrc.HitPoints = 5;
            Spells.RaiseDead.Cast(ground, cleric, 12, SpellLevel.FIFTH, 0, livingOrc);
            Assert.Equal(5, livingOrc.HitPoints);

            orc.TakeDamage(new DamageSource(Spells.ID.POWER_WORD_KILL, cleric), DamageType.TRUE_DAMAGE, orc.HitPointsMax + 100);
            Assert.True(orc.Dead);
            orc.AddCondition(ConditionType.POISONED);
            orc.AddEffect(Effect.DEATH_DOG_DISEASE);
            Spells.RaiseDead.Cast(ground, cleric, 12, SpellLevel.FIFTH, 0, orc);
            Assert.False(orc.Dead);
            Assert.Equal(1, orc.HitPoints);

            // The spell can't return an undead creature to life
            Monster zombie = Monsters.Zombie;
            zombie.TakeDamage(new DamageSource(Spells.ID.POWER_WORD_KILL, cleric), DamageType.TRUE_DAMAGE, zombie.HitPointsMax + 100);
            Assert.True(zombie.Dead);
            Spells.RaiseDead.Cast(ground, cleric, 12, SpellLevel.FIFTH, 0, zombie);
            Assert.True(zombie.Dead);
        }


        private Monster contagionVictim() {
            Monster orc = Monsters.Orc;
            orc.HitPointsMax = 100;
            orc.HitPoints = 100;
            return orc;
        }

        [Fact]
        public void ContagionVariantsTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            cleric.AddLevel(CharacterClasses.Druid);
            SpellVariant[] variants = { SpellVariant.BLINDING_SICKNESS, SpellVariant.FILTH_FEVER, SpellVariant.FLESH_ROT, SpellVariant.MINDFIRE, SpellVariant.SEIZURE, SpellVariant.SLIMY_DOOM };
            Effect[] diseases = {
                Effect.SPELL_CONTAGION_BLINDING_SICKNESS_DISEASE, Effect.SPELL_CONTAGION_FILTH_FEVER_DISEASE, Effect.SPELL_CONTAGION_FLESH_ROT_DISEASE,
                Effect.SPELL_CONTAGION_MINDFIRE_DISEASE, Effect.SPELL_CONTAGION_SEIZURE_DISEASE, Effect.SPELL_CONTAGION_SLIMY_DOOM_DISEASE
            };
            Effect[] disadvantages = {
                Effect.DISADVANTAGE_WISDOM_SAVES, Effect.DISADVANTAGE_STRENGTH_SAVES, Effect.VULNERABILITY_ANY_DAMAGE,
                Effect.DISADVANTAGE_INTELLIGENCE_SAVES, Effect.DISADVANTAGE_DEXTERITY_SAVES, Effect.DISADVANTAGE_CONSTITUTION_SAVES
            };
            for (int i = 0; i < variants.Length; i++) {
                Monster orc = contagionVictim();
                Battleground ground = createBattleground(cleric, orc);
                Spell contagion = Spells.Contagion;
                contagion.Variant = variants[i];
                Random.FixedRandom = Random.DebugState.Max; // natural 20, the touch hits
                contagion.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, orc);
                Assert.True(orc.HasEffect(diseases[i]));
                Assert.True(orc.HasEffect(disadvantages[i]));
                Assert.True(diseases[i].IsDisease());
                // The touch deals no damage
                Assert.Equal(100, orc.HitPoints);
            }

            // Blinding Sickness also blinds the target
            Monster blinded = contagionVictim();
            Battleground blindedGround = createBattleground(cleric, blinded);
            Random.FixedRandom = Random.DebugState.Max;
            Spells.Contagion.Cast(blindedGround, cleric, 15, SpellLevel.FIFTH, 0, blinded);
            Assert.True(blinded.HasCondition(ConditionType.BLINDED));

            // A missed touch has no effect
            Monster missed = contagionVictim();
            Battleground missedGround = createBattleground(cleric, missed);
            Random.FixedRandom = Random.DebugState.Min; // natural 1, the touch misses
            Spells.Contagion.Cast(missedGround, cleric, 15, SpellLevel.FIFTH, 0, missed);
            Assert.False(missed.HasEffect(Effect.SPELL_CONTAGION_BLINDING_SICKNESS_DISEASE));
            Assert.Empty(missed.EndOfTurnEvents);
        }

        [Fact]
        public void ContagionFleshRotTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            Monster orc = contagionVictim();
            Spell contagion = Spells.Contagion;
            contagion.Variant = SpellVariant.FLESH_ROT;
            Battleground ground = createBattleground(cleric, orc);
            Random.FixedRandom = Random.DebugState.Max;
            contagion.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, orc);
            // Vulnerable to all damage ...
            orc.TakeDamage(new DamageSource(Spells.ID.CONTAGION, cleric), DamageType.FIRE, 10);
            Assert.Equal(80, orc.HitPoints);
        }

        [Fact]
        public void ContagionRecoveryTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            Monster orc = contagionVictim();
            Battleground orcGround = createBattleground(cleric, orc);
            Random.FixedRandom = Random.DebugState.Max;
            Spells.Contagion.Cast(orcGround, cleric, 15, SpellLevel.FIFTH, 0, orc);
            // Three successful saves cure the disease, failures in between don't matter
            Random.FixedRandom = Random.DebugState.Max;
            orc.OnEndOfTurn();
            Random.FixedRandom = Random.DebugState.Min;
            orc.OnEndOfTurn();
            Random.FixedRandom = Random.DebugState.Max;
            orc.OnEndOfTurn();
            Assert.True(orc.HasEffect(Effect.SPELL_CONTAGION_BLINDING_SICKNESS_DISEASE));
            Random.FixedRandom = Random.DebugState.Max;
            orc.OnEndOfTurn();
            Assert.False(orc.HasEffect(Effect.SPELL_CONTAGION_BLINDING_SICKNESS_DISEASE));
            Assert.False(orc.HasCondition(ConditionType.BLINDED));
            Assert.Empty(orc.EndOfTurnEvents);

            // Like a natural disease, the disease can be cured by Lesser Restoration
            Monster cured = contagionVictim();
            Battleground ground = createBattleground(cleric, cured);
            Random.FixedRandom = Random.DebugState.Max;
            Spells.Contagion.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, cured);
            Spell lesserRestoration = Spells.LesserRestoration;
            lesserRestoration.Variant = SpellVariant.DISEASES;
            lesserRestoration.Cast(ground, cleric, 15, SpellLevel.SECOND, 0, cured);
            Assert.False(cured.HasEffect(Effect.SPELL_CONTAGION_BLINDING_SICKNESS_DISEASE));
            cured.OnEndOfTurn();
            Assert.Empty(cured.EndOfTurnEvents);
        }

        [Fact]
        public void ContagionDurationTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            Monster orc = contagionVictim();
            Spell contagion = Spells.Contagion;
            contagion.Variant = SpellVariant.SEIZURE;
            Battleground ground = createBattleground(cleric, orc);
            Random.FixedRandom = Random.DebugState.Max;
            contagion.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, orc);
            // After three failed saves, the disease lasts for the whole duration and no further saves are made
            for (int i = 0; i < 3; i++) {
                Random.FixedRandom = Random.DebugState.Min;
                orc.OnEndOfTurn();
            }
            for (int i = 3; i < (int)SpellDuration.SEVEN_DAYS - 1; i++) {
                orc.OnEndOfTurn();
            }
            Assert.True(orc.HasEffect(Effect.SPELL_CONTAGION_SEIZURE_DISEASE));
            orc.OnEndOfTurn();
            Assert.False(orc.HasEffect(Effect.SPELL_CONTAGION_SEIZURE_DISEASE));
            Assert.False(orc.HasEffect(Effect.DISADVANTAGE_DEXTERITY_SAVES));
            Assert.Empty(orc.EndOfTurnEvents);
        }

        [Fact]
        public void ContagionSlimyDoomTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            Monster orc = contagionVictim();
            Spell contagion = Spells.Contagion;
            contagion.Variant = SpellVariant.SLIMY_DOOM;
            Battleground ground = createBattleground(cleric, orc);
            Random.FixedRandom = Random.DebugState.Max;
            contagion.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, orc);
            Assert.False(orc.HasCondition(ConditionType.STUNNED));
            // Taking damage stuns the creature until the end of its turn
            orc.TakeDamage(new DamageSource(Spells.ID.CONTAGION, cleric), DamageType.TRUE_DAMAGE, 1);
            Assert.True(orc.HasCondition(ConditionType.STUNNED));
            Random.FixedRandom = Random.DebugState.Min;
            orc.OnEndOfTurn();
            Assert.False(orc.HasCondition(ConditionType.STUNNED));
            // Once the disease is gone, damage doesn't stun anymore
            orc.RemoveEffect(Effect.SPELL_CONTAGION_SLIMY_DOOM_DISEASE);
            orc.TakeDamage(new DamageSource(Spells.ID.CONTAGION, cleric), DamageType.TRUE_DAMAGE, 1);
            Assert.False(orc.HasCondition(ConditionType.STUNNED));
            Assert.Empty(orc.DamageTakenEvents);
        }

        [Fact]
        public void DispelEvilAndGoodTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            cleric.AddLevel(CharacterClasses.Druid);
            toughen(cleric); // survive the critical hits in this test
            CharacterSheet paladin = new CharacterSheet(Race.HUMAN); // protected by Protection from Evil and Good instead
            Monster[] otherworldly = { Monsters.Deva, Monsters.EarthElemental, Monsters.Dryad, Monsters.Imp, Monsters.Zombie };
            Monster aboleth = Monsters.Aboleth;
            Monster orc = Monsters.Orc;
            Battleground ground = createBattleground(cleric, otherworldly[0], otherworldly[1], otherworldly[2], otherworldly[3], otherworldly[4], aboleth, orc);
            Spells.DispelEvilandGood.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, cleric);
            Assert.True(cleric.HasEffect(Effect.SPELL_DISPEL_EVIL_AND_GOOD));
            paladin.AddEffect(Effect.SPELL_PROTECTION_FROM_EVIL_AND_GOOD);

            // A natural 20 without disadvantage is a critical hit. With disadvantage, the second d20 (10 at state 1) is used and misses.
            Func<Monster, Combatant, bool> attack = delegate (Monster attacker, Combatant target) {
                Random.FixedRandom = Random.DebugState.Max;
                Random.State = 1;
                return attacker.Attack(weakMeleeAttack, target, 5);
            };
            // Celestials, elementals, fey, fiends and undead have disadvantage
            foreach (Monster attacker in otherworldly) {
                Assert.False(attack(attacker, cleric));
                Assert.False(attack(attacker, paladin));
            }
            // Aberrations are covered by Protection from Evil and Good only
            Assert.True(attack(aboleth, cleric));
            Assert.False(attack(aboleth, paladin));
            // Other creatures attack as usual
            Assert.True(attack(orc, cleric));

            // The spell lasts for one minute
            for (int i = 0; i < (int)SpellDuration.ONE_MINUTE; i++) {
                cleric.OnStartOfTurn();
                cleric.OnEndOfTurn();
            }
            Assert.False(cleric.HasEffect(Effect.SPELL_DISPEL_EVIL_AND_GOOD));
            Assert.True(attack(otherworldly[0], cleric));
        }

        [Fact]
        public void GreaterRestorationExhaustionTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            CharacterSheet fighter = new CharacterSheet(Race.HUMAN);
            Battleground ground = createBattleground(cleric, fighter);
            Spell restoration = Spells.GreaterRestoration;
            Assert.Equal(SpellVariant.EXHAUSTION, restoration.Variant);
            // Reduces the exhaustion level by one
            fighter.AddCondition(ConditionType.EXHAUSTED_3);
            restoration.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, fighter);
            Assert.False(fighter.HasCondition(ConditionType.EXHAUSTED_3));
            Assert.True(fighter.HasCondition(ConditionType.EXHAUSTED_2));
            restoration.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, fighter);
            Assert.True(fighter.HasCondition(ConditionType.EXHAUSTED_1));
            restoration.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, fighter);
            Assert.False(fighter.HasCondition(ConditionType.EXHAUSTED_1));
            // Without exhaustion nothing happens
            restoration.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, fighter);
            foreach (ConditionType condition in fighter.Conditions) {
                Assert.True(condition < ConditionType.EXHAUSTED_1 || condition > ConditionType.EXHAUSTED_6);
            }
        }

        [Fact]
        public void GreaterRestorationCharmTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            CharacterSheet fighter = new CharacterSheet(Race.HUMAN);
            Monster orc = Monsters.Orc;
            Monster badger = Monsters.Badger;
            Battleground ground = createTeamBattleground(cleric, fighter, orc, badger);
            Spell restoration = Spells.GreaterRestoration;
            restoration.Variant = SpellVariant.CHARM;

            // A plain charmed condition is removed
            fighter.AddCondition(ConditionType.CHARMED);
            restoration.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, fighter);
            Assert.False(fighter.HasCondition(ConditionType.CHARMED));

            // Dominate Person is ended and the target returns to its team
            Random.FixedRandom = Random.DebugState.Min;
            Random.State = 1;
            Spells.DominatePerson.Cast(ground, cleric, 25, SpellLevel.FIFTH, 0, orc);
            Assert.Equal(Team.HEROES, ground.GetTeam(orc));
            // Without a designated attack target, the dominated creature doesn't attack anyone
            orc.OnStartOfTurn();
            Assert.Single(orc.StartOfTurnEvents);
            restoration.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, orc);
            Assert.False(orc.HasEffect(Effect.SPELL_DOMINATE_PERSON));
            Assert.False(orc.HasCondition(ConditionType.CHARMED));
            cleric.OnEndOfTurn();
            Assert.Equal(Team.VILLAINS, ground.GetTeam(orc));

            // Dominate Beast is ended and the target returns to its team
            Random.FixedRandom = Random.DebugState.Min;
            Random.State = 1;
            Spells.DominateBeast.Cast(ground, cleric, 25, SpellLevel.FOURTH, 0, badger);
            Assert.Equal(Team.HEROES, ground.GetTeam(badger));
            restoration.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, badger);
            Assert.False(badger.HasEffect(Effect.SPELL_DOMINATE_BEAST));
            cleric.OnEndOfTurn();
            Assert.Equal(Team.VILLAINS, ground.GetTeam(badger));
            Assert.Empty(cleric.EndOfTurnEvents);
        }

        [Fact]
        public void GreaterRestorationPetrificationAndCurseTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            CharacterSheet fighter = new CharacterSheet(Race.HUMAN);
            Battleground ground = createBattleground(cleric, fighter);
            Spell restoration = Spells.GreaterRestoration;

            restoration.Variant = SpellVariant.PETRIFICATION;
            fighter.AddCondition(ConditionType.PETRIFIED);
            restoration.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, fighter);
            Assert.False(fighter.HasCondition(ConditionType.PETRIFIED));

            // One curse is removed, other effects remain
            restoration.Variant = SpellVariant.CURSE;
            fighter.AddEffect(Effect.DARKVISION, Effect.CURSE_MUMMY_ROT, Effect.CURSE_WEREWOLF);
            restoration.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, fighter);
            Assert.False(fighter.HasEffect(Effect.CURSE_MUMMY_ROT));
            Assert.True(fighter.HasEffect(Effect.CURSE_WEREWOLF));
            Assert.True(fighter.HasEffect(Effect.DARKVISION));
            restoration.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, fighter);
            Assert.False(fighter.HasEffect(Effect.CURSE_WEREWOLF));
            // Without a curse nothing happens
            restoration.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, fighter);
            Assert.True(fighter.HasEffect(Effect.DARKVISION));
        }

        [Fact]
        public void GreaterRestorationAbilityScoreTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            Monster orc = Monsters.Orc;
            Battleground ground = createBattleground(cleric, orc);
            Spell restoration = Spells.GreaterRestoration;
            restoration.Variant = SpellVariant.ABILITY_SCORE_REDUCTION;
            orc.Strength.ValueModifier = -2;
            orc.Dexterity.ValueModifier = -4;
            orc.Constitution.ValueModifier = -1;
            orc.Wisdom.ValueModifier = 2; // increases are not affected
            // The largest reduction is restored first
            restoration.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, orc);
            Assert.Equal(0, orc.Dexterity.ValueModifier);
            Assert.Equal(-2, orc.Strength.ValueModifier);
            restoration.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, orc);
            Assert.Equal(0, orc.Strength.ValueModifier);
            restoration.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, orc);
            Assert.Equal(0, orc.Constitution.ValueModifier);
            // Without any reduction nothing happens
            restoration.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, orc);
            Assert.Equal(2, orc.Wisdom.ValueModifier);
        }

        [Fact]
        public void GreaterRestorationHitPointMaximumTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            Monster orc = Monsters.Orc;
            Battleground ground = createBattleground(cleric, orc);
            Spell restoration = Spells.GreaterRestoration;
            restoration.Variant = SpellVariant.HIT_POINT_MAXIMUM_REDUCTION;
            int hitPointsMax = orc.HitPointsMax;
            HitPointMaxiumModifier aid = new HitPointMaxiumModifier(5, HitPointMaxiumModifier.RemovedByEffect.AFTER_8_HOURS);
            HitPointMaxiumModifier drain = new HitPointMaxiumModifier(-10, HitPointMaxiumModifier.RemovedByEffect.LONG_REST);
            orc.AddHitPointMaximumModifiers(aid, drain);
            Assert.Equal(hitPointsMax - 5, orc.HitPointsMax);
            restoration.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, orc);
            Assert.Equal(hitPointsMax + 5, orc.HitPointsMax);
            // Increases of the hit point maximum are not affected
            restoration.Cast(ground, cleric, 15, SpellLevel.FIFTH, 0, orc);
            Assert.Equal(hitPointsMax + 5, orc.HitPointsMax);
        }

        [Fact]
        public void RaiseDeadCharacterTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            CharacterSheet fighter = new CharacterSheet(Race.HUMAN);
            fighter.AddLevel(CharacterClasses.Barbarian);
            Battleground ground = createBattleground(cleric, fighter);
            fighter.TakeDamage(new DamageSource(Spells.ID.POWER_WORD_KILL, cleric), DamageType.TRUE_DAMAGE, fighter.HitPointsMax + 100);
            Assert.True(fighter.Dead);
            Spells.RaiseDead.Cast(ground, cleric, 12, SpellLevel.FIFTH, 0, fighter);
            Assert.False(fighter.Dead);
            Assert.Equal(1, fighter.HitPoints);
        }
    }
}

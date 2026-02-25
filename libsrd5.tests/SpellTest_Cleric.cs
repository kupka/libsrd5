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
            Combattant[] allCombattantTypes = [
                Monsters.Badger, Monsters.Solar, Monsters.IronGolem, Monsters.AncientBlackDragon, Monsters.FireElemental,
                Monsters.Dryad, Monsters.BarbedDevil, Monsters.HillGiant, Monsters.Bandit, Monsters.BlackPudding,
                Monsters.Treant, Monsters.SwarmOfQuippers, Monsters.Zombie, hero
             ];
            foreach (Combattant combattant in allCombattantTypes) {
                combattant.Attack(Attacks.AcolyteClub, hero, 5);
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
            Spells.SpiritualWeapon.Cast(ground, cleric, 15, SpellLevel.FIFTH, 15, orc);
            Assert.True(orc.HitPoints < orc.HitPointsMax);
            cleric.AvailableSpells[0].KnownSpells[0].Cast(ground, cleric, 15, SpellLevel.CANTRIP, 15, bandit);
            Assert.True(bandit.HitPoints < bandit.HitPointsMax);
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
            ground.AddCombattant(cleric, 0, 0);
            ground.AddCombattant(bandit, 5, 2);
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, bandit);
            Assert.True(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.True(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
            bandit.TakeDamage(new DamageSource(DamageSourceType.OTHER, this, cleric), DamageType.BLUDGEONING, 10);
            Assert.True(cleric.HitPoints == cleric.HitPointsMax - 5);
            Assert.True(bandit.HitPoints == bandit.HitPointsMax - 5);
            cleric.TakeDamage(new DamageSource(DamageSourceType.OTHER, this, bandit), DamageType.POISON, 100);
            Assert.False(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.False(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
        }

        [Fact]
        public void WardingBondTest_DoubleCast1() {
            Monster cleric = Monsters.Acolyte;
            Monster bandit = Monsters.Bandit;
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombattant(cleric, 0, 0);
            ground.AddCombattant(bandit, 5, 2);
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
            ground.AddCombattant(cleric, 0, 0);
            ground.AddCombattant(bandit, 5, 2);
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
            ground.AddCombattant(cleric, 0, 0);
            ground.AddCombattant(bandit, 5, 2);
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
            ground.AddCombattant(cleric, 0, 0);
            ground.AddCombattant(bandit, 5, 2);
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
            ground.AddCombattant(cleric, 0, 0);
            ground.AddCombattant(bandit, 5, 2);
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
            ground.AddCombattant(cleric, 0, 0);
            ground.AddCombattant(bandit, 5, 2);
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
            ground.AddCombattant(cleric, 0, 0);
            ground.AddCombattant(bandit, 5, 2);
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
            ground.AddCombattant(cleric, 0, 0);
            ground.AddCombattant(bandit, 5, 2);
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
            ground.AddCombattant(cleric, 0, 0);
            ground.AddCombattant(bandit, 5, 5);
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
            CharacterSheet cleric = new CharacterSheet(Race.HILL_DWARF);

            Battleground ground = createBattleground(cleric, bandit1, bandit2, hillGiant, rat, wizard);
            Spells.AnimateDead.Cast(ground, cleric, 12, SpellLevel.NINTH, 0, bandit1, bandit2, rat, wizard);
            Assert.True(bandit1.HasEffect(Effect.SPELL_ANIMATE_DEAD));
            Assert.False(bandit2.HasEffect(Effect.SPELL_ANIMATE_DEAD));
            Assert.False(rat.HasEffect(Effect.SPELL_ANIMATE_DEAD));
            Assert.False(hillGiant.HasEffect(Effect.SPELL_ANIMATE_DEAD));
            Assert.True(wizard.HasEffect(Effect.SPELL_ANIMATE_DEAD));
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
    }
}

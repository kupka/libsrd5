using Xunit;

namespace srd5 {
    public partial class SpellTest {
        [Fact]
        public void SpareTheDyingTest() {
            CharacterSheet hero = new CharacterSheet(Race.HUMAN);
            hero.AddLevel(CharacterClasses.Barbarian);
            hero.TakeDamage(this, DamageType.TRUE_DAMAGE, hero.HitPointsMax);
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
            DefaultSpellTest(Spells.Bane, 12, SpellLevel.FIFTH, null, Effect.SPELL_BANE, 10);
        }

        [Fact]
        public void BlessTest() {
            DefaultSpellTest(Spells.Bless, 12, SpellLevel.FIFTH, null, Effect.SPELL_BLESS, 10);
        }

        [Fact]
        public void CommandTest() {
            DefaultSpellTest(Spells.Command, 12, SpellLevel.THIRD, ConditionType.PRONE, Effect.SPELL_COMMAND_GROVEL, null);
            DefaultSpellTest(Spells.Command, 12, SpellLevel.THIRD, null, Effect.SPELL_COMMAND_GROVEL, 1);
        }

        [Fact]
        public void DivineFavorTest() {
            DefaultSpellTest(Spells.DivineFavor, 12, SpellLevel.SECOND, null, Effect.SPELL_DIVINE_FAVOR, 10);
        }

        [Fact]
        public void GuidingBoltTest() {
            DamagingSpellTesting(Spells.GuidingBolt, 12, DamageType.RADIANT);
            DefaultSpellTest(Spells.GuidingBolt, 12, SpellLevel.NINETH, null, Effect.ADVANTAGE_ON_BEING_ATTACKED, 1);
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
            DefaultSpellTest(Spells.ShieldofFaith, 10, SpellLevel.SECOND, null, Effect.SPELL_SHIELD_OF_FAITH, 100);
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
            Spells.PrayerofHealing.Cast(ground, cleric, 12, SpellLevel.NINETH, 50, cleric, ogre, shadow, golem);
            Assert.Equal(cleric.HitPointsMax, cleric.HitPoints);
            Assert.Equal(ogre.HitPointsMax, ogre.HitPoints);
            Assert.Equal(1, shadow.HitPoints);
            Assert.Equal(1, golem.HitPoints);
        }
    }
}
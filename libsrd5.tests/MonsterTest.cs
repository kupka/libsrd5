using Xunit;
using System.Reflection;

namespace srd5 {
    [CollectionDefinition("SingleThreaded", DisableParallelization = true)]
    [Collection("SingleThreaded")]
    public class MonsterTest {
        [Fact]
        public void OgreTest() {
            Monster ogre = Monsters.Ogre;
            Assert.InRange(ogre.HitPoints, 28, 91);
            Assert.Equal(Experience.MonsterByCR(ogre.Challenge), ogre.Experience);
        }

        [Fact]
        public void ImmunityTest() {
            Monster shadow = Monsters.Shadow;
            Assert.False(shadow.AddCondition(ConditionType.PARALYZED));
        }

        [Fact]
        public void AllMonsterTest() {
            foreach (PropertyInfo property in typeof(Monsters).GetProperties()) {
                object o = property.GetMethod.Invoke(null, null);
                Assert.True(o is Monster);
            }
        }

        [Fact]
        public void AutoFailDCTest() {
            Monster orc = Monsters.Orc;
            orc.AddEffect(Effect.FAIL_DEXERITY_CHECK, Effect.FAIL_STRENGTH_CHECK);
            Assert.False(orc.DC(Spells.ID.HOLD_PERSON, 2, AbilityType.STRENGTH, true));
            Assert.False(orc.DC(Weapons.Blowgun, 2, AbilityType.DEXTERITY));
        }

        [Fact]
        public void ProficiencyBonusTest() {
            Monster orc = Monsters.Orc;
            Assert.Equal(2, orc.ProficiencyBonus);
            Monster hag = Monsters.NightHag;
            Assert.Equal(3, hag.ProficiencyBonus);
            Monster golem = Monsters.ClayGolem;
            Assert.Equal(4, golem.ProficiencyBonus);
        }

        [Fact]
        public void TarrasqueTest() {
            Battleground2D ground = new Battleground2D(10, 10);
            Monster tarrasque = Monsters.Tarrasque;
            Monster hag = Monsters.NightHag;
            ground.AddCombattant(tarrasque, 5, 5);
            ground.AddCombattant(hag, 8, 8);
            Assert.True(tarrasque.DC(null, 100, AbilityType.DEXTERITY) && tarrasque.DC(null, 100, AbilityType.DEXTERITY) && tarrasque.DC(null, 100, AbilityType.DEXTERITY));
            Assert.False(tarrasque.DC(Spells.ID.HOLD_PERSON, 100, AbilityType.DEXTERITY) && tarrasque.DC(Spells.ID.CURE_WOUNDS, 100, AbilityType.DEXTERITY) && tarrasque.DC(Attacks.TarrasqueBite, 100, AbilityType.DEXTERITY));
            for (int i = 0; i < 100; i++) {
                Spells.MagicMissile.Cast(ground, hag, 16, SpellLevel.SECOND, 0, tarrasque);
            }
            Assert.True(hag.HitPoints == 0);
            hag.HealDamage(100);
            for (int i = 0; i < 100; i++) {
                Spells.ChillTouch.Cast(ground, hag, 16, SpellLevel.SECOND, 0, tarrasque);
            }
            Assert.True(hag.HitPoints == 0);
        }

        [Fact]
        public void GiantScorpionTest() {
            Random.State = 1;
            Monster scorpion = Monsters.GiantScorpion;
            Monster goblin1 = Monsters.Goblin;
            goblin1.HitPoints = 13; // max normal damage of scorpion is 1d10+2=12
            Monster goblin2 = Monsters.Goblin;
            goblin2.HitPoints = 13; // max normal damage of scorpion is 1d10+2=12
            Monster goblin3 = Monsters.Goblin;
            goblin3.HitPoints = 13; // max normal damage of scorpion is 1d10+2=12
            scorpion.Attack(Attacks.GiantScorpionSting, goblin1, 5);
            scorpion.Attack(Attacks.GiantScorpionSting, goblin2, 5);
            scorpion.Attack(Attacks.GiantScorpionSting, goblin3, 5);
            Assert.True(goblin1.HitPoints <= 0 || goblin2.HitPoints <= 0 || goblin3.HitPoints <= 0);
        }

        [Fact]
        public void NightHagTest() {
            Monster hag = Monsters.NightHag;
            Assert.True(Spells.MagicMissile.Equals(hag.InnateSpellcastingBySpell(Spells.MagicMissile).Spell));
            Assert.Null(hag.InnateSpellcastingBySpell(Spells.Wish));
        }
    }
}
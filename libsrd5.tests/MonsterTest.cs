using Xunit;
using System.Reflection;

namespace srd5 {
    public class MonsterTest {
        [Fact]
        public void OgreTest() {
            Monster ogre = Monsters.Ogre;
            Assert.InRange(ogre.HitPoints, 28, 91);
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
            }
        }

        [Fact]
        public void AutoFailDCTest() {
            Monster orc = Monsters.Orc;
            orc.AddEffects(Effect.FAIL_DEXERITY_CHECK, Effect.FAIL_STRENGTH_CHECK);
            Assert.False(orc.DC(2, AbilityType.STRENGTH, true));
            Assert.False(orc.DC(2, AbilityType.DEXTERITY));
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
    }
}
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
    }
}
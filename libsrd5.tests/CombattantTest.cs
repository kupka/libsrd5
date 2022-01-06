using System;
using Xunit;

namespace srd5 {
    public class CombattantTest {
        [Fact]
        public void TakeDamageTest() {

            Combattant ogre = Monsters.Ogre;
            ogre.AddEffect(Effect.VULNERABILITY_COLD);
            ogre.AddEffect(Effect.IMMUNITY_ACID);
            ogre.AddEffect(Effect.RESISTANCE_LIGHTNING);
            int hp = ogre.HitPoints;
            Damage cold = new Damage(DamageType.COLD, "1d6+5");
            ogre.TakeDamage(cold.Type, cold.Dices.RollCritical());
            Assert.InRange<int>(ogre.HitPoints, hp - 34, hp - 14);
            hp = ogre.HitPoints;
            Damage acid = new Damage(DamageType.ACID, "1d4+3");
            ogre.TakeDamage(acid.Type, acid.Dices.Roll());
            Assert.Equal(hp, ogre.HitPoints);
            Damage lightning = new Damage(DamageType.LIGHTNING, "1d12");
            ogre.TakeDamage(lightning.Type, lightning.Dices.Roll());
            Assert.InRange<int>(ogre.HitPoints, hp - 12, hp - 1);
        }

        [Fact]
        public void GetAbilityTest() {
            Combattant ogre = Monsters.Ogre;
            Assert.Equal(ogre.Strength.Value, ogre.GetAbility(AbilityType.STRENGTH).Value);
            Assert.Equal(ogre.Constitution.Value, ogre.GetAbility(AbilityType.CONSTITUTION).Value);
            Assert.Equal(ogre.Dexterity.Value, ogre.GetAbility(AbilityType.DEXTERITY).Value);
            Assert.Equal(ogre.Intelligence.Value, ogre.GetAbility(AbilityType.INTELLIGENCE).Value);
            Assert.Equal(ogre.Wisdom.Value, ogre.GetAbility(AbilityType.WISDOM).Value);
            Assert.Equal(ogre.Charisma.Value, ogre.GetAbility(AbilityType.CHARISMA).Value);
            Assert.Throws<ArgumentException>(delegate {
                ogre.GetAbility(AbilityType.NONE);
            });
        }

        [Fact]
        public void ConditionTest() {
            CharacterSheet hero = new CharacterSheet(Race.HUMAN);
            Assert.Empty(hero.Conditions);
            Assert.Empty(hero.Effects);
            foreach (ConditionType condition in Enum.GetValues(typeof(ConditionType))) {
                hero.AddCondition(condition);
                hero.RemoveCondition(condition);
                Assert.Empty(hero.Conditions);
                Assert.Empty(hero.Effects);
            }
        }
    }
}
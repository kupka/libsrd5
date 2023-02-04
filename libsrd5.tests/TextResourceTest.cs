using Xunit;
using System;

namespace srd5 {
    public class TextResourceTest {
        [Fact]
        public void RacialTextTest() {
            foreach (Race race in Enum.GetValues(typeof(Race))) {
                Assert.NotNull(race.Name());
                Assert.NotNull(race.Description());
            }
        }

        [Fact]
        public void EffectTextTest() {
            foreach (Effect effect in Enum.GetValues(typeof(Effect))) {
                Assert.NotNull(effect.Name());
            }
        }

        [Fact]
        public void FeatTextTest() {
            foreach (Feat feat in Enum.GetValues(typeof(Feat))) {
                Assert.NotNull(feat.Name());
                Assert.NotNull(feat.Description());
            }
        }

        [Fact]
        public void SkillTextTest() {
            foreach (Skill skill in Enum.GetValues(typeof(Skill))) {
                Assert.NotNull(skill.Name());
                Assert.NotNull(skill.Description());
            }
        }

        [Fact]
        public void NullTest() {
            Assert.NotNull(SkillTextResource.Description((Skill)(-1)));
            Assert.NotNull(SkillTextResource.Name((Skill)(-1)));
            Assert.NotNull(MonsterTextResource.Description((Monsters.ID)(-1)));
            Assert.NotNull(MonsterTextResource.Name((Monsters.ID)(-1)));
            Assert.NotNull(MonsterTextResource.Description((Monsters.Type)(-1)));
            Assert.NotNull(MonsterTextResource.Name((Monsters.Type)(-1)));
            Assert.NotNull(ProficiencyTextResource.Name((Proficiency)(-1)));
            Assert.NotNull(DamageTypeTextResource.Name((DamageType)(-1)));
            Assert.NotNull(ConditionTypeTextResource.Name((ConditionType)(-1)));
            Assert.NotNull(ConditionTypeTextResource.Description((ConditionType)(-1)));
        }

        [Fact]
        public void SpellTextTest() {
            foreach (Spells.ID id in Enum.GetValues(typeof(Spells.ID))) {
                Assert.NotNull(id.Name());
                Assert.NotNull(id.Description());
            }
        }
        [Fact]
        public void MonsterTest() {
            foreach (Monsters.ID monster in Enum.GetValues(typeof(Monsters.ID))) {
                Assert.NotNull(monster.Name());
                Assert.NotNull(monster.Description());
            }
        }

        [Fact]
        public void MonsterTypeTest() {
            foreach (Monsters.Type type in Enum.GetValues(typeof(Monsters.Type))) {
                Assert.NotNull(type.Name());
                Assert.NotNull(type.Description());
            }
        }

        [Fact]
        public void ClassTest() {
            foreach (Class clazz in Enum.GetValues(typeof(Class))) {
                Assert.NotNull(clazz.Name());
            }
        }

        [Fact]
        public void ProficiencyTest() {
            foreach (Proficiency proficiency in Enum.GetValues(typeof(Proficiency))) {
                Assert.NotNull(proficiency.Name());
            }
        }

        [Fact]
        public void DamageTypeTest() {
            foreach (DamageType type in Enum.GetValues(typeof(DamageType))) {
                Assert.NotNull(type.Name());
            }
        }


        [Fact]
        public void AbilityTypeTest() {
            foreach (AbilityType type in Enum.GetValues(typeof(AbilityType))) {
                Assert.NotNull(type.Name());
                Assert.NotNull(type.Description());
            }
        }

        [Fact]
        public void ConditionTypeTest() {
            foreach (ConditionType type in Enum.GetValues(typeof(ConditionType))) {
                Assert.NotNull(type.Name());
                Assert.NotNull(type.Description());
            }
        }
    }
}
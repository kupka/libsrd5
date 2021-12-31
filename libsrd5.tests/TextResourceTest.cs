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
            Assert.NotNull(MonsterTextResource.Description((MonsterType)(-1)));
            Assert.NotNull(MonsterTextResource.Name((MonsterType)(-1)));
        }

        [Fact]
        public void SpellTextTest() {
            foreach (Spells.ID id in Enum.GetValues(typeof(Spells.ID))) {
                Assert.NotNull(id.Name());
                Assert.NotNull(id.Description());
            }
        }

        [Fact]
        public void MonsterTypeTest() {
            foreach (MonsterType type in Enum.GetValues(typeof(MonsterType))) {
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
    }
}
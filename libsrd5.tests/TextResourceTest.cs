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
    }
}
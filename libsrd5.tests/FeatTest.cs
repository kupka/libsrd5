using Xunit;
using System;

namespace srd5 {
    public class FeatTest {
        [Fact]
        public void IterationTest() {
            CharacterSheet sheet = new CharacterSheet(Race.HUMAN);
            foreach (Feat feat in Enum.GetValues(typeof(Feat))) {
                sheet.AddFeat(feat);
                Assert.True(sheet.HasFeat(feat));
            }
        }

        [Fact]
        public void MultipleTest() {
            CharacterSheet sheet = new CharacterSheet(Race.HUMAN);
            Array feats = Enum.GetValues(typeof(Feat));
            sheet.AddFeats(new Feat[] { (Feat)feats.GetValue(0), (Feat)feats.GetValue(1) });
            Assert.Equal(3, sheet.Feats.Length);
        }
    }
}
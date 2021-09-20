using Xunit;
using System;

namespace srd5 {
    public class FeatTest {
        [Fact]
        public void IterationTest() {
            CharacterSheet sheet = new CharacterSheet(Race.HUMAN);
            foreach (Feat feat in Enum.GetValues(typeof(Feat))) {
                sheet.AddFeat(feat);
            }
        }
    }
}
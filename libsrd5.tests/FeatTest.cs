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

        [Fact]
        public void RepeatedFeatTest() {
            CharacterSheet sheet = new CharacterSheet(Race.HUMAN);
            int constitution = sheet.Constitution.BaseValue;
            sheet.AddFeat(Feat.DWARVEN_ABILITY_INCREASE);
            sheet.AddFeat(Feat.DWARVEN_ABILITY_INCREASE);
            Assert.Equal(2, Array.FindAll(sheet.Feats, f => f == Feat.DWARVEN_ABILITY_INCREASE).Length);
            Assert.Equal(constitution + 4, sheet.Constitution.BaseValue);
        }

        [Fact]
        public void ClassLevelFeatsTest() {
            CharacterSheet sheet = new CharacterSheet(Race.HUMAN);
            for (int i = 0; i < 8; i++) sheet.AddLevel(CharacterClasses.Barbarian);
            Assert.Equal(2, Array.FindAll(sheet.Feats, f => f == Feat.ABILITY_SCORE_IMPROVEMENT).Length);
            Assert.True(sheet.HasFeat(Feat.EXTRA_ATTACK));
            Assert.True(sheet.HasFeat(Feat.MINDLESS_RAGE));
            Assert.False(sheet.HasFeat(Feat.BRUTAL_CRITICAL));
        }
    }
}
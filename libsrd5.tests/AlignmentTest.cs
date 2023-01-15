using System;
using Xunit;

namespace srd5 {
    public class AlignmentTest {
        [Fact]
        public void checkGood() {
            Assert.False(Alignment.UNALIGNED.IsGood());
            Assert.True(Alignment.LAWFUL_GOOD.IsGood());
            Assert.True(Alignment.NEUTRAL_GOOD.IsGood());
            Assert.True(Alignment.CHAOTIC_GOOD.IsGood());
            Assert.False(Alignment.LAWFUL_NEUTRAL.IsGood());
            Assert.False(Alignment.NEUTRAL.IsGood());
            Assert.False(Alignment.CHAOTIC_NEUTRAL.IsGood());
            Assert.False(Alignment.LAWFUL_EVIL.IsGood());
            Assert.False(Alignment.NEUTRAL_EVIL.IsGood());
            Assert.False(Alignment.CHAOTIC_EVIL.IsGood());
        }

        [Fact]
        public void checkNeutral() {
            Assert.False(Alignment.UNALIGNED.IsNeutral());
            Assert.False(Alignment.LAWFUL_GOOD.IsNeutral());
            Assert.False(Alignment.NEUTRAL_GOOD.IsNeutral());
            Assert.False(Alignment.CHAOTIC_GOOD.IsNeutral());
            Assert.True(Alignment.LAWFUL_NEUTRAL.IsNeutral());
            Assert.True(Alignment.NEUTRAL.IsNeutral());
            Assert.True(Alignment.CHAOTIC_NEUTRAL.IsNeutral());
            Assert.False(Alignment.LAWFUL_EVIL.IsNeutral());
            Assert.False(Alignment.NEUTRAL_EVIL.IsNeutral());
            Assert.False(Alignment.CHAOTIC_EVIL.IsNeutral());
        }

        [Fact]
        public void checkEvil() {
            Assert.False(Alignment.UNALIGNED.IsEvil());
            Assert.False(Alignment.LAWFUL_GOOD.IsEvil());
            Assert.False(Alignment.NEUTRAL_GOOD.IsEvil());
            Assert.False(Alignment.CHAOTIC_GOOD.IsEvil());
            Assert.False(Alignment.LAWFUL_NEUTRAL.IsEvil());
            Assert.False(Alignment.NEUTRAL.IsEvil());
            Assert.False(Alignment.CHAOTIC_NEUTRAL.IsEvil());
            Assert.True(Alignment.LAWFUL_EVIL.IsEvil());
            Assert.True(Alignment.NEUTRAL_EVIL.IsEvil());
            Assert.True(Alignment.CHAOTIC_EVIL.IsEvil());
        }
    }
}
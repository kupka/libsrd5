using Xunit;

namespace d20 {
    public class FeatTest {
        [Fact]
        public void EqualsTest() {
            DwarvenConstitution const1 = new DwarvenConstitution();
            DwarvenConstitution const2 = new DwarvenConstitution();
            DarkVision darkVision = new DarkVision();
            Assert.True(const1.Equals(const2));
            Assert.False(const1.Equals(darkVision));
        }
    }
}
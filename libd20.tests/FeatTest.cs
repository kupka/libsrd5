using Xunit;

namespace d20 {
    public class FeatTest {
        [Fact]
        public void EqualsTest() {
            DwarvenAbilityIncrease const1 = new DwarvenAbilityIncrease();
            DwarvenAbilityIncrease const2 = new DwarvenAbilityIncrease();
            Darkvision darkVision = new Darkvision();
            Assert.True(const1.Equals(const2));
            Assert.False(const1.Equals(darkVision));
        }
    }
}
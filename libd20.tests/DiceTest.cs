using System;
using Xunit;

namespace d20 {
    public class DiceTest {
        [Fact]
        public void D20Test() {
            Dice d20 = Dice.D20;
            Assert.InRange<uint>(d20.Value, 1, 20);
        }

        [Theory]
        [InlineData("3d6+3", 6, 21)]
        [InlineData("d20", 1, 20)]
        [InlineData("d4-5", -4, -1)]
        [InlineData("d2-1", 0, 1)]
        [InlineData("5d3+10", 15, 25)]
        public void ParseTest1(string toParse, int min, int max) {
            int result = Dice.Roll(toParse);
            Assert.InRange<int>(result, min, max);
        }
    }
}
using System;
using Xunit;

namespace d20 {
    public class DiceTest {
        [Fact]
        public void D20Test() {
            Dice d20 = Dice.D20;
            Assert.InRange<int>(d20.Value, 1, 20);
        }

        [Theory]
        [InlineData("3d6+3", 6, 21)]
        [InlineData("d20", 1, 20)]
        [InlineData("d4-5", -4, -1)]
        [InlineData("d2-1", 0, 1)]
        [InlineData("5d3+10", 15, 25)]
        [InlineData("1111d12+889", 2000, 14221)]
        public void ParseTest(string diceString, int min, int max) {
            Dices parsed = new Dices(diceString);
            Assert.Equal(min, parsed.Min);
            Assert.Equal(max, parsed.Max);
            long result = Dice.Roll(diceString);
            Assert.InRange<long>(result, min, max);
        }
    }
}
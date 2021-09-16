using System;
using Xunit;

namespace srd5 {
    public class DiceTest {
        [Fact]
        public void D2Test() {
            Dice dice = Dice.D2;
            Assert.InRange<int>(dice.Value, 1, 2);
        }

        [Fact]
        public void D3Test() {
            Dice dice = Dice.D3;
            Assert.InRange<int>(dice.Value, 1, 3);
        }

        [Fact]
        public void D4Test() {
            Dice dice = Dice.D4;
            Assert.InRange<int>(dice.Value, 1, 4);
        }

        [Fact]
        public void D6Test() {
            Dice dice = Dice.D6;
            Assert.InRange<int>(dice.Value, 1, 6);
        }

        [Fact]
        public void D8Test() {
            Dice dice = Dice.D8;
            Assert.InRange<int>(dice.Value, 1, 8);
        }

        [Fact]
        public void D10Test() {
            Dice dice = Dice.D10;
            Assert.InRange<int>(dice.Value, 1, 10);
        }

        [Fact]
        public void D12Test() {
            Dice dice = Dice.D12;
            Assert.InRange<int>(dice.Value, 1, 12);
        }

        [Fact]
        public void D20Test() {
            Dice d20 = Dice.D20;
            Assert.InRange<int>(d20.Value, 1, 20);
        }

        [Fact]
        public void D100Test() {
            Dice dice = Dice.D100;
            Assert.InRange<int>(dice.Value, 1, 100);
        }

        [Fact]
        public void NotADiceTest() {
            Assert.Throws<ArgumentOutOfRangeException>(delegate {
                Dice.Get(21);
            });
        }

        [Fact]
        public void AnotherNotADiceTest() {
            Assert.Throws<FormatException>(delegate {
                new Dices("3d7+3");
            });
        }

        [Fact]
        public void DisAdvantageTest() {
            int advantageRolls = 0, disadvantageRolls = 0;
            for (int i = 0; i < 10; i++) {
                advantageRolls += Dice.D20Advantage.Value;
                disadvantageRolls += Dice.D20Disadvantage.Value;
            }
            Assert.True(advantageRolls > disadvantageRolls);
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
            Assert.Equal(diceString, parsed.ToString());
            Assert.Equal(min, parsed.Min);
            Assert.Equal(max, parsed.Max);
            long result = Dice.Roll(diceString);
            Assert.InRange<long>(result, min, max);
        }

        [Theory]
        [InlineData("x6+3")]
        [InlineData("3f6+3")]
        [InlineData("3d6*3")]
        [InlineData("3d6+x")]
        [InlineData("3d6-41n")]
        public void InvalidDiceTest(string diceString) {
            Assert.Throws<FormatException>(delegate { new Dices(diceString); });
        }
    }
}
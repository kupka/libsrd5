using System;
using Xunit;

namespace d20 {
    public class AbilityTest {
        [Theory]
        [InlineData(3, -4)]
        [InlineData(8, -1)]
        [InlineData(15, 2)]
        [InlineData(26, 8)]
        public void TestModifier(int value, int expected) {
            Ability ability = new Ability(AbilityType.STRENGTH, value);
            ability.Value = value;
            Assert.Equal(expected, ability.Modifier);
        }
    }
}
using System;
using Xunit;

namespace d20 {
    public class BarbarianTest {
        [Fact]
        public void TestProficiency() {
            Assert.True(CharacterClass.Barbarian.IsProficientIn(Weapons.Club));
        }
    }
}
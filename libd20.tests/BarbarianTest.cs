using System;
using Xunit;

namespace d20 {
    public class BarbarianTest {
        [Fact]
        public void TestProficiency() {
            Assert.True(CharacterClasses.Barbarian.IsProficientIn(Weapons.Club));
        }
    }
}
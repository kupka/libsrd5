using System;
using Xunit;

namespace d20 {
    public class BarbarianTest {
        [Fact]
        public void TestProficiency() {
            Assert.True(new Barbarian().IsProficientIn(Weapons.Club));
        }
    }
}
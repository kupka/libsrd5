using System;
using Xunit;

namespace d20 {
    public class BarbarianTest {
        [Fact]
        public void TestProficiency() {
            Assert.True(Array.IndexOf<Proficiency>(CharacterClasses.Barbarian.Proficiencies, Proficiency.MARTIAL_RANGED_WEAPONS) >= 0);
        }
    }
}
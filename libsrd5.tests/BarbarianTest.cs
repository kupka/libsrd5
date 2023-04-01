using System;
using Xunit;

namespace srd5 {
    public class BarbarianTest {
        [Fact]
        public void TestProficiency() {
            Assert.True(Array.IndexOf<Proficiency>(CharacterClasses.Barbarian.Proficiencies, Proficiency.MARTIAL_RANGED_WEAPONS) > -1);
        }
    }
}
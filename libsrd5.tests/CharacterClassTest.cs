using Xunit;

namespace srd5 {
    public class CharacterClassTest {
        [Fact]
        public void EqualTest() {
            Assert.True(CharacterClasses.Barbarian.Equals(CharacterClasses.Barbarian));
            Assert.False(CharacterClasses.Barbarian.Equals(CharacterClasses.Druid));
            Assert.False(CharacterClasses.Barbarian.Equals("Barbarian"));
        }
    }
}

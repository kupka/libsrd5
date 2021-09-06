using Xunit;

namespace d20 {
    public class MonsterTest {
        [Fact]
        public void OgreTest() {
            Monster ogre = Monsters.Ogre;
            Assert.InRange(ogre.HitPoints, 28, 91);
        }
    }
}
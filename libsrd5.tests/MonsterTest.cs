using Xunit;
using System;

namespace srd5 {
    public class MonsterTest {
        [Fact]
        public void OgreTest() {
            Monster ogre = Monsters.Ogre;
            Assert.InRange(ogre.HitPoints, 28, 91);
        }
    }
}
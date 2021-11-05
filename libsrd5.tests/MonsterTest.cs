using Xunit;
using System;

namespace srd5 {
    public class MonsterTest {
        [Fact]
        public void OgreTest() {
            Monster ogre = Monsters.Ogre;
            Assert.InRange(ogre.HitPoints, 28, 91);
        }

        [Fact]
        public void EffectTest() {
            Monster ogre = Monsters.Ogre;
            Assert.Throws<NotImplementedException>(delegate {
                ogre.AddEffect(Effect.PROTECTION);
            });
            Assert.Throws<NotImplementedException>(delegate {
                ogre.RemoveEffect(Effect.PROTECTION);
            });
        }
    }
}
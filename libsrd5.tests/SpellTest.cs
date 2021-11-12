using System;
using Xunit;

namespace srd5 {
    public class SpellTest {
        [Fact]
        public void AcidSplashTest() {
            CharacterSheet hero = new CharacterSheet(Race.HUMAN, true);
            Monster ogre = Monsters.Ogre;
            int hpBefore = ogre.HitPoints;
            Spells.AcidSplash.Cast(hero, SpellLevel.CANTRIP, ogre);
            Assert.True(ogre.HitPoints < hpBefore);
        }
    }
}
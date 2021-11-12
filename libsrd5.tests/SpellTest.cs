using System;
using Xunit;

namespace srd5 {
    public class SpellTest {
        [Fact]
        public void AcidSplashTest() {
            CharacterSheet hero = new CharacterSheet(Race.HUMAN, true);
            Monster ogre = Monsters.Ogre;
            int hpBefore = ogre.HitPoints;
            for (int i = 0; i < 17; i++) {
                hero.AddLevel(CharacterClasses.Druid);
                if (i == 1 || i == 4 || i == 10 || i == 16) {
                    hpBefore = ogre.HitPoints;
                    Spells.AcidSplash.Cast(hero, SpellLevel.CANTRIP, ogre);
                    Assert.True(ogre.HitPoints < hpBefore);
                }
            }
        }
    }
}
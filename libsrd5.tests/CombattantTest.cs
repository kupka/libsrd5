using System;
using Xunit;

namespace srd5 {
    public class CombattantTest {
        [Fact]
        public void TakeDamageTest() {

            Combattant ogre = Monsters.Ogre;
            ogre.AddEffect(Effect.VULNERABILITY_COLD);
            ogre.AddEffect(Effect.IMMUNITY_ACID);
            ogre.AddEffect(Effect.RESISTANCE_LIGHTNING);
            int hp = ogre.HitPoints;
            Damage cold = new Damage(DamageType.COLD, "1d6+5");
            ogre.TakeDamage(cold, true);
            Assert.InRange<int>(ogre.HitPoints, hp - 34, hp - 14);
            hp = ogre.HitPoints;
            Damage acid = new Damage(DamageType.ACID, "1d4+3");
            ogre.TakeDamage(acid, false);
            Assert.Equal(hp, ogre.HitPoints);
            Damage lightning = new Damage(DamageType.LIGHTNING, "1d12");
            ogre.TakeDamage(lightning, true);
            Assert.InRange<int>(ogre.HitPoints, hp - 12, hp - 1);

        }
    }
}
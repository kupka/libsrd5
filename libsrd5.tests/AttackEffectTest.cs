using Xunit;

namespace srd5 {
    public class AttackEffectTest {
        private Monster uberMonster = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.ORC, Alignment.LAWFUL_EVIL, 30, 30, 30, 30, 30, 30, 30, "1d6+10000", 40, 16,
                    new Attack[] { }, new Attack[] { }, Size.HUGE
                );

        private Monster pansyMonster = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.GOAT, Alignment.LAWFUL_EVIL, 2, 1, 1, 1, 1, 1, 1, "1d6+10000", 40, 16,
                    new Attack[] { }, new Attack[] { }, Size.HUGE
                );


        private void attackEffectTest(AttackEffect effect) {
            for (int i = 0; i < 10; i++) {
                effect.Invoke(Monsters.Aboleth, uberMonster);
                effect.Invoke(Monsters.Aboleth, pansyMonster);
            }
        }

        [Fact]
        public void TestAttackEffects_A() {
            attackEffectTest(Attacks.AbolethTentacleEffect);
            attackEffectTest(Attacks.AnkhegBiteEffect);
            attackEffectTest(Attacks.AssassinShortswordEffect);
            attackEffectTest(Attacks.GiantScorpionStingEffect);
        }
    }
}
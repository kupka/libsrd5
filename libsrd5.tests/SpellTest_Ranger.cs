using Xunit;

namespace srd5 {
    public partial class SpellTest {
        [Fact]
        public void HuntersMarkTest() {
            CharacterSheet ranger = new CharacterSheet(Race.HALFLING);
            Monster goblin = Monsters.Goblin;
            Battleground ground = createBattleground(ranger, goblin);
            Spells.HuntersMark.Cast(ground, ranger, 20, SpellLevel.THIRD, 2, goblin);
            goblin.TakeDamage(this, DamageType.TRUE_DAMAGE, 1);
            Assert.Equal(goblin.HitPointsMax - 1, goblin.HitPoints);
            goblin.TakeDamage(ranger, DamageType.TRUE_DAMAGE, 1);
            Assert.True(goblin.HitPointsMax - 2 > goblin.HitPoints);
        }
    }
}
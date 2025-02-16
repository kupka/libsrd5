using System.Data;
using Xunit;

namespace srd5 {
    public partial class SpellTest {
        [Fact]
        public void ViciousMockeryTest() {
            CharacterSheet bard = new CharacterSheet(Race.GNOME, true);
            bard.AddLevels(CharacterClasses.Bard, CharacterClasses.Bard);
            Monster goblin = Monsters.Goblin;
            Monster goblin2 = Monsters.Goblin;
            BattleGroundClassic ground = new BattleGroundClassic();
            ground.AddCombattant(bard, ClassicLocation.Row.FRONT_LEFT);
            ground.AddCombattant(goblin, ClassicLocation.Row.FRONT_RIGHT);
            ground.AddCombattant(goblin2, ClassicLocation.Row.FRONT_RIGHT);
            Spells.ViciousMockery.Cast(ground, bard, 30, SpellLevel.CANTRIP, 2, goblin);
            Assert.True(goblin.HitPointsMax > goblin.HitPoints);
            Assert.True(goblin.HasEffect(Effect.DISADVANTAGE_ON_ATTACK));
            goblin.OnEndOfTurn();
            Assert.False(goblin.HasEffect(Effect.DISADVANTAGE_ON_ATTACK));
            Random.State = 1;
            Spells.ViciousMockery.Cast(ground, bard, 1, SpellLevel.CANTRIP, 2, goblin2);
            Assert.True(goblin2.HitPointsMax == goblin2.HitPoints);
            Assert.False(goblin2.HasEffect(Effect.DISADVANTAGE_ON_ATTACK));
        }

        [Fact]
        public void HeroismTest() {
            Monster goblin = Monsters.Goblin;
            Spells.Heroism.Cast(goblin, 12, SpellLevel.FIRST, 5);
            goblin.OnStartOfTurn();
            goblin.TakeDamage(this, DamageType.ACID, 1);
            Assert.Equal(goblin.HitPointsMax, goblin.HitPoints);
            goblin.OnEndOfTurn();
            DefaultSpellTest(Spells.Heroism, 12, SpellLevel.THIRD, null, Effect.IMMUNITY_FRIGHTENED, 10);
        }

        [Fact]
        public void CalmEmotionsTest() {
            Monster badger = Monsters.Badger;
            badger.AddCondition(ConditionType.CHARMED);
            Monster bandit = Monsters.Bandit;
            bandit.AddCondition(ConditionType.CHARMED);
            CharacterSheet coward = new CharacterSheet(Race.GNOME);
            coward.AddCondition(ConditionType.FRIGHTENED);
            Monster solar = Monsters.Solar;
            Battleground ground = createBattleground(solar, badger, bandit, coward);
            Spells.CalmEmotions.Cast(ground, solar, 20, SpellLevel.SEVENTH, 10, badger, bandit, coward);
            Assert.True(badger.HasCondition(ConditionType.CHARMED));
            Assert.False(bandit.HasCondition(ConditionType.CHARMED));
            Assert.False(coward.HasCondition(ConditionType.FRIGHTENED));

            // TODO: Add effects here that will be restored after Calm Emotions expires
            Assert.True(bandit.HasEffect(Effect.SPELL_CALM_EMOTIONS_CHARMED_SUPRESSED));
            bandit.RemoveEffect(Effect.SPELL_CALM_EMOTIONS);
            Assert.False(bandit.HasEffect(Effect.SPELL_CALM_EMOTIONS_CHARMED_SUPRESSED));
            Assert.True(coward.HasEffect(Effect.SPELL_CALM_EMOTIONS_FRIGHTENED_SUPRESSED));
            coward.RemoveEffect(Effect.SPELL_CALM_EMOTIONS);
            Assert.False(coward.HasEffect(Effect.SPELL_CALM_EMOTIONS_FRIGHTENED_SUPRESSED));
        }
    }
}
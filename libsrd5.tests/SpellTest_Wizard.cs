using System;
using Xunit;

namespace srd5 {
    public partial class SpellTest {
        [Fact]
        public void ChillTouchTest() {
            CharacterSheet wizard = new CharacterSheet(Race.GNOME, true);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard);
            CharacterSheet barbarian = new CharacterSheet(Race.HALF_ORC, true);
            wizard.AddLevel(CharacterClasses.Barbarian);
            Monster orc = Monsters.Orc;
            Monster shadow = Monsters.Shadow;
            Battleground2D ground = new Battleground2D(10, 10);
            Random.State = 1;
            ground.AddCombattant(wizard, 5, 5);
            ground.AddCombattant(orc, 7, 7);
            ground.AddCombattant(shadow, 8, 8);
            ground.AddCombattant(barbarian, 9, 9);
            Spells.ChillTouch.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, barbarian);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard);
            Spells.ChillTouch.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, orc);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard);
            Spells.ChillTouch.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, shadow);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard);
            Spells.ChillTouch.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, shadow);
            Assert.True(shadow.HasEffect(Effect.CANNOT_REGENERATE_HITPOINTS));
            Assert.True(shadow.HasEffect(Effect.DISADVANTAGE_ON_ATTACK));
            shadow.OnEndOfTurn();
            Assert.False(shadow.HasEffect(Effect.CANNOT_REGENERATE_HITPOINTS));
            Assert.False(shadow.HasEffect(Effect.DISADVANTAGE_ON_ATTACK));
        }

        [Fact]
        public void FireBoltTest() {
            CharacterSheet wizard = new CharacterSheet(Race.GNOME, true);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard);
            Monster orc = Monsters.Orc;
            Battleground2D ground = new Battleground2D(10, 10);
            Random.State = 1;
            ground.AddCombattant(wizard, 5, 5);
            ground.AddCombattant(orc, 7, 7);
            Spells.FireBolt.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, orc);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard);
            Spells.FireBolt.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, orc);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard);
            Spells.FireBolt.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, orc);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard);
            Spells.FireBolt.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, orc);
            Assert.Equal(0, orc.HitPoints);
        }

        [Fact]
        public void LightTest() {
            DefaultSpellTest(Spells.Light, SpellLevel.CANTRIP, null, Effect.LIGHT, null);
        }
    }
}
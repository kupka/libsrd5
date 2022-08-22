using System;
using Xunit;

namespace srd5 {
    public partial class SpellTest {
        [Fact]
        public void ChillTouchTest() {
            CharacterSheet wizard = new CharacterSheet(Race.GNOME, true);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard);
            CharacterSheet barbarian = new CharacterSheet(Race.HALF_ORC, true);
            barbarian.AddLevel(CharacterClasses.Barbarian);
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
            wizard.OnStartOfTurn();
            wizard.OnEndOfTurn();
            Assert.False(shadow.HasEffect(Effect.CANNOT_REGENERATE_HITPOINTS));
            Assert.True(shadow.HasEffect(Effect.DISADVANTAGE_ON_ATTACK));
            wizard.OnEndOfTurn();
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
            DefaultSpellTest(Spells.Light, 12, SpellLevel.CANTRIP, null, Effect.LIGHT, null);
        }

        [Fact]
        public void RayOfFrostTest() {
            CharacterSheet wizard = new CharacterSheet(Race.GNOME, true);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard);
            CharacterSheet barbarian = new CharacterSheet(Race.HALF_ORC, true);
            barbarian.AddLevel(CharacterClasses.Barbarian);
            Monster orc = Monsters.Orc;
            Monster shadow = Monsters.Shadow;
            Battleground2D ground = new Battleground2D(10, 50);
            Random.State = 1;
            ground.AddCombattant(wizard, 5, 5);
            ground.AddCombattant(orc, 7, 7);
            ground.AddCombattant(shadow, 8, 8);
            ground.AddCombattant(barbarian, 9, 49);
            Spells.RayOfFrost.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, barbarian);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard);
            Spells.RayOfFrost.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, orc);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard);
            Spells.RayOfFrost.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, shadow);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard);
            Spells.RayOfFrost.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, shadow);
            Assert.True(shadow.HasEffect(Effect.RAY_OF_FROST));
            wizard.OnStartOfTurn();
            Assert.False(shadow.HasEffect(Effect.RAY_OF_FROST));
        }

        [Fact]
        public void ShockingGraspTest() {
            CharacterSheet wizard = new CharacterSheet(Race.GNOME, true);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard);
            CharacterSheet barbarian = new CharacterSheet(Race.HALF_ORC, true);
            barbarian.AddLevel(CharacterClasses.Barbarian);
            Monster orc = Monsters.Orc;
            Monster shadow = Monsters.Shadow;
            Battleground2D ground = new Battleground2D(10, 10);
            Random.State = 1;
            ground.AddCombattant(wizard, 5, 5);
            ground.AddCombattant(orc, 7, 7);
            ground.AddCombattant(shadow, 5, 6);
            ground.AddCombattant(barbarian, 9, 9);
            Spells.ShockingGrasp.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, barbarian);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard);
            Spells.ShockingGrasp.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, orc);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard);
            Spells.ShockingGrasp.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, shadow);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard);
            Spells.ShockingGrasp.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, shadow);
            Assert.True(shadow.HasEffect(Effect.CANNOT_TAKE_REACTIONS));
            wizard.OnStartOfTurn();
            Assert.False(shadow.HasEffect(Effect.CANNOT_TAKE_REACTIONS));
        }

        [Fact]
        public void TrueStrikeTest() {
            CharacterSheet wizard = new CharacterSheet(Race.GNOME, true);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard);
            Monster orc1 = Monsters.Orc;
            Monster orc2 = Monsters.Orc;
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombattant(wizard, 5, 5);
            ground.AddCombattant(orc1, 5, 6);
            ground.AddCombattant(orc2, 6, 5);
            ground.Initialize();
            Spells.TrueStrike.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, orc1);
            wizard.Attack(Attacks.GiantBadgerBite, orc1, 5); // not yet active
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            wizard.Attack(Attacks.GiantBadgerBite, orc2, 5); // wrong target
            wizard.Attack(Attacks.GiantBadgerBite, orc1, 5); // correct target and turn
            Spells.TrueStrike.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, orc2);
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            wizard.Attack(Attacks.GiantBadgerBite, orc2, 5); // no longer active
        }
    }
}
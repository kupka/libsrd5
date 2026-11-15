using System;
using Xunit;

namespace srd5 {
    public partial class SpellTest {
        [Fact]
        public void EldritchBlastTest() {
            Monster hag = Monsters.NightHag;
            Monster badger = Monsters.Badger;
            Battleground ground = createBattleground(hag, badger);
            int hp = badger.HitPoints;
            for (int i = 0; i < 5; i++)
                Spells.EldritchBlast.Cast(ground, hag, 12, SpellLevel.CANTRIP, hag.ProficiencyBonus, badger, badger, badger);
            Assert.True(badger.HitPoints < hp);
        }

        [Fact]
        public void PoisonSprayTest() {
            Random.State = 1; // isolate from whatever random state preceding tests left behind
            Monster hag = Monsters.NightHag;
            Monster badger = Monsters.Badger;
            Battleground ground = createBattleground(hag, badger);
            int hp = badger.HitPoints;
            Random.FixedRandom = Random.DebugState.Max;
            Spells.PoisonSpray.Cast(ground, hag, 1, SpellLevel.CANTRIP, 0, badger);
            Assert.Equal(badger.HitPointsMax, badger.HitPoints);
            Random.State = 1;
            Random.FixedRandom = Random.DebugState.Avg;
            Spells.PoisonSpray.Cast(ground, hag, 25, SpellLevel.CANTRIP, hag.ProficiencyBonus, badger, badger, badger);
            Assert.True(badger.HitPoints < hp);

        }

        [Fact]
        public void HellishRebukeTest() {
            DamagingSpellTesting(Spells.HellishRebuke, 12, DamageType.FIRE);
        }

        [Fact]
        public void SuggestionTest() {
            DefaultSpellTest(Spells.Suggestion, 15, SpellLevel.FOURTH, null, Effect.CANNOT_TAKE_ACTIONS, Spells.Suggestion.Duration);
        }

        [Fact]
        public void ContactOtherPlaneTest() {
            CharacterSheet wizard = new CharacterSheet(Race.HUMAN);
            wizard.AddLevel(CharacterClasses.Wizard);
            toughen(wizard);
            int hitPointsMax = wizard.HitPointsMax;

            // Successful save: the questions can be asked without harm
            Random.FixedRandom = Random.DebugState.Max;
            Spells.ContactOtherPlane.Cast(wizard, 0, SpellLevel.FIFTH, 0);
            Assert.Equal(hitPointsMax, wizard.HitPoints);
            Assert.False(wizard.HasEffect(Effect.SPELL_CONTACT_OTHER_PLANE_INSANITY));

            // Failed save: 6d6 psychic damage and insanity until a long rest
            Random.FixedRandom = Random.DebugState.Min;
            Spells.ContactOtherPlane.Cast(wizard, 0, SpellLevel.FIFTH, 0);
            Assert.InRange(wizard.HitPoints, hitPointsMax - 36, hitPointsMax - 6);
            Assert.True(wizard.HasEffect(Effect.SPELL_CONTACT_OTHER_PLANE_INSANITY));
            Assert.True(wizard.HasEffect(Effect.CANNOT_TAKE_ACTIONS));
            wizard.LongRest();
            Assert.False(wizard.HasEffect(Effect.SPELL_CONTACT_OTHER_PLANE_INSANITY));
            Assert.False(wizard.HasEffect(Effect.CANNOT_TAKE_ACTIONS));
        }

    }
}
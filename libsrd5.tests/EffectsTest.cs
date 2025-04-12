using System;
using Xunit;

namespace srd5 {
    public class EffectsTest {
        [Fact]
        public void ResistanceTest() {
            Assert.Equal(Effect.RESISTANCE_FORCE, Effects.Resistance(DamageType.FORCE));
        }
        [Fact]
        public void ImmunityTest() {
            Assert.Equal(Effect.IMMUNITY_PSYCHIC, Effects.Immunity(DamageType.PSYCHIC));
        }
        [Fact]
        public void VulnerabilityTest() {
            Assert.Equal(Effect.VULNERABILITY_SLASHING, Effects.Vulnerability(DamageType.SLASHING));
        }

        [Fact]
        public void TrueDamageTest() {
            Assert.Throws<Srd5ArgumentException>(delegate () {
                Monsters.Aboleth.AddEffect(Effect.IMMUNITY_TRUE_DAMAGE);
            });
            Assert.Throws<Srd5ArgumentException>(delegate () {
                Monsters.Aboleth.AddEffect(Effect.RESISTANCE_TRUE_DAMAGE);
            });
            Assert.Throws<Srd5ArgumentException>(delegate () {
                Monsters.Aboleth.AddEffect(Effect.VULNERABILITY_TRUE_DAMAGE);
            });
        }

        [Fact]
        public void CurseTest() {
            Assert.True(Effect.CURSE_MUMMY_ROT.IsCurse());
            Assert.False(Effect.BEARDED_DEVIL_POISON.IsCurse());
        }

        [Fact]
        public void EnumerateEffectsTest() {
            foreach (Effect effect in Enum.GetValues(typeof(Effect))) {
                if (effect == Effect.IMMUNITY_TRUE_DAMAGE || effect == Effect.RESISTANCE_TRUE_DAMAGE || effect == Effect.VULNERABILITY_TRUE_DAMAGE) continue;
                Combattant bandit = Monsters.Bandit;
                bandit.AddEffect(effect);
                Assert.True(bandit.HasEffect(effect));
                bandit.OnStartOfTurn();
                bandit.OnEndOfTurn();
                bandit.OnDamageTaken(new DamageSource(effect, Monsters.NightHag), new Damage(DamageType.TRUE_DAMAGE, 1));
                bandit.RemoveEffect(effect);
                Assert.False(bandit.HasEffect(effect));
                bandit.OnStartOfTurn();
                bandit.OnEndOfTurn();
                bandit.OnDamageTaken(new DamageSource(effect, Monsters.NightHag), new Damage(DamageType.TRUE_DAMAGE, 1));
            }
        }

        [Fact]
        public void QuasitPoisonEffectTest() {
            Combattant bandit = Monsters.Bandit;
            while (!bandit.HasEffect(Effect.QUASIT_POISON)) {
                bandit.AddEffect(Effect.QUASIT_POISON);
                bandit.OnEndOfTurn();
            }
            Assert.True(bandit.HasCondition(ConditionType.POISONED));
            bandit.RemoveEffect(Effect.QUASIT_POISON);
            bandit.OnEndOfTurn();
            Assert.False(bandit.HasCondition(ConditionType.POISONED));
        }

        [Fact]
        public void LichParalyzingTouchEffectTest() {
            Combattant bandit = Monsters.Bandit;
            while (!bandit.HasEffect(Effect.LICH_PARALYZATION)) {
                bandit.AddEffect(Effect.LICH_PARALYZATION);
                bandit.OnEndOfTurn();
            }
            Assert.True(bandit.HasCondition(ConditionType.PARALYZED));
            bandit.RemoveEffect(Effect.LICH_PARALYZATION);
            bandit.OnEndOfTurn();
            Assert.False(bandit.HasCondition(ConditionType.PARALYZED));
        }

        [Fact]
        public void DiseaseTest() {
            Assert.True(Effect.DEATH_DOG_DISEASE.IsDisease());
            Assert.False(Effect.CURSE_MUMMY_ROT.IsDisease());
        }

        [Fact]
        public void CheckSpellTest() {
            Assert.Throws<Srd5ArgumentException>(delegate () {
                Effect.GRAPPLING.SpellLevel();
            });
            Assert.Equal(SpellLevel.CANTRIP, Effect.SPELL_LIGHT.SpellLevel());
            Assert.Equal(SpellLevel.FIRST, Effect.SPELL_DISGUISE_SELF.SpellLevel());
            Assert.Equal(SpellLevel.SECOND, Effect.SPELL_BLINDNESS_DEAFNESS.SpellLevel());
            Assert.Equal(SpellLevel.THIRD, Effect.SPELL_BESTOW_CURSE_LOSE_TURN_ON_FAILED_WISDOM_SAVE.SpellLevel());
            Assert.Equal(SpellLevel.FOURTH, Effect.SPELL_PLACEHOLDER_4TH.SpellLevel());
            Assert.Equal(SpellLevel.FIFTH, Effect.SPELL_PLACEHOLDER_5TH.SpellLevel());
            Assert.Equal(SpellLevel.SIXTH, Effect.SPELL_PLACEHOLDER_6TH.SpellLevel());
            Assert.Equal(SpellLevel.SEVENTH, Effect.SPELL_PLACEHOLDER_7TH.SpellLevel());
            Assert.Equal(SpellLevel.EIGHTH, Effect.SPELL_PLACEHOLDER_8TH.SpellLevel());
            Assert.Equal(SpellLevel.NINTH, Effect.SPELL_PLACEHOLDER_9TH.SpellLevel());
            Assert.Throws<Srd5ArgumentException>(delegate () {
                Effect.SPELL_GENERIC.SpellLevel();
            });
        }
    }
}
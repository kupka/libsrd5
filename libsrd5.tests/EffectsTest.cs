using System;
using System.IO;
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
            Combattant bandit = Monsters.Bandit;
            foreach (Effect effect in Enum.GetValues(typeof(Effect))) {
                if (effect == Effect.IMMUNITY_TRUE_DAMAGE || effect == Effect.RESISTANCE_TRUE_DAMAGE || effect == Effect.VULNERABILITY_TRUE_DAMAGE) continue;
                bandit.AddEffect(effect);
                Assert.True(bandit.HasEffect(effect));
                bandit.OnStartOfTurn();
                bandit.OnEndOfTurn();
                bandit.OnDamageTaken();
                bandit.RemoveEffect(effect);
                bandit.OnStartOfTurn();
                bandit.OnEndOfTurn();
                bandit.OnDamageTaken();
                Assert.False(bandit.HasEffect(effect));
            }
        }
    }
}
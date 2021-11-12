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
    }
}
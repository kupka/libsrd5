using System;
using Xunit;
using static srd5.Die;

namespace srd5 {
    public partial class SpellTest {
        [Fact]
        public void BrandingSmiteTest() {
            CharacterSheet paladin = new CharacterSheet(Race.HUMAN);
            paladin.Equip(Weapons.Longsword);
            Spells.BrandingSmite.Cast(paladin, 10, SpellLevel.THIRD, 5);
            Assert.True(paladin.MeleeAttacks[0].AdditionalDamage[0].Type == DamageType.RADIANT);
            Assert.True(paladin.MeleeAttacks[0].EffectOnHit.Length == 1);
            while (!paladin.Attack(paladin.MeleeAttacks[0], Monsters.Rat, 5)) {

            }
            Assert.True(paladin.MeleeAttacks[0].AdditionalDamage.Length == 0);
            Assert.True(paladin.MeleeAttacks[0].EffectOnHit.Length == 0);
        }

        [Fact]
        public void BrandingSmiteMultipleAttacksTest() {
            // Every melee attack is branded; the first hit removes the extra damage from all of them
            Monster owlbear = Monsters.Owlbear; // beak and claws
            Assert.Equal(2, owlbear.MeleeAttacks.Length);
            Spells.BrandingSmite.Cast(owlbear, 10, SpellLevel.SECOND, 0);
            foreach (Attack attack in owlbear.MeleeAttacks) {
                Assert.Equal(DamageType.RADIANT, attack.AdditionalDamage[0].Type);
            }
            Monster rat = Monsters.Rat; // creating a monster rolls its hit dice, so do it before fixing the roll
            Random.FixedRandom = Random.DebugState.Max; // guarantee the hit
            Assert.True(owlbear.Attack(owlbear.MeleeAttacks[1], rat, 5));
            foreach (Attack attack in owlbear.MeleeAttacks) {
                Assert.Empty(attack.AdditionalDamage);
            }
        }
    }
}

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
    }
}

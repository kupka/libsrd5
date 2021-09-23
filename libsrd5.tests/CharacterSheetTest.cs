using System;
using Xunit;

namespace srd5 {
    public class CharacterSheetTest {
        [Fact]
        public void EquipOneHandTest() {
            Thing<Weapon> club = new Thing<Weapon>(Weapons.Club);
            CharacterSheet sheet = new CharacterSheet(Race.HUMAN);
            sheet.Equip(club);
            Assert.Equal(club, sheet.Inventory.MainHand);
        }

        [Fact]
        public void EquipTwoHandTest() {
            Thing<Weapon> greatAxe = new Thing<Weapon>(Weapons.Greataxe);
            Thing<Weapon> club = new Thing<Weapon>(Weapons.Club);
            CharacterSheet sheet = new CharacterSheet(Race.HUMAN);
            sheet.Equip(club);
            sheet.Equip(greatAxe);
            Assert.Equal(greatAxe, sheet.Inventory.MainHand);
            Assert.Null(sheet.Inventory.OffHand);
        }

        [Fact]
        public void EquipDualWieldTest() {
            Thing<Weapon> greatAxe = new Thing<Weapon>(Weapons.Greataxe);
            Thing<Weapon> club1 = new Thing<Weapon>(Weapons.Club);
            Thing<Weapon> club2 = new Thing<Weapon>(Weapons.Club);
            Thing<Weapon> club3 = new Thing<Weapon>(Weapons.Club);
            CharacterSheet sheet = new CharacterSheet(Race.DRAGONBORN);
            sheet.Equip(greatAxe);
            sheet.Equip(club1);
            sheet.Equip(club2);
            sheet.Equip(club3);
            Assert.True(sheet.Inventory.MainHand.Equals(club3));
            Assert.True(sheet.Inventory.OffHand.Equals(club2));
            sheet.Unequip(club3);
            sheet.Equip(club2);
            Assert.Null(sheet.Inventory.MainHand);
            Assert.True(sheet.Inventory.OffHand.Equals(club2));
        }

        [Fact]
        public void EquipArmorTest() {
            Thing<Armor> chainShirt = new Thing<Armor>(Armors.ChainShirt);
            CharacterSheet sheet = new CharacterSheet(Race.HUMAN);
            sheet.Dexterity.Value = 18;
            Assert.Equal(14, sheet.ArmorClass);
            sheet.Equip(chainShirt);
            Assert.Equal(15, sheet.ArmorClass);
        }

        [Fact]
        public void EquipFullTest() {
            Thing<Weapon> club = new Thing<Weapon>(Weapons.Club);
            Thing<Shield> buckler = new Thing<Shield>(Shields.Buckler);
            CharacterSheet sheet = new CharacterSheet(Race.HUMAN);
            sheet.Equip(club);
            sheet.Equip(buckler);
            Assert.Equal(club, sheet.Inventory.MainHand);
            Assert.True(buckler.Equals(sheet.Inventory.OffHand));
        }

        [Fact]
        public void BarbarianTest() {
            CharacterSheet sheet = new CharacterSheet(Race.HUMAN);
            sheet.AddLevel(CharacterClasses.Barbarian);
            Assert.Contains(Feat.RAGE, sheet.Feats);
            Assert.DoesNotContain(Feat.RECKLESS_ATTACK, sheet.Feats);
            sheet.AddLevel(CharacterClasses.Barbarian);
            Assert.Contains(Feat.RECKLESS_ATTACK, sheet.Feats);
            sheet.AddLevel(CharacterClasses.Barbarian);
            Assert.Equal(2, sheet.AttackProficiency);
            sheet.AddLevel(CharacterClasses.Barbarian);
            sheet.AddLevel(CharacterClasses.Barbarian);
            Assert.Equal(3, sheet.AttackProficiency);
            sheet.Strength.Value = 18;
            sheet.Dexterity.Value = 14;
            Thing<Weapon> club = new Thing<Weapon>(Weapons.Club);
            sheet.Equip(club);
            Assert.Equal(7, sheet.AttackProficiency);
            Thing<Weapon> longbow = new Thing<Weapon>(Weapons.Longbow);
            sheet.Equip(longbow);
            Assert.Equal(5, sheet.AttackProficiency);
        }

        [Fact]
        public void DruidTest() {
            CharacterSheet sheet = new CharacterSheet(Race.HUMAN);
            sheet.Strength.Value = 8;
            sheet.Dexterity.Value = 12;
            sheet.AddLevel(CharacterClasses.Druid);
            sheet.AddLevel(CharacterClasses.Druid);
            sheet.AddLevel(CharacterClasses.Druid);
            Assert.Equal(1, sheet.AttackProficiency);
            sheet.AddLevel(CharacterClasses.Druid);
            sheet.AddLevel(CharacterClasses.Druid);
            Assert.Equal(2, sheet.AttackProficiency);
            Thing<Weapon> greatAxe = new Thing<Weapon>(Weapons.Greataxe);
            sheet.Equip(greatAxe);
            Assert.Equal(-1, sheet.AttackProficiency);
            Thing<Weapon> dagger = new Thing<Weapon>(Weapons.Dagger);
            sheet.Equip(dagger);
            Assert.Equal(4, sheet.AttackProficiency); // Dex bonus because finesse
            sheet.Strength.Value = 14;
            Assert.Equal(5, sheet.AttackProficiency); // Str bonus because greater
            sheet.AddLevel(CharacterClasses.Druid);
            sheet.AddLevel(CharacterClasses.Druid);
            sheet.AddLevel(CharacterClasses.Druid);
            Assert.Equal(5, sheet.AttackProficiency);
            sheet.AddLevel(CharacterClasses.Druid);
            Assert.Equal(6, sheet.AttackProficiency);
        }

        [Fact]
        public void HitPointsTest() {
            CharacterSheet sheet = new CharacterSheet(Race.HUMAN);
            sheet.AddLevel(CharacterClasses.Druid);
            Assert.Equal(CharacterClasses.Druid.HitDice, sheet.HitPoints);
            Assert.Equal(CharacterClasses.Druid.HitDice, sheet.HitPointsMax);
            sheet.AddLevel(CharacterClasses.Barbarian);
            Assert.InRange(sheet.HitPoints, CharacterClasses.Druid.HitDice + 1, CharacterClasses.Druid.HitDice + CharacterClasses.Barbarian.HitDice);
            Assert.InRange(sheet.HitPointsMax, CharacterClasses.Druid.HitDice + 1, CharacterClasses.Druid.HitDice + CharacterClasses.Barbarian.HitDice);
        }

        [Fact]
        public void DwarfTest() {
            CharacterSheet sheet = new CharacterSheet(Race.HILL_DWARF);
            Assert.Contains(Feat.DWARVEN_TOUGHNESS, sheet.Feats);
            sheet.AddLevel(CharacterClasses.Barbarian);
            Assert.Equal(Race.HILL_DWARF, sheet.Race.Race);
            Assert.Equal(12, sheet.Constitution.Value);
            Assert.True(sheet.IsProficient(Proficiency.WARHAMMER));
            Assert.Equal(14, sheet.HitPoints); // 12 barbarian + 1 constituion + 1 racial feat
            Assert.Equal(14, sheet.HitPointsMax); // 12 barbarian + 1 constituion + 1 racial feat
            sheet.Equip(new Thing<Armor>(Armors.Plate));
            Assert.Equal(18, sheet.ArmorClass);
            Assert.Equal(25, sheet.Speed);
        }

        [Fact]
        public void HeavyArmorTest() {
            CharacterSheet sheet = new CharacterSheet(Race.HUMAN);
            Assert.Equal(30, sheet.Speed);
            Thing<Armor> plate = new Thing<Armor>(Armors.Plate);
            sheet.Equip(plate);
            Assert.Equal(20, sheet.Speed);
            sheet.Unequip(plate);
            Assert.Equal(30, sheet.Speed);
        }

        [Fact]
        public void BlindedTest() {
            CharacterSheet sheet = new CharacterSheet(Race.GNOME);
            Assert.Equal(Size.SMALL, sheet.Size);
            sheet.AddCondition(ConditionType.BLINDED);
            Assert.True(sheet.HasEffect(Effect.DISADVANTAGE_ON_ATTACK));
            sheet.RemoveCondition(ConditionType.BLINDED);
            Assert.False(sheet.HasEffect(Effect.DISADVANTAGE_ON_ATTACK));
        }

        [Fact]
        public void HeadbandOfIntellectTest() {
            CharacterSheet sheet = new CharacterSheet(Race.TIEFLING);
            Assert.Equal(10, sheet.Intelligence.Value);
            Thing<Helmet> headband = new Thing<Helmet>(Helmets.HeadbandOfIntellect);
            sheet.Equip(headband);
            Assert.Equal(19, sheet.Intelligence.Value);
            sheet.Unequip(headband);
            Assert.Equal(10, sheet.Intelligence.Value);
        }

        [Fact]
        public void RingTest() {
            CharacterSheet sheet = new CharacterSheet(Race.HALF_ELF);
            Assert.Equal(10, sheet.ArmorClass);
            Thing<Ring> ring1 = new Thing<Ring>(Rings.RingOfSwimming);
            Thing<Ring> ring2 = new Thing<Ring>(Rings.RingOfProtection);
            Thing<Ring> ring3 = new Thing<Ring>(Rings.RingOfProtection);
            sheet.Equip(ring1);
            sheet.Equip(ring2);
            Assert.Equal(ring2, sheet.Inventory.RingRight);
            Assert.Equal(11, sheet.ArmorClass);
            sheet.Unequip(ring2);
            Assert.Equal(10, sheet.ArmorClass);
            sheet.Equip(ring2);
            Assert.Equal(11, sheet.ArmorClass);
            sheet.Equip(ring3);
            Assert.Equal(11, sheet.ArmorClass);
            Assert.Equal(ring3, sheet.Inventory.RingLeft);
            sheet.Unequip(ring3);
            Assert.Equal(11, sheet.ArmorClass);
            sheet.Unequip(ring2);
            Assert.Equal(10, sheet.ArmorClass);
        }

        [Fact]
        public void AmuletTest() {
            CharacterSheet sheet = new CharacterSheet(Race.HALF_ORC);
            sheet.AddLevel(CharacterClasses.Druid);
            Assert.Equal(8, sheet.HitPointsMax);
            Thing<Amulet> amulet = new Thing<Amulet>(Amulets.AmuletOfHealth);
            sheet.Equip(amulet);
            Assert.Equal(19, sheet.Constitution.Value);
            Assert.Equal(12, sheet.HitPointsMax);
            sheet.Unequip(amulet);
            Assert.Equal(8, sheet.HitPointsMax);
        }

        [Fact]
        public void BootsTest() {
            CharacterSheet sheet = new CharacterSheet(Race.HIGH_ELF);
            Thing<Boots> boots = new Thing<Boots>(Bootss.BootsOfTheWinterland);
            sheet.Equip(boots);
            Assert.Equal(boots, sheet.Inventory.Boots);
            Assert.True(sheet.HasEffect(Effect.RESISTANCE_COLD));
            sheet.Unequip(boots);
            Assert.Null(sheet.Inventory.Boots);
        }

        [Fact]
        public void CoverageTest() {
            CharacterSheet sheet = new CharacterSheet(Race.HIGH_ELF);
            sheet.AddLevel(CharacterClasses.Barbarian);
            Assert.Single(sheet.Levels);
            Assert.NotEmpty(sheet.Proficiencies);
            Assert.NotEmpty(sheet.Effects);
            Assert.Single(sheet.HitDice);
            Assert.Empty(sheet.Conditions);
        }

        [Fact]
        public void UnarmedTest() {
            CharacterSheet sheet = new CharacterSheet(Race.HALF_ELF);
            sheet.Strength.Value = 14;
            sheet.AddLevel(CharacterClasses.Barbarian);
            sheet.RecalculateAttacks();
            Assert.Single(sheet.MeleeAttacks);
            Assert.Empty(sheet.RangedAttacks);
            Attack unarmed = sheet.MeleeAttacks[0];
            Assert.Equal(4, unarmed.AttackBonus);
            Assert.Equal("1d1+2", unarmed.Damage.Dices.ToString());
            Assert.Equal(3, unarmed.Damage.Dices.Roll());
        }

        [Fact]
        public void MultiAttacksMeleeTest() {
            CharacterSheet sheet = new CharacterSheet(Race.HALF_ELF);
            sheet.Strength.Value = 14;
            sheet.AddLevel(CharacterClasses.Barbarian);
            sheet.AddEffect(Effect.ONE_EXTRA_ATTACK);
            sheet.AddEffect(Effect.TWO_EXTRA_ATTACKS);
            sheet.AddEffect(Effect.THREE_EXTRA_ATTACKS);
            Thing<Weapon> club = new Thing<Weapon>(Weapons.Club);
            Thing<Weapon> dagger = new Thing<Weapon>(Weapons.Dagger);
            sheet.Equip(club);
            sheet.Equip(dagger);
            Assert.Equal(4, sheet.MeleeAttacks.Length);
            Assert.Equal(dagger.Item.Name, sheet.BonusAttack.Name);
            sheet.RemoveEffect(Effect.THREE_EXTRA_ATTACKS);
            Assert.Equal(3, sheet.MeleeAttacks.Length);
            sheet.RemoveEffect(Effect.TWO_EXTRA_ATTACKS);
            Assert.Equal(2, sheet.MeleeAttacks.Length);
            sheet.RemoveEffect(Effect.ONE_EXTRA_ATTACK);
            Assert.Single(sheet.MeleeAttacks);
        }

        [Fact]
        public void MultiAttacksRangedTest() {
            CharacterSheet sheet = new CharacterSheet(Race.HALF_ELF);
            sheet.Dexterity.Value = 14;
            sheet.AddLevel(CharacterClasses.Barbarian);
            sheet.AddEffect(Effect.ONE_EXTRA_ATTACK);
            sheet.AddEffect(Effect.TWO_EXTRA_ATTACKS);
            sheet.AddEffect(Effect.THREE_EXTRA_ATTACKS);
            Thing<Weapon> longbow = new Thing<Weapon>(Weapons.Longbow);
            sheet.Equip(longbow);
            Assert.Equal(4, sheet.RangedAttacks.Length);
            sheet.RemoveEffect(Effect.THREE_EXTRA_ATTACKS);
            Assert.Equal(3, sheet.RangedAttacks.Length);
            sheet.RemoveEffect(Effect.TWO_EXTRA_ATTACKS);
            Assert.Equal(2, sheet.RangedAttacks.Length);
            sheet.RemoveEffect(Effect.ONE_EXTRA_ATTACK);
            Assert.Single(sheet.RangedAttacks);
        }

        [Fact]
        public void VersatileTest() {
            CharacterSheet sheet = new CharacterSheet(Race.HALFLING);
            Thing<Weapon> quarterstaff = new Thing<Weapon>(Weapons.Quarterstaff);
            sheet.Equip(quarterstaff);
            Assert.Equal(8, sheet.MeleeAttacks[0].Damage.Dices.Dice);
            Thing<Shield> buckler = new Thing<Shield>(Shields.Buckler);
            sheet.Equip(buckler);
            Assert.Equal(6, sheet.MeleeAttacks[0].Damage.Dices.Dice);
        }

        [Fact]
        public void SkillModifierTest() {
            CharacterSheet sheet = new CharacterSheet(Race.HUMAN);
            sheet.Strength.Value = 8;
            sheet.Wisdom.Value = 14;
            sheet.Charisma.Value = 10;
            sheet.Dexterity.Value = 16;
            sheet.Intelligence.Value = 1;
            Assert.Equal(3, sheet.GetSkillModifier(Skill.STEALTH));
            Assert.Equal(-1, sheet.GetSkillModifier(Skill.ATHLETICS));
            Assert.Equal(0, sheet.GetSkillModifier(Skill.PERFORMANCE));
            Assert.Equal(-5, sheet.GetSkillModifier(Skill.ARCANA));
            sheet.AddProficiency(Proficiency.STEALTH);
            Assert.Equal(5, sheet.GetSkillModifier(Skill.STEALTH));
        }

    }
}
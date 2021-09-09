using System;
using Xunit;

namespace d20 {
    public class CharacterSheetTest {
        [Fact]
        public void EquipOneHandTest() {
            Thing<Weapon> club = new Thing<Weapon>(Weapons.Club);
            CharacterSheet sheet = new CharacterSheet(CharacterRaces.Human);
            sheet.Equip(club);
            Assert.Equal(club, sheet.Inventory.MainHand);
        }

        [Fact]
        public void EquipTwoHandTest() {
            Thing<Weapon> greatAxe = new Thing<Weapon>(Weapons.GreatAxe);
            Thing<Weapon> club = new Thing<Weapon>(Weapons.Club);
            CharacterSheet sheet = new CharacterSheet(CharacterRaces.Human);
            sheet.Equip(club);
            sheet.Equip(greatAxe);
            Assert.Equal(greatAxe, sheet.Inventory.MainHand);
            Assert.Null(sheet.Inventory.OffHand);
        }

        [Fact]
        public void EquipArmorTest() {
            Thing<Armor> chainShirt = new Thing<Armor>(Armors.ChainShirt);
            CharacterSheet sheet = new CharacterSheet(CharacterRaces.Human);
            sheet.Dexterity.Value = 18;
            Assert.Equal(14, sheet.ArmorClass);
            sheet.Equip(chainShirt);
            Assert.Equal(15, sheet.ArmorClass);
        }

        [Fact]
        public void EquipFullTest() {
            Thing<Weapon> club = new Thing<Weapon>(Weapons.Club);
            Thing<Shield> buckler = new Thing<Shield>(Shields.Buckler);
            CharacterSheet sheet = new CharacterSheet(CharacterRaces.Human);
            sheet.Equip(club);
            sheet.Equip(buckler);
            Assert.Equal(club, sheet.Inventory.MainHand);
            Assert.True(buckler.Equals(sheet.Inventory.OffHand));
        }

        [Fact]
        public void BarbarianTest() {
            CharacterSheet sheet = new CharacterSheet(CharacterRaces.Human);
            sheet.AddLevel(CharacterClasses.Barbarian);
            sheet.AddLevel(CharacterClasses.Barbarian);
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
            CharacterSheet sheet = new CharacterSheet(CharacterRaces.Human);
            sheet.Strength.Value = 8;
            sheet.Dexterity.Value = 12;
            sheet.AddLevel(CharacterClasses.Druid);
            sheet.AddLevel(CharacterClasses.Druid);
            sheet.AddLevel(CharacterClasses.Druid);
            Assert.Equal(1, sheet.AttackProficiency);
            sheet.AddLevel(CharacterClasses.Druid);
            sheet.AddLevel(CharacterClasses.Druid);
            Assert.Equal(2, sheet.AttackProficiency);
            Thing<Weapon> greatAxe = new Thing<Weapon>(Weapons.GreatAxe);
            sheet.Equip(greatAxe);
            Assert.Equal(-1, sheet.AttackProficiency);
            Thing<Weapon> dagger = new Thing<Weapon>(Weapons.Dagger);
            sheet.Equip(dagger);
            Assert.Equal(4, sheet.AttackProficiency);
            sheet.AddLevel(CharacterClasses.Druid);
            sheet.AddLevel(CharacterClasses.Druid);
            sheet.AddLevel(CharacterClasses.Druid);
            Assert.Equal(4, sheet.AttackProficiency);
            sheet.AddLevel(CharacterClasses.Druid);
            Assert.Equal(5, sheet.AttackProficiency);
        }

        [Fact]
        public void HitPointsTest() {
            CharacterSheet sheet = new CharacterSheet(CharacterRaces.Human);
            sheet.AddLevel(CharacterClasses.Druid);
            Assert.Equal(CharacterClasses.Druid.HitDice, sheet.HitPoints);
            Assert.Equal(CharacterClasses.Druid.HitDice, sheet.HitPointsMax);
            sheet.AddLevel(CharacterClasses.Barbarian);
            Assert.InRange(sheet.HitPoints, CharacterClasses.Druid.HitDice + 1, CharacterClasses.Druid.HitDice + CharacterClasses.Barbarian.HitDice);
            Assert.InRange(sheet.HitPointsMax, CharacterClasses.Druid.HitDice + 1, CharacterClasses.Druid.HitDice + CharacterClasses.Barbarian.HitDice);
        }

        [Fact]
        public void DwarfTest() {
            CharacterSheet sheet = new CharacterSheet(CharacterRaces.HillDwarf);
            sheet.AddLevel(CharacterClasses.Barbarian);
            Assert.Equal(Race.HILL_DWARF, sheet.Race.Race);
            Assert.Equal(12, sheet.Constitution.Value);
            Assert.True(sheet.IsProficient(Proficiency.WARHAMMER));
            Assert.Equal(13, sheet.HitPoints);
        }

        [Fact]
        public void BlindedTest() {
            CharacterSheet sheet = new CharacterSheet(CharacterRaces.Gnome);
            sheet.AddCondition(ConditionType.BLINDED);
            Assert.True(sheet.HasEffect(Effect.DISADVANTAGE_ON_ATTACK));
            sheet.RemoveCondition(ConditionType.BLINDED);
            Assert.False(sheet.HasEffect(Effect.DISADVANTAGE_ON_ATTACK));
        }
    }
}
using System;
using Xunit;

namespace d20 {
    public class CharacterSheetTest {
        [Fact]        
        public void EquipOneHandTest() {
            Thing<Weapon> club = new Thing<Weapon>(Weapons.Club);
            CharacterSheet sheet = new CharacterSheet();
            sheet.Equip(club);
            Assert.Equal(sheet.Inventory.MainHand, club);
        }
    }
}
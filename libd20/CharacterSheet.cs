using System;

namespace d20 {
    public class CharacterLevel {
        public uint Levels { get; internal set; }
        public CharacterClass Class { get; internal set; }
    }

    public class CharacterInventory {
        public Thing<Weapon> MainHand { get; internal set; }
        public Thing<Item> OffHand { get; internal set; }
        public Thing<Armor> Armor  { get; internal set; }
        public Thing<Helmet> Helmet { get; internal set; }
        public Thing<Amulet> Amulet { get; internal set; }
        public Thing<Ring> RingRight { get; internal set; }
        public Thing<Ring> RingLeft { get; internal set; }
        public Thing<Boots> Boots { get; internal set; }
    }

    public class CharacterSheet {
        public Ability Strength { get; internal set; }
        public Ability Dexterity { get; internal set; }
        public Ability Constitution { get; internal set; }
        public Ability Intelligence { get; internal set; }
        public Ability Wisdom { get; internal set; }
        public Ability Charisma { get; internal set; }
        public string Name { get; internal set; }
        public CharacterRace Race { get; internal set; }
        public CharacterLevel[] Levels { get; internal set; }
        public uint HitPointsMax { get; internal set; }
        public uint HitPoints { get; internal set; }
        public Dice[] HitDiceSpent { get; internal set; }
        public CharacterInventory Inventory { get; internal set; } = new CharacterInventory();

        public void Equip(Thing<Weapon> thing) {
            switch(thing.Item.Type) {
                case ItemType.WEAPON:
                    Weapon weapon = thing.Item;
                    if (Array.IndexOf(weapon.Properties, WeaponProperty.TWO_HANDED) >= 0) {
                        Unequip(Inventory.OffHand); 
                        Unequip(Inventory.MainHand);
                        Inventory.MainHand = thing;                       
                    } else if(Inventory.MainHand == null) {
                       Inventory.MainHand = thing;  
                    } else if(Inventory.OffHand == null) {
                        Inventory.OffHand = Thing<Item>.Cast<Weapon>(thing);
                    } else {
                        Unequip(Inventory.MainHand);
                        Inventory.MainHand = thing;
                    }
                    break;
            }
        }

        public void Unequip<T>(Thing<T> thing) where T : Item {
            if (thing == null) return;
            switch (thing.Item.Type) {
                case ItemType.WEAPON:
                    if(Inventory.MainHand.Equals(thing))
                        Inventory.MainHand = null;
                    else if(Inventory.OffHand.Equals(thing))
                        Inventory.OffHand = null;
                    break;
            }
        }

        
    }
}
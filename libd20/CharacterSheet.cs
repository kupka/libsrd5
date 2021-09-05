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
        public Ability Strength { get; internal set; } = new Ability();
        public Ability Dexterity { get; internal set; } = new Ability();
        public Ability Constitution { get; internal set; } = new Ability();
        public Ability Intelligence { get; internal set; } = new Ability();
        public Ability Wisdom { get; internal set; } = new Ability();
        public Ability Charisma { get; internal set; } = new Ability();
        public string Name { get; internal set; }
        public CharacterRace Race { get; internal set; }
        public CharacterLevel[] Levels {
            get {
                return levels;
            }
        }
        private CharacterLevel[] levels = new CharacterLevel[0];
        public uint HitPointsMax { get; internal set; }
        public uint HitPoints { get; internal set; }
        public Dice[] HitDiceSpent { get; internal set; }
        public CharacterInventory Inventory { get; internal set; } = new CharacterInventory();
        public int ArmorClass { 
            get {
                int ac = 10 + Dexterity.Modifier;
                if (Inventory.Armor != null) {
                    ac = Inventory.Armor.Item.AC + Math.Min(Inventory.Armor.Item.MaxDexBonus, Dexterity.Modifier);
                }
                return ac;
            }
        }

        public int AttackBonus {
            get {
                float bonus = 0;
                foreach (CharacterLevel level in levels) {
                    bonus += level.Levels * level.Class.BaseAttackBonus;
                }
                return (int)Math.Floor(bonus);
            }
        }

        public void Equip(Thing<Weapon> thing) {
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
        }

        public void Equip(Thing<Shield> thing) {
            Shield shield = thing.Item;
            if (Inventory.MainHand != null && Array.IndexOf(Inventory.MainHand.Item.Properties, WeaponProperty.TWO_HANDED) >= 0) {
                Unequip(Inventory.MainHand);
            }
            Unequip(Inventory.OffHand);
            Inventory.OffHand = Thing<Item>.Cast<Shield>(thing);
        }

        public void Equip(Thing<Armor> armor) {
            Unequip(Inventory.Armor);
            Inventory.Armor = armor;
        }

        public void Equip(Thing<Ring> ring) {
            if (Inventory.RingLeft == null)
                Inventory.RingLeft = ring;
            else if(Inventory.RingRight == null)
                Inventory.RingRight = ring;
            else {
                Unequip(Inventory.RingLeft);
                Inventory.RingLeft = ring;
            }
        }

        public void Equip(Thing<Helmet> helmet) {
            Unequip(Inventory.Helmet);
            Inventory.Helmet = helmet;
        }

        public void Equip(Thing<Boots> boots) {
            Unequip(Inventory.Boots);
            Inventory.Boots = boots;
        }

        public void Equip(Thing<Amulet> amulet) {
            Unequip(Inventory.Amulet);
            Inventory.Amulet = amulet;
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

        public void AddLevel(CharacterClass characterClass) {
            foreach (CharacterLevel level in levels) {
                if (level.Class.Class == characterClass.Class) {
                    level.Levels++;
                    return;
                }
            }
            CharacterLevel newLevel = new CharacterLevel();
            newLevel.Class = characterClass;
            newLevel.Levels = 1;
            Array.Resize(ref levels, levels.Length + 1);
            levels[levels.GetUpperBound(0)] = newLevel;
        }        
    }
}
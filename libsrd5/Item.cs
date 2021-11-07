using System;

namespace srd5 {
    public class Shield : Item {
        public int AC {
            get;
            internal set;
        }

        public Shield(string name, int ac, int value, int weight) {
            Name = name;
            AC = ac;
            Proficiencies = new Proficiency[] { Proficiency.SHIELDS };
            Value = value;
            Weight = weight;
        }
    }

    public class Armor : Item {
        public int AC { get; private set; }
        public int MaxDexBonus { get; private set; }
        public int Strength { get; private set; }
        public ArmorProperty[] Properties { get; private set; }

        public Armor(string name, int ac, int maxDexBonus, int strength, Proficiency proficiency, ArmorProperty[] properties, int value, float weight) {
            Name = name;
            AC = ac;
            MaxDexBonus = maxDexBonus;
            Strength = strength;
            Proficiencies = new Proficiency[] { proficiency };
            Properties = properties;
            Value = value;
            Weight = weight;
        }
    }

    public class Helmet : MagicItem {
        public Helmet(string name, Effect[] effects) : base(name, effects) {
            Type = ItemType.HELMET;
        }
    }

    public class Amulet : MagicItem {
        public Amulet(string name, Effect[] effects) : base(name, effects) {
            Type = ItemType.AMULET;
        }
    }

    public class Ring : MagicItem {
        public Ring(string name, Effect[] effects) : base(name, effects) {
            Type = ItemType.RING;
        }
    }

    public class Boots : MagicItem {
        public Boots(string name, Effect[] effects) : base(name, effects) {
            Type = ItemType.BOOTS;
        }
    }

    public class MagicItem : Item {
        public Effect[] Effects { get; internal set; }

        public MagicItem(string name, Effect[] effects) {
            Name = name;
            Effects = effects;
        }
    }

    public class Damage {
        public DamageType Type { get; internal set; }
        public Dices Dices { get; internal set; }

        public Damage(DamageType type, string diceString) {
            Type = type;
            Dices = new Dices(diceString);
        }
    }


    public class Weapon : Item {
        internal Weapon(string name, string damage, DamageType damageType, WeaponProperty[] properties, Proficiency[] proficiencies,
                        int value, float weight, int reach = 5, int rangeNormal = 0, int rangeLong = 0) {
            Name = name;
            Type = ItemType.WEAPON;
            Damage = new Damage(damageType, damage);
            Proficiencies = proficiencies;
            Properties = properties;
            Value = value;
            Weight = weight;
            RangeNormal = rangeNormal;
            RangeLong = rangeLong;
            Reach = reach;
        }

        public Damage Damage { get; private set; }

        public WeaponProperty[] Properties { get; private set; }

        public int RangeNormal { get; private set; }

        public int RangeLong { get; private set; }

        public int Reach { get; private set; }

        public bool HasProperty(WeaponProperty property) {
            return Array.IndexOf(Properties, property) >= 0;
        }
    }

    public abstract class Item {
        public string Name { get; protected set; }
        public ItemType Type { get; protected set; }

        public Proficiency[] Proficiencies { get; protected set; }

        public float Weight { get; protected set; }

        public int Value { get; internal set; }
    }

    public class Thing<T> where T : Item {
        private int id = Random.Get(1, int.MaxValue);

        public Thing(T item) {
            Item = item;
        }

        public override int GetHashCode() {
            return id;
        }

        public override bool Equals(object obj) {
            if (obj == null)
                return false;
            return this.GetHashCode() == obj.GetHashCode();
        }

        public T Item {
            get;
            private set;
        }

        public static implicit operator Thing<T>(Thing<Item> v) {
            return (Thing<T>)v;
        }

        public static Thing<Item> Cast<V>(Thing<V> thing) where V : Item {
            Item item = thing.Item;
            Thing<Item> newthing = new Thing<Item>(item);
            newthing.id = thing.id;
            return newthing;
        }
    }
}
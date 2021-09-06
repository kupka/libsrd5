using System;

namespace d20 {
    public class Shield : Item {
        public int AC {
            get;
            internal set;
        }

        public Shield(int ac, uint value, uint weight) {
            AC = ac;
            Proficiencies = new Proficiency[] { Proficiency.SHIELDS };
            Value = value;
            Weight = weight;
        }
    }

    public class Armor : Item {
        public int AC {
            get;
            internal set;
        }

        public int MaxDexBonus {
            get;
            internal set;
        }

        public uint Strength {
            get;
            internal set;
        }

        public Armor(int ac, int maxDexBonus, uint strength, Proficiency proficiency, uint value, uint weight) {
            AC = ac;
            MaxDexBonus = maxDexBonus;
            Strength = Strength;
            Proficiencies = new Proficiency[] { proficiency };
            Value = value;
            Weight = weight;
        }
    }

    public class Helmet : Item {

    }

    public class Amulet : Item {

    }

    public class Ring : Item {

    }

    public class Boots : Item {

    }

    public class Weapon : Item {
        internal Weapon(string damage, DamageType damageType, WeaponProperty[] properties, Proficiency[] proficiencies, 
                        uint value, uint weight, uint rangeNormal = 0, uint rangeLong = 0) {
            Type = ItemType.WEAPON;
            Damage = damage;
            this.DamageType = damageType;
            Proficiencies = proficiencies;
            Properties = properties;
            Value = value;
            Weight = weight;
            RangeNormal = rangeNormal;
            RangeLong = rangeLong;
        }

        public string Damage { get; internal set; }

        public DamageType DamageType { get; internal set; }

        public WeaponProperty[] Properties { get; internal set; }

        public uint RangeNormal { get; internal set; }

        public uint RangeLong { get; internal set; }
    }

    public abstract class Item {
        public ItemType Type { get; internal set; }

        public Proficiency[] Proficiencies { get; internal set; }

        public uint Weight { get; internal set; }

        public uint Value { get; internal set; }
    }

    public class Thing<T> where T : Item {
        private uint id = Random.Get(1, uint.MaxValue);

        public Thing(T item) {
            Item = item;
        }

        public override int GetHashCode() {
            return (int)id;
        }

        public override bool Equals(object obj) {
            if(obj == null)
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
using System;

namespace d20 {
    public class Shield : Item {
        public int AC {
            get;
            internal set;
        }

        public Shield(int ac, int value, int weight) {
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

        public int Strength {
            get;
            internal set;
        }

        public Armor(int ac, int maxDexBonus, int strength, Proficiency proficiency, int value, int weight) {
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

    public class Damage {
        public DamageType Type { get; internal set; }
        public Dices Value { get; internal set; }

        public Damage(DamageType type, string diceString) {
            Type = type;
            Value = new Dices(diceString);
        }
    }


    public class Weapon : Item {
        internal Weapon(string damage, DamageType damageType, WeaponProperty[] properties, Proficiency[] proficiencies,
                        int value, int weight, int rangeNormal = 0, int rangeLong = 0) {
            Type = ItemType.WEAPON;
            Damage = new Damage(damageType, damage);
            Proficiencies = proficiencies;
            Properties = properties;
            Value = value;
            Weight = weight;
            RangeNormal = rangeNormal;
            RangeLong = rangeLong;
        }

        public Damage Damage { get; internal set; }

        public WeaponProperty[] Properties { get; internal set; }

        public int RangeNormal { get; internal set; }

        public int RangeLong { get; internal set; }
    }

    public abstract class Item {
        public ItemType Type { get; internal set; }

        public Proficiency[] Proficiencies { get; internal set; }

        public int Weight { get; internal set; }

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
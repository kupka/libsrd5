using System;

namespace d20 {
    public enum ItemType {
        ARMOR,
        SHIELD,
        WEAPON,
        TOOL
    }

    public enum DamageType {
        BLUDGEONING,
        PIERCING,
        SLASHING
    }

    public struct Weapons {
        public static readonly Weapon Club = new Weapon("1d4", DamageType.BLUDGEONING, Proficiency.SIMPLE_MELEE_WEAPONS, Proficiency.CLUB);
    }

    public class Weapon : Item {
        internal Weapon(string damage, DamageType damageType, params Proficiency[] proficiencies) {
            Type = ItemType.WEAPON;
            Damage = damage;
            this.DamageType = damageType;
            Proficiencies = proficiencies;
        }

        public string Damage {
            get;
            internal set;
        }

        public DamageType DamageType {
            get;
            internal set;
        }
    }

    public abstract class Item {
        public ItemType Type {
            get;
            internal set;
        }

        public Proficiency[] Proficiencies {
            get;
            internal set;
        }
    }
}
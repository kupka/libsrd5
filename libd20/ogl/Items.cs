namespace d20 {
    public enum WeaponProperty {
        AMMUNITION,
        FINESSE,
        HEAVY,
        LIGHT,
        LOADING,
        RANGED,
        REACH,
        SPECIAL,
        THROWN,
        TWO_HANDED,
        VERSATILE
    }
    public enum ItemType {
        ARMOR,
        SHIELD,
        WEAPON,
        TOOL,
        HELMET,
        RING,
        AMULET,
        BOOTS
    }

    public enum DamageType {
        ACID,
        BLUDGEONING,
        COLD,
        FIRE,
        FORCE,
        LIGHTNING,
        NECROTIC,
        PIERCING,
        POISON,
        PSYCHIC,
        RADIANT,
        SLASHING,
        THUNDER
    }

    public struct Weapons {
        public static readonly Weapon Club = new Weapon(
            "1d4", 
            DamageType.BLUDGEONING, 
            new WeaponProperty[] { WeaponProperty.LIGHT },
            new Proficiency[] { Proficiency.SIMPLE_MELEE_WEAPONS, Proficiency.CLUB },
            10,
            2
        );

        public static readonly Weapon Dagger = new Weapon(
            "1d4",
            DamageType.PIERCING,
            new WeaponProperty[] { WeaponProperty.LIGHT, WeaponProperty.FINESSE, WeaponProperty.THROWN},
            new Proficiency[] {Proficiency.SIMPLE_MELEE_WEAPONS, Proficiency.DAGGER },
            200,
            1,
            20,
            60
        );

        public static readonly Weapon GreatAxe = new Weapon(
            "1d12",
            DamageType.SLASHING,
            new WeaponProperty[] { WeaponProperty.TWO_HANDED, WeaponProperty.HEAVY },
            new Proficiency[] { Proficiency.MARTIAL_MELEE_WEAPONS, Proficiency.GREATAXE },
            3000,
            7
        );

            public static readonly Weapon Longbow = new Weapon(
            "1d8",
            DamageType.PIERCING,
            new WeaponProperty[] { WeaponProperty.TWO_HANDED, WeaponProperty.HEAVY, WeaponProperty.AMMUNITION },
            new Proficiency[] { Proficiency.MARTIAL_RANGED_WEAPONS, Proficiency.LONGBOW },
            5000,
            2
        );
    }

    public struct Shields {
        public static readonly Shield Buckler = new Shield(1, 100, 1);        
    }

    public struct Armors {
        public static readonly Armor ChainShirt = new Armor(13, 2, 0, Proficiency.MEDIUM_ARMOR, 50000, 20);
    }
}
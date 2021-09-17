namespace srd5 {
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
            "Club",
            "1d4",
            DamageType.BLUDGEONING,
            new WeaponProperty[] { WeaponProperty.LIGHT },
            new Proficiency[] { Proficiency.SIMPLE_MELEE_WEAPONS, Proficiency.CLUB },
            10,
            2
        );

        public static readonly Weapon Dagger = new Weapon(
            "Dagger", "1d4", DamageType.PIERCING,
            new WeaponProperty[] { WeaponProperty.LIGHT, WeaponProperty.FINESSE, WeaponProperty.THROWN },
            new Proficiency[] { Proficiency.SIMPLE_MELEE_WEAPONS, Proficiency.DAGGER },
            200, 1, 20, 60
        );

        public static readonly Weapon Greatclub = new Weapon(
            "Greatclub", "1d8", DamageType.BLUDGEONING,
            new WeaponProperty[] { WeaponProperty.TWO_HANDED },
            new Proficiency[] { Proficiency.SIMPLE_MELEE_WEAPONS, Proficiency.GREATCLUB },
            20, 10
        );

        public static readonly Weapon Handaxe = new Weapon(
            "Handaxe", "1d6", DamageType.SLASHING,
            new WeaponProperty[] { WeaponProperty.LIGHT, WeaponProperty.THROWN },
            new Proficiency[] { Proficiency.SIMPLE_MELEE_WEAPONS, Proficiency.HANDAXE },
            500, 2, 5, 20, 60
        );

        public static readonly Weapon Javelin = new Weapon(
            "Javelin", "1d6", DamageType.PIERCING,
            new WeaponProperty[] { WeaponProperty.THROWN },
            new Proficiency[] { Proficiency.SIMPLE_MELEE_WEAPONS, Proficiency.JAVELIN },
            200, 2, 30, 120
        );

        public static readonly Weapon Mace = new Weapon(
            "Mace", "1d6", DamageType.BLUDGEONING,
            new WeaponProperty[] { },
            new Proficiency[] { Proficiency.SIMPLE_MELEE_WEAPONS, Proficiency.MACE },
            500, 4
        );

        public static readonly Weapon Quarterstaff = new Weapon(
            "Quarterstaff", "1d6", DamageType.BLUDGEONING,
            new WeaponProperty[] { WeaponProperty.VERSATILE },
            new Proficiency[] { Proficiency.SIMPLE_MELEE_WEAPONS, Proficiency.QUARTERSTAFF },
            20, 4
        );

        public static readonly Weapon Greataxe = new Weapon(
            "Greataxe", "1d12", DamageType.SLASHING,
            new WeaponProperty[] { WeaponProperty.TWO_HANDED, WeaponProperty.HEAVY },
            new Proficiency[] { Proficiency.MARTIAL_MELEE_WEAPONS, Proficiency.GREATAXE },
            3000, 7
        );

        public static readonly Weapon Longbow = new Weapon(
            "Longbow", "1d8", DamageType.PIERCING,
            new WeaponProperty[] { WeaponProperty.TWO_HANDED, WeaponProperty.HEAVY, WeaponProperty.AMMUNITION },
            new Proficiency[] { Proficiency.MARTIAL_RANGED_WEAPONS, Proficiency.LONGBOW },
            5000, 2, 0, 150, 600
        );
    }

    public struct Shields {
        public static readonly Shield Buckler = new Shield("Buckler", 1, 100, 1);
    }

    public struct Armors {
        public static readonly Armor ChainShirt = new Armor("Chain shirt", 13, 2, 0, Proficiency.MEDIUM_ARMOR, 50000, 20);
        public static readonly Armor Plate = new Armor("Plate armor", 18, 0, 15, Proficiency.HEAVY_ARMOR, 1500000, 65);
    }

    public struct Rings {
        public static readonly Ring RingOfSwimming = new Ring("Ring of Swimming", new Effect[] { Effect.SWIMMING_SPEED_40 });
        public static readonly Ring RingOfProtection = new Ring("Ring of Protection", new Effect[] { Effect.PROTECTION });
    }

    public struct Helmets {
        public static readonly Helmet HeadbandOfIntellect = new Helmet("Headband of Intellect", new Effect[] { Effect.INTELLIGENCE_19 });
    }

    public struct Amulets {
        public static readonly Amulet AmuletOfHealth = new Amulet("Amulet of Health", new Effect[] { Effect.CONSTITUION_19 });
    }

    public struct Bootss { // additional s because double plural ^_^
        public static readonly Boots BootsOfTheWinterland = new Boots("Boots of the Winterland", new Effect[] { Effect.RESISTANCE_COLD, Effect.IGNORE_SNOW_PENALITY });
    }
}
namespace srd5 {
    public enum Size {
        TINY,
        SMALL,
        MEDIUM,
        LARGE,
        HUGE,
        GARGANTUAN
    }

    public enum MonsterType {
        ABERRATION,
        BEAST,
        CELESTIAL,
        CONSTRUCT,
        DRAGON,
        ELEMENTAL,
        FEY,
        FIEND,
        GIANT,
        HUMANOID,
        MONSTROSITY,
        OOZE,
        PLANT,
        UNDEAD
    }

    public struct Attacks {
        public static readonly Attack[] None = new Attack[0];
        public static readonly Attack GiantBadgerBite = new Attack("Bite", 3, new Damage(DamageType.PIERCING, "1d6+1"));
        public static readonly Attack GiantBadgerClaws = new Attack("Claws", 3, new Damage(DamageType.SLASHING, "2d4+1"));
        public static readonly Attack OgreGreatclub = new Attack("Greatclub", 6, new Damage(DamageType.BLUDGEONING, "2d8+4"));
        public static readonly Attack OgreJavelin = new Attack("Javelin", 6, new Damage(DamageType.PIERCING, "2d6+4"), 5, 30, 120);
        public static readonly Attack NightHagClaws = new Attack("Claws", 7, new Damage(DamageType.SLASHING, "2d8+4"));
        public static readonly Attack OrcGreataxe = new Attack("Greataxe", 5, new Damage(DamageType.SLASHING, "1d12+3"));
        public static readonly Attack OrcJavelin = new Attack("Javelin", 5, new Damage(DamageType.PIERCING, "1d6+3"), 5, 30, 120);

    }

    public struct Monsters {
        public static Monster GiantBadger {
            get {
                return new Monster(
                    MonsterType.BEAST, "Giant Badger", 13, 10, 15, 2, 12, 5, 10, "2d8+4", 30, ChallengeRating.QUARTER,
                    new Attack[] { Attacks.GiantBadgerBite, Attacks.GiantBadgerClaws }, Attacks.None, Size.MEDIUM
                );
            }
        }

        public static Monster Ogre {
            get {
                return new Monster(
                    MonsterType.GIANT, "Ogre", 19, 8, 16, 5, 7, 7, 11, "7d10+21", 40, 2,
                    new Attack[] { Attacks.OgreGreatclub }, new Attack[] { Attacks.OgreJavelin }, Size.LARGE
                );
            }
        }

        public static Monster NightHag {
            get {
                Monster hag = new Monster(
                    MonsterType.FIEND, "Night Hag", 18, 15, 16, 16, 14, 16, 17, "15d8+45", 30, 5,
                    new Attack[] { Attacks.NightHagClaws }, Attacks.None, Size.MEDIUM, 14
                );
                AvailableSpells spells = new AvailableSpells(AbilityType.CHARISMA);
                spells.AddKnownSpell(Spells.MagicMissile, Spells.DetectMagic);
                spells.SlotsCurrent[1] = 999;
                hag.AddAvailableSpells(spells);
                return hag;
            }
        }

        public static Monster Orc {
            get {
                Monster orc = new Monster(
                    MonsterType.HUMANOID, "Orc", 16, 12, 16, 7, 11, 10, 13, "2d8+6", 30, -2,
                    new Attack[] { Attacks.OrcGreataxe }, new Attack[] { Attacks.OrcJavelin }, Size.MEDIUM, 0
                );
                return orc;
            }
        }
    }
}
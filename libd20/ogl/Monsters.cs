namespace d20 {
    public struct Attacks {
        public static readonly Attack[] None = new Attack[0];
        public static readonly Attack GiantBadgerBite = new Attack("Bite", 3, new Damage(DamageType.PIERCING, "1d6+1"));
        public static readonly Attack GiantBadgerClaws = new Attack("Claws", 3, new Damage(DamageType.SLASHING, "2d4+1"));
        public static readonly Attack OgreGreatclub = new Attack("Greatclub", 6, new Damage(DamageType.BLUDGEONING, "2d8+4"));
        public static readonly Attack OgreJavelin = new Attack("Javelin", 6, new Damage(DamageType.PIERCING, "2d6+4"), 5, 30, 120);

    }

    public struct Monsters {
        public static readonly Monster GiantBadger = new Monster("Giant Badger", 13, 10, 15, 2, 12, 5, 10, "2d8+4", 30, ChallengeRating.QUARTER, new Attack[]{Attacks.GiantBadgerBite, Attacks.GiantBadgerClaws}, Attacks.None);
        public static readonly Monster Ogre = new Monster("Ogre", 19, 8, 16, 5, 7, 7, 11, "7d10+21", 40, 2, new Attack[]{Attacks.OgreGreatclub}, new Attack[]{Attacks.OgreJavelin});
    }
} 
namespace d20 {
    public struct Attacks {
        public static readonly Attack OgreGreatclub = new Attack("Greatclub", 6, "2d8+4", DamageType.BLUDGEONING);
        public static readonly Attack OgreJavelin = new Attack("Javelin", 6, "2d6+4", DamageType.PIERCING, 5, 30, 120);
    }

    public struct Monsters {
        public static readonly Monster Ogre = new Monster("Ogre", 19, 8, 16, 5, 7, 7, 11, "7d10+21", 40, 2, new Attack[]{Attacks.OgreGreatclub}, new Attack[]{Attacks.OgreJavelin});
    }
} 
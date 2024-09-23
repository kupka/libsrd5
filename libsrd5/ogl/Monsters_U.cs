namespace srd5 {
    public partial struct Attacks {
        public static readonly Attack UnicornHooves = new Attack("Hooves", 7, new Damage(DamageType.BLUDGEONING, "2d6+4"), 5);
        public static readonly Attack UnicornHorn = new Attack("Horn", 7, new Damage(DamageType.PIERCING, "1d8+4"), 5);
    }

    public partial struct Monsters {
        /* TODO */
        public static Monster Unicorn {
            get {
                Monster unicorn = new Monster(
                    Monsters.Type.CELESTIAL, Monsters.ID.UNICORN, Alignment.LAWFUL_GOOD, 18, 14, 15, 11, 17, 16, 12, "9d10+18", 40, 5,
                    new Attack[] { Attacks.UnicornHooves, Attacks.UnicornHorn }, new Attack[] { }, Size.LARGE
                );
                unicorn.AddEffect(Effect.IMMUNITY_POISON);
                unicorn.AddEffect(Effect.IMMUNITY_CHARMED);
                unicorn.AddEffect(Effect.IMMUNITY_PARALYZED);
                unicorn.AddEffect(Effect.IMMUNITY_POISONED);
                unicorn.AddFeat(Feat.CHARGE_UNICORN);
                unicorn.AddFeat(Feat.INNATE_SPELLCASTING_UNICORN);
                unicorn.AddFeat(Feat.MAGIC_RESISTANCE);
                unicorn.AddFeat(Feat.MAGIC_WEAPONS);
                return unicorn;
            }
        }
    }
}
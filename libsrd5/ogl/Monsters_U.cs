using static srd5.DamageType;
using static srd5.Effect;

namespace srd5 {
    public partial struct Attacks {
        public static Attack UnicornHooves {
            get {
                return new Attack("Hooves", 7, new Damage(BLUDGEONING, "2d6+4"), 5);
            }
        }
        public static Attack UnicornHorn {
            get {
                return new Attack("Horn", 7, new Damage(PIERCING, "1d8+4"), 5);
            }
        }
    }

    public partial struct Monsters {
        /* TODO */
        public static Monster Unicorn {
            get {
                Monster unicorn = new Monster(
                    Monsters.Type.CELESTIAL, Monsters.ID.UNICORN, Alignment.LAWFUL_GOOD, 18, 14, 15, 11, 17, 16, 12, "9d10+18", 40, 5,
                    new Attack[] { Attacks.UnicornHooves, Attacks.UnicornHorn }, new Attack[] { }, Size.LARGE
                );
                unicorn.AddEffect(IMMUNITY_POISON);
                unicorn.AddEffect(IMMUNITY_CHARMED);
                unicorn.AddEffect(IMMUNITY_PARALYZED);
                unicorn.AddEffect(IMMUNITY_POISONED);
                unicorn.AddFeat(Feat.CHARGE_UNICORN);
                unicorn.AddFeat(Feat.INNATE_SPELLCASTING_UNICORN);
                unicorn.AddFeat(Feat.MAGIC_RESISTANCE);
                unicorn.AddFeat(Feat.MAGIC_WEAPONS);
                return unicorn;
            }
        }
    }
}
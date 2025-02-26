using static srd5.DamageType;
using static srd5.Effect;

namespace srd5 {
    public partial struct Attacks {
        public static Attack ZombieSlam {
            get {
                return new Attack("Slam", 3, new Damage(BLUDGEONING, "1d6+1"), 5);
            }
        }
    }

    public partial struct Monsters {
        /* TODO */
        public static Monster Zombie {
            get {
                Monster zombie = new Monster(
                    Monsters.Type.UNDEAD, Monsters.ID.ZOMBIE, Alignment.NEUTRAL_EVIL, 13, 6, 16, 3, 6, 5, 8, "3d8+9", 40, ChallengeRating.QUARTER,
                    new Attack[] { Attacks.ZombieSlam }, new Attack[] { }, Size.MEDIUM
                );
                zombie.AddProficiency(Proficiency.WISDOM);
                zombie.AddEffect(IMMUNITY_POISON);
                zombie.AddEffect(IMMUNITY_POISONED);
                zombie.AddFeat(Feat.UNDEAD_FORTITUDE);
                return zombie;
            }
        }
    }
}
using static srd5.DamageType;
using static srd5.Effect;

namespace srd5 {
    public partial struct Attacks {
        public static readonly AttackEffect FireElementalTouchEffect = delegate (Combattant attacker, Combattant target) {
            if (target.IsImmune(FIRE)) return false;
            if (target.HasEffect(FIRE_ELEMENTAL_IGNITE)) return false;
            target.AddEffect(FIRE_ELEMENTAL_IGNITE);
            // TODO: Add means to remove effect ("Until a creature takes an action to douse the fire...")
            return false;
        };
        public static Attack FireElementalTouch {
            get {
                return new Attack("Touch", 6, new Damage(FIRE, "1d6+0"), 5, null, FireElementalTouchEffect);
            }
        }
        public static Attack FireGiantGreatsword {
            get {
                return new Attack("Greatsword", 11, new Damage(SLASHING, "6d6+7"), 10);
            }
        }
        public static Attack FireGiantRock {
            get {
                return new Attack("Rock", 11, new Damage(BLUDGEONING, "4d10+7"), 5, 60, 240);
            }
        }
        public static Attack FleshGolemSlam {
            get {
                return new Attack("Slam", 7, new Damage(BLUDGEONING, "2d8+4"), 5);
            }
        }
        public static Attack FlyingSnakeBite {
            get {
                return new Attack("Bite", 6, new Damage(PIERCING, 1), 5, new Damage(POISON, "3d4"));
            }
        }
        public static Attack FlyingSwordLongsword {
            get {
                return new Attack("Longsword", 3, new Damage(SLASHING, "1d8+1"), 5);
            }
        }
        public static Attack FrostGiantGreataxe {
            get {
                return new Attack("Greataxe", 9, new Damage(SLASHING, "3d12+6"), 10);
            }
        }
        public static Attack FrostGiantRock {
            get {
                return new Attack("Rock", 9, new Damage(BLUDGEONING, "4d10+6"), 5, 60, 240);
            }
        }
    }

    public partial struct Monsters {
        /* TODO */
        public static Monster FireElemental {
            get {
                Monster fireElemental = new Monster(
                    Monsters.Type.ELEMENTAL, Monsters.ID.FIRE_ELEMENTAL, Alignment.NEUTRAL, 10, 17, 16, 6, 10, 7, 13, "12d10+36", 40, 5,
                    new Attack[] { Attacks.FireElementalTouch }, new Attack[] { }, Size.LARGE
                );
                fireElemental.AddEffect(RESISTANCE_NONMAGIC);
                fireElemental.AddEffect(IMMUNITY_FIRE);
                fireElemental.AddEffect(IMMUNITY_POISON);
                fireElemental.AddEffect(IMMUNITY_EXHAUSTION);
                fireElemental.AddEffect(IMMUNITY_GRAPPLED);
                fireElemental.AddEffect(IMMUNITY_PARALYZED);
                fireElemental.AddEffect(IMMUNITY_PETRIFIED);
                fireElemental.AddEffect(IMMUNITY_POISONED);
                fireElemental.AddEffect(IMMUNITY_PRONE);
                fireElemental.AddEffect(IMMUNITY_RESTRAINED);
                fireElemental.AddEffect(IMMUNITY_UNCONSCIOUS);
                fireElemental.AddFeat(Feat.FIRE_FORM);
                fireElemental.AddFeat(Feat.ILLUMINATION_30FT);
                fireElemental.AddFeat(Feat.WATER_SUSCEPTIBILITY);
                return fireElemental;
            }
        }

        /* TODO */
        public static Monster FireGiant {
            get {
                Monster fireGiant = new Monster(
                    Monsters.Type.GIANT, Monsters.ID.FIRE_GIANT, Alignment.LAWFUL_EVIL, 25, 9, 23, 10, 14, 13, 18, "13d12+78", 40, 9,
                    new Attack[] { Attacks.FireGiantGreatsword }, new Attack[] { Attacks.FireGiantRock }, Size.HUGE
                );
                fireGiant.AddProficiency(Proficiency.DEXTERITY);
                fireGiant.AddProficiency(Proficiency.CONSTITUTION);
                fireGiant.AddProficiency(Proficiency.CHARISMA);
                fireGiant.AddProficiency(Proficiency.ATHLETICS);
                fireGiant.AddProficiency(Proficiency.PERCEPTION);
                fireGiant.AddEffect(IMMUNITY_FIRE);
                return fireGiant;
            }
        }

        /* TODO */
        public static Monster FleshGolem {
            get {
                Monster fleshGolem = new Monster(
                    Monsters.Type.CONSTRUCT, Monsters.ID.FLESH_GOLEM, Alignment.NEUTRAL, 19, 9, 18, 6, 10, 5, 9, "11d8+44", 40, 5,
                    new Attack[] { Attacks.FleshGolemSlam }, new Attack[] { }, Size.MEDIUM
                );
                fleshGolem.AddEffect(IMMUNITY_LIGHTNING);
                fleshGolem.AddEffect(IMMUNITY_POISON);
                fleshGolem.AddEffect(IMMUNITY_NONMAGIC);
                fleshGolem.AddEffect(IMMUNITY_CHARMED);
                fleshGolem.AddEffect(IMMUNITY_EXHAUSTION);
                fleshGolem.AddEffect(IMMUNITY_FRIGHTENED);
                fleshGolem.AddEffect(IMMUNITY_PARALYZED);
                fleshGolem.AddEffect(IMMUNITY_PETRIFIED);
                fleshGolem.AddEffect(IMMUNITY_POISONED);
                fleshGolem.AddFeat(Feat.BERSERK_FLESH_GOLEM);
                fleshGolem.AddFeat(Feat.AVERSION_OF_FIRE);
                fleshGolem.AddFeat(Feat.IMMUTABLE_FORM);
                fleshGolem.AddFeat(Feat.LIGHTNING_ABSORPTION);
                fleshGolem.AddFeat(Feat.MAGIC_RESISTANCE);
                fleshGolem.AddFeat(Feat.MAGIC_WEAPONS);
                return fleshGolem;
            }
        }

        /* TODO */
        public static Monster FlyingSnake {
            get {
                Monster flyingSnake = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.FLYING_SNAKE, Alignment.UNALIGNED, 4, 18, 11, 2, 12, 5, 14, "2d4", 40, ChallengeRating.EIGHTH,
                    new Attack[] { Attacks.FlyingSnakeBite }, new Attack[] { }, Size.TINY
                );
                flyingSnake.AddFeat(Feat.FLYBY);
                return flyingSnake;
            }
        }

        /* TODO */
        public static Monster FlyingSword {
            get {
                Monster flyingSword = new Monster(
                    Monsters.Type.CONSTRUCT, Monsters.ID.FLYING_SWORD, Alignment.UNALIGNED, 12, 15, 11, 1, 5, 1, 17, "5d6", 40, ChallengeRating.QUARTER,
                    new Attack[] { Attacks.FlyingSwordLongsword }, new Attack[] { }, Size.SMALL
                );
                flyingSword.AddProficiency(Proficiency.DEXTERITY);
                flyingSword.AddEffect(IMMUNITY_POISON);
                flyingSword.AddEffect(IMMUNITY_PSYCHIC);
                flyingSword.AddEffect(IMMUNITY_BLINDED);
                flyingSword.AddEffect(IMMUNITY_CHARMED);
                flyingSword.AddEffect(IMMUNITY_BLINDED);
                flyingSword.AddEffect(IMMUNITY_FRIGHTENED);
                flyingSword.AddEffect(IMMUNITY_PARALYZED);
                flyingSword.AddEffect(IMMUNITY_PETRIFIED);
                flyingSword.AddEffect(IMMUNITY_POISONED);
                flyingSword.AddFeat(Feat.ANTIMAGIC_SUSCEPTIBILITY);
                flyingSword.AddFeat(Feat.FALSE_APPEARANCE);
                return flyingSword;
            }
        }

        /* TODO */
        public static Monster Frog {
            get {
                Monster frog = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.FROG, Alignment.UNALIGNED, 1, 13, 8, 1, 8, 3, 11, "1d4-1", 40, 0,
                    new Attack[] { }, new Attack[] { }, Size.TINY
                );
                frog.AddProficiency(Proficiency.PERCEPTION);
                frog.AddProficiency(Proficiency.STEALTH);
                frog.AddFeat(Feat.AMPHIBIOUS);
                frog.AddFeat(Feat.STANDING_LEAP_FROG_10FT);
                return frog;
            }
        }

        /* TODO */
        public static Monster FrostGiant {
            get {
                Monster frostGiant = new Monster(
                    Monsters.Type.GIANT, Monsters.ID.FROST_GIANT, Alignment.NEUTRAL_EVIL, 23, 9, 21, 9, 10, 12, 15, "12d12+60", 40, 8,
                    new Attack[] { Attacks.FrostGiantGreataxe }, new Attack[] { Attacks.FrostGiantRock }, Size.HUGE
                );
                frostGiant.AddProficiency(Proficiency.CONSTITUTION);
                frostGiant.AddProficiency(Proficiency.WISDOM);
                frostGiant.AddProficiency(Proficiency.CHARISMA);
                frostGiant.AddProficiency(Proficiency.ATHLETICS);
                frostGiant.AddProficiency(Proficiency.PERCEPTION);
                frostGiant.AddEffect(IMMUNITY_COLD);
                return frostGiant;
            }
        }
    }
}
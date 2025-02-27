using static srd5.DamageType;
using static srd5.Effect;

namespace srd5 {
    public partial struct Attacks {
        public static Attack IceDevilTail {
            get {
                return new Attack("Tail", 10, new Damage(BLUDGEONING, "2d6+5"), 5, new Damage(COLD, "3d6"));
            }
        }
        public static Attack IceDevilBite {
            get {
                return new Attack("Bite", 10, new Damage(PIERCING, "2d6+5"), 5, new Damage(COLD, "3d6"));
            }
        }
        public static Attack IceDevilClaws {
            get {
                return new Attack("Claws", 10, new Damage(SLASHING, "2d4+5"), 5, new Damage(COLD, "3d6"));
            }
        }
        public static Attack IceMephitClaws {
            get {
                return new Attack("Claws", 3, new Damage(SLASHING, "1d4+1"), 5, new Damage(COLD, "1d4"));
            }
        }
        public static readonly AttackEffect ImpStingEffect = delegate (Combattant attacker, Combattant target) {
            AttackEffects.PoisonEffect(target, ImpSting, "1d4+3", 11);
            return false;
        };
        public static Attack ImpSting {
            get {
                return new Attack("Sting", 5, new Damage(PIERCING, "1d4+3"), 5, null, ImpStingEffect);
            }
        }
        public static Attack InvisibleStalkerSlam {
            get {
                return new Attack("Slam", 6, new Damage(BLUDGEONING, "2d6+3"), 5);
            }
        }
        public static Attack IronGolemSlam {
            get {
                return new Attack("Slam", 13, new Damage(BLUDGEONING, "3d8+7"), 5);
            }
        }
        public static Attack IronGolemSword {
            get {
                return new Attack("Sword", 13, new Damage(SLASHING, "3d10+7"), 10);
            }
        }
    }

    public partial struct Monsters {
        /* TODO */
        public static Monster IceDevil {
            get {
                Monster iceDevil = new Monster(
                    Monsters.Type.FIEND, Monsters.ID.ICE_DEVIL, Alignment.LAWFUL_EVIL, 21, 14, 18, 18, 15, 18, 18, "19d10+76", 40, 14,
                    new Attack[] { Attacks.IceDevilBite, Attacks.IceDevilClaws, Attacks.IceDevilTail }, new Attack[] { }, Size.LARGE
                );
                iceDevil.AddProficiency(Proficiency.DEXTERITY);
                iceDevil.AddProficiency(Proficiency.CONSTITUTION);
                iceDevil.AddProficiency(Proficiency.WISDOM);
                iceDevil.AddProficiency(Proficiency.CHARISMA);
                iceDevil.AddEffect(RESISTANCE_NONMAGIC);
                iceDevil.AddEffect(IMMUNITY_FIRE);
                iceDevil.AddEffect(IMMUNITY_POISON);
                iceDevil.AddEffect(IMMUNITY_POISONED);
                iceDevil.AddFeat(Feat.DEVILS_SIGHT);
                iceDevil.AddFeat(Feat.MAGIC_RESISTANCE);
                return iceDevil;
            }
        }

        /* TODO */
        public static Monster IceMephit {
            get {
                Monster iceMephit = new Monster(
                    Monsters.Type.ELEMENTAL, Monsters.ID.ICE_MEPHIT, Alignment.NEUTRAL_EVIL, 7, 13, 10, 9, 11, 12, 11, "6d6", 40, ChallengeRating.HALF,
                    new Attack[] { Attacks.IceMephitClaws }, new Attack[] { }, Size.SMALL
                );
                iceMephit.AddProficiency(Proficiency.PERCEPTION);
                iceMephit.AddProficiency(Proficiency.STEALTH);
                iceMephit.AddEffect(VULNERABILITY_BLUDGEONING);
                iceMephit.AddEffect(VULNERABILITY_FIRE);
                iceMephit.AddEffect(IMMUNITY_COLD);
                iceMephit.AddEffect(IMMUNITY_POISON);
                iceMephit.AddEffect(IMMUNITY_POISONED);
                iceMephit.AddFeat(Feat.DEATH_BURST_ICE_MEPHIT);
                iceMephit.AddFeat(Feat.FALSE_APPEARANCE);
                iceMephit.AddFeat(Feat.INNATE_SPELLCASTING_ICE_MEPHIT);
                return iceMephit;
            }
        }

        /* TODO */
        public static Monster Imp {
            get {
                Monster imp = new Monster(
                    Monsters.Type.FIEND, Monsters.ID.IMP, Alignment.LAWFUL_EVIL, 6, 17, 13, 11, 12, 14, 13, "3d4+3", 40, 1,
                    new Attack[] { Attacks.ImpSting }, new Attack[] { }, Size.TINY
                );
                imp.AddProficiency(Proficiency.DECEPTION);
                imp.AddProficiency(Proficiency.INSIGHT);
                imp.AddProficiency(Proficiency.PERSUASION);
                imp.AddProficiency(Proficiency.STEALTH);
                imp.AddEffect(RESISTANCE_COLD);
                imp.AddEffect(RESISTANCE_NONMAGIC);
                imp.AddEffect(IMMUNITY_FIRE);
                imp.AddEffect(IMMUNITY_POISON);
                imp.AddEffect(IMMUNITY_POISONED);
                imp.AddFeat(Feat.SHAPECHANGER_IMP);
                imp.AddFeat(Feat.DEVILS_SIGHT);
                imp.AddFeat(Feat.MAGIC_RESISTANCE);
                return imp;
            }
        }

        /* TODO */
        public static Monster InvisibleStalker {
            get {
                Monster invisibleStalker = new Monster(
                    Monsters.Type.ELEMENTAL, Monsters.ID.INVISIBLE_STALKER, Alignment.NEUTRAL, 16, 19, 14, 10, 15, 11, 14, "16d8+32", 40, 6,
                    new Attack[] { Attacks.InvisibleStalkerSlam }, new Attack[] { }, Size.MEDIUM
                );
                invisibleStalker.AddProficiency(Proficiency.PERCEPTION);
                invisibleStalker.AddProficiency(Proficiency.STEALTH);
                invisibleStalker.AddEffect(RESISTANCE_NONMAGIC);
                invisibleStalker.AddEffect(IMMUNITY_POISON);
                invisibleStalker.AddEffect(IMMUNITY_EXHAUSTION);
                invisibleStalker.AddEffect(IMMUNITY_GRAPPLED);
                invisibleStalker.AddEffect(IMMUNITY_PARALYZED);
                invisibleStalker.AddEffect(IMMUNITY_PETRIFIED);
                invisibleStalker.AddEffect(IMMUNITY_POISONED);
                invisibleStalker.AddEffect(IMMUNITY_PRONE);
                invisibleStalker.AddEffect(IMMUNITY_RESTRAINED);
                invisibleStalker.AddEffect(IMMUNITY_UNCONSCIOUS);
                invisibleStalker.AddFeat(Feat.INVISIBILITY);
                invisibleStalker.AddFeat(Feat.FAULTLESS_TRACKER);
                return invisibleStalker;
            }
        }

        /* TODO */
        public static Monster IronGolem {
            get {
                Monster ironGolem = new Monster(
                    Monsters.Type.CONSTRUCT, Monsters.ID.IRON_GOLEM, Alignment.UNALIGNED, 24, 9, 20, 3, 11, 1, 20, "20d10+100", 40, 16,
                    new Attack[] { Attacks.IronGolemSlam, Attacks.IronGolemSword }, new Attack[] { }, Size.LARGE
                );
                ironGolem.AddEffect(IMMUNITY_FIRE);
                ironGolem.AddEffect(IMMUNITY_POISON);
                ironGolem.AddEffect(IMMUNITY_PSYCHIC);
                ironGolem.AddEffect(IMMUNITY_NONMAGIC);
                ironGolem.AddEffect(IMMUNITY_CHARMED);
                ironGolem.AddEffect(IMMUNITY_EXHAUSTION);
                ironGolem.AddEffect(IMMUNITY_FRIGHTENED);
                ironGolem.AddEffect(IMMUNITY_PARALYZED);
                ironGolem.AddEffect(IMMUNITY_PETRIFIED);
                ironGolem.AddEffect(IMMUNITY_POISONED);
                ironGolem.AddFeat(Feat.FIRE_ABSORPTION);
                ironGolem.AddFeat(Feat.IMMUTABLE_FORM);
                ironGolem.AddFeat(Feat.MAGIC_RESISTANCE);
                ironGolem.AddFeat(Feat.MAGIC_WEAPONS);
                return ironGolem;
            }
        }
    }
}
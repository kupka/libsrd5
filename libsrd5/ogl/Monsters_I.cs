namespace srd5 {
    public partial struct Attacks {
        public static readonly Attack IceDevilTail = new Attack("Tail", 10, new Damage(DamageType.BLUDGEONING, "2d6+5"), 5, new Damage(DamageType.COLD, "3d6"));
        public static readonly Attack IceDevilBite = new Attack("Bite", 10, new Damage(DamageType.PIERCING, "2d6+5"), 5, new Damage(DamageType.COLD, "3d6"));
        public static readonly Attack IceDevilClaws = new Attack("Claws", 10, new Damage(DamageType.SLASHING, "2d4+5"), 5, new Damage(DamageType.COLD, "3d6"));
        public static readonly Attack IceMephitClaws = new Attack("Claws", 3, new Damage(DamageType.SLASHING, "1d4+1"), 5, new Damage(DamageType.COLD, "1d4"));
        public static readonly AttackEffect ImpStingEffect = delegate (Combattant attacker, Combattant target) {
            AttackEffects.PoisonEffect(target, ImpSting, "1d4+3", 11);
        };
        public static readonly Attack ImpSting = new Attack("Sting", 5, new Damage(DamageType.PIERCING, "1d4+3"), 5, null, ImpStingEffect);
        public static readonly Attack InvisibleStalkerSlam = new Attack("Slam", 6, new Damage(DamageType.BLUDGEONING, "2d6+3"), 5);
        public static readonly Attack IronGolemSlam = new Attack("Slam", 13, new Damage(DamageType.BLUDGEONING, "3d8+7"), 5);
        public static readonly Attack IronGolemSword = new Attack("Sword", 13, new Damage(DamageType.SLASHING, "3d10+7"), 10);
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
                iceDevil.AddEffect(Effect.RESISTANCE_NONMAGIC);
                iceDevil.AddEffect(Effect.IMMUNITY_FIRE);
                iceDevil.AddEffect(Effect.IMMUNITY_POISON);
                iceDevil.AddEffect(Effect.IMMUNITY_POISONED);
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
                iceMephit.AddEffect(Effect.VULNERABILITY_BLUDGEONING);
                iceMephit.AddEffect(Effect.VULNERABILITY_FIRE);
                iceMephit.AddEffect(Effect.IMMUNITY_COLD);
                iceMephit.AddEffect(Effect.IMMUNITY_POISON);
                iceMephit.AddEffect(Effect.IMMUNITY_POISONED);
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
                imp.AddEffect(Effect.RESISTANCE_COLD);
                imp.AddEffect(Effect.RESISTANCE_NONMAGIC);
                imp.AddEffect(Effect.IMMUNITY_FIRE);
                imp.AddEffect(Effect.IMMUNITY_POISON);
                imp.AddEffect(Effect.IMMUNITY_POISONED);
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
                invisibleStalker.AddEffect(Effect.RESISTANCE_NONMAGIC);
                invisibleStalker.AddEffect(Effect.IMMUNITY_POISON);
                invisibleStalker.AddEffect(Effect.IMMUNITY_EXHAUSTION);
                invisibleStalker.AddEffect(Effect.IMMUNITY_GRAPPLED);
                invisibleStalker.AddEffect(Effect.IMMUNITY_PARALYZED);
                invisibleStalker.AddEffect(Effect.IMMUNITY_PETRIFIED);
                invisibleStalker.AddEffect(Effect.IMMUNITY_POISONED);
                invisibleStalker.AddEffect(Effect.IMMUNITY_PRONE);
                invisibleStalker.AddEffect(Effect.IMMUNITY_RESTRAINED);
                invisibleStalker.AddEffect(Effect.IMMUNITY_UNCONSCIOUS);
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
                ironGolem.AddEffect(Effect.IMMUNITY_FIRE);
                ironGolem.AddEffect(Effect.IMMUNITY_POISON);
                ironGolem.AddEffect(Effect.IMMUNITY_PSYCHIC);
                ironGolem.AddEffect(Effect.IMMUNITY_NONMAGIC);
                ironGolem.AddEffect(Effect.IMMUNITY_CHARMED);
                ironGolem.AddEffect(Effect.IMMUNITY_EXHAUSTION);
                ironGolem.AddEffect(Effect.IMMUNITY_FRIGHTENED);
                ironGolem.AddEffect(Effect.IMMUNITY_PARALYZED);
                ironGolem.AddEffect(Effect.IMMUNITY_PETRIFIED);
                ironGolem.AddEffect(Effect.IMMUNITY_POISONED);
                ironGolem.AddFeat(Feat.FIRE_ABSORPTION);
                ironGolem.AddFeat(Feat.IMMUTABLE_FORM);
                ironGolem.AddFeat(Feat.MAGIC_RESISTANCE);
                ironGolem.AddFeat(Feat.MAGIC_WEAPONS);
                return ironGolem;
            }
        }
    }
}
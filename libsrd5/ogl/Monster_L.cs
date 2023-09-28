namespace srd5 {
    public partial struct Attacks {
        public static readonly Attack LamiaClaws = new Attack("Claws", 5, new Damage(DamageType.SLASHING, "2d10+3"), 5);
        public static readonly Attack LamiaDagger = new Attack("Dagger", 5, new Damage(DamageType.PIERCING, "1d4+3"), 5);
        public static readonly Attack LemureFist = new Attack("Fist", 3, new Damage(DamageType.BLUDGEONING, "1d4"), 5);
        public static readonly AttackEffect LichParalyzingTouchEffect = delegate (Combattant attacker, Combattant target) {
            if (target.HasEffect(Effect.IMMUNITY_PARALYZED)) return;
            if (target.DC(LichParalyzingTouch, 18, AbilityType.CONSTITUTION)) return;
            target.AddEffect(Effect.LICH_PARALYZATION);
        };
        public static readonly Attack LichParalyzingTouch = new Attack("Paralyzing Touch", 12, new Damage(DamageType.COLD, "3d6"), 5, null, LichParalyzingTouchEffect);
        public static readonly Attack LionBite = new Attack("Bite", 5, new Damage(DamageType.PIERCING, "1d8+3"), 5);
        public static readonly Attack LionClaw = new Attack("Claw", 5, new Damage(DamageType.SLASHING, "1d6+3"), 5);
        public static readonly Attack LizardBite = new Attack("Bite", 0, new Damage(DamageType.PIERCING, 1), 5);
        public static readonly Attack LizardfolkBite = new Attack("Bite", 4, new Damage(DamageType.PIERCING, "1d6+2"), 5);
        public static readonly Attack LizardfolkHeavyClub = new Attack("Heavy Club", 4, new Damage(DamageType.BLUDGEONING, "1d6+2"), 5);
        public static readonly Attack LizardfolkJavelinMelee = new Attack("Javelin", 4, new Damage(DamageType.PIERCING, "1d6+2"), 5);
        public static readonly Attack LizardfolkSpikedShield = new Attack("Spiked Shield", 4, new Damage(DamageType.PIERCING, "1d6+2"), 5);
        public static readonly Attack LizardfolkJavelinRanged = new Attack("Javelin", 4, new Damage(DamageType.PIERCING, "1d6+2"), 5, 30, 120);
    }

    public partial struct Monsters {
        /* TODO */
        public static Monster Lamia {
            get {
                Monster lamia = new Monster(
                    Monsters.Type.MONSTROSITY, Monsters.ID.LAMIA, Alignment.CHAOTIC_EVIL, 16, 13, 15, 14, 15, 16, 13, "13d10+26", 40, 4,
                    new Attack[] { Attacks.LamiaClaws, Attacks.LamiaDagger }, new Attack[] { }, Size.LARGE
                );
                lamia.AddProficiency(Proficiency.DECEPTION);
                lamia.AddProficiency(Proficiency.INSIGHT);
                lamia.AddProficiency(Proficiency.STEALTH);
                lamia.AddFeat(Feat.INNATE_SPELLCASTING_LAMIA);
                return lamia;
            }
        }

        /* TODO */
        public static Monster Lemure {
            get {
                Monster lemure = new Monster(
                    Monsters.Type.FIEND, Monsters.ID.LEMURE, Alignment.LAWFUL_EVIL, 10, 5, 11, 1, 11, 3, 7, "3d8", 40, 0,
                    new Attack[] { Attacks.LemureFist }, new Attack[] { }, Size.MEDIUM
                );
                lemure.AddEffect(Effect.RESISTANCE_COLD);
                lemure.AddEffect(Effect.IMMUNITY_FIRE);
                lemure.AddEffect(Effect.IMMUNITY_POISON);
                lemure.AddEffect(Effect.IMMUNITY_CHARMED);
                lemure.AddEffect(Effect.IMMUNITY_FRIGHTENED);
                lemure.AddEffect(Effect.IMMUNITY_POISONED);
                lemure.AddFeat(Feat.DEVILS_SIGHT);
                lemure.AddFeat(Feat.HELLISH_REJUVENATION);
                return lemure;
            }
        }

        /* TODO */
        public static Monster Lich {
            get {
                Monster lich = new Monster(
                    Monsters.Type.UNDEAD, Monsters.ID.LICH, Alignment.UNALIGNED, 11, 16, 16, 20, 14, 16, 17, "18d8+54", 40, 21,
                    new Attack[] { }, new Attack[] { }, Size.MEDIUM
                );
                lich.AddProficiency(Proficiency.CONSTITUTION);
                lich.AddProficiency(Proficiency.INTELLIGENCE);
                lich.AddProficiency(Proficiency.WISDOM);
                lich.AddProficiency(Proficiency.ARCANA);
                lich.AddProficiency(Proficiency.HISTORY);
                lich.AddProficiency(Proficiency.INSIGHT);
                lich.AddProficiency(Proficiency.PERCEPTION);
                lich.AddEffect(Effect.RESISTANCE_COLD);
                lich.AddEffect(Effect.RESISTANCE_LIGHTNING);
                lich.AddEffect(Effect.RESISTANCE_NECROTIC);
                lich.AddEffect(Effect.IMMUNITY_POISON);
                lich.AddEffect(Effect.IMMUNITY_NONMAGIC);
                lich.AddEffect(Effect.IMMUNITY_CHARMED);
                lich.AddEffect(Effect.IMMUNITY_EXHAUSTION);
                lich.AddEffect(Effect.IMMUNITY_FRIGHTENED);
                lich.AddEffect(Effect.IMMUNITY_PARALYZED);
                lich.AddEffect(Effect.IMMUNITY_POISONED);
                lich.AddFeat(Feat.LEGENDARY_RESISTANCE);
                lich.AddFeat(Feat.REJUVENATION_LICH);
                lich.AddFeat(Feat.SPELLCASTING_LICH);
                lich.AddFeat(Feat.TURN_RESISTANCE);
                return lich;
            }
        }

        /* TODO */
        public static Monster Lion {
            get {
                Monster lion = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.LION, Alignment.UNALIGNED, 17, 15, 13, 3, 12, 8, 12, "4d10+4", 40, 1,
                    new Attack[] { Attacks.LionBite, Attacks.LionClaw }, new Attack[] { }, Size.LARGE
                );
                lion.AddProficiency(Proficiency.PERCEPTION);
                lion.AddProficiency(Proficiency.STEALTH);
                lion.AddFeat(Feat.KEEN_SMELL);
                lion.AddFeat(Feat.PACK_TACTICS);
                lion.AddFeat(Feat.POUNCE_LION);
                lion.AddFeat(Feat.RUNNING_LEAP);
                return lion;
            }
        }

        /* TODO */
        public static Monster Lizard {
            get {
                Monster lizard = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.LIZARD, Alignment.UNALIGNED, 2, 11, 10, 1, 8, 3, 10, "1d4", 40, 0,
                    new Attack[] { }, new Attack[] { }, Size.TINY
                );
                return lizard;
            }
        }

        /* TODO */
        public static Monster Lizardfolk {
            get {
                Monster lizardfolk = new Monster(
                    Monsters.Type.HUMANOID, Monsters.ID.LIZARDFOLK, Alignment.NEUTRAL, 15, 10, 13, 7, 12, 7, 13, "4d8+4", 40, ChallengeRating.HALF,
                    new Attack[] { Attacks.LizardfolkBite, Attacks.LizardfolkHeavyClub, Attacks.LizardfolkJavelinMelee, Attacks.LizardfolkSpikedShield }, new Attack[] { Attacks.LizardfolkJavelinRanged }, Size.MEDIUM
                );
                lizardfolk.AddProficiency(Proficiency.PERCEPTION);
                lizardfolk.AddProficiency(Proficiency.STEALTH);
                lizardfolk.AddProficiency(Proficiency.SURVIVAL);
                lizardfolk.AddFeat(Feat.HOLD_BREATH_15MIN);
                return lizardfolk;
            }
        }
    }
}
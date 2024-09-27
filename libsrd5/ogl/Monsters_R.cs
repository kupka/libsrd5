namespace srd5 {
    public partial struct Attacks {
        public static readonly AttackEffect RakshasaClawEffect = delegate (Combattant attacker, Combattant target) {
            target.AddEffect(Effect.CURSE_RAKSHASA);
        };
        public static Attack RakshasaClaw {
            get {
                return new Attack("Claw", 7, new Damage(DamageType.SLASHING, "2d6+2"), 5, null, RakshasaClawEffect);
            }
        }
        public static Attack RatBite {
            get {
                return new Attack("Bite", 0, new Damage(DamageType.PIERCING, "1d1"), 5);
            }
        }
        public static Attack RavenBeak {
            get {
                return new Attack("Beak", 4, new Damage(DamageType.PIERCING, "1d1"), 5);
            }
        }
        public static Attack RedDragonWyrmlingBite {
            get {
                return new Attack("Bite", 6, new Damage(DamageType.PIERCING, "1d10+4"), 5, new Damage(DamageType.FIRE, "1d6"));
            }
        }
        public static Attack ReefSharkBite {
            get {
                return new Attack("Bite", 4, new Damage(DamageType.PIERCING, "1d8+2"), 5);
            }
        }
        public static readonly AttackEffect RemorhazBiteEffect = delegate (Combattant attacker, Combattant target) {
            AttackEffects.GrapplingEffect(attacker, target, 17, Size.GARGANTUAN, true, RemorhazBite);
        };
        public static Attack RemorhazBite {
            get {
                return new Attack("Bite", 11, new Damage(DamageType.PIERCING, "6d10+7"), 5, new Damage(DamageType.FIRE, "3d6"), RemorhazBiteEffect);
            }
        }
        public static Attack RhinocerosGore {
            get {
                return new Attack("Gore", 7, new Damage(DamageType.BLUDGEONING, "2d8+5"), 5);
            }
        }
        public static Attack RidingHorseHooves {
            get {
                return new Attack("Hooves", 5, new Damage(DamageType.BLUDGEONING, "2d4+3"), 5);
            }
        }
        public static readonly AttackEffect RocTalonsEffect = delegate (Combattant attacker, Combattant target) {
            AttackEffects.GrapplingEffect(attacker, target, 19, Size.GARGANTUAN, true, RocTalons);
        };
        public static Attack RocTalons {
            get {
                return new Attack("Talons", 13, new Damage(DamageType.SLASHING, "4d6+9"), 5, null, RocTalonsEffect);
            }
        }
        public static Attack RocBeak {
            get {
                return new Attack("Beak", 13, new Damage(DamageType.PIERCING, "4d8+9"), 10);
            }
        }

        public static readonly AttackEffect RoperTendrilEffect = delegate (Combattant attacker, Combattant target) {
            AttackEffects.GrapplingEffect(attacker, target, 15, Size.HUGE, true, RoperTendril, 6);
        };
        public static Attack RoperTendril {
            get {
                return new Attack("Tendril", 7, new Damage(DamageType.BLUDGEONING, 0), 5, null, RoperTendrilEffect);
            }
        }
        public static Attack RoperBite {
            get {
                return new Attack("Bite", 7, new Damage(DamageType.PIERCING, "4d8+4"), 5);
            }
        }
        // !!!!!!!!!!!!!!!!!!!!!!UNPARSABLE ATTACK!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // RugOfSmotheringSmother
        // {"name":"Smother","desc":"Melee Weapon Attack: +5 to hit, reach 5 ft., one Medium or smaller creature. Hit: The creature is grappled (escape DC 13). Until this grapple ends, the target is restrained, blinded, and at risk of suffocating, and the rug can't smother another target. In addition, at the start of each of the target's turns, the target takes 10 (2d6 + 3) bludgeoning damage.","attack_bonus":5}
        public static readonly AttackEffect RugOfSmotheringSmotherEffect = delegate (Combattant attacker, Combattant target) {
            if (AttackEffects.GrapplingEffect(attacker, target, 13, Size.MEDIUM, true, RugOfSmotheringSmother, 1)) {
                target.AddEffect(Effect.RUG_SMOTHER);
            }
        };
        public static Attack RugOfSmotheringSmother {
            get {
                return new Attack("Smother", 5, new Damage(DamageType.SLASHING, 0), 5, null, RugOfSmotheringSmotherEffect);
            }
        }
        public static Attack RustMonsterBite {
            get {
                return new Attack("Bite", 3, new Damage(DamageType.PIERCING, "1d8+1"), 5);
            }
        }
    }

    public partial struct Monsters {
        /* TODO */
        public static Monster Rakshasa {
            get {
                Monster rakshasa = new Monster(
                    Monsters.Type.FIEND, Monsters.ID.RAKSHASA, Alignment.LAWFUL_EVIL, 14, 17, 18, 13, 16, 20, 16, "13d8+52", 40, 13,
                    new Attack[] { Attacks.RakshasaClaw }, new Attack[] { }, Size.MEDIUM
                );
                rakshasa.AddProficiency(Proficiency.DECEPTION);
                rakshasa.AddProficiency(Proficiency.INSIGHT);
                rakshasa.AddEffect(Effect.VULNERABILITY_PIERCING); // TODO: Only from Magic Weapons wielded by good creatures
                rakshasa.AddEffect(Effect.IMMUNITY_NONMAGIC);
                rakshasa.AddFeat(Feat.LIMITED_MAGIC_IMMUNITY);
                rakshasa.AddFeat(Feat.INNATE_SPELLCASTING_RAKSHASA);
                return rakshasa;
            }
        }

        /* TODO */
        public static Monster Rat {
            get {
                Monster rat = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.RAT, Alignment.UNALIGNED, 2, 11, 9, 2, 10, 4, 10, "1d4-1", 40, 0,
                    new Attack[] { Attacks.RatBite }, new Attack[] { }, Size.TINY
                );
                rat.AddFeat(Feat.KEEN_SMELL);
                return rat;
            }
        }

        /* TODO */
        public static Monster Raven {
            get {
                Monster raven = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.RAVEN, Alignment.UNALIGNED, 2, 14, 8, 2, 12, 6, 12, "1d4-1", 40, 0,
                    new Attack[] { Attacks.RavenBeak }, new Attack[] { }, Size.TINY
                );
                raven.AddProficiency(Proficiency.PERCEPTION);
                raven.AddFeat(Feat.MIMICRY_RAVEN);
                return raven;
            }
        }

        /* TODO */
        public static Monster RedDragonWyrmling {
            get {
                Monster redDragonWyrmling = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.RED_DRAGON_WYRMLING, Alignment.CHAOTIC_EVIL, 19, 10, 17, 12, 11, 15, 17, "10d8+30", 40, 4,
                    new Attack[] { Attacks.RedDragonWyrmlingBite }, new Attack[] { }, Size.MEDIUM
                );
                redDragonWyrmling.AddProficiency(Proficiency.DEXTERITY);
                redDragonWyrmling.AddProficiency(Proficiency.CONSTITUTION);
                redDragonWyrmling.AddProficiency(Proficiency.WISDOM);
                redDragonWyrmling.AddProficiency(Proficiency.CHARISMA);
                redDragonWyrmling.AddProficiency(Proficiency.PERCEPTION);
                redDragonWyrmling.AddProficiency(Proficiency.STEALTH);
                redDragonWyrmling.AddEffect(Effect.IMMUNITY_FIRE);
                return redDragonWyrmling;
            }
        }

        /* TODO */
        public static Monster ReefShark {
            get {
                Monster reefShark = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.REEF_SHARK, Alignment.UNALIGNED, 14, 13, 13, 1, 10, 4, 12, "4d8+4", 40, ChallengeRating.HALF,
                    new Attack[] { Attacks.ReefSharkBite }, new Attack[] { }, Size.MEDIUM
                );
                reefShark.AddProficiency(Proficiency.PERCEPTION);
                reefShark.AddFeat(Feat.PACK_TACTICS);
                reefShark.AddFeat(Feat.WATER_BREATHING);
                return reefShark;
            }
        }

        /* TODO */
        public static Monster Remorhaz {
            get {
                Monster remorhaz = new Monster(
                    Monsters.Type.MONSTROSITY, Monsters.ID.REMORHAZ, Alignment.UNALIGNED, 24, 13, 21, 4, 10, 5, 17, "17d12+85", 40, 11,
                    new Attack[] { Attacks.RemorhazBite }, new Attack[] { }, Size.HUGE
                );
                remorhaz.AddEffect(Effect.IMMUNITY_COLD);
                remorhaz.AddEffect(Effect.IMMUNITY_FIRE);
                remorhaz.AddFeat(Feat.HEATED_BODY_3D6);
                return remorhaz;
            }
        }

        /* TODO */
        public static Monster Rhinoceros {
            get {
                Monster rhinoceros = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.RHINOCEROS, Alignment.UNALIGNED, 21, 8, 15, 2, 12, 6, 11, "6d10+12", 40, 2,
                    new Attack[] { Attacks.RhinocerosGore }, new Attack[] { }, Size.LARGE
                );
                rhinoceros.AddFeat(Feat.CHARGE_RHINOCEROS);
                return rhinoceros;
            }
        }

        /* TODO */
        public static Monster RidingHorse {
            get {
                Monster ridingHorse = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.RIDING_HORSE, Alignment.UNALIGNED, 16, 10, 12, 2, 11, 7, 10, "2d10+2", 40, ChallengeRating.QUARTER,
                    new Attack[] { Attacks.RidingHorseHooves }, new Attack[] { }, Size.LARGE
                );
                return ridingHorse;
            }
        }

        /* TODO */
        public static Monster Roc {
            get {
                Monster roc = new Monster(
                    Monsters.Type.MONSTROSITY, Monsters.ID.ROC, Alignment.UNALIGNED, 28, 10, 20, 3, 10, 9, 15, "16d20+80", 40, 11,
                    new Attack[] { Attacks.RocBeak, Attacks.RocTalons }, new Attack[] { }, Size.GARGANTUAN
                );
                roc.AddProficiency(Proficiency.DEXTERITY);
                roc.AddProficiency(Proficiency.CONSTITUTION);
                roc.AddProficiency(Proficiency.WISDOM);
                roc.AddProficiency(Proficiency.CHARISMA);
                roc.AddProficiency(Proficiency.PERCEPTION);
                roc.AddFeat(Feat.KEEN_SIGHT);
                return roc;
            }
        }

        /* TODO */
        public static Monster Roper {
            get {
                Monster roper = new Monster(
                    Monsters.Type.MONSTROSITY, Monsters.ID.ROPER, Alignment.NEUTRAL_EVIL, 18, 8, 17, 7, 16, 6, 20, "11d10+33", 40, 5,
                    new Attack[] { Attacks.RoperBite }, new Attack[] { }, Size.LARGE
                );
                roper.AddProficiency(Proficiency.PERCEPTION);
                roper.AddProficiency(Proficiency.STEALTH);
                roper.AddFeat(Feat.FALSE_APPEARANCE);
                roper.AddFeat(Feat.GRASPING_TENDRILS);
                roper.AddFeat(Feat.SPIDER_CLIMB);
                return roper;
            }
        }

        /* TODO */
        public static Monster RugOfSmothering {
            get {
                Monster rugOfSmothering = new Monster(
                    Monsters.Type.CONSTRUCT, Monsters.ID.RUG_OF_SMOTHERING, Alignment.UNALIGNED, 17, 14, 10, 1, 3, 1, 12, "6d10", 40, 2,
                    new Attack[] { }, new Attack[] { }, Size.LARGE
                );
                rugOfSmothering.AddEffect(Effect.IMMUNITY_POISON);
                rugOfSmothering.AddEffect(Effect.IMMUNITY_PSYCHIC);
                rugOfSmothering.AddEffect(Effect.IMMUNITY_BLINDED);
                rugOfSmothering.AddEffect(Effect.IMMUNITY_CHARMED);
                rugOfSmothering.AddEffect(Effect.IMMUNITY_BLINDED);
                rugOfSmothering.AddEffect(Effect.IMMUNITY_FRIGHTENED);
                rugOfSmothering.AddEffect(Effect.IMMUNITY_PARALYZED);
                rugOfSmothering.AddEffect(Effect.IMMUNITY_PETRIFIED);
                rugOfSmothering.AddEffect(Effect.IMMUNITY_POISONED);
                rugOfSmothering.AddFeat(Feat.ANTIMAGIC_SUSCEPTIBILITY);
                rugOfSmothering.AddFeat(Feat.DAMAGE_TRANSFER_GRAPPLING);
                rugOfSmothering.AddFeat(Feat.FALSE_APPEARANCE);
                return rugOfSmothering;
            }
        }

        /* TODO */
        public static Monster RustMonster {
            get {
                Monster rustMonster = new Monster(
                    Monsters.Type.MONSTROSITY, Monsters.ID.RUST_MONSTER, Alignment.UNALIGNED, 13, 12, 13, 2, 13, 6, 14, "5d8+5", 40, ChallengeRating.HALF,
                    new Attack[] { Attacks.RustMonsterBite }, new Attack[] { }, Size.MEDIUM
                );
                rustMonster.AddFeat(Feat.IRON_SCENT);
                rustMonster.AddFeat(Feat.RUST_METAL);
                return rustMonster;
            }
        }

    }

}
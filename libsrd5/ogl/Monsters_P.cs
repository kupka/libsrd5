namespace srd5 {
    public partial struct Attacks {
        public static readonly Attack PantherBite = new Attack("Bite", 4, new Damage(DamageType.PIERCING, "1d6+2"), 5);
        public static readonly Attack PantherClaw = new Attack("Claw", 4, new Damage(DamageType.SLASHING, "1d4+2"), 5);
        public static readonly Attack PegasusHooves = new Attack("Hooves", 6, new Damage(DamageType.BLUDGEONING, "2d6+4"), 5);
        public static readonly AttackEffect PhaseSpiderBiteEffect = delegate (Combattant attacker, Combattant target) {
            if (target.IsImmune(DamageType.POISON)) return;
            if (target.DC(PhaseSpiderBite, 12, AbilityType.CONSTITUTION)) return;
            target.TakeDamage(DamageType.POISON, "4d8");
            if (target.HitPoints == 0) {
                target.AddEffect(Effect.PHASE_SPIDER_POISON);
                // TODO: remove after one hour "the target is stable but poisoned for 1 hour"
            }
        };
        public static readonly Attack PhaseSpiderBite = new Attack("Bite", 4, new Damage(DamageType.PIERCING, "1d10+2"), 5, null, PhaseSpiderBiteEffect);
        public static readonly AttackEffect PitFiendBiteEffect = delegate (Combattant attacker, Combattant target) {
            if (target.IsImmune(DamageType.POISON)) return;
            if (target.DC(PitFiendBite, 21, AbilityType.CONSTITUTION)) return;
            target.AddEffect(Effect.PIT_FIEND_POISON);
        };
        public static readonly Attack PitFiendBite = new Attack("Bite", 14, new Damage(DamageType.PIERCING, "4d6+8"), 5, null, PitFiendBiteEffect);
        public static readonly Attack PitFiendClaw = new Attack("Claw", 14, new Damage(DamageType.SLASHING, "2d8+8"), 10);
        public static readonly Attack PitFiendMace = new Attack("Mace", 14, new Damage(DamageType.BLUDGEONING, "2d6+8"), 10, new Damage(DamageType.FIRE, "6d6"));
        public static readonly Attack PitFiendTail = new Attack("Tail", 14, new Damage(DamageType.BLUDGEONING, "3d10+8"), 10);
        public static readonly Attack PlanetarGreatsword = new Attack("Greatsword", 12, new Damage(DamageType.SLASHING, "4d6+7"), 5, new Damage(DamageType.RADIANT, "5d8"));
        public static readonly Attack PlesiosaurusBite = new Attack("Bite", 6, new Damage(DamageType.PIERCING, "3d6+4"), 10);
        public static readonly AttackEffect PoisonousSnakeBiteEffect = delegate (Combattant attacker, Combattant target) {
            AttackEffects.PoisonEffect(target, PoisonousSnakeBite, "2d4", 10);
        };
        public static readonly Attack PoisonousSnakeBite = new Attack("Bite", 5, new Damage(DamageType.PIERCING, 1), 5, null, PoisonousSnakeBiteEffect);
        public static readonly Attack PolarBearBite = new Attack("Bite", 7, new Damage(DamageType.PIERCING, "1d8+5"), 5);
        public static readonly Attack PolarBearClaws = new Attack("Claws", 7, new Damage(DamageType.SLASHING, "2d6+5"), 5);
        public static readonly Attack PonyHooves = new Attack("Hooves", 4, new Damage(DamageType.BLUDGEONING, "2d4+2"), 5);
        public static readonly Attack PriestMace = new Attack("Mace", 2, new Damage(DamageType.BLUDGEONING, "1d6"), 5);
        // !!!!!!!!!!!!!!!!!!!!!!UNPARSABLE ATTACK!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // PseudodragonSting
        // {"name":"Sting","desc":"Melee Weapon Attack: +4 to hit, reach 5 ft., one creature. Hit: 4 (1d4 + 2) piercing damage, and the target must succeed on a DC 11 Constitution saving throw or become poisoned for 1 hour. If the saving throw fails by 5 or more, the target falls unconscious for the same duration, or until it takes damage or another creature uses an action to shake it awake.","attack_bonus":4,"damage":[{"damage_type":{"index":"piercing","name":"Piercing","url":"/api/damage-types/piercing"},"damage_dice":"1d4+2"}]}
        public static readonly AttackEffect PseudodragonStingEffect = delegate (Combattant attacker, Combattant target) {
            if (target.IsImmune(DamageType.POISON)) return;
            int roll;
            if (target.DC(PseudodragonSting, 11, AbilityType.CONSTITUTION, out roll)) return;
            target.AddEffect(Effect.PSEUDO_DRAGON_POISON);
            if (roll < 7) {
                target.AddEffect(Effect.PSEUDO_DRAGON_POISON_UNCONSCIOUS);
            }
        };
        public static readonly Attack PseudodragonSting = new Attack("Sting", 4, new Damage(DamageType.PIERCING, "1d4+2"), 5, null, PseudodragonStingEffect);
        public static readonly Attack PseudodragonBite = new Attack("Bite", 4, new Damage(DamageType.PIERCING, "1d4+2"), 5);
        public static readonly AttackEffect PurpleWormBiteEffect = delegate (Combattant attacker, Combattant target) {
        };
        public static readonly Attack PurpleWormBite = new Attack("Bite", 9, new Damage(DamageType.PIERCING, "3d8+9"), 5, null, PurpleWormBiteEffect);
        public static readonly AttackEffect PurpleWormTailStingerEffect = delegate (Combattant attacker, Combattant target) {
            AttackEffects.PoisonEffect(target, PurpleWormTailStinger, "3d6+9", 19);
        };
        public static readonly Attack PurpleWormTailStinger = new Attack("Tail Stinger", 9, new Damage(DamageType.PIERCING, "3d6+9"), 5, null, PurpleWormTailStingerEffect);
    }

    public partial struct Monsters {
                 /* TODO */ 
         public static Monster Panther {
            get {
                Monster panther = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.PANTHER, Alignment.UNALIGNED, 14, 15, 10, 3, 14, 7, 12, "3d8", 40, ChallengeRating.QUARTER,
                    new Attack[] { Attacks.PantherBite, Attacks.PantherClaw }, new Attack[] {  }, Size.MEDIUM
                );
                panther.AddProficiency(Proficiency.PERCEPTION);
                panther.AddProficiency(Proficiency.STEALTH);
                panther.AddFeat(Feat.KEEN_SMELL);
                panther.AddFeat(Feat.POUNCE_PANTHER);
                return panther;
            }
        }

         /* TODO */ 
         public static Monster Pegasus {
            get {
                Monster pegasus = new Monster(
                    Monsters.Type.CELESTIAL, Monsters.ID.PEGASUS, Alignment.CHAOTIC_GOOD, 18, 15, 16, 10, 15, 13, 12, "7d10+21", 40, 2,
                    new Attack[] { Attacks.PegasusHooves }, new Attack[] {  }, Size.LARGE
                );
                pegasus.AddProficiency(Proficiency.DEXTERITY);
                pegasus.AddProficiency(Proficiency.WISDOM);
                pegasus.AddProficiency(Proficiency.CHARISMA);
                pegasus.AddProficiency(Proficiency.PERCEPTION);
                return pegasus;
            }
        }

         /* TODO */ 
         public static Monster PhaseSpider {
            get {
                Monster phaseSpider = new Monster(
                    Monsters.Type.MONSTROSITY, Monsters.ID.PHASE_SPIDER, Alignment.UNALIGNED, 15, 15, 12, 6, 10, 6, 13, "5d10+5", 40, 3,
                    new Attack[] { Attacks.PhaseSpiderBite }, new Attack[] {  }, Size.LARGE
                );
                phaseSpider.AddProficiency(Proficiency.STEALTH);
                phaseSpider.AddFeat(Feat.ETHEREAL_JAUNT);
                phaseSpider.AddFeat(Feat.SPIDER_CLIMB);
                phaseSpider.AddFeat(Feat.WEB_WALKER);
                return phaseSpider;
            }
        }

         /* TODO */ 
         public static Monster PitFiend {
            get {
                Monster pitFiend = new Monster(
                    Monsters.Type.FIEND, Monsters.ID.PIT_FIEND, Alignment.LAWFUL_EVIL, 26, 14, 24, 22, 18, 24, 19, "24d10+168", 40, 20,
                    new Attack[] { Attacks.PitFiendBite, Attacks.PitFiendClaw }, new Attack[] {  }, Size.LARGE
                );
                pitFiend.AddProficiency(Proficiency.DEXTERITY);
                pitFiend.AddProficiency(Proficiency.CONSTITUTION);
                pitFiend.AddProficiency(Proficiency.WISDOM);
                pitFiend.AddEffect(Effect.RESISTANCE_COLD);
                pitFiend.AddEffect(Effect.RESISTANCE_NONMAGIC);
                pitFiend.AddEffect(Effect.IMMUNITY_FIRE);
                pitFiend.AddEffect(Effect.IMMUNITY_POISON);
                pitFiend.AddEffect(Effect.IMMUNITY_POISONED);
                pitFiend.AddFeat(Feat.FEAR_AURA);
                pitFiend.AddFeat(Feat.MAGIC_RESISTANCE);
                pitFiend.AddFeat(Feat.MAGIC_WEAPONS);
                pitFiend.AddFeat(Feat.INNATE_SPELLCASTING_PIT_FIEND);
                return pitFiend;
            }
        }

         /* TODO */ 
         public static Monster Planetar {
            get {
                Monster planetar = new Monster(
                    Monsters.Type.CELESTIAL, Monsters.ID.PLANETAR, Alignment.LAWFUL_GOOD, 24, 20, 24, 19, 22, 25, 19, "16d10+112", 40, 16,
                    new Attack[] { Attacks.PlanetarGreatsword }, new Attack[] {  }, Size.LARGE
                );
                planetar.AddProficiency(Proficiency.CONSTITUTION);
                planetar.AddProficiency(Proficiency.WISDOM);
                planetar.AddProficiency(Proficiency.CHARISMA);
                planetar.AddProficiency(Proficiency.PERCEPTION);
                planetar.AddEffect(Effect.RESISTANCE_RADIANT);
                planetar.AddEffect(Effect.RESISTANCE_NONMAGIC);
                planetar.AddEffect(Effect.IMMUNITY_CHARMED);
                planetar.AddEffect(Effect.IMMUNITY_EXHAUSTION);
                planetar.AddEffect(Effect.IMMUNITY_FRIGHTENED);
                planetar.AddFeat(Feat.ANGELIC_WEAPONS_5D8);
                planetar.AddFeat(Feat.DIVINE_AWARENESS);
                planetar.AddFeat(Feat.INNATE_SPELLCASTING_PLANETAR);
                planetar.AddFeat(Feat.MAGIC_RESISTANCE);
                return planetar;
            }
        }

         /* TODO */ 
         public static Monster Plesiosaurus {
            get {
                Monster plesiosaurus = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.PLESIOSAURUS, Alignment.UNALIGNED, 18, 15, 16, 2, 12, 5, 13, "8d10+24", 40, 2,
                    new Attack[] { Attacks.PlesiosaurusBite }, new Attack[] {  }, Size.LARGE
                );
                plesiosaurus.AddProficiency(Proficiency.PERCEPTION);
                plesiosaurus.AddProficiency(Proficiency.STEALTH);
                plesiosaurus.AddFeat(Feat.HOLD_BREATH_1HOUR);
                return plesiosaurus;
            }
        }

         /* TODO */ 
         public static Monster PoisonousSnake {
            get {
                Monster poisonousSnake = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.POISONOUS_SNAKE, Alignment.UNALIGNED, 2, 16, 11, 1, 10, 3, 13, "1d4", 40, ChallengeRating.EIGHTH,
                    new Attack[] {  }, new Attack[] {  }, Size.TINY
                );
                return poisonousSnake;
            }
        }

         /* TODO */ 
         public static Monster PolarBear {
            get {
                Monster polarBear = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.POLAR_BEAR, Alignment.UNALIGNED, 20, 10, 16, 2, 13, 7, 12, "5d10+15", 40, 2,
                    new Attack[] { Attacks.PolarBearBite, Attacks.PolarBearClaws }, new Attack[] {  }, Size.LARGE
                );
                polarBear.AddProficiency(Proficiency.PERCEPTION);
                polarBear.AddFeat(Feat.KEEN_SMELL);
                return polarBear;
            }
        }

         /* TODO */ 
         public static Monster Pony {
            get {
                Monster pony = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.PONY, Alignment.UNALIGNED, 15, 10, 13, 2, 11, 7, 10, "2d8+2", 40, ChallengeRating.EIGHTH,
                    new Attack[] { Attacks.PonyHooves }, new Attack[] {  }, Size.MEDIUM
                );
                return pony;
            }
        }

         /* TODO */ 
         public static Monster Priest {
            get {
                Monster priest = new Monster(
                    Monsters.Type.HUMANOID, Monsters.ID.PRIEST, Alignment.UNALIGNED, 10, 10, 12, 13, 16, 13, 13, "5d8+5", 40, 2,
                    new Attack[] { Attacks.PriestMace }, new Attack[] {  }, Size.MEDIUM
                );
                priest.AddProficiency(Proficiency.MEDICINE);
                priest.AddProficiency(Proficiency.PERSUASION);
                priest.AddProficiency(Proficiency.RELIGION);
                priest.AddFeat(Feat.DIVINE_EMINENCE);
                priest.AddFeat(Feat.SPELLCASTING_PRIEST);
                return priest;
            }
        }

         /* TODO */ 
         public static Monster Pseudodragon {
            get {
                Monster pseudodragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.PSEUDODRAGON, Alignment.NEUTRAL_GOOD, 6, 15, 13, 10, 12, 10, 13, "2d4+2", 40, ChallengeRating.QUARTER,
                    new Attack[] { Attacks.PseudodragonBite, Attacks.PseudodragonSting }, new Attack[] {  }, Size.TINY
                );
                pseudodragon.AddProficiency(Proficiency.PERCEPTION);
                pseudodragon.AddProficiency(Proficiency.STEALTH);
                pseudodragon.AddFeat(Feat.KEEN_SENSES);
                pseudodragon.AddFeat(Feat.MAGIC_RESISTANCE);
                pseudodragon.AddFeat(Feat.LIMITED_TELEPATHY_PSEUDODRAGON);
                return pseudodragon;
            }
        }

         /* TODO */ 
         public static Monster PurpleWorm {
            get {
                Monster purpleWorm = new Monster(
                    Monsters.Type.MONSTROSITY, Monsters.ID.PURPLE_WORM, Alignment.UNALIGNED, 28, 7, 22, 1, 8, 4, 18, "15d20+90", 40, 15,
                    new Attack[] { Attacks.PurpleWormBite, Attacks.PurpleWormTailStinger }, new Attack[] {  }, Size.GARGANTUAN
                );
                purpleWorm.AddProficiency(Proficiency.CONSTITUTION);
                purpleWorm.AddProficiency(Proficiency.WISDOM);
                purpleWorm.AddFeat(Feat.TUNNELER);
                return purpleWorm;
            }
        }
    }
}
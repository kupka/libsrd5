namespace srd5 {
    public partial struct Attacks {
        public static readonly AttackEffect DarkmantleCrushEffect = delegate (Combattant attacker, Combattant target) {
            if (target.Size > Size.MEDIUM) return;
            if (attacker.HasEffect(Effect.ATTACHED_TO_TARGET)) return;
            attacker.AddEffect(Effect.ATTACHED_TO_TARGET);
            attacker.AddEffect(Effect.ADVANTAGE_ON_ATTACK);
            foreach (Attack attack in attacker.MeleeAttacks) {
                attack.LockedTarget = target;
            }
            target.AddCondition(ConditionType.BLINDED);
            target.AddEffect(Effect.UNABLE_TO_BREATHE);
        };
        public static readonly Attack DarkmantleCrush = new Attack("Crush", 5, new Damage(DamageType.BLUDGEONING, "1d6+3"), 5, null, DarkmantleCrushEffect);
        public static readonly AttackEffect DeathDogBiteEffect = delegate (Combattant attacker, Combattant target) {
            if (target.DC(DeathDogBite, 12, AbilityType.CONSTITUTION)) return;
            target.AddCondition(ConditionType.POISONED);
            target.AddEffect(Effect.DEATH_DOG_DISEASE);
        };
        public static readonly Attack DeathDogBite = new Attack("Bite", 4, new Damage(DamageType.PIERCING, "1d4+2"), 5, null, DeathDogBiteEffect);
        public static readonly AttackEffect DeepGnomeSvirfneblinPoisonedDartEffect = delegate (Combattant attacker, Combattant target) {
            if (target.DC(DeepGnomeSvirfneblinPoisonedDart, 12, AbilityType.CONSTITUTION)) return;
            target.AddCondition(ConditionType.POISONED);
            int turn = 0;
            target.AddEndOfTurnEvent(delegate (Combattant combattant) {
                if (turn++ > 9 || combattant.DC(DeepGnomeSvirfneblinPoisonedDart, 12, AbilityType.CONSTITUTION)) {
                    combattant.RemoveCondition(ConditionType.POISONED);
                    return true;
                }
                return false;
            });
        };
        public static readonly Attack DeepGnomeSvirfneblinPoisonedDart = new Attack("Poisoned Dart", 4, new Damage(DamageType.PIERCING, "1d6+0"), 5, null, DeepGnomeSvirfneblinPoisonedDartEffect);
        public static readonly Attack DeepGnomeSvirfneblinWarPick = new Attack("War Pick", 4, new Damage(DamageType.PIERCING, "1d8+2"), 5);
        public static readonly Attack DeerBite = new Attack("Bite", 2, new Damage(DamageType.PIERCING, "1d4"), 5);
        public static readonly Attack DevaMace = new Attack("Mace", 8, new Damage(DamageType.BLUDGEONING, "1d6+4"), 5, new Damage(DamageType.RADIANT, "4d8"));
        public static readonly AttackEffect DireWolfBiteEffect = delegate (Combattant attacker, Combattant target) {
            if (target.DC(DireWolfBite, 13, AbilityType.STRENGTH)) return;
            target.AddCondition(ConditionType.PRONE);
        };
        public static readonly Attack DireWolfBite = new Attack("Bite", 5, new Damage(DamageType.PIERCING, "2d6+3"), 5, null, DireWolfBiteEffect);
        public static readonly AttackEffect DjinniScimitarEffect = delegate (Combattant attacker, Combattant target) {
            if (Dice.D20.Value > 10) {
                target.TakeDamage(DamageType.LIGHTNING, Dice.D6.Value);
            } else {
                target.TakeDamage(DamageType.THUNDER, Dice.D6.Value);
            }
        };
        public static readonly Attack DjinniScimitar = new Attack("Scimitar", 9, new Damage(DamageType.SLASHING, "2d6+5"), 5, null, DjinniScimitarEffect);
        public static readonly Attack DoppelgangerSlam = new Attack("Slam", 6, new Damage(DamageType.BLUDGEONING, "1d6+4"), 5);
        public static readonly Attack DraftHorseHooves = new Attack("Hooves", 6, new Damage(DamageType.BLUDGEONING, "2d4+4"), 5);
        public static readonly AttackEffect DragonTurtleTailEffect = delegate (Combattant attacker, Combattant target) {
            if (target.DC(DragonTurtleTail, 20, AbilityType.STRENGTH)) return;
            target.AddCondition(ConditionType.PRONE);
            // TODO: Push 10ft away
        };
        public static readonly Attack DragonTurtleTail = new Attack("Tail", 13, new Damage(DamageType.BLUDGEONING, "3d12+7"), 5, null, DragonTurtleTailEffect);
        public static readonly Attack DragonTurtleBite = new Attack("Bite", 13, new Damage(DamageType.PIERCING, "3d12+7"), 15);
        public static readonly Attack DragonTurtleClaw = new Attack("Claw", 13, new Damage(DamageType.SLASHING, "2d8+7"), 10);
        public static readonly Attack DretchBite = new Attack("Bite", 2, new Damage(DamageType.PIERCING, "1d6"), 5);
        public static readonly Attack DretchClaws = new Attack("Claws", 2, new Damage(DamageType.SLASHING, "2d4"), 5);
        public static readonly Attack DriderLongsword = new Attack("Longsword", 6, new Damage(DamageType.SLASHING, "1d8+3"), 5);
        public static readonly Attack DriderLongbow = new Attack("Longbow", 6, new Damage(DamageType.PIERCING, "1d8+3"), 150, 600, new Damage(DamageType.POISON, "1d8"));
        public static readonly Attack DriderBite = new Attack("Bite", 6, new Damage(DamageType.PIERCING, "1d4"), 5, new Damage(DamageType.POISON, "2d8"));
        public static readonly AttackEffect DrowHandCrossbowEffect = delegate (Combattant attacker, Combattant target) {
            int value;
            if (target.IsImmune(DamageType.POISON)) return;
            if (target.DC(DrowHandCrossbow, 13, AbilityType.CONSTITUTION, out value)) return;
            target.AddEffect(Effect.DROW_POISON);
            if (value < 9) {
                target.AddCondition(ConditionType.UNCONSCIOUS);
            }
            target.AddDamageTakenEvent(delegate (Combattant combattant) {
                if (!target.HasEffect(Effect.DROW_POISON)) return true;
                target.RemoveEffect(Effect.DROW_POISON);
                target.RemoveCondition(ConditionType.UNCONSCIOUS);
                return true;
            });
        };
        public static readonly Attack DrowHandCrossbow = new Attack("Hand Crossbow", 4, new Damage(DamageType.PIERCING, "1d6+2"), 30, 120, null, DrowHandCrossbowEffect);
        public static readonly Attack DrowShortsword = new Attack("Shortsword", 4, new Damage(DamageType.PIERCING, "1d6+2"), 5);
        public static readonly Attack DruidQuarterstaff = new Attack("Quarterstaff", 2, new Damage(DamageType.BLUDGEONING, "1d6"), 5);
        public static readonly Attack DryadClub = new Attack("Club", 2, new Damage(DamageType.BLUDGEONING, "1d4"), 5);
        public static readonly Attack DuergarWarPick = new Attack("War Pick", 4, new Damage(DamageType.PIERCING, "1d8+2"), 5);
        public static readonly Attack DuergarJavelin = new Attack("Javelin", 4, new Damage(DamageType.PIERCING, "1d6+2"), 5);
        public static readonly Attack DuergarJavelinRanged = new Attack("Javelin", 4, new Damage(DamageType.PIERCING, "1d6+2"), 30, 120);
        public static readonly Attack DustMephitClaws = new Attack("Claws", 4, new Damage(DamageType.SLASHING, "1d4+2"), 5);
    }

    public partial struct Monsters {
        /* TODO */
        public static Monster Darkmantle {
            get {
                Monster darkmantle = new Monster(
                    Monsters.Type.MONSTROSITY, Monsters.ID.DARKMANTLE, Alignment.UNALIGNED, 16, 12, 13, 2, 10, 5, 11, "5d6+5", 40, ChallengeRating.HALF,
                    new Attack[] { Attacks.DarkmantleCrush }, new Attack[] { }, Size.SMALL
                );
                darkmantle.AddProficiency(Proficiency.STEALTH);
                darkmantle.AddFeat(Feat.ECHOLOCATION);
                darkmantle.AddFeat(Feat.FALSE_APPEARANCE);
                return darkmantle;
            }
        }

        /* TODO */
        public static Monster DeathDog {
            get {
                Monster deathDog = new Monster(
                    Monsters.Type.MONSTROSITY, Monsters.ID.DEATH_DOG, Alignment.NEUTRAL_EVIL, 15, 14, 14, 3, 13, 6, 12, "6d8+12", 40, 1,
                    new Attack[] { Attacks.DeathDogBite }, new Attack[] { }, Size.MEDIUM
                );
                deathDog.AddProficiency(Proficiency.PERCEPTION);
                deathDog.AddProficiency(Proficiency.STEALTH);
                deathDog.AddFeat(Feat.TWO_HEADED);
                return deathDog;
            }
        }

        /* TODO */
        public static Monster DeepGnomeSvirfneblin {
            get {
                Monster deepGnomeSvirfneblin = new Monster(
                    Monsters.Type.HUMANOID, Monsters.ID.DEEP_GNOME__SVIRFNEBLIN, Alignment.NEUTRAL_GOOD, 15, 14, 14, 12, 10, 9, 15, "3d6+6", 40, ChallengeRating.HALF,
                    new Attack[] { Attacks.DeepGnomeSvirfneblinWarPick
    }, new Attack[] { }, Size.SMALL
                );
                deepGnomeSvirfneblin.AddProficiency(Proficiency.INVESTIGATION);
                deepGnomeSvirfneblin.AddProficiency(Proficiency.PERCEPTION);
                deepGnomeSvirfneblin.AddProficiency(Proficiency.STEALTH);
                deepGnomeSvirfneblin.AddFeat(Feat.STONE_CAMOUFLAGE);
                deepGnomeSvirfneblin.AddFeat(Feat.GNOME_CUNNING);
                deepGnomeSvirfneblin.AddFeat(Feat.INNATE_SPELLCASTING_DEEP_GNOME);
                return deepGnomeSvirfneblin;
            }
        }

        /* TODO */
        public static Monster Deer {
            get {
                Monster deer = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.DEER, Alignment.UNALIGNED, 11, 16, 11, 2, 14, 5, 13, "1d8", 40, 0,
                    new Attack[] { Attacks.DeerBite }, new Attack[] { }, Size.MEDIUM
                );
                return deer;
            }
        }

        /* TODO */
        public static Monster Deva {
            get {
                Monster deva = new Monster(
                    Monsters.Type.CELESTIAL, Monsters.ID.DEVA, Alignment.LAWFUL_GOOD, 18, 18, 18, 17, 20, 20, 17, "16d8+64", 40, 10,
                    new Attack[] { Attacks.DevaMace }, new Attack[] { }, Size.MEDIUM
                );
                deva.AddProficiency(Proficiency.WISDOM);
                deva.AddProficiency(Proficiency.CHARISMA);
                deva.AddProficiency(Proficiency.INSIGHT);
                deva.AddProficiency(Proficiency.PERCEPTION);
                deva.AddEffect(Effect.RESISTANCE_RADIANT);
                deva.AddEffect(Effect.RESISTANCE_NONMAGIC);
                deva.AddEffect(Effect.IMMUNITY_CHARMED);
                deva.AddEffect(Effect.IMMUNITY_EXHAUSTION);
                deva.AddEffect(Effect.IMMUNITY_FRIGHTENED);
                deva.AddFeat(Feat.ANGELIC_WEAPONS_4D8);
                deva.AddFeat(Feat.INNATE_SPELLCASTING_DEVA);
                deva.AddFeat(Feat.MAGIC_RESISTANCE);
                return deva;
            }
        }

        /* TODO */
        public static Monster DireWolf {
            get {
                Monster direWolf = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.DIRE_WOLF, Alignment.UNALIGNED, 17, 15, 15, 3, 12, 7, 14, "5d10+10", 40, 1,
                    new Attack[] { Attacks.DireWolfBite }, new Attack[] { }, Size.LARGE
                );
                direWolf.AddProficiency(Proficiency.PERCEPTION);
                direWolf.AddProficiency(Proficiency.STEALTH);
                direWolf.AddFeat(Feat.KEEN_HEARING_AND_SMELL);
                direWolf.AddFeat(Feat.PACK_TACTICS);
                return direWolf;
            }
        }

        /* TODO */
        public static Monster Djinni {
            get {
                Monster djinni = new Monster(
                    Monsters.Type.ELEMENTAL, Monsters.ID.DJINNI, Alignment.CHAOTIC_GOOD, 21, 15, 22, 15, 16, 20, 17, "14d10+84", 40, 11,
                    new Attack[] { Attacks.DjinniScimitar }, new Attack[] { }, Size.LARGE
                );
                djinni.AddProficiency(Proficiency.DEXTERITY);
                djinni.AddProficiency(Proficiency.WISDOM);
                djinni.AddProficiency(Proficiency.CHARISMA);
                djinni.AddEffect(Effect.IMMUNITY_LIGHTNING);
                djinni.AddEffect(Effect.IMMUNITY_THUNDER);
                djinni.AddFeat(Feat.ELEMENTAL_DEMISE_DJINNI);
                djinni.AddFeat(Feat.INNATE_SPELLCASTING_DJINNI);
                return djinni;
            }
        }

        /* TODO */
        public static Monster Doppelganger {
            get {
                Monster doppelganger = new Monster(
                    Monsters.Type.MONSTROSITY, Monsters.ID.DOPPELGANGER, Alignment.UNALIGNED, 11, 18, 14, 11, 12, 14, 14, "8d8+16", 40, 3,
                    new Attack[] { Attacks.DoppelgangerSlam }, new Attack[] { }, Size.MEDIUM
                );
                doppelganger.AddProficiency(Proficiency.DECEPTION);
                doppelganger.AddProficiency(Proficiency.INSIGHT);
                doppelganger.AddEffect(Effect.IMMUNITY_CHARMED);
                doppelganger.AddFeat(Feat.SHAPECHANGER_DOPPELGANGER);
                doppelganger.AddFeat(Feat.AMBUSHER);
                doppelganger.AddFeat(Feat.SURPRISE_ATTACK_DOPPELGANGER);
                return doppelganger;
            }
        }

        /* TODO */
        public static Monster DraftHorse {
            get {
                Monster draftHorse = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.DRAFT_HORSE, Alignment.UNALIGNED, 18, 10, 12, 2, 11, 7, 10, "3d10+3", 40, ChallengeRating.QUARTER,
                    new Attack[] { Attacks.DraftHorseHooves }, new Attack[] { }, Size.LARGE
                );
                return draftHorse;
            }
        }

        /* TODO */
        public static Monster DragonTurtle {
            get {
                Monster dragonTurtle = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.DRAGON_TURTLE, Alignment.NEUTRAL, 25, 10, 20, 10, 12, 12, 20, "22d20+110", 40, 17,
                    new Attack[] { Attacks.DragonTurtleBite, Attacks.DragonTurtleClaw, Attacks.DragonTurtleTail }, new Attack[] { }, Size.GARGANTUAN
                );
                dragonTurtle.AddProficiency(Proficiency.DEXTERITY);
                dragonTurtle.AddProficiency(Proficiency.CONSTITUTION);
                dragonTurtle.AddProficiency(Proficiency.WISDOM);
                dragonTurtle.AddEffect(Effect.RESISTANCE_FIRE);
                dragonTurtle.AddFeat(Feat.AMPHIBIOUS);
                return dragonTurtle;
            }
        }

        /* TODO */
        public static Monster Dretch {
            get {
                Monster dretch = new Monster(
                    Monsters.Type.FIEND, Monsters.ID.DRETCH, Alignment.CHAOTIC_EVIL, 11, 11, 12, 5, 8, 3, 11, "4d6+4", 40, ChallengeRating.QUARTER,
                    new Attack[] { Attacks.DretchBite, Attacks.DretchClaws }, new Attack[] { }, Size.SMALL
                );
                dretch.AddEffect(Effect.RESISTANCE_COLD);
                dretch.AddEffect(Effect.RESISTANCE_FIRE);
                dretch.AddEffect(Effect.RESISTANCE_LIGHTNING);
                dretch.AddEffect(Effect.IMMUNITY_POISON);
                dretch.AddEffect(Effect.IMMUNITY_POISONED);
                return dretch;
            }
        }

        /* TODO */
        public static Monster Drider {
            get {
                Monster drider = new Monster(
                    Monsters.Type.MONSTROSITY, Monsters.ID.DRIDER, Alignment.CHAOTIC_EVIL, 16, 16, 18, 13, 14, 12, 19, "13d10+52", 40, 6,
                    new Attack[] { Attacks.DriderBite, Attacks.DriderLongsword }, new Attack[] { }, Size.LARGE
                );
                drider.AddProficiency(Proficiency.PERCEPTION);
                drider.AddProficiency(Proficiency.STEALTH);
                drider.AddFeat(Feat.FEY_ANCESTRY);
                drider.AddFeat(Feat.INNATE_SPELLCASTING_DRIDER);
                drider.AddFeat(Feat.SPIDER_CLIMB);
                drider.AddFeat(Feat.SUNLIGHT_SENSITIVITY);
                drider.AddFeat(Feat.WEB_WALKER);
                return drider;
            }
        }

        /* TODO */
        public static Monster Drow {
            get {
                Monster drow = new Monster(
                    Monsters.Type.HUMANOID, Monsters.ID.DROW, Alignment.NEUTRAL_EVIL, 10, 14, 10, 11, 11, 12, 15, "3d8", 40, ChallengeRating.QUARTER,
                    new Attack[] { Attacks.DrowShortsword }, new Attack[] { }, Size.MEDIUM
                );
                drow.AddProficiency(Proficiency.PERCEPTION);
                drow.AddProficiency(Proficiency.STEALTH);
                drow.AddFeat(Feat.FEY_ANCESTRY);
                drow.AddFeat(Feat.INNATE_SPELLCASTING_DROW);
                drow.AddFeat(Feat.SUNLIGHT_SENSITIVITY);
                return drow;
            }
        }

        /* TODO */
        public static Monster Druid {
            get {
                Monster druid = new Monster(
                    Monsters.Type.HUMANOID, Monsters.ID.DRUID, Alignment.UNALIGNED, 10, 12, 13, 12, 15, 11, 11, "5d8+5", 40, 2,
                    new Attack[] { }, new Attack[] { }, Size.MEDIUM
                );
                druid.AddProficiency(Proficiency.MEDICINE);
                druid.AddProficiency(Proficiency.NATURE);
                druid.AddProficiency(Proficiency.PERCEPTION);
                druid.AddFeat(Feat.SPELLCASTING_DRUID);
                return druid;
            }
        }

        /* TODO */
        public static Monster Dryad {
            get {
                Monster dryad = new Monster(
                    Monsters.Type.FEY, Monsters.ID.DRYAD, Alignment.NEUTRAL, 10, 12, 11, 14, 15, 18, 11, "5d8", 40, 1,
                    new Attack[] { }, new Attack[] { }, Size.MEDIUM
                );
                dryad.AddProficiency(Proficiency.PERCEPTION);
                dryad.AddProficiency(Proficiency.STEALTH);
                dryad.AddFeat(Feat.INNATE_SPELLCASTING_DRYAD);
                dryad.AddFeat(Feat.MAGIC_RESISTANCE);
                dryad.AddFeat(Feat.SPEAK_WITH_BEASTS_AND_PLANTS);
                dryad.AddFeat(Feat.TREE_STRIDE);
                return dryad;
            }
        }

        /* TODO */
        public static Monster Duergar {
            get {
                Monster duergar = new Monster(
                    Monsters.Type.HUMANOID, Monsters.ID.DUERGAR, Alignment.LAWFUL_EVIL, 14, 11, 14, 11, 10, 9, 16, "4d8+8", 40, 1,
                    new Attack[] { Attacks.DuergarWarPick, Attacks.DuergarJavelin }, new Attack[] { Attacks.DuergarJavelinRanged }, Size.MEDIUM
                );
                duergar.AddEffect(Effect.RESISTANCE_POISON);
                duergar.AddFeat(Feat.DUERGAR_RESILIENCE);
                duergar.AddFeat(Feat.SUNLIGHT_SENSITIVITY);
                return duergar;
            }
        }

        /* TODO */
        public static Monster DustMephit {
            get {
                Monster dustMephit = new Monster(
                    Monsters.Type.ELEMENTAL, Monsters.ID.DUST_MEPHIT, Alignment.NEUTRAL_EVIL, 5, 14, 10, 9, 11, 10, 12, "5d6", 40, ChallengeRating.HALF,
                    new Attack[] { Attacks.DustMephitClaws }, new Attack[] { }, Size.SMALL
                );
                dustMephit.AddProficiency(Proficiency.PERCEPTION);
                dustMephit.AddProficiency(Proficiency.STEALTH);
                dustMephit.AddEffect(Effect.VULNERABILITY_FIRE);
                dustMephit.AddEffect(Effect.IMMUNITY_POISON);
                dustMephit.AddEffect(Effect.IMMUNITY_POISONED);
                dustMephit.AddFeat(Feat.DEATH_BURST_DUST_MEPHIT);
                dustMephit.AddFeat(Feat.INNATE_SPELLCASTING_DUST_MEPHIT);
                return dustMephit;
            }
        }
    }
}
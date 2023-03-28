namespace srd5 {
    public partial struct Attacks {
        public static readonly Attack[] None = new Attack[0];
        public static AttackEffect AbolethTentacleEffect = delegate (Combattant attacker, Combattant target) {
            if (target.DC(AbolethTentacle, 14, AbilityType.CONSTITUTION)) return;
            target.AddEffect(Effect.ABOLETH_DISEASE_TENTACLE);
        };
        public static readonly Attack AbolethTentacle = new Attack("Tentacle", 9, new Damage(DamageType.BLUDGEONING, "2d6+5"), 10, null, AbolethTentacleEffect);
        public static readonly Attack AbolethTail = new Attack("Tail", 9, new Damage(DamageType.BLUDGEONING, "3d6+5"), 10);
        public static readonly Attack AcolyteClub = new Attack("Club", 2, new Damage(DamageType.BLUDGEONING, "1d4"), 5);
        public static readonly Attack AdultBlackDragonBite = new Attack("Bite", 11, new Damage(DamageType.PIERCING, "2d10+6"), 10, new Damage(DamageType.ACID, "1d8"));
        public static readonly Attack AdultBlackDragonClaw = new Attack("Claw", 11, new Damage(DamageType.SLASHING, "2d6+6"), 5);
        public static readonly Attack AdultBlackDragonTail = new Attack("Tail", 11, new Damage(DamageType.BLUDGEONING, "2d8+6"), 15);
        public static readonly Attack AdultBlueDragonBite = new Attack("Bite", 12, new Damage(DamageType.PIERCING, "2d10+7"), 10, new Damage(DamageType.LIGHTNING, "1d10"));
        public static readonly Attack AdultBlueDragonClaw = new Attack("Claw", 12, new Damage(DamageType.SLASHING, "2d6+7"), 5);
        public static readonly Attack AdultBlueDragonTail = new Attack("Tail", 12, new Damage(DamageType.BLUDGEONING, "2d8+7"), 15);
        public static readonly Attack AdultBrassDragonBite = new Attack("Bite", 11, new Damage(DamageType.PIERCING, "2d10+6"), 10);
        public static readonly Attack AdultBrassDragonClaw = new Attack("Claw", 11, new Damage(DamageType.SLASHING, "2d6+6"), 5);
        public static readonly Attack AdultBrassDragonTail = new Attack("Tail", 11, new Damage(DamageType.BLUDGEONING, "2d8+6"), 15);
        public static readonly Attack AdultBronzeDragonBite = new Attack("Bite", 12, new Damage(DamageType.PIERCING, "2d10+7"), 10);
        public static readonly Attack AdultBronzeDragonClaw = new Attack("Claw", 12, new Damage(DamageType.SLASHING, "2d6+7"), 5);
        public static readonly Attack AdultBronzeDragonTail = new Attack("Tail", 12, new Damage(DamageType.BLUDGEONING, "2d8+7"), 15);
        public static readonly Attack AdultCopperDragonBite = new Attack("Bite", 11, new Damage(DamageType.PIERCING, "2d10+6"), 10);
        public static readonly Attack AdultCopperDragonClaw = new Attack("Claw", 11, new Damage(DamageType.SLASHING, "2d6+6"), 5);
        public static readonly Attack AdultCopperDragonTail = new Attack("Tail", 11, new Damage(DamageType.BLUDGEONING, "2d8+6"), 15);
        public static readonly Attack AdultGoldDragonBite = new Attack("Bite", 14, new Damage(DamageType.PIERCING, "2d10+8"), 10);
        public static readonly Attack AdultGoldDragonClaw = new Attack("Claw", 14, new Damage(DamageType.SLASHING, "2d6+8"), 5);
        public static readonly Attack AdultGoldDragonTail = new Attack("Tail", 14, new Damage(DamageType.BLUDGEONING, "2d8+8"), 15);
        public static readonly Attack AdultGreenDragonBite = new Attack("Bite", 11, new Damage(DamageType.PIERCING, "2d10+6"), 10, new Damage(DamageType.POISON, "2d6"));
        public static readonly Attack AdultGreenDragonClaw = new Attack("Claw", 11, new Damage(DamageType.SLASHING, "2d6+6"), 5);
        public static readonly Attack AdultGreenDragonTail = new Attack("Tail", 11, new Damage(DamageType.BLUDGEONING, "2d8+6"), 15);
        public static readonly Attack AdultRedDragonBite = new Attack("Bite", 14, new Damage(DamageType.PIERCING, "2d10+8"), 10, new Damage(DamageType.FIRE, "2d6"));
        public static readonly Attack AdultRedDragonClaw = new Attack("Claw", 14, new Damage(DamageType.SLASHING, "2d6+8"), 5);
        public static readonly Attack AdultRedDragonTail = new Attack("Tail", 14, new Damage(DamageType.BLUDGEONING, "2d8+8"), 15);
        public static readonly Attack AdultSilverDragonBite = new Attack("Bite", 13, new Damage(DamageType.PIERCING, "2d10+8"), 10);
        public static readonly Attack AdultSilverDragonClaw = new Attack("Claw", 13, new Damage(DamageType.SLASHING, "2d6+8"), 5);
        public static readonly Attack AdultSilverDragonTail = new Attack("Tail", 13, new Damage(DamageType.BLUDGEONING, "2d8+8"), 15);
        public static readonly Attack AdultWhiteDragonBite = new Attack("Bite", 11, new Damage(DamageType.PIERCING, "2d10+6"), 10, new Damage(DamageType.COLD, "1d8"));
        public static readonly Attack AdultWhiteDragonClaw = new Attack("Claw", 11, new Damage(DamageType.SLASHING, "2d6+6"), 5);
        public static readonly Attack AdultWhiteDragonTail = new Attack("Tail", 11, new Damage(DamageType.BLUDGEONING, "2d8+6"), 15);
        public static readonly Attack AirElementalSlam = new Attack("Slam", 8, new Damage(DamageType.BLUDGEONING, "2d8+5"), 5);
        public static readonly Attack AncientBlackDragonBite = new Attack("Bite", 15, new Damage(DamageType.PIERCING, "2d10+8"), 15, new Damage(DamageType.ACID, "2d8"));
        public static readonly Attack AncientBlackDragonClaw = new Attack("Claw", 15, new Damage(DamageType.SLASHING, "2d6+8"), 10);
        public static readonly Attack AncientBlackDragonTail = new Attack("Tail", 15, new Damage(DamageType.BLUDGEONING, "2d8+8"), 20);
        public static readonly Attack AncientBlueDragonBite = new Attack("Bite", 16, new Damage(DamageType.PIERCING, "2d10+9"), 15, new Damage(DamageType.LIGHTNING, "2d10"));
        public static readonly Attack AncientBlueDragonClaw = new Attack("Claw", 16, new Damage(DamageType.SLASHING, "2d6+9"), 10);
        public static readonly Attack AncientBlueDragonTail = new Attack("Tail", 16, new Damage(DamageType.BLUDGEONING, "2d8+9"), 20);
        public static readonly Attack AncientBrassDragonBite = new Attack("Bite", 14, new Damage(DamageType.PIERCING, "2d10+8"), 15);
        public static readonly Attack AncientBrassDragonClaw = new Attack("Claw", 14, new Damage(DamageType.SLASHING, "2d6+8"), 10);
        public static readonly Attack AncientBrassDragonTail = new Attack("Tail", 14, new Damage(DamageType.BLUDGEONING, "2d8+8"), 20);
        public static readonly Attack AncientBronzeDragonBite = new Attack("Bite", 16, new Damage(DamageType.PIERCING, "2d10+9"), 15);
        public static readonly Attack AncientBronzeDragonClaw = new Attack("Claw", 16, new Damage(DamageType.SLASHING, "2d6+9"), 10);
        public static readonly Attack AncientBronzeDragonTail = new Attack("Tail", 16, new Damage(DamageType.BLUDGEONING, "2d8+9"), 20);
        public static readonly Attack AncientCopperDragonBite = new Attack("Bite", 15, new Damage(DamageType.PIERCING, "2d10+8"), 15);
        public static readonly Attack AncientCopperDragonClaw = new Attack("Claw", 15, new Damage(DamageType.SLASHING, "2d6+8"), 10);
        public static readonly Attack AncientCopperDragonTail = new Attack("Tail", 15, new Damage(DamageType.BLUDGEONING, "2d8+8"), 20);
        public static readonly Attack AncientGoldDragonBite = new Attack("Bite", 17, new Damage(DamageType.PIERCING, "2d10+10"), 15);
        public static readonly Attack AncientGoldDragonClaw = new Attack("Claw", 17, new Damage(DamageType.SLASHING, "2d6+10"), 10);
        public static readonly Attack AncientGoldDragonTail = new Attack("Tail", 17, new Damage(DamageType.BLUDGEONING, "2d8+10"), 20);
        public static readonly Attack AncientGreenDragonBite = new Attack("Bite", 15, new Damage(DamageType.PIERCING, "2d10+8"), 15, new Damage(DamageType.POISON, "3d6"));
        public static readonly Attack AncientGreenDragonClaw = new Attack("Claw", 15, new Damage(DamageType.SLASHING, "4d6+8"), 10);
        public static readonly Attack AncientGreenDragonTail = new Attack("Tail", 15, new Damage(DamageType.BLUDGEONING, "2d8+8"), 20);
        public static readonly Attack AncientRedDragonBite = new Attack("Bite", 17, new Damage(DamageType.PIERCING, "2d10+10"), 15, new Damage(DamageType.FIRE, "4d6"));
        public static readonly Attack AncientRedDragonClaw = new Attack("Claw", 17, new Damage(DamageType.SLASHING, "2d6+10"), 10);
        public static readonly Attack AncientRedDragonTail = new Attack("Tail", 17, new Damage(DamageType.BLUDGEONING, "2d8+10"), 20);
        public static readonly Attack AncientSilverDragonBite = new Attack("Bite", 17, new Damage(DamageType.PIERCING, "2d10+10"), 15);
        public static readonly Attack AncientSilverDragonClaw = new Attack("Claw", 17, new Damage(DamageType.SLASHING, "2d6+10"), 10);
        public static readonly Attack AncientSilverDragonTail = new Attack("Tail", 17, new Damage(DamageType.BLUDGEONING, "2d8+10"), 20);
        public static readonly Attack AncientWhiteDragonBite = new Attack("Bite", 14, new Damage(DamageType.PIERCING, "2d10+8"), 15, new Damage(DamageType.COLD, "2d8"));
        public static readonly Attack AncientWhiteDragonClaw = new Attack("Claw", 14, new Damage(DamageType.SLASHING, "2d6+8"), 10);
        public static readonly Attack AncientWhiteDragonTail = new Attack("Tail", 14, new Damage(DamageType.BLUDGEONING, "2d8+8"), 20);
        public static readonly Attack AndrosphinxClaw = new Attack("Claw", 12, new Damage(DamageType.SLASHING, "2d10+6"), 5);
        public static readonly Attack AnimatedArmorSlam = new Attack("Slam", 4, new Damage(DamageType.BLUDGEONING, "1d6+2"), 5);
        public static AttackEffect AnkhegBiteEffect = delegate (Combattant attacker, Combattant target) {
            target.AddCondition(ConditionType.GRAPPLED_DC13);
        };
        public static readonly Attack AnkhegBite = new Attack("Bite", 5, new Damage(DamageType.SLASHING, "2d6+3"), 5, new Damage(DamageType.ACID, "1d6"), AnkhegBiteEffect);
        public static readonly Attack ApeFist = new Attack("Fist", 5, new Damage(DamageType.BLUDGEONING, "1d6+3"), 5);
        public static readonly Attack ApeRock = new Attack("Rock", 5, new Damage(DamageType.BLUDGEONING, "1d6+3"), 5, 25, 50);
        public static readonly Attack ArchmageDaggerMelee = new Attack("Dagger", 6, new Damage(DamageType.PIERCING, "1d4+2"), 5);
        public static readonly Attack ArchmageDaggerRanged = new Attack("Dagger", 6, new Damage(DamageType.PIERCING, "1d4+2"), 5, 20, 60);
        public static AttackEffect AssassinShortswordEffect = delegate (Combattant attacker, Combattant target) {
            int amount = new Dices("7d6").Roll();
            if (target.DC(AssassinShortsword, 15, AbilityType.CONSTITUTION)) amount /= 2;
            target.TakeDamage(DamageType.POISON, amount);
        };
        public static readonly Attack AssassinShortsword = new Attack("Shortsword", 6, new Damage(DamageType.PIERCING, "1d6+3"), 5, null, AssassinShortswordEffect);
        public static readonly Attack AssassinLight_Crossbow = new Attack("Light Crossbow", 6, new Damage(DamageType.PIERCING, "1d8+3"), 5, 80, 320);
        public static readonly Attack AwakenedShrubRake = new Attack("Rake", 1, new Damage(DamageType.SLASHING, "1d4-1"), 5);
        public static readonly Attack AwakenedTreeSlam = new Attack("Slam", 6, new Damage(DamageType.BLUDGEONING, "3d6+4"), 10);
        public static readonly Attack AxeBeakBeak = new Attack("Beak", 4, new Damage(DamageType.SLASHING, "1d8+2"), 5);
        public static readonly Attack AzerWarhammer = new Attack("Warhammer", 5, new Damage(DamageType.BLUDGEONING, "1d8+3"), 5, new Damage(DamageType.FIRE, "1d6"));
        public static readonly Attack ClayGolemSlam = new Attack("Slam", 8, new Damage(DamageType.BLUDGEONING, "2d10+5"), 5);
        public static readonly Attack GiantBadgerBite = new Attack("Bite", 3, new Damage(DamageType.PIERCING, "1d6+1"), 5);
        public static readonly Attack GiantBadgerClaws = new Attack("Claws", 3, new Damage(DamageType.SLASHING, "2d4+1"), 5);
        public static readonly Attack GiantScorpionClaw = new Attack("Claw", 4, new Damage(DamageType.BLUDGEONING, "1d8+2"), 5);
        public static AttackEffect GiantScorpionStingEffect = delegate (Combattant attacker, Combattant target) {
            int amount = new Dices("4d10").Roll();
            if (target.DC(GiantScorpionSting, 12, AbilityType.CONSTITUTION)) amount /= 2;
            target.TakeDamage(DamageType.POISON, amount);
        };
        public static readonly Attack GiantScorpionSting = new Attack("Sting", 4, new Damage(DamageType.PIERCING, "1d10+2"), 5, null, GiantScorpionStingEffect);
        public static readonly Attack GoblinScimitar = new Attack("Scimitar", 4, new Damage(DamageType.SLASHING, "1d6+2"), 5);
        public static readonly Attack GoblinShortbow = new Attack("Shortbow", 4, new Damage(DamageType.PIERCING, "1d6+2"), 80, 320);
        public static readonly Attack NightHagClaws = new Attack("Claws", 7, new Damage(DamageType.SLASHING, "2d8+4"), 5);
        public static readonly Attack OgreGreatclub = new Attack("Greatclub", 6, new Damage(DamageType.BLUDGEONING, "2d8+4"), 5);
        public static readonly Attack OgreJavelin = new Attack("Javelin", 6, new Damage(DamageType.PIERCING, "2d6+4"), 30, 120);
        public static readonly Attack OrcGreataxe = new Attack("Greataxe", 5, new Damage(DamageType.SLASHING, "1d12+3"), 5);
        public static readonly Attack OrcJavelin = new Attack("Javelin", 5, new Damage(DamageType.PIERCING, "1d6+3"), 30, 120);
        public static readonly Attack ShadowStrengthDrain = new Attack("Strength Drain", 4, new Damage(DamageType.NECROTIC, "2d6+2"), 5);
        public static readonly Attack TarrasqueBite = new Attack("Bite", 19, new Damage(DamageType.PIERCING, "4d12+10"), 10);
        public static readonly Attack TarrasqueClaw = new Attack("Claw", 19, new Damage(DamageType.SLASHING, "4d8+10"), 15);
        public static readonly Attack TarrasqueHorns = new Attack("Horns", 19, new Damage(DamageType.PIERCING, "4d10+10"), 10);
        public static readonly Attack TarrasqueTail = new Attack("Tail", 19, new Damage(DamageType.BLUDGEONING, "4d6+10"), 20);
    }

    public partial struct Monsters {

        /* TODO */
        public static Monster Aboleth {
            get {
                Monster aboleth = new Monster(
                    Monsters.Type.ABERRATION, Monsters.ID.ABOLETH, Alignment.LAWFUL_EVIL, 21, 9, 15, 18, 15, 18, 17, "18d10+36", 40, 10,
                    new Attack[] { Attacks.AbolethTentacle, Attacks.AbolethTail }, new Attack[] { }, Size.LARGE
                );
                aboleth.AddProficiency(Proficiency.CONSTITUTION);
                aboleth.AddProficiency(Proficiency.INTELLIGENCE);
                aboleth.AddProficiency(Proficiency.WISDOM);
                aboleth.AddProficiency(Proficiency.HISTORY);
                aboleth.AddProficiency(Proficiency.PERCEPTION);
                aboleth.AddFeat(Feat.AMPHIBIOUS);
                aboleth.AddFeat(Feat.MUCOUS_CLOUD);
                aboleth.AddFeat(Feat.PROBING_TELEPATHY);
                return aboleth;
            }
        }

        /* TODO */
        public static Monster Acolyte {
            get {
                Monster acolyte = new Monster(
                    Monsters.Type.HUMANOID, Monsters.ID.ACOLYTE, Alignment.UNALIGNED, 10, 10, 10, 10, 14, 11, 10, "2d8", 40, ChallengeRating.QUARTER,
                    new Attack[] { Attacks.AcolyteClub }, new Attack[] { }, Size.MEDIUM
                );
                acolyte.AddProficiency(Proficiency.MEDICINE);
                acolyte.AddProficiency(Proficiency.RELIGION);
                acolyte.AddFeat(Feat.SPELLCASTING_ACOLYTE);
                return acolyte;
            }
        }

        /* TODO */
        public static Monster AdultBlackDragon {
            get {
                Monster adultBlackDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.ADULT_BLACK_DRAGON, Alignment.CHAOTIC_EVIL, 23, 14, 21, 14, 13, 17, 19, "17d12+85", 40, 14,
                    new Attack[] { Attacks.AdultBlackDragonBite, Attacks.AdultBlackDragonClaw, Attacks.AdultBlackDragonTail }, new Attack[] { }, Size.HUGE
                );
                adultBlackDragon.AddProficiency(Proficiency.DEXTERITY);
                adultBlackDragon.AddProficiency(Proficiency.CONSTITUTION);
                adultBlackDragon.AddProficiency(Proficiency.WISDOM);
                adultBlackDragon.AddProficiency(Proficiency.CHARISMA);
                adultBlackDragon.AddProficiency(Proficiency.PERCEPTION);
                adultBlackDragon.AddProficiency(Proficiency.STEALTH);
                adultBlackDragon.AddEffect(Effect.IMMUNITY_ACID);
                adultBlackDragon.AddFeat(Feat.AMPHIBIOUS);
                adultBlackDragon.AddFeat(Feat.LEGENDARY_RESISTANCE);
                return adultBlackDragon;
            }
        }

        /* TODO */
        public static Monster AdultBlueDragon {
            get {
                Monster adultBlueDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.ADULT_BLUE_DRAGON, Alignment.LAWFUL_EVIL, 25, 10, 23, 16, 15, 19, 19, "18d12+108", 40, 16,
                    new Attack[] { Attacks.AdultBlueDragonBite, Attacks.AdultBlueDragonClaw, Attacks.AdultBlueDragonTail }, new Attack[] { }, Size.HUGE
                );
                adultBlueDragon.AddProficiency(Proficiency.DEXTERITY);
                adultBlueDragon.AddProficiency(Proficiency.CONSTITUTION);
                adultBlueDragon.AddProficiency(Proficiency.WISDOM);
                adultBlueDragon.AddProficiency(Proficiency.CHARISMA);
                adultBlueDragon.AddProficiency(Proficiency.PERCEPTION);
                adultBlueDragon.AddProficiency(Proficiency.STEALTH);
                adultBlueDragon.AddEffect(Effect.IMMUNITY_LIGHTNING);
                adultBlueDragon.AddFeat(Feat.LEGENDARY_RESISTANCE);
                return adultBlueDragon;
            }
        }

        /* TODO */
        public static Monster AdultBrassDragon {
            get {
                Monster adultBrassDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.ADULT_BRASS_DRAGON, Alignment.CHAOTIC_GOOD, 23, 10, 21, 14, 13, 17, 18, "15d12+75", 40, 13,
                    new Attack[] { Attacks.AdultBrassDragonBite, Attacks.AdultBrassDragonClaw, Attacks.AdultBrassDragonTail }, new Attack[] { }, Size.HUGE
                );
                adultBrassDragon.AddProficiency(Proficiency.DEXTERITY);
                adultBrassDragon.AddProficiency(Proficiency.CONSTITUTION);
                adultBrassDragon.AddProficiency(Proficiency.WISDOM);
                adultBrassDragon.AddProficiency(Proficiency.CHARISMA);
                adultBrassDragon.AddProficiency(Proficiency.HISTORY);
                adultBrassDragon.AddProficiency(Proficiency.PERCEPTION);
                adultBrassDragon.AddProficiency(Proficiency.PERSUASION);
                adultBrassDragon.AddProficiency(Proficiency.STEALTH);
                adultBrassDragon.AddEffect(Effect.IMMUNITY_FIRE);
                adultBrassDragon.AddFeat(Feat.LEGENDARY_RESISTANCE);
                return adultBrassDragon;
            }
        }

        /* TODO */
        public static Monster AdultBronzeDragon {
            get {
                Monster adultBronzeDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.ADULT_BRONZE_DRAGON, Alignment.LAWFUL_GOOD, 25, 10, 23, 16, 15, 19, 19, "17d12+102", 40, 15,
                    new Attack[] { Attacks.AdultBronzeDragonBite, Attacks.AdultBronzeDragonClaw, Attacks.AdultBronzeDragonTail }, new Attack[] { }, Size.HUGE
                );
                adultBronzeDragon.AddProficiency(Proficiency.DEXTERITY);
                adultBronzeDragon.AddProficiency(Proficiency.CONSTITUTION);
                adultBronzeDragon.AddProficiency(Proficiency.WISDOM);
                adultBronzeDragon.AddProficiency(Proficiency.CHARISMA);
                adultBronzeDragon.AddProficiency(Proficiency.INSIGHT);
                adultBronzeDragon.AddProficiency(Proficiency.PERCEPTION);
                adultBronzeDragon.AddProficiency(Proficiency.STEALTH);
                adultBronzeDragon.AddEffect(Effect.IMMUNITY_LIGHTNING);
                adultBronzeDragon.AddFeat(Feat.AMPHIBIOUS);
                adultBronzeDragon.AddFeat(Feat.LEGENDARY_RESISTANCE);
                return adultBronzeDragon;
            }
        }

        /* TODO */
        public static Monster AdultCopperDragon {
            get {
                Monster adultCopperDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.ADULT_COPPER_DRAGON, Alignment.CHAOTIC_GOOD, 23, 12, 21, 18, 15, 17, 18, "16d12+80", 40, 14,
                    new Attack[] { Attacks.AdultCopperDragonBite, Attacks.AdultCopperDragonClaw, Attacks.AdultCopperDragonTail }, new Attack[] { }, Size.HUGE
                );
                adultCopperDragon.AddProficiency(Proficiency.DEXTERITY);
                adultCopperDragon.AddProficiency(Proficiency.CONSTITUTION);
                adultCopperDragon.AddProficiency(Proficiency.WISDOM);
                adultCopperDragon.AddProficiency(Proficiency.CHARISMA);
                adultCopperDragon.AddProficiency(Proficiency.DECEPTION);
                adultCopperDragon.AddProficiency(Proficiency.PERCEPTION);
                adultCopperDragon.AddProficiency(Proficiency.STEALTH);
                adultCopperDragon.AddEffect(Effect.IMMUNITY_ACID);
                adultCopperDragon.AddFeat(Feat.LEGENDARY_RESISTANCE);
                return adultCopperDragon;
            }
        }

        /* TODO */
        public static Monster AdultGoldDragon {
            get {
                Monster adultGoldDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.ADULT_GOLD_DRAGON, Alignment.LAWFUL_GOOD, 27, 14, 25, 16, 15, 24, 19, "19d12+133", 40, 17,
                    new Attack[] { Attacks.AdultGoldDragonBite, Attacks.AdultGoldDragonClaw, Attacks.AdultGoldDragonTail }, new Attack[] { }, Size.HUGE
                );
                adultGoldDragon.AddProficiency(Proficiency.DEXTERITY);
                adultGoldDragon.AddProficiency(Proficiency.CONSTITUTION);
                adultGoldDragon.AddProficiency(Proficiency.WISDOM);
                adultGoldDragon.AddProficiency(Proficiency.CHARISMA);
                adultGoldDragon.AddProficiency(Proficiency.INSIGHT);
                adultGoldDragon.AddProficiency(Proficiency.PERCEPTION);
                adultGoldDragon.AddProficiency(Proficiency.PERSUASION);
                adultGoldDragon.AddProficiency(Proficiency.STEALTH);
                adultGoldDragon.AddEffect(Effect.IMMUNITY_FIRE);
                adultGoldDragon.AddFeat(Feat.AMPHIBIOUS);
                adultGoldDragon.AddFeat(Feat.LEGENDARY_RESISTANCE);
                return adultGoldDragon;
            }
        }

        /* TODO */
        public static Monster AdultGreenDragon {
            get {
                Monster adultGreenDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.ADULT_GREEN_DRAGON, Alignment.LAWFUL_EVIL, 23, 12, 21, 18, 15, 17, 19, "18d12+90", 40, 15,
                    new Attack[] { Attacks.AdultGreenDragonBite, Attacks.AdultGreenDragonClaw, Attacks.AdultGreenDragonTail }, new Attack[] { }, Size.HUGE
                );
                adultGreenDragon.AddProficiency(Proficiency.DEXTERITY);
                adultGreenDragon.AddProficiency(Proficiency.CONSTITUTION);
                adultGreenDragon.AddProficiency(Proficiency.WISDOM);
                adultGreenDragon.AddProficiency(Proficiency.CHARISMA);
                adultGreenDragon.AddProficiency(Proficiency.DECEPTION);
                adultGreenDragon.AddProficiency(Proficiency.INSIGHT);
                adultGreenDragon.AddProficiency(Proficiency.PERCEPTION);
                adultGreenDragon.AddProficiency(Proficiency.PERSUASION);
                adultGreenDragon.AddProficiency(Proficiency.STEALTH);
                adultGreenDragon.AddEffect(Effect.IMMUNITY_POISON);
                adultGreenDragon.AddEffect(Effect.IMMUNITY_POISONED);
                adultGreenDragon.AddFeat(Feat.AMPHIBIOUS);
                adultGreenDragon.AddFeat(Feat.LEGENDARY_RESISTANCE);
                return adultGreenDragon;
            }
        }

        /* TODO */
        public static Monster AdultRedDragon {
            get {
                Monster adultRedDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.ADULT_RED_DRAGON, Alignment.CHAOTIC_EVIL, 27, 10, 25, 16, 13, 21, 19, "19d12+133", 40, 17,
                    new Attack[] { Attacks.AdultRedDragonBite, Attacks.AdultRedDragonClaw, Attacks.AdultRedDragonTail }, new Attack[] { }, Size.HUGE
                );
                adultRedDragon.AddProficiency(Proficiency.DEXTERITY);
                adultRedDragon.AddProficiency(Proficiency.CONSTITUTION);
                adultRedDragon.AddProficiency(Proficiency.WISDOM);
                adultRedDragon.AddProficiency(Proficiency.CHARISMA);
                adultRedDragon.AddProficiency(Proficiency.PERCEPTION);
                adultRedDragon.AddProficiency(Proficiency.STEALTH);
                adultRedDragon.AddEffect(Effect.IMMUNITY_FIRE);
                adultRedDragon.AddFeat(Feat.LEGENDARY_RESISTANCE);
                return adultRedDragon;
            }
        }

        /* TODO */
        public static Monster AdultSilverDragon {
            get {
                Monster adultSilverDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.ADULT_SILVER_DRAGON, Alignment.LAWFUL_GOOD, 27, 10, 25, 16, 13, 21, 19, "18d12+126", 40, 16,
                    new Attack[] { Attacks.AdultSilverDragonBite, Attacks.AdultSilverDragonClaw, Attacks.AdultSilverDragonTail }, new Attack[] { }, Size.HUGE
                );
                adultSilverDragon.AddProficiency(Proficiency.DEXTERITY);
                adultSilverDragon.AddProficiency(Proficiency.CONSTITUTION);
                adultSilverDragon.AddProficiency(Proficiency.WISDOM);
                adultSilverDragon.AddProficiency(Proficiency.CHARISMA);
                adultSilverDragon.AddProficiency(Proficiency.ARCANA);
                adultSilverDragon.AddProficiency(Proficiency.HISTORY);
                adultSilverDragon.AddProficiency(Proficiency.PERCEPTION);
                adultSilverDragon.AddProficiency(Proficiency.STEALTH);
                adultSilverDragon.AddEffect(Effect.IMMUNITY_COLD);
                adultSilverDragon.AddFeat(Feat.LEGENDARY_RESISTANCE);
                return adultSilverDragon;
            }
        }

        /* TODO */
        public static Monster AdultWhiteDragon {
            get {
                Monster adultWhiteDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.ADULT_WHITE_DRAGON, Alignment.CHAOTIC_EVIL, 22, 10, 22, 8, 12, 12, 18, "16d12+96", 40, 13,
                    new Attack[] { Attacks.AdultWhiteDragonBite, Attacks.AdultWhiteDragonClaw, Attacks.AdultWhiteDragonTail }, new Attack[] { }, Size.HUGE
                );
                adultWhiteDragon.AddProficiency(Proficiency.DEXTERITY);
                adultWhiteDragon.AddProficiency(Proficiency.CONSTITUTION);
                adultWhiteDragon.AddProficiency(Proficiency.WISDOM);
                adultWhiteDragon.AddProficiency(Proficiency.CHARISMA);
                adultWhiteDragon.AddProficiency(Proficiency.PERCEPTION);
                adultWhiteDragon.AddProficiency(Proficiency.STEALTH);
                adultWhiteDragon.AddEffect(Effect.IMMUNITY_COLD);
                adultWhiteDragon.AddFeat(Feat.ICE_WALK);
                adultWhiteDragon.AddFeat(Feat.LEGENDARY_RESISTANCE);
                return adultWhiteDragon;
            }
        }

        /* TODO */
        public static Monster AirElemental {
            get {
                Monster airElemental = new Monster(
                    Monsters.Type.ELEMENTAL, Monsters.ID.AIR_ELEMENTAL, Alignment.NEUTRAL, 14, 20, 14, 6, 10, 6, 15, "12d10+24", 40, 5,
                    new Attack[] { Attacks.AirElementalSlam }, new Attack[] { }, Size.LARGE
                );
                airElemental.AddEffect(Effect.RESISTANCE_LIGHTNING);
                airElemental.AddEffect(Effect.RESISTANCE_THUNDER);
                airElemental.AddEffect(Effect.RESISTANCE_NONMAGIC);
                airElemental.AddEffect(Effect.IMMUNITY_POISON);
                airElemental.AddEffect(Effect.IMMUNITY_EXHAUSTION);
                airElemental.AddEffect(Effect.IMMUNITY_GRAPPLED);
                airElemental.AddEffect(Effect.IMMUNITY_PARALYZED);
                airElemental.AddEffect(Effect.IMMUNITY_PETRIFIED);
                airElemental.AddEffect(Effect.IMMUNITY_POISONED);
                airElemental.AddEffect(Effect.IMMUNITY_PRONE);
                airElemental.AddEffect(Effect.IMMUNITY_RESTRAINED);
                airElemental.AddEffect(Effect.IMMUNITY_UNCONSCIOUS);
                airElemental.AddFeat(Feat.AIR_FORM);
                return airElemental;
            }
        }

        /* TODO */
        public static Monster AncientBlackDragon {
            get {
                Monster ancientBlackDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.ANCIENT_BLACK_DRAGON, Alignment.CHAOTIC_EVIL, 27, 14, 25, 16, 15, 19, 22, "21d20+147", 40, 21,
                    new Attack[] { Attacks.AncientBlackDragonClaw, Attacks.AncientBlackDragonTail }, new Attack[] { }, Size.GARGANTUAN
                );
                ancientBlackDragon.AddProficiency(Proficiency.DEXTERITY);
                ancientBlackDragon.AddProficiency(Proficiency.CONSTITUTION);
                ancientBlackDragon.AddProficiency(Proficiency.WISDOM);
                ancientBlackDragon.AddProficiency(Proficiency.CHARISMA);
                ancientBlackDragon.AddProficiency(Proficiency.PERCEPTION);
                ancientBlackDragon.AddProficiency(Proficiency.STEALTH);
                ancientBlackDragon.AddEffect(Effect.IMMUNITY_ACID);
                ancientBlackDragon.AddFeat(Feat.AMPHIBIOUS);
                ancientBlackDragon.AddFeat(Feat.LEGENDARY_RESISTANCE);
                return ancientBlackDragon;
            }
        }

        /* TODO */
        public static Monster AncientBlueDragon {
            get {
                Monster ancientBlueDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.ANCIENT_BLUE_DRAGON, Alignment.LAWFUL_EVIL, 29, 10, 27, 18, 17, 21, 22, "26d20+208", 40, 23,
                    new Attack[] { Attacks.AncientBlueDragonBite, Attacks.AncientBlueDragonClaw, Attacks.AncientBlueDragonTail }, new Attack[] { }, Size.GARGANTUAN
                );
                ancientBlueDragon.AddProficiency(Proficiency.DEXTERITY);
                ancientBlueDragon.AddProficiency(Proficiency.CONSTITUTION);
                ancientBlueDragon.AddProficiency(Proficiency.WISDOM);
                ancientBlueDragon.AddProficiency(Proficiency.CHARISMA);
                ancientBlueDragon.AddProficiency(Proficiency.PERCEPTION);
                ancientBlueDragon.AddProficiency(Proficiency.STEALTH);
                ancientBlueDragon.AddEffect(Effect.IMMUNITY_LIGHTNING);
                ancientBlueDragon.AddFeat(Feat.LEGENDARY_RESISTANCE);
                return ancientBlueDragon;
            }
        }

        /* TODO */
        public static Monster AncientBrassDragon {
            get {
                Monster ancientBrassDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.ANCIENT_BRASS_DRAGON, Alignment.CHAOTIC_GOOD, 27, 10, 25, 16, 15, 19, 20, "17d20+119", 40, 20,
                    new Attack[] { Attacks.AncientBrassDragonBite, Attacks.AncientBrassDragonClaw, Attacks.AncientBrassDragonTail }, new Attack[] { }, Size.GARGANTUAN
                );
                ancientBrassDragon.AddProficiency(Proficiency.DEXTERITY);
                ancientBrassDragon.AddProficiency(Proficiency.CONSTITUTION);
                ancientBrassDragon.AddProficiency(Proficiency.WISDOM);
                ancientBrassDragon.AddProficiency(Proficiency.CHARISMA);
                ancientBrassDragon.AddProficiency(Proficiency.HISTORY);
                ancientBrassDragon.AddProficiency(Proficiency.PERCEPTION);
                ancientBrassDragon.AddProficiency(Proficiency.PERSUASION);
                ancientBrassDragon.AddProficiency(Proficiency.STEALTH);
                ancientBrassDragon.AddEffect(Effect.IMMUNITY_FIRE);
                ancientBrassDragon.AddFeat(Feat.LEGENDARY_RESISTANCE);
                return ancientBrassDragon;
            }
        }

        /* TODO */
        public static Monster AncientBronzeDragon {
            get {
                Monster ancientBronzeDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.ANCIENT_BRONZE_DRAGON, Alignment.LAWFUL_GOOD, 29, 10, 27, 18, 17, 21, 22, "24d20+192", 40, 22,
                    new Attack[] { Attacks.AncientBronzeDragonBite, Attacks.AncientBronzeDragonClaw, Attacks.AncientBronzeDragonTail }, new Attack[] { }, Size.GARGANTUAN
                );
                ancientBronzeDragon.AddProficiency(Proficiency.DEXTERITY);
                ancientBronzeDragon.AddProficiency(Proficiency.CONSTITUTION);
                ancientBronzeDragon.AddProficiency(Proficiency.WISDOM);
                ancientBronzeDragon.AddProficiency(Proficiency.CHARISMA);
                ancientBronzeDragon.AddProficiency(Proficiency.INSIGHT);
                ancientBronzeDragon.AddProficiency(Proficiency.PERCEPTION);
                ancientBronzeDragon.AddProficiency(Proficiency.STEALTH);
                ancientBronzeDragon.AddEffect(Effect.IMMUNITY_LIGHTNING);
                ancientBronzeDragon.AddFeat(Feat.AMPHIBIOUS);
                ancientBronzeDragon.AddFeat(Feat.LEGENDARY_RESISTANCE);
                return ancientBronzeDragon;
            }
        }

        /* TODO */
        public static Monster AncientCopperDragon {
            get {
                Monster ancientCopperDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.ANCIENT_COPPER_DRAGON, Alignment.CHAOTIC_GOOD, 27, 12, 25, 20, 17, 19, 21, "20d20+140", 40, 21,
                    new Attack[] { Attacks.AncientCopperDragonBite, Attacks.AncientCopperDragonClaw, Attacks.AncientCopperDragonTail }, new Attack[] { }, Size.GARGANTUAN
                );
                ancientCopperDragon.AddProficiency(Proficiency.DEXTERITY);
                ancientCopperDragon.AddProficiency(Proficiency.CONSTITUTION);
                ancientCopperDragon.AddProficiency(Proficiency.WISDOM);
                ancientCopperDragon.AddProficiency(Proficiency.CHARISMA);
                ancientCopperDragon.AddProficiency(Proficiency.DECEPTION);
                ancientCopperDragon.AddProficiency(Proficiency.PERCEPTION);
                ancientCopperDragon.AddProficiency(Proficiency.STEALTH);
                ancientCopperDragon.AddEffect(Effect.IMMUNITY_ACID);
                ancientCopperDragon.AddFeat(Feat.LEGENDARY_RESISTANCE);
                return ancientCopperDragon;
            }
        }

        /* TODO */
        public static Monster AncientGoldDragon {
            get {
                Monster ancientGoldDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.ANCIENT_GOLD_DRAGON, Alignment.LAWFUL_GOOD, 30, 14, 29, 18, 17, 28, 22, "28d20+252", 40, 24,
                    new Attack[] { Attacks.AncientGoldDragonBite, Attacks.AncientGoldDragonClaw, Attacks.AncientGoldDragonTail }, new Attack[] { }, Size.GARGANTUAN
                );
                ancientGoldDragon.AddProficiency(Proficiency.DEXTERITY);
                ancientGoldDragon.AddProficiency(Proficiency.CONSTITUTION);
                ancientGoldDragon.AddProficiency(Proficiency.WISDOM);
                ancientGoldDragon.AddProficiency(Proficiency.CHARISMA);
                ancientGoldDragon.AddProficiency(Proficiency.INSIGHT);
                ancientGoldDragon.AddProficiency(Proficiency.PERCEPTION);
                ancientGoldDragon.AddProficiency(Proficiency.PERSUASION);
                ancientGoldDragon.AddProficiency(Proficiency.STEALTH);
                ancientGoldDragon.AddEffect(Effect.IMMUNITY_FIRE);
                ancientGoldDragon.AddFeat(Feat.AMPHIBIOUS);
                ancientGoldDragon.AddFeat(Feat.LEGENDARY_RESISTANCE);
                return ancientGoldDragon;
            }
        }

        /* TODO */
        public static Monster AncientGreenDragon {
            get {
                Monster ancientGreenDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.ANCIENT_GREEN_DRAGON, Alignment.LAWFUL_EVIL, 27, 12, 25, 20, 17, 19, 21, "22d20+154", 40, 22,
                    new Attack[] { Attacks.AncientGreenDragonBite, Attacks.AncientGreenDragonClaw, Attacks.AncientGreenDragonTail }, new Attack[] { }, Size.GARGANTUAN
                );
                ancientGreenDragon.AddProficiency(Proficiency.DEXTERITY);
                ancientGreenDragon.AddProficiency(Proficiency.CONSTITUTION);
                ancientGreenDragon.AddProficiency(Proficiency.WISDOM);
                ancientGreenDragon.AddProficiency(Proficiency.CHARISMA);
                ancientGreenDragon.AddProficiency(Proficiency.DECEPTION);
                ancientGreenDragon.AddProficiency(Proficiency.INSIGHT);
                ancientGreenDragon.AddProficiency(Proficiency.PERCEPTION);
                ancientGreenDragon.AddProficiency(Proficiency.PERSUASION);
                ancientGreenDragon.AddProficiency(Proficiency.STEALTH);
                ancientGreenDragon.AddEffect(Effect.IMMUNITY_POISON);
                ancientGreenDragon.AddEffect(Effect.IMMUNITY_POISONED);
                ancientGreenDragon.AddFeat(Feat.AMPHIBIOUS);
                ancientGreenDragon.AddFeat(Feat.LEGENDARY_RESISTANCE);
                return ancientGreenDragon;
            }
        }

        /* TODO */
        public static Monster AncientRedDragon {
            get {
                Monster ancientRedDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.ANCIENT_RED_DRAGON, Alignment.CHAOTIC_EVIL, 30, 10, 29, 18, 15, 23, 22, "28d20+252", 40, 24,
                    new Attack[] { Attacks.AncientRedDragonBite, Attacks.AncientRedDragonClaw, Attacks.AncientRedDragonTail }, new Attack[] { }, Size.GARGANTUAN
                );
                ancientRedDragon.AddProficiency(Proficiency.DEXTERITY);
                ancientRedDragon.AddProficiency(Proficiency.CONSTITUTION);
                ancientRedDragon.AddProficiency(Proficiency.WISDOM);
                ancientRedDragon.AddProficiency(Proficiency.CHARISMA);
                ancientRedDragon.AddProficiency(Proficiency.PERCEPTION);
                ancientRedDragon.AddProficiency(Proficiency.STEALTH);
                ancientRedDragon.AddEffect(Effect.IMMUNITY_FIRE);
                ancientRedDragon.AddFeat(Feat.LEGENDARY_RESISTANCE);
                return ancientRedDragon;
            }
        }

        /* TODO */
        public static Monster AncientSilverDragon {
            get {
                Monster ancientSilverDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.ANCIENT_SILVER_DRAGON, Alignment.LAWFUL_GOOD, 30, 10, 29, 18, 15, 23, 22, "25d20+225", 40, 23,
                    new Attack[] { Attacks.AncientSilverDragonBite, Attacks.AncientSilverDragonClaw, Attacks.AncientSilverDragonTail }, new Attack[] { }, Size.GARGANTUAN
                );
                ancientSilverDragon.AddProficiency(Proficiency.DEXTERITY);
                ancientSilverDragon.AddProficiency(Proficiency.CONSTITUTION);
                ancientSilverDragon.AddProficiency(Proficiency.WISDOM);
                ancientSilverDragon.AddProficiency(Proficiency.CHARISMA);
                ancientSilverDragon.AddProficiency(Proficiency.ARCANA);
                ancientSilverDragon.AddProficiency(Proficiency.HISTORY);
                ancientSilverDragon.AddProficiency(Proficiency.PERCEPTION);
                ancientSilverDragon.AddProficiency(Proficiency.STEALTH);
                ancientSilverDragon.AddEffect(Effect.IMMUNITY_COLD);
                ancientSilverDragon.AddFeat(Feat.LEGENDARY_RESISTANCE);
                return ancientSilverDragon;
            }
        }

        /* TODO */
        public static Monster AncientWhiteDragon {
            get {
                Monster ancientWhiteDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.ANCIENT_WHITE_DRAGON, Alignment.CHAOTIC_EVIL, 26, 10, 26, 10, 13, 14, 20, "18d20+144", 40, 20,
                    new Attack[] { Attacks.AncientWhiteDragonBite, Attacks.AncientWhiteDragonClaw, Attacks.AncientWhiteDragonTail }, new Attack[] { }, Size.GARGANTUAN
                );
                ancientWhiteDragon.AddProficiency(Proficiency.DEXTERITY);
                ancientWhiteDragon.AddProficiency(Proficiency.CONSTITUTION);
                ancientWhiteDragon.AddProficiency(Proficiency.WISDOM);
                ancientWhiteDragon.AddProficiency(Proficiency.CHARISMA);
                ancientWhiteDragon.AddProficiency(Proficiency.PERCEPTION);
                ancientWhiteDragon.AddProficiency(Proficiency.STEALTH);
                ancientWhiteDragon.AddEffect(Effect.IMMUNITY_COLD);
                ancientWhiteDragon.AddFeat(Feat.ICE_WALK);
                ancientWhiteDragon.AddFeat(Feat.LEGENDARY_RESISTANCE);
                return ancientWhiteDragon;
            }
        }

        /* TODO */
        public static Monster Androsphinx {
            get {
                Monster androsphinx = new Monster(
                    Monsters.Type.MONSTROSITY, Monsters.ID.ANDROSPHINX, Alignment.LAWFUL_NEUTRAL, 22, 10, 20, 16, 18, 23, 17, "19d10+95", 40, 17,
                    new Attack[] { Attacks.AndrosphinxClaw }, new Attack[] { }, Size.LARGE
                );
                androsphinx.AddProficiency(Proficiency.DEXTERITY);
                androsphinx.AddProficiency(Proficiency.CONSTITUTION);
                androsphinx.AddProficiency(Proficiency.INTELLIGENCE);
                androsphinx.AddProficiency(Proficiency.WISDOM);
                androsphinx.AddProficiency(Proficiency.ARCANA);
                androsphinx.AddProficiency(Proficiency.PERCEPTION);
                androsphinx.AddProficiency(Proficiency.RELIGION);
                androsphinx.AddEffect(Effect.IMMUNITY_PSYCHIC);
                androsphinx.AddEffect(Effect.IMMUNITY_NONMAGIC);
                androsphinx.AddEffect(Effect.IMMUNITY_CHARMED);
                androsphinx.AddEffect(Effect.IMMUNITY_FRIGHTENED);
                androsphinx.AddFeat(Feat.INSCRUTABLE);
                androsphinx.AddFeat(Feat.MAGIC_WEAPONS);
                androsphinx.AddFeat(Feat.SPELLCASTING_ANDROSPHINX);
                return androsphinx;
            }
        }

        /* TODO */
        public static Monster AnimatedArmor {
            get {
                Monster animatedArmor = new Monster(
                    Monsters.Type.CONSTRUCT, Monsters.ID.ANIMATED_ARMOR, Alignment.UNALIGNED, 14, 11, 13, 1, 3, 1, 18, "6d8+6", 40, 1,
                    new Attack[] { Attacks.AnimatedArmorSlam }, new Attack[] { }, Size.MEDIUM
                );
                animatedArmor.AddEffect(Effect.IMMUNITY_POISON);
                animatedArmor.AddEffect(Effect.IMMUNITY_PSYCHIC);
                animatedArmor.AddEffect(Effect.IMMUNITY_BLINDED);
                animatedArmor.AddEffect(Effect.IMMUNITY_CHARMED);
                animatedArmor.AddEffect(Effect.IMMUNITY_DEAFENED);
                animatedArmor.AddEffect(Effect.IMMUNITY_EXHAUSTION);
                animatedArmor.AddEffect(Effect.IMMUNITY_FRIGHTENED);
                animatedArmor.AddEffect(Effect.IMMUNITY_PARALYZED);
                animatedArmor.AddEffect(Effect.IMMUNITY_PETRIFIED);
                animatedArmor.AddEffect(Effect.IMMUNITY_POISONED);
                animatedArmor.AddFeat(Feat.ANTIMAGIC_SUSCEPTIBILITY);
                animatedArmor.AddFeat(Feat.FALSE_APPEARANCE);
                return animatedArmor;
            }
        }

        /* TODO */
        public static Monster Ankheg {
            get {
                Monster ankheg = new Monster(
                    Monsters.Type.MONSTROSITY, Monsters.ID.ANKHEG, Alignment.UNALIGNED, 17, 11, 13, 1, 13, 6, 14, "6d10+6", 40, 2,
                    new Attack[] { Attacks.AnkhegBite }, new Attack[] { }, Size.LARGE
                );
                return ankheg;
            }
        }

        /* TODO */
        public static Monster Ape {
            get {
                Monster ape = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.APE, Alignment.UNALIGNED, 16, 14, 14, 6, 12, 7, 12, "3d8+6", 40, ChallengeRating.HALF,
                    new Attack[] { Attacks.ApeFist }, new Attack[] { }, Size.MEDIUM
                );
                ape.AddProficiency(Proficiency.ATHLETICS);
                ape.AddProficiency(Proficiency.PERCEPTION);
                return ape;
            }
        }

        /* TODO */
        public static Monster Archmage {
            get {
                Monster archmage = new Monster(
                    Monsters.Type.HUMANOID, Monsters.ID.ARCHMAGE, Alignment.UNALIGNED, 10, 14, 12, 20, 15, 16, 12, "18d8+18", 40, 12,
                    new Attack[] { Attacks.ArchmageDaggerMelee }, new Attack[] { Attacks.ArchmageDaggerRanged }, Size.MEDIUM
                );
                archmage.AddProficiency(Proficiency.INTELLIGENCE);
                archmage.AddProficiency(Proficiency.WISDOM);
                archmage.AddProficiency(Proficiency.ARCANA);
                archmage.AddProficiency(Proficiency.HISTORY);
                archmage.AddEffect(Effect.RESISTANCE_DAMAGE_FROM_SPELLS);
                archmage.AddEffect(Effect.RESISTANCE_NONMAGIC);
                archmage.AddFeat(Feat.MAGIC_RESISTANCE);
                archmage.AddFeat(Feat.SPELLCASTING_ARCHMAGE);
                return archmage;
            }
        }

        /* TODO */
        public static Monster Assassin {
            get {
                Monster assassin = new Monster(
                    Monsters.Type.HUMANOID, Monsters.ID.ASSASSIN, Alignment.UNALIGNED, 11, 16, 14, 13, 11, 10, 15, "12d8+24", 40, 8,
                    new Attack[] { Attacks.AssassinShortsword }, new Attack[] { }, Size.MEDIUM
                );
                assassin.AddProficiency(Proficiency.DEXTERITY);
                assassin.AddProficiency(Proficiency.INTELLIGENCE);
                assassin.AddProficiency(Proficiency.ACROBATICS);
                assassin.AddProficiency(Proficiency.DECEPTION);
                assassin.AddProficiency(Proficiency.PERCEPTION);
                assassin.AddProficiency(Proficiency.STEALTH);
                assassin.AddEffect(Effect.RESISTANCE_POISON);
                assassin.AddFeat(Feat.ASSASSINATE);
                assassin.AddFeat(Feat.EVASION);
                assassin.AddFeat(Feat.SNEAK_ATTACK_4D6);
                return assassin;
            }
        }

        /* TODO */
        public static Monster AwakenedShrub {
            get {
                Monster awakenedShrub = new Monster(
                    Monsters.Type.PLANT, Monsters.ID.AWAKENED_SHRUB, Alignment.UNALIGNED, 3, 8, 11, 10, 10, 6, 9, "3d6", 40, 0,
                    new Attack[] { Attacks.AwakenedShrubRake }, new Attack[] { }, Size.SMALL
                );
                awakenedShrub.AddEffect(Effect.VULNERABILITY_FIRE);
                awakenedShrub.AddEffect(Effect.RESISTANCE_PIERCING);
                awakenedShrub.AddFeat(Feat.FALSE_APPEARANCE);
                return awakenedShrub;
            }
        }

        /* TODO */
        public static Monster AwakenedTree {
            get {
                Monster awakenedTree = new Monster(
                    Monsters.Type.PLANT, Monsters.ID.AWAKENED_TREE, Alignment.UNALIGNED, 19, 6, 15, 10, 10, 7, 13, "7d12+14", 40, 2,
                    new Attack[] { Attacks.AwakenedTreeSlam }, new Attack[] { }, Size.HUGE
                );
                awakenedTree.AddEffect(Effect.VULNERABILITY_FIRE);
                awakenedTree.AddEffect(Effect.RESISTANCE_BLUDGEONING);
                awakenedTree.AddEffect(Effect.RESISTANCE_PIERCING);
                awakenedTree.AddFeat(Feat.FALSE_APPEARANCE);
                return awakenedTree;
            }
        }

        /* TODO */
        public static Monster AxeBeak {
            get {
                Monster axeBeak = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.AXE_BEAK, Alignment.UNALIGNED, 14, 12, 12, 2, 10, 5, 11, "3d10+3", 40, ChallengeRating.QUARTER,
                    new Attack[] { Attacks.AxeBeakBeak }, new Attack[] { }, Size.LARGE
                );
                return axeBeak;
            }
        }

        /* TODO */
        public static Monster Azer {
            get {
                Monster azer = new Monster(
                    Monsters.Type.ELEMENTAL, Monsters.ID.AZER, Alignment.LAWFUL_NEUTRAL, 17, 12, 15, 12, 13, 10, 17, "6d8+12", 40, 2,
                    new Attack[] { Attacks.AzerWarhammer }, new Attack[] { }, Size.MEDIUM
                );
                azer.AddProficiency(Proficiency.CONSTITUTION);
                azer.AddEffect(Effect.IMMUNITY_FIRE);
                azer.AddEffect(Effect.IMMUNITY_POISON);
                azer.AddEffect(Effect.IMMUNITY_POISONED);
                azer.AddFeat(Feat.HEATED_BODY_1D10);
                azer.AddFeat(Feat.HEATED_WEAPONS);
                azer.AddFeat(Feat.ILLUMINATION_10FT);
                return azer;
            }
        }

        public static Monster GiantBadger {
            get {
                return new Monster(
                    Monsters.Type.BEAST, Monsters.ID.GIANT_BADGER, Alignment.UNALIGNED, 13, 10, 15, 2, 12, 5, 10, "2d8+4", 30, ChallengeRating.QUARTER,
                    new Attack[] { Attacks.GiantBadgerBite, Attacks.GiantBadgerClaws }, Attacks.None, Size.MEDIUM
                );
            }
        }

        public static Monster GiantScorpion {
            get {
                Monster giantScorpion = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.GIANT_SCORPION, Alignment.UNALIGNED, 15, 13, 15, 1, 9, 3, 15, "7d10+14", 40, 3,
                    new Attack[] { Attacks.GiantScorpionClaw, Attacks.GiantScorpionSting }, new Attack[] { }, Size.LARGE
                );
                return giantScorpion;
            }
        }

        public static Monster Goblin {
            get {
                return new Monster(
                    Monsters.Type.HUMANOID, Monsters.ID.GOBLIN, Alignment.NEUTRAL_EVIL, 8, 14, 10, 10, 8, 8, 15, "2d6", 30, ChallengeRating.QUARTER,
                    new Attack[] { Attacks.GoblinScimitar }, new Attack[] { Attacks.GoblinShortbow }, Size.SMALL
                );
            }
        }

        public static Monster Ogre {
            get {
                return new Monster(
                    Monsters.Type.GIANT, Monsters.ID.OGRE, Alignment.CHAOTIC_EVIL, 19, 8, 16, 5, 7, 7, 11, "7d10+21", 40, 2,
                    new Attack[] { Attacks.OgreGreatclub }, new Attack[] { Attacks.OgreJavelin }, Size.LARGE
                );
            }
        }

        public static Monster NightHag {
            get {
                Monster hag = new Monster(
                    Monsters.Type.FIEND, Monsters.ID.NIGHT_HAG, Alignment.NEUTRAL_EVIL, 18, 15, 16, 16, 14, 16, 17, "15d8+45", 30, 5,
                    new Attack[] { Attacks.NightHagClaws }, Attacks.None, Size.MEDIUM, 14
                );
                AvailableSpells spells = new AvailableSpells(AbilityType.CHARISMA);
                spells.AddKnownSpell(Spells.MagicMissile, Spells.DetectMagic, Spells.PlaneShift, Spells.RayofEnfeeblement, Spells.Sleep);
                hag.AddAvailableSpells(spells);
                hag.AddInnateSpellcasting(
                    new InnateSpellcasting(Spells.MagicMissile, InnateSpellcasting.Frequencies.AT_WILL),
                    new InnateSpellcasting(Spells.DetectMagic, InnateSpellcasting.Frequencies.AT_WILL),
                    new InnateSpellcasting(Spells.PlaneShift, InnateSpellcasting.Frequencies.TWICE_PER_DAY),
                    new InnateSpellcasting(Spells.RayofEnfeeblement, InnateSpellcasting.Frequencies.TWICE_PER_DAY),
                    new InnateSpellcasting(Spells.Sleep, InnateSpellcasting.Frequencies.TWICE_PER_DAY)
                );
                return hag;
            }
        }

        public static Monster Orc {
            get {
                Monster orc = new Monster(
                    Monsters.Type.HUMANOID, Monsters.ID.ORC, Alignment.CHAOTIC_EVIL, 16, 12, 16, 7, 11, 10, 13, "2d8+6", 30, ChallengeRating.HALF,
                    new Attack[] { Attacks.OrcGreataxe }, new Attack[] { Attacks.OrcJavelin }, Size.MEDIUM, 0
                );
                return orc;
            }
        }

        public static Monster ClayGolem {
            get {
                Monster golem = new Monster(
                    Monsters.Type.CONSTRUCT, Monsters.ID.CLAY_GOLEM, Alignment.UNALIGNED, 20, 9, 18, 3, 8, 1, 14, "14d10+56", 20, 9,
                    new Attack[] { Attacks.ClayGolemSlam, Attacks.ClayGolemSlam }, Attacks.None, Size.LARGE, 0
                );
                golem.AddEffects(Effect.IMMUNITY_ACID, Effect.IMMUNITY_POISON, Effect.IMMUNITY_PSYCHIC, Effect.IMMUNITY_NONMAGIC);
                golem.AddEffects(Effect.IMMUNITY_CHARMED, Effect.IMMUNITY_EXHAUSTION, Effect.IMMUNITY_FRIGHTENED, Effect.IMMUNITY_PARALYZED, Effect.IMMUNITY_PETRIFIED, Effect.IMMUNITY_POISONED);
                return golem;
            }
        }

        public static Monster Shadow {
            get {
                Monster shadow = new Monster(
                    Monsters.Type.UNDEAD, Monsters.ID.SHADOW, Alignment.CHAOTIC_EVIL, 6, 14, 13, 6, 10, 8, 12, "3d8+3", 40, ChallengeRating.HALF,
                    new Attack[] { Attacks.ShadowStrengthDrain }, Attacks.None, Size.MEDIUM, 0
                );
                shadow.AddEffects(Effect.VULNERABILITY_RADIANT);
                shadow.AddEffects(Effect.RESISTANCE_ACID, Effect.RESISTANCE_COLD, Effect.RESISTANCE_LIGHTNING, Effect.RESISTANCE_THUNDER, Effect.RESISTANCE_NONMAGIC);
                shadow.AddEffects(Effect.IMMUNITY_NECROTIC, Effect.IMMUNITY_POISON);
                shadow.AddEffects(Effect.IMMUNITY_EXHAUSTION, Effect.IMMUNITY_FRIGHTENED, Effect.IMMUNITY_GRAPPLED, Effect.IMMUNITY_PARALYZED, Effect.IMMUNITY_PETRIFIED, Effect.IMMUNITY_POISONED, Effect.IMMUNITY_PRONE, Effect.IMMUNITY_RESTRAINED);
                return shadow;
            }
        }

        public static Monster Tarrasque {
            get {
                Monster tarrasque = new Monster(
                    Monsters.Type.MONSTROSITY, Monsters.ID.TARRASQUE, Alignment.UNALIGNED, 30, 11, 30, 3, 11, 11, 25, "33d20+330", 40, 30,
                    new Attack[] { Attacks.TarrasqueBite, Attacks.TarrasqueHorns, Attacks.TarrasqueTail, Attacks.TarrasqueClaw, Attacks.TarrasqueClaw },
                    Attacks.None, Size.GARGANTUAN, 0
                );
                tarrasque.AddFeats(Feat.LEGENDARY_RESISTANCE, Feat.MAGIC_RESISTANCE, Feat.REFLECTIVE_CARAPACE, Feat.SIEGE_MONSTER);
                tarrasque.AddEffects(Effect.IMMUNITY_FIRE, Effect.IMMUNITY_POISON, Effect.IMMUNITY_NONMAGIC);
                tarrasque.AddEffects(Effect.IMMUNITY_CHARMED, Effect.IMMUNITY_FRIGHTENED, Effect.IMMUNITY_PARALYZED, Effect.IMMUNITY_POISONED);

                tarrasque.AddProficiency(Proficiency.INTELLIGENCE);
                tarrasque.AddProficiency(Proficiency.WISDOM);
                tarrasque.AddProficiency(Proficiency.CHARISMA);

                return tarrasque;
            }
        }
    }
}
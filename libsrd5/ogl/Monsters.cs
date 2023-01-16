namespace srd5 {
    public enum Size {
        TINY,
        SMALL,
        MEDIUM,
        LARGE,
        HUGE,
        GARGANTUAN
    }

    public partial struct Attacks {
        public static readonly Attack[] None = new Attack[0];
        public static readonly Attack BoarTusk = new Attack("Tusk", 3, new Damage(DamageType.SLASHING, "1d6+1"), 5);
        public static readonly Attack ClayGolemSlam = new Attack("Slam", 8, new Damage(DamageType.BLUDGEONING, "2d10+5"), 5);
        public static readonly Attack GiantBadgerBite = new Attack("Bite", 3, new Damage(DamageType.PIERCING, "1d6+1"), 5);
        public static readonly Attack GiantBadgerClaws = new Attack("Claws", 3, new Damage(DamageType.SLASHING, "2d4+1"), 5);
        public static readonly Attack GiantScorpionClaw = new Attack("Claw", 4, new Damage(DamageType.BLUDGEONING, "1d8+2"), 5);
        public static AttackEffect GiantScorpionStingEffect = delegate (Combattant attacker, Combattant target) {
            int amount = new Dices("4d10").Roll();
            if (target.DC(null, 12, AbilityType.CONSTITUTION)) amount /= 2;
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
        public enum Type {
            ABERRATION,
            BEAST,
            CELESTIAL,
            CONSTRUCT,
            DRAGON,
            ELEMENTAL,
            FEY,
            FIEND,
            GIANT,
            HUMANOID,
            MONSTROSITY,
            OOZE,
            PLANT,
            UNDEAD
        }

        public enum ID {
            ABOLETH,
            ACOLYTE,
            ADULT_BLACK_DRAGON,
            ADULT_BLUE_DRAGON,
            ADULT_BRASS_DRAGON,
            ADULT_BRONZE_DRAGON,
            ADULT_COPPER_DRAGON,
            ADULT_GOLD_DRAGON,
            ADULT_GREEN_DRAGON,
            ADULT_RED_DRAGON,
            ADULT_SILVER_DRAGON,
            ADULT_WHITE_DRAGON,
            AIR_ELEMENTAL,
            ANCIENT_BLACK_DRAGON,
            ANCIENT_BLUE_DRAGON,
            ANCIENT_BRASS_DRAGON,
            ANCIENT_BRONZE_DRAGON,
            ANCIENT_COPPER_DRAGON,
            ANCIENT_GOLD_DRAGON,
            ANCIENT_GREEN_DRAGON,
            ANCIENT_RED_DRAGON,
            ANCIENT_SILVER_DRAGON,
            ANCIENT_WHITE_DRAGON,
            ANDROSPHINX,
            ANIMATED_ARMOR,
            ANKHEG,
            APE,
            ARCHMAGE,
            ASSASSIN,
            AWAKENED_SHRUB,
            AWAKENED_TREE,
            AXE_BEAK,
            AZER,
            BABOON,
            BADGER,
            BALOR,
            BANDIT,
            BANDIT_CAPTAIN,
            BARBED_DEVIL,
            BASILISK,
            BAT,
            BEARDED_DEVIL,
            BEHIR,
            BERSERKER,
            BLACK_BEAR,
            BLACK_DRAGON_WYRMLING,
            BLACK_PUDDING,
            BLINK_DOG,
            BLOOD_HAWK,
            BLUE_DRAGON_WYRMLING,
            BOAR,
            BONE_DEVIL,
            BRASS_DRAGON_WYRMLING,
            BRONZE_DRAGON_WYRMLING,
            BROWN_BEAR,
            BUGBEAR,
            BULETTE,
            CAMEL,
            CAT,
            CENTAUR,
            CHAIN_DEVIL,
            CHIMERA,
            CHUUL,
            CLAY_GOLEM,
            CLOAKER,
            CLOUD_GIANT,
            COCKATRICE,
            COMMONER,
            CONSTRICTOR_SNAKE,
            COPPER_DRAGON_WYRMLING,
            COUATL,
            CRAB,
            CROCODILE,
            CULT_FANATIC,
            CULTIST,
            DARKMANTLE,
            DEATH_DOG,
            DEEP_GNOME__SVIRFNEBLIN,
            DEER,
            DEVA,
            DIRE_WOLF,
            DJINNI,
            DOPPELGANGER,
            DRAFT_HORSE,
            DRAGON_TURTLE,
            DRETCH,
            DRIDER,
            DROW,
            DRUID,
            DRYAD,
            DUERGAR,
            DUST_MEPHIT,
            EAGLE,
            EARTH_ELEMENTAL,
            EFREETI,
            ELEPHANT,
            ELK,
            ERINYES,
            ETTERCAP,
            ETTIN,
            FIRE_ELEMENTAL,
            FIRE_GIANT,
            FLESH_GOLEM,
            FLYING_SNAKE,
            FLYING_SWORD,
            FROG,
            FROST_GIANT,
            GARGOYLE,
            GELATINOUS_CUBE,
            GHAST,
            GHOST,
            GHOUL,
            GIANT_APE,
            GIANT_BADGER,
            GIANT_BAT,
            GIANT_BOAR,
            GIANT_CENTIPEDE,
            GIANT_CONSTRICTOR_SNAKE,
            GIANT_CRAB,
            GIANT_CROCODILE,
            GIANT_EAGLE,
            GIANT_ELK,
            GIANT_FIRE_BEETLE,
            GIANT_FROG,
            GIANT_GOAT,
            GIANT_HYENA,
            GIANT_LIZARD,
            GIANT_OCTOPUS,
            GIANT_OWL,
            GIANT_POISONOUS_SNAKE,
            GIANT_RAT,
            GIANT_RAT__DISEASED,
            GIANT_SCORPION,
            GIANT_SEA_HORSE,
            GIANT_SHARK,
            GIANT_SPIDER,
            GIANT_TOAD,
            GIANT_VULTURE,
            GIANT_WASP,
            GIANT_WEASEL,
            GIANT_WOLF_SPIDER,
            GIBBERING_MOUTHER,
            GLABREZU,
            GLADIATOR,
            GNOLL,
            GOAT,
            GOBLIN,
            GOLD_DRAGON_WYRMLING,
            GORGON,
            GRAY_OOZE,
            GREEN_DRAGON_WYRMLING,
            GREEN_HAG,
            GRICK,
            GRIFFON,
            GRIMLOCK,
            GUARD,
            GUARDIAN_NAGA,
            GYNOSPHINX,
            HALF_RED_DRAGON_VETERAN,
            HARPY,
            HAWK,
            HELL_HOUND,
            HEZROU,
            HILL_GIANT,
            HIPPOGRIFF,
            HOBGOBLIN,
            HOMUNCULUS,
            HORNED_DEVIL,
            HUNTER_SHARK,
            HYDRA,
            HYENA,
            ICE_DEVIL,
            ICE_MEPHIT,
            IMP,
            INVISIBLE_STALKER,
            IRON_GOLEM,
            JACKAL,
            KILLER_WHALE,
            KNIGHT,
            KOBOLD,
            KRAKEN,
            LAMIA,
            LEMURE,
            LICH,
            LION,
            LIZARD,
            LIZARDFOLK,
            MAGE,
            MAGMA_MEPHIT,
            MAGMIN,
            MAMMOTH,
            MANTICORE,
            MARILITH,
            MASTIFF,
            MEDUSA,
            MERFOLK,
            MERROW,
            MIMIC,
            MINOTAUR,
            MINOTAUR_SKELETON,
            MULE,
            MUMMY,
            MUMMY_LORD,
            NALFESHNEE,
            NIGHT_HAG,
            NIGHTMARE,
            NOBLE,
            OCHRE_JELLY,
            OCTOPUS,
            OGRE,
            OGRE_ZOMBIE,
            ONI,
            ORC,
            OTYUGH,
            OWL,
            OWLBEAR,
            PANTHER,
            PEGASUS,
            PHASE_SPIDER,
            PIT_FIEND,
            PLANETAR,
            PLESIOSAURUS,
            POISONOUS_SNAKE,
            POLAR_BEAR,
            PONY,
            PRIEST,
            PSEUDODRAGON,
            PURPLE_WORM,
            QUASIT,
            QUIPPER,
            RAKSHASA,
            RAT,
            RAVEN,
            RED_DRAGON_WYRMLING,
            REEF_SHARK,
            REMORHAZ,
            RHINOCEROS,
            RIDING_HORSE,
            ROC,
            ROPER,
            RUG_OF_SMOTHERING,
            RUST_MONSTER,
            SABER_TOOTHED_TIGER,
            SAHUAGIN,
            SALAMANDER,
            SATYR,
            SCORPION,
            SCOUT,
            SEA_HAG,
            SEA_HORSE,
            SHADOW,
            SHAMBLING_MOUND,
            SHIELD_GUARDIAN,
            SHRIEKER,
            SILVER_DRAGON_WYRMLING,
            SKELETON,
            SOLAR,
            SPECTER,
            SPIDER,
            SPIRIT_NAGA,
            SPRITE,
            SPY,
            STEAM_MEPHIT,
            STIRGE,
            STONE_GIANT,
            STONE_GOLEM,
            STORM_GIANT,
            SUCCUBUS_INCUBUS,
            SWARM_OF_BATS,
            SWARM_OF_BEETLES,
            SWARM_OF_CENTIPEDES,
            SWARM_OF_INSECTS,
            SWARM_OF_POISONOUS_SNAKES,
            SWARM_OF_QUIPPERS,
            SWARM_OF_RATS,
            SWARM_OF_RAVENS,
            SWARM_OF_SPIDERS,
            SWARM_OF_WASPS,
            TARRASQUE,
            THUG,
            TIGER,
            TREANT,
            TRIBAL_WARRIOR,
            TRICERATOPS,
            TROLL,
            TYRANNOSAURUS_REX,
            UNICORN,
            VAMPIRE_VAMPIRE_FORM,
            VAMPIRE_BAT_FORM,
            VAMPIRE_MIST_FORM,
            VAMPIRE_SPAWN,
            VETERAN,
            VIOLET_FUNGUS,
            VROCK,
            VULTURE,
            WARHORSE,
            WARHORSE_SKELETON,
            WATER_ELEMENTAL,
            WEASEL,
            WEREBEAR_BEAR_FORM,
            WEREBEAR_HUMAN_FORM,
            WEREBEAR_HYBRID_FORM,
            WEREBOAR_BOAR_FORM,
            WEREBOAR_HUMAN_FORM,
            WEREBOAR_HYBRID_FORM,
            WERERAT_HUMAN_FORM,
            WERERAT_HYBRID_FORM,
            WERERAT_RAT_FORM,
            WERETIGER_HUMAN_FORM,
            WERETIGER_HYBRID_FORM,
            WERETIGER_TIGER_FORM,
            WEREWOLF_HUMAN_FORM,
            WEREWOLF_HYBRID_FORM,
            WEREWOLF_WOLF_FORM,
            WHITE_DRAGON_WYRMLING,
            WIGHT,
            WILL_O_WISP,
            WINTER_WOLF,
            WOLF,
            WORG,
            WRAITH,
            WYVERN,
            XORN,
            YOUNG_BLACK_DRAGON,
            YOUNG_BLUE_DRAGON,
            YOUNG_BRASS_DRAGON,
            YOUNG_BRONZE_DRAGON,
            YOUNG_COPPER_DRAGON,
            YOUNG_GOLD_DRAGON,
            YOUNG_GREEN_DRAGON,
            YOUNG_RED_DRAGON,
            YOUNG_SILVER_DRAGON,
            YOUNG_WHITE_DRAGON,
            ZOMBIE,

        }

        public static Monster Boar {
            get {
                return new Monster(
                    Monsters.Type.BEAST, "Boar", Alignment.UNALIGNED, 13, 11, 12, 2, 9, 5, 11, "2d8+2", 40, ChallengeRating.QUARTER,
                    new Attack[] { Attacks.BoarTusk }, Attacks.None, Size.MEDIUM
                );
            }
        }

        public static Monster GiantBadger {
            get {
                return new Monster(
                    Monsters.Type.BEAST, "Giant Badger", Alignment.UNALIGNED, 13, 10, 15, 2, 12, 5, 10, "2d8+4", 30, ChallengeRating.QUARTER,
                    new Attack[] { Attacks.GiantBadgerBite, Attacks.GiantBadgerClaws }, Attacks.None, Size.MEDIUM
                );
            }
        }

        public static Monster GiantScorpion {
            get {
                Monster giantScorpion = new Monster(
                    Monsters.Type.BEAST, "GiantScorpion", Alignment.UNALIGNED, 15, 13, 15, 1, 9, 3, 15, "7d10+14", 40, 3,
                    new Attack[] { Attacks.GiantScorpionClaw, Attacks.GiantScorpionSting }, new Attack[] { }, Size.LARGE
                );
                return giantScorpion;
            }
        }

        public static Monster Goblin {
            get {
                return new Monster(
                    Monsters.Type.HUMANOID, "Goblin", Alignment.NEUTRAL_EVIL, 8, 14, 10, 10, 8, 8, 15, "2d6", 30, ChallengeRating.QUARTER,
                    new Attack[] { Attacks.GoblinScimitar }, new Attack[] { Attacks.GoblinShortbow }, Size.SMALL
                );
            }
        }

        public static Monster Ogre {
            get {
                return new Monster(
                    Monsters.Type.GIANT, "Ogre", Alignment.CHAOTIC_EVIL, 19, 8, 16, 5, 7, 7, 11, "7d10+21", 40, 2,
                    new Attack[] { Attacks.OgreGreatclub }, new Attack[] { Attacks.OgreJavelin }, Size.LARGE
                );
            }
        }

        public static Monster NightHag {
            get {
                Monster hag = new Monster(
                    Monsters.Type.FIEND, "Night Hag", Alignment.NEUTRAL_EVIL, 18, 15, 16, 16, 14, 16, 17, "15d8+45", 30, 5,
                    new Attack[] { Attacks.NightHagClaws }, Attacks.None, Size.MEDIUM, 14
                );
                AvailableSpells spells = new AvailableSpells(AbilityType.CHARISMA);
                spells.AddKnownSpell(Spells.MagicMissile, Spells.DetectMagic);
                spells.SlotsCurrent[1] = 999;
                hag.AddAvailableSpells(spells);
                return hag;
            }
        }

        public static Monster Orc {
            get {
                Monster orc = new Monster(
                    Monsters.Type.HUMANOID, "Orc", Alignment.CHAOTIC_EVIL, 16, 12, 16, 7, 11, 10, 13, "2d8+6", 30, ChallengeRating.HALF,
                    new Attack[] { Attacks.OrcGreataxe }, new Attack[] { Attacks.OrcJavelin }, Size.MEDIUM, 0
                );
                return orc;
            }
        }

        public static Monster ClayGolem {
            get {
                Monster golem = new Monster(
                    Monsters.Type.CONSTRUCT, "Clay Golem", Alignment.UNALIGNED, 20, 9, 18, 3, 8, 1, 14, "14d10+56", 20, 9,
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
                    Monsters.Type.UNDEAD, "Shadow", Alignment.CHAOTIC_EVIL, 6, 14, 13, 6, 10, 8, 12, "3d8+3", 40, ChallengeRating.HALF,
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
                    Monsters.Type.MONSTROSITY, "Tarrasque", Alignment.UNALIGNED, 30, 11, 30, 3, 11, 11, 25, "33d20+330", 40, 30,
                    new Attack[] { Attacks.TarrasqueBite, Attacks.TarrasqueHorns, Attacks.TarrasqueTail, Attacks.TarrasqueClaw, Attacks.TarrasqueClaw },
                    Attacks.None, Size.GARGANTUAN, 0
                );
                tarrasque.AddEffects(Effect.LEGENDARY_RESISTANCE, Effect.LEGENDARY_RESISTANCE, Effect.LEGENDARY_RESISTANCE, Effect.MAGIC_RESISTANCE, Effect.REFLECTIVE_CARAPACE, Effect.SIEGE_MONSTER);
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
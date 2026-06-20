namespace srd5 {
    public enum Size {
        EXTRA_TINY, // DO NOT ASSIGN DIRECTLY. Only for shrink effects
        TINY,
        SMALL,
        MEDIUM,
        LARGE,
        HUGE,
        GARGANTUAN,
        EXTRA_GARGANTUAN, // DO NOT ASSIGN DIRECTLY. Only for enlarge effects
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
            SWARM,
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
            ZOMBIE
        }

        public static Monster Get(ID id) {
            switch (id) {
                case ID.ABOLETH: return Monsters.Aboleth;
                case ID.ACOLYTE: return Monsters.Acolyte;
                case ID.ADULT_BLACK_DRAGON: return Monsters.AdultBlackDragon;
                case ID.ADULT_BLUE_DRAGON: return Monsters.AdultBlueDragon;
                case ID.ADULT_BRASS_DRAGON: return Monsters.AdultBrassDragon;
                case ID.ADULT_BRONZE_DRAGON: return Monsters.AdultBronzeDragon;
                case ID.ADULT_COPPER_DRAGON: return Monsters.AdultCopperDragon;
                case ID.ADULT_GOLD_DRAGON: return Monsters.AdultGoldDragon;
                case ID.ADULT_GREEN_DRAGON: return Monsters.AdultGreenDragon;
                case ID.ADULT_RED_DRAGON: return Monsters.AdultRedDragon;
                case ID.ADULT_SILVER_DRAGON: return Monsters.AdultSilverDragon;
                case ID.ADULT_WHITE_DRAGON: return Monsters.AdultWhiteDragon;
                case ID.AIR_ELEMENTAL: return Monsters.AirElemental;
                case ID.ANCIENT_BLACK_DRAGON: return Monsters.AncientBlackDragon;
                case ID.ANCIENT_BLUE_DRAGON: return Monsters.AncientBlueDragon;
                case ID.ANCIENT_BRASS_DRAGON: return Monsters.AncientBrassDragon;
                case ID.ANCIENT_BRONZE_DRAGON: return Monsters.AncientBronzeDragon;
                case ID.ANCIENT_COPPER_DRAGON: return Monsters.AncientCopperDragon;
                case ID.ANCIENT_GOLD_DRAGON: return Monsters.AncientGoldDragon;
                case ID.ANCIENT_GREEN_DRAGON: return Monsters.AncientGreenDragon;
                case ID.ANCIENT_RED_DRAGON: return Monsters.AncientRedDragon;
                case ID.ANCIENT_SILVER_DRAGON: return Monsters.AncientSilverDragon;
                case ID.ANCIENT_WHITE_DRAGON: return Monsters.AncientWhiteDragon;
                case ID.ANDROSPHINX: return Monsters.Androsphinx;
                case ID.ANIMATED_ARMOR: return Monsters.AnimatedArmor;
                case ID.ANKHEG: return Monsters.Ankheg;
                case ID.APE: return Monsters.Ape;
                case ID.ARCHMAGE: return Monsters.Archmage;
                case ID.ASSASSIN: return Monsters.Assassin;
                case ID.AWAKENED_SHRUB: return Monsters.AwakenedShrub;
                case ID.AWAKENED_TREE: return Monsters.AwakenedTree;
                case ID.AXE_BEAK: return Monsters.AxeBeak;
                case ID.AZER: return Monsters.Azer;
                case ID.BABOON: return Monsters.Baboon;
                case ID.BADGER: return Monsters.Badger;
                case ID.BALOR: return Monsters.Balor;
                case ID.BANDIT: return Monsters.Bandit;
                case ID.BANDIT_CAPTAIN: return Monsters.BanditCaptain;
                case ID.BARBED_DEVIL: return Monsters.BarbedDevil;
                case ID.BASILISK: return Monsters.Basilisk;
                case ID.BAT: return Monsters.Bat;
                case ID.BEARDED_DEVIL: return Monsters.BeardedDevil;
                case ID.BEHIR: return Monsters.Behir;
                case ID.BERSERKER: return Monsters.Berserker;
                case ID.BLACK_BEAR: return Monsters.BlackBear;
                case ID.BLACK_DRAGON_WYRMLING: return Monsters.BlackDragonWyrmling;
                case ID.BLACK_PUDDING: return Monsters.BlackPudding;
                case ID.BLINK_DOG: return Monsters.BlinkDog;
                case ID.BLOOD_HAWK: return Monsters.BloodHawk;
                case ID.BLUE_DRAGON_WYRMLING: return Monsters.BlueDragonWyrmling;
                case ID.BOAR: return Monsters.Boar;
                case ID.BONE_DEVIL: return Monsters.BoneDevil;
                case ID.BRASS_DRAGON_WYRMLING: return Monsters.BrassDragonWyrmling;
                case ID.BRONZE_DRAGON_WYRMLING: return Monsters.BronzeDragonWyrmling;
                case ID.BROWN_BEAR: return Monsters.BrownBear;
                case ID.BUGBEAR: return Monsters.Bugbear;
                case ID.BULETTE: return Monsters.Bulette;
                case ID.CAMEL: return Monsters.Camel;
                case ID.CAT: return Monsters.Cat;
                case ID.CENTAUR: return Monsters.Centaur;
                case ID.CHAIN_DEVIL: return Monsters.ChainDevil;
                case ID.CHIMERA: return Monsters.Chimera;
                case ID.CHUUL: return Monsters.Chuul;
                case ID.CLAY_GOLEM: return Monsters.ClayGolem;
                case ID.CLOAKER: return Monsters.Cloaker;
                case ID.CLOUD_GIANT: return Monsters.CloudGiant;
                case ID.COCKATRICE: return Monsters.Cockatrice;
                case ID.COMMONER: return Monsters.Commoner;
                case ID.CONSTRICTOR_SNAKE: return Monsters.ConstrictorSnake;
                case ID.COPPER_DRAGON_WYRMLING: return Monsters.CopperDragonWyrmling;
                case ID.COUATL: return Monsters.Couatl;
                case ID.CRAB: return Monsters.Crab;
                case ID.CROCODILE: return Monsters.Crocodile;
                case ID.CULT_FANATIC: return Monsters.CultFanatic;
                case ID.CULTIST: return Monsters.Cultist;
                case ID.DARKMANTLE: return Monsters.Darkmantle;
                case ID.DEATH_DOG: return Monsters.DeathDog;
                case ID.DEEP_GNOME__SVIRFNEBLIN: return Monsters.DeepGnomeSvirfneblin;
                case ID.DEER: return Monsters.Deer;
                case ID.DEVA: return Monsters.Deva;
                case ID.DIRE_WOLF: return Monsters.DireWolf;
                case ID.DJINNI: return Monsters.Djinni;
                case ID.DOPPELGANGER: return Monsters.Doppelganger;
                case ID.DRAFT_HORSE: return Monsters.DraftHorse;
                case ID.DRAGON_TURTLE: return Monsters.DragonTurtle;
                case ID.DRETCH: return Monsters.Dretch;
                case ID.DRIDER: return Monsters.Drider;
                case ID.DROW: return Monsters.Drow;
                case ID.DRUID: return Monsters.Druid;
                case ID.DRYAD: return Monsters.Dryad;
                case ID.DUERGAR: return Monsters.Duergar;
                case ID.DUST_MEPHIT: return Monsters.DustMephit;
                case ID.EAGLE: return Monsters.Eagle;
                case ID.EARTH_ELEMENTAL: return Monsters.EarthElemental;
                case ID.EFREETI: return Monsters.Efreeti;
                case ID.ELEPHANT: return Monsters.Elephant;
                case ID.ELK: return Monsters.Elk;
                case ID.ERINYES: return Monsters.Erinyes;
                case ID.ETTERCAP: return Monsters.Ettercap;
                case ID.ETTIN: return Monsters.Ettin;
                case ID.FIRE_ELEMENTAL: return Monsters.FireElemental;
                case ID.FIRE_GIANT: return Monsters.FireGiant;
                case ID.FLESH_GOLEM: return Monsters.FleshGolem;
                case ID.FLYING_SNAKE: return Monsters.FlyingSnake;
                case ID.FLYING_SWORD: return Monsters.FlyingSword;
                case ID.FROG: return Monsters.Frog;
                case ID.FROST_GIANT: return Monsters.FrostGiant;
                case ID.GARGOYLE: return Monsters.Gargoyle;
                case ID.GELATINOUS_CUBE: return Monsters.GelatinousCube;
                case ID.GHAST: return Monsters.Ghast;
                case ID.GHOST: return Monsters.Ghost;
                case ID.GHOUL: return Monsters.Ghoul;
                case ID.GIANT_APE: return Monsters.GiantApe;
                case ID.GIANT_BADGER: return Monsters.GiantBadger;
                case ID.GIANT_BAT: return Monsters.GiantBat;
                case ID.GIANT_BOAR: return Monsters.GiantBoar;
                case ID.GIANT_CENTIPEDE: return Monsters.GiantCentipede;
                case ID.GIANT_CONSTRICTOR_SNAKE: return Monsters.GiantConstrictorSnake;
                case ID.GIANT_CRAB: return Monsters.GiantCrab;
                case ID.GIANT_CROCODILE: return Monsters.GiantCrocodile;
                case ID.GIANT_EAGLE: return Monsters.GiantEagle;
                case ID.GIANT_ELK: return Monsters.GiantElk;
                case ID.GIANT_FIRE_BEETLE: return Monsters.GiantFireBeetle;
                case ID.GIANT_FROG: return Monsters.GiantFrog;
                case ID.GIANT_GOAT: return Monsters.GiantGoat;
                case ID.GIANT_HYENA: return Monsters.GiantHyena;
                case ID.GIANT_LIZARD: return Monsters.GiantLizard;
                case ID.GIANT_OCTOPUS: return Monsters.GiantOctopus;
                case ID.GIANT_OWL: return Monsters.GiantOwl;
                case ID.GIANT_POISONOUS_SNAKE: return Monsters.GiantPoisonousSnake;
                case ID.GIANT_RAT: return Monsters.GiantRat;
                case ID.GIANT_RAT__DISEASED: return Monsters.GiantRatDiseased;
                case ID.GIANT_SCORPION: return Monsters.GiantScorpion;
                case ID.GIANT_SEA_HORSE: return Monsters.GiantSeaHorse;
                case ID.GIANT_SHARK: return Monsters.GiantShark;
                case ID.GIANT_SPIDER: return Monsters.GiantSpider;
                case ID.GIANT_TOAD: return Monsters.GiantToad;
                case ID.GIANT_VULTURE: return Monsters.GiantVulture;
                case ID.GIANT_WASP: return Monsters.GiantWasp;
                case ID.GIANT_WEASEL: return Monsters.GiantWeasel;
                case ID.GIANT_WOLF_SPIDER: return Monsters.GiantWolfSpider;
                case ID.GIBBERING_MOUTHER: return Monsters.GibberingMouther;
                case ID.GLABREZU: return Monsters.Glabrezu;
                case ID.GLADIATOR: return Monsters.Gladiator;
                case ID.GNOLL: return Monsters.Gnoll;
                case ID.GOAT: return Monsters.Goat;
                case ID.GOBLIN: return Monsters.Goblin;
                case ID.GOLD_DRAGON_WYRMLING: return Monsters.GoldDragonWyrmling;
                case ID.GORGON: return Monsters.Gorgon;
                case ID.GRAY_OOZE: return Monsters.GrayOoze;
                case ID.GREEN_DRAGON_WYRMLING: return Monsters.GreenDragonWyrmling;
                case ID.GREEN_HAG: return Monsters.GreenHag;
                case ID.GRICK: return Monsters.Grick;
                case ID.GRIFFON: return Monsters.Griffon;
                case ID.GRIMLOCK: return Monsters.Grimlock;
                case ID.GUARD: return Monsters.Guard;
                case ID.GUARDIAN_NAGA: return Monsters.GuardianNaga;
                case ID.GYNOSPHINX: return Monsters.Gynosphinx;
                case ID.HALF_RED_DRAGON_VETERAN: return Monsters.HalfRedDragonVeteran;
                case ID.HARPY: return Monsters.Harpy;
                case ID.HAWK: return Monsters.Hawk;
                case ID.HELL_HOUND: return Monsters.HellHound;
                case ID.HEZROU: return Monsters.Hezrou;
                case ID.HILL_GIANT: return Monsters.HillGiant;
                case ID.HIPPOGRIFF: return Monsters.Hippogriff;
                case ID.HOBGOBLIN: return Monsters.Hobgoblin;
                case ID.HOMUNCULUS: return Monsters.Homunculus;
                case ID.HORNED_DEVIL: return Monsters.HornedDevil;
                case ID.HUNTER_SHARK: return Monsters.HunterShark;
                case ID.HYDRA: return Monsters.Hydra;
                case ID.HYENA: return Monsters.Hyena;
                case ID.ICE_DEVIL: return Monsters.IceDevil;
                case ID.ICE_MEPHIT: return Monsters.IceMephit;
                case ID.IMP: return Monsters.Imp;
                case ID.INVISIBLE_STALKER: return Monsters.InvisibleStalker;
                case ID.IRON_GOLEM: return Monsters.IronGolem;
                case ID.JACKAL: return Monsters.Jackal;
                case ID.KILLER_WHALE: return Monsters.KillerWhale;
                case ID.KNIGHT: return Monsters.Knight;
                case ID.KOBOLD: return Monsters.Kobold;
                case ID.KRAKEN: return Monsters.Kraken;
                case ID.LAMIA: return Monsters.Lamia;
                case ID.LEMURE: return Monsters.Lemure;
                case ID.LICH: return Monsters.Lich;
                case ID.LION: return Monsters.Lion;
                case ID.LIZARD: return Monsters.Lizard;
                case ID.LIZARDFOLK: return Monsters.Lizardfolk;
                case ID.MAGE: return Monsters.Mage;
                case ID.MAGMA_MEPHIT: return Monsters.MagmaMephit;
                case ID.MAGMIN: return Monsters.Magmin;
                case ID.MAMMOTH: return Monsters.Mammoth;
                case ID.MANTICORE: return Monsters.Manticore;
                case ID.MARILITH: return Monsters.Marilith;
                case ID.MASTIFF: return Monsters.Mastiff;
                case ID.MEDUSA: return Monsters.Medusa;
                case ID.MERFOLK: return Monsters.Merfolk;
                case ID.MERROW: return Monsters.Merrow;
                case ID.MIMIC: return Monsters.Mimic;
                case ID.MINOTAUR: return Monsters.Minotaur;
                case ID.MINOTAUR_SKELETON: return Monsters.MinotaurSkeleton;
                case ID.MULE: return Monsters.Mule;
                case ID.MUMMY: return Monsters.Mummy;
                case ID.MUMMY_LORD: return Monsters.MummyLord;
                case ID.NALFESHNEE: return Monsters.Nalfeshnee;
                case ID.NIGHT_HAG: return Monsters.NightHag;
                case ID.NIGHTMARE: return Monsters.Nightmare;
                case ID.NOBLE: return Monsters.Noble;
                case ID.OCHRE_JELLY: return Monsters.OchreJelly;
                case ID.OCTOPUS: return Monsters.Octopus;
                case ID.OGRE: return Monsters.Ogre;
                case ID.OGRE_ZOMBIE: return Monsters.OgreZombie;
                case ID.ONI: return Monsters.Oni;
                case ID.ORC: return Monsters.Orc;
                case ID.OTYUGH: return Monsters.Otyugh;
                case ID.OWL: return Monsters.Owl;
                case ID.OWLBEAR: return Monsters.Owlbear;
                case ID.PANTHER: return Monsters.Panther;
                case ID.PEGASUS: return Monsters.Pegasus;
                case ID.PHASE_SPIDER: return Monsters.PhaseSpider;
                case ID.PIT_FIEND: return Monsters.PitFiend;
                case ID.PLANETAR: return Monsters.Planetar;
                case ID.PLESIOSAURUS: return Monsters.Plesiosaurus;
                case ID.POISONOUS_SNAKE: return Monsters.PoisonousSnake;
                case ID.POLAR_BEAR: return Monsters.PolarBear;
                case ID.PONY: return Monsters.Pony;
                case ID.PRIEST: return Monsters.Priest;
                case ID.PSEUDODRAGON: return Monsters.Pseudodragon;
                case ID.PURPLE_WORM: return Monsters.PurpleWorm;
                case ID.QUASIT: return Monsters.Quasit;
                case ID.QUIPPER: return Monsters.Quipper;
                case ID.RAKSHASA: return Monsters.Rakshasa;
                case ID.RAT: return Monsters.Rat;
                case ID.RAVEN: return Monsters.Raven;
                case ID.RED_DRAGON_WYRMLING: return Monsters.RedDragonWyrmling;
                case ID.REEF_SHARK: return Monsters.ReefShark;
                case ID.REMORHAZ: return Monsters.Remorhaz;
                case ID.RHINOCEROS: return Monsters.Rhinoceros;
                case ID.RIDING_HORSE: return Monsters.RidingHorse;
                case ID.ROC: return Monsters.Roc;
                case ID.ROPER: return Monsters.Roper;
                case ID.RUG_OF_SMOTHERING: return Monsters.RugOfSmothering;
                case ID.RUST_MONSTER: return Monsters.RustMonster;
                case ID.SABER_TOOTHED_TIGER: return Monsters.SaberToothedTiger;
                case ID.SAHUAGIN: return Monsters.Sahuagin;
                case ID.SALAMANDER: return Monsters.Salamander;
                case ID.SATYR: return Monsters.Satyr;
                case ID.SCORPION: return Monsters.Scorpion;
                case ID.SCOUT: return Monsters.Scout;
                case ID.SEA_HAG: return Monsters.SeaHag;
                case ID.SEA_HORSE: return Monsters.SeaHorse;
                case ID.SHADOW: return Monsters.Shadow;
                case ID.SHAMBLING_MOUND: return Monsters.ShamblingMound;
                case ID.SHIELD_GUARDIAN: return Monsters.ShieldGuardian;
                case ID.SHRIEKER: return Monsters.Shrieker;
                case ID.SILVER_DRAGON_WYRMLING: return Monsters.SilverDragonWyrmling;
                case ID.SKELETON: return Monsters.Skeleton;
                case ID.SOLAR: return Monsters.Solar;
                case ID.SPECTER: return Monsters.Specter;
                case ID.SPIDER: return Monsters.Spider;
                case ID.SPIRIT_NAGA: return Monsters.SpiritNaga;
                case ID.SPRITE: return Monsters.Sprite;
                case ID.SPY: return Monsters.Spy;
                case ID.STEAM_MEPHIT: return Monsters.SteamMephit;
                case ID.STIRGE: return Monsters.Stirge;
                case ID.STONE_GIANT: return Monsters.StoneGiant;
                case ID.STONE_GOLEM: return Monsters.StoneGolem;
                case ID.STORM_GIANT: return Monsters.StormGiant;
                case ID.SUCCUBUS_INCUBUS: return Monsters.Succubus;
                case ID.SWARM_OF_BATS: return Monsters.SwarmOfBats;
                case ID.SWARM_OF_BEETLES: return Monsters.SwarmOfBeetles;
                case ID.SWARM_OF_CENTIPEDES: return Monsters.SwarmOfCentipedes;
                case ID.SWARM_OF_INSECTS: return Monsters.SwarmOfInsects;
                case ID.SWARM_OF_POISONOUS_SNAKES: return Monsters.SwarmOfPoisonousSnakes;
                case ID.SWARM_OF_QUIPPERS: return Monsters.SwarmOfQuippers;
                case ID.SWARM_OF_RATS: return Monsters.SwarmOfRats;
                case ID.SWARM_OF_RAVENS: return Monsters.SwarmOfRavens;
                case ID.SWARM_OF_SPIDERS: return Monsters.SwarmOfSpiders;
                case ID.SWARM_OF_WASPS: return Monsters.SwarmOfWasps;
                case ID.TARRASQUE: return Monsters.Tarrasque;
                case ID.THUG: return Monsters.Thug;
                case ID.TIGER: return Monsters.Tiger;
                case ID.TREANT: return Monsters.Treant;
                case ID.TRIBAL_WARRIOR: return Monsters.TribalWarrior;
                case ID.TRICERATOPS: return Monsters.Triceratops;
                case ID.TROLL: return Monsters.Troll;
                case ID.TYRANNOSAURUS_REX: return Monsters.TyrannosaurusRex;
                case ID.UNICORN: return Monsters.Unicorn;
                case ID.VAMPIRE_VAMPIRE_FORM: return Monsters.Vampire;
                case ID.VAMPIRE_BAT_FORM: return Monsters.VampireBatForm;
                case ID.VAMPIRE_MIST_FORM: return Monsters.VampireMistForm;
                case ID.VAMPIRE_SPAWN: return Monsters.VampireSpawn;
                case ID.VETERAN: return Monsters.Veteran;
                case ID.VIOLET_FUNGUS: return Monsters.VioletFungus;
                case ID.VROCK: return Monsters.Vrock;
                case ID.VULTURE: return Monsters.Vulture;
                case ID.WARHORSE: return Monsters.Warhorse;
                case ID.WARHORSE_SKELETON: return Monsters.WarhorseSkeleton;
                case ID.WATER_ELEMENTAL: return Monsters.WaterElemental;
                case ID.WEASEL: return Monsters.Weasel;
                case ID.WEREBEAR_BEAR_FORM: return Monsters.Werebear;
                case ID.WEREBEAR_HUMAN_FORM: return Monsters.WerebearHumanForm;
                case ID.WEREBEAR_HYBRID_FORM: return Monsters.WerebearHybridForm;
                case ID.WEREBOAR_BOAR_FORM: return Monsters.Wereboar;
                case ID.WEREBOAR_HUMAN_FORM: return Monsters.WereboarHumanForm;
                case ID.WEREBOAR_HYBRID_FORM: return Monsters.WereboarHybridForm;
                case ID.WERERAT_HUMAN_FORM: return Monsters.WereratHumanForm;
                case ID.WERERAT_HYBRID_FORM: return Monsters.WereratHybridForm;
                case ID.WERERAT_RAT_FORM: return Monsters.Wererat;
                case ID.WERETIGER_HUMAN_FORM: return Monsters.WeretigerHumanForm;
                case ID.WERETIGER_HYBRID_FORM: return Monsters.WeretigerHybridForm;
                case ID.WERETIGER_TIGER_FORM: return Monsters.Weretiger;
                case ID.WEREWOLF_HUMAN_FORM: return Monsters.WerewolfHumanForm;
                case ID.WEREWOLF_HYBRID_FORM: return Monsters.WerewolfHybridForm;
                case ID.WEREWOLF_WOLF_FORM: return Monsters.Werewolf;
                case ID.WHITE_DRAGON_WYRMLING: return Monsters.WhiteDragonWyrmling;
                case ID.WIGHT: return Monsters.Wight;
                case ID.WILL_O_WISP: return Monsters.WilloWisp;
                case ID.WINTER_WOLF: return Monsters.WinterWolf;
                case ID.WOLF: return Monsters.Wolf;
                case ID.WORG: return Monsters.Worg;
                case ID.WRAITH: return Monsters.Wraith;
                case ID.WYVERN: return Monsters.Wyvern;
                case ID.XORN: return Monsters.Xorn;
                case ID.YOUNG_BLACK_DRAGON: return Monsters.YoungBlackDragon;
                case ID.YOUNG_BLUE_DRAGON: return Monsters.YoungBlueDragon;
                case ID.YOUNG_BRASS_DRAGON: return Monsters.YoungBrassDragon;
                case ID.YOUNG_BRONZE_DRAGON: return Monsters.YoungBronzeDragon;
                case ID.YOUNG_COPPER_DRAGON: return Monsters.YoungCopperDragon;
                case ID.YOUNG_GOLD_DRAGON: return Monsters.YoungGoldDragon;
                case ID.YOUNG_GREEN_DRAGON: return Monsters.YoungGreenDragon;
                case ID.YOUNG_RED_DRAGON: return Monsters.YoungRedDragon;
                case ID.YOUNG_SILVER_DRAGON: return Monsters.YoungSilverDragon;
                case ID.YOUNG_WHITE_DRAGON: return Monsters.YoungWhiteDragon;
                case ID.ZOMBIE: return Monsters.Zombie;
            }
            throw new Srd5ArgumentException("Invalid monster ID");
        }
    }
}
namespace srd5 {
    public partial struct Attacks {
        public static readonly Attack EagleTalons = new Attack("Talons", 4, new Damage(DamageType.SLASHING, "1d4+2"), 5);
        public static readonly Attack EarthElementalSlam = new Attack("Slam", 8, new Damage(DamageType.BLUDGEONING, "2d8+5"), 10);
        public static readonly Attack EfreetiHurlFlame = new Attack("Hurl Flame", 7, new Damage(DamageType.FIRE, "5d6+0"), 5);
        public static readonly Attack EfreetiScimitar = new Attack("Scimitar", 10, new Damage(DamageType.SLASHING, "2d6+6"), 5, new Damage(DamageType.FIRE, "2d6"));
        public static readonly AttackEffect ElephantStompEffect = delegate (Combattant attacker, Combattant target) {
            if (!target.HasCondition(ConditionType.PRONE)) return;
            int amount = new Dices("3d10+6").Roll(); // FIXME: Cannot crit because attack roll is not available here
            target.TakeDamage(DamageType.BLUDGEONING, amount);
        };
        public static readonly Attack ElephantStomp = new Attack("Stomp", 8, new Damage(DamageType.BLUDGEONING, "1d2-2"), 5, null, ElephantStompEffect);
        public static readonly Attack ElephantGore = new Attack("Gore", 8, new Damage(DamageType.PIERCING, "3d8+6"), 5);
        public static readonly AttackEffect ElkHoovesEffect = delegate (Combattant attacker, Combattant target) {
            if (!target.HasCondition(ConditionType.PRONE)) return;
            int amount = new Dices("2d4+3").Roll(); // FIXME: Cannot crit because attack roll is not available here
            target.TakeDamage(DamageType.BLUDGEONING, amount);
        };
        public static readonly Attack ElkHooves = new Attack("Hooves", 5, new Damage(DamageType.BLUDGEONING, "1d2-2"), 5, null, ElkHoovesEffect);
        public static readonly Attack ElkRam = new Attack("Ram", 5, new Damage(DamageType.BLUDGEONING, "1d6+3"), 5);
        public static readonly Attack ErinyesLongsword = new Attack("Longsword", 8, new Damage(DamageType.SLASHING, "1d10+4"), 5, new Damage(DamageType.POISON, "3d8"));
        public static readonly AttackEffect ErinyesLongbowEffect = delegate (Combattant attacker, Combattant target) {
            if (target.IsImmune(DamageType.POISON)) return;
            bool success = target.DC(ErinyesLongbow, 14, AbilityType.CONSTITUTION);
            if (success) return;
            target.AddEffect(Effect.ERINYES_POISON);
        };
        public static readonly Attack ErinyesLongbow = new Attack("Longbow", 7, new Damage(DamageType.PIERCING, "1d8+3"), 5, new Damage(DamageType.POISON, "3d8"), ErinyesLongbowEffect);
        public static readonly AttackEffect EttercapBiteEffect = delegate (Combattant attacker, Combattant target) {
            if (target.IsImmune(DamageType.POISON)) return;
            bool succees = target.DC(EttercapBite, 11, AbilityType.CONSTITUTION);
            if (succees) return;
            target.AddEffect(Effect.ETTERCAP_POISON);
            int turn = 0;
            target.AddEndOfTurnEvent(delegate (Combattant combattant) {
                bool success = combattant.DC(EttercapBite, 11, AbilityType.CONSTITUTION);
                if ((turn++) > 10) succees = true;
                if (succees) target.RemoveEffect(Effect.ETTERCAP_POISON);
                return succees;
            });
        };
        public static readonly Attack EttercapBite = new Attack("Bite", 4, new Damage(DamageType.PIERCING, "1d8+2"), 5, new Damage(DamageType.POISON, "1d8"), EttercapBiteEffect);
        public static readonly AttackEffect EttercapWebEffect = delegate (Combattant attacker, Combattant target) {
            if (target.Size > Size.LARGE) return;
            if (target.HasEffect(Effect.IMMUNITY_RESTRAINED)) return;
            target.AddEffect(Effect.ETTERCAP_WEB);
            // TODO: As an action, the restrained creature can make a DC 11 Strength check, escaping from the webbing on a success.
            // TODO: The effect ends if the webbing is destroyed. The webbing has AC 10, 5 hit points, is vulnerable to fire damage and immune to bludgeoning damage.
        };
        public static readonly Attack EttercapWeb = new Attack("Web", 4, new Damage(DamageType.BLUDGEONING, "1d2-2"), 5, null, EttercapWebEffect);
        public static readonly Attack EttercapClaws = new Attack("Claws", 4, new Damage(DamageType.SLASHING, "2d4+2"), 5);
        public static readonly Attack EttinBattleaxe = new Attack("Battleaxe", 7, new Damage(DamageType.SLASHING, "2d8+5"), 5);
        public static readonly Attack EttinMorningstar = new Attack("Morningstar", 7, new Damage(DamageType.PIERCING, "2d8+5"), 5);
    }

    public partial struct Monsters {
        /* TODO */
        public static Monster Eagle {
            get {
                Monster eagle = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.EAGLE, Alignment.UNALIGNED, 6, 15, 10, 2, 14, 7, 12, "1d6", 40, 0,
                    new Attack[] { Attacks.EagleTalons }, new Attack[] { }, Size.SMALL
                );
                eagle.AddProficiency(Proficiency.PERCEPTION);
                eagle.AddFeat(Feat.KEEN_SIGHT);
                return eagle;
            }
        }

        /* TODO */
        public static Monster EarthElemental {
            get {
                Monster earthElemental = new Monster(
                    Monsters.Type.ELEMENTAL, Monsters.ID.EARTH_ELEMENTAL, Alignment.NEUTRAL, 20, 8, 20, 5, 10, 5, 17, "12d10+60", 40, 5,
                    new Attack[] { Attacks.EarthElementalSlam }, new Attack[] { }, Size.LARGE
                );
                earthElemental.AddEffect(Effect.VULNERABILITY_THUNDER);
                earthElemental.AddEffect(Effect.RESISTANCE_NONMAGIC);
                earthElemental.AddEffect(Effect.IMMUNITY_POISON);
                earthElemental.AddEffect(Effect.IMMUNITY_EXHAUSTION);
                earthElemental.AddEffect(Effect.IMMUNITY_PARALYZED);
                earthElemental.AddEffect(Effect.IMMUNITY_PETRIFIED);
                earthElemental.AddEffect(Effect.IMMUNITY_POISONED);
                earthElemental.AddEffect(Effect.IMMUNITY_UNCONSCIOUS);
                earthElemental.AddFeat(Feat.EARTH_GLIDE);
                earthElemental.AddFeat(Feat.SIEGE_MONSTER);
                return earthElemental;
            }
        }

        /* TODO */
        public static Monster Efreeti {
            get {
                Monster efreeti = new Monster(
                    Monsters.Type.ELEMENTAL, Monsters.ID.EFREETI, Alignment.LAWFUL_EVIL, 22, 12, 24, 16, 15, 16, 17, "16d10+112", 40, 11,
                    new Attack[] { Attacks.EfreetiScimitar }, new Attack[] { }, Size.LARGE
                );
                efreeti.AddProficiency(Proficiency.INTELLIGENCE);
                efreeti.AddProficiency(Proficiency.WISDOM);
                efreeti.AddProficiency(Proficiency.CHARISMA);
                efreeti.AddEffect(Effect.IMMUNITY_FIRE);
                efreeti.AddFeat(Feat.ELEMENTAL_DEMISE_EFREETI);
                efreeti.AddFeat(Feat.INNATE_SPELLCASTING_EFREETI);
                return efreeti;
            }
        }

        /* TODO */
        public static Monster Elephant {
            get {
                Monster elephant = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.ELEPHANT, Alignment.UNALIGNED, 22, 9, 17, 3, 11, 6, 12, "8d12+24", 40, 4,
                    new Attack[] { Attacks.ElephantGore, Attacks.ElephantStomp }, new Attack[] { }, Size.HUGE
                );
                elephant.AddFeat(Feat.TRAMPLING_CHARGE_ELEPHANT);
                return elephant;
            }
        }

        /* TODO */
        public static Monster Elk {
            get {
                Monster elk = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.ELK, Alignment.UNALIGNED, 16, 10, 12, 2, 10, 6, 10, "2d10+2", 40, ChallengeRating.QUARTER,
                    new Attack[] { Attacks.ElkRam, Attacks.ElkHooves }, new Attack[] { }, Size.LARGE
                );
                elk.AddFeat(Feat.CHARGE_ELK);
                return elk;
            }
        }

        /* TODO */
        public static Monster Erinyes {
            get {
                Monster erinyes = new Monster(
                    Monsters.Type.FIEND, Monsters.ID.ERINYES, Alignment.LAWFUL_EVIL, 18, 16, 18, 14, 14, 18, 18, "18d8+72", 40, 12,
                    new Attack[] { Attacks.ErinyesLongsword }, new Attack[] { }, Size.MEDIUM
                );
                erinyes.AddProficiency(Proficiency.DEXTERITY);
                erinyes.AddProficiency(Proficiency.CONSTITUTION);
                erinyes.AddProficiency(Proficiency.WISDOM);
                erinyes.AddProficiency(Proficiency.CHARISMA);
                erinyes.AddEffect(Effect.RESISTANCE_COLD);
                erinyes.AddEffect(Effect.RESISTANCE_NONMAGIC);
                erinyes.AddEffect(Effect.IMMUNITY_FIRE);
                erinyes.AddEffect(Effect.IMMUNITY_POISON);
                erinyes.AddEffect(Effect.IMMUNITY_POISONED);
                erinyes.AddFeat(Feat.HELLISH_WEAPONS);
                erinyes.AddFeat(Feat.MAGIC_RESISTANCE);
                return erinyes;
            }
        }

        /* TODO */
        public static Monster Ettercap {
            get {
                Monster ettercap = new Monster(
                    Monsters.Type.MONSTROSITY, Monsters.ID.ETTERCAP, Alignment.NEUTRAL_EVIL, 14, 15, 13, 7, 12, 8, 13, "8d8+8", 40, 2,
                    new Attack[] { Attacks.EttercapBite, Attacks.EttercapClaws }, new Attack[] { }, Size.MEDIUM
                );
                ettercap.AddProficiency(Proficiency.PERCEPTION);
                ettercap.AddProficiency(Proficiency.STEALTH);
                ettercap.AddProficiency(Proficiency.SURVIVAL);
                ettercap.AddFeat(Feat.SPIDER_CLIMB);
                ettercap.AddFeat(Feat.WEB_SENSE);
                ettercap.AddFeat(Feat.WEB_WALKER);
                return ettercap;
            }
        }

        /* TODO */
        public static Monster Ettin {
            get {
                Monster ettin = new Monster(
                    Monsters.Type.GIANT, Monsters.ID.ETTIN, Alignment.CHAOTIC_EVIL, 21, 8, 17, 6, 10, 8, 12, "10d10+30", 40, 4,
                    new Attack[] { Attacks.EttinBattleaxe, Attacks.EttinMorningstar }, new Attack[] { }, Size.LARGE
                );
                ettin.AddProficiency(Proficiency.PERCEPTION);
                ettin.AddFeat(Feat.TWO_HEADS);
                ettin.AddFeat(Feat.WAKEFUL);
                return ettin;
            }
        }

    }
}
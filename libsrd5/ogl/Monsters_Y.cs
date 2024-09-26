namespace srd5 {
    public partial struct Attacks {
        public static Attack YoungBlackDragonBite {
            get {
                return new Attack("Bite", 7, new Damage(DamageType.PIERCING, "2d10+4"), 10, new Damage(DamageType.ACID, "1d8"));
            }
        }
        public static Attack YoungBlackDragonClaw {
            get {
                return new Attack("Claw", 7, new Damage(DamageType.SLASHING, "2d6+4"), 5);
            }
        }
        public static Attack YoungBlueDragonBite {
            get {
                return new Attack("Bite", 9, new Damage(DamageType.PIERCING, "2d10+5"), 10, new Damage(DamageType.LIGHTNING, "1d10"));
            }
        }
        public static Attack YoungBlueDragonClaw {
            get {
                return new Attack("Claw", 9, new Damage(DamageType.SLASHING, "2d6+5"), 5);
            }
        }
        public static Attack YoungBrassDragonBite {
            get {
                return new Attack("Bite", 7, new Damage(DamageType.PIERCING, "2d10+4"), 10);
            }
        }
        public static Attack YoungBrassDragonClaw {
            get {
                return new Attack("Claw", 7, new Damage(DamageType.SLASHING, "2d6+4"), 5);
            }
        }
        public static Attack YoungBronzeDragonBite {
            get {
                return new Attack("Bite", 8, new Damage(DamageType.PIERCING, "2d10+5"), 10);
            }
        }
        public static Attack YoungBronzeDragonClaw {
            get {
                return new Attack("Claw", 8, new Damage(DamageType.SLASHING, "2d6+5"), 5);
            }
        }
        public static Attack YoungCopperDragonBite {
            get {
                return new Attack("Bite", 7, new Damage(DamageType.PIERCING, "2d10+4"), 10);
            }
        }
        public static Attack YoungCopperDragonClaw {
            get {
                return new Attack("Claw", 7, new Damage(DamageType.SLASHING, "2d6+4"), 5);
            }
        }
        public static Attack YoungGoldDragonBite {
            get {
                return new Attack("Bite", 10, new Damage(DamageType.PIERCING, "2d10+6"), 10);
            }
        }
        public static Attack YoungGoldDragonClaw {
            get {
                return new Attack("Claw", 10, new Damage(DamageType.SLASHING, "2d6+6"), 5);
            }
        }
        public static Attack YoungGreenDragonBite {
            get {
                return new Attack("Bite", 7, new Damage(DamageType.PIERCING, "2d10+4"), 10, new Damage(DamageType.POISON, "2d6"));
            }
        }
        public static Attack YoungGreenDragonClaw {
            get {
                return new Attack("Claw", 7, new Damage(DamageType.SLASHING, "2d6+4"), 5);
            }
        }
        public static Attack YoungRedDragonBite {
            get {
                return new Attack("Bite", 10, new Damage(DamageType.PIERCING, "2d10+6"), 10, new Damage(DamageType.FIRE, "1d6"));
            }
        }
        public static Attack YoungRedDragonClaw {
            get {
                return new Attack("Claw", 10, new Damage(DamageType.SLASHING, "2d6+6"), 5);
            }
        }
        public static Attack YoungSilverDragonBite {
            get {
                return new Attack("Bite", 10, new Damage(DamageType.PIERCING, "2d10+6"), 10);
            }
        }
        public static Attack YoungSilverDragonClaw {
            get {
                return new Attack("Claw", 10, new Damage(DamageType.SLASHING, "2d6+6"), 5);
            }
        }
        public static Attack YoungWhiteDragonBite {
            get {
                return new Attack("Bite", 7, new Damage(DamageType.PIERCING, "2d10+4"), 10, new Damage(DamageType.COLD, "1d8"));
            }
        }
        public static Attack YoungWhiteDragonClaw {
            get {
                return new Attack("Claw", 7, new Damage(DamageType.SLASHING, "2d6+4"), 5);
            }
        }
    }

    public partial struct Monsters {
        /* TODO */
        public static Monster YoungBlackDragon {
            get {
                Monster youngBlackDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.YOUNG_BLACK_DRAGON, Alignment.CHAOTIC_EVIL, 19, 14, 17, 12, 11, 15, 18, "15d10+45", 40, 7,
                    new Attack[] { Attacks.YoungBlackDragonBite, Attacks.YoungBlackDragonClaw }, new Attack[] { }, Size.LARGE
                );
                youngBlackDragon.AddProficiency(Proficiency.DEXTERITY);
                youngBlackDragon.AddProficiency(Proficiency.CONSTITUTION);
                youngBlackDragon.AddProficiency(Proficiency.WISDOM);
                youngBlackDragon.AddProficiency(Proficiency.CHARISMA);
                youngBlackDragon.AddProficiency(Proficiency.PERCEPTION);
                youngBlackDragon.AddProficiency(Proficiency.STEALTH);
                youngBlackDragon.AddEffect(Effect.IMMUNITY_ACID);
                youngBlackDragon.AddFeat(Feat.AMPHIBIOUS);
                return youngBlackDragon;
            }
        }

        /* TODO */
        public static Monster YoungBlueDragon {
            get {
                Monster youngBlueDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.YOUNG_BLUE_DRAGON, Alignment.LAWFUL_EVIL, 21, 10, 19, 14, 13, 17, 18, "16d10+64", 40, 9,
                    new Attack[] { Attacks.YoungBlueDragonBite, Attacks.YoungBlueDragonClaw }, new Attack[] { }, Size.LARGE
                );
                youngBlueDragon.AddProficiency(Proficiency.DEXTERITY);
                youngBlueDragon.AddProficiency(Proficiency.CONSTITUTION);
                youngBlueDragon.AddProficiency(Proficiency.WISDOM);
                youngBlueDragon.AddProficiency(Proficiency.CHARISMA);
                youngBlueDragon.AddProficiency(Proficiency.PERCEPTION);
                youngBlueDragon.AddProficiency(Proficiency.STEALTH);
                youngBlueDragon.AddEffect(Effect.IMMUNITY_LIGHTNING);
                return youngBlueDragon;
            }
        }

        /* TODO */
        public static Monster YoungBrassDragon {
            get {
                Monster youngBrassDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.YOUNG_BRASS_DRAGON, Alignment.CHAOTIC_GOOD, 19, 10, 17, 12, 11, 15, 17, "13d10+39", 40, 6,
                    new Attack[] { Attacks.YoungBrassDragonBite, Attacks.YoungBrassDragonClaw }, new Attack[] { }, Size.LARGE
                );
                youngBrassDragon.AddProficiency(Proficiency.DEXTERITY);
                youngBrassDragon.AddProficiency(Proficiency.CONSTITUTION);
                youngBrassDragon.AddProficiency(Proficiency.WISDOM);
                youngBrassDragon.AddProficiency(Proficiency.CHARISMA);
                youngBrassDragon.AddProficiency(Proficiency.PERCEPTION);
                youngBrassDragon.AddProficiency(Proficiency.PERSUASION);
                youngBrassDragon.AddProficiency(Proficiency.STEALTH);
                youngBrassDragon.AddEffect(Effect.IMMUNITY_FIRE);
                return youngBrassDragon;
            }
        }

        /* TODO */
        public static Monster YoungBronzeDragon {
            get {
                Monster youngBronzeDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.YOUNG_BRONZE_DRAGON, Alignment.LAWFUL_GOOD, 21, 10, 19, 14, 13, 17, 18, "15d10+60", 40, 8,
                    new Attack[] { Attacks.YoungBronzeDragonBite, Attacks.YoungBronzeDragonClaw }, new Attack[] { }, Size.LARGE
                );
                youngBronzeDragon.AddProficiency(Proficiency.DEXTERITY);
                youngBronzeDragon.AddProficiency(Proficiency.CONSTITUTION);
                youngBronzeDragon.AddProficiency(Proficiency.WISDOM);
                youngBronzeDragon.AddProficiency(Proficiency.CHARISMA);
                youngBronzeDragon.AddProficiency(Proficiency.INSIGHT);
                youngBronzeDragon.AddProficiency(Proficiency.PERCEPTION);
                youngBronzeDragon.AddProficiency(Proficiency.STEALTH);
                youngBronzeDragon.AddEffect(Effect.IMMUNITY_LIGHTNING);
                youngBronzeDragon.AddFeat(Feat.AMPHIBIOUS);
                return youngBronzeDragon;
            }
        }

        /* TODO */
        public static Monster YoungCopperDragon {
            get {
                Monster youngCopperDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.YOUNG_COPPER_DRAGON, Alignment.CHAOTIC_GOOD, 19, 12, 17, 16, 13, 15, 17, "14d10+42", 40, 7,
                    new Attack[] { Attacks.YoungCopperDragonBite, Attacks.YoungCopperDragonClaw }, new Attack[] { }, Size.LARGE
                );
                youngCopperDragon.AddProficiency(Proficiency.DEXTERITY);
                youngCopperDragon.AddProficiency(Proficiency.CONSTITUTION);
                youngCopperDragon.AddProficiency(Proficiency.WISDOM);
                youngCopperDragon.AddProficiency(Proficiency.CHARISMA);
                youngCopperDragon.AddProficiency(Proficiency.DECEPTION);
                youngCopperDragon.AddProficiency(Proficiency.PERCEPTION);
                youngCopperDragon.AddProficiency(Proficiency.STEALTH);
                youngCopperDragon.AddEffect(Effect.IMMUNITY_ACID);
                return youngCopperDragon;
            }
        }

        /* TODO */
        public static Monster YoungGoldDragon {
            get {
                Monster youngGoldDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.YOUNG_GOLD_DRAGON, Alignment.LAWFUL_GOOD, 23, 14, 21, 16, 13, 20, 18, "17d10+85", 40, 10,
                    new Attack[] { Attacks.YoungGoldDragonBite, Attacks.YoungGoldDragonClaw }, new Attack[] { }, Size.LARGE
                );
                youngGoldDragon.AddProficiency(Proficiency.DEXTERITY);
                youngGoldDragon.AddProficiency(Proficiency.CONSTITUTION);
                youngGoldDragon.AddProficiency(Proficiency.WISDOM);
                youngGoldDragon.AddProficiency(Proficiency.CHARISMA);
                youngGoldDragon.AddProficiency(Proficiency.INSIGHT);
                youngGoldDragon.AddProficiency(Proficiency.PERCEPTION);
                youngGoldDragon.AddProficiency(Proficiency.PERSUASION);
                youngGoldDragon.AddProficiency(Proficiency.STEALTH);
                youngGoldDragon.AddEffect(Effect.IMMUNITY_FIRE);
                youngGoldDragon.AddFeat(Feat.AMPHIBIOUS);
                return youngGoldDragon;
            }
        }

        /* TODO */
        public static Monster YoungGreenDragon {
            get {
                Monster youngGreenDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.YOUNG_GREEN_DRAGON, Alignment.LAWFUL_EVIL, 19, 12, 17, 16, 13, 15, 18, "16d10+48", 40, 8,
                    new Attack[] { Attacks.YoungGreenDragonBite, Attacks.YoungGreenDragonClaw }, new Attack[] { }, Size.LARGE
                );
                youngGreenDragon.AddProficiency(Proficiency.DEXTERITY);
                youngGreenDragon.AddProficiency(Proficiency.CONSTITUTION);
                youngGreenDragon.AddProficiency(Proficiency.WISDOM);
                youngGreenDragon.AddProficiency(Proficiency.CHARISMA);
                youngGreenDragon.AddProficiency(Proficiency.DECEPTION);
                youngGreenDragon.AddProficiency(Proficiency.PERCEPTION);
                youngGreenDragon.AddProficiency(Proficiency.STEALTH);
                youngGreenDragon.AddEffect(Effect.IMMUNITY_POISON);
                youngGreenDragon.AddEffect(Effect.IMMUNITY_POISONED);
                youngGreenDragon.AddFeat(Feat.AMPHIBIOUS);
                return youngGreenDragon;
            }
        }

        /* TODO */
        public static Monster YoungRedDragon {
            get {
                Monster youngRedDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.YOUNG_RED_DRAGON, Alignment.CHAOTIC_EVIL, 23, 10, 21, 14, 11, 19, 18, "17d10+85", 40, 10,
                    new Attack[] { Attacks.YoungRedDragonBite, Attacks.YoungRedDragonClaw }, new Attack[] { }, Size.LARGE
                );
                youngRedDragon.AddProficiency(Proficiency.DEXTERITY);
                youngRedDragon.AddProficiency(Proficiency.CONSTITUTION);
                youngRedDragon.AddProficiency(Proficiency.WISDOM);
                youngRedDragon.AddProficiency(Proficiency.CHARISMA);
                youngRedDragon.AddProficiency(Proficiency.PERCEPTION);
                youngRedDragon.AddProficiency(Proficiency.STEALTH);
                youngRedDragon.AddEffect(Effect.IMMUNITY_FIRE);
                return youngRedDragon;
            }
        }

        /* TODO */
        public static Monster YoungSilverDragon {
            get {
                Monster youngSilverDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.YOUNG_SILVER_DRAGON, Alignment.LAWFUL_GOOD, 23, 10, 21, 14, 11, 19, 18, "16d10+80", 40, 9,
                    new Attack[] { Attacks.YoungSilverDragonBite, Attacks.YoungSilverDragonClaw }, new Attack[] { }, Size.LARGE
                );
                youngSilverDragon.AddProficiency(Proficiency.DEXTERITY);
                youngSilverDragon.AddProficiency(Proficiency.CONSTITUTION);
                youngSilverDragon.AddProficiency(Proficiency.WISDOM);
                youngSilverDragon.AddProficiency(Proficiency.CHARISMA);
                youngSilverDragon.AddProficiency(Proficiency.ARCANA);
                youngSilverDragon.AddProficiency(Proficiency.HISTORY);
                youngSilverDragon.AddProficiency(Proficiency.PERCEPTION);
                youngSilverDragon.AddProficiency(Proficiency.STEALTH);
                youngSilverDragon.AddEffect(Effect.IMMUNITY_COLD);
                return youngSilverDragon;
            }
        }

        /* TODO */
        public static Monster YoungWhiteDragon {
            get {
                Monster youngWhiteDragon = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.YOUNG_WHITE_DRAGON, Alignment.CHAOTIC_EVIL, 18, 10, 18, 6, 11, 12, 17, "14d10+56", 40, 6,
                    new Attack[] { Attacks.YoungWhiteDragonBite, Attacks.YoungWhiteDragonClaw }, new Attack[] { }, Size.LARGE
                );
                youngWhiteDragon.AddProficiency(Proficiency.DEXTERITY);
                youngWhiteDragon.AddProficiency(Proficiency.CONSTITUTION);
                youngWhiteDragon.AddProficiency(Proficiency.WISDOM);
                youngWhiteDragon.AddProficiency(Proficiency.CHARISMA);
                youngWhiteDragon.AddProficiency(Proficiency.PERCEPTION);
                youngWhiteDragon.AddProficiency(Proficiency.STEALTH);
                youngWhiteDragon.AddEffect(Effect.IMMUNITY_COLD);
                youngWhiteDragon.AddFeat(Feat.ICE_WALK);
                return youngWhiteDragon;
            }
        }
    }
}
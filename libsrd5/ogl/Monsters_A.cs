namespace srd5 {
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
namespace srd5 {
    public partial struct Attacks {
        public static readonly Attack OchreJellyPseudopod = new Attack("Pseudopod", 4, new Damage(DamageType.BLUDGEONING, "2d6+2"), 5, new Damage(DamageType.ACID, "1d6"));
        public static readonly AttackEffect OctopusTentaclesEffect = delegate (Combattant attacker, Combattant target) {
            AttackEffects.GrapplingEffect(attacker, target, 10, Monsters.Octopus.Size++, false, Attacks.OctopusTentacles, 1);
        };
        public static readonly Attack OctopusTentacles = new Attack("Tentacles", 4, new Damage(DamageType.BLUDGEONING, 1), 5, null, OctopusTentaclesEffect);
        public static readonly AttackEffect OctopusInkCloudEffect = delegate (Combattant attacker, Combattant target) {
            // TODO: A 5-foot-radius cloud of ink extends all around the octopus if it is underwater. 
            // The area is heavily obscured for 1 minute, although a significant current can disperse the ink. 
            // After releasing the ink, the octopus can use the Dash action as a bonus action.
        };
        public static readonly Attack OctopusInkCloud = new Attack("Ink Cloud", 0, new Damage(DamageType.TRUE_DAMAGE, 0), 5, null, OctopusInkCloudEffect);
        public static readonly Attack OgreGreatclub = new Attack("Greatclub", 6, new Damage(DamageType.BLUDGEONING, "2d8+4"), 5);
        public static readonly Attack OgreJavelinMelee = new Attack("Javelin", 6, new Damage(DamageType.PIERCING, "2d6+4"), 5);
        public static readonly Attack OgreJavelinRanged = new Attack("Javelin", 6, new Damage(DamageType.PIERCING, "2d6+4"), 5, 30, 120);
        public static readonly Attack OgreZombieMorningstar = new Attack("Morningstar", 6, new Damage(DamageType.BLUDGEONING, "2d8+4"), 5);
        public static readonly Attack OniGlaive = new Attack("Glaive", 7, new Damage(DamageType.SLASHING, "2d10+4"), 5);
        public static readonly Attack OniClaw = new Attack("Claw", 7, new Damage(DamageType.SLASHING, "1d8+4"), 5);
        public static readonly Attack OrcGreataxe = new Attack("Greataxe", 5, new Damage(DamageType.SLASHING, "1d12+3"), 5);
        public static readonly Attack OrcJavelinMelee = new Attack("Javelin", 5, new Damage(DamageType.PIERCING, "1d6+3"), 5);
        public static readonly Attack OrcJavelinRanged = new Attack("Javelin", 5, new Damage(DamageType.PIERCING, "1d6+3"), 5, 30, 120);
        public static readonly AttackEffect OtyughBiteEffect = delegate (Combattant attacker, Combattant target) {
            bool success = target.DC(OtyughBite, 15, AbilityType.CONSTITUTION);
            if (success) return;
            target.AddEffect(Effect.OTYUGH_DISEASE);
        };
        public static readonly Attack OtyughBite = new Attack("Bite", 6, new Damage(DamageType.PIERCING, "2d8+3"), 5, null, OtyughBiteEffect);
        public static readonly AttackEffect OtyughTentacleEffect = delegate (Combattant attacker, Combattant target) {
            AttackEffects.GrapplingEffect(attacker, target, 13, Size.MEDIUM, true, null, 2);
        };
        public static readonly Attack OtyughTentacle = new Attack("Tentacle", 6, new Damage(DamageType.BLUDGEONING, "1d8+3"), 5, null, OtyughTentacleEffect);
        public static readonly Attack OwlTalons = new Attack("Talons", 3, new Damage(DamageType.SLASHING, 1), 5);
        public static readonly Attack OwlbearBeak = new Attack("Beak", 7, new Damage(DamageType.PIERCING, "1d10+5"), 5);
        public static readonly Attack OwlbearClaws = new Attack("Claws", 7, new Damage(DamageType.SLASHING, "2d8+5"), 5);
    }

    public partial struct Monsters {
        /* TODO */
        public static Monster OchreJelly {
            get {
                Monster ochreJelly = new Monster(
                    Monsters.Type.OOZE, Monsters.ID.OCHRE_JELLY, Alignment.UNALIGNED, 15, 6, 14, 2, 6, 1, 8, "6d10+12", 40, 2,
                    new Attack[] { Attacks.OchreJellyPseudopod }, new Attack[] { }, Size.LARGE
                );
                ochreJelly.AddEffect(Effect.RESISTANCE_ACID);
                ochreJelly.AddEffect(Effect.IMMUNITY_LIGHTNING);
                ochreJelly.AddEffect(Effect.IMMUNITY_SLASHING);
                ochreJelly.AddEffect(Effect.IMMUNITY_BLINDED);
                ochreJelly.AddEffect(Effect.IMMUNITY_CHARMED);
                ochreJelly.AddEffect(Effect.IMMUNITY_BLINDED);
                ochreJelly.AddEffect(Effect.IMMUNITY_EXHAUSTION);
                ochreJelly.AddEffect(Effect.IMMUNITY_FRIGHTENED);
                ochreJelly.AddEffect(Effect.IMMUNITY_PRONE);
                ochreJelly.AddFeat(Feat.AMORPHOUS);
                ochreJelly.AddFeat(Feat.SPIDER_CLIMB);
                return ochreJelly;
            }
        }

        /* TODO */
        public static Monster Octopus {
            get {
                Monster octopus = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.OCTOPUS, Alignment.UNALIGNED, 4, 15, 11, 3, 10, 4, 12, "1d6", 40, 0,
                    new Attack[] { }, new Attack[] { }, Size.SMALL
                );
                octopus.AddProficiency(Proficiency.PERCEPTION);
                octopus.AddProficiency(Proficiency.STEALTH);
                octopus.AddFeat(Feat.HOLD_BREATH_30MIN);
                octopus.AddFeat(Feat.UNDERWATER_CAMOUFLAGE);
                octopus.AddFeat(Feat.WATER_BREATHING);
                return octopus;
            }
        }

        /* TODO */
        public static Monster Ogre {
            get {
                Monster ogre = new Monster(
                    Monsters.Type.GIANT, Monsters.ID.OGRE, Alignment.CHAOTIC_EVIL, 19, 8, 16, 5, 7, 7, 11, "7d10+21", 40, 2,
                    new Attack[] { Attacks.OgreGreatclub, Attacks.OgreJavelinMelee }, new Attack[] { Attacks.OgreJavelinRanged }, Size.LARGE
                );
                return ogre;
            }
        }

        /* TODO */
        public static Monster OgreZombie {
            get {
                Monster ogreZombie = new Monster(
                    Monsters.Type.UNDEAD, Monsters.ID.OGRE_ZOMBIE, Alignment.NEUTRAL_EVIL, 19, 6, 18, 3, 6, 5, 8, "9d10+36", 40, 2,
                    new Attack[] { Attacks.OgreZombieMorningstar }, new Attack[] { }, Size.LARGE
                );
                ogreZombie.AddProficiency(Proficiency.WISDOM);
                ogreZombie.AddEffect(Effect.IMMUNITY_POISON);
                ogreZombie.AddEffect(Effect.IMMUNITY_POISONED);
                ogreZombie.AddFeat(Feat.UNDEAD_FORTITUDE);
                return ogreZombie;
            }
        }

        /* TODO */
        public static Monster Oni {
            get {
                Monster oni = new Monster(
                    Monsters.Type.GIANT, Monsters.ID.ONI, Alignment.LAWFUL_EVIL, 19, 11, 16, 14, 12, 15, 16, "13d10+39", 40, 7,
                    new Attack[] { Attacks.OniClaw, Attacks.OniGlaive }, new Attack[] { }, Size.LARGE
                );
                oni.AddProficiency(Proficiency.DEXTERITY);
                oni.AddProficiency(Proficiency.CONSTITUTION);
                oni.AddProficiency(Proficiency.WISDOM);
                oni.AddProficiency(Proficiency.CHARISMA);
                oni.AddProficiency(Proficiency.ARCANA);
                oni.AddProficiency(Proficiency.DECEPTION);
                oni.AddProficiency(Proficiency.PERCEPTION);
                oni.AddFeat(Feat.INNATE_SPELLCASTING_ONI);
                oni.AddFeat(Feat.MAGIC_WEAPONS);
                oni.AddFeat(Feat.REGENERATION);
                return oni;
            }
        }

        /* TODO */
        public static Monster Orc {
            get {
                Monster orc = new Monster(
                    Monsters.Type.HUMANOID, Monsters.ID.ORC, Alignment.CHAOTIC_EVIL, 16, 12, 16, 7, 11, 10, 13, "2d8+6", 40, ChallengeRating.HALF,
                    new Attack[] { Attacks.OrcGreataxe, Attacks.OrcJavelinMelee }, new Attack[] { Attacks.OrcJavelinRanged }, Size.MEDIUM
                );
                orc.AddProficiency(Proficiency.INTIMIDATION);
                orc.AddFeat(Feat.AGGRESSIVE);
                return orc;
            }
        }

        /* TODO */
        public static Monster Otyugh {
            get {
                Monster otyugh = new Monster(
                    Monsters.Type.ABERRATION, Monsters.ID.OTYUGH, Alignment.NEUTRAL, 16, 11, 19, 6, 13, 6, 14, "12d10+48", 40, 5,
                    new Attack[] { Attacks.OtyughBite, Attacks.OtyughTentacle }, new Attack[] { }, Size.LARGE
                );
                otyugh.AddProficiency(Proficiency.CONSTITUTION);
                otyugh.AddFeat(Feat.LIMITED_TELEPATHY_OTYUGH);
                return otyugh;
            }
        }

        /* TODO */
        public static Monster Owl {
            get {
                Monster owl = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.OWL, Alignment.UNALIGNED, 3, 13, 8, 2, 12, 7, 11, "1d4-1", 40, 0,
                    new Attack[] { }, new Attack[] { }, Size.TINY
                );
                owl.AddProficiency(Proficiency.PERCEPTION);
                owl.AddProficiency(Proficiency.STEALTH);
                owl.AddFeat(Feat.FLYBY);
                owl.AddFeat(Feat.KEEN_HEARING_AND_SIGHT);
                return owl;
            }
        }

        /* TODO */
        public static Monster Owlbear {
            get {
                Monster owlbear = new Monster(
                    Monsters.Type.MONSTROSITY, Monsters.ID.OWLBEAR, Alignment.UNALIGNED, 20, 12, 17, 3, 12, 7, 13, "7d10+21", 40, 3,
                    new Attack[] { Attacks.OwlbearBeak, Attacks.OwlbearClaws }, new Attack[] { }, Size.LARGE
                );
                owlbear.AddProficiency(Proficiency.PERCEPTION);
                owlbear.AddFeat(Feat.KEEN_SIGHT_AND_SMELL);
                return owlbear;
            }
        }
    }
}
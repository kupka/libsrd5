namespace srd5 {
    public partial struct Attacks {
        public static Attack NalfeshneeBite {
            get {
                return new Attack("Bite", 10, new Damage(DamageType.PIERCING, "5d10+5"), 5);
            }
        }
        public static Attack NalfeshneeClaw {
            get {
                return new Attack("Claw", 10, new Damage(DamageType.SLASHING, "3d6+5"), 10);
            }
        }
        public static Attack NightHagClaws {
            get {
                return new Attack("Claws", 7, new Damage(DamageType.SLASHING, "2d8+4"), 5);
            }
        }
        public static Attack NightmareHooves {
            get {
                return new Attack("Hooves", 6, new Damage(DamageType.BLUDGEONING, "2d8+4"), 5, new Damage(DamageType.FIRE, "2d6"));
            }
        }
        public static Attack NobleRapier {
            get {
                return new Attack("Rapier", 3, new Damage(DamageType.PIERCING, "1d8+1"), 5);
            }
        }
    }

    public partial struct Monsters {
        /* TODO */
        public static Monster Nalfeshnee {
            get {
                Monster nalfeshnee = new Monster(
                    Monsters.Type.FIEND, Monsters.ID.NALFESHNEE, Alignment.CHAOTIC_EVIL, 21, 10, 22, 19, 12, 15, 18, "16d10+96", 40, 13,
                    new Attack[] { Attacks.NalfeshneeBite, Attacks.NalfeshneeClaw }, new Attack[] { }, Size.LARGE
                );
                nalfeshnee.AddProficiency(Proficiency.CONSTITUTION);
                nalfeshnee.AddProficiency(Proficiency.INTELLIGENCE);
                nalfeshnee.AddProficiency(Proficiency.WISDOM);
                nalfeshnee.AddProficiency(Proficiency.CHARISMA);
                nalfeshnee.AddEffect(Effect.RESISTANCE_COLD);
                nalfeshnee.AddEffect(Effect.RESISTANCE_FIRE);
                nalfeshnee.AddEffect(Effect.RESISTANCE_LIGHTNING);
                nalfeshnee.AddEffect(Effect.RESISTANCE_NONMAGIC);
                nalfeshnee.AddEffect(Effect.IMMUNITY_POISON);
                nalfeshnee.AddEffect(Effect.IMMUNITY_POISONED);
                nalfeshnee.AddFeat(Feat.MAGIC_RESISTANCE);
                return nalfeshnee;
            }
        }

        /* TODO */
        public static Monster NightHag {
            get {
                Monster nightHag = new Monster(
                    Monsters.Type.FIEND, Monsters.ID.NIGHT_HAG, Alignment.NEUTRAL_EVIL, 18, 15, 16, 16, 14, 16, 17, "15d8+45", 40, 5,
                    new Attack[] { Attacks.NightHagClaws }, new Attack[] { }, Size.MEDIUM
                );
                nightHag.AddProficiency(Proficiency.DECEPTION);
                nightHag.AddProficiency(Proficiency.INSIGHT);
                nightHag.AddProficiency(Proficiency.PERCEPTION);
                nightHag.AddProficiency(Proficiency.STEALTH);
                nightHag.AddEffect(Effect.RESISTANCE_COLD);
                nightHag.AddEffect(Effect.RESISTANCE_FIRE);
                nightHag.AddEffect(Effect.RESISTANCE_NONMAGIC);
                nightHag.AddEffect(Effect.IMMUNITY_CHARMED);
                nightHag.AddFeat(Feat.INNATE_SPELLCASTING_NIGHT_HAG);
                nightHag.AddFeat(Feat.MAGIC_RESISTANCE);
                nightHag.AddFeat(Feat.NIGHT_HAG_ITEMS);

                AvailableSpells spells = new AvailableSpells(AbilityType.CHARISMA);
                spells.AddKnownSpell(Spells.MagicMissile, Spells.DetectMagic, Spells.PlaneShift, Spells.RayofEnfeeblement, Spells.Sleep);
                nightHag.AddAvailableSpells(spells);
                nightHag.AddInnateSpellcasting(
                    new InnateSpellcasting(Spells.MagicMissile, InnateSpellcasting.Frequencies.AT_WILL),
                    new InnateSpellcasting(Spells.DetectMagic, InnateSpellcasting.Frequencies.AT_WILL),
                    new InnateSpellcasting(Spells.PlaneShift, InnateSpellcasting.Frequencies.TWICE_PER_DAY),
                    new InnateSpellcasting(Spells.RayofEnfeeblement, InnateSpellcasting.Frequencies.TWICE_PER_DAY),
                    new InnateSpellcasting(Spells.Sleep, InnateSpellcasting.Frequencies.TWICE_PER_DAY)
                );
                return nightHag;
            }
        }

        /* TODO */
        public static Monster Nightmare {
            get {
                Monster nightmare = new Monster(
                    Monsters.Type.FIEND, Monsters.ID.NIGHTMARE, Alignment.NEUTRAL_EVIL, 18, 15, 16, 10, 13, 15, 13, "8d10+24", 40, 3,
                    new Attack[] { Attacks.NightmareHooves }, new Attack[] { }, Size.LARGE
                );
                nightmare.AddEffect(Effect.IMMUNITY_FIRE);
                nightmare.AddFeat(Feat.CONFER_FIRE_RESISTANCE);
                nightmare.AddFeat(Feat.ILLUMINATION_10FT);
                return nightmare;
            }
        }

        /* TODO */
        public static Monster Noble {
            get {
                Monster noble = new Monster(
                    Monsters.Type.HUMANOID, Monsters.ID.NOBLE, Alignment.UNALIGNED, 11, 12, 11, 12, 14, 16, 15, "2d8", 40, ChallengeRating.EIGHTH,
                    new Attack[] { Attacks.NobleRapier }, new Attack[] { }, Size.MEDIUM
                );
                noble.AddProficiency(Proficiency.DECEPTION);
                noble.AddProficiency(Proficiency.INSIGHT);
                noble.AddProficiency(Proficiency.PERSUASION);
                return noble;
            }
        }
    }
}

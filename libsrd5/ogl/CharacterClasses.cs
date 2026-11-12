namespace srd5 {
    public enum Class {
        BARBARIAN,
        BARD,
        CLERIC,
        DRUID,
        FIGHTER,
        MONK,
        PALADIN,
        RANGER,
        ROGUE,
        SORCEROR,
        WARLOCK,
        WIZARD
    }
    public class CharacterClasses {
        public static CharacterClass Barbarian {
            get {
                CharacterClass barbarian = new CharacterClass();
                barbarian.Class = Class.BARBARIAN;
                barbarian.HitDie = 12;
                barbarian.Proficiencies = new Proficiency[]{
                                Proficiency.STRENGTH,
                                Proficiency.CONSTITUTION,
                                Proficiency.LIGHT_ARMOR,
                                Proficiency.MEDIUM_ARMOR,
                                Proficiency.SHIELDS,
                                Proficiency.SIMPLE_MELEE_WEAPONS,
                                Proficiency.SIMPLE_RANGED_WEAPONS,
                                Proficiency.MARTIAL_MELEE_WEAPONS,
                                Proficiency.MARTIAL_RANGED_WEAPONS
                            };
                barbarian.Feats = new Feat[][] {
                    new Feat[] { Feat.RAGE, Feat.BARBARIAN_UNARMORED_DEFENSE },
                    new Feat[] { Feat.RECKLESS_ATTACK, Feat.DANGER_SENSE },
                    new Feat[] { Feat.PRIMAL_PATH, Feat.FRENZY },
                    new Feat[] { Feat.ABILITY_SCORE_IMPROVEMENT },
                    new Feat[] { Feat.EXTRA_ATTACK, Feat.FAST_MOVEMENT },
                    new Feat[] { Feat.MINDLESS_RAGE, Feat.PRIMAL_PATH },
                    new Feat[] { Feat.FERAL_INSTINCT },
                    new Feat[] { Feat.ABILITY_SCORE_IMPROVEMENT },
                    new Feat[] { Feat.BRUTAL_CRITICAL },
                    new Feat[] { Feat.INTIMIDATING_PRESENCE, Feat.PRIMAL_PATH },
                    new Feat[] { Feat.RELENTLESS_RAGE },
                    new Feat[] { Feat.ABILITY_SCORE_IMPROVEMENT },
                    new Feat[] { Feat.BRUTAL_CRITICAL },
                    new Feat[] { Feat.RETALIATION, Feat.PRIMAL_PATH },
                    new Feat[] { Feat.PERSISTENT_RAGE },
                    new Feat[] { Feat.ABILITY_SCORE_IMPROVEMENT },
                    new Feat[] { Feat.BRUTAL_CRITICAL },
                    new Feat[] { Feat.INDOMITABLE_MIGHT },
                    new Feat[] { Feat.ABILITY_SCORE_IMPROVEMENT },
                    new Feat[] { Feat.PRIMAL_CHAMPION },
                };
                return barbarian;
            }
        }

        public static CharacterClass Druid {
            get {
                CharacterClass druid = new CharacterClass();
                druid.Class = Class.DRUID;
                druid.HitDie = 8;
                druid.Proficiencies = new Proficiency[]{
                                Proficiency.INTELLIGENCE,
                                Proficiency.WISDOM,
                                Proficiency.CLUB,
                                Proficiency.DAGGER,
                                Proficiency.DARTS,
                                Proficiency.JAVELIN,
                                Proficiency.MACE,
                                Proficiency.QUARTERSTAFF,
                                Proficiency.SCIMITAR,
                                Proficiency.SICKLE,
                                Proficiency.SLING,
                                Proficiency.SPEAR,
                                Proficiency.HERBALISM_KIT,
                                Proficiency.LIGHT_ARMOR,
                                Proficiency.MEDIUM_ARMOR,
                                Proficiency.SHIELDS
                            };
                druid.Feats = new Feat[][] {
                    new Feat[] { Feat.DRUID_SPELLCASTING, Feat.DRUIDIC },
                    new Feat[] { Feat.WILD_SHAPE, Feat.DRUID_CIRCLE, Feat.CIRCLE_OF_THE_LAND, Feat.BONUS_CANTRIP, Feat.NATURAL_RECOVERY },
                    new Feat[] { Feat.CIRCLE_SPELLS },
                    new Feat[] { Feat.WILD_SHAPE, Feat.ABILITY_SCORE_IMPROVEMENT },
                    new Feat[] { Feat.CIRCLE_SPELLS },
                    new Feat[] { Feat.DRUID_CIRCLE, Feat.DRUID_LANDS_STRIDE },
                    new Feat[] { Feat.CIRCLE_SPELLS },
                    new Feat[] { Feat.WILD_SHAPE, Feat.ABILITY_SCORE_IMPROVEMENT },
                    new Feat[] { Feat.CIRCLE_SPELLS },
                    new Feat[] { Feat.DRUID_CIRCLE, Feat.NATURES_WARD },
                    new Feat[] { },
                    new Feat[] { Feat.ABILITY_SCORE_IMPROVEMENT },
                    new Feat[] { },
                    new Feat[] { Feat.DRUID_CIRCLE, Feat.NATURES_SANCTUARY },
                    new Feat[] { },
                    new Feat[] { Feat.ABILITY_SCORE_IMPROVEMENT },
                    new Feat[] { },
                    new Feat[] { Feat.DRUID_TIMELESS_BODY, Feat.BEAST_SPELLS },
                    new Feat[] { Feat.ABILITY_SCORE_IMPROVEMENT },
                    new Feat[] { Feat.ARCHDRUID },
                };
                druid.SpellCastingAbility = AbilityType.WISDOM;
                druid.KnownSpellsLimit = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
                druid.SpellSlots = new int[][] {
                    new int[]{ 2, 2, 0, 0, 0, 0, 0, 0, 0, 0},
                    new int[]{ 2, 3, 0, 0, 0, 0, 0, 0, 0, 0},
                    new int[]{ 2, 4, 2, 0, 0, 0, 0, 0, 0, 0},
                    new int[]{ 3, 4, 3, 0, 0, 0, 0, 0, 0, 0},
                    new int[]{ 3, 4, 3, 2, 0, 0, 0, 0, 0, 0},
                    new int[]{ 3, 4, 3, 3, 0, 0, 0, 0, 0, 0},
                    new int[]{ 3, 4, 3, 3, 1, 0, 0, 0, 0, 0},
                    new int[]{ 3, 4, 3, 3, 2, 0, 0, 0, 0, 0},
                    new int[]{ 3, 4, 3, 3, 3, 1, 0, 0, 0, 0},
                    new int[]{ 3, 4, 3, 3, 3, 2, 0, 0, 0, 0},
                    new int[]{ 3, 4, 3, 3, 3, 2, 1, 0, 0, 0},
                    new int[]{ 3, 4, 3, 3, 3, 2, 1, 0, 0, 0},
                    new int[]{ 3, 4, 3, 3, 3, 2, 1, 1, 0, 0},
                    new int[]{ 3, 4, 3, 3, 3, 2, 1, 1, 0, 0},
                    new int[]{ 3, 4, 3, 3, 3, 2, 1, 1, 1, 0},
                    new int[]{ 3, 4, 3, 3, 3, 2, 1, 1, 1, 0},
                    new int[]{ 3, 4, 3, 3, 3, 2, 1, 1, 1, 1},
                    new int[]{ 3, 4, 3, 3, 3, 3, 1, 1, 1, 1},
                    new int[]{ 3, 4, 3, 3, 3, 3, 2, 1, 1, 1},
                    new int[]{ 3, 4, 3, 3, 3, 3, 2, 2, 1, 1}
                };
                druid.MustPrepareSpells = true;
                return druid;
            }
        }

        public static CharacterClass Wizard {
            get {
                CharacterClass wizard = new CharacterClass();
                wizard.Class = Class.WIZARD;
                wizard.HitDie = 6;
                wizard.Proficiencies = new Proficiency[]{
                                Proficiency.INTELLIGENCE,
                                Proficiency.WISDOM,
                                Proficiency.DAGGER,
                                Proficiency.DARTS,
                                Proficiency.QUARTERSTAFF,
                                Proficiency.SLING,
                                Proficiency.CROSSBOW_LIGHT
                            };
                wizard.Feats = new Feat[][] {
                    new Feat[] { Feat.WIZARD_SPELLCASTING, Feat.ARCANE_RECOVERY },
                    new Feat[] { Feat.ARCANE_TRADITION, Feat.EVOCATION_SAVANT, Feat.SCULPT_SPELLS },
                    new Feat[] { },
                    new Feat[] { Feat.ABILITY_SCORE_IMPROVEMENT },
                    new Feat[] { },
                    new Feat[] { Feat.ARCANE_TRADITION, Feat.POTENT_CANTRIP },
                    new Feat[] { },
                    new Feat[] { Feat.ABILITY_SCORE_IMPROVEMENT },
                    new Feat[] { },
                    new Feat[] { Feat.ARCANE_TRADITION, Feat.EMPOWERED_EVOCATION },
                    new Feat[] { },
                    new Feat[] { Feat.ABILITY_SCORE_IMPROVEMENT },
                    new Feat[] { },
                    new Feat[] { Feat.ARCANE_TRADITION, Feat.OVERCHANNEL },
                    new Feat[] { },
                    new Feat[] { Feat.ABILITY_SCORE_IMPROVEMENT },
                    new Feat[] { },
                    new Feat[] { Feat.SPELL_MASTERY },
                    new Feat[] { Feat.ABILITY_SCORE_IMPROVEMENT },
                    new Feat[] { Feat.SIGNATURE_SPELL },
                };
                wizard.SpellCastingAbility = AbilityType.INTELLIGENCE;
                wizard.KnownSpellsLimit = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
                wizard.SpellSlots = new int[][] {
                    new int[]{ 3, 2, 0, 0, 0, 0, 0, 0, 0, 0},
                    new int[]{ 3, 3, 0, 0, 0, 0, 0, 0, 0, 0},
                    new int[]{ 3, 4, 2, 0, 0, 0, 0, 0, 0, 0},
                    new int[]{ 4, 4, 3, 0, 0, 0, 0, 0, 0, 0},
                    new int[]{ 4, 4, 3, 2, 0, 0, 0, 0, 0, 0},
                    new int[]{ 4, 4, 3, 3, 0, 0, 0, 0, 0, 0},
                    new int[]{ 4, 4, 3, 3, 1, 0, 0, 0, 0, 0},
                    new int[]{ 4, 4, 3, 3, 2, 0, 0, 0, 0, 0},
                    new int[]{ 4, 4, 3, 3, 3, 1, 0, 0, 0, 0},
                    new int[]{ 5, 4, 3, 3, 3, 2, 0, 0, 0, 0},
                    new int[]{ 5, 4, 3, 3, 3, 2, 1, 0, 0, 0},
                    new int[]{ 5, 4, 3, 3, 3, 2, 1, 0, 0, 0},
                    new int[]{ 5, 4, 3, 3, 3, 2, 1, 1, 0, 0},
                    new int[]{ 5, 4, 3, 3, 3, 2, 1, 1, 0, 0},
                    new int[]{ 5, 4, 3, 3, 3, 2, 1, 1, 1, 0},
                    new int[]{ 5, 4, 3, 3, 3, 2, 1, 1, 1, 0},
                    new int[]{ 5, 4, 3, 3, 3, 2, 1, 1, 1, 1},
                    new int[]{ 5, 4, 3, 3, 3, 3, 1, 1, 1, 1},
                    new int[]{ 5, 4, 3, 3, 3, 3, 2, 1, 1, 1},
                    new int[]{ 5, 4, 3, 3, 3, 3, 2, 2, 1, 1}
                };
                wizard.MustPrepareSpells = true;
                return wizard;
            }
        }

        public static CharacterClass Bard {
            get {
                // TODO: Implement Bard
                CharacterClass bard = new CharacterClass();
                bard.Class = Class.BARD;
                bard.HitDie = 8;
                bard.Proficiencies = new Proficiency[] { };
                bard.Feats = new Feat[][] {
                    new Feat[] { },
                    new Feat[] { },
                    new Feat[] { },
                    new Feat[] { },
                    new Feat[] { },
                    new Feat[] { },
                    new Feat[] { },
                    new Feat[] { },
                    new Feat[] { },
                    new Feat[] { },
                    new Feat[] { },
                    new Feat[] { },
                    new Feat[] { },
                    new Feat[] { },
                    new Feat[] { },
                    new Feat[] { },
                    new Feat[] { },
                    new Feat[] { },
                    new Feat[] { },
                    new Feat[] { },
                };
                return bard;
            }
        }
    }
}
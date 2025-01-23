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
                    new Feat[]{ Feat.RAGE, Feat.UNARMORED_DEFENSE },
                    new Feat[]{ Feat.RECKLESS_ATTACK, Feat.DANGER_SENSE },
                    new Feat[]{ Feat.FRENZY },
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
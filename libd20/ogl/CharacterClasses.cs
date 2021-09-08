namespace d20 {
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
                barbarian.HitDice = 12;
                barbarian.Proficiencies = new Proficiency[]{
                                Proficiency.LIGHT_ARMOR,
                                Proficiency.MEDIUM_ARMOR,
                                Proficiency.SHIELDS,
                                Proficiency.SIMPLE_MELEE_WEAPONS,
                                Proficiency.SIMPLE_RANGED_WEAPONS,
                                Proficiency.MARTIAL_MELEE_WEAPONS,
                                Proficiency.MARTIAL_RANGED_WEAPONS
                            };
                return barbarian;
            }
        }

        public static CharacterClass Druid {
            get {
                CharacterClass druid = new CharacterClass();
                druid.Class = Class.DRUID;
                druid.HitDice = 8;
                druid.Proficiencies = new Proficiency[]{
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
                return druid;
            }
        }
    }
}
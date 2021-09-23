using System;

namespace srd5 {
    public enum Skill {
        ATHLETICS,
        ACROBATICS,
        SLEIGHT_OF_HAND,
        STEALTH,
        ARCANA,
        HISTORY,
        INVESTIGATION,
        NATURE,
        RELIGION,
        ANIMAL_HANDLING,
        INSIGHT,
        MEDICINE,
        PERCEPTION,
        SURVIVAL,
        DECEPTION,
        INTIMIDATION,
        PERFORMANCE,
        PERSUASION
    }

    public static class SkillExtension {
        public static AbilityType Ability(this Skill skill) {
            switch (skill) {
                case Skill.ATHLETICS:
                    return AbilityType.STRENGTH;
                case Skill.ACROBATICS:
                case Skill.SLEIGHT_OF_HAND:
                case Skill.STEALTH:
                    return AbilityType.DEXTERITY;
                case Skill.ARCANA:
                case Skill.HISTORY:
                case Skill.INVESTIGATION:
                case Skill.NATURE:
                case Skill.RELIGION:
                    return AbilityType.INTELLIGENCE;
                case Skill.ANIMAL_HANDLING:
                case Skill.INSIGHT:
                case Skill.MEDICINE:
                case Skill.PERCEPTION:
                case Skill.SURVIVAL:
                    return AbilityType.WISDOM;
                case Skill.DECEPTION:
                case Skill.INTIMIDATION:
                case Skill.PERFORMANCE:
                case Skill.PERSUASION:
                default:
                    return AbilityType.CHARISMA;
            }
        }

        public static Proficiency Proficiency(this Skill skill) {
            return (Proficiency)Enum.Parse(typeof(Proficiency), skill.ToString());
        }

    }
}
namespace d20 {
    public enum SkillType {
        ATHLETICS,
        ACROBATICS,
        SLIGHT_OF_HAND,
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
    public struct Skills {
        public static readonly Skill Athletics = new Skill(SkillType.ATHLETICS, AbilityType.STRENGTH);
        public static readonly Skill Acrobatics = new Skill(SkillType.ACROBATICS, AbilityType.DEXTERITY);
        public static readonly Skill SlightOfHand = new Skill(SkillType.SLIGHT_OF_HAND, AbilityType.DEXTERITY);
        public static readonly Skill Stealth = new Skill(SkillType.STEALTH, AbilityType.DEXTERITY);
        public static readonly Skill Arcana = new Skill(SkillType.ARCANA, AbilityType.INTELLIGENCE);
        public static readonly Skill History = new Skill(SkillType.HISTORY, AbilityType.INTELLIGENCE);
        public static readonly Skill Investigation = new Skill(SkillType.INVESTIGATION, AbilityType.INTELLIGENCE);
        public static readonly Skill Nature = new Skill(SkillType.NATURE, AbilityType.INTELLIGENCE);
        public static readonly Skill Religion = new Skill(SkillType.RELIGION, AbilityType.INTELLIGENCE);
        public static readonly Skill AnimalHandling = new Skill(SkillType.ANIMAL_HANDLING, AbilityType.WISDOM);
        public static readonly Skill Insight = new Skill(SkillType.INSIGHT, AbilityType.WISDOM);
        public static readonly Skill Medicine = new Skill(SkillType.MEDICINE, AbilityType.WISDOM);
        public static readonly Skill Perception = new Skill(SkillType.PERCEPTION, AbilityType.WISDOM);
        public static readonly Skill Survival = new Skill(SkillType.SURVIVAL, AbilityType.WISDOM);
        public static readonly Skill Deception = new Skill(SkillType.DECEPTION, AbilityType.CHARISMA);
        public static readonly Skill Intimidation = new Skill(SkillType.INTIMIDATION, AbilityType.CHARISMA);
        public static readonly Skill Performance = new Skill(SkillType.PERFORMANCE, AbilityType.CHARISMA);
        public static readonly Skill Persuasion = new Skill(SkillType.PERSUASION, AbilityType.CHARISMA);
    }
}
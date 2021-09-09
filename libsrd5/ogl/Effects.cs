namespace srd5 {
    public enum Effect {
        // Resistances against d20.DamageType
        RESISTANCE_POISON,

        // Immunities against d20.Condition
        IMMUNITY_SLEEP,

        // Advantage on Save Throws
        ADVANTAGE_SAVE_POISON,
        ADVANTAGE_SAVE_CHARM,

        // Attack modifiers
        ADVANTAGE_ON_ATTACK,
        DISADVANTAGE_ON_ATTACK,
        ADVANTAGE_ON_BEING_ATTACKED,
        DISADVANTAGE_ON_BEING_ATTACKED,
        AUTOMATIC_CRIT_ON_ATTACK,
        AUTOMATIC_CRIT_ON_BEING_ATTACKED,

        // Misc./Special
        DOUBLE_PROFICIENCY_BONUS_HISTORY,
        ADDITIONAL_HP_PER_LEVEL,
        DARKVISION,

    }
}
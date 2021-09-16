namespace srd5 {
    public enum Effect {
        // Resistances against DamageType
        RESISTANCE_POISON,
        RESISTANCE_COLD,

        // Immunities against Condition
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
        ONE_EXTRA_ATTACK,
        TWO_EXTRA_ATTACKS,
        THREE_EXTRA_ATTACKS,
        // Movement
        NO_SPEED_PENALITY_FOR_HEAVY_ARMOR,
        HEAVY_ARMOR_SPEED_PENALITY,
        SWIMMING_SPEED_40,
        IGNORE_SNOW_PENALITY,

        // Abilities
        CONSTITUION_19,
        INTELLIGENCE_19,


        // Misc./Special
        DOUBLE_PROFICIENCY_BONUS_HISTORY,
        ADDITIONAL_HP_PER_LEVEL,
        DARKVISION,
        PROTECTION
    }

    public static class EffectExtension {
        public static void Apply(this Effect effect, Combattant combattant) {
            switch (effect) {
                case Effect.HEAVY_ARMOR_SPEED_PENALITY:
                    combattant.Speed -= 10;
                    break;
                case Effect.CONSTITUION_19:
                case Effect.INTELLIGENCE_19:
                    applyAbilityEffect(effect, combattant);
                    break;
                case Effect.PROTECTION:
                    combattant.ArmorClassModifier++;
                    break;
                case Effect.ONE_EXTRA_ATTACK:
                case Effect.TWO_EXTRA_ATTACKS:
                case Effect.THREE_EXTRA_ATTACKS:
                    ((CharacterSheet)combattant).RecalculateAttacks();
                    break;
            }
        }

        public static void Unapply(this Effect effect, Combattant combattant) {
            switch (effect) {
                case Effect.HEAVY_ARMOR_SPEED_PENALITY:
                    combattant.Speed += 10;
                    break;
                case Effect.CONSTITUION_19:
                case Effect.INTELLIGENCE_19:
                    unapplyAbilityEffect(effect, combattant);
                    break;
                case Effect.PROTECTION:
                    combattant.ArmorClassModifier--;
                    break;
                case Effect.ONE_EXTRA_ATTACK:
                case Effect.TWO_EXTRA_ATTACKS:
                case Effect.THREE_EXTRA_ATTACKS:
                    ((CharacterSheet)combattant).RecalculateAttacks();
                    break;
            }
        }

        private static void applyAbilityEffect(Effect effect, Combattant combattant) {
            switch (effect) {
                case Effect.INTELLIGENCE_19:
                    if (combattant.Intelligence.Value < 19) {
                        // TODO: BaseValue logic
                        combattant.Intelligence.Value = 19;
                    }
                    break;
                case Effect.CONSTITUION_19:
                    if (combattant.Constitution.Value < 19) {
                        // TODO: BaseValue logic
                        combattant.Constitution.Value = 19;
                    }
                    break;
            }
        }

        private static void unapplyAbilityEffect(Effect effect, Combattant combattant) {
            switch (effect) {
                case Effect.INTELLIGENCE_19:
                    if (combattant.Intelligence.Value == 19 && combattant.Intelligence.BaseValue < 19) {
                        combattant.Intelligence.Value = combattant.Intelligence.BaseValue;
                    }
                    break;
                case Effect.CONSTITUION_19:
                    if (combattant.Constitution.Value == 19 && combattant.Constitution.BaseValue < 19) {
                        combattant.Constitution.Value = combattant.Constitution.BaseValue;
                    }
                    break;
            }
        }
    }
}
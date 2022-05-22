using System;

namespace srd5 {
    public enum Effect {
        // Vulnerability against DamageType
        VULNERABILITY_ACID,
        VULNERABILITY_BLUDGEONING,
        VULNERABILITY_COLD,
        VULNERABILITY_FIRE,
        VULNERABILITY_FORCE,
        VULNERABILITY_LIGHTNING,
        VULNERABILITY_NECROTIC,
        VULNERABILITY_PIERCING,
        VULNERABILITY_POISON,
        VULNERABILITY_PSYCHIC,
        VULNERABILITY_RADIANT,
        VULNERABILITY_SLASHING,
        VULNERABILITY_THUNDER,
        // Resistances against DamageType
        RESISTANCE_ACID,
        RESISTANCE_BLUDGEONING,
        RESISTANCE_COLD,
        RESISTANCE_FIRE,
        RESISTANCE_FORCE,
        RESISTANCE_LIGHTNING,
        RESISTANCE_NECROTIC,
        RESISTANCE_PIERCING,
        RESISTANCE_POISON,
        RESISTANCE_PSYCHIC,
        RESISTANCE_RADIANT,
        RESISTANCE_SLASHING,
        RESISTANCE_THUNDER,
        RESISTANCE_NONMAGIC,
        // Immunities against DamageType
        IMMUNITY_ACID,
        IMMUNITY_BLUDGEONING,
        IMMUNITY_COLD,
        IMMUNITY_FIRE,
        IMMUNITY_FORCE,
        IMMUNITY_LIGHTNING,
        IMMUNITY_NECROTIC,
        IMMUNITY_PIERCING,
        IMMUNITY_POISON,
        IMMUNITY_PSYCHIC,
        IMMUNITY_RADIANT,
        IMMUNITY_SLASHING,
        IMMUNITY_THUNDER,
        IMMUNITY_NONMAGIC,

        // Immunities against Condition
        IMMUNITY_BLINDED,
        IMMUNITY_CHARMED,
        IMMUNITY_DEAFENED,
        IMMUNITY_EXHAUSTION,
        IMMUNITY_FRIGHTENED,
        IMMUNITY_GRAPPLED,
        IMMUNITY_INCAPACITATED,
        IMMUNITY_INVISIBLE,
        IMMUNITY_PARALYZED,
        IMMUNITY_PETRIFIED,
        IMMUNITY_POISONED,
        IMMUNITY_PRONE,
        IMMUNITY_RESTRAINED,
        IMMUNITY_SLEEP,
        IMMUNITY_STUNNED,
        IMMUNITY_UNCONSCIOUS,

        // Advantage on Save Throws
        ADVANTAGE_SAVE_POISON,
        ADVANTAGE_SAVE_CHARM,

        // Attack modifiers
        ADVANTAGE_ON_ATTACK,
        DISADVANTAGE_ON_ATTACK,
        ADVANTAGE_ON_BEING_ATTACKED,
        DISADVANTAGE_ON_BEING_ATTACKED,
        AUTOMATIC_CRIT_ON_HIT,
        AUTOMATIC_CRIT_ON_BEING_HIT_WITHIN_5_FT,
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
        PROTECTION,
        CANNOT_TAKE_ACTIONS,
        FAIL_STRENGTH_CHECK,
        FAIL_DEXERITY_CHECK,

        // Spell Effects
        RESISTANCE,
        LONGSTRIDER,
        ENTANGLE,
        FAIRIE_FIRE,
        JUMP
    }

    public static class Effects {
        public static Effect Resistance(DamageType damage) {
            string name = "RESISTANCE_" + Enum.GetName(typeof(DamageType), damage);
            return (Effect)Enum.Parse(typeof(Effect), name);
        }

        public static Effect Immunity(DamageType damage) {
            string name = "IMMUNITY_" + Enum.GetName(typeof(DamageType), damage);
            return (Effect)Enum.Parse(typeof(Effect), name);
        }

        public static Effect Vulnerability(DamageType damage) {
            string name = "VULNERABILITY_" + Enum.GetName(typeof(DamageType), damage);
            return (Effect)Enum.Parse(typeof(Effect), name);
        }

        public static Effect Immunity(ConditionType condition) {
            if (condition >= ConditionType.EXHAUSTED_1 && condition <= ConditionType.EXHAUSTED_6)
                return Effect.IMMUNITY_EXHAUSTION;
            string name = "IMMUNITY_" + Enum.GetName(typeof(ConditionType), condition);
            return (Effect)Enum.Parse(typeof(Effect), name);
        }
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
                case Effect.LONGSTRIDER:
                    combattant.Speed += 10;
                    break;
                case Effect.ENTANGLE:
                    combattant.AddCondition(ConditionType.RESTRAINED);
                    break;
                case Effect.FAIRIE_FIRE:
                    combattant.AddEffect(Effect.ADVANTAGE_ON_BEING_ATTACKED);
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
                case Effect.LONGSTRIDER:
                    combattant.Speed -= 10;
                    break;
                case Effect.ENTANGLE:
                    combattant.RemoveCondition(ConditionType.RESTRAINED);
                    break;
                case Effect.FAIRIE_FIRE:
                    combattant.RemoveEffect(Effect.ADVANTAGE_ON_BEING_ATTACKED);
                    break;
            }
        }

        private static void applyAbilityEffect(Effect effect, Combattant combattant) {
            switch (effect) {
                case Effect.INTELLIGENCE_19:
                    combattant.Intelligence.AddMinimumBaseValue(19);
                    break;
                case Effect.CONSTITUION_19:
                    combattant.Constitution.AddMinimumBaseValue(19);
                    break;
            }
        }

        private static void unapplyAbilityEffect(Effect effect, Combattant combattant) {
            switch (effect) {
                case Effect.INTELLIGENCE_19:
                    combattant.Intelligence.RemoveMinimumBaseValue(19);
                    break;
                case Effect.CONSTITUION_19:
                    combattant.Constitution.RemoveMinimumBaseValue(19);
                    break;
            }
        }
    }
}
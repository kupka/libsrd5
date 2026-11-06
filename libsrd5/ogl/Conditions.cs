using static srd5.Effect;
using System;

namespace srd5 {
    public enum ConditionType {
        BLINDED, // Disadvantage on attacks, Advantage on being attacked
        CHARMED, // Cannot attack source of charm
        DEAFENED, // Fail hearing checks
        EXHAUSTED_1, // Disadvantage on all ability checks
        EXHAUSTED_2, // Speed halved
        EXHAUSTED_3, // Disadvantage on attack and save
        EXHAUSTED_4, // Max HPs halved
        EXHAUSTED_5, // Speed = 0
        EXHAUSTED_6, // Death
        FRIGHTENED, // Disadvantage on ability and attack when source is close, cannot approach source
        GRAPPLED_DC10, // Speed = 0  
        GRAPPLED_DC11, // Speed = 0        
        GRAPPLED_DC12, // Speed = 0
        GRAPPLED_DC13, // Speed = 0
        GRAPPLED_DC14, // Speed = 0
        GRAPPLED_DC15, // Speed = 0
        GRAPPLED_DC16, // Speed = 0
        GRAPPLED_DC17, // Speed = 0
        GRAPPLED_DC18, // Speed = 0
        GRAPPLED_DC19, // Speed = 0
        GRAPPLED_DC20, // Speed = 0
        INCAPACITATED, // Cannot take actions and reactions
        INVISIBLE, // Advantage on attacks, Disadvantage on being attacked
        PARALYZED, // Stunned & takes auto crits
        PETRIFIED, // Stunned & resistance against all damage, immune against poison and disease
        POISONED,  // Disadvantage on ability and attack
        PRONE, // Disadvantage on attack, Advantage on being melee attacked, Disadvantage on being ranged attacked
        RESTRAINED, // Speed = 0, Disadvantage on attacks, Advantage on being attacked, Disadvantage on DEX saves
        STUNNED, // Incapacitated & fail STR/DEX checks, Advantage on being attacked
        UNCONSCIOUS, // Paralyzed & Fully Disarmed
    }

    public static class ConditionsExtension {
        public static void Apply(this ConditionType type, Combatant combatant) {
            switch (type) {
                case ConditionType.BLINDED:
                    applyBlinded(combatant);
                    break;
                case ConditionType.INCAPACITATED:
                    applyIncapacitated(combatant);
                    break;
                case ConditionType.PARALYZED:
                    applyParalyzed(combatant);
                    break;
                case ConditionType.STUNNED:
                    applyStunned(combatant);
                    break;
                case ConditionType.UNCONSCIOUS:
                    applyUnconcious(combatant);
                    break;
                case ConditionType.GRAPPLED_DC10:
                case ConditionType.GRAPPLED_DC11:
                case ConditionType.GRAPPLED_DC12:
                case ConditionType.GRAPPLED_DC13:
                case ConditionType.GRAPPLED_DC14:
                case ConditionType.GRAPPLED_DC15:
                case ConditionType.GRAPPLED_DC16:
                case ConditionType.GRAPPLED_DC17:
                case ConditionType.GRAPPLED_DC18:
                case ConditionType.GRAPPLED_DC19:
                case ConditionType.GRAPPLED_DC20:
                    applyGrappled(combatant, type);
                    break;
            }
        }

        public static void Unapply(this ConditionType type, Combatant combatant) {
            switch (type) {
                case ConditionType.BLINDED:
                    unapplyBlinded(combatant);
                    break;
                case ConditionType.INCAPACITATED:
                    unapplyIncapacitated(combatant);
                    break;
                case ConditionType.PARALYZED:
                    unapplyParalyzed(combatant);
                    break;
                case ConditionType.STUNNED:
                    unapplyStunned(combatant);
                    break;
                case ConditionType.UNCONSCIOUS:
                    unapplyUnconcious(combatant);
                    break;
            }
        }

        private static void applyBlinded(Combatant combatant) {
            combatant.AddEffect(ADVANTAGE_ON_BEING_ATTACKED);
            combatant.AddEffect(DISADVANTAGE_ON_ATTACK);
        }

        private static void unapplyBlinded(Combatant combatant) {
            combatant.RemoveEffect(ADVANTAGE_ON_BEING_ATTACKED);
            combatant.RemoveEffect(DISADVANTAGE_ON_ATTACK);
        }

        private static void applyIncapacitated(Combatant combatant) {
            combatant.AddEffect(CANNOT_TAKE_ACTIONS);
        }

        private static void unapplyIncapacitated(Combatant combatant) {
            combatant.RemoveEffect(CANNOT_TAKE_ACTIONS);
        }


        private static void applyParalyzed(Combatant combatant) {
            applyStunned(combatant);
            combatant.AddEffect(AUTOMATIC_CRIT_ON_BEING_HIT_WITHIN_5_FT);
        }

        private static void unapplyParalyzed(Combatant combatant) {
            unapplyStunned(combatant);
            combatant.RemoveEffect(AUTOMATIC_CRIT_ON_BEING_HIT_WITHIN_5_FT);
        }

        private static void applyStunned(Combatant combatant) {
            applyIncapacitated(combatant);
            combatant.AddEffect(FAIL_STRENGTH_CHECK);
            combatant.AddEffect(FAIL_DEXERITY_CHECK);
            combatant.AddEffect(ADVANTAGE_ON_BEING_ATTACKED);
        }

        private static void unapplyStunned(Combatant combatant) {
            unapplyIncapacitated(combatant);
            combatant.RemoveEffect(FAIL_STRENGTH_CHECK);
            combatant.RemoveEffect(FAIL_DEXERITY_CHECK);
            combatant.RemoveEffect(ADVANTAGE_ON_BEING_ATTACKED);

        }

        private static void applyUnconcious(Combatant combatant) {
            applyParalyzed(combatant);
            if (combatant is CharacterSheet sheet) {
                sheet.Unequip(sheet.Inventory.MainHand);
                sheet.Unequip(sheet.Inventory.OffHand);
            }
        }

        private static void unapplyUnconcious(Combatant combatant) {
            unapplyParalyzed(combatant);
        }

        private static void applyGrappled(Combatant combatant, ConditionType type) {
            ActionEffect escapeFromGrapple = () => {
                // check proficiency or skills
                bool success = false;
                int dc = 0;
                int athelicsFavor = combatant.Strength.Modifier;
                int acrobaticsFavor = combatant.Dexterity.Modifier;
                // determine grappled condition
                if (Enum.GetName(typeof(ConditionType), type).IndexOf("GRAPPLED_") == 0) {
                    dc = (int)type - (int)ConditionType.GRAPPLED_DC12 + 12;
                }
                if (combatant.IsProficient(Skill.ATHLETICS)) {
                    athelicsFavor += combatant.ProficiencyBonus;
                }
                if (combatant.IsProficient(Skill.ACROBATICS)) {
                    acrobaticsFavor += combatant.ProficiencyBonus;
                }
                if (athelicsFavor > acrobaticsFavor) {
                    success = combatant.DC(null, dc, Skill.ATHLETICS);
                } else {
                    success = combatant.DC(null, dc, Skill.ACROBATICS);
                }
                if (success) {
                    combatant.RemoveCondition(type);
                }
                return success;
            };
            combatant.AddConditionalAction(new Action(Actions.ID.ESCAPE_FROM_GRAPPLE, escapeFromGrapple));
        }
    }
}
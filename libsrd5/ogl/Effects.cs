using System;
using static srd5.Die;
using static srd5.Effect;
using static srd5.DamageType;

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
        VULNERABILITY_TRUE_DAMAGE, // should never be applied
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
        RESISTANCE_DAMAGE_FROM_SPELLS,
        RESISTANCE_TRUE_DAMAGE, // should never be applied
        RESISTANCE_ANY_DAMAGE,
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
        IMMUNITY_DAMAGE_FROM_SPELLS,
        IMMUNITY_TRUE_DAMAGE, // should never be applied
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

        // Advantage on Save Throws/Skill Checks
        ADVANTAGE_POISON_SAVES,
        ADVANTAGE_CHARM_SAVES,
        ADVANTAGE_CONSTITUTION_SAVES,
        ADVANTAGE_STRENGTH_SAVES,
        ADVANTAGE_DEXTERITY_SAVES,
        ADVANTAGE_CHARISMA_SAVES,
        ADVANTAGE_INTELLIGENCE_SAVES,
        ADVANTAGE_WISDOM_SAVES,
        // Disadvantage of Save Throws/Skill Checks
        DISADVANTAGE_CONSTITUTION_SAVES,
        DISADVANTAGE_STRENGTH_SAVES,
        DISADVANTAGE_DEXTERITY_SAVES,
        DISADVANTAGE_CHARISMA_SAVES,
        DISADVANTAGE_INTELLIGENCE_SAVES,
        DISADVANTAGE_WISDOM_SAVES,
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
        CANNOT_MELEE_ATTACK,
        CANNOT_BE_MELEE_ATTACKED,
        // Movement
        NO_SPEED_PENALITY_FOR_HEAVY_ARMOR,
        HEAVY_ARMOR_SPEED_PENALITY,
        SWIMMING_SPEED_40,
        IGNORE_SNOW_PENALITY,

        // Abilities
        CONSTITUTION_19,
        INTELLIGENCE_19,

        // Death Saves Effects when not stabilized
        FIGHTING_DEATH,
        FIGHTING_DEATH_SAVE_FAIL_1,
        FIGHTING_DEATH_SAVE_FAIL_2,
        FIGHTING_DEATH_SAVE_SUCCESS_1,
        FIGHTING_DEATH_SAVE_SUCCESS_2,
        FIGHTING_DEATH_STABILIZED,

        // Misc./Special
        DOUBLE_PROFICIENCY_BONUS_HISTORY,
        ADDITIONAL_HP_PER_LEVEL,
        DARKVISION,
        PROTECTION,
        CANNOT_TAKE_ACTIONS,
        CANNOT_TAKE_REACTIONS,
        FAIL_STRENGTH_CHECK,
        FAIL_DEXERITY_CHECK,
        FAIL_CONSTITUTION_CHECK,
        CANNOT_REGAIN_HITPOINTS,
        GRAPPLING,

        // Spell Effects
        SPELL_ACID_ARRORW_BURN,
        SPELL_AID,
        SPELL_ALTER_SELF_CLAWS,
        SPELL_ANIMAL_FRIENDSHIP,
        SPELL_BANE,
        SPELL_BARKSKIN,
        SPELL_BLESS,
        SPELL_BLINDNESS_DEAFNESS,
        SPELL_BLUR,
        SPELL_CALM_EMOTIONS,
        SPELL_CALM_EMOTIONS_CHARMED_SUPRESSED,
        SPELL_CALM_EMOTIONS_FRIGHTENED_SUPRESSED,
        SPELL_COMMAND_GROVEL,
        SPELL_COMPREHEND_LANGUAGES,
        SPELL_DARKVISION,
        SPELL_DETECT_EVIL_AND_GOOD,
        SPELL_DETECT_MAGIC,
        SPELL_DETECT_POISON_AND_DISEASE,
        SPELL_DISGUISE_SELF,
        SPELL_DIVINE_FAVOR,
        SPELL_ENHANCE_ABILITY,
        SPELL_ENLARGE,
        SPELL_ENTANGLE,
        SPELL_FAIRIE_FIRE,
        SPELL_FEATHER_FALL,
        SPELL_GUIDANCE,
        SPELL_GUST_OF_WIND,
        SPELL_HIDEOUS_LAUGHTER,
        SPELL_INVISIBILITY,
        SPELL_JUMP,
        SPELL_LEVITATE,
        SPELL_LIGHT,
        SPELL_LONGSTRIDER,
        SPELL_MIRROR_IMAGE_1,
        SPELL_MIRROR_IMAGE_2,
        SPELL_MIRROR_IMAGE_3,
        SPELL_PASS_WITHOUT_TRACE,
        SPELL_PROTECTION_FROM_EVIL_AND_GOOD,
        SPELL_PROTECTION_FROM_POISON,
        SPELL_RAY_OF_ENFEEBLEMENT,
        SPELL_RAY_OF_FROST,
        SPELL_REDUCE,
        SPELL_RESISTANCE,
        SPELL_SEE_INVISIBILITY,
        SPELL_SHIELD,
        SPELL_SHIELD_OF_FAITH,
        SPELL_SILENCE,
        SPELL_SPIDER_CLIMB,
        SPELL_SUGGESTION,
        SPELL_WARDING_BOND,
        SPELL_WARDING_BOND_CASTER,
        // Curses
        CURSE_MUMMY_ROT,
        CURSE_RAKSHASA,
        CURSE_WEREBEAR,
        CURSE_WEREBOAR,
        CURSE_WERERAT,
        CURSE_WERETIGER,
        CURSE_WEREWOLF,
        // Attack Effects
        ABOLETH_DISEASE_TENTACLE,
        BEARDED_DEVIL_POISON,
        BONE_DEVIL_POISON,
        ATTACHED_TO_TARGET,
        COUATL_POISON,
        DROW_POISON,
        DEATH_DOG_DISEASE,
        ERINYES_POISON,
        ETTERCAP_POISON,
        ETTERCAP_WEB,
        FIRE_ELEMENTAL_IGNITE,
        GHAST_CLAWS_PARALYZATION,
        GHOUL_CLAWS_PARALYZATION,
        GIANT_RAT_DISEASED_BITE,
        GIANT_SPIDER_WEB,
        HOMUNCULUS_POISON,
        HOMUNCULUS_POISON_UNCONCIOUSNESS,
        INFERNAL_WOUND_BEARDED_DEVIL,
        INFERNAL_WOUND_HORNED_DEVIL,
        KRAKEN_SWALLOW,
        LICH_PARALYZATION,
        MAGMIN_IGNITE,
        OTYUGH_DISEASE,
        PHASE_SPIDER_POISON,
        PSEUDO_DRAGON_POISON,
        PSEUDO_DRAGON_POISON_UNCONSCIOUS,
        QUASIT_POISON,
        PIT_FIEND_POISON,
        RUG_SMOTHER,
        SPRITE_POISON,
        SPRITE_POISON_UNCONCIOUS,
        STIRGE_BLOOD_DRAIN_EFFECT,
        STIRGE_BLOOD_DRAINING,
        UNABLE_TO_BREATHE,

        // Feat Effects
        LEGENDARY_RESISTANCE,
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
            string conditionName = Enum.GetName(typeof(ConditionType), condition);
            if (conditionName.IndexOf("EXHAUSTED") == 0) conditionName = "EXHAUSTION";
            if (conditionName.IndexOf("GRAPPLED") == 0) conditionName = "GRAPPLED";
            string name = "IMMUNITY_" + conditionName;
            return (Effect)Enum.Parse(typeof(Effect), name);
        }
    }

    public static class EffectExtension {
        public static void Apply(this Effect effect, Combattant combattant) {
            int turn = 0;
            int duration;
            int dc;
            switch (effect) {
                case HEAVY_ARMOR_SPEED_PENALITY:
                    combattant.Speed -= 10;
                    break;
                case CONSTITUTION_19:
                case INTELLIGENCE_19:
                    applyAbilityEffect(effect, combattant);
                    break;
                case PROTECTION:
                    combattant.ArmorClassModifier++;
                    break;
                case ONE_EXTRA_ATTACK:
                case TWO_EXTRA_ATTACKS:
                case THREE_EXTRA_ATTACKS:
                    if (combattant is CharacterSheet sheet) {
                        sheet.RecalculateAttacks();
                    }
                    break;
                case SPELL_LONGSTRIDER:
                    combattant.Speed += 10;
                    break;
                case SPELL_ENTANGLE:
                    combattant.AddCondition(ConditionType.RESTRAINED);
                    break;
                case SPELL_FAIRIE_FIRE:
                    combattant.AddEffect(ADVANTAGE_ON_BEING_ATTACKED);
                    break;
                case IMMUNITY_TRUE_DAMAGE:
                case RESISTANCE_TRUE_DAMAGE:
                case VULNERABILITY_TRUE_DAMAGE:
                    throw new Srd5ArgumentException("Do not aply True Damage effects.");
                case COUATL_POISON:
                    combattant.AddCondition(ConditionType.POISONED);
                    combattant.AddCondition(ConditionType.UNCONSCIOUS);
                    break;
                case BEARDED_DEVIL_POISON:
                case BONE_DEVIL_POISON:
                case DEATH_DOG_DISEASE:
                case DROW_POISON:
                case ERINYES_POISON:
                case ETTERCAP_POISON:
                case HOMUNCULUS_POISON:
                    combattant.AddCondition(ConditionType.POISONED);
                    break;
                case ETTERCAP_WEB:
                    combattant.AddCondition(ConditionType.RESTRAINED);
                    break;
                case FIRE_ELEMENTAL_IGNITE:
                    combattant.AddStartOfTurnEvent(delegate () {
                        if (!combattant.HasEffect(effect)) return true;
                        combattant.TakeDamage(effect, FIRE, "1d10");
                        return false;
                    });
                    break;
                case GHAST_CLAWS_PARALYZATION:
                case GHOUL_CLAWS_PARALYZATION:
                case LICH_PARALYZATION:
                    combattant.AddCondition(ConditionType.PARALYZED);
                    dc = 10;
                    duration = 10; // one minute 
                    if (effect == LICH_PARALYZATION) dc = 18;
                    combattant.AddEndOfTurnEvent(delegate () {
                        if (!combattant.HasEffect(effect)) return true;
                        bool success = combattant.DC(effect, dc, AbilityType.CONSTITUTION);
                        if (turn++ >= duration) success = true;
                        if (success) combattant.RemoveEffect(effect);
                        return success;
                    });
                    break;
                case GIANT_RAT_DISEASED_BITE:
                    // TODO: contract a disease. 
                    // Until the disease is cured, the target can't regain hit points except by magical means, 
                    // and the target's hit point maximum decreases by 3 (1d6) every 24 hours. 
                    // If the target's hit point maximum drops to 0 as a result of this disease, the target dies.
                    break;
                case CURSE_MUMMY_ROT:
                    // TODO: The cursed target can't regain hit points, and its hit point maximum decreases by 10 
                    // (3d6) for every 24 hours that elapse. If the curse reduces the target's hit point maximum to 0, 
                    // the target dies, and its body turns to dust. The curse lasts until removed by the remove curse 
                    // spell or other magic.
                    combattant.AddEffect(CANNOT_REGAIN_HITPOINTS);
                    break;
                case HOMUNCULUS_POISON_UNCONCIOUSNESS:
                    combattant.AddCondition(ConditionType.POISONED, ConditionType.UNCONSCIOUS);
                    break;
                case MAGMIN_IGNITE:
                    combattant.AddStartOfTurnEvent(delegate () {
                        if (!combattant.HasEffect(effect)) return true;
                        combattant.TakeDamage(effect, FIRE, "1d6");
                        return false;
                    });
                    break;
                case OTYUGH_DISEASE:
                    combattant.AddCondition(ConditionType.POISONED);
                    // TODO: Every 24 hours that elapse, the target must repeat the saving throw, 
                    // reducing its hit point maximum by 5 (1d10) on a failure. The disease is cured on a success. 
                    // The target dies if the disease reduces its hit point maximum to 0. 
                    // This reduction to the target's hit point maximum lasts until the disease is cured.
                    break;
                case PHASE_SPIDER_POISON:
                    combattant.AddCondition(ConditionType.POISONED, ConditionType.PARALYZED);
                    break;
                case PIT_FIEND_POISON:
                    combattant.AddCondition(ConditionType.POISONED);
                    combattant.AddEffect(CANNOT_REGAIN_HITPOINTS);
                    combattant.AddStartOfTurnEvent(delegate () {
                        if (!combattant.HasEffect(effect)) return true;
                        combattant.TakeDamage(effect, POISON, "6d6");
                        return false;
                    });
                    combattant.AddEndOfTurnEvent(delegate () {
                        if (!combattant.HasEffect(effect)) return true;
                        if (combattant.DC(effect, 21, AbilityType.CONSTITUTION)) {
                            combattant.RemoveEffect(effect);
                            return true;
                        }
                        return false;
                    });
                    break;
                case PSEUDO_DRAGON_POISON:
                case SPRITE_POISON:
                    combattant.AddCondition(ConditionType.POISONED);
                    break;
                case PSEUDO_DRAGON_POISON_UNCONSCIOUS:
                case SPRITE_POISON_UNCONCIOUS:
                    combattant.AddCondition(ConditionType.UNCONSCIOUS);
                    // TODO: If the saving throw fails by 5 or more, the target falls unconscious for the same duration, 
                    // or until it takes damage or another creature uses an action to shake it awake.
                    break;
                case QUASIT_POISON:
                    combattant.AddCondition(ConditionType.POISONED);
                    dc = 10;
                    duration = 10; // one minute
                    combattant.AddEndOfTurnEvent(delegate () {
                        if (!combattant.HasEffect(effect)) return true;
                        bool success = combattant.DC(effect, dc, AbilityType.CONSTITUTION);
                        if (turn++ >= duration) success = true;
                        if (success) combattant.RemoveEffect(effect);
                        return success;
                    });
                    break;
                case RUG_SMOTHER:
                    if (!combattant.HasEffect(IMMUNITY_BLINDED)) combattant.AddCondition(ConditionType.BLINDED);
                    combattant.AddStartOfTurnEvent(delegate () {
                        if (combattant.HasCondition(ConditionType.GRAPPLED_DC13)) {
                            combattant.TakeDamage(effect, BLUDGEONING, "2d6+3");
                            return false;
                        } else {
                            return true;
                        }
                    });
                    break;
                case FIGHTING_DEATH:
                    combattant.AddStartOfTurnEvent(delegate () {
                        // Don't roll if stabilized
                        if (combattant.HasEffect(FIGHTING_DEATH_STABILIZED)) {
                            combattant.RemoveEffect(FIGHTING_DEATH);
                            return true;
                        }
                        // Death Save is DC10 with no Ability
                        int deathSaveRoll = D20.Value;
                        bool success = deathSaveRoll > 9;
                        GlobalEvents.RolledDC(combattant, FIGHTING_DEATH, new Ability(AbilityType.NONE, 9), 10, deathSaveRoll, success);
                        if (success) {
                            // Critical success counts as 2 successes
                            if (deathSaveRoll == 20) {
                                if (combattant.HasEffect(FIGHTING_DEATH_SAVE_SUCCESS_1) || combattant.HasEffect(FIGHTING_DEATH_SAVE_SUCCESS_2)) {
                                    combattant.RemoveEffect(FIGHTING_DEATH);
                                    return true;
                                } else {
                                    combattant.AddEffect(FIGHTING_DEATH_SAVE_SUCCESS_2);
                                    return false;
                                }
                            } else if (combattant.HasEffect(FIGHTING_DEATH_SAVE_SUCCESS_2)) {
                                // third success => stabilized
                                combattant.RemoveEffect(FIGHTING_DEATH);
                                return true;
                            } else if (combattant.HasEffect(FIGHTING_DEATH_SAVE_SUCCESS_1)) {
                                combattant.AddEffect(FIGHTING_DEATH_SAVE_SUCCESS_2);
                                return false;
                            } else {
                                combattant.AddEffect(FIGHTING_DEATH_SAVE_SUCCESS_1);
                                return false;
                            }
                        } else {
                            // Critical fail counts as 2 fails
                            if (deathSaveRoll == 1) {
                                if (combattant.HasEffect(FIGHTING_DEATH_SAVE_FAIL_1) || combattant.HasEffect(FIGHTING_DEATH_SAVE_FAIL_2)) {
                                    combattant.RemoveEffect(FIGHTING_DEATH);
                                    combattant.Die();
                                    return true;
                                } else {
                                    combattant.AddEffect(FIGHTING_DEATH_SAVE_FAIL_2);
                                    return false;
                                }
                            } else if (combattant.HasEffect(FIGHTING_DEATH_SAVE_FAIL_2)) {
                                // third fail => dead
                                combattant.RemoveEffect(FIGHTING_DEATH);
                                combattant.Die();
                                return true;
                            } else if (combattant.HasEffect(FIGHTING_DEATH_SAVE_FAIL_1)) {
                                combattant.AddEffect(FIGHTING_DEATH_SAVE_FAIL_2);
                                return false;
                            } else {
                                combattant.AddEffect(FIGHTING_DEATH_SAVE_FAIL_1);
                                return false;
                            }
                        }
                    });
                    break;
                case SPELL_COMMAND_GROVEL:
                case SPELL_HIDEOUS_LAUGHTER:
                    combattant.AddEffect(CANNOT_TAKE_ACTIONS);
                    break;
                case SPELL_ALTER_SELF_CLAWS:
                    if (combattant is CharacterSheet hero) {
                        hero.Unequip(hero.Inventory.MainHand);
                        hero.Equip(Weapons.Claws);
                    }
                    break;
                case SPELL_BLUR:
                    combattant.AddEffect(DISADVANTAGE_ON_BEING_ATTACKED);
                    break;
                case SPELL_CALM_EMOTIONS:
                    if (combattant.HasCondition(ConditionType.CHARMED)) {
                        combattant.AddEffect(SPELL_CALM_EMOTIONS_CHARMED_SUPRESSED);
                        combattant.RemoveCondition(ConditionType.CHARMED);
                    }
                    if (combattant.HasCondition(ConditionType.FRIGHTENED)) {
                        combattant.AddEffect(SPELL_CALM_EMOTIONS_FRIGHTENED_SUPRESSED);
                        combattant.RemoveCondition(ConditionType.FRIGHTENED);
                    }
                    break;
                case SPELL_DARKVISION:
                    combattant.AddEffect(DARKVISION);
                    break;
                case SPELL_ENLARGE:
                    combattant.Size++;
                    break;
                case SPELL_REDUCE:
                    combattant.Size--;
                    break;
                case SPELL_GUST_OF_WIND:
                    combattant.Speed /= 2;
                    break;
                case SPELL_PROTECTION_FROM_POISON:
                    combattant.AddEffect(ADVANTAGE_POISON_SAVES, RESISTANCE_POISON);
                    break;
                case SPELL_SILENCE:
                    combattant.AddEffect(IMMUNITY_THUNDER);
                    combattant.AddCondition(ConditionType.DEAFENED);
                    break;
                case SPELL_SUGGESTION:
                    combattant.AddEffect(CANNOT_TAKE_ACTIONS);
                    break;
                case SPELL_WARDING_BOND:
                    combattant.AddEffect(RESISTANCE_ANY_DAMAGE);
                    break;
            }
        }

        public static void Unapply(this Effect effect, Combattant combattant) {
            switch (effect) {
                case HEAVY_ARMOR_SPEED_PENALITY:
                    combattant.Speed += 10;
                    break;
                case CONSTITUTION_19:
                case INTELLIGENCE_19:
                    unapplyAbilityEffect(effect, combattant);
                    break;
                case PROTECTION:
                    combattant.ArmorClassModifier--;
                    break;
                case ONE_EXTRA_ATTACK:
                case TWO_EXTRA_ATTACKS:
                case THREE_EXTRA_ATTACKS:
                    if (combattant is CharacterSheet sheet) {
                        sheet.RecalculateAttacks();
                    }
                    ;
                    break;
                case SPELL_LONGSTRIDER:
                    combattant.Speed -= 10;
                    break;
                case SPELL_ENTANGLE:
                    combattant.RemoveCondition(ConditionType.RESTRAINED);
                    break;
                case SPELL_FAIRIE_FIRE:
                    combattant.RemoveEffect(ADVANTAGE_ON_BEING_ATTACKED);
                    break;
                case COUATL_POISON:
                    combattant.RemoveCondition(ConditionType.POISONED);
                    combattant.RemoveCondition(ConditionType.UNCONSCIOUS);
                    break;
                case BEARDED_DEVIL_POISON:
                case BONE_DEVIL_POISON:
                case DEATH_DOG_DISEASE:
                case DROW_POISON:
                case ERINYES_POISON:
                case ETTERCAP_POISON:
                case HOMUNCULUS_POISON:
                    combattant.RemoveCondition(ConditionType.POISONED);
                    break;
                case ETTERCAP_WEB:
                    combattant.RemoveCondition(ConditionType.RESTRAINED);
                    break;
                case GHAST_CLAWS_PARALYZATION:
                case GHOUL_CLAWS_PARALYZATION:
                case LICH_PARALYZATION:
                    combattant.RemoveCondition(ConditionType.PARALYZED);
                    break;
                case HOMUNCULUS_POISON_UNCONCIOUSNESS:
                    combattant.RemoveCondition(ConditionType.POISONED, ConditionType.UNCONSCIOUS);
                    break;
                case OTYUGH_DISEASE:
                    combattant.RemoveCondition(ConditionType.POISONED);
                    // TODO: Every 24 hours that elapse, the target must repeat the saving throw, 
                    // reducing its hit point maximum by 5 (1d10) on a failure. The disease is cured on a success. 
                    // The target dies if the disease reduces its hit point maximum to 0. 
                    // This reduction to the target's hit point maximum lasts until the disease is cured.
                    break;
                case PHASE_SPIDER_POISON:
                    combattant.RemoveCondition(ConditionType.POISONED, ConditionType.PARALYZED);
                    break;
                case PIT_FIEND_POISON:
                    combattant.RemoveCondition(ConditionType.POISONED);
                    combattant.RemoveEffect(CANNOT_REGAIN_HITPOINTS);
                    break;
                case PSEUDO_DRAGON_POISON:
                    combattant.RemoveCondition(ConditionType.POISONED);
                    break;
                case PSEUDO_DRAGON_POISON_UNCONSCIOUS:
                    combattant.RemoveCondition(ConditionType.UNCONSCIOUS);
                    break;
                case QUASIT_POISON:
                    combattant.RemoveCondition(ConditionType.POISONED);
                    break;
                case RUG_SMOTHER:
                    combattant.RemoveCondition(ConditionType.BLINDED);
                    break;
                case CURSE_MUMMY_ROT:
                    combattant.RemoveEffect(CANNOT_REGAIN_HITPOINTS);
                    break;
                case FIGHTING_DEATH:
                    combattant.RemoveEffect(FIGHTING_DEATH_SAVE_FAIL_1,
                                             FIGHTING_DEATH_SAVE_FAIL_2,
                                             FIGHTING_DEATH_SAVE_SUCCESS_1,
                                             FIGHTING_DEATH_SAVE_SUCCESS_2,
                                             FIGHTING_DEATH_STABILIZED);
                    break;
                case SPELL_COMMAND_GROVEL:
                case SPELL_HIDEOUS_LAUGHTER:
                    combattant.RemoveEffect(CANNOT_TAKE_ACTIONS);
                    break;
                case SPELL_ALTER_SELF_CLAWS:
                    if (combattant is CharacterSheet hero) {
                        if (hero.Inventory.MainHand.Is(Weapons.Claws)) {
                            hero.Inventory.MainHand = null;
                        }
                    }
                    break;
                case SPELL_BLUR:
                    combattant.RemoveEffect(DISADVANTAGE_ON_BEING_ATTACKED);
                    break;
                case SPELL_CALM_EMOTIONS:
                    if (combattant.HasEffect(SPELL_CALM_EMOTIONS_CHARMED_SUPRESSED)) {
                        combattant.RemoveEffect(SPELL_CALM_EMOTIONS_CHARMED_SUPRESSED);
                        // TODO: Add all effects here that cause charmed. If still present, re-apply condition.
                        // NOTE: Animal Friendship doesn't apply to Humanoids, so it is not valid here
                    }
                    if (combattant.HasEffect(SPELL_CALM_EMOTIONS_FRIGHTENED_SUPRESSED)) {
                        combattant.RemoveEffect(SPELL_CALM_EMOTIONS_FRIGHTENED_SUPRESSED);
                        // TODO: Add all effects here that cause frightened. If still present, re-apply condition.
                    }
                    break;
                case SPELL_DARKVISION:
                    combattant.RemoveEffect(DARKVISION);
                    break;
                case SPELL_ENLARGE:
                    combattant.Size--;
                    break;
                case SPELL_REDUCE:
                    combattant.Size++;
                    break;
                case SPELL_GUST_OF_WIND:
                    combattant.Speed *= 2;
                    break;
                case SPELL_PROTECTION_FROM_POISON:
                    combattant.RemoveEffect(ADVANTAGE_POISON_SAVES, RESISTANCE_POISON);
                    break;
                case SPELL_SILENCE:
                    combattant.RemoveEffect(IMMUNITY_THUNDER);
                    combattant.RemoveCondition(ConditionType.DEAFENED);
                    break;
                case SPELL_SUGGESTION:
                    combattant.RemoveEffect(CANNOT_TAKE_ACTIONS);
                    break;
                case SPELL_WARDING_BOND:
                    combattant.RemoveEffect(RESISTANCE_ANY_DAMAGE);
                    break;
            }
        }

        private static void applyAbilityEffect(Effect effect, Combattant combattant) {
            switch (effect) {
                case INTELLIGENCE_19:
                    combattant.Intelligence.AddMinimumBaseValue(19);
                    break;
                case CONSTITUTION_19:
                    combattant.Constitution.AddMinimumBaseValue(19);
                    break;
            }
        }

        private static void unapplyAbilityEffect(Effect effect, Combattant combattant) {
            switch (effect) {
                case INTELLIGENCE_19:
                    combattant.Intelligence.RemoveMinimumBaseValue(19);
                    break;
                case CONSTITUTION_19:
                    combattant.Constitution.RemoveMinimumBaseValue(19);
                    break;
            }
        }

        public static bool IsCurse(this Effect effect) {
            return Enum.GetName(typeof(Effect), effect).StartsWith("CURSE_");
        }

        public static bool IsDisease(this Effect effect) {
            return Enum.GetName(typeof(Effect), effect).IndexOf("DISEASE") > -1;
        }

        public static bool IsPoison(this Effect effect) {
            return Enum.GetName(typeof(Effect), effect).IndexOf("POISON") > -1;
        }
    }
}
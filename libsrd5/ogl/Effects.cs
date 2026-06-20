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
        ADVANTAGE_DEATH_SAVES,
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
        CANNOT_BE_ATTACKED,
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
        SPELL_GENERIC,
        // Cantrips
        SPELL_GUIDANCE,
        SPELL_LIGHT,
        SPELL_RAY_OF_FROST,
        SPELL_RESISTANCE,
        // 1st
        SPELL_ANIMAL_FRIENDSHIP,
        SPELL_BANE,
        SPELL_BLESS,
        SPELL_COMMAND_GROVEL,
        SPELL_COMPREHEND_LANGUAGES,
        SPELL_DETECT_EVIL_AND_GOOD,
        SPELL_DETECT_MAGIC,
        SPELL_DETECT_POISON_AND_DISEASE,
        SPELL_DISGUISE_SELF,
        SPELL_DIVINE_FAVOR,
        SPELL_ENTANGLE,
        SPELL_FAIRIE_FIRE,
        SPELL_FEATHER_FALL,
        SPELL_HIDEOUS_LAUGHTER,
        SPELL_JUMP,
        SPELL_LONGSTRIDER,
        SPELL_PROTECTION_FROM_EVIL_AND_GOOD,
        SPELL_SHIELD,
        SPELL_SHIELD_OF_FAITH,
        // 2nd
        SPELL_ACID_ARRORW_BURN,
        SPELL_AID,
        SPELL_ALTER_SELF_CLAWS,
        SPELL_BARKSKIN,
        SPELL_BLINDNESS_DEAFNESS,
        SPELL_BLUR,
        SPELL_CALM_EMOTIONS,
        SPELL_CALM_EMOTIONS_CHARMED_SUPRESSED,
        SPELL_CALM_EMOTIONS_FRIGHTENED_SUPRESSED,
        SPELL_CLAIRVOYANCE,
        SPELL_DARKVISION,
        SPELL_ENHANCE_ABILITY,
        SPELL_ENLARGE,
        SPELL_GUST_OF_WIND,
        SPELL_INVISIBILITY,
        SPELL_LEVITATE,
        SPELL_MIRROR_IMAGE_1,
        SPELL_MIRROR_IMAGE_2,
        SPELL_MIRROR_IMAGE_3,
        SPELL_PASS_WITHOUT_TRACE,
        SPELL_PROTECTION_FROM_POISON,
        SPELL_RAY_OF_ENFEEBLEMENT,
        SPELL_REDUCE,
        SPELL_SEE_INVISIBILITY,
        SPELL_SILENCE,
        SPELL_SPIDER_CLIMB,
        SPELL_SUGGESTION,
        SPELL_WARDING_BOND,
        SPELL_WARDING_BOND_CASTER,
        // 3rd
        SPELL_ANIMATE_DEAD,
        SPELL_FEAR,
        SPELL_BEACON_OF_HOPE,
        SPELL_BESTOW_CURSE,
        SPELL_BESTOW_CURSE_LOSE_TURN_ON_FAILED_WISDOM_SAVE,
        SPELL_BESTOW_CURSE_LOST_TURN,
        SPELL_BESTOW_CURSE_TAKE_ADDITIONAL_DAMAGE,
        SPELL_HASTE,
        SPELL_PROTECTION_FROM_ENERGY,
        SPELL_SLEET_STORM,
        SPELL_SLOW,
        SPELL_SPIRIT_GUARDIANS,
        SPELL_STINKING_CLOUD,
        SPELL_FLY,
        SPELL_GASEOUS_FORM,
        SPELL_MELD_INTO_STONE,
        SPELL_NONDETECTION,
        SPELL_TONGUES,
        SPELL_WATER_BREATHING,
        SPELL_WATER_WALK,
        SPELL_HYPNOTIC_PATTERN,
        // 4th
        SPELL_PLACEHOLDER_4TH,
        // 5th
        SPELL_PLACEHOLDER_5TH,
        // 6th
        SPELL_PLACEHOLDER_6TH,
        // 7th
        SPELL_PLACEHOLDER_7TH,
        // 8th
        SPELL_PLACEHOLDER_8TH,
        // 9th
        SPELL_PLACEHOLDER_9TH,
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


        public static readonly Effect FIRST_SPELL_CANTRIP = SPELL_GUIDANCE;
        public static readonly Effect FIRST_SPELL_1ST = SPELL_ANIMAL_FRIENDSHIP;
        public static readonly Effect FIRST_SPELL_2ND = SPELL_ACID_ARRORW_BURN;
        public static readonly Effect FIRST_SPELL_3RD = SPELL_ANIMATE_DEAD;
        public static readonly Effect FIRST_SPELL_4TH = SPELL_PLACEHOLDER_4TH;
        public static readonly Effect FIRST_SPELL_5TH = SPELL_PLACEHOLDER_5TH;
        public static readonly Effect FIRST_SPELL_6TH = SPELL_PLACEHOLDER_6TH;
        public static readonly Effect FIRST_SPELL_7TH = SPELL_PLACEHOLDER_7TH;
        public static readonly Effect FIRST_SPELL_8TH = SPELL_PLACEHOLDER_8TH;
        public static readonly Effect FIRST_SPELL_9TH = SPELL_PLACEHOLDER_9TH;
        public static readonly Effect LAST_SPELL_9TH = SPELL_PLACEHOLDER_9TH;

        public static Effect[] GetSpellEffects(SpellLevel level) {
            int lowerBoundary, upperBoundary;
            switch (level) {
                case SpellLevel.CANTRIP:
                    lowerBoundary = (int)FIRST_SPELL_CANTRIP;
                    upperBoundary = (int)FIRST_SPELL_1ST;
                    break;
                case SpellLevel.FIRST:
                    lowerBoundary = (int)FIRST_SPELL_1ST;
                    upperBoundary = (int)FIRST_SPELL_2ND;
                    break;
                case SpellLevel.SECOND:
                    lowerBoundary = (int)FIRST_SPELL_2ND;
                    upperBoundary = (int)FIRST_SPELL_3RD;
                    break;
                case SpellLevel.THIRD:
                    lowerBoundary = (int)FIRST_SPELL_3RD;
                    upperBoundary = (int)FIRST_SPELL_4TH;
                    break;
                case SpellLevel.FOURTH:
                    lowerBoundary = (int)FIRST_SPELL_4TH;
                    upperBoundary = (int)FIRST_SPELL_5TH;
                    break;
                case SpellLevel.FIFTH:
                    lowerBoundary = (int)FIRST_SPELL_5TH;
                    upperBoundary = (int)FIRST_SPELL_6TH;
                    break;
                case SpellLevel.SIXTH:
                    lowerBoundary = (int)FIRST_SPELL_6TH;
                    upperBoundary = (int)FIRST_SPELL_7TH;
                    break;
                case SpellLevel.SEVENTH:
                    lowerBoundary = (int)FIRST_SPELL_7TH;
                    upperBoundary = (int)FIRST_SPELL_8TH;
                    break;
                case SpellLevel.EIGHTH:
                    lowerBoundary = (int)FIRST_SPELL_8TH;
                    upperBoundary = (int)FIRST_SPELL_9TH;
                    break;
                case SpellLevel.NINTH:
                default:
                    lowerBoundary = (int)FIRST_SPELL_9TH;
                    upperBoundary = (int)LAST_SPELL_9TH;
                    break;
            }
            Effect[] effects = new Effect[upperBoundary - lowerBoundary + 1];
            for (int i = 0; i < effects.Length; i++) {
                effects[i] = (Effect)(lowerBoundary + i);
            }
            return effects;
        }
    }

    public static class EffectExtension {
        public static void Apply(this Effect effect, Combatant combatant) {
            int turn = 0;
            int duration;
            int dc;
            DamageSource source = new DamageSource(DamageSourceType.ATTACK, effect, combatant);
            switch (effect) {
                case HEAVY_ARMOR_SPEED_PENALITY:
                    combatant.Speed -= 10;
                    break;
                case CONSTITUTION_19:
                case INTELLIGENCE_19:
                    applyAbilityEffect(effect, combatant);
                    break;
                case PROTECTION:
                    combatant.ArmorClassModifier++;
                    break;
                case ONE_EXTRA_ATTACK:
                case TWO_EXTRA_ATTACKS:
                case THREE_EXTRA_ATTACKS:
                    if (combatant is CharacterSheet sheet) {
                        sheet.RecalculateAttacks();
                    }
                    break;
                case SPELL_LONGSTRIDER:
                    combatant.Speed += 10;
                    break;
                case SPELL_ENTANGLE:
                    combatant.AddCondition(ConditionType.RESTRAINED);
                    break;
                case SPELL_FAIRIE_FIRE:
                    combatant.AddEffect(ADVANTAGE_ON_BEING_ATTACKED);
                    break;
                case IMMUNITY_TRUE_DAMAGE:
                case RESISTANCE_TRUE_DAMAGE:
                case VULNERABILITY_TRUE_DAMAGE:
                    throw new Srd5ArgumentException("Do not aply True Damage effects.");
                case COUATL_POISON:
                    combatant.AddCondition(ConditionType.POISONED);
                    combatant.AddCondition(ConditionType.UNCONSCIOUS);
                    break;
                case BEARDED_DEVIL_POISON:
                case BONE_DEVIL_POISON:
                case DEATH_DOG_DISEASE:
                case DROW_POISON:
                case ERINYES_POISON:
                case ETTERCAP_POISON:
                case HOMUNCULUS_POISON:
                    combatant.AddCondition(ConditionType.POISONED);
                    break;
                case ETTERCAP_WEB:
                    combatant.AddCondition(ConditionType.RESTRAINED);
                    break;
                case FIRE_ELEMENTAL_IGNITE:
                    combatant.AddStartOfTurnEvent(delegate () {
                        if (!combatant.HasEffect(effect)) return true;
                        combatant.TakeDamage(source, FIRE, D10);
                        return false;
                    });
                    break;
                case GHAST_CLAWS_PARALYZATION:
                case GHOUL_CLAWS_PARALYZATION:
                case LICH_PARALYZATION:
                    combatant.AddCondition(ConditionType.PARALYZED);
                    dc = 10;
                    duration = 10; // one minute 
                    if (effect == LICH_PARALYZATION) dc = 18;
                    combatant.AddEndOfTurnEvent(delegate () {
                        if (!combatant.HasEffect(effect)) return true;
                        bool success = combatant.DC(effect, dc, AbilityType.CONSTITUTION);
                        if (turn++ >= duration) success = true;
                        if (success) combatant.RemoveEffect(effect);
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
                    combatant.AddEffect(CANNOT_REGAIN_HITPOINTS);
                    break;
                case HOMUNCULUS_POISON_UNCONCIOUSNESS:
                    combatant.AddCondition(ConditionType.POISONED, ConditionType.UNCONSCIOUS);
                    break;
                case MAGMIN_IGNITE:
                    combatant.AddStartOfTurnEvent(delegate () {
                        if (!combatant.HasEffect(effect)) return true;
                        combatant.TakeDamage(source, FIRE, D6);
                        return false;
                    });
                    break;
                case OTYUGH_DISEASE:
                    combatant.AddCondition(ConditionType.POISONED);
                    // TODO: Every 24 hours that elapse, the target must repeat the saving throw, 
                    // reducing its hit point maximum by 5 (1d10) on a failure. The disease is cured on a success. 
                    // The target dies if the disease reduces its hit point maximum to 0. 
                    // This reduction to the target's hit point maximum lasts until the disease is cured.
                    break;
                case PHASE_SPIDER_POISON:
                    combatant.AddCondition(ConditionType.POISONED, ConditionType.PARALYZED);
                    break;
                case PIT_FIEND_POISON:
                    combatant.AddCondition(ConditionType.POISONED);
                    combatant.AddEffect(CANNOT_REGAIN_HITPOINTS);
                    combatant.AddStartOfTurnEvent(delegate () {
                        if (!combatant.HasEffect(effect)) return true;
                        combatant.TakeDamage(source, POISON, 6 * D6);
                        return false;
                    });
                    combatant.AddEndOfTurnEvent(delegate () {
                        if (!combatant.HasEffect(effect)) return true;
                        if (combatant.DC(effect, 21, AbilityType.CONSTITUTION)) {
                            combatant.RemoveEffect(effect);
                            return true;
                        }
                        return false;
                    });
                    break;
                case PSEUDO_DRAGON_POISON:
                case SPRITE_POISON:
                    combatant.AddCondition(ConditionType.POISONED);
                    break;
                case PSEUDO_DRAGON_POISON_UNCONSCIOUS:
                case SPRITE_POISON_UNCONCIOUS:
                    combatant.AddCondition(ConditionType.UNCONSCIOUS);
                    // TODO: If the saving throw fails by 5 or more, the target falls unconscious for the same duration, 
                    // or until it takes damage or another creature uses an action to shake it awake.
                    break;
                case QUASIT_POISON:
                    combatant.AddCondition(ConditionType.POISONED);
                    dc = 10;
                    duration = 10; // one minute
                    combatant.AddEndOfTurnEvent(delegate () {
                        if (!combatant.HasEffect(effect)) return true;
                        bool success = combatant.DC(effect, dc, AbilityType.CONSTITUTION);
                        if (turn++ >= duration) success = true;
                        if (success) combatant.RemoveEffect(effect);
                        return success;
                    });
                    break;
                case RUG_SMOTHER:
                    if (!combatant.HasEffect(IMMUNITY_BLINDED)) combatant.AddCondition(ConditionType.BLINDED);
                    combatant.AddStartOfTurnEvent(delegate () {
                        if (combatant.HasCondition(ConditionType.GRAPPLED_DC13)) {
                            combatant.TakeDamage(source, BLUDGEONING, 2 * D6 + 3);
                            return false;
                        } else {
                            return true;
                        }
                    });
                    break;
                case FIGHTING_DEATH:
                    combatant.AddStartOfTurnEvent(delegate () {
                        // Don't roll if stabilized
                        if (combatant.HasEffect(FIGHTING_DEATH_STABILIZED)) {
                            combatant.RemoveEffect(FIGHTING_DEATH);
                            return true;
                        }
                        // Death Save is DC10 with no Ability
                        int deathSaveRoll = D20.Value;
                        if (combatant.HasEffect(ADVANTAGE_DEATH_SAVES)) {
                            deathSaveRoll = Math.Max(deathSaveRoll, D20.Value);
                        }
                        bool success = deathSaveRoll > 9;
                        GlobalEvents.RolledDC(combatant, FIGHTING_DEATH, new Ability(AbilityType.NONE, 9), 10, deathSaveRoll, success);
                        if (success) {
                            // Critical success counts as 2 successes
                            if (deathSaveRoll == 20) {
                                if (combatant.HasEffect(FIGHTING_DEATH_SAVE_SUCCESS_1) || combatant.HasEffect(FIGHTING_DEATH_SAVE_SUCCESS_2)) {
                                    combatant.RemoveEffect(FIGHTING_DEATH);
                                    return true;
                                } else {
                                    combatant.AddEffect(FIGHTING_DEATH_SAVE_SUCCESS_2);
                                    return false;
                                }
                            } else if (combatant.HasEffect(FIGHTING_DEATH_SAVE_SUCCESS_2)) {
                                // third success => stabilized
                                combatant.RemoveEffect(FIGHTING_DEATH);
                                return true;
                            } else if (combatant.HasEffect(FIGHTING_DEATH_SAVE_SUCCESS_1)) {
                                combatant.AddEffect(FIGHTING_DEATH_SAVE_SUCCESS_2);
                                return false;
                            } else {
                                combatant.AddEffect(FIGHTING_DEATH_SAVE_SUCCESS_1);
                                return false;
                            }
                        } else {
                            // Critical fail counts as 2 fails
                            if (deathSaveRoll == 1) {
                                if (combatant.HasEffect(FIGHTING_DEATH_SAVE_FAIL_1) || combatant.HasEffect(FIGHTING_DEATH_SAVE_FAIL_2)) {
                                    combatant.RemoveEffect(FIGHTING_DEATH);
                                    combatant.Die();
                                    return true;
                                } else {
                                    combatant.AddEffect(FIGHTING_DEATH_SAVE_FAIL_2);
                                    return false;
                                }
                            } else if (combatant.HasEffect(FIGHTING_DEATH_SAVE_FAIL_2)) {
                                // third fail => dead
                                combatant.RemoveEffect(FIGHTING_DEATH);
                                combatant.Die();
                                return true;
                            } else if (combatant.HasEffect(FIGHTING_DEATH_SAVE_FAIL_1)) {
                                combatant.AddEffect(FIGHTING_DEATH_SAVE_FAIL_2);
                                return false;
                            } else {
                                combatant.AddEffect(FIGHTING_DEATH_SAVE_FAIL_1);
                                return false;
                            }
                        }
                    });
                    break;
                case SPELL_COMMAND_GROVEL:
                case SPELL_HIDEOUS_LAUGHTER:
                    combatant.AddEffect(CANNOT_TAKE_ACTIONS);
                    break;
                case SPELL_HYPNOTIC_PATTERN:
                    // Charmed/incapacitated conditions and speed 0 are managed by the spell closure
                    break;
                case SPELL_ALTER_SELF_CLAWS:
                    if (combatant is CharacterSheet hero) {
                        hero.Unequip(hero.Inventory.MainHand);
                        hero.Equip(Weapons.Claws);
                    }
                    break;
                case SPELL_BLUR:
                    combatant.AddEffect(DISADVANTAGE_ON_BEING_ATTACKED);
                    break;
                case SPELL_CALM_EMOTIONS:
                    if (combatant.HasCondition(ConditionType.CHARMED)) {
                        combatant.AddEffect(SPELL_CALM_EMOTIONS_CHARMED_SUPRESSED);
                        combatant.RemoveCondition(ConditionType.CHARMED);
                    }
                    if (combatant.HasCondition(ConditionType.FRIGHTENED)) {
                        combatant.AddEffect(SPELL_CALM_EMOTIONS_FRIGHTENED_SUPRESSED);
                        combatant.RemoveCondition(ConditionType.FRIGHTENED);
                    }
                    break;
                case SPELL_DARKVISION:
                    combatant.AddEffect(DARKVISION);
                    break;
                case SPELL_ENLARGE:
                    combatant.Size++;
                    break;
                case SPELL_REDUCE:
                    combatant.Size--;
                    break;
                case SPELL_GUST_OF_WIND:
                    combatant.Speed /= 2;
                    break;
                case SPELL_PROTECTION_FROM_POISON:
                    combatant.AddEffect(ADVANTAGE_POISON_SAVES, RESISTANCE_POISON);
                    break;
                case SPELL_SILENCE:
                    combatant.AddEffect(IMMUNITY_THUNDER);
                    combatant.AddCondition(ConditionType.DEAFENED);
                    break;
                case SPELL_SUGGESTION:
                    combatant.AddEffect(CANNOT_TAKE_ACTIONS);
                    break;
                case SPELL_WARDING_BOND:
                    combatant.AddEffect(RESISTANCE_ANY_DAMAGE);
                    break;
                case SPELL_BEACON_OF_HOPE:
                    combatant.AddEffect(ADVANTAGE_WISDOM_SAVES, ADVANTAGE_DEATH_SAVES);
                    break;
                case SPELL_BESTOW_CURSE_LOST_TURN:
                    combatant.AddEffect(CANNOT_TAKE_ACTIONS);
                    combatant.AddEndOfTurnEvent(delegate () {
                        combatant.RemoveEffect(SPELL_BESTOW_CURSE_LOST_TURN);
                        return true;
                    });
                    break;
                case SPELL_INVISIBILITY:
                    combatant.AddCondition(ConditionType.INVISIBLE);
                    break;
                case SPELL_HASTE:
                    combatant.ArmorClassModifier += 2;
                    combatant.AddEffect(ONE_EXTRA_ATTACK);
                    combatant.AddEffect(ADVANTAGE_DEXTERITY_SAVES);
                    combatant.Speed *= 2;
                    break;
                case SPELL_SLOW:
                    combatant.AddEffect(DISADVANTAGE_DEXTERITY_SAVES);
                    combatant.AddEffect(DISADVANTAGE_ON_ATTACK);
                    combatant.Speed /= 2;
                    combatant.AddEffect(CANNOT_TAKE_REACTIONS);
                    break;
                case SPELL_SPIRIT_GUARDIANS:
                    combatant.Speed /= 2;
                    break;
                case SPELL_PROTECTION_FROM_ENERGY:
                    // Resistance is applied via variant in the spell itself
                    break;
                case SPELL_FLY:
                    // TODO: grant flying movement speed
                    break;
                case SPELL_GASEOUS_FORM:
                    // TODO: apply gaseous resistances, flying speed, object passage
                    break;
                case SPELL_MELD_INTO_STONE:
                    // TODO: merge caster into stone surface
                    break;
                case SPELL_NONDETECTION:
                    // TODO: block divination effects
                    break;
                case SPELL_TONGUES:
                    // TODO: grant comprehension of all spoken languages
                    break;
                case SPELL_WATER_BREATHING:
                    // TODO: allow breathing underwater
                    break;
                case SPELL_WATER_WALK:
                    // TODO: allow walking on liquid surfaces
                    break;
            }
        }

        public static void Unapply(this Effect effect, Combatant combatant) {
            switch (effect) {
                case HEAVY_ARMOR_SPEED_PENALITY:
                    combatant.Speed += 10;
                    break;
                case CONSTITUTION_19:
                case INTELLIGENCE_19:
                    unapplyAbilityEffect(effect, combatant);
                    break;
                case PROTECTION:
                    combatant.ArmorClassModifier--;
                    break;
                case ONE_EXTRA_ATTACK:
                case TWO_EXTRA_ATTACKS:
                case THREE_EXTRA_ATTACKS:
                    if (combatant is CharacterSheet sheet) {
                        sheet.RecalculateAttacks();
                    }
                    ;
                    break;
                case SPELL_LONGSTRIDER:
                    combatant.Speed -= 10;
                    break;
                case SPELL_ENTANGLE:
                    combatant.RemoveCondition(ConditionType.RESTRAINED);
                    break;
                case SPELL_FAIRIE_FIRE:
                    combatant.RemoveEffect(ADVANTAGE_ON_BEING_ATTACKED);
                    break;
                case COUATL_POISON:
                    combatant.RemoveCondition(ConditionType.POISONED);
                    combatant.RemoveCondition(ConditionType.UNCONSCIOUS);
                    break;
                case BEARDED_DEVIL_POISON:
                case BONE_DEVIL_POISON:
                case DEATH_DOG_DISEASE:
                case DROW_POISON:
                case ERINYES_POISON:
                case ETTERCAP_POISON:
                case HOMUNCULUS_POISON:
                    combatant.RemoveCondition(ConditionType.POISONED);
                    break;
                case ETTERCAP_WEB:
                    combatant.RemoveCondition(ConditionType.RESTRAINED);
                    break;
                case GHAST_CLAWS_PARALYZATION:
                case GHOUL_CLAWS_PARALYZATION:
                case LICH_PARALYZATION:
                    combatant.RemoveCondition(ConditionType.PARALYZED);
                    break;
                case HOMUNCULUS_POISON_UNCONCIOUSNESS:
                    combatant.RemoveCondition(ConditionType.POISONED, ConditionType.UNCONSCIOUS);
                    break;
                case OTYUGH_DISEASE:
                    combatant.RemoveCondition(ConditionType.POISONED);
                    // TODO: Every 24 hours that elapse, the target must repeat the saving throw, 
                    // reducing its hit point maximum by 5 (1d10) on a failure. The disease is cured on a success. 
                    // The target dies if the disease reduces its hit point maximum to 0. 
                    // This reduction to the target's hit point maximum lasts until the disease is cured.
                    break;
                case PHASE_SPIDER_POISON:
                    combatant.RemoveCondition(ConditionType.POISONED, ConditionType.PARALYZED);
                    break;
                case PIT_FIEND_POISON:
                    combatant.RemoveCondition(ConditionType.POISONED);
                    combatant.RemoveEffect(CANNOT_REGAIN_HITPOINTS);
                    break;
                case PSEUDO_DRAGON_POISON:
                    combatant.RemoveCondition(ConditionType.POISONED);
                    break;
                case PSEUDO_DRAGON_POISON_UNCONSCIOUS:
                    combatant.RemoveCondition(ConditionType.UNCONSCIOUS);
                    break;
                case QUASIT_POISON:
                    combatant.RemoveCondition(ConditionType.POISONED);
                    break;
                case RUG_SMOTHER:
                    combatant.RemoveCondition(ConditionType.BLINDED);
                    break;
                case CURSE_MUMMY_ROT:
                    combatant.RemoveEffect(CANNOT_REGAIN_HITPOINTS);
                    break;
                case FIGHTING_DEATH:
                    combatant.RemoveEffect(FIGHTING_DEATH_SAVE_FAIL_1,
                                             FIGHTING_DEATH_SAVE_FAIL_2,
                                             FIGHTING_DEATH_SAVE_SUCCESS_1,
                                             FIGHTING_DEATH_SAVE_SUCCESS_2,
                                             FIGHTING_DEATH_STABILIZED);
                    break;
                case SPELL_COMMAND_GROVEL:
                case SPELL_HIDEOUS_LAUGHTER:
                    combatant.RemoveEffect(CANNOT_TAKE_ACTIONS);
                    break;
                case SPELL_HYPNOTIC_PATTERN:
                    // Conditions and speed restoration are managed by the spell closure
                    break;
                case SPELL_ALTER_SELF_CLAWS:
                    if (combatant is CharacterSheet hero) {
                        if (hero.Inventory.MainHand.Is(Weapons.Claws)) {
                            hero.Inventory.MainHand = null;
                        }
                    }
                    break;
                case SPELL_BLUR:
                    combatant.RemoveEffect(DISADVANTAGE_ON_BEING_ATTACKED);
                    break;
                case SPELL_CALM_EMOTIONS:
                    if (combatant.HasEffect(SPELL_CALM_EMOTIONS_CHARMED_SUPRESSED)) {
                        combatant.RemoveEffect(SPELL_CALM_EMOTIONS_CHARMED_SUPRESSED);
                        // TODO: Add all effects here that cause charmed. If still present, re-apply condition.
                        // NOTE: Animal Friendship doesn't apply to Humanoids, so it is not valid here
                    }
                    if (combatant.HasEffect(SPELL_CALM_EMOTIONS_FRIGHTENED_SUPRESSED)) {
                        combatant.RemoveEffect(SPELL_CALM_EMOTIONS_FRIGHTENED_SUPRESSED);
                        // TODO: Add all effects here that cause frightened. If still present, re-apply condition.
                    }
                    break;
                case SPELL_DARKVISION:
                    combatant.RemoveEffect(DARKVISION);
                    break;
                case SPELL_ENLARGE:
                    combatant.Size--;
                    break;
                case SPELL_REDUCE:
                    combatant.Size++;
                    break;
                case SPELL_GUST_OF_WIND:
                    combatant.Speed *= 2;
                    break;
                case SPELL_PROTECTION_FROM_POISON:
                    combatant.RemoveEffect(ADVANTAGE_POISON_SAVES, RESISTANCE_POISON);
                    break;
                case SPELL_SILENCE:
                    combatant.RemoveEffect(IMMUNITY_THUNDER);
                    combatant.RemoveCondition(ConditionType.DEAFENED);
                    break;
                case SPELL_SUGGESTION:
                    combatant.RemoveEffect(CANNOT_TAKE_ACTIONS);
                    break;
                case SPELL_WARDING_BOND:
                    combatant.RemoveEffect(RESISTANCE_ANY_DAMAGE);
                    break;
                case SPELL_BEACON_OF_HOPE:
                    combatant.RemoveEffect(ADVANTAGE_WISDOM_SAVES, ADVANTAGE_DEATH_SAVES);
                    break;
                case SPELL_BESTOW_CURSE_LOST_TURN:
                    combatant.RemoveEffect(CANNOT_TAKE_ACTIONS);
                    break;
                case SPELL_INVISIBILITY:
                    combatant.RemoveCondition(ConditionType.INVISIBLE);
                    break;
                case SPELL_HASTE:
                    combatant.ArmorClassModifier -= 2;
                    combatant.RemoveEffect(ONE_EXTRA_ATTACK);
                    combatant.RemoveEffect(ADVANTAGE_DEXTERITY_SAVES);
                    combatant.Speed /= 2;
                    break;
                case SPELL_SLOW:
                    combatant.RemoveEffect(DISADVANTAGE_DEXTERITY_SAVES);
                    combatant.RemoveEffect(DISADVANTAGE_ON_ATTACK);
                    combatant.Speed *= 2;
                    combatant.RemoveEffect(CANNOT_TAKE_REACTIONS);
                    break;
                case SPELL_SPIRIT_GUARDIANS:
                    combatant.Speed *= 2;
                    break;
                case SPELL_PROTECTION_FROM_ENERGY:
                    // Resistance applied via variants in spell itself
                    break;
                case SPELL_FLY:
                case SPELL_GASEOUS_FORM:
                case SPELL_MELD_INTO_STONE:
                case SPELL_NONDETECTION:
                case SPELL_TONGUES:
                case SPELL_WATER_BREATHING:
                case SPELL_WATER_WALK:
                    // TODO: reverse effect-specific mechanics when implemented
                    break;
            }
        }

        private static void applyAbilityEffect(Effect effect, Combatant combatant) {
            switch (effect) {
                case INTELLIGENCE_19:
                    combatant.Intelligence.AddMinimumBaseValue(19);
                    break;
                case CONSTITUTION_19:
                    combatant.Constitution.AddMinimumBaseValue(19);
                    break;
            }
        }

        private static void unapplyAbilityEffect(Effect effect, Combatant combatant) {
            switch (effect) {
                case INTELLIGENCE_19:
                    combatant.Intelligence.RemoveMinimumBaseValue(19);
                    break;
                case CONSTITUTION_19:
                    combatant.Constitution.RemoveMinimumBaseValue(19);
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

        public static bool IsSpell(this Effect effect) {
            return Enum.GetName(typeof(Effect), effect).StartsWith("SPELL_");
        }

        public static SpellLevel SpellLevel(this Effect effect) {
            if (!IsSpell(effect)) throw new Srd5ArgumentException("Effect is not a spell effect.");
            if (effect >= Effects.FIRST_SPELL_9TH)
                return srd5.SpellLevel.NINTH;
            if (effect >= Effects.FIRST_SPELL_8TH)
                return srd5.SpellLevel.EIGHTH;
            if (effect >= Effects.FIRST_SPELL_7TH)
                return srd5.SpellLevel.SEVENTH;
            if (effect >= Effects.FIRST_SPELL_6TH)
                return srd5.SpellLevel.SIXTH;
            if (effect >= Effects.FIRST_SPELL_5TH)
                return srd5.SpellLevel.FIFTH;
            if (effect >= Effects.FIRST_SPELL_4TH)
                return srd5.SpellLevel.FOURTH;
            if (effect >= Effects.FIRST_SPELL_3RD)
                return srd5.SpellLevel.THIRD;
            if (effect >= Effects.FIRST_SPELL_2ND)
                return srd5.SpellLevel.SECOND;
            if (effect >= Effects.FIRST_SPELL_1ST)
                return srd5.SpellLevel.FIRST;
            if (effect >= Effects.FIRST_SPELL_CANTRIP)
                return srd5.SpellLevel.CANTRIP;
            throw new Srd5ArgumentException("Effect does not match any spell level.");
        }
    }
}
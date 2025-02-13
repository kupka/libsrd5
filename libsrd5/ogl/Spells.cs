using System;
using System.Collections;

namespace srd5 {
    public enum SpellSchool {
        ABJURATION,
        CONJURATION,
        DIVINATION,
        ENCHANTMENT,
        EVOCATION,
        ILLUSION,
        NECROMANCY,
        TRANSMUTATION
    }

    public enum SpellLevel {
        CANTRIP = 0,
        FIRST = 1,
        SECOND = 2,
        THIRD = 3,
        FOURTH = 4,
        FIFTH = 5,
        SIXTH = 6,
        SEVENTH = 7,
        EIGHTH = 8,
        NINETH = 9
    }

    public enum CastingTime {
        BONUS_ACTION,
        REACTION,
        ONE_ACTION,
        ONE_ROUND,
        ONE_MINUTE,
        TEN_MINUTES,
        ONE_HOUR,
        EIGHT_HOURS,
        TWELVE_HOURS,
        ONE_DAY
    }

    public enum SpellComponent {
        VERBAL,
        SOMATIC,
        MATERIAL
    }

    public enum SpellDuration {
        SPECIAL = -1,
        INSTANTANEOUS = 0,
        ONE_ROUND = 6,
        ONE_MINUTE = 60,
        TEN_MINUTES = 60 * 10,
        ONE_HOUR = 3600,
        TWO_HOURS = 3600 * 2,
        EIGHT_HOURS = 3600 * 8,
        ONE_DAY = 86400,
        SEVEN_DAYS = 86400 * 7,
        TEN_DAYS = 86400 * 10,
        THIRTY_DAYS = 86400 * 30,
        UNTIL_DISPELLED = 99999999
    }

    public delegate void SpellCastEffect(Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, params Combattant[] targets);

    public partial struct Spells {
        private static readonly SpellCastEffect doNothing = delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) { };

        private static SpellCastEffect SpellWithoutEffect(ID spell) {
            return delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                GlobalEvents.CastSpell(caster, spell);
            };
        }


        private static SpellComponent[] S {
            get {
                return new SpellComponent[] { SpellComponent.SOMATIC };
            }
        }

        private static SpellComponent[] SM {
            get {
                return new SpellComponent[] { SpellComponent.SOMATIC, SpellComponent.MATERIAL };
            }
        }

        private static SpellComponent[] V {
            get {
                return new SpellComponent[] { SpellComponent.VERBAL };
            }
        }

        private static SpellComponent[] VM {
            get {
                return new SpellComponent[] { SpellComponent.VERBAL, SpellComponent.MATERIAL };
            }
        }

        private static SpellComponent[] VS {
            get {
                return new SpellComponent[] { SpellComponent.VERBAL, SpellComponent.SOMATIC };
            }
        }

        private static SpellComponent[] VSM {
            get {
                return new SpellComponent[] { SpellComponent.VERBAL, SpellComponent.SOMATIC, SpellComponent.MATERIAL };
            }
        }

        public enum ID {
            DEFAULT,
            ACID_ARROW,
            ACID_SPLASH,
            AID,
            ALARM,
            ALTER_SELF,
            ANIMAL_FRIENDSHIP,
            ANIMAL_MESSENGER,
            ANIMAL_SHAPES,
            ANIMATE_DEAD,
            ANIMATE_OBJECTS,
            ANTILIFE_SHELL,
            ANTIMAGIC_FIELD,
            ANTIPATHY_SYMPATHY,
            ARCANE_EYE,
            ARCANE_HAND,
            ARCANE_LOCK,
            ARCANE_SWORD,
            ARCANISTS_MAGIC_AURA,
            ASTRAL_PROJECTION,
            AUGURY,
            AWAKEN,
            BANE,
            BANISHMENT,
            BARKSKIN,
            BEACON_OF_HOPE,
            BESTOW_CURSE,
            BLACK_TENTACLES,
            BLADE_BARRIER,
            BLESS,
            BLIGHT,
            BLINDNESS_DEAFNESS,
            BLINK,
            BLUR,
            BRANDING_SMITE,
            BURNING_HANDS,
            CALL_LIGHTNING,
            CALM_EMOTIONS,
            CHAIN_LIGHTNING,
            CHARM_PERSON,
            CHILL_TOUCH,
            CIRCLE_OF_DEATH,
            CLAIRVOYANCE,
            CLONE,
            CLOUDKILL,
            COLOR_SPRAY,
            COMMAND,
            COMMUNE,
            COMMUNE_WITH_NATURE,
            COMPREHEND_LANGUAGES,
            COMPULSION,
            CONE_OF_COLD,
            CONFUSION,
            CONJURE_ANIMALS,
            CONJURE_CELESTIAL,
            CONJURE_ELEMENTAL,
            CONJURE_FEY,
            CONJURE_MINOR_ELEMENTALS,
            CONJURE_WOODLAND_BEINGS,
            CONTACT_OTHER_PLANE,
            CONTAGION,
            CONTINGENCY,
            CONTINUAL_FLAME,
            CONTROL_WATER,
            CONTROL_WEATHER,
            COUNTERSPELL,
            CREATE_FOOD_AND_WATER,
            CREATE_UNDEAD,
            CREATE_OR_DESTROY_WATER,
            CREATION,
            CURE_WOUNDS,
            DANCING_LIGHTS,
            DARKNESS,
            DARKVISION,
            DAYLIGHT,
            DEATH_WARD,
            DELAYED_BLAST_FIREBALL,
            DEMIPLANE,
            DETECT_EVIL_AND_GOOD,
            DETECT_MAGIC,
            DETECT_POISON_AND_DISEASE,
            DETECT_THOUGHTS,
            DIMENSION_DOOR,
            DISGUISE_SELF,
            DISINTEGRATE,
            DISPEL_EVIL_AND_GOOD,
            DISPEL_MAGIC,
            DIVINATION,
            DIVINE_FAVOR,
            DIVINE_WORD,
            DOMINATE_BEAST,
            DOMINATE_MONSTER,
            DOMINATE_PERSON,
            DREAM,
            DRUIDCRAFT,
            EARTHQUAKE,
            ELDRITCH_BLAST,
            ENHANCE_ABILITY,
            ENLARGE_REDUCE,
            ENTANGLE,
            ENTHRALL,
            ETHEREALNESS,
            EXPEDITIOUS_RETREAT,
            EYEBITE,
            FABRICATE,
            FAERIE_FIRE,
            FAITHFUL_HOUND,
            FALSE_LIFE,
            FEAR,
            FEATHER_FALL,
            FEEBLEMIND,
            FIND_FAMILIAR,
            FIND_STEED,
            FIND_TRAPS,
            FIND_THE_PATH,
            FINGER_OF_DEATH,
            FIRE_BOLT,
            FIRE_SHIELD,
            FIRE_STORM,
            FIREBALL,
            FLAME_BLADE,
            FLAME_STRIKE,
            FLAMING_SPHERE,
            FLESH_TO_STONE,
            FLOATING_DISK,
            FLY,
            FOG_CLOUD,
            FORBIDDANCE,
            FORCECAGE,
            FORESIGHT,
            FREEDOM_OF_MOVEMENT,
            FREEZING_SPHERE,
            GASEOUS_FORM,
            GATE,
            GEAS,
            GENTLE_REPOSE,
            GIANT_INSECT,
            GLIBNESS,
            GLOBE_OF_INVULNERABILITY,
            GLYPH_OF_WARDING,
            GOODBERRY,
            GREASE,
            GREATER_INVISIBILITY,
            GREATER_RESTORATION,
            GUARDIAN_OF_FAITH,
            GUARDS_AND_WARDS,
            GUIDANCE,
            GUIDING_BOLT,
            GUST_OF_WIND,
            HALLOW,
            HALLUCINATORY_TERRAIN,
            HARM,
            HASTE,
            HEAL,
            HEALING_WORD,
            HEAT_METAL,
            HELLISH_REBUKE,
            HEROES_FEAST,
            HEROISM,
            HIDEOUS_LAUGHTER,
            HOLD_MONSTER,
            HOLD_PERSON,
            HOLY_AURA,
            HUNTERS_MARK,
            HYPNOTIC_PATTERN,
            ICE_STORM,
            IDENTIFY,
            ILLUSORY_SCRIPT,
            IMPRISONMENT,
            INCENDIARY_CLOUD,
            INFLICT_WOUNDS,
            INSECT_PLAGUE,
            INSTANT_SUMMONS,
            INVISIBILITY,
            IRRESISTIBLE_DANCE,
            JUMP,
            KNOCK,
            LEGEND_LORE,
            LESSER_RESTORATION,
            LEVITATE,
            LIGHT,
            LIGHTNING_BOLT,
            LOCATE_ANIMALS_OR_PLANTS,
            LOCATE_CREATURE,
            LOCATE_OBJECT,
            LONGSTRIDER,
            MAGE_ARMOR,
            MAGE_HAND,
            MAGIC_CIRCLE,
            MAGIC_JAR,
            MAGIC_MISSILE,
            MAGIC_MOUTH,
            MAGIC_WEAPON,
            MAGNIFICENT_MANSION,
            MAJOR_IMAGE,
            MASS_CURE_WOUNDS,
            MASS_HEAL,
            MASS_HEALING_WORD,
            MASS_SUGGESTION,
            MAZE,
            MELD_INTO_STONE,
            MENDING,
            MESSAGE,
            METEOR_SWARM,
            MIND_BLANK,
            MINOR_ILLUSION,
            MIRAGE_ARCANE,
            MIRROR_IMAGE,
            MISLEAD,
            MISTY_STEP,
            MODIFY_MEMORY,
            MOONBEAM,
            MOVE_EARTH,
            NONDETECTION,
            PASS_WITHOUT_TRACE,
            PASSWALL,
            PHANTASMAL_KILLER,
            PHANTOM_STEED,
            PLANAR_ALLY,
            PLANAR_BINDING,
            PLANE_SHIFT,
            PLANT_GROWTH,
            POISON_SPRAY,
            POLYMORPH,
            POWER_WORD_KILL,
            POWER_WORD_STUN,
            PRAYER_OF_HEALING,
            PRESTIDIGITATION,
            PRISMATIC_SPRAY,
            PRISMATIC_WALL,
            PRIVATE_SANCTUM,
            PRODUCE_FLAME,
            PROGRAMMED_ILLUSION,
            PROJECT_IMAGE,
            PROTECTION_FROM_ENERGY,
            PROTECTION_FROM_EVIL_AND_GOOD,
            PROTECTION_FROM_POISON,
            PURIFY_FOOD_AND_DRINK,
            RAISE_DEAD,
            RAY_OF_ENFEEBLEMENT,
            RAY_OF_FROST,
            REGENERATE,
            REINCARNATE,
            REMOVE_CURSE,
            RESILIENT_SPHERE,
            RESISTANCE,
            RESURRECTION,
            REVERSE_GRAVITY,
            REVIVIFY,
            ROPE_TRICK,
            SACRED_FLAME,
            SANCTUARY,
            SCORCHING_RAY,
            SCRYING,
            SECRET_CHEST,
            SEE_INVISIBILITY,
            SEEMING,
            SENDING,
            SEQUESTER,
            SHAPECHANGE,
            SHATTER,
            SHIELD,
            SHIELD_OF_FAITH,
            SHILLELAGH,
            SHOCKING_GRASP,
            SILENCE,
            SILENT_IMAGE,
            SIMULACRUM,
            SLEEP,
            SLEET_STORM,
            SLOW,
            SPARE_THE_DYING,
            SPEAK_WITH_ANIMALS,
            SPEAK_WITH_DEAD,
            SPEAK_WITH_PLANTS,
            SPIDER_CLIMB,
            SPIKE_GROWTH,
            SPIRIT_GUARDIANS,
            SPIRITUAL_WEAPON,
            STINKING_CLOUD,
            STONE_SHAPE,
            STONESKIN,
            STORM_OF_VENGEANCE,
            SUGGESTION,
            SUNBEAM,
            SUNBURST,
            SYMBOL,
            TELEKINESIS,
            TELEPATHIC_BOND,
            TELEPORT,
            TELEPORTATION_CIRCLE,
            THAUMATURGY,
            THUNDERWAVE,
            TIME_STOP,
            TINY_HUT,
            TONGUES,
            TRANSPORT_VIA_PLANTS,
            TREE_STRIDE,
            TRUE_POLYMORPH,
            TRUE_RESURRECTION,
            TRUE_SEEING,
            TRUE_STRIKE,
            UNSEEN_SERVANT,
            VAMPIRIC_TOUCH,
            VICIOUS_MOCKERY,
            WALL_OF_FIRE,
            WALL_OF_FORCE,
            WALL_OF_ICE,
            WALL_OF_STONE,
            WALL_OF_THORNS,
            WARDING_BOND,
            WATER_BREATHING,
            WATER_WALK,
            WEB,
            WEIRD,
            WIND_WALK,
            WIND_WALL,
            WISH,
            WORD_OF_RECALL,
            ZONE_OF_TRUTH,
        }

        /// <summary>
        /// Scales dice by 4th, 10th and 17th level of the caster.
        /// </summary>
        internal static Dice DiceLevelScaling(Combattant caster, Die die) {
            int dice = 1;
            if (caster.EffectiveLevel > 16)
                dice = 4;
            else if (caster.EffectiveLevel > 10)
                dice = 3;
            else if (caster.EffectiveLevel > 4)
                dice = 2;
            return new Dice(dice, die);
        }

        /// <summary>
        /// Scales amount of dice based on the slot a spell is cast from
        /// </summary>
        /// <example>
        /// DiceSlotScaling(SpellSlot.FIRST, SpellSlot.SECOND, 8, 3, 5, 2) results in a Dice that refers to "5d8+5",
        /// since it adds 1 slot of 2 dice d8 to the base 3 dice with a modifier of 5
        /// </example>
        internal static Dice DiceSlotScaling(SpellLevel minimumSlot, SpellLevel actualSlot, Die die, int dice = 1, int modifier = 0, int additionalDiePerSlot = 1) {
            if (minimumSlot > actualSlot) throw new Srd5ArgumentException("This spell cannot be cast at slot " + actualSlot);
            int diff = (actualSlot - minimumSlot) * additionalDiePerSlot;
            dice += diff;
            string diceString = dice + die.ToString();
            if (modifier > 0) diceString += "+" + modifier;
            if (modifier < 0) diceString += modifier;
            return new Dice(diceString);
        }

        /// <summary>
        /// Defines the effect on damage in case of a  successful DC roll or other conditions such as failed attack roll
        /// </summary>
        public enum DamageMitigation {
            NO_EFFECT, // do not modify damage
            HALVES_DAMAGE, // divide damage by two
            NULLIFIES_DAMAGE // set damage to zero
        }

        /// <summary>
        /// Does a Spell Attack roll against the target, applies the damage. Returns whether the attack roll succeeded or not.
        /// </summary>
        public static bool SpellAttack(ID id, Battleground ground, Combattant caster, DamageType damageType, Dice dice, int modifier, Combattant target, int range, DamageMitigation missEffect = DamageMitigation.NULLIFIES_DAMAGE, DamageMitigation dCEffect = DamageMitigation.NO_EFFECT, int dc = 0, AbilityType dcAbility = AbilityType.DEXTERITY) {
            return SpellAttack(id, ground, caster, damageType, dice, modifier, target, range, missEffect, dCEffect, dc, out _);
        }

        internal static bool SpellAttack(ID id, Battleground ground, Combattant caster, DamageType damageType, Dice dice, int modifier, Combattant target, int range, DamageMitigation missEffect, DamageMitigation dCEffect, int dc, out bool dcResult) {
            int bonus = modifier + caster.ProficiencyBonus;
            Attack attack = new Attack(id.Name(), bonus, new Damage(damageType, dice), 0, range, range);
            int distance = ground.Distance(caster, target);
            bool hit = caster.Attack(attack, target, distance, true, true, dCEffect, dc, AbilityType.NONE, out dcResult);
            if (missEffect == DamageMitigation.NULLIFIES_DAMAGE) {
                GlobalEvents.AffectBySpell(caster, id, target, hit);
            } else if (missEffect == DamageMitigation.HALVES_DAMAGE) {
                GlobalEvents.AffectBySpell(caster, id, target, true);
                target.TakeDamage(id, damageType, dice.Roll() / 2);
            }
            return hit;
        }

        internal static void AddEffectForDuration(ID id, Combattant caster, Combattant target, Effect effect, SpellDuration duration) {
            GlobalEvents.AffectBySpell(caster, id, target, true);
            target.AddEffect(effect);
            int remainingRounds = (int)duration / 6;
            target.AddEndOfTurnEvent(delegate () {
                if (--remainingRounds < 1) {
                    target.RemoveEffect(effect);
                    return true;
                } else {
                    return false;
                }
            });
        }

        internal static void AddEffectAndConditionForDuration(ID id, Combattant caster, Combattant target, Effect effect, ConditionType condition, SpellDuration duration) {
            GlobalEvents.AffectBySpell(caster, id, target, true);
            target.AddEffect(effect);
            target.AddCondition(condition);
            int remainingRounds = (int)duration / 6;
            target.AddEndOfTurnEvent(delegate () {
                if (--remainingRounds < 1) {
                    target.RemoveEffect(effect);
                    target.RemoveCondition(condition);
                    return true;
                } else {
                    return false;
                }
            });
        }
    }
}
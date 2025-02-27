using System;
using static srd5.Die;
using static srd5.SpellVariant;
using static srd5.SpellSchool;
using static srd5.SpellLevel;
using static srd5.SpellDuration;
using static srd5.DamageType;
using static srd5.Spells.DamageMitigation;
using static srd5.Effect;
using static srd5.AbilityType;

namespace srd5 {
    public partial struct Spells {
        /* TODO */
        public static Spell AnimateDead {
            get {
                return new Spell(ID.ANIMATE_DEAD, NECROMANCY, THIRD, CastingTime.ONE_MINUTE, 10, VSM, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell BeaconOfHope {
            get {
                return new Spell(ID.BEACON_OF_HOPE, ABJURATION, THIRD, CastingTime.ONE_ACTION, 30, VS, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell BestowCurse {
            get {
                return new Spell(ID.BESTOW_CURSE, NECROMANCY, THIRD, CastingTime.ONE_ACTION, 0, VS, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Blink {
            get {
                return new Spell(ID.BLINK, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 0, VS, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell CallLightning {
            get {
                return new Spell(ID.CALL_LIGHTNING, CONJURATION, THIRD, CastingTime.ONE_ACTION, 120, VS, TEN_MINUTES, 5, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Clairvoyance {
            get {
                return new Spell(ID.CLAIRVOYANCE, DIVINATION, THIRD, CastingTime.TEN_MINUTES, 5280, VSM, TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ConjureAnimals {
            get {
                return new Spell(ID.CONJURE_ANIMALS, CONJURATION, THIRD, CastingTime.ONE_ACTION, 60, VS, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Counterspell {
            get {
                return new Spell(ID.COUNTERSPELL, ABJURATION, THIRD, CastingTime.REACTION, 60, S, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell CreateFoodandWater {
            get {
                return new Spell(ID.CREATE_FOOD_AND_WATER, CONJURATION, THIRD, CastingTime.ONE_ACTION, 30, VS, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Daylight {
            get {
                return new Spell(ID.DAYLIGHT, EVOCATION, THIRD, CastingTime.ONE_ACTION, 60, VS, ONE_HOUR, 60, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell DispelMagic {
            get {
                return new Spell(ID.DISPEL_MAGIC, ABJURATION, THIRD, CastingTime.ONE_ACTION, 120, VS, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Fear {
            get {
                return new Spell(ID.FEAR, ILLUSION, THIRD, CastingTime.ONE_ACTION, 0, VSM, ONE_MINUTE, 30, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Fireball {
            get {
                return new Spell(ID.FIREBALL, EVOCATION, THIRD, CastingTime.ONE_ACTION, 150, VSM, INSTANTANEOUS, 20, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Fly {
            get {
                return new Spell(ID.FLY, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 0, VSM, TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell GaseousForm {
            get {
                return new Spell(ID.GASEOUS_FORM, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell GlyphofWarding {
            get {
                return new Spell(ID.GLYPH_OF_WARDING, ABJURATION, THIRD, CastingTime.ONE_HOUR, 0, VSM, UNTIL_DISPELLED, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Haste {
            get {
                return new Spell(ID.HASTE, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 30, VSM, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell HypnoticPattern {
            get {
                return new Spell(ID.HYPNOTIC_PATTERN, ILLUSION, THIRD, CastingTime.ONE_ACTION, 120, SM, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell LightningBolt {
            get {
                return new Spell(ID.LIGHTNING_BOLT, EVOCATION, THIRD, CastingTime.ONE_ACTION, 0, VSM, INSTANTANEOUS, 100, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MagicCircle {
            get {
                return new Spell(ID.MAGIC_CIRCLE, ABJURATION, THIRD, CastingTime.ONE_MINUTE, 10, VSM, ONE_HOUR, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MajorImage {
            get {
                return new Spell(ID.MAJOR_IMAGE, ILLUSION, THIRD, CastingTime.ONE_ACTION, 120, VSM, TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MassHealingWord {
            get {
                return new Spell(ID.MASS_HEALING_WORD, EVOCATION, THIRD, CastingTime.BONUS_ACTION, 60, V, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MeldIntoStone {
            get {
                return new Spell(ID.MELD_INTO_STONE, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 0, VS, EIGHT_HOURS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Nondetection {
            get {
                return new Spell(ID.NONDETECTION, ABJURATION, THIRD, CastingTime.ONE_ACTION, 0, VSM, EIGHT_HOURS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PhantomSteed {
            get {
                return new Spell(ID.PHANTOM_STEED, ILLUSION, THIRD, CastingTime.ONE_MINUTE, 30, VS, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PlantGrowth {
            get {
                return new Spell(ID.PLANT_GROWTH, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 150, VS, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ProtectionFromEnergy {
            get {
                return new Spell(ID.PROTECTION_FROM_ENERGY, ABJURATION, THIRD, CastingTime.ONE_ACTION, 0, VS, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell RemoveCurse {
            get {
                return new Spell(ID.REMOVE_CURSE, ABJURATION, THIRD, CastingTime.ONE_ACTION, 0, VS, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Revivify {
            get {
                return new Spell(ID.REVIVIFY, CONJURATION, THIRD, CastingTime.ONE_ACTION, 0, VSM, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Sending {
            get {
                return new Spell(ID.SENDING, EVOCATION, THIRD, CastingTime.ONE_ACTION, -1, VSM, ONE_ROUND, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell SleetStorm {
            get {
                return new Spell(ID.SLEET_STORM, CONJURATION, THIRD, CastingTime.ONE_ACTION, 150, VSM, ONE_MINUTE, 40, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Slow {
            get {
                return new Spell(ID.SLOW, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 120, VSM, ONE_MINUTE, 40, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell SpeakwithDead {
            get {
                return new Spell(ID.SPEAK_WITH_DEAD, NECROMANCY, THIRD, CastingTime.ONE_ACTION, 10, VSM, TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell SpeakwithPlants {
            get {
                return new Spell(ID.SPEAK_WITH_PLANTS, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 0, VS, TEN_MINUTES, 30, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell SpiritGuardians {
            get {
                return new Spell(ID.SPIRIT_GUARDIANS, CONJURATION, THIRD, CastingTime.ONE_ACTION, 0, VSM, TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell StinkingCloud {
            get {
                return new Spell(ID.STINKING_CLOUD, CONJURATION, THIRD, CastingTime.ONE_ACTION, 90, VSM, ONE_MINUTE, 20, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell TinyHut {
            get {
                return new Spell(ID.TINY_HUT, EVOCATION, THIRD, CastingTime.ONE_MINUTE, 0, VSM, EIGHT_HOURS, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Tongues {
            get {
                return new Spell(ID.TONGUES, DIVINATION, THIRD, CastingTime.ONE_ACTION, 0, VM, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell VampiricTouch {
            get {
                return new Spell(ID.VAMPIRIC_TOUCH, NECROMANCY, THIRD, CastingTime.ONE_ACTION, 0, VS, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell WaterBreathing {
            get {
                return new Spell(ID.WATER_BREATHING, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 30, VSM, ONE_DAY, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell WaterWalk {
            get {
                return new Spell(ID.WATER_WALK, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 30, VSM, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell WindWall {
            get {
                return new Spell(ID.WIND_WALL, EVOCATION, THIRD, CastingTime.ONE_ACTION, 120, VSM, ONE_MINUTE, 50, 0, doNothing);
            }
        }
    }
}
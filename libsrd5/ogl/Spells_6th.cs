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
        public static Spell BladeBarrier {
            get {
                return new Spell(ID.BLADE_BARRIER, EVOCATION, SIXTH, CastingTime.ONE_ACTION, 90, VS, TEN_MINUTES, 100, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ChainLightning {
            get {
                return new Spell(ID.CHAIN_LIGHTNING, EVOCATION, SIXTH, CastingTime.ONE_ACTION, 150, VSM, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell CircleOfDeath {
            get {
                return new Spell(ID.CIRCLE_OF_DEATH, NECROMANCY, SIXTH, CastingTime.ONE_ACTION, 150, VSM, INSTANTANEOUS, 60, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ConjureFey {
            get {
                return new Spell(ID.CONJURE_FEY, CONJURATION, SIXTH, CastingTime.ONE_MINUTE, 90, VS, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Contingency {
            get {
                return new Spell(ID.CONTINGENCY, EVOCATION, SIXTH, CastingTime.TEN_MINUTES, 0, VSM, TEN_DAYS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell CreateUndead {
            get {
                return new Spell(ID.CREATE_UNDEAD, NECROMANCY, SIXTH, CastingTime.ONE_MINUTE, 10, VSM, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Disintegrate {
            get {
                return new Spell(ID.DISINTEGRATE, TRANSMUTATION, SIXTH, CastingTime.ONE_ACTION, 60, VSM, INSTANTANEOUS, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Eyebite {
            get {
                return new Spell(ID.EYEBITE, NECROMANCY, SIXTH, CastingTime.ONE_ACTION, 0, VS, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell FindthePath {
            get {
                return new Spell(ID.FIND_THE_PATH, DIVINATION, SIXTH, CastingTime.ONE_MINUTE, 0, VSM, ONE_DAY, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell FleshtoStone {
            get {
                return new Spell(ID.FLESH_TO_STONE, TRANSMUTATION, SIXTH, CastingTime.ONE_ACTION, 60, VSM, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Forbiddance {
            get {
                return new Spell(ID.FORBIDDANCE, ABJURATION, SIXTH, CastingTime.TEN_MINUTES, 0, VSM, ONE_DAY, 40000, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell FreezingSphere {
            get {
                return new Spell(ID.FREEZING_SPHERE, EVOCATION, SIXTH, CastingTime.ONE_ACTION, 300, VSM, INSTANTANEOUS, 60, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell GlobeOfInvulnerability {
            get {
                return new Spell(ID.GLOBE_OF_INVULNERABILITY, ABJURATION, SIXTH, CastingTime.ONE_ACTION, 0, VSM, ONE_MINUTE, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell GuardsandWards {
            get {
                return new Spell(ID.GUARDS_AND_WARDS, ABJURATION, SIXTH, CastingTime.TEN_MINUTES, 0, VSM, ONE_DAY, 2500, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Harm {
            get {
                return new Spell(ID.HARM, NECROMANCY, SIXTH, CastingTime.ONE_ACTION, 60, VS, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Heal {
            get {
                return new Spell(ID.HEAL, EVOCATION, SIXTH, CastingTime.ONE_ACTION, 60, VS, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell HeroesFeast {
            get {
                return new Spell(ID.HEROES_FEAST, CONJURATION, SIXTH, CastingTime.TEN_MINUTES, 30, VSM, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell InstantSummons {
            get {
                return new Spell(ID.INSTANT_SUMMONS, CONJURATION, SIXTH, CastingTime.ONE_MINUTE, 0, VSM, UNTIL_DISPELLED, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell IrresistibleDance {
            get {
                return new Spell(ID.IRRESISTIBLE_DANCE, ENCHANTMENT, SIXTH, CastingTime.ONE_ACTION, 30, V, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MagicJar {
            get {
                return new Spell(ID.MAGIC_JAR, NECROMANCY, SIXTH, CastingTime.ONE_MINUTE, 0, VSM, UNTIL_DISPELLED, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MassSuggestion {
            get {
                return new Spell(ID.MASS_SUGGESTION, ENCHANTMENT, SIXTH, CastingTime.ONE_ACTION, 60, VM, ONE_DAY, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MoveEarth {
            get {
                return new Spell(ID.MOVE_EARTH, TRANSMUTATION, SIXTH, CastingTime.ONE_ACTION, 120, VSM, TWO_HOURS, 40, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PlanarAlly {
            get {
                return new Spell(ID.PLANAR_ALLY, CONJURATION, SIXTH, CastingTime.TEN_MINUTES, 60, VS, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ProgrammedIllusion {
            get {
                return new Spell(ID.PROGRAMMED_ILLUSION, ILLUSION, SIXTH, CastingTime.ONE_ACTION, 120, VSM, UNTIL_DISPELLED, 30, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Sunbeam {
            get {
                return new Spell(ID.SUNBEAM, EVOCATION, SIXTH, CastingTime.ONE_ACTION, 0, VSM, ONE_MINUTE, 60, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell TransportviaPlants {
            get {
                return new Spell(ID.TRANSPORT_VIA_PLANTS, CONJURATION, SIXTH, CastingTime.ONE_ACTION, 10, VS, ONE_ROUND, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell TrueSeeing {
            get {
                return new Spell(ID.TRUE_SEEING, DIVINATION, SIXTH, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell WallOfIce {
            get {
                return new Spell(ID.WALL_OF_ICE, EVOCATION, SIXTH, CastingTime.ONE_ACTION, 120, VSM, TEN_MINUTES, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell WallOfThorns {
            get {
                return new Spell(ID.WALL_OF_THORNS, CONJURATION, SIXTH, CastingTime.ONE_ACTION, 120, VSM, TEN_MINUTES, 60, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell WindWalk {
            get {
                return new Spell(ID.WIND_WALK, TRANSMUTATION, SIXTH, CastingTime.ONE_MINUTE, 30, VSM, EIGHT_HOURS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell WordOfRecall {
            get {
                return new Spell(ID.WORD_OF_RECALL, CONJURATION, SIXTH, CastingTime.ONE_ACTION, 5, V, INSTANTANEOUS, 5, 0, doNothing);
            }
        }
    }
}
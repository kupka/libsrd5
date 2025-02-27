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
        public static Spell ArcaneEye {
            get {
                return new Spell(ID.ARCANE_EYE, DIVINATION, FOURTH, CastingTime.ONE_ACTION, 30, VSM, ONE_HOUR, 30, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Banishment {
            get {
                return new Spell(ID.BANISHMENT, ABJURATION, FOURTH, CastingTime.ONE_ACTION, 60, VSM, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell BlackTentacles {
            get {
                return new Spell(ID.BLACK_TENTACLES, CONJURATION, FOURTH, CastingTime.ONE_ACTION, 90, VSM, ONE_MINUTE, 20, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Blight {
            get {
                return new Spell(ID.BLIGHT, NECROMANCY, FOURTH, CastingTime.ONE_ACTION, 30, VS, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Compulsion {
            get {
                return new Spell(ID.COMPULSION, ENCHANTMENT, FOURTH, CastingTime.ONE_ACTION, 30, VS, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Confusion {
            get {
                return new Spell(ID.CONFUSION, ENCHANTMENT, FOURTH, CastingTime.ONE_ACTION, 90, VSM, ONE_MINUTE, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ConjureMinorElementals {
            get {
                return new Spell(ID.CONJURE_MINOR_ELEMENTALS, CONJURATION, FOURTH, CastingTime.ONE_MINUTE, 90, VS, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ConjureWoodlandBeings {
            get {
                return new Spell(ID.CONJURE_WOODLAND_BEINGS, CONJURATION, FOURTH, CastingTime.ONE_ACTION, 60, VSM, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ControlWater {
            get {
                return new Spell(ID.CONTROL_WATER, TRANSMUTATION, FOURTH, CastingTime.ONE_ACTION, 300, VSM, TEN_MINUTES, 100, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell DeathWard {
            get {
                return new Spell(ID.DEATH_WARD, ABJURATION, FOURTH, CastingTime.ONE_ACTION, 0, VS, EIGHT_HOURS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell DimensionDoor {
            get {
                return new Spell(ID.DIMENSION_DOOR, CONJURATION, FOURTH, CastingTime.ONE_ACTION, 500, V, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Divination {
            get {
                return new Spell(ID.DIVINATION, DIVINATION, FOURTH, CastingTime.ONE_ACTION, 0, VSM, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell DominateBeast {
            get {
                return new Spell(ID.DOMINATE_BEAST, ENCHANTMENT, FOURTH, CastingTime.ONE_ACTION, 60, VS, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Fabricate {
            get {
                return new Spell(ID.FABRICATE, TRANSMUTATION, FOURTH, CastingTime.TEN_MINUTES, 120, VS, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell FaithfulHound {
            get {
                return new Spell(ID.FAITHFUL_HOUND, CONJURATION, FOURTH, CastingTime.ONE_ACTION, 30, VSM, EIGHT_HOURS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell FireShield {
            get {
                return new Spell(ID.FIRE_SHIELD, EVOCATION, FOURTH, CastingTime.ONE_ACTION, 0, VSM, TEN_MINUTES, 5, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell FreedomOfMovement {
            get {
                return new Spell(ID.FREEDOM_OF_MOVEMENT, ABJURATION, FOURTH, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell GiantInsect {
            get {
                return new Spell(ID.GIANT_INSECT, TRANSMUTATION, FOURTH, CastingTime.ONE_ACTION, 30, VS, TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell GreaterInvisibility {
            get {
                return new Spell(ID.GREATER_INVISIBILITY, ILLUSION, FOURTH, CastingTime.ONE_ACTION, 0, VS, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell GuardianOfFaith {
            get {
                return new Spell(ID.GUARDIAN_OF_FAITH, CONJURATION, FOURTH, CastingTime.ONE_ACTION, 30, V, EIGHT_HOURS, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell HallucinatoryTerrain {
            get {
                return new Spell(ID.HALLUCINATORY_TERRAIN, ILLUSION, FOURTH, CastingTime.TEN_MINUTES, 300, VSM, ONE_DAY, 150, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell IceStorm {
            get {
                return new Spell(ID.ICE_STORM, EVOCATION, FOURTH, CastingTime.ONE_ACTION, 300, VSM, INSTANTANEOUS, 20, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell LocateCreature {
            get {
                return new Spell(ID.LOCATE_CREATURE, DIVINATION, FOURTH, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PhantasmalKiller {
            get {
                return new Spell(ID.PHANTASMAL_KILLER, ILLUSION, FOURTH, CastingTime.ONE_ACTION, 120, VS, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Polymorph {
            get {
                return new Spell(ID.POLYMORPH, TRANSMUTATION, FOURTH, CastingTime.ONE_ACTION, 60, VSM, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PrivateSanctum {
            get {
                return new Spell(ID.PRIVATE_SANCTUM, ABJURATION, FOURTH, CastingTime.TEN_MINUTES, 120, VSM, ONE_DAY, 100, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ResilientSphere {
            get {
                return new Spell(ID.RESILIENT_SPHERE, EVOCATION, FOURTH, CastingTime.ONE_ACTION, 30, VSM, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell SecretChest {
            get {
                return new Spell(ID.SECRET_CHEST, CONJURATION, FOURTH, CastingTime.ONE_ACTION, 0, VSM, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell StoneShape {
            get {
                return new Spell(ID.STONE_SHAPE, TRANSMUTATION, FOURTH, CastingTime.ONE_ACTION, 0, VSM, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Stoneskin {
            get {
                return new Spell(ID.STONESKIN, ABJURATION, FOURTH, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell WallOfFire {
            get {
                return new Spell(ID.WALL_OF_FIRE, EVOCATION, FOURTH, CastingTime.ONE_ACTION, 120, VSM, ONE_MINUTE, 60, 0, doNothing);
            }
        }
    }
}
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
        public static Spell AnimateObjects {
            get {
                return new Spell(ID.ANIMATE_OBJECTS, TRANSMUTATION, FIFTH, CastingTime.ONE_ACTION, 120, VS, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell AntilifeShell {
            get {
                return new Spell(ID.ANTILIFE_SHELL, ABJURATION, FIFTH, CastingTime.ONE_ACTION, 0, VS, ONE_HOUR, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ArcaneHand {
            get {
                return new Spell(ID.ARCANE_HAND, EVOCATION, FIFTH, CastingTime.ONE_ACTION, 120, VSM, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Awaken {
            get {
                return new Spell(ID.AWAKEN, TRANSMUTATION, FIFTH, CastingTime.EIGHT_HOURS, 0, VSM, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Cloudkill {
            get {
                return new Spell(ID.CLOUDKILL, CONJURATION, FIFTH, CastingTime.ONE_ACTION, 120, VS, TEN_MINUTES, 20, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Commune {
            get {
                return new Spell(ID.COMMUNE, DIVINATION, FIFTH, CastingTime.ONE_MINUTE, 0, VSM, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell CommuneWithNature {
            get {
                return new Spell(ID.COMMUNE_WITH_NATURE, DIVINATION, FIFTH, CastingTime.ONE_MINUTE, 0, VS, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ConeOfCold {
            get {
                return new Spell(ID.CONE_OF_COLD, EVOCATION, FIFTH, CastingTime.ONE_ACTION, 0, VSM, INSTANTANEOUS, 60, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ConjureElemental {
            get {
                return new Spell(ID.CONJURE_ELEMENTAL, CONJURATION, FIFTH, CastingTime.ONE_MINUTE, 90, VSM, ONE_HOUR, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ContactOtherPlane {
            get {
                return new Spell(ID.CONTACT_OTHER_PLANE, DIVINATION, FIFTH, CastingTime.ONE_MINUTE, 0, V, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Contagion {
            get {
                return new Spell(ID.CONTAGION, NECROMANCY, FIFTH, CastingTime.ONE_ACTION, 0, VS, SEVEN_DAYS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Creation {
            get {
                return new Spell(ID.CREATION, ILLUSION, FIFTH, CastingTime.ONE_MINUTE, 30, VSM, SPECIAL, 5, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell DispelEvilandGood {
            get {
                return new Spell(ID.DISPEL_EVIL_AND_GOOD, ABJURATION, FIFTH, CastingTime.ONE_ACTION, 0, VSM, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell DominatePerson {
            get {
                return new Spell(ID.DOMINATE_PERSON, ENCHANTMENT, FIFTH, CastingTime.ONE_ACTION, 60, VS, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Dream {
            get {
                return new Spell(ID.DREAM, ILLUSION, FIFTH, CastingTime.ONE_MINUTE, -1, VSM, EIGHT_HOURS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell FlameStrike {
            get {
                return new Spell(ID.FLAME_STRIKE, EVOCATION, FIFTH, CastingTime.ONE_ACTION, 60, VSM, INSTANTANEOUS, 40, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Geas {
            get {
                return new Spell(ID.GEAS, ENCHANTMENT, FIFTH, CastingTime.ONE_MINUTE, 60, V, THIRTY_DAYS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell GreaterRestoration {
            get {
                return new Spell(ID.GREATER_RESTORATION, ABJURATION, FIFTH, CastingTime.ONE_ACTION, 0, VSM, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Hallow {
            get {
                return new Spell(ID.HALLOW, EVOCATION, FIFTH, CastingTime.ONE_DAY, 0, VSM, UNTIL_DISPELLED, 60, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell HoldMonster {
            get {
                return new Spell(ID.HOLD_MONSTER, ENCHANTMENT, FIFTH, CastingTime.ONE_ACTION, 90, VSM, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell InsectPlague {
            get {
                return new Spell(ID.INSECT_PLAGUE, CONJURATION, FIFTH, CastingTime.ONE_ACTION, 300, VSM, TEN_MINUTES, 20, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell LegendLore {
            get {
                return new Spell(ID.LEGEND_LORE, DIVINATION, FIFTH, CastingTime.TEN_MINUTES, 0, VSM, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MassCureWounds {
            get {
                return new Spell(ID.MASS_CURE_WOUNDS, CONJURATION, FIFTH, CastingTime.ONE_ACTION, 60, VS, INSTANTANEOUS, 30, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Mislead {
            get {
                return new Spell(ID.MISLEAD, ILLUSION, FIFTH, CastingTime.ONE_ACTION, 0, S, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ModifyMemory {
            get {
                return new Spell(ID.MODIFY_MEMORY, ENCHANTMENT, FIFTH, CastingTime.ONE_ACTION, 30, VS, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Passwall {
            get {
                return new Spell(ID.PASSWALL, TRANSMUTATION, FIFTH, CastingTime.ONE_ACTION, 30, VSM, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PlanarBinding {
            get {
                return new Spell(ID.PLANAR_BINDING, ABJURATION, FIFTH, CastingTime.ONE_HOUR, 60, VSM, ONE_DAY, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell RaiseDead {
            get {
                return new Spell(ID.RAISE_DEAD, NECROMANCY, FIFTH, CastingTime.ONE_HOUR, 0, VSM, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Reincarnate {
            get {
                return new Spell(ID.REINCARNATE, TRANSMUTATION, FIFTH, CastingTime.ONE_HOUR, 0, VSM, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Scrying {
            get {
                return new Spell(ID.SCRYING, DIVINATION, FIFTH, CastingTime.TEN_MINUTES, 0, VSM, TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Seeming {
            get {
                return new Spell(ID.SEEMING, ILLUSION, FIFTH, CastingTime.ONE_ACTION, 30, VS, EIGHT_HOURS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Telekinesis {
            get {
                return new Spell(ID.TELEKINESIS, TRANSMUTATION, FIFTH, CastingTime.ONE_ACTION, 60, VS, TEN_MINUTES, 30, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell TelepathicBond {
            get {
                return new Spell(ID.TELEPATHIC_BOND, DIVINATION, FIFTH, CastingTime.ONE_ACTION, 30, VSM, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell TeleportationCircle {
            get {
                return new Spell(ID.TELEPORTATION_CIRCLE, CONJURATION, FIFTH, CastingTime.ONE_MINUTE, 10, VM, ONE_ROUND, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell TreeStride {
            get {
                return new Spell(ID.TREE_STRIDE, CONJURATION, FIFTH, CastingTime.ONE_ACTION, 0, VS, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell WallOfForce {
            get {
                return new Spell(ID.WALL_OF_FORCE, EVOCATION, FIFTH, CastingTime.ONE_ACTION, 120, VSM, TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell WallOfStone {
            get {
                return new Spell(ID.WALL_OF_STONE, EVOCATION, FIFTH, CastingTime.ONE_ACTION, 120, VSM, TEN_MINUTES, 0, 0, doNothing);
            }
        }
    }
}
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
        public static Spell AstralProjection {
            get {
                return new Spell(ID.ASTRAL_PROJECTION, NECROMANCY, NINETH, CastingTime.ONE_HOUR, 10, VSM, SPECIAL, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Foresight {
            get {
                return new Spell(ID.FORESIGHT, DIVINATION, NINETH, CastingTime.ONE_MINUTE, 0, VSM, EIGHT_HOURS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Gate {
            get {
                return new Spell(ID.GATE, CONJURATION, NINETH, CastingTime.ONE_ACTION, 60, VSM, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Imprisonment {
            get {
                return new Spell(ID.IMPRISONMENT, ABJURATION, NINETH, CastingTime.ONE_MINUTE, 30, VSM, UNTIL_DISPELLED, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MassHeal {
            get {
                return new Spell(ID.MASS_HEAL, CONJURATION, NINETH, CastingTime.ONE_ACTION, 60, VS, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MeteorSwarm {
            get {
                return new Spell(ID.METEOR_SWARM, EVOCATION, NINETH, CastingTime.ONE_ACTION, 5280, VS, INSTANTANEOUS, 40, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PowerWordKill {
            get {
                return new Spell(ID.POWER_WORD_KILL, ENCHANTMENT, NINETH, CastingTime.ONE_ACTION, 60, V, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PrismaticWall {
            get {
                return new Spell(ID.PRISMATIC_WALL, ABJURATION, NINETH, CastingTime.ONE_ACTION, 60, VS, TEN_MINUTES, 90, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Shapechange {
            get {
                return new Spell(ID.SHAPECHANGE, TRANSMUTATION, NINETH, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell StormOfVengeance {
            get {
                return new Spell(ID.STORM_OF_VENGEANCE, CONJURATION, NINETH, CastingTime.ONE_ACTION, 1000, VS, ONE_MINUTE, 360, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell TimeStop {
            get {
                return new Spell(ID.TIME_STOP, TRANSMUTATION, NINETH, CastingTime.ONE_ACTION, 0, V, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell TruePolymorph {
            get {
                return new Spell(ID.TRUE_POLYMORPH, TRANSMUTATION, NINETH, CastingTime.ONE_ACTION, 30, VSM, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell TrueResurrection {
            get {
                return new Spell(ID.TRUE_RESURRECTION, NECROMANCY, NINETH, CastingTime.ONE_HOUR, 0, VSM, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Weird {
            get {
                return new Spell(ID.WEIRD, ILLUSION, NINETH, CastingTime.ONE_ACTION, 120, VS, ONE_MINUTE, 30, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Wish {
            get {
                return new Spell(ID.WISH, CONJURATION, NINETH, CastingTime.ONE_ACTION, 0, V, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
    }
}
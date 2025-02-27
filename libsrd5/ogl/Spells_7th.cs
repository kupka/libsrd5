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
        public static Spell ArcaneSword {
            get {
                return new Spell(ID.ARCANE_SWORD, EVOCATION, SEVENTH, CastingTime.ONE_ACTION, 60, VSM, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ConjureCelestial {
            get {
                return new Spell(ID.CONJURE_CELESTIAL, CONJURATION, SEVENTH, CastingTime.ONE_MINUTE, 90, VS, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell DelayedBlastFireball {
            get {
                return new Spell(ID.DELAYED_BLAST_FIREBALL, EVOCATION, SEVENTH, CastingTime.ONE_ACTION, 150, VSM, ONE_MINUTE, 20, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell DivineWord {
            get {
                return new Spell(ID.DIVINE_WORD, EVOCATION, SEVENTH, CastingTime.BONUS_ACTION, 30, V, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Etherealness {
            get {
                return new Spell(ID.ETHEREALNESS, TRANSMUTATION, SEVENTH, CastingTime.ONE_ACTION, 0, VS, EIGHT_HOURS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell FingerOfDeath {
            get {
                return new Spell(ID.FINGER_OF_DEATH, NECROMANCY, SEVENTH, CastingTime.ONE_ACTION, 60, VS, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell FireStorm {
            get {
                return new Spell(ID.FIRE_STORM, EVOCATION, SEVENTH, CastingTime.ONE_ACTION, 150, VS, INSTANTANEOUS, 100, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Forcecage {
            get {
                return new Spell(ID.FORCECAGE, EVOCATION, SEVENTH, CastingTime.ONE_ACTION, 100, VSM, ONE_HOUR, 20, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MagnificentMansion {
            get {
                return new Spell(ID.MAGNIFICENT_MANSION, CONJURATION, SEVENTH, CastingTime.ONE_MINUTE, 300, VSM, ONE_DAY, 5, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MirageArcane {
            get {
                return new Spell(ID.MIRAGE_ARCANE, ILLUSION, SEVENTH, CastingTime.TEN_MINUTES, 1000, VS, TEN_DAYS, 5280, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PlaneShift {
            get {
                return new Spell(ID.PLANE_SHIFT, CONJURATION, SEVENTH, CastingTime.ONE_ACTION, 0, VSM, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PrismaticSpray {
            get {
                return new Spell(ID.PRISMATIC_SPRAY, EVOCATION, SEVENTH, CastingTime.ONE_ACTION, 0, VS, INSTANTANEOUS, 60, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ProjectImage {
            get {
                return new Spell(ID.PROJECT_IMAGE, ILLUSION, SEVENTH, CastingTime.ONE_ACTION, 5280 * 500, VSM, ONE_DAY, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Regenerate {
            get {
                return new Spell(ID.REGENERATE, TRANSMUTATION, SEVENTH, CastingTime.ONE_MINUTE, 0, VSM, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Resurrection {
            get {
                return new Spell(ID.RESURRECTION, NECROMANCY, SEVENTH, CastingTime.ONE_HOUR, 0, VSM, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ReverseGravity {
            get {
                return new Spell(ID.REVERSE_GRAVITY, TRANSMUTATION, SEVENTH, CastingTime.ONE_ACTION, 100, VSM, ONE_MINUTE, 50, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Sequester {
            get {
                return new Spell(ID.SEQUESTER, TRANSMUTATION, SEVENTH, CastingTime.ONE_ACTION, 0, VSM, UNTIL_DISPELLED, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Simulacrum {
            get {
                return new Spell(ID.SIMULACRUM, ILLUSION, SEVENTH, CastingTime.TWELVE_HOURS, 0, VSM, UNTIL_DISPELLED, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Symbol {
            get {
                return new Spell(ID.SYMBOL, ABJURATION, SEVENTH, CastingTime.ONE_MINUTE, 0, VSM, UNTIL_DISPELLED, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Teleport {
            get {
                return new Spell(ID.TELEPORT, CONJURATION, SEVENTH, CastingTime.ONE_ACTION, 10, V, INSTANTANEOUS, 10, 0, doNothing);
            }
        }
    }
}
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
        public static Spell AnimalShapes {
            get {
                return new Spell(ID.ANIMAL_SHAPES, TRANSMUTATION, EIGHTH, CastingTime.ONE_ACTION, 30, VS, ONE_DAY, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell AntimagicField {
            get {
                return new Spell(ID.ANTIMAGIC_FIELD, ABJURATION, EIGHTH, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell AntipathySympathy {
            get {
                return new Spell(ID.ANTIPATHY_SYMPATHY, ENCHANTMENT, EIGHTH, CastingTime.ONE_HOUR, 60, VSM, TEN_DAYS, 200, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Clone {
            get {
                return new Spell(ID.CLONE, NECROMANCY, EIGHTH, CastingTime.ONE_HOUR, 0, VSM, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ControlWeather {
            get {
                return new Spell(ID.CONTROL_WEATHER, TRANSMUTATION, EIGHTH, CastingTime.TEN_MINUTES, 0, VSM, EIGHT_HOURS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Demiplane {
            get {
                return new Spell(ID.DEMIPLANE, CONJURATION, EIGHTH, CastingTime.ONE_ACTION, 60, S, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell DominateMonster {
            get {
                return new Spell(ID.DOMINATE_MONSTER, ENCHANTMENT, EIGHTH, CastingTime.ONE_ACTION, 60, VS, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Earthquake {
            get {
                return new Spell(ID.EARTHQUAKE, EVOCATION, EIGHTH, CastingTime.ONE_ACTION, 500, VSM, ONE_MINUTE, 100, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Feeblemind {
            get {
                return new Spell(ID.FEEBLEMIND, ENCHANTMENT, EIGHTH, CastingTime.ONE_ACTION, 150, VSM, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Glibness {
            get {
                return new Spell(ID.GLIBNESS, TRANSMUTATION, EIGHTH, CastingTime.ONE_ACTION, 0, V, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell HolyAura {
            get {
                return new Spell(ID.HOLY_AURA, ABJURATION, EIGHTH, CastingTime.ONE_ACTION, 0, VSM, ONE_MINUTE, 30, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell IncendiaryCloud {
            get {
                return new Spell(ID.INCENDIARY_CLOUD, CONJURATION, EIGHTH, CastingTime.ONE_ACTION, 150, VS, ONE_MINUTE, 20, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Maze {
            get {
                return new Spell(ID.MAZE, CONJURATION, EIGHTH, CastingTime.ONE_ACTION, 60, VS, TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MindBlank {
            get {
                return new Spell(ID.MIND_BLANK, ABJURATION, EIGHTH, CastingTime.ONE_ACTION, 0, VS, ONE_DAY, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PowerWordStun {
            get {
                return new Spell(ID.POWER_WORD_STUN, ENCHANTMENT, EIGHTH, CastingTime.ONE_ACTION, 60, V, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Sunburst {
            get {
                return new Spell(ID.SUNBURST, EVOCATION, EIGHTH, CastingTime.ONE_ACTION, 150, VSM, INSTANTANEOUS, 60, 0, doNothing);
            }
        }
    }
}
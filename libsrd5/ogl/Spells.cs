using System;

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
        ONE_ACTION,
        ONE_ROUND,
        ONE_MINUTE,
        ONE_HOUR
    }

    public enum SpellComponent {
        VERBAL,
        SOMATIC,
        MATERIAL
    }

    public enum SpellDuration {
        INSTANTANEOUS = 0,
        CONCENTRATION_ONE_MINUTE = 1,
        CONCENTRATION_TEN_MINUTES = 10,
        CONCENTRATION_ONE_HOUR = 60,
        CONCENTRATION_ONE_DAY = 1440
    }

    public delegate void SpellCastEffect(Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, params Combattant[] targets);

    public partial struct Spells {
        private static SpellCastEffect doNothing = delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) { };

        private static SpellComponent[] V {
            get {
                return new SpellComponent[] { SpellComponent.VERBAL };
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
            ACID_SPLASH,
            CHARM_PERSON,
            CREATE_OR_DESTROY_WATER,
            CURE_WOUNDS,
            DETECT_MAGIC,
            DETECT_POISON_AND_DISEASE,
            ENTANGLE,
            FAIRIE_FIRE,
            FOG_CLOUD,
            GUIDANCE,
            HEALING_WORD,
            HOLD_PERSON,
            JUMP,
            LONGSTRIDER,
            MAGIC_MISSILE,
            MENDING,
            PRODUCE_FLAME,
            PURIFY_FOOD_AND_DRINK,
            RESISTANCE,
            SHILLELAGH,
            SPEAK_WITH_ANIMALS,
            THUNDERWAVE
        }
    }
}
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
        ONE_ROUND = 6,
        ONE_MINUTE = 60,
        TEN_MINUTES = 600,
        ONE_HOUR = 3600,
        ONE_DAY = 86400
    }

    public delegate void SpellCastEffect(Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, params Combattant[] targets);

    public partial struct Spells {
        private static SpellCastEffect doNothing = delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) { };


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
            ACID_SPLASH,
            CHARM_PERSON,
            CHILL_TOUCH,
            CREATE_OR_DESTROY_WATER,
            CURE_WOUNDS,
            DANCING_LIGHTS,
            DETECT_MAGIC,
            DETECT_POISON_AND_DISEASE,
            ENTANGLE,
            FAIRIE_FIRE,
            FIRE_BOLT,
            FOG_CLOUD,
            GUIDANCE,
            HEALING_WORD,
            HOLD_PERSON,
            JUMP,
            LIGHT,
            LONGSTRIDER,
            MAGE_HAND,
            MAGIC_MISSILE,
            MENDING,
            MESSAGE,
            MINOR_ILLUSION,
            PRESTIDIGITATION,
            PRODUCE_FLAME,
            PURIFY_FOOD_AND_DRINK,
            RAY_OF_FROST,
            RESISTANCE,
            SHILLELAGH,
            SHOCKING_GRASP,
            SPEAK_WITH_ANIMALS,
            THUNDERWAVE
        }
    }
}
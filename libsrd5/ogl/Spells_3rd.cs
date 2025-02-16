namespace srd5 {
    public partial struct Spells {
        /* TODO */
        public static Spell AnimateDead {
            get {
                return new Spell(Spells.ID.ANIMATE_DEAD, SpellSchool.NECROMANCY, SpellLevel.THIRD, CastingTime.ONE_MINUTE, 10, VSM, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell BeaconOfHope {
            get {
                return new Spell(Spells.ID.BEACON_OF_HOPE, SpellSchool.ABJURATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 30, VS, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell BestowCurse {
            get {
                return new Spell(Spells.ID.BESTOW_CURSE, SpellSchool.NECROMANCY, SpellLevel.THIRD, CastingTime.ONE_ACTION, 0, VS, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Blink {
            get {
                return new Spell(Spells.ID.BLINK, SpellSchool.TRANSMUTATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 0, VS, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell CallLightning {
            get {
                return new Spell(Spells.ID.CALL_LIGHTNING, SpellSchool.CONJURATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 120, VS, SpellDuration.TEN_MINUTES, 5, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Clairvoyance {
            get {
                return new Spell(Spells.ID.CLAIRVOYANCE, SpellSchool.DIVINATION, SpellLevel.THIRD, CastingTime.TEN_MINUTES, 5280, VSM, SpellDuration.TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ConjureAnimals {
            get {
                return new Spell(Spells.ID.CONJURE_ANIMALS, SpellSchool.CONJURATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 60, VS, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Counterspell {
            get {
                return new Spell(Spells.ID.COUNTERSPELL, SpellSchool.ABJURATION, SpellLevel.THIRD, CastingTime.REACTION, 60, S, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell CreateFoodandWater {
            get {
                return new Spell(Spells.ID.CREATE_FOOD_AND_WATER, SpellSchool.CONJURATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 30, VS, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Daylight {
            get {
                return new Spell(Spells.ID.DAYLIGHT, SpellSchool.EVOCATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 60, VS, SpellDuration.ONE_HOUR, 60, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell DispelMagic {
            get {
                return new Spell(Spells.ID.DISPEL_MAGIC, SpellSchool.ABJURATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 120, VS, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Fear {
            get {
                return new Spell(Spells.ID.FEAR, SpellSchool.ILLUSION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_MINUTE, 30, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Fireball {
            get {
                return new Spell(Spells.ID.FIREBALL, SpellSchool.EVOCATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 150, VSM, SpellDuration.INSTANTANEOUS, 20, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Fly {
            get {
                return new Spell(Spells.ID.FLY, SpellSchool.TRANSMUTATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell GaseousForm {
            get {
                return new Spell(Spells.ID.GASEOUS_FORM, SpellSchool.TRANSMUTATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell GlyphofWarding {
            get {
                return new Spell(Spells.ID.GLYPH_OF_WARDING, SpellSchool.ABJURATION, SpellLevel.THIRD, CastingTime.ONE_HOUR, 0, VSM, SpellDuration.UNTIL_DISPELLED, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Haste {
            get {
                return new Spell(Spells.ID.HASTE, SpellSchool.TRANSMUTATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 30, VSM, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell HypnoticPattern {
            get {
                return new Spell(Spells.ID.HYPNOTIC_PATTERN, SpellSchool.ILLUSION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 120, SM, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell LightningBolt {
            get {
                return new Spell(Spells.ID.LIGHTNING_BOLT, SpellSchool.EVOCATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.INSTANTANEOUS, 100, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MagicCircle {
            get {
                return new Spell(Spells.ID.MAGIC_CIRCLE, SpellSchool.ABJURATION, SpellLevel.THIRD, CastingTime.ONE_MINUTE, 10, VSM, SpellDuration.ONE_HOUR, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MajorImage {
            get {
                return new Spell(Spells.ID.MAJOR_IMAGE, SpellSchool.ILLUSION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 120, VSM, SpellDuration.TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MassHealingWord {
            get {
                return new Spell(Spells.ID.MASS_HEALING_WORD, SpellSchool.EVOCATION, SpellLevel.THIRD, CastingTime.BONUS_ACTION, 60, V, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MeldIntoStone {
            get {
                return new Spell(Spells.ID.MELD_INTO_STONE, SpellSchool.TRANSMUTATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 0, VS, SpellDuration.EIGHT_HOURS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Nondetection {
            get {
                return new Spell(Spells.ID.NONDETECTION, SpellSchool.ABJURATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.EIGHT_HOURS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PhantomSteed {
            get {
                return new Spell(Spells.ID.PHANTOM_STEED, SpellSchool.ILLUSION, SpellLevel.THIRD, CastingTime.ONE_MINUTE, 30, VS, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PlantGrowth {
            get {
                return new Spell(Spells.ID.PLANT_GROWTH, SpellSchool.TRANSMUTATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 150, VS, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ProtectionFromEnergy {
            get {
                return new Spell(Spells.ID.PROTECTION_FROM_ENERGY, SpellSchool.ABJURATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 0, VS, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell RemoveCurse {
            get {
                return new Spell(Spells.ID.REMOVE_CURSE, SpellSchool.ABJURATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 0, VS, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Revivify {
            get {
                return new Spell(Spells.ID.REVIVIFY, SpellSchool.CONJURATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Sending {
            get {
                return new Spell(Spells.ID.SENDING, SpellSchool.EVOCATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, -1, VSM, SpellDuration.ONE_ROUND, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell SleetStorm {
            get {
                return new Spell(Spells.ID.SLEET_STORM, SpellSchool.CONJURATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 150, VSM, SpellDuration.ONE_MINUTE, 40, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Slow {
            get {
                return new Spell(Spells.ID.SLOW, SpellSchool.TRANSMUTATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 120, VSM, SpellDuration.ONE_MINUTE, 40, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell SpeakwithDead {
            get {
                return new Spell(Spells.ID.SPEAK_WITH_DEAD, SpellSchool.NECROMANCY, SpellLevel.THIRD, CastingTime.ONE_ACTION, 10, VSM, SpellDuration.TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell SpeakwithPlants {
            get {
                return new Spell(Spells.ID.SPEAK_WITH_PLANTS, SpellSchool.TRANSMUTATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 0, VS, SpellDuration.TEN_MINUTES, 30, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell SpiritGuardians {
            get {
                return new Spell(Spells.ID.SPIRIT_GUARDIANS, SpellSchool.CONJURATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell StinkingCloud {
            get {
                return new Spell(Spells.ID.STINKING_CLOUD, SpellSchool.CONJURATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 90, VSM, SpellDuration.ONE_MINUTE, 20, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell TinyHut {
            get {
                return new Spell(Spells.ID.TINY_HUT, SpellSchool.EVOCATION, SpellLevel.THIRD, CastingTime.ONE_MINUTE, 0, VSM, SpellDuration.EIGHT_HOURS, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Tongues {
            get {
                return new Spell(Spells.ID.TONGUES, SpellSchool.DIVINATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 0, VM, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell VampiricTouch {
            get {
                return new Spell(Spells.ID.VAMPIRIC_TOUCH, SpellSchool.NECROMANCY, SpellLevel.THIRD, CastingTime.ONE_ACTION, 0, VS, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell WaterBreathing {
            get {
                return new Spell(Spells.ID.WATER_BREATHING, SpellSchool.TRANSMUTATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 30, VSM, SpellDuration.ONE_DAY, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell WaterWalk {
            get {
                return new Spell(Spells.ID.WATER_WALK, SpellSchool.TRANSMUTATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 30, VSM, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell WindWall {
            get {
                return new Spell(Spells.ID.WIND_WALL, SpellSchool.EVOCATION, SpellLevel.THIRD, CastingTime.ONE_ACTION, 120, VSM, SpellDuration.ONE_MINUTE, 50, 0, doNothing);
            }
        }
    }
}
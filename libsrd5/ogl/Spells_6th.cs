namespace srd5 {
    public partial struct Spells {
        /* TODO */
        public static Spell BladeBarrier {
            get {
                return new Spell(Spells.ID.BLADE_BARRIER, SpellSchool.EVOCATION, SpellLevel.SIXTH, CastingTime.ONE_ACTION, 90, VS, SpellDuration.TEN_MINUTES, 100, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ChainLightning {
            get {
                return new Spell(Spells.ID.CHAIN_LIGHTNING, SpellSchool.EVOCATION, SpellLevel.SIXTH, CastingTime.ONE_ACTION, 150, VSM, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell CircleOfDeath {
            get {
                return new Spell(Spells.ID.CIRCLE_OF_DEATH, SpellSchool.NECROMANCY, SpellLevel.SIXTH, CastingTime.ONE_ACTION, 150, VSM, SpellDuration.INSTANTANEOUS, 60, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ConjureFey {
            get {
                return new Spell(Spells.ID.CONJURE_FEY, SpellSchool.CONJURATION, SpellLevel.SIXTH, CastingTime.ONE_MINUTE, 90, VS, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Contingency {
            get {
                return new Spell(Spells.ID.CONTINGENCY, SpellSchool.EVOCATION, SpellLevel.SIXTH, CastingTime.TEN_MINUTES, 0, VSM, SpellDuration.TEN_DAYS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell CreateUndead {
            get {
                return new Spell(Spells.ID.CREATE_UNDEAD, SpellSchool.NECROMANCY, SpellLevel.SIXTH, CastingTime.ONE_MINUTE, 10, VSM, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Disintegrate {
            get {
                return new Spell(Spells.ID.DISINTEGRATE, SpellSchool.TRANSMUTATION, SpellLevel.SIXTH, CastingTime.ONE_ACTION, 60, VSM, SpellDuration.INSTANTANEOUS, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Eyebite {
            get {
                return new Spell(Spells.ID.EYEBITE, SpellSchool.NECROMANCY, SpellLevel.SIXTH, CastingTime.ONE_ACTION, 0, VS, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell FindthePath {
            get {
                return new Spell(Spells.ID.FIND_THE_PATH, SpellSchool.DIVINATION, SpellLevel.SIXTH, CastingTime.ONE_MINUTE, 0, VSM, SpellDuration.ONE_DAY, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell FleshtoStone {
            get {
                return new Spell(Spells.ID.FLESH_TO_STONE, SpellSchool.TRANSMUTATION, SpellLevel.SIXTH, CastingTime.ONE_ACTION, 60, VSM, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Forbiddance {
            get {
                return new Spell(Spells.ID.FORBIDDANCE, SpellSchool.ABJURATION, SpellLevel.SIXTH, CastingTime.TEN_MINUTES, 0, VSM, SpellDuration.ONE_DAY, 40000, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell FreezingSphere {
            get {
                return new Spell(Spells.ID.FREEZING_SPHERE, SpellSchool.EVOCATION, SpellLevel.SIXTH, CastingTime.ONE_ACTION, 300, VSM, SpellDuration.INSTANTANEOUS, 60, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell GlobeOfInvulnerability {
            get {
                return new Spell(Spells.ID.GLOBE_OF_INVULNERABILITY, SpellSchool.ABJURATION, SpellLevel.SIXTH, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_MINUTE, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell GuardsandWards {
            get {
                return new Spell(Spells.ID.GUARDS_AND_WARDS, SpellSchool.ABJURATION, SpellLevel.SIXTH, CastingTime.TEN_MINUTES, 0, VSM, SpellDuration.ONE_DAY, 2500, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Harm {
            get {
                return new Spell(Spells.ID.HARM, SpellSchool.NECROMANCY, SpellLevel.SIXTH, CastingTime.ONE_ACTION, 60, VS, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Heal {
            get {
                return new Spell(Spells.ID.HEAL, SpellSchool.EVOCATION, SpellLevel.SIXTH, CastingTime.ONE_ACTION, 60, VS, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell HeroesFeast {
            get {
                return new Spell(Spells.ID.HEROES_FEAST, SpellSchool.CONJURATION, SpellLevel.SIXTH, CastingTime.TEN_MINUTES, 30, VSM, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell InstantSummons {
            get {
                return new Spell(Spells.ID.INSTANT_SUMMONS, SpellSchool.CONJURATION, SpellLevel.SIXTH, CastingTime.ONE_MINUTE, 0, VSM, SpellDuration.UNTIL_DISPELLED, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell IrresistibleDance {
            get {
                return new Spell(Spells.ID.IRRESISTIBLE_DANCE, SpellSchool.ENCHANTMENT, SpellLevel.SIXTH, CastingTime.ONE_ACTION, 30, V, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MagicJar {
            get {
                return new Spell(Spells.ID.MAGIC_JAR, SpellSchool.NECROMANCY, SpellLevel.SIXTH, CastingTime.ONE_MINUTE, 0, VSM, SpellDuration.UNTIL_DISPELLED, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MassSuggestion {
            get {
                return new Spell(Spells.ID.MASS_SUGGESTION, SpellSchool.ENCHANTMENT, SpellLevel.SIXTH, CastingTime.ONE_ACTION, 60, VM, SpellDuration.ONE_DAY, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MoveEarth {
            get {
                return new Spell(Spells.ID.MOVE_EARTH, SpellSchool.TRANSMUTATION, SpellLevel.SIXTH, CastingTime.ONE_ACTION, 120, VSM, SpellDuration.TWO_HOURS, 40, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PlanarAlly {
            get {
                return new Spell(Spells.ID.PLANAR_ALLY, SpellSchool.CONJURATION, SpellLevel.SIXTH, CastingTime.TEN_MINUTES, 60, VS, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ProgrammedIllusion {
            get {
                return new Spell(Spells.ID.PROGRAMMED_ILLUSION, SpellSchool.ILLUSION, SpellLevel.SIXTH, CastingTime.ONE_ACTION, 120, VSM, SpellDuration.UNTIL_DISPELLED, 30, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Sunbeam {
            get {
                return new Spell(Spells.ID.SUNBEAM, SpellSchool.EVOCATION, SpellLevel.SIXTH, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_MINUTE, 60, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell TransportviaPlants {
            get {
                return new Spell(Spells.ID.TRANSPORT_VIA_PLANTS, SpellSchool.CONJURATION, SpellLevel.SIXTH, CastingTime.ONE_ACTION, 10, VS, SpellDuration.ONE_ROUND, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell TrueSeeing {
            get {
                return new Spell(Spells.ID.TRUE_SEEING, SpellSchool.DIVINATION, SpellLevel.SIXTH, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell WallOfIce {
            get {
                return new Spell(Spells.ID.WALL_OF_ICE, SpellSchool.EVOCATION, SpellLevel.SIXTH, CastingTime.ONE_ACTION, 120, VSM, SpellDuration.TEN_MINUTES, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell WallOfThorns {
            get {
                return new Spell(Spells.ID.WALL_OF_THORNS, SpellSchool.CONJURATION, SpellLevel.SIXTH, CastingTime.ONE_ACTION, 120, VSM, SpellDuration.TEN_MINUTES, 60, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell WindWalk {
            get {
                return new Spell(Spells.ID.WIND_WALK, SpellSchool.TRANSMUTATION, SpellLevel.SIXTH, CastingTime.ONE_MINUTE, 30, VSM, SpellDuration.EIGHT_HOURS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell WordOfRecall {
            get {
                return new Spell(Spells.ID.WORD_OF_RECALL, SpellSchool.CONJURATION, SpellLevel.SIXTH, CastingTime.ONE_ACTION, 5, V, SpellDuration.INSTANTANEOUS, 5, 0, doNothing);
            }
        }
    }
}
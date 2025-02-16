namespace srd5 {
    public partial struct Spells {
        /* TODO */
        public static Spell AnimalShapes {
            get {
                return new Spell(Spells.ID.ANIMAL_SHAPES, SpellSchool.TRANSMUTATION, SpellLevel.EIGHTH, CastingTime.ONE_ACTION, 30, VS, SpellDuration.ONE_DAY, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell AntimagicField {
            get {
                return new Spell(Spells.ID.ANTIMAGIC_FIELD, SpellSchool.ABJURATION, SpellLevel.EIGHTH, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_HOUR, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell AntipathySympathy {
            get {
                return new Spell(Spells.ID.ANTIPATHY_SYMPATHY, SpellSchool.ENCHANTMENT, SpellLevel.EIGHTH, CastingTime.ONE_HOUR, 60, VSM, SpellDuration.TEN_DAYS, 200, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Clone {
            get {
                return new Spell(Spells.ID.CLONE, SpellSchool.NECROMANCY, SpellLevel.EIGHTH, CastingTime.ONE_HOUR, 0, VSM, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ControlWeather {
            get {
                return new Spell(Spells.ID.CONTROL_WEATHER, SpellSchool.TRANSMUTATION, SpellLevel.EIGHTH, CastingTime.TEN_MINUTES, 0, VSM, SpellDuration.EIGHT_HOURS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Demiplane {
            get {
                return new Spell(Spells.ID.DEMIPLANE, SpellSchool.CONJURATION, SpellLevel.EIGHTH, CastingTime.ONE_ACTION, 60, S, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell DominateMonster {
            get {
                return new Spell(Spells.ID.DOMINATE_MONSTER, SpellSchool.ENCHANTMENT, SpellLevel.EIGHTH, CastingTime.ONE_ACTION, 60, VS, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Earthquake {
            get {
                return new Spell(Spells.ID.EARTHQUAKE, SpellSchool.EVOCATION, SpellLevel.EIGHTH, CastingTime.ONE_ACTION, 500, VSM, SpellDuration.ONE_MINUTE, 100, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Feeblemind {
            get {
                return new Spell(Spells.ID.FEEBLEMIND, SpellSchool.ENCHANTMENT, SpellLevel.EIGHTH, CastingTime.ONE_ACTION, 150, VSM, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Glibness {
            get {
                return new Spell(Spells.ID.GLIBNESS, SpellSchool.TRANSMUTATION, SpellLevel.EIGHTH, CastingTime.ONE_ACTION, 0, V, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell HolyAura {
            get {
                return new Spell(Spells.ID.HOLY_AURA, SpellSchool.ABJURATION, SpellLevel.EIGHTH, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_MINUTE, 30, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell IncendiaryCloud {
            get {
                return new Spell(Spells.ID.INCENDIARY_CLOUD, SpellSchool.CONJURATION, SpellLevel.EIGHTH, CastingTime.ONE_ACTION, 150, VS, SpellDuration.ONE_MINUTE, 20, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Maze {
            get {
                return new Spell(Spells.ID.MAZE, SpellSchool.CONJURATION, SpellLevel.EIGHTH, CastingTime.ONE_ACTION, 60, VS, SpellDuration.TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MindBlank {
            get {
                return new Spell(Spells.ID.MIND_BLANK, SpellSchool.ABJURATION, SpellLevel.EIGHTH, CastingTime.ONE_ACTION, 0, VS, SpellDuration.ONE_DAY, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PowerWordStun {
            get {
                return new Spell(Spells.ID.POWER_WORD_STUN, SpellSchool.ENCHANTMENT, SpellLevel.EIGHTH, CastingTime.ONE_ACTION, 60, V, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Sunburst {
            get {
                return new Spell(Spells.ID.SUNBURST, SpellSchool.EVOCATION, SpellLevel.EIGHTH, CastingTime.ONE_ACTION, 150, VSM, SpellDuration.INSTANTANEOUS, 60, 0, doNothing);
            }
        }
    }
}
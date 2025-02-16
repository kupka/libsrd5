namespace srd5 {
    public partial struct Spells {
        /* TODO */
        public static Spell ArcaneSword {
            get {
                return new Spell(Spells.ID.ARCANE_SWORD, SpellSchool.EVOCATION, SpellLevel.SEVENTH, CastingTime.ONE_ACTION, 60, VSM, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ConjureCelestial {
            get {
                return new Spell(Spells.ID.CONJURE_CELESTIAL, SpellSchool.CONJURATION, SpellLevel.SEVENTH, CastingTime.ONE_MINUTE, 90, VS, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell DelayedBlastFireball {
            get {
                return new Spell(Spells.ID.DELAYED_BLAST_FIREBALL, SpellSchool.EVOCATION, SpellLevel.SEVENTH, CastingTime.ONE_ACTION, 150, VSM, SpellDuration.ONE_MINUTE, 20, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell DivineWord {
            get {
                return new Spell(Spells.ID.DIVINE_WORD, SpellSchool.EVOCATION, SpellLevel.SEVENTH, CastingTime.BONUS_ACTION, 30, V, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Etherealness {
            get {
                return new Spell(Spells.ID.ETHEREALNESS, SpellSchool.TRANSMUTATION, SpellLevel.SEVENTH, CastingTime.ONE_ACTION, 0, VS, SpellDuration.EIGHT_HOURS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell FingerOfDeath {
            get {
                return new Spell(Spells.ID.FINGER_OF_DEATH, SpellSchool.NECROMANCY, SpellLevel.SEVENTH, CastingTime.ONE_ACTION, 60, VS, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell FireStorm {
            get {
                return new Spell(Spells.ID.FIRE_STORM, SpellSchool.EVOCATION, SpellLevel.SEVENTH, CastingTime.ONE_ACTION, 150, VS, SpellDuration.INSTANTANEOUS, 100, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Forcecage {
            get {
                return new Spell(Spells.ID.FORCECAGE, SpellSchool.EVOCATION, SpellLevel.SEVENTH, CastingTime.ONE_ACTION, 100, VSM, SpellDuration.ONE_HOUR, 20, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MagnificentMansion {
            get {
                return new Spell(Spells.ID.MAGNIFICENT_MANSION, SpellSchool.CONJURATION, SpellLevel.SEVENTH, CastingTime.ONE_MINUTE, 300, VSM, SpellDuration.ONE_DAY, 5, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MirageArcane {
            get {
                return new Spell(Spells.ID.MIRAGE_ARCANE, SpellSchool.ILLUSION, SpellLevel.SEVENTH, CastingTime.TEN_MINUTES, 1000, VS, SpellDuration.TEN_DAYS, 5280, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PlaneShift {
            get {
                return new Spell(Spells.ID.PLANE_SHIFT, SpellSchool.CONJURATION, SpellLevel.SEVENTH, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PrismaticSpray {
            get {
                return new Spell(Spells.ID.PRISMATIC_SPRAY, SpellSchool.EVOCATION, SpellLevel.SEVENTH, CastingTime.ONE_ACTION, 0, VS, SpellDuration.INSTANTANEOUS, 60, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ProjectImage {
            get {
                return new Spell(Spells.ID.PROJECT_IMAGE, SpellSchool.ILLUSION, SpellLevel.SEVENTH, CastingTime.ONE_ACTION, 5280 * 500, VSM, SpellDuration.ONE_DAY, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Regenerate {
            get {
                return new Spell(Spells.ID.REGENERATE, SpellSchool.TRANSMUTATION, SpellLevel.SEVENTH, CastingTime.ONE_MINUTE, 0, VSM, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Resurrection {
            get {
                return new Spell(Spells.ID.RESURRECTION, SpellSchool.NECROMANCY, SpellLevel.SEVENTH, CastingTime.ONE_HOUR, 0, VSM, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ReverseGravity {
            get {
                return new Spell(Spells.ID.REVERSE_GRAVITY, SpellSchool.TRANSMUTATION, SpellLevel.SEVENTH, CastingTime.ONE_ACTION, 100, VSM, SpellDuration.ONE_MINUTE, 50, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Sequester {
            get {
                return new Spell(Spells.ID.SEQUESTER, SpellSchool.TRANSMUTATION, SpellLevel.SEVENTH, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.UNTIL_DISPELLED, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Simulacrum {
            get {
                return new Spell(Spells.ID.SIMULACRUM, SpellSchool.ILLUSION, SpellLevel.SEVENTH, CastingTime.TWELVE_HOURS, 0, VSM, SpellDuration.UNTIL_DISPELLED, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Symbol {
            get {
                return new Spell(Spells.ID.SYMBOL, SpellSchool.ABJURATION, SpellLevel.SEVENTH, CastingTime.ONE_MINUTE, 0, VSM, SpellDuration.UNTIL_DISPELLED, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Teleport {
            get {
                return new Spell(Spells.ID.TELEPORT, SpellSchool.CONJURATION, SpellLevel.SEVENTH, CastingTime.ONE_ACTION, 10, V, SpellDuration.INSTANTANEOUS, 10, 0, doNothing);
            }
        }
    }
}
namespace srd5 {
    public partial struct Spells {
        /* TODO */
        public static Spell AstralProjection {
            get {
                return new Spell(Spells.ID.ASTRAL_PROJECTION, SpellSchool.NECROMANCY, SpellLevel.NINETH, CastingTime.ONE_HOUR, 10, VSM, SpellDuration.SPECIAL, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Foresight {
            get {
                return new Spell(Spells.ID.FORESIGHT, SpellSchool.DIVINATION, SpellLevel.NINETH, CastingTime.ONE_MINUTE, 0, VSM, SpellDuration.EIGHT_HOURS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Gate {
            get {
                return new Spell(Spells.ID.GATE, SpellSchool.CONJURATION, SpellLevel.NINETH, CastingTime.ONE_ACTION, 60, VSM, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Imprisonment {
            get {
                return new Spell(Spells.ID.IMPRISONMENT, SpellSchool.ABJURATION, SpellLevel.NINETH, CastingTime.ONE_MINUTE, 30, VSM, SpellDuration.UNTIL_DISPELLED, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MassHeal {
            get {
                return new Spell(Spells.ID.MASS_HEAL, SpellSchool.CONJURATION, SpellLevel.NINETH, CastingTime.ONE_ACTION, 60, VS, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MeteorSwarm {
            get {
                return new Spell(Spells.ID.METEOR_SWARM, SpellSchool.EVOCATION, SpellLevel.NINETH, CastingTime.ONE_ACTION, 5280, VS, SpellDuration.INSTANTANEOUS, 40, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PowerWordKill {
            get {
                return new Spell(Spells.ID.POWER_WORD_KILL, SpellSchool.ENCHANTMENT, SpellLevel.NINETH, CastingTime.ONE_ACTION, 60, V, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PrismaticWall {
            get {
                return new Spell(Spells.ID.PRISMATIC_WALL, SpellSchool.ABJURATION, SpellLevel.NINETH, CastingTime.ONE_ACTION, 60, VS, SpellDuration.TEN_MINUTES, 90, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Shapechange {
            get {
                return new Spell(Spells.ID.SHAPECHANGE, SpellSchool.TRANSMUTATION, SpellLevel.NINETH, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell StormOfVengeance {
            get {
                return new Spell(Spells.ID.STORM_OF_VENGEANCE, SpellSchool.CONJURATION, SpellLevel.NINETH, CastingTime.ONE_ACTION, 1000, VS, SpellDuration.ONE_MINUTE, 360, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell TimeStop {
            get {
                return new Spell(Spells.ID.TIME_STOP, SpellSchool.TRANSMUTATION, SpellLevel.NINETH, CastingTime.ONE_ACTION, 0, V, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell TruePolymorph {
            get {
                return new Spell(Spells.ID.TRUE_POLYMORPH, SpellSchool.TRANSMUTATION, SpellLevel.NINETH, CastingTime.ONE_ACTION, 30, VSM, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell TrueResurrection {
            get {
                return new Spell(Spells.ID.TRUE_RESURRECTION, SpellSchool.NECROMANCY, SpellLevel.NINETH, CastingTime.ONE_HOUR, 0, VSM, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Weird {
            get {
                return new Spell(Spells.ID.WEIRD, SpellSchool.ILLUSION, SpellLevel.NINETH, CastingTime.ONE_ACTION, 120, VS, SpellDuration.ONE_MINUTE, 30, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Wish {
            get {
                return new Spell(Spells.ID.WISH, SpellSchool.CONJURATION, SpellLevel.NINETH, CastingTime.ONE_ACTION, 0, V, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
    }
}
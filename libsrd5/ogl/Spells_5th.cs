namespace srd5 {
    public partial struct Spells {
        /* TODO */
        public static Spell AnimateObjects {
            get {
                return new Spell(Spells.ID.ANIMATE_OBJECTS, SpellSchool.TRANSMUTATION, SpellLevel.FIFTH, CastingTime.ONE_ACTION, 120, VS, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell AntilifeShell {
            get {
                return new Spell(Spells.ID.ANTILIFE_SHELL, SpellSchool.ABJURATION, SpellLevel.FIFTH, CastingTime.ONE_ACTION, 0, VS, SpellDuration.ONE_HOUR, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ArcaneHand {
            get {
                return new Spell(Spells.ID.ARCANE_HAND, SpellSchool.EVOCATION, SpellLevel.FIFTH, CastingTime.ONE_ACTION, 120, VSM, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Awaken {
            get {
                return new Spell(Spells.ID.AWAKEN, SpellSchool.TRANSMUTATION, SpellLevel.FIFTH, CastingTime.EIGHT_HOURS, 0, VSM, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Cloudkill {
            get {
                return new Spell(Spells.ID.CLOUDKILL, SpellSchool.CONJURATION, SpellLevel.FIFTH, CastingTime.ONE_ACTION, 120, VS, SpellDuration.TEN_MINUTES, 20, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Commune {
            get {
                return new Spell(Spells.ID.COMMUNE, SpellSchool.DIVINATION, SpellLevel.FIFTH, CastingTime.ONE_MINUTE, 0, VSM, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell CommuneWithNature {
            get {
                return new Spell(Spells.ID.COMMUNE_WITH_NATURE, SpellSchool.DIVINATION, SpellLevel.FIFTH, CastingTime.ONE_MINUTE, 0, VS, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ConeOfCold {
            get {
                return new Spell(Spells.ID.CONE_OF_COLD, SpellSchool.EVOCATION, SpellLevel.FIFTH, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.INSTANTANEOUS, 60, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ConjureElemental {
            get {
                return new Spell(Spells.ID.CONJURE_ELEMENTAL, SpellSchool.CONJURATION, SpellLevel.FIFTH, CastingTime.ONE_MINUTE, 90, VSM, SpellDuration.ONE_HOUR, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ContactOtherPlane {
            get {
                return new Spell(Spells.ID.CONTACT_OTHER_PLANE, SpellSchool.DIVINATION, SpellLevel.FIFTH, CastingTime.ONE_MINUTE, 0, V, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Contagion {
            get {
                return new Spell(Spells.ID.CONTAGION, SpellSchool.NECROMANCY, SpellLevel.FIFTH, CastingTime.ONE_ACTION, 0, VS, SpellDuration.SEVEN_DAYS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Creation {
            get {
                return new Spell(Spells.ID.CREATION, SpellSchool.ILLUSION, SpellLevel.FIFTH, CastingTime.ONE_MINUTE, 30, VSM, SpellDuration.SPECIAL, 5, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell DispelEvilandGood {
            get {
                return new Spell(Spells.ID.DISPEL_EVIL_AND_GOOD, SpellSchool.ABJURATION, SpellLevel.FIFTH, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell DominatePerson {
            get {
                return new Spell(Spells.ID.DOMINATE_PERSON, SpellSchool.ENCHANTMENT, SpellLevel.FIFTH, CastingTime.ONE_ACTION, 60, VS, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Dream {
            get {
                return new Spell(Spells.ID.DREAM, SpellSchool.ILLUSION, SpellLevel.FIFTH, CastingTime.ONE_MINUTE, -1, VSM, SpellDuration.EIGHT_HOURS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell FlameStrike {
            get {
                return new Spell(Spells.ID.FLAME_STRIKE, SpellSchool.EVOCATION, SpellLevel.FIFTH, CastingTime.ONE_ACTION, 60, VSM, SpellDuration.INSTANTANEOUS, 40, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Geas {
            get {
                return new Spell(Spells.ID.GEAS, SpellSchool.ENCHANTMENT, SpellLevel.FIFTH, CastingTime.ONE_MINUTE, 60, V, SpellDuration.THIRTY_DAYS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell GreaterRestoration {
            get {
                return new Spell(Spells.ID.GREATER_RESTORATION, SpellSchool.ABJURATION, SpellLevel.FIFTH, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Hallow {
            get {
                return new Spell(Spells.ID.HALLOW, SpellSchool.EVOCATION, SpellLevel.FIFTH, CastingTime.ONE_DAY, 0, VSM, SpellDuration.UNTIL_DISPELLED, 60, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell HoldMonster {
            get {
                return new Spell(Spells.ID.HOLD_MONSTER, SpellSchool.ENCHANTMENT, SpellLevel.FIFTH, CastingTime.ONE_ACTION, 90, VSM, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell InsectPlague {
            get {
                return new Spell(Spells.ID.INSECT_PLAGUE, SpellSchool.CONJURATION, SpellLevel.FIFTH, CastingTime.ONE_ACTION, 300, VSM, SpellDuration.TEN_MINUTES, 20, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell LegendLore {
            get {
                return new Spell(Spells.ID.LEGEND_LORE, SpellSchool.DIVINATION, SpellLevel.FIFTH, CastingTime.TEN_MINUTES, 0, VSM, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MassCureWounds {
            get {
                return new Spell(Spells.ID.MASS_CURE_WOUNDS, SpellSchool.CONJURATION, SpellLevel.FIFTH, CastingTime.ONE_ACTION, 60, VS, SpellDuration.INSTANTANEOUS, 30, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Mislead {
            get {
                return new Spell(Spells.ID.MISLEAD, SpellSchool.ILLUSION, SpellLevel.FIFTH, CastingTime.ONE_ACTION, 0, S, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ModifyMemory {
            get {
                return new Spell(Spells.ID.MODIFY_MEMORY, SpellSchool.ENCHANTMENT, SpellLevel.FIFTH, CastingTime.ONE_ACTION, 30, VS, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Passwall {
            get {
                return new Spell(Spells.ID.PASSWALL, SpellSchool.TRANSMUTATION, SpellLevel.FIFTH, CastingTime.ONE_ACTION, 30, VSM, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PlanarBinding {
            get {
                return new Spell(Spells.ID.PLANAR_BINDING, SpellSchool.ABJURATION, SpellLevel.FIFTH, CastingTime.ONE_HOUR, 60, VSM, SpellDuration.ONE_DAY, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell RaiseDead {
            get {
                return new Spell(Spells.ID.RAISE_DEAD, SpellSchool.NECROMANCY, SpellLevel.FIFTH, CastingTime.ONE_HOUR, 0, VSM, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Reincarnate {
            get {
                return new Spell(Spells.ID.REINCARNATE, SpellSchool.TRANSMUTATION, SpellLevel.FIFTH, CastingTime.ONE_HOUR, 0, VSM, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Scrying {
            get {
                return new Spell(Spells.ID.SCRYING, SpellSchool.DIVINATION, SpellLevel.FIFTH, CastingTime.TEN_MINUTES, 0, VSM, SpellDuration.TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Seeming {
            get {
                return new Spell(Spells.ID.SEEMING, SpellSchool.ILLUSION, SpellLevel.FIFTH, CastingTime.ONE_ACTION, 30, VS, SpellDuration.EIGHT_HOURS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Telekinesis {
            get {
                return new Spell(Spells.ID.TELEKINESIS, SpellSchool.TRANSMUTATION, SpellLevel.FIFTH, CastingTime.ONE_ACTION, 60, VS, SpellDuration.TEN_MINUTES, 30, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell TelepathicBond {
            get {
                return new Spell(Spells.ID.TELEPATHIC_BOND, SpellSchool.DIVINATION, SpellLevel.FIFTH, CastingTime.ONE_ACTION, 30, VSM, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell TeleportationCircle {
            get {
                return new Spell(Spells.ID.TELEPORTATION_CIRCLE, SpellSchool.CONJURATION, SpellLevel.FIFTH, CastingTime.ONE_MINUTE, 10, VM, SpellDuration.ONE_ROUND, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell TreeStride {
            get {
                return new Spell(Spells.ID.TREE_STRIDE, SpellSchool.CONJURATION, SpellLevel.FIFTH, CastingTime.ONE_ACTION, 0, VS, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell WallOfForce {
            get {
                return new Spell(Spells.ID.WALL_OF_FORCE, SpellSchool.EVOCATION, SpellLevel.FIFTH, CastingTime.ONE_ACTION, 120, VSM, SpellDuration.TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell WallOfStone {
            get {
                return new Spell(Spells.ID.WALL_OF_STONE, SpellSchool.EVOCATION, SpellLevel.FIFTH, CastingTime.ONE_ACTION, 120, VSM, SpellDuration.TEN_MINUTES, 0, 0, doNothing);
            }
        }
    }
}
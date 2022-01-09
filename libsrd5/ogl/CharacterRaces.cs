using System;

namespace srd5 {
    public enum Race {
        HILL_DWARF,
        HIGH_ELF,
        HALFLING,
        HUMAN,
        DRAGONBORN,
        GNOME,
        HALF_ELF,
        HALF_ORC,
        TIEFLING
    }

    public static class RaceExtension {
        public static CharacterRace CharacterRace(this Race race) {
            switch (race) {
                case Race.HILL_DWARF:
                    return CharacterRaces.HillDwarf;
                case Race.HIGH_ELF:
                    return CharacterRaces.HighElf;
                case Race.HALFLING:
                    return CharacterRaces.Halfling;
                case Race.HUMAN:
                    return CharacterRaces.Human;
                case Race.DRAGONBORN:
                    return CharacterRaces.Dragonborn;
                case Race.GNOME:
                    return CharacterRaces.Gnome;
                case Race.HALF_ELF:
                    return CharacterRaces.HalfElf;
                case Race.HALF_ORC:
                    return CharacterRaces.HalfOrc;
                case Race.TIEFLING:
                    return CharacterRaces.Tiefling;
            }
            throw new Srd5ArgumentException("Unknown race");
        }
    }

    public struct CharacterRaces {
        public static readonly CharacterRace HillDwarf = new CharacterRace(
            Race.HILL_DWARF,
            25,
            new Feat[] { Feat.DWARVEN_COMBAT_TRAINING, Feat.DWARVEN_ABILITY_INCREASE, Feat.HILL_DWARVEN_ABILITY_INCREASE, Feat.DWARVEN_RESILIENCE, Feat.DWARVEN_DARKVISION, Feat.STONECUNNING, Feat.DWARVEN_TOUGHNESS }
        );

        public static readonly CharacterRace HighElf = new CharacterRace(
            Race.HIGH_ELF,
            30,
            new Feat[] { Feat.ELVEN_ABILITY_INCREASE, Feat.HIGH_ELVEN_ABILITY_INCREASE, Feat.ELVEN_DARKVISION, Feat.KEEN_SENSES, Feat.FEY_ANCESTRY, Feat.HIGH_ELVEN_WEAPON_TRAINING, Feat.HIGH_ELVEN_CANTRIP }
        );

        public static readonly CharacterRace Halfling = new CharacterRace(
            Race.HALFLING,
            25,
            new Feat[] { }
        );

        public static readonly CharacterRace Human = new CharacterRace(
            Race.HUMAN,
            30,
            new Feat[] { Feat.HUMAN_ABILITY_INCREASE }
        );

        public static readonly CharacterRace Dragonborn = new CharacterRace(
            Race.DRAGONBORN,
            30,
            new Feat[] { }
        );

        public static readonly CharacterRace Gnome = new CharacterRace(
            Race.GNOME,
            25,
            new Feat[] { },
            Size.SMALL
        );

        public static readonly CharacterRace HalfElf = new CharacterRace(
            Race.HALF_ELF,
            30,
            new Feat[] { }
        );

        public static readonly CharacterRace HalfOrc = new CharacterRace(
            Race.HALF_ORC,
            30,
            new Feat[] { }
        );

        public static readonly CharacterRace Tiefling = new CharacterRace(
            Race.TIEFLING,
            30,
            new Feat[] { }
        );
    }
}
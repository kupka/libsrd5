namespace d20 {
    public enum Race {
        DWARF,
        ELF,
        HALFLING,
        HUMAN,
        DRAGONBORN,
        GNOME,
        HALF_ELF,
        HALF_ORC,
        TIEFLING
    }

    public struct CharacterRaces {
        public static readonly CharacterRace Dwarf = new CharacterRace(
            Race.DWARF,
            25,
            new RacialFeat[] { RacialFeats.DwarvenCombatTraining, RacialFeats.DwarvenConstitution, RacialFeats.DarkVision }
        );

        public static readonly CharacterRace Elf = new CharacterRace(
            Race.ELF,
            30,
            new RacialFeat[] { }
        );

        public static readonly CharacterRace Halfling = new CharacterRace(
            Race.HALFLING,
            25,
            new RacialFeat[] { }
        );

        public static readonly CharacterRace Human = new CharacterRace(
            Race.HUMAN,
            30,
            new RacialFeat[] { }
        );

        public static readonly CharacterRace Dragonborn = new CharacterRace(
            Race.DRAGONBORN,
            30,
            new RacialFeat[] { }
        );

        public static readonly CharacterRace Gnome = new CharacterRace(
            Race.GNOME,
            25,
            new RacialFeat[] { }
        );

        public static readonly CharacterRace HalfElf = new CharacterRace(
            Race.HALF_ELF,
            30,
            new RacialFeat[] { }
        );

        public static readonly CharacterRace HalfOrc = new CharacterRace(
            Race.HALF_ORC,
            30,
            new RacialFeat[] { }
        );

        public static readonly CharacterRace Tiefling = new CharacterRace(
            Race.TIEFLING,
            30,
            new RacialFeat[] { }
        );
    }
}
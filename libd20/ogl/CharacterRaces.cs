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
            new RacialFeat[]{RacialFeats.DwarvenCombatTraining, RacialFeats.DwarvenConstitution, RacialFeats.DarkVision}
        );
    }
}
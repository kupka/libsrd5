using System;

namespace srd5 {
    public class CharacterRace {
        public Race Race { get; internal set; }
        public int Speed { get; internal set; }
        public Feat[] RacialFeats { get; internal set; }
        public Size Size { get; internal set; }

        public CharacterRace(Race race, int speed, Feat[] racialFeats, Size size = Size.MEDIUM) {
            Race = race;
            Speed = speed;
            RacialFeats = racialFeats;
            Size = size;
        }
    }
}
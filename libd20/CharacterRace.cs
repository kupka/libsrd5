using System;

namespace d20 {
    public class CharacterRace {
        public Race Race { get; internal set; }
        public int Speed { get; internal set; }
        public RacialFeat[] RacialFeats { get; internal set; }

        public CharacterRace(Race race, int speed, RacialFeat[] racialFeats) {
            Race = race;
            Speed = speed;
            RacialFeats = racialFeats;
        }
    }
}
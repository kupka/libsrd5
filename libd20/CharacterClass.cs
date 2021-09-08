using System;

namespace d20 {
    public struct CharacterClass {
        public Class Class { get; internal set; }

        public int HitDice { get; internal set; }

        public Proficiency[] Proficiencies { get; internal set; }
    }
}
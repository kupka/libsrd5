using System;

namespace srd5 {
    public struct CharacterClass {
        public Class Class { get; internal set; }

        public int HitDice { get; internal set; }

        public Proficiency[] Proficiencies { get; internal set; }

        public Feat[][] Feats { get; internal set; }

        public int[][] SpellSlots { get; internal set; }
    }
}
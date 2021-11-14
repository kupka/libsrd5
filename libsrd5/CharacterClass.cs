using System;

namespace srd5 {
    public struct CharacterClass {
        public Class Class { get; internal set; }

        public int HitDice { get; internal set; }

        public Proficiency[] Proficiencies { get; internal set; }

        public Feat[][] Feats { get; internal set; }

        public AbilityType SpellCastingAbility { get; internal set; }

        public int[] KnownSpells { get; internal set; }

        public int[][] SpellSlots { get; internal set; }

        public bool MustPrepareSpells { get; internal set; }

        public override bool Equals(object obj) {
            if (!(obj is CharacterClass)) return false;
            return GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode() {
            return (int)Class;
        }
    }
}
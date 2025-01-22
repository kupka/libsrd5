using System;

namespace srd5 {
    public struct CharacterClass {
        public Class Class { get; internal set; }

        public int HitDie { get; internal set; }

        public Proficiency[] Proficiencies { get; internal set; }

        public Feat[][] Feats { get; internal set; }

        public AbilityType SpellCastingAbility { get; internal set; }

        public int[] KnownSpellsLimit { get; internal set; }

        public int[][] SpellSlots { get; internal set; }

        public bool MustPrepareSpells { get; internal set; }

        public string Name {
            get {
                return this.Class.Name();
            }
        }

        public override bool Equals(object obj) {
            if (!(obj is CharacterClass)) return false;
            return GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode() {
            return (int)Class;
        }
    }
}
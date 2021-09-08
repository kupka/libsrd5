using System;

namespace d20 {
    public class CharacterClass {
        public Class Class {
            get;
            internal set;
        }

        public int HitDice {
            get;
            internal set;
        }

        public Proficiency[] Proficiencies {
            get;
            internal set;
        }

        public bool IsProficientIn(Item item) {
            foreach (Proficiency needs in item.Proficiencies) {
                foreach (Proficiency has in Proficiencies) {
                    if (needs == has) return true;
                }
            }
            return false;
        }
    }
}
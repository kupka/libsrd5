using System;

namespace d20 {
    public class Barbarian : CharacterClass {
        public Barbarian() {
            HitDice = 12;
            Proficiencies = new Proficiency[]{
                            Proficiency.LIGHT_ARMOR,
                            Proficiency.MEDIUM_ARMOR,
                            Proficiency.SHIELDS,
                            Proficiency.SIMPLE_MELEE_WEAPONS,
                            Proficiency.SIMPLE_RANGED_WEAPONS,
                            Proficiency.MARTIAL_MELEE_WEAPONS,
                            Proficiency.MARTIAL_RANGED_WEAPONS
                        };
        }
    }

    public abstract class CharacterClass {
        public uint HitDice {
            get;
            internal set;
        }

        public Proficiency[] Proficiencies {
            get;
            internal set;
        }

        public bool IsProficientIn(Item item) {
            foreach(Proficiency needs in item.Proficiencies) {
                foreach(Proficiency has in Proficiencies) {
                    if(needs == has) return true;
                }
            }
            return false;
        }
    }
}
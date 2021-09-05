using System;

namespace d20 {
    public enum Class {
        BARBARIAN,
        BARD,
        CLERIC,
        DRUID,
        FIGHTER,
        MONK,
        PALADIN,
        RANGER,
        ROGUE,
        SORCEROR,
        WARLOCK,
        WIZARD
    }
    public class CharacterClass {

        public static CharacterClass Barbarian {
            get {
                CharacterClass barbarian = new CharacterClass();
                barbarian.Class = Class.BARBARIAN;
                barbarian.HitDice = 12;
                barbarian.Proficiencies = new Proficiency[]{
                                Proficiency.LIGHT_ARMOR,
                                Proficiency.MEDIUM_ARMOR,
                                Proficiency.SHIELDS,
                                Proficiency.SIMPLE_MELEE_WEAPONS,
                                Proficiency.SIMPLE_RANGED_WEAPONS,
                                Proficiency.MARTIAL_MELEE_WEAPONS,
                                Proficiency.MARTIAL_RANGED_WEAPONS
                            };
                barbarian.BaseAttackBonus = 1;
                return barbarian;
            }
        }

        public Class Class {
            get;
            internal set;
        }

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

        public float BaseAttackBonus {
            get;
            internal set;
        }
    }
}
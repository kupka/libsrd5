using System;

namespace d20 {
    public enum AbilityType {
        Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma
    }
    
    public class Ability {
        public int Modifier {
            get {
                if(Value <= 1) {
                    return -5;
                } else if (Value >= 30) {
                    return 10;
                } else {
                    return (int)(Value / 2) - 5;
                }
            }
        }

        public uint Value {
            get;
            internal set;
        }

        public AbilityType Type {
            get;
            internal set;
        }

        internal Ability(AbilityType type, uint value) {
            Type = type;
            Value = value;
        }
    }
}
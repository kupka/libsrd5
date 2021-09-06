using System;

namespace d20 {
    public class Ability {
        public int Modifier {
            get {
                if(Value <= 1) {
                    return -5;
                } else if (Value >= 30) {
                    return 10;
                } else {
                    return (Value / 2) - 5;
                }
            }
        }

        public int Value {
            get;
            internal set;
        }

        public AbilityType Type {
            get;
            internal set;
        }

        internal Ability(AbilityType type, int value) {
            Type = type;
            Value = value;
        }
    }
}
using System;

namespace srd5 {
    public class Ability {
        public int Modifier {
            get {
                if (Value <= 1) {
                    return -5;
                } else if (Value > 29) {
                    return 10;
                } else {
                    return (Value / 2) - 5;
                }
            }
        }
        public int Value {
            get {
                return Math.Max(BaseValue, ModifiedMinimumBaseValue) + ValueModifier;
            }
        }
        public AbilityType Type { get; internal set; }
        public int BaseValue { get; internal set; }
        public int ModifiedMinimumBaseValue { get; private set; }
        public int ValueModifier { get; internal set; }
        public string Name {
            get {
                return Type.Name();
            }
        }

        private int[] minimumBaseValues = new int[0];
        public void AddMinimumBaseValue(int value) {
            Utils.Push<int>(ref minimumBaseValues, value);
            ModifiedMinimumBaseValue = Utils.Max<int>(minimumBaseValues);
        }

        public void RemoveMinimumBaseValue(int value) {
            Utils.RemoveSingle<int>(ref minimumBaseValues, value);
            ModifiedMinimumBaseValue = Utils.Max<int>(minimumBaseValues);
        }


        internal Ability(AbilityType type, int value) {
            Type = type;
            BaseValue = value;
        }
    }
}
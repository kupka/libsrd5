using System;

namespace srd5 {
    public struct Dice {
        public static Dice Get(int max) {
            switch (max) {
                case 2:
                case 3:
                case 4:
                case 6:
                case 8:
                case 10:
                case 12:
                case 20:
                case 100:
                    Dice dice = new Dice();
                    dice.MaxValue = max;
                    dice.Value = Random.Get(1, max);
                    return dice;
                default:
                    throw new ArgumentOutOfRangeException("No such dice d" + max);
            }
        }

        public static Dice D2 {
            get {
                return Get(2);
            }
        }

        public static Dice D3 {
            get {
                return Get(3);
            }
        }

        public static Dice D4 {
            get {
                return Get(4);
            }
        }

        public static Dice D6 {
            get {
                return Get(6);
            }
        }

        public static Dice D8 {
            get {
                return Get(8);
            }
        }

        public static Dice D10 {
            get {
                return Get(10);
            }
        }

        public static Dice D12 {
            get {
                return Get(12);
            }
        }

        public static Dice D20 {
            get {
                return Get(20);
            }
        }

        public static Dice D20Advantage {
            get {
                Dice first = Get(20);
                Dice second = Get(20);
                if (first.Value >= second.Value)
                    return first;
                else
                    return second;
            }
        }

        public static Dice D20Disadvantage {
            get {
                Dice first = Get(20);
                Dice second = Get(20);
                if (first.Value <= second.Value)
                    return first;
                else
                    return second;
            }
        }

        public static Dice D100 {
            get {
                return Get(100);
            }
        }

        public int Value {
            get;
            internal set;
        }

        public int MaxValue {
            get;
            private set;
        }

        public static long Roll(string diceString) {
            Dices parsed = new Dices(diceString);
            return parsed.Roll();
        }
    }

    public struct Dices {
        internal int Modifier {
            get;
            set;
        }

        internal int Amount {
            get;
            set;
        }

        internal int Dice {
            get;
            set;
        }

        public long Min {
            get {
                return Amount + Modifier;
            }
        }

        public long Max {
            get {
                return Amount * Dice + Modifier;
            }
        }

        private string diceString;
        public override string ToString() {
            return diceString;
        }

        internal Dices(string diceString) {
            this.diceString = diceString;
            Amount = 1;
            Dice = 0;
            Modifier = 0;
            bool negativeModifier = false;
            int state = 0; // 0 = Start, 1 = Dice, 2 = Modifier
            for (int i = 0; i < diceString.Length; i++) {
                char c = diceString[i];
                switch (state) {
                    case 0:
                        if (char.IsDigit(c)) {
                            if (i == 0) {
                                Amount = 0;
                            } else {
                                Amount *= 10;
                            }
                            Amount += int.Parse(c.ToString());
                            break;
                        } else if (c == 'd') {
                            state = 1;
                            continue;
                        } else {
                            throw new FormatException("Invalid input: " + diceString);
                        }
                    case 1:
                        if (char.IsDigit(c)) {
                            if (Dice > 0) {
                                Dice *= 10;
                            }
                            Dice += int.Parse(c.ToString());
                            break;
                        } else if (c == '+') {
                            state = 2;
                            continue;
                        } else if (c == '-') {
                            negativeModifier = true;
                            state = 2;
                            continue;
                        } else {
                            throw new FormatException("Invalid input: " + diceString);
                        }
                    case 2:
                        if (char.IsDigit(c)) {
                            if (Modifier != 0) {
                                Modifier *= 10;
                            }
                            Modifier += int.Parse(c.ToString());
                        } else {
                            throw new FormatException("Invalid input: " + diceString);
                        }
                        break;
                }
            }
            if (negativeModifier) {
                Modifier *= -1;
            }
            switch (Dice) {
                case 1:
                case 2:
                case 3:
                case 4:
                case 6:
                case 8:
                case 10:
                case 12:
                case 20:
                case 100:
                    break;
                default:
                    throw new FormatException("Invalid input: " + diceString);
            }
        }

        public int Roll() {
            int result = Modifier;
            for (int i = 0; i < Amount; i++) {
                result += Random.Get(1, Dice);
            }
            return result;
        }
    }
}
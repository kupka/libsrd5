using System;

namespace d20 {
    public struct Dice {
        public static Dice Get(uint max) {
            switch(max) {
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
                if(first.Value >= second.Value)
                    return first;
                else
                    return second;
            }
        }

        public static Dice D20Disadvantage {
            get {
                Dice first = Get(20);
                Dice second = Get(20);
                if(first.Value <= second.Value)
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

        public uint Value {
            get;
            private set;
        }

        public static int Roll(int modifier, params Dice[] dices) {
            int roll = modifier;
            foreach (Dice dice in dices) {
                roll += (int)dice.Value;
            }
            return roll;
        }

        public static int Roll(string toParse) {
            int amount = 1;
            uint dice = 0;
            int modifier = 0;
            bool negativeModifier = false;
            int state = 0; // 0 = Start, 1 = Dice, 2 = Modifier
            for(int i = 0; i < toParse.Length; i++) {
                char c = toParse[i];
                switch(state) {
                    case 0:
                        if(char.IsDigit(c)) {
                            if(i > 0) {
                                amount *= 10;
                            }
                            amount += int.Parse(c.ToString());
                            break;
                        } else if (c == 'd') {
                            state = 1;
                            continue;
                        } else {
                            throw new FormatException("Invalid input: " +  toParse);
                        }
                    case 1:
                        if(char.IsDigit(c)) {
                            if(dice > 0) {
                                dice *= 10;
                            }
                            dice += uint.Parse(c.ToString());
                            break;
                        } else if (c == '+') {
                            state = 2;
                            continue;
                        } else if (c == '-') {
                            negativeModifier = true;
                            state = 2;
                            continue;
                        } else {
                            throw new FormatException("Invalid input: " + toParse);
                        }
                    case 2:
                        if(char.IsDigit(c)) {
                            if(modifier != 0) {
                                modifier *= 10;
                            }
                            modifier += int.Parse(c.ToString());
                        } else {
                            throw new FormatException("Invalid input: " + toParse);
                        }
                        break;
                }
            }
            if(negativeModifier) {
                modifier *= -1;
            }
            if(dice != 2 && dice != 3 && dice != 4 && dice != 6 && dice != 8 && dice != 10 && dice != 12 && dice != 20 && dice != 100) {
                throw new FormatException("Invalid input: " + toParse);
            }
            int result = modifier;
            for(int i = 0; i < amount; i++) {
                result += (int)Random.Get(1, dice);
            }
            return result;
        }
    }
}
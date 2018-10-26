using System;

namespace d20 {
    public struct Dice {
        public static Dice D4 {
            get {
                Dice dice = new Dice();
                dice.Value = Random.Get(1, 4);
                return dice;
            }
        }

        public static Dice D6 {
            get {
                Dice dice = new Dice();
                dice.Value = Random.Get(1, 6);
                return dice;
            }
        }

        public static Dice D8 {
            get {
                Dice dice = new Dice();
                dice.Value = Random.Get(1, 8);
                return dice;
            }
        }

        public static Dice D10 {
            get {
                Dice dice = new Dice();
                dice.Value = Random.Get(1, 10);
                return dice;
            }
        }

        public static Dice D12 {
            get {
                Dice dice = new Dice();
                dice.Value = Random.Get(1, 12);
                return dice;
            }
        }

        public static Dice D20 {
            get {
                Dice dice = new Dice();
                dice.Value = Random.Get(1, 20);
                return dice;
            }
        }

        public static Dice D100 {
            get {
                Dice dice = new Dice();
                dice.Value = Random.Get(1, 100);
                return dice;
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
            if(dice != 4 && dice != 6 && dice != 8 && dice != 10 && dice != 12 && dice != 20 && dice != 100) {
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
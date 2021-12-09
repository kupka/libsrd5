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
                    Dices.onDiceRolled(dice);
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

        public static int Roll(string diceString) {
            Dices parsed = new Dices(diceString);
            return parsed.Roll();
        }

        public override string ToString() {
            return "d" + MaxValue;
        }
    }

    public abstract class DiceRolledEventSource {

    }

    public class DiceRolledEvent : EventArgs {
        internal static DiceRolledEventSource source { get; set; }
        public Dices Dices { get; private set; }
        public int Value { get; private set; }
        public DiceRolledEventSource Source { get; private set; }

        public DiceRolledEvent(Dices dices, int value) {
            Dices = dices;
            Value = value;
            Source = source;
            source = null;
        }
    }

    public struct Dices {
        internal int Modifier {
            get;
            private set;
        }

        internal int Amount {
            get;
            private set;
        }

        internal int Dice {
            get;
            private set;
        }

        public int Min {
            get {
                return Math.Max(0, Amount + Modifier);
            }
        }

        public int Max {
            get {
                return Math.Max(0, Amount * Dice + Modifier);
            }
        }

        private string diceString;
        public override string ToString() {
            return diceString;
        }

        internal Dices(int amount, int dice, int modifier) {
            Amount = amount;
            Dice = dice;
            Modifier = modifier;
            string modifierString = "";
            if (modifier > 0)
                modifierString = "+" + modifier;
            else if (modifier < 0)
                modifierString += modifier;
            diceString = amount + "d" + dice + modifierString;
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
            int value = Math.Max(0, result);
            onDiceRolled(this, value);
            return value;
        }

        // Crticial hits roll each dice twice
        public int RollCritical() {
            int result = Modifier;
            for (int i = 0; i < Amount; i++) {
                result += Random.Get(1, Dice);
                result += Random.Get(1, Dice);
            }
            int value = Math.Max(0, result);
            onDiceRolled(this, value);
            return value;
        }

        /// <summary>
        /// Roll a D20 dice to check against a DC (difficulty check) with the given Ability as its modifier
        /// </summary>
        public static bool DC(int dc, Ability ability) {
            Dice d20 = srd5.Dice.D20;
            onDiceRolled(d20);
            if (d20.Value == 20) return true;
            if (d20.Value == 1) return false;
            return d20.Value + ability.Modifier >= dc;
        }

        // Event Handling
        public static event EventHandler<DiceRolledEvent> DiceRolled;

        internal static void onDiceRolled(Dices dices, int value) {
            if (DiceRolled == null) return;
            DiceRolledEvent diceRolledEvent = new DiceRolledEvent(dices, value);
            DiceRolled(dices, diceRolledEvent);
        }

        internal static void onDiceRolled(Dice dice) {
            if (DiceRolled == null) return;
            Dices dices = new Dices(dice.ToString());
            DiceRolledEvent diceRolledEvent = new DiceRolledEvent(dices, dice.Value);
            DiceRolled(dices, diceRolledEvent);
        }
    }
}
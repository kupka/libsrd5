namespace srd5 {
    internal class Random {
        private static uint state = 1838911792;

        public static uint State {
            get {
                return state;
            }
            set {
                state = value;
            }
        }

        private static uint xorshift32() {
            /* Algorithm "xor" from p. 4 of Marsaglia, "Xorshift RNGs" */
            uint x = state;
            x ^= x << 13;
            x ^= x >> 17;
            x ^= x << 5;
            state = x;
            return x;
        }

        internal static int Get(int min, int max) {
            if (min < 0) {
                throw new System.ArgumentException("min must be greater or equal than 0.");
            }
            if (max <= min) {
                throw new System.ArgumentException("max must be greater than min.");
            }
            uint r = xorshift32();
            uint diff = (uint)(max - min);
            r = r % (diff + 1);
            r += (uint)min;
            return (int)r;
        }
    }
}
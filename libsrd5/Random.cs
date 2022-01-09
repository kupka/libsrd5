namespace srd5 {
    internal class Random {
        public static uint State { get; set; } = 1838911792;

        private static uint xorshift32() {
            /* Algorithm "xor" from p. 4 of Marsaglia, "Xorshift RNGs" */
            uint x = State;
            x ^= x << 13;
            x ^= x >> 17;
            x ^= x << 5;
            State = x;
            return x;
        }

        internal static int Get(int min, int max) {
            if (min < 0) {
                throw new Srd5ArgumentException("min must be greater or equal than 0.");
            }
            if (max < min) {
                throw new Srd5ArgumentException("max must be greater or equal than min.");
            }
            uint r = xorshift32();
            uint diff = (uint)(max - min);
            r = r % (diff + 1);
            r += (uint)min;
            return (int)r;
        }
    }
}
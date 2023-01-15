namespace srd5 {
    public enum Alignment {
        UNALIGNED,
        LAWFUL_GOOD,
        NEUTRAL_GOOD,
        LAWFUL_EVIL,
        LAWFUL_NEUTRAL,
        NEUTRAL,
        CHAOTIC_NEUTRAL,
        CHAOTIC_GOOD,
        NEUTRAL_EVIL,
        CHAOTIC_EVIL
    }

    public static class AlignmentExtension {
        public static bool IsGood(this Alignment alignment) {
            return alignment == Alignment.LAWFUL_GOOD || alignment == Alignment.NEUTRAL_GOOD || alignment == Alignment.CHAOTIC_GOOD;
        }

        public static bool IsNeutral(this Alignment alignment) {
            return !(alignment == Alignment.UNALIGNED || alignment.IsGood() || alignment.IsEvil());
        }

        public static bool IsEvil(this Alignment alignment) {
            return alignment == Alignment.LAWFUL_EVIL || alignment == Alignment.NEUTRAL_EVIL || alignment == Alignment.CHAOTIC_EVIL;
        }
    }
}
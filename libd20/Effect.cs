using System;

namespace d20 {
    public struct Effect {
        public EffectType Type { get; internal set; }

        public Effect(EffectType type) {
            Type = type;
        }
    }
}
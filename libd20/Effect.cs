using System;

namespace d20 {
    public class Effect {
                
        public object Source { get; private set; }
        public CharacterSheet Character { get; private set; }
        public EffectType[] Types { get; private set; }

        public Effect(object source, CharacterSheet character, params EffectType[] types ) {
            Source = source;
            Character = character;
            Types = types;
            
        }


    }
}
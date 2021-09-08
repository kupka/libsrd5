using System;

namespace d20 {
    public class Skill {
        public SkillType Type {
            get;
            internal set;
        }

        public AbilityType Ability {
            get;
            internal set;
        }

        public Skill(SkillType type, AbilityType ability) {
            Type = type;
            Ability = ability;
        }
    }
}

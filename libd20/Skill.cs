using System;

namespace d20
{
    public enum SkillType {
        SKILL_A,
        SKILL_B
    }

    public class Skill {
        public SkillType Type {
            get;
            internal set;
        }
    }
}

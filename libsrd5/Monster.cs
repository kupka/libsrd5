using System;

namespace srd5 {
    public struct ChallengeRating {
        public static readonly int QUARTER = -2;
        public static readonly int HALF = -1;
    }

    public class Monster : Combattant {
        public MonsterType Type { get; internal set; }

        public int Challenge { get; internal set; } = 1;

        public int SpellCastDC { get; private set; } = 0;

        public override int ProficiencyBonus {
            get {
                if (Challenge <= 4) return 2;
                return (int)Math.Ceiling((Challenge - 4) / 4.0f) + 2;
            }
        }

        public Monster(MonsterType type, string name, Alignment alignment, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma,
                        int armorClass, string hitDice, int speed, int challenge, Attack[] meleeAttacks, Attack[] rangedAttacks, Size size, int spellCastDC = 0) {
            Type = type;
            Name = name;
            Alignment = alignment;
            Strength.BaseValue = strength;
            Dexterity.BaseValue = dexterity;
            Constitution.BaseValue = constitution;
            Intelligence.BaseValue = intelligence;
            Wisdom.BaseValue = wisdom;
            Charisma.BaseValue = charisma;
            ArmorClass = armorClass;
            int hp = new Dices(hitDice).Roll();
            HitPointsMax = hp;
            HitPoints = hp;
            Speed = speed;
            Challenge = challenge;
            EffectiveLevel = challenge;
            MeleeAttacks = meleeAttacks;
            RangedAttacks = rangedAttacks;
            Size = size;
            SpellCastDC = spellCastDC;
        }
    }
}
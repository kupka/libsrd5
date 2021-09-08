namespace d20 {
    public class Attack {
        public string Name { get; internal set; }
        public int AttackBonus { get; internal set; }
        public Damage Damage { get; internal set; }
        public Damage AdditionalDamage { get; internal set; }
        public int Reach { get; internal set; }
        public int RangeNormal { get; internal set; }
        public int RangeLong { get; internal set; }
        public Attack(string name, int attackBonus, Damage damage, int reach = 5, int rangeNormal = 0, int rangeLong = 0, Damage additionalDamage = null) {
            Name = name;
            AttackBonus = attackBonus;
            Damage = damage;
            AdditionalDamage = additionalDamage;
            Reach = reach;
            RangeNormal = rangeNormal;
            RangeLong = rangeLong;
        }
    }

    public struct ChallengeRating {
        public static readonly int QUARTER = -2;
        public static readonly int HALF = -1;
    }

    public class Monster : Combattant {
        public Ability Strength { get; internal set; } = new Ability(AbilityType.STRENGTH, 10);
        public Ability Dexterity { get; internal set; } = new Ability(AbilityType.DEXTERITY, 10);
        public Ability Constitution { get; internal set; } = new Ability(AbilityType.CONSTITUTION, 10);
        public Ability Intelligence { get; internal set; } = new Ability(AbilityType.INTELLIGENCE, 10);
        public Ability Wisdom { get; internal set; } = new Ability(AbilityType.WISDOM, 10);
        public Ability Charisma { get; internal set; } = new Ability(AbilityType.CHARISMA, 10);
        public string Name { get; internal set; }
        public int Speed { get; internal set; } = 30;
        public int Challenge { get; internal set; } = 1;
        public Attack[] MeleeAttacks { get; internal set; } = new Attack[0];
        public Attack[] RangedAttacks { get; internal set; } = new Attack[0];

        public Monster(string name, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma,
                        int armorClass, string hitDice, int speed, int challenge, Attack[] meleeAttacks, Attack[] rangedAttacks) {
            Name = name;
            Strength.Value = strength;
            Dexterity.Value = dexterity;
            Constitution.Value = constitution;
            Intelligence.Value = intelligence;
            Wisdom.Value = wisdom;
            Charisma.Value = charisma;
            ArmorClass = armorClass;
            int hp = new Dices(hitDice).Roll();
            HitPointsMax = hp;
            HitPoints = hp;
            Speed = speed;
            Challenge = challenge;
            MeleeAttacks = meleeAttacks;
            RangedAttacks = rangedAttacks;
        }
    }
}
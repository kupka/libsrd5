namespace d20 {
    public class Attack {
        public string Name { get; internal set; }
        public int AttackBonus { get; internal set; }
        public string Damage { get; internal set; }
        public int Reach { get; internal set; }
        public int RangeNormal { get; internal set; }
        public int RangeLong { get; internal set; }
        public DamageType DamageType { get; internal set; }

        public Attack(string name, int attackBonus, string damage, DamageType damageType, int reach = 5, int rangeNormal = 0, int rangeLong = 0) {
            Name = name;
            AttackBonus = attackBonus;
            Damage = damage;
            DamageType = damageType;
            Reach = reach;
            RangeNormal = rangeNormal;
            RangeLong = rangeLong;
        }
    }



    public class Monster {
        public Ability Strength { get; internal set; } = new Ability(AbilityType.STRENGTH, 10);
        public Ability Dexterity { get; internal set; } = new Ability(AbilityType.DEXTERITY, 10);
        public Ability Constitution { get; internal set; } = new Ability(AbilityType.CONSTITUTION, 10);
        public Ability Intelligence { get; internal set; } = new Ability(AbilityType.INTELLIGENCE, 10);
        public Ability Wisdom { get; internal set; } = new Ability(AbilityType.WISDOM, 10);
        public Ability Charisma { get; internal set; } = new Ability(AbilityType.CHARISMA, 10);
        public string Name { get; internal set; }
        public int ArmorClass { get; internal set; } = 10;
        public int Speed { get; internal set; } = 30;
        public int Challenge { get; internal set; } = 1;
        public Attack[] MeleeAttacks { get; internal set; } = new Attack[0];
        public Attack[] RangedAttacks { get; internal set; } = new Attack[0];
        public uint HitPointsMax { get; internal set; }
        public uint HitPoints { get; internal set; }        

        public Monster(string name, uint strength, uint dexterity, uint constitution, uint intelligence, uint wisdom, uint charisma, int armorClass, string hitDice, int speed, int challenge) {
            Name = name;
            Strength.Value = strength;
            Dexterity.Value = dexterity;
            Constitution.Value = constitution;
            Intelligence.Value = intelligence;
            Wisdom.Value = wisdom;
            Charisma.Value = charisma;            
            ArmorClass = armorClass;
            uint hp = (uint)new Dices(hitDice).Roll();
            HitPointsMax = hp;
            HitPoints = hp;
            Speed = speed;
            Challenge = challenge;
        }
    }
}
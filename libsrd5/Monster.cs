namespace srd5 {
    public struct ChallengeRating {
        public static readonly int QUARTER = -2;
        public static readonly int HALF = -1;
    }

    public class Monster : Combattant {
        public int Challenge { get; internal set; } = 1;

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

        public override void AddEffect(Effect effect) {
            throw new System.NotImplementedException();
        }

        public override void RemoveEffect(Effect effect) {
            throw new System.NotImplementedException();
        }
    }
}
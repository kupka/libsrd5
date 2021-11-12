using System;

namespace srd5 {
    public class Attack {
        public string Name { get; set; }
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

        public static Attack FromWeapon(int attackBonus, string damageString, Weapon weapon, Damage additionalDamage = null) {
            return new Attack(weapon.Name, attackBonus,
                new Damage(weapon.Damage.Type, damageString), weapon.Reach, weapon.RangeNormal, weapon.RangeLong, additionalDamage);
        }
    }

    public abstract class Combattant {
        public int Speed { get; internal set; } = 30;
        public string Name { get; internal set; }
        public Ability Strength { get; internal set; } = new Ability(AbilityType.STRENGTH, 10);
        public Ability Dexterity { get; internal set; } = new Ability(AbilityType.DEXTERITY, 10);
        public Ability Constitution { get; internal set; } = new Ability(AbilityType.CONSTITUTION, 10);
        public Ability Intelligence { get; internal set; } = new Ability(AbilityType.INTELLIGENCE, 10);
        public Ability Wisdom { get; internal set; } = new Ability(AbilityType.WISDOM, 10);
        public Ability Charisma { get; internal set; } = new Ability(AbilityType.CHARISMA, 10);
        public int ArmorClass { get; internal set; }
        public int ArmorClassModifier { get; internal set; }
        public int HitPoints { get; set; }
        public int HitPointsMax { get; internal set; }
        public Attack[] MeleeAttacks { get; internal set; } = new Attack[0];
        public Attack[] RangedAttacks { get; internal set; } = new Attack[0];
        public Attack BonusAttack { get; internal set; }
        public Size Size { get; internal set; }
        public Effect[] Effects { get { return effects; } }
        private Effect[] effects = new Effect[0];
        public abstract int EffectiveLevel();
        public void AddEffect(Effect effect) {
            bool pushed = Utils.PushUnique<Effect>(ref effects, effect);
            if (pushed)
                effect.Apply(this);
        }

        public void RemoveEffect(Effect effect) {
            RemoveResult result = Utils.RemoveSingle<Effect>(ref effects, effect);
            if (result == RemoveResult.NOT_FOUND) return;
            if (result == RemoveResult.REMOVED_AND_GONE)
                effect.Unapply(this);
        }

        public bool HasEffect(Effect type) {
            return Array.IndexOf(effects, type) >= 0;
        }
        public bool IsImmune(DamageType type) {
            return HasEffect(srd5.Effects.Immunity(type));
        }

        public bool IsResistant(DamageType type) {
            return HasEffect(srd5.Effects.Resistance(type));
        }

        public bool IsVulnerable(DamageType type) {
            return HasEffect(srd5.Effects.Vulnerability(type));
        }

        public void TakeDamage(DamageType type, int amount) {
            if (IsImmune(type)) return;
            if (IsResistant(type)) amount /= 2;
            if (IsVulnerable(type)) amount *= 2;
            HitPoints -= amount;
        }
    }
}
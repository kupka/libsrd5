using System;

namespace srd5 {
    public delegate void AttackEffect(Combattant attacker, Combattant target);

    public class Attack {
        public enum Property {
            TRIPLE_DICE_ON_CRIT
        }

        public string Name { get; set; }
        public int AttackBonus { get; internal set; }
        public Damage Damage { get; internal set; }
        public Damage AdditionalDamage { get; internal set; }
        public int Reach { get; internal set; }
        public int RangeNormal { get; internal set; }
        public int RangeLong { get; internal set; }
        public AttackEffect EffectOnHit { get; internal set; }
        private Attack.Property[] properties = new Attack.Property[0];
        public Attack.Property[] Properties {
            get {
                return properties;
            }
        }
        public Combattant LockedTarget { get; set; }

        public Attack(string name, int attackBonus, Damage damage, int reach, int rangeNormal, int rangeLong, Damage additionalDamage = null, AttackEffect effectOnHit = null) {
            Name = name;
            AttackBonus = attackBonus;
            Damage = damage;
            AdditionalDamage = additionalDamage;
            Reach = reach;
            RangeNormal = rangeNormal;
            RangeLong = rangeLong;
            EffectOnHit = effectOnHit;
        }

        public Attack(string name, int attackBonus, Damage damage, int reach, Damage additionalDamage = null, AttackEffect effectOnHit = null) {
            Name = name;
            AttackBonus = attackBonus;
            Damage = damage;
            AdditionalDamage = additionalDamage;
            Reach = reach;
            RangeNormal = 0;
            RangeLong = 0;
            EffectOnHit = effectOnHit;
        }

        public Attack(string name, int attackBonus, Damage damage, int rangeNormal, int rangeLong, Damage additionalDamage = null, AttackEffect effectOnHit = null) {
            Name = name;
            AttackBonus = attackBonus;
            Damage = damage;
            AdditionalDamage = additionalDamage;
            Reach = 0;
            RangeNormal = rangeNormal;
            RangeLong = rangeLong;
            EffectOnHit = effectOnHit;
        }

        public static Attack FromWeapon(int attackBonus, string damageString, Weapon weapon, Damage additionalDamage = null) {
            return new Attack(weapon.Name, attackBonus,
                new Damage(weapon.Damage.Type, damageString), weapon.Reach, weapon.RangeNormal, weapon.RangeLong, additionalDamage);
        }

        public void ApplyEffectOnHit(Combattant attacker, Combattant target) {
            if (EffectOnHit == null) return;
            EffectOnHit(attacker, target);
        }

        public bool HasProperty(Attack.Property property) {
            return Array.IndexOf(properties, property) >= 0;
        }

        public Attack WithProperties(params Attack.Property[] properties) {
            for (int i = 0; i < properties.Length; i++) {
                Utils.Push<Attack.Property>(ref this.properties, properties[i]);
            }
            return this;
        }
    }
}
using System;

namespace srd5 {
    public delegate bool AttackEffect(Combattant attacker, Combattant target);

    public struct AttackEffects {

        /// <summary>
        /// Lets the attacker grapple a target with DC and other options.
        /// </summary>
        /// <param name="attacker">The grappler</param>
        /// <param name="target">Who is grappled</param>
        /// <param name="dc">DC required to avoid grapple</param>
        /// <param name="maxSize">Maximum Size the attacker can grapple</param>
        /// <param name="withRestrained">With true, the target is restrained as well as grappled</param>
        /// <param name="lockAttackToTarget">If set, then this attack will have the target locked (e.g. can only Bite the grappled target)</param>
        /// <param name="maxTargets">Amount of targets the attacker can grapple (e.g. Crabs can grapple one target with each of their two claws)</param>
        public static bool GrapplingEffect(Combattant attacker, Combattant target, int dc, Size maxSize, bool withRestrained = false, Attack lockAttackToTarget = null, int maxTargets = 1) {
            ConditionType grapplingType = (ConditionType)Enum.Parse(typeof(ConditionType), "GRAPPLED_DC" + dc);
            if (target.HasCondition(grapplingType)) return false;
            if (target.Size > maxSize) return false;
            int grappling = 0;
            foreach (Effect effect in attacker.Effects) {
                if (effect == Effect.GRAPPLING) grappling++;
            }
            if (grappling >= maxTargets) return false;
            if (target.HasEffect(Effect.IMMUNITY_GRAPPLED)) return false;
            attacker.AddEffect(Effect.GRAPPLING);
            if (withRestrained && !target.HasEffect(Effect.IMMUNITY_RESTRAINED))
                target.AddCondition(ConditionType.RESTRAINED);
            target.AddCondition(grapplingType);
            if (lockAttackToTarget != null) {
                foreach (Attack attack in attacker.MeleeAttacks) { // Currently, no ranged attack is locked
                    if (lockAttackToTarget.Name.Equals(attack.Name)) {
                        attack.LockedTarget = target;
                    }
                }
            }
            target.AddEndOfTurnEvent(delegate () {
                if (!target.HasCondition(grapplingType)) {
                    if (withRestrained)
                        target.RemoveCondition(ConditionType.RESTRAINED);
                    attacker.RemoveEffect(Effect.GRAPPLING);
                    return true;
                }
                return false;
            });
            return true;
        }

        /// <summary>
        /// Damages the target by a certain amount, half of the amount when dc is successfull
        /// </summary>
        /// <param name="target">The target to take damage</param>
        /// <param name="type">The type of the damage</param>
        /// <param name="dice">The dice string describing how much damage is taken (e.g. "3d6+3")</param>
        /// <param name="dc">How difficult the DC is to receive only half of the dice' damage</param>
        /// <param name="ability">Which ability is used for the DC (default Constitution)</param>
        /// <param name="dcAvoidsDamage">If true, all damage is avoided instead of halved on successful DC. (default false)</param>
        /// <returns></returns>
        public static int PoisonEffect(Combattant target, Attack source, string dice, int dc, AbilityType ability = AbilityType.CONSTITUTION, bool dcAvoidsDamage = false) {
            if (target.IsImmune(DamageType.POISON)) return 0;
            bool success = target.DC(source, dc, ability);
            if (dcAvoidsDamage && success) return 0;
            int amount = new Dice(dice).Roll();
            if (success) amount /= 2;
            amount = target.TakeDamage(source, DamageType.POISON, amount);
            return amount;
        }
    }

    public class Attack : GuidClass {
        public enum Property {
            TRIPLE_DICE_ON_CRIT
        }

        public int AttackBonus { get; internal set; }
        public Damage Damage { get; internal set; }
        private Damage[] additionalDamages;
        public Damage[] AdditionalDamage {
            get {
                return additionalDamages;
            }
            private set {
                additionalDamages = value;
            }
        }
        public int Reach { get; internal set; }
        public int RangeNormal { get; internal set; }
        public int RangeLong { get; internal set; }
        private AttackEffect[] effectsOnHit;
        public AttackEffect[] EffectOnHit {
            get {
                return effectsOnHit;
            }
            private set {
                effectsOnHit = value;
            }
        }
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
            if (additionalDamage == null) {
                AdditionalDamage = new Damage[0];
            } else {
                AdditionalDamage = new Damage[] { additionalDamage };
            }
            Reach = reach;
            RangeNormal = rangeNormal;
            RangeLong = rangeLong;
            if (effectOnHit == null) {
                EffectOnHit = new AttackEffect[0];
            } else {
                EffectOnHit = new AttackEffect[] { effectOnHit };
            }
        }

        public Attack(string name, int attackBonus, Damage damage, int reach, Damage additionalDamage = null, AttackEffect effectOnHit = null)
            : this(name, attackBonus, damage, reach, 0, 0, additionalDamage, effectOnHit) { }

        public Attack(string name, int attackBonus, Damage damage, int rangeNormal, int rangeLong, Damage additionalDamage = null, AttackEffect effectOnHit = null)
            : this(name, attackBonus, damage, 0, rangeNormal, rangeLong, additionalDamage, effectOnHit) { }

        public static Attack FromWeapon(int attackBonus, string damageString, Weapon weapon, Damage additionalDamage = null) {
            return new Attack(weapon.Name, attackBonus,
                new Damage(weapon.Damage.Type, damageString), weapon.Reach, weapon.RangeNormal, weapon.RangeLong, additionalDamage);
        }

        public void ApplyEffectOnHit(Combattant attacker, Combattant target) {
            AttackEffect[] toRemove = new AttackEffect[0];
            foreach (AttackEffect effect in EffectOnHit) {
                if (effect(attacker, target)) {
                    Utils.Push<AttackEffect>(ref toRemove, effect);
                }
            }
            RemoveAttackEffect(toRemove);
        }

        public bool HasProperty(Attack.Property property) {
            return Array.IndexOf(properties, property) > -1;
        }

        public Attack WithProperties(params Attack.Property[] properties) {
            for (int i = 0; i < properties.Length; i++) {
                Utils.Push<Attack.Property>(ref this.properties, properties[i]);
            }
            return this;
        }

        internal void AddAdditionalDamage(params Damage[] additionalDamage) {
            Utils.Push<Damage>(ref this.additionalDamages, additionalDamage);
        }

        internal void RemoveAdditionalDamage(params Damage[] additionalDamage) {
            foreach (Damage damage in additionalDamage) {
                Utils.RemoveSingle<Damage>(ref this.additionalDamages, damage);
            }
        }

        internal void AddAttackEffect(params AttackEffect[] attackEffects) {
            Utils.Push<AttackEffect>(ref this.effectsOnHit, attackEffects);
        }

        internal void RemoveAttackEffect(params AttackEffect[] attackEffects) {
            foreach (AttackEffect effect in attackEffects) {
                Utils.RemoveSingle<AttackEffect>(ref this.effectsOnHit, effect);
            }
        }
    }
}
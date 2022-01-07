using System;

namespace srd5 {
    public static class GlobalEvents {
        public enum EventTypes {
            INITIATIVE,
            ATTACKED,
            DAMAGED,
            HEALED,
            CONDITION,
            DC,
            SPELL
        }
        public static event EventHandler<EventArgs> Handlers;

        public class InitiativeRolled : EventArgs {
            public Combattant Roller { get; private set; }
            public int Result { get; private set; }

            public InitiativeRolled(Combattant roller, int result) {
                Roller = roller;
                Result = result;
            }
        }

        internal static void RolledInitiative(Combattant combattant, int result) {
            if (Handlers == null) return;
            Handlers(EventTypes.INITIATIVE, new InitiativeRolled(combattant, result));
        }

        public class AttackRolled : EventArgs {
            public Combattant Attacker { get; private set; }
            public Combattant Target { get; private set; }
            public int Roll { get; private set; }
            public bool Hit { get; private set; }
            public bool CriticalHit { get; private set; }

            public AttackRolled(Combattant attacker, Combattant target, int roll, bool hit, bool criticalHit) {
                Attacker = attacker;
                Target = target;
                Roll = roll;
                Hit = hit;
                CriticalHit = criticalHit;
            }
        }

        internal static void RolledAttack(Combattant attacker, Combattant target, int roll, bool hit, bool criticalHit = false) {
            if (Handlers == null) return;
            Handlers(EventTypes.ATTACKED, new AttackRolled(attacker, target, roll, hit, criticalHit));
        }

        public class DamageReceived : EventArgs {
            public Combattant Victim { get; private set; }
            public int Amount { get; private set; }
            public DamageType DamageType { get; private set; }

            public DamageReceived(Combattant victim, int amount, DamageType damageType) {
                Victim = victim;
                Amount = amount;
                DamageType = damageType;
            }
        }

        internal static void ReceivedDamage(Combattant victim, int amount, DamageType damageType) {
            if (Handlers == null) return;
            Handlers(EventTypes.DAMAGED, new DamageReceived(victim, amount, damageType));
        }

        public class HealingReceived : EventArgs {
            public Combattant Beneficiary { get; private set; }
            public int Amount { get; private set; }
            public HealingReceived(Combattant beneficiary, int amount) {
                Beneficiary = beneficiary;
                Amount = amount;
            }
        }

        internal static void ReceivedHealing(Combattant beneficiary, int amount) {
            if (Handlers == null) return;
            Handlers(EventTypes.HEALED, new HealingReceived(beneficiary, amount));
        }

        public class DCRolled : EventArgs {
            public Combattant Roller { get; private set; }
            public Ability Ability { get; private set; }
            public int DC { get; private set; }
            public int Roll { get; private set; }
            public bool Success { get; private set; }

            public DCRolled(Combattant roller, Ability ability, int dc, int roll, bool success) {
                Roller = roller;
                Ability = ability;
                DC = dc;
                Roll = roll;
                Success = success;
            }
        }

        internal static void RolledDC(Combattant roller, Ability ability, int dc, int roll, bool success) {
            if (Handlers == null) return;
            Handlers(EventTypes.DC, new DCRolled(roller, ability, dc, roll, success));
        }

        public class ConditionChanged : EventArgs {
            public Combattant Bearer { get; private set; }
            public ConditionType Condition { get; private set; }
            public bool Removed { get; private set; }

            public ConditionChanged(Combattant bearer, ConditionType condition, bool removed = false) {
                Bearer = bearer;
                Condition = condition;
                Removed = removed;
            }
        }

        internal static void ChangedCondition(Combattant bearer, ConditionType condition, bool removed = false) {
            if (Handlers == null) return;
            Handlers(EventTypes.CONDITION, new ConditionChanged(bearer, condition, removed));
        }

        public class SpellAffection : EventArgs {
            public Combattant Caster { get; private set; }
            public Combattant Target { get; private set; }
            public bool Affected { get; private set; }

            public SpellAffection(Combattant caster, Combattant target, bool affected) {
                Caster = caster;
                Target = target;
                Affected = affected;
            }
        }

        internal static void AffectBySpell(Combattant caster, Combattant target, bool affected) {
            if (Handlers == null) return;
            Handlers(EventTypes.SPELL, new SpellAffection(caster, target, affected));
        }
    }
}
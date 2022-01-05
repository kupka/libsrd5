using System;

namespace srd5 {
    public static class GlobalEvents {
        public enum EventTypes {
            INITIATIVE,
            ATTACKED,
            DAMAGED,
            HEALED
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
    }
}
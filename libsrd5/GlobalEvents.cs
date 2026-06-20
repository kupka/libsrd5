using System;

namespace srd5 {
    public static class GlobalEvents {
        public enum EventTypes {
            ACTION_FAILED,
            INITIATIVE,
            ATTACKED,
            DAMAGED,
            HEALED,
            CONDITION,
            DC,
            AFFECT_BY_SPELL,
            CAST_SPELL,
            EQUIPMENT,
            EFFECT_ACTIVATED,
            DEATH
        }
        public static event EventHandler<EventArgs> Handlers;
        public static event EventHandler<AttackRolled> AttackRolledHandlers;
        public static event EventHandler<SpellCast> SpellCastHandlers;
        public static event EventHandler<SpellAffection> SpellAffectionHandlers;

        public class InitiativeRolled : EventArgs {
            public Combatant Roller { get; private set; }
            public int Result { get; private set; }

            public InitiativeRolled(Combatant roller, int result) {
                Roller = roller;
                Result = result;
            }
        }

        internal static void RolledInitiative(Combatant combatant, int result) {
            if (Handlers == null) return;
            Handlers(EventTypes.INITIATIVE, new InitiativeRolled(combatant, result));
        }

        public class AttackRolled : EventArgs {
            public Combatant Attacker { get; private set; }
            public Attack Attack { get; private set; }
            public Combatant Target { get; private set; }
            public int Roll { get; private set; }
            public bool Hit { get; private set; }
            public bool CriticalHit { get; private set; }

            public AttackRolled(Combatant attacker, Attack attack, Combatant target, int roll, bool hit, bool criticalHit) {
                Attacker = attacker;
                Attack = attack;
                Target = target;
                Roll = roll;
                Hit = hit;
                CriticalHit = criticalHit;
            }
        }

        internal static void RolledAttack(Combatant attacker, Attack attack, Combatant target, int roll, bool hit, bool criticalHit = false) {
            if (Handlers != null)
                Handlers(EventTypes.ATTACKED, new AttackRolled(attacker, attack, target, roll, hit, criticalHit));
            if (AttackRolledHandlers != null)
                AttackRolledHandlers(EventTypes.ATTACKED, new AttackRolled(attacker, attack, target, roll, hit, criticalHit));
        }

        public class DamageReceived : EventArgs {
            public Combatant Victim { get; private set; }
            public int Amount { get; private set; }
            public DamageType DamageType { get; private set; }

            public DamageReceived(Combatant victim, int amount, DamageType damageType) {
                Victim = victim;
                Amount = amount;
                DamageType = damageType;
            }
        }

        internal static void ReceivedDamage(Combatant victim, int amount, DamageType damageType) {
            if (Handlers == null) return;
            Handlers(EventTypes.DAMAGED, new DamageReceived(victim, amount, damageType));
        }

        public class HealingReceived : EventArgs {
            public Combatant Beneficiary { get; private set; }
            public int Amount { get; private set; }
            public HealingReceived(Combatant beneficiary, int amount) {
                Beneficiary = beneficiary;
                Amount = amount;
            }
        }

        internal static void ReceivedHealing(Combatant beneficiary, int amount) {
            if (Handlers == null) return;
            Handlers(EventTypes.HEALED, new HealingReceived(beneficiary, amount));
        }

        public class DCRolled : EventArgs {
            public Combatant Roller { get; private set; }
            public object Source { get; private set; }
            public Ability Ability { get; private set; }
            public int DC { get; private set; }
            public int Roll { get; private set; }
            public bool Success { get; private set; }

            public DCRolled(Combatant roller, object source, Ability ability, int dc, int roll, bool success) {
                Roller = roller;
                Source = source;
                Ability = ability;
                DC = dc;
                Roll = roll;
                Success = success;
            }
        }

        internal static void RolledDC(Combatant roller, object source, Ability ability, int dc, int roll, bool success) {
            if (Handlers == null) return;
            Handlers(EventTypes.DC, new DCRolled(roller, source, ability, dc, roll, success));
        }

        public class ConditionChanged : EventArgs {
            public Combatant Bearer { get; private set; }
            public ConditionType Condition { get; private set; }
            public bool Removed { get; private set; }

            public ConditionChanged(Combatant bearer, ConditionType condition, bool removed = false) {
                Bearer = bearer;
                Condition = condition;
                Removed = removed;
            }
        }

        internal static void ChangedCondition(Combatant bearer, ConditionType condition, bool removed = false) {
            if (Handlers == null) return;
            Handlers(EventTypes.CONDITION, new ConditionChanged(bearer, condition, removed));
        }

        public class SpellAffection : EventArgs {
            public Combatant Caster { get; private set; }
            public Spells.ID Spell { get; private set; }
            public Combatant Target { get; private set; }
            public bool Affected { get; private set; }

            public SpellAffection(Combatant caster, Spells.ID spell, Combatant target, bool affected) {
                Caster = caster;
                Spell = spell;
                Target = target;
                Affected = affected;
            }
        }

        internal static void AffectBySpell(Combatant caster, Spells.ID spell, Combatant target, bool affected) {
            if (Handlers != null)
                Handlers(EventTypes.AFFECT_BY_SPELL, new SpellAffection(caster, spell, target, affected));
            if (SpellAffectionHandlers != null)
                SpellAffectionHandlers(EventTypes.AFFECT_BY_SPELL, new SpellAffection(caster, spell, target, affected));
        }

        public class ActionFailed : EventArgs {
            public enum Reasons {
                CANNOT_TAKE_ACTIONS,
                WRONG_PHASE,
                TARGET_OUT_OF_RANGE,
                WRONG_NUMBER_OF_TARGETS,
                SPELL_NOT_KNOWN,
                SPELL_NOT_PREPARED,
                SPELLSLOT_EMPTY,
                SPELLSLOT_INVALID,
                INSUFFICIENT_USES,
                INVALID_TARGET

            }
            public Combatant Initiator { get; private set; }
            public Reasons Reason { get; private set; }

            public ActionFailed(Combatant initiator, Reasons reason) {
                Initiator = initiator;
                Reason = reason;
            }
        }

        internal static void FailAction(Combatant initiator, ActionFailed.Reasons reason) {
            if (Handlers == null) return;
            Handlers(EventTypes.ACTION_FAILED, new ActionFailed(initiator, reason));
        }

        public class EquipmentChanged : EventArgs {
            public enum Events {
                EQUIPPED,
                UNEQUIPPED,
                DESTROYED,
                USED,
                PUT_IN_BAG,
                REMOVED_FROM_BAG
            }

            public CharacterSheet Hero { get; private set; }
            public Item Item { get; private set; }
            public Events Event { get; private set; }

            public EquipmentChanged(CharacterSheet hero, Item item, Events evnt) {
                Hero = hero;
                Item = item;
                Event = evnt;
            }
        }

        public static void ChangeEquipment(CharacterSheet hero, Item item, EquipmentChanged.Events evnt) {
            if (Handlers == null) return;
            Handlers(EventTypes.EQUIPMENT, new EquipmentChanged(hero, item, evnt));
        }

        public class EffectActivated : EventArgs {
            public Combatant Source { get; private set; }
            public Effect Effect { get; private set; }

            public EffectActivated(Combatant source, Effect effect) {
                Source = source;
                Effect = effect;
            }
        }

        public static void ActivateEffect(Combatant source, Effect effect) {
            if (Handlers == null) return;
            Handlers(EventTypes.EFFECT_ACTIVATED, new EffectActivated(source, effect));
        }

        public class FeatActivated : EventArgs {
            public Combatant Source { get; private set; }
            public Feat Feat { get; private set; }

            public FeatActivated(Combatant source, Feat feat) {
                Source = source;
                Feat = feat;
            }
        }

        public static void ActivateFeat(Combatant source, Feat feat) {
            if (Handlers == null) return;
            Handlers(EventTypes.EFFECT_ACTIVATED, new FeatActivated(source, feat));
        }

        public class SpellCast : EventArgs {
            public Combatant Caster { get; private set; }
            public Spells.ID Spell { get; private set; }

            public SpellCast(Combatant caster, Spells.ID spell) {
                Caster = caster;
                Spell = spell;
            }
        }

        public static void CastSpell(Combatant caster, Spells.ID spell) {
            if (Handlers != null)
                Handlers(EventTypes.CAST_SPELL, new SpellCast(caster, spell));
            if (SpellCastHandlers != null)
                SpellCastHandlers(EventTypes.CAST_SPELL, new SpellCast(caster, spell));
        }

        public class Death : EventArgs {
            public Combatant Victim { get; private set; }

            public Death(Combatant victim) {
                Victim = victim;
            }
        }

        public static void Die(Combatant victim) {
            if (Handlers == null) return;
            Handlers(EventTypes.DEATH, new Death(victim));
        }
    }
}
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

    public class AvailableSpells {
        public CharacterClass CharacterClass { get; internal set; }
        public Spell[] KnownSpells {
            get {
                return knownSpells;
            }
        }
        private Spell[] knownSpells = new Spell[0];
        public Spell[] PreparedSpells {
            get {
                return preparedSpells;
            }
        }
        private Spell[] preparedSpells = new Spell[0];
        public Spell[] BonusPreparedSpells { get; internal set; } = new Spell[0];
        public int[] SlotsMax { get; internal set; } = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public int[] SlotsCurrent { get; internal set; } = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public AvailableSpells(AbilityType abilityType) {
            CharacterClass clazz = new CharacterClass();
            clazz.SpellCastingAbility = abilityType;
            clazz.MustPrepareSpells = false;
            CharacterClass = clazz;
        }
        public AvailableSpells(CharacterClass clazz) {
            CharacterClass = clazz;
        }

        public void AddKnownSpell(params Spell[] spells) {
            Utils.Push<Spell>(ref knownSpells, spells);
        }

        public void AddPreparedSpell(params Spell[] spells) {
            foreach (Spell spell in spells)
                if (Array.IndexOf(knownSpells, spell) == -1) return;
            Utils.Push<Spell>(ref preparedSpells, spells);
        }

        /// <summary>
        /// Calculates the spell cast DC for the sheet. Assumes that this object belongs to this sheet.
        /// </summary>
        public int GetSpellCastDC(CharacterSheet sheet) {
            int dc = 8;
            dc += sheet.GetAbility(CharacterClass.SpellCastingAbility).Modifier;
            dc += sheet.Proficiency;
            return dc;
        }

        /// <summary>
        /// Calculates the spell cast DC for the Monster. Assumes that this object belongs to this Monster.
        /// </summary>
        public int GetSpellCastDC(Combattant combattant) {
            if (combattant is CharacterSheet) return GetSpellCastDC((CharacterSheet)combattant);
            Monster monster = (Monster)combattant;
            return monster.SpellCastDC;
        }

        /// <summary>
        /// Get the spellcasting modifier for the Combattant. Assumes that this object belongs to this sheet.
        /// <summary>
        public int GetSpellcastingModifier(Combattant combattant) {
            AbilityType spellAbility = CharacterClass.SpellCastingAbility;
            return combattant.GetAbility(spellAbility).Modifier;
        }

    }

    public abstract class Combattant {
        public int Speed { get; internal set; } = 30;
        public string Name { get; set; }
        public Ability Strength { get; internal set; } = new Ability(AbilityType.STRENGTH, 10);
        public Ability Dexterity { get; internal set; } = new Ability(AbilityType.DEXTERITY, 10);
        public Ability Constitution { get; internal set; } = new Ability(AbilityType.CONSTITUTION, 10);
        public Ability Intelligence { get; internal set; } = new Ability(AbilityType.INTELLIGENCE, 10);
        public Ability Wisdom { get; internal set; } = new Ability(AbilityType.WISDOM, 10);
        public Ability Charisma { get; internal set; } = new Ability(AbilityType.CHARISMA, 10);
        public virtual int ArmorClass { get; internal set; }
        public int ArmorClassModifier { get; internal set; }
        public int HitPoints { get; set; }
        public virtual int HitPointsMax { get; internal set; }
        public Attack[] MeleeAttacks { get; internal set; } = new Attack[0];
        public Attack[] RangedAttacks { get; internal set; } = new Attack[0];
        public Attack BonusAttack { get; internal set; }
        public Size Size { get; internal set; }
        public Effect[] Effects { get { return effects; } }
        private Effect[] effects = new Effect[0];
        public ConditionType[] Conditions { get { return conditions; } }
        private ConditionType[] conditions = new ConditionType[0];
        public int EffectiveLevel { get; protected set; }
        public AvailableSpells[] AvailableSpells {
            get {
                return availableSpells;
            }
        }
        private AvailableSpells[] availableSpells = new AvailableSpells[0];

        public void AddEffect(Effect effect) {
            bool pushed = Utils.PushUnique<Effect>(ref effects, effect);
            if (pushed)
                effect.Apply(this);
        }

        public void AddEffects(params Effect[] effects) {
            foreach (Effect effect in effects) {
                AddEffect(effect);
            }
        }

        public void RemoveEffect(Effect effect) {
            RemoveResult result = Utils.RemoveSingle<Effect>(ref effects, effect);
            if (result == RemoveResult.NOT_FOUND) return;
            if (result == RemoveResult.REMOVED_AND_GONE)
                effect.Unapply(this);
        }

        public bool AddCondition(ConditionType condition) {
            // don't add if immune
            if (HasEffect(srd5.Effects.Immunity(condition))) return false;
            if (Utils.PushUnique<ConditionType>(ref conditions, condition))
                condition.Apply(this);
            return true;
        }
        public void RemoveCondition(ConditionType condition) {
            RemoveResult result = Utils.RemoveSingle<ConditionType>(ref conditions, condition);
            if (result == RemoveResult.REMOVED_AND_GONE)
                condition.Unapply(this);
        }

        public bool HasCondition(ConditionType condition) {
            return Array.IndexOf(conditions, condition) >= 0;
        }

        internal void AddAvailableSpells(AvailableSpells spells) {
            Utils.Push<AvailableSpells>(ref availableSpells, spells);
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

        /// <summary>
        /// Apply the correct amount of damage of the given type to this Combattant, taking immunities, resistances and vulnerabilities into account.
        /// </summary>
        public void TakeDamage(Damage damage, bool critical = false) {
            int amount = critical ? damage.Dices.RollCritical() : damage.Dices.Roll();
            DamageType type = damage.Type;
            if (IsImmune(type)) return;
            if (IsResistant(type)) amount /= 2;
            if (IsVulnerable(type)) amount *= 2;
            GlobalEvents.ReceivedDamage(this, amount, damage.Type);
            HitPoints -= amount;
            if (HitPoints <= 0) AddCondition(ConditionType.UNCONSCIOUS);
        }

        /// <summary>
        /// Heals the specified amount of damage. The healed hitpoints cannot exceed the maximum hitpoints of this combattant.
        /// </summary>
        public void HealDamage(int amount) {
            GlobalEvents.ReceivedHealing(this, amount);
            HitPoints = Math.Min(HitPoints + amount, HitPointsMax);
        }

        /// <summary>
        /// Retrieves the Ability value by AbilityType.
        /// </summary>
        public Ability GetAbility(AbilityType type) {
            switch (type) {
                case AbilityType.STRENGTH:
                    return Strength;
                case AbilityType.CONSTITUTION:
                    return Constitution;
                case AbilityType.DEXTERITY:
                    return Dexterity;
                case AbilityType.INTELLIGENCE:
                    return Intelligence;
                case AbilityType.WISDOM:
                    return Wisdom;
                case AbilityType.CHARISMA:
                    return Charisma;
                default:
                    throw new ArgumentException("No value for this AbilityType");
            }
        }

        /// <summary>
        /// Roll a DC (difficulty check) against the specified Ability
        /// </summary>
        public bool DC(int dc, AbilityType type, bool advantage = false, bool disadvantage = false) {
            if (type == AbilityType.STRENGTH && HasEffect(Effect.FAIL_STRENGTH_CHECK)) return false;
            if (type == AbilityType.DEXTERITY && HasEffect(Effect.FAIL_DEXERITY_CHECK)) return false;
            return Dices.DC(dc, GetAbility(type), advantage, disadvantage);
        }


        private EndOfTurnEvent[] endOfTurnEvents = new EndOfTurnEvent[0];

        /// <summary>
        /// Adds a piece of code to be evaluated at the end of this combattatant's turn
        /// </summary>
        public void AddEndOfTurnEvent(EndOfTurnEvent endOfTurnEvent) {
            Utils.Push<EndOfTurnEvent>(ref endOfTurnEvents, endOfTurnEvent);
        }

        public void OnEndOfTurn() {
            for (int i = 0; i < endOfTurnEvents.Length; i++) {
                if (endOfTurnEvents[i] == null) continue;
                if (endOfTurnEvents[i](this)) {
                    endOfTurnEvents[i] = null;
                }
            }
        }

    }

    /// <summary>
    /// Describes an event that shall be executed at the end of this combattant's turn. 
    /// The event is considered finished when the delegate returns true.
    /// </summary>
    public delegate bool EndOfTurnEvent(Combattant combattant);
}
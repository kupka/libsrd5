using System;
using static srd5.Effect;

namespace srd5 {
    public class Spell : GuidClass {
        public Spells.ID ID { get; private set; }
        public SpellSchool School { get; private set; }
        public SpellLevel Level { get; private set; }
        public CastingTime CastingTime { get; private set; }
        public int Range { get; private set; }
        public SpellComponent[] Components { get; private set; }
        public SpellDuration Duration { get; private set; }
        public int AreaOfEffect { get; private set; }
        public int MaximumTargets { get; private set; }
        public override string Name {
            get {
                return ID.Name();
            }
        }
        public SpellVariant[] Variants {
            get;
            internal set;
        }

        private SpellVariant variant = SpellVariant.NONE;
        public SpellVariant Variant {
            get {
                return variant;
            }
            set {
                if (Array.IndexOf(Variants, value) > -1) {
                    variant = value;
                }
            }
        }
        internal SpellCastEffect CastEffect {
            get;
            set;
        }

        public Spell(Spells.ID id, SpellSchool school, SpellLevel level, CastingTime castingTime,
                     int range, SpellComponent[] components, SpellDuration duration,
                     int areaOfEffect, int maximumTargets, SpellCastEffect castEffect = null) {
            ID = id;
            School = school;
            Level = level;
            CastingTime = castingTime;
            Range = range;
            Components = components;
            Duration = duration;
            AreaOfEffect = areaOfEffect;
            MaximumTargets = maximumTargets;
            CastEffect = castEffect;
            Variants = new SpellVariant[0];
        }

        /* Cast a Spell that doesn't require a battleground, because it does not target
           anyone other or only the caster */
        public void Cast(Combatant caster, int dc, SpellLevel slot, int modifier) {
            CastEffect(null, caster, dc, slot, modifier, caster);
        }

        /* Cast a spell on one or more targets */
        public void Cast(Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, params Combatant[] targets) {
            if (targets.Length < 1) throw new Srd5ArgumentException("targets must contain at least one element");
            GlobalEvents.CastSpell(caster, ID);
            Combatant[] targetable = filterUntargetable(caster, targets);
            if (targetable.Length < 1) return;
            CastEffect(ground, caster, dc, slot, modifier, targetable);
        }

        public override bool Equals(object obj) {
            if (!(obj is Spell)) return false;
            return obj.GetHashCode() == this.GetHashCode();
        }

        /// <summary>
        /// Removes targets shielded from this spell (e.g. Resilient Sphere blocks every spell except Disintegrate),
        /// reporting a miss for each one removed. Centralized here so individual spells don't need to duplicate the check.
        /// </summary>
        private Combatant[] filterUntargetable(Combatant caster, Combatant[] targets) {
            Combatant[] targetable = new Combatant[0];
            foreach (Combatant target in targets) {
                if (target.HasEffect(SPELL_RESILIENT_SPHERE) && ID != Spells.ID.DISINTEGRATE && !caster.Equals(target)) {
                    GlobalEvents.AffectBySpell(caster, ID, target, false);
                    continue;
                }
                Utils.Push<Combatant>(ref targetable, target);
            }
            return targetable;
        }

        public override int GetHashCode() {
            return (int)ID;
        }
    }
}
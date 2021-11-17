using System;

namespace srd5 {
    public enum SpellSchool {
        ABJURATION,
        CONJURATION,
        DIVINATION,
        ENCHANTMENT,
        EVOCATION,
        ILLUSION,
        NECROMANCY,
        TRANSMUTATION
    }

    public enum SpellLevel {
        CANTRIP = 0,
        FIRST = 1,
        SECOND = 2,
        THIRD = 3,
        FOURTH = 4,
        FIFTH = 5,
        SIXTH = 6,
        SEVENTH = 7,
        EIGHTH = 8,
        NINETH = 9
    }

    public enum CastingTime {
        ONE_ACTION,
        ONE_ROUND,
        ONE_MINUTE,
        ONE_HOUR
    }

    public enum SpellComponent {
        VERBAL,
        SOMATIC,
        MATERIAL
    }

    public enum SpellDuration {
        INSTANTANEOUS,
        CONCENTRATION_ONE_MINUTE,
        CONCENTRATION_ONE_HOUR,
        CONCENTRATION_ONE_DAY
    }

    public delegate void SpellCastEffect(Combattant caster, int dc, SpellLevel slot, params Combattant[] targets);

    public struct Spells {
        public enum ID {
            DEFAULT,
            ACID_SPLASH,
            CURE_WOUNDS,
            MAGIC_MISSILE,
        }

        public static readonly Spell AcidSplash = new Spell(
            ID.ACID_SPLASH, SpellSchool.CONJURATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 60, new SpellComponent[] { SpellComponent.VERBAL, SpellComponent.SOMATIC },
            SpellDuration.INSTANTANEOUS, 5, 2, delegate (Combattant caster, int dc, SpellLevel slot, Combattant[] targets) {
                Damage damage;
                if (caster.EffectiveLevel > 16)
                    damage = new Damage(DamageType.ACID, "4d6");
                else if (caster.EffectiveLevel > 10)
                    damage = new Damage(DamageType.ACID, "3d6");
                else if (caster.EffectiveLevel > 4)
                    damage = new Damage(DamageType.ACID, "2d6");
                else
                    damage = new Damage(DamageType.ACID, "1d6");
                foreach (Combattant target in targets) {
                    if (!Dices.DC(dc, target.Dexterity))
                        target.TakeDamage(damage);
                }
            }
        );

        public static readonly Spell MagicMissile = new Spell(
            ID.ACID_SPLASH, SpellSchool.EVOCATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 120, new SpellComponent[] { SpellComponent.VERBAL, SpellComponent.SOMATIC },
            SpellDuration.INSTANTANEOUS, 0, 20, delegate (Combattant caster, int dc, SpellLevel slot, Combattant[] targets) {
                Damage damage = new Damage(DamageType.FORCE, "1d4+1");
                int missiles = (int)slot + 2;
                for (int i = 0; i < missiles; i++) {
                    Combattant target = targets[i % targets.Length];
                    target.TakeDamage(damage);
                }
            }
        );

        public static readonly Spell CureWounds = new Spell(
            ID.CURE_WOUNDS, SpellSchool.EVOCATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 5, new SpellComponent[] { SpellComponent.VERBAL, SpellComponent.SOMATIC },
            SpellDuration.INSTANTANEOUS, 0, 1, delegate (Combattant caster, int dc, SpellLevel slot, Combattant[] targets) {
                int dices = (int)slot;
                Dices healed = new Dices(dices + "d8");
                targets[0].HealDamage(healed.Roll());
            }
        );
    };
}
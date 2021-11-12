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

    public delegate void SpellCastEffect(Combattant caster, SpellLevel slot, params Combattant[] targets);

    public struct Spells {
        public static readonly Spell AcidSplash = new Spell(
            "Acid Splash", SpellSchool.CONJURATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 60, new SpellComponent[] { SpellComponent.VERBAL, SpellComponent.SOMATIC },
            SpellDuration.INSTANTANEOUS, 5, 2, delegate (Combattant caster, SpellLevel slot, Combattant[] targets) {
                Damage damage = new Damage(DamageType.FORCE, "1d6");
                if (caster.EffectiveLevel() > 16)
                    damage = new Damage(DamageType.FORCE, "4d6");
                else if (caster.EffectiveLevel() > 10)
                    damage = new Damage(DamageType.FORCE, "3d6");
                else if (caster.EffectiveLevel() > 4)
                    damage = new Damage(DamageType.FORCE, "2d6");
                foreach (Combattant target in targets) {
                    target.TakeDamage(damage.Type, damage.Dices.Roll());
                }
            });
    };
}
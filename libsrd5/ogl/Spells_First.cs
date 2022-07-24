using System;

namespace srd5 {
    public partial struct Spells {
        public static readonly Spell CharmPerson = new Spell(
            ID.CHARM_PERSON, SpellSchool.ENCHANTMENT, SpellLevel.FIRST, CastingTime.ONE_ACTION, 30, VS,
            SpellDuration.ONE_HOUR, 0, 20, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                // one target per slot
                for (int i = 0; i < (int)slot && i < targets.Length; i++) {
                    Combattant target = targets[i];
                    // only affect humanoid monsters
                    if (target is Monster) {
                        Monster monster = (Monster)target;
                        if (monster.Type != MonsterType.HUMANOID) {
                            GlobalEvents.AffectBySpell(caster, ID.CHARM_PERSON, monster, false);
                            continue;
                        }
                    }
                    // Wisdom save with advantage since we assume a fight
                    if (!target.DC(dc, AbilityType.WISDOM, true)) {
                        GlobalEvents.AffectBySpell(caster, ID.CHARM_PERSON, target, true);
                        target.AddCondition(ConditionType.CHARMED);
                    } else {
                        GlobalEvents.AffectBySpell(caster, ID.CHARM_PERSON, target, false);
                    }
                }
            }
        );

        public static readonly Spell CreateOrDestroyWater = new Spell(
            ID.CREATE_OR_DESTROY_WATER, SpellSchool.TRANSMUTATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 30, VS,
            SpellDuration.INSTANTANEOUS, 0, 0, doNothing
        );

        public static readonly Spell CureWounds = new Spell(
            ID.CURE_WOUNDS, SpellSchool.EVOCATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 5, VS,
            SpellDuration.INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                if (targets[0] is Monster) {
                    Monster monster = (Monster)targets[0];
                    if (monster.Type == MonsterType.CONSTRUCT || monster.Type == MonsterType.UNDEAD) {
                        GlobalEvents.AffectBySpell(caster, ID.CURE_WOUNDS, monster, false);
                        return;
                    }
                }
                int dices = (int)slot;
                GlobalEvents.AffectBySpell(caster, ID.CURE_WOUNDS, targets[0], true);
                Dices healed = new Dices(dices, 8, modifier);
                targets[0].HealDamage(healed.Roll());
            }
        );

        public static readonly Spell DetectMagic = new Spell(
            ID.DETECT_MAGIC, SpellSchool.DIVINATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 0, VS,
            SpellDuration.TEN_MINUTES, 30, 0, doNothing
        );

        public static readonly Spell DetectPoisonAndDisease = new Spell(
            ID.DETECT_POISON_AND_DISEASE, SpellSchool.DIVINATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 0, VSM,
            SpellDuration.TEN_MINUTES, 30, 0, doNothing
        );

        public static readonly Spell Entangle = new Spell(
            ID.ENTANGLE, SpellSchool.CONJURATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 90, VS,
            SpellDuration.ONE_MINUTE, 20, 20, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                foreach (Combattant target in targets) {
                    if (target.DC(dc, AbilityType.STRENGTH)) {
                        GlobalEvents.AffectBySpell(caster, ID.ENTANGLE, target, false);
                    } else {
                        GlobalEvents.AffectBySpell(caster, ID.ENTANGLE, target, true);
                        target.AddEffect(Effect.ENTANGLE);
                        int rounds = 10;
                        target.AddEndOfTurnEvent(delegate (Combattant combattant) {
                            rounds--;
                            bool done = rounds <= 0;
                            if (done)
                                combattant.RemoveEffect(Effect.ENTANGLE);
                            return done;
                        });
                    }
                }
            }
        );

        public static readonly Spell FairieFire = new Spell(
            ID.FAIRIE_FIRE, SpellSchool.EVOCATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 60, V,
            SpellDuration.ONE_MINUTE, 20, 20, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                foreach (Combattant target in targets) {
                    if (target.DC(dc, AbilityType.DEXTERITY)) {
                        GlobalEvents.AffectBySpell(caster, ID.FAIRIE_FIRE, target, false);
                    } else {
                        GlobalEvents.AffectBySpell(caster, ID.FAIRIE_FIRE, target, true);
                        target.AddEffect(Effect.FAIRIE_FIRE);
                        int rounds = 10;
                        target.AddEndOfTurnEvent(delegate (Combattant combattant) {
                            rounds--;
                            bool done = rounds <= 0;
                            if (done)
                                combattant.RemoveEffect(Effect.FAIRIE_FIRE);
                            return done;
                        });
                    }
                }
            }
        );

        public static readonly Spell FogCloud = new Spell(
            ID.FOG_CLOUD, SpellSchool.CONJURATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 120, VS,
            SpellDuration.ONE_HOUR, 20, 0, doNothing
        );

        public static readonly Spell HealingWord = new Spell(
            ID.HEALING_WORD, SpellSchool.EVOCATION, SpellLevel.FIRST, CastingTime.BONUS_ACTION, 60, V,
            SpellDuration.INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                if (targets[0] is Monster) {
                    Monster monster = (Monster)targets[0];
                    if (monster.Type == MonsterType.CONSTRUCT || monster.Type == MonsterType.UNDEAD) {
                        GlobalEvents.AffectBySpell(caster, ID.HEALING_WORD, monster, false);
                        return;
                    };
                }
                int dices = (int)slot;
                Dices healed = new Dices(dices, 4, modifier);
                GlobalEvents.AffectBySpell(caster, ID.HEALING_WORD, targets[0], true);
                targets[0].HealDamage(healed.Roll());
            }
        );

        public static readonly Spell Jump = new Spell(
            ID.JUMP, SpellSchool.TRANSMUTATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 0, VSM,
            SpellDuration.ONE_MINUTE, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                Combattant target = targets[0];
                GlobalEvents.AffectBySpell(caster, ID.JUMP, target, true);
                target.AddEffect(Effect.JUMP);
            }
        );

        public static readonly Spell Longstrider = new Spell(
            ID.LONGSTRIDER, SpellSchool.TRANSMUTATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 0, VSM,
            SpellDuration.ONE_HOUR, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                Combattant target = targets[0];
                GlobalEvents.AffectBySpell(caster, ID.LONGSTRIDER, target, true);
                target.AddEffect(Effect.LONGSTRIDER);
            }
        );


        public static readonly Spell MagicMissile = new Spell(
            ID.MAGIC_MISSILE, SpellSchool.EVOCATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 120, VS,
            SpellDuration.INSTANTANEOUS, 0, 20, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                Damage damage = new Damage(DamageType.FORCE, "1d4+1");
                int missilesTotal = (int)slot + 2;
                foreach (Combattant target in targets) {
                    GlobalEvents.AffectBySpell(caster, ID.MAGIC_MISSILE, target, true);
                    int bonusMissiles = missilesTotal % targets.Length;
                    bonusMissiles = Math.Min(1, bonusMissiles);
                    missilesTotal -= bonusMissiles;
                    for (int m = 0; m < missilesTotal / targets.Length + bonusMissiles; m++) {
                        target.TakeDamage(damage.Type, damage.Dices.Roll());
                    }
                }
            }
        );

        public static readonly Spell PurifyFoodAndDrink = new Spell(
            ID.PURIFY_FOOD_AND_DRINK, SpellSchool.TRANSMUTATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 10, VS,
            SpellDuration.INSTANTANEOUS, 5, 0, doNothing
        );

        public static readonly Spell SpeakWithAnimals = new Spell(
            ID.SPEAK_WITH_ANIMALS, SpellSchool.DIVINATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 0, VS,
            SpellDuration.TEN_MINUTES, 0, 0, doNothing
        );

        public static readonly Spell Thunderwave = new Spell(
            ID.THUNDERWAVE, SpellSchool.EVOCATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 15, VS,
            SpellDuration.INSTANTANEOUS, 15, 20, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                int dices = (int)slot + 1;
                bool pushed = true;
                foreach (Combattant target in targets) {
                    GlobalEvents.AffectBySpell(caster, ID.THUNDERWAVE, target, true);
                    if (target.DC(dc, AbilityType.CONSTITUTION)) {
                        dices = (int)(dices / 2);
                        pushed = false;
                    }
                    Damage damage = new Damage(DamageType.THUNDER, dices + "d8");
                    target.TakeDamage(damage.Type, damage.Dices.Roll());
                    if (pushed) {
                        ground.Push(ground.LocateCombattant(caster), target, 10);
                    }
                }
            }
        );
    }
}
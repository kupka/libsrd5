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
        BONUS_ACTION,
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
        INSTANTANEOUS = 0,
        CONCENTRATION_ONE_MINUTE = 1,
        CONCENTRATION_TEN_MINUTES = 10,
        CONCENTRATION_ONE_HOUR = 60,
        CONCENTRATION_ONE_DAY = 1440
    }

    public delegate void SpellCastEffect(Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, params Combattant[] targets);

    public struct Spells {
        private static SpellCastEffect doNothing = delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) { };

        private static SpellComponent[] V {
            get {
                return new SpellComponent[] { SpellComponent.VERBAL };
            }
        }

        private static SpellComponent[] VS {
            get {
                return new SpellComponent[] { SpellComponent.VERBAL, SpellComponent.SOMATIC };
            }
        }

        private static SpellComponent[] VSM {
            get {
                return new SpellComponent[] { SpellComponent.VERBAL, SpellComponent.SOMATIC, SpellComponent.MATERIAL };
            }
        }

        public enum ID {
            DEFAULT,
            ACID_SPLASH,
            CHARM_PERSON,
            CREATE_OR_DESTROY_WATER,
            CURE_WOUNDS,
            DETECT_MAGIC,
            DETECT_POISON_AND_DISEASE,
            ENTANGLE,
            FAIRIE_FIRE,
            FOG_CLOUD,
            GUIDANCE,
            HEALING_WORD,
            HOLD_PERSON,
            JUMP,
            LONGSTRIDER,
            MAGIC_MISSILE,
            MENDING,
            PRODUCE_FLAME,
            PURIFY_FOOD_AND_DRINK,
            RESISTANCE,
            SHILLELAGH,
            SPEAK_WITH_ANIMALS,
            THUNDERWAVE
        }

        public static readonly Spell AcidSplash = new Spell(
            ID.ACID_SPLASH, SpellSchool.CONJURATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 60, VS,
            SpellDuration.INSTANTANEOUS, 5, 2, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifer, Combattant[] targets) {
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
                    int amount = damage.Dices.Roll();
                    if (!target.DC(dc, AbilityType.DEXTERITY)) {
                        GlobalEvents.AffectBySpell(caster, ID.ACID_SPLASH, target, true);
                        target.TakeDamage(damage.Type, amount);
                    } else {
                        GlobalEvents.AffectBySpell(caster, ID.ACID_SPLASH, target, false);
                    }
                }
            }
        );

        public static readonly Spell CharmPerson = new Spell(
            ID.CHARM_PERSON, SpellSchool.ENCHANTMENT, SpellLevel.FIRST, CastingTime.ONE_ACTION, 30, VS,
            SpellDuration.CONCENTRATION_ONE_HOUR, 0, 20, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                // one target per slot
                for (int i = 0; i < (int)slot; i++) {
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
            SpellDuration.CONCENTRATION_TEN_MINUTES, 30, 0, doNothing
        );

        public static readonly Spell DetectPoisonAndDisease = new Spell(
            ID.DETECT_POISON_AND_DISEASE, SpellSchool.DIVINATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 0, VSM,
            SpellDuration.CONCENTRATION_TEN_MINUTES, 30, 0, doNothing
        );

        public static readonly Spell Entangle = new Spell(
            ID.ENTANGLE, SpellSchool.CONJURATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 90, VS,
            SpellDuration.CONCENTRATION_ONE_MINUTE, 20, 20, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
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
            SpellDuration.CONCENTRATION_ONE_MINUTE, 20, 20, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
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
            SpellDuration.CONCENTRATION_ONE_HOUR, 20, 0, doNothing
        );

        public static readonly Spell Guidance = new Spell(
            ID.GUIDANCE, SpellSchool.DIVINATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 0, VS,
            SpellDuration.CONCENTRATION_ONE_MINUTE, 0, 1, doNothing
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

        public static readonly Spell HoldPerson = new Spell(
            ID.HOLD_PERSON, SpellSchool.ENCHANTMENT, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, VSM,
            SpellDuration.CONCENTRATION_ONE_MINUTE, 0, 20, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                // one target per slot above 2nd
                for (int i = 0; i < (int)slot - 1; i++) {
                    Combattant target = targets[i];
                    // only affect humanoid monsters
                    if (target is Monster) {
                        Monster monster = (Monster)target;
                        if (monster.Type != MonsterType.HUMANOID) {
                            GlobalEvents.AffectBySpell(caster, ID.HOLD_PERSON, monster, false);
                            continue;
                        }
                    }
                    // Wisdom save
                    if (!target.DC(dc, AbilityType.WISDOM)) {
                        GlobalEvents.AffectBySpell(caster, ID.HOLD_PERSON, target, true);
                        target.AddCondition(ConditionType.PARALYZED);
                        target.AddEndOfTurnEvent(delegate (Combattant combattant) {
                            bool success = combattant.DC(dc, AbilityType.WISDOM);
                            if (success) {
                                combattant.RemoveCondition(ConditionType.PARALYZED);
                            }
                            return success;
                        });
                    } else {
                        GlobalEvents.AffectBySpell(caster, ID.HOLD_PERSON, target, false);
                    }
                }
            }
        );

        public static readonly Spell Jump = new Spell(
            ID.JUMP, SpellSchool.TRANSMUTATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 0, VSM,
            SpellDuration.CONCENTRATION_ONE_MINUTE, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                Combattant target = targets[0];
                GlobalEvents.AffectBySpell(caster, ID.JUMP, target, true);
                target.AddEffect(Effect.JUMP);
            }
        );

        public static readonly Spell Longstrider = new Spell(
            ID.LONGSTRIDER, SpellSchool.TRANSMUTATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 0, VSM,
            SpellDuration.CONCENTRATION_ONE_HOUR, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
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

        public static readonly Spell Mending = new Spell(
            ID.MENDING, SpellSchool.TRANSMUTATION, SpellLevel.CANTRIP, CastingTime.ONE_MINUTE, 0, VSM,
            SpellDuration.INSTANTANEOUS, 0, 1, doNothing
        );

        public static readonly Spell ProduceFlame = new Spell(
            ID.PRODUCE_FLAME, SpellSchool.CONJURATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 30, VS,
            SpellDuration.INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                int bonus = modifier + caster.ProficiencyBonus;
                string diceString = "1d8";
                if (caster.EffectiveLevel >= 17)
                    diceString = "4d8";
                else if (caster.EffectiveLevel >= 11)
                    diceString = "3d8";
                else if (caster.EffectiveLevel >= 5)
                    diceString = "2d8";
                Damage damage = new Damage(DamageType.FIRE, diceString);
                Attack attack = new Attack(ID.PRODUCE_FLAME.Name(), bonus, damage, 0, 30, 30);
                int distance = ground.LocateCombattant(caster).Distance(ground.LocateCombattant(targets[0]));
                caster.Attack(attack, targets[0], distance, true);
            }
        );

        public static readonly Spell PurifyFoodAndDrink = new Spell(
            ID.PURIFY_FOOD_AND_DRINK, SpellSchool.TRANSMUTATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 10, VS,
            SpellDuration.INSTANTANEOUS, 5, 0, doNothing
        );

        public static readonly Spell Resistance = new Spell(
            ID.RESISTANCE, SpellSchool.ABJURATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 0, VSM,
            SpellDuration.CONCENTRATION_ONE_MINUTE, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                GlobalEvents.AffectBySpell(caster, ID.RESISTANCE, targets[0], true);
                targets[0].AddEffect(Effect.RESISTANCE);
            }
        );

        public static readonly Spell Shillelagh = new Spell(
            ID.SHILLELAGH, SpellSchool.TRANSMUTATION, SpellLevel.CANTRIP, CastingTime.BONUS_ACTION, 0, VSM,
            SpellDuration.CONCENTRATION_ONE_MINUTE, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                // can only be cast by PCs or NPCs
                if (!(caster is CharacterSheet)) {
                    GlobalEvents.AffectBySpell(caster, ID.SHILLELAGH, caster, false);
                    return;
                };
                CharacterSheet sheet = (CharacterSheet)caster;
                // spell requires a quarterstaff or club
                if (sheet.Inventory.MainHand == null) {
                    GlobalEvents.AffectBySpell(caster, ID.SHILLELAGH, caster, false);
                    return;
                }
                if (!sheet.Inventory.MainHand.IsThisA(Weapons.Club) && !sheet.Inventory.MainHand.IsThisA(Weapons.Quarterstaff)) {
                    GlobalEvents.AffectBySpell(caster, ID.SHILLELAGH, caster, false);
                    return;
                }
                // replace melee attacks by shillelagh attacks
                GlobalEvents.AffectBySpell(caster, ID.SHILLELAGH, caster, true);
                foreach (Attack attack in sheet.MeleeAttacks) {
                    attack.Name = ID.SHILLELAGH.Name();
                    attack.Damage.Dices = new Dices(1, 8, modifier);
                    attack.AttackBonus = modifier + sheet.ProficiencyBonus;
                }
                if (caster.BonusAttack != null) {
                    caster.BonusAttack.Name = ID.SHILLELAGH.Name();
                    caster.BonusAttack.Damage.Dices = new Dices(1, 8, modifier);
                    caster.BonusAttack.AttackBonus = modifier + sheet.ProficiencyBonus;
                }
            }
        );

        public static readonly Spell SpeakWithAnimals = new Spell(
            ID.SPEAK_WITH_ANIMALS, SpellSchool.DIVINATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 0, VS,
            SpellDuration.CONCENTRATION_TEN_MINUTES, 0, 0, doNothing
        );

        public static readonly Spell Thunderwave = new Spell(
            ID.THUNDERWAVE, SpellSchool.EVOCATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 15, VS,
            SpellDuration.INSTANTANEOUS, 15, 20, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                int dices = (int)slot + 1;
                bool pushed = true;
                foreach (Combattant target in targets) {
                    GlobalEvents.AffectBySpell(caster, ID.THUNDERWAVE, caster, true);
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
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

    public delegate void SpellCastEffect(Combattant caster, int dc, SpellLevel slot, int modifier, params Combattant[] targets);

    public struct Spells {
        private static SpellCastEffect doNothing = delegate (Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) { };

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
            CURE_WOUNDS,
            DETECT_MAGIC,
            HEALING_WORD,
            HOLD_PERSON,
            MAGIC_MISSILE,
            SHILLELAGH
        }

        public static readonly Spell AcidSplash = new Spell(
            ID.ACID_SPLASH, SpellSchool.CONJURATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 60, VS,
            SpellDuration.INSTANTANEOUS, 5, 2, delegate (Combattant caster, int dc, SpellLevel slot, int modifer, Combattant[] targets) {
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
                    if (!target.DC(dc, AbilityType.DEXTERITY))
                        target.TakeDamage(damage);
                }
            }
        );

        public static readonly Spell MagicMissile = new Spell(
            ID.MAGIC_MISSILE, SpellSchool.EVOCATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 120, VS,
            SpellDuration.INSTANTANEOUS, 0, 20, delegate (Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                Damage damage = new Damage(DamageType.FORCE, "1d4+1");
                int missiles = (int)slot + 2;
                for (int i = 0; i < missiles; i++) {
                    Combattant target = targets[i % targets.Length];
                    target.TakeDamage(damage);
                }
            }
        );

        public static readonly Spell CureWounds = new Spell(
            ID.CURE_WOUNDS, SpellSchool.EVOCATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 5, VS,
            SpellDuration.INSTANTANEOUS, 0, 1, delegate (Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                if (targets[0] is Monster) {
                    Monster monster = (Monster)targets[0];
                    if (monster.Type == MonsterType.CONSTRUCT || monster.Type == MonsterType.UNDEAD) return;
                }
                int dices = (int)slot;
                Dices healed = new Dices(dices, 8, modifier);
                targets[0].HealDamage(healed.Roll());
            }
        );

        public static readonly Spell DetectMagic = new Spell(
            ID.DETECT_MAGIC, SpellSchool.DIVINATION, SpellLevel.FIRST, CastingTime.ONE_ACTION, 0, VS,
            SpellDuration.CONCENTRATION_TEN_MINUTES, 30, 0, doNothing
        );

        public static readonly Spell Shillelagh = new Spell(
            ID.SHILLELAGH, SpellSchool.TRANSMUTATION, SpellLevel.CANTRIP, CastingTime.BONUS_ACTION, 0, VSM,
            SpellDuration.CONCENTRATION_ONE_MINUTE, 0, 0, delegate (Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                // can only be cast by PCs or NPCs
                if (!(caster is CharacterSheet)) return;
                CharacterSheet sheet = (CharacterSheet)caster;
                // spell requires a quarterstaff or club
                if (sheet.Inventory.MainHand == null) return;
                if (!sheet.Inventory.MainHand.Item.Equals(Weapons.Club) && !sheet.Inventory.MainHand.Item.Equals(Weapons.Quarterstaff)) return;
                // replace melee attacks by shillelagh attacks
                foreach (Attack attack in sheet.MeleeAttacks) {
                    attack.Damage.Dices = new Dices(1, 8, modifier);
                    attack.AttackBonus = modifier + sheet.Proficiency;
                }
            }
        );

        public static readonly Spell HealingWord = new Spell(
            ID.HEALING_WORD, SpellSchool.EVOCATION, SpellLevel.FIRST, CastingTime.BONUS_ACTION, 60, V,
            SpellDuration.INSTANTANEOUS, 0, 1, delegate (Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                if (targets[0] is Monster) {
                    Monster monster = (Monster)targets[0];
                    if (monster.Type == MonsterType.CONSTRUCT || monster.Type == MonsterType.UNDEAD) return;
                }
                int dices = (int)slot;
                Dices healed = new Dices(dices, 4, modifier);
                targets[0].HealDamage(healed.Roll());
            }
        );

        public static readonly Spell CharmPerson = new Spell(
            ID.CHARM_PERSON, SpellSchool.ENCHANTMENT, SpellLevel.FIRST, CastingTime.ONE_ACTION, 30, VS,
            SpellDuration.CONCENTRATION_ONE_HOUR, 0, 20, delegate (Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                // one target per slot
                for (int i = 0; i < (int)slot; i++) {
                    Combattant target = targets[i];
                    // only affect humanoid monsters
                    if (target is Monster) {
                        Monster monster = (Monster)target;
                        if (monster.Type != MonsterType.HUMANOID) continue;
                    }
                    // Wisdom save with advantage since we assume a fight
                    if (!target.DC(dc, AbilityType.WISDOM, true)) {
                        target.AddCondition(ConditionType.CHARMED);
                    }
                }
            }
        );

        public static readonly Spell HoldPerson = new Spell(
            ID.HOLD_PERSON, SpellSchool.ENCHANTMENT, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, VSM,
            SpellDuration.CONCENTRATION_ONE_MINUTE, 0, 20, delegate (Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                // one target per slot above 2nd
                for (int i = 0; i < (int)slot - 1; i++) {
                    Combattant target = targets[i];
                    // only affect humanoid monsters
                    if (target is Monster) {
                        Monster monster = (Monster)target;
                        if (monster.Type != MonsterType.HUMANOID) continue;
                    }
                    // Wisdom save
                    if (!target.DC(dc, AbilityType.WISDOM)) {
                        target.AddCondition(ConditionType.PARALYZED);
                        target.AddEndOfTurnEvent(delegate (Combattant combattant) {
                            bool success = combattant.DC(dc, AbilityType.WISDOM);
                            if (success) {
                                combattant.RemoveCondition(ConditionType.PARALYZED);
                            }
                            return success;
                        });
                    }
                }
            }
        );

    }
}
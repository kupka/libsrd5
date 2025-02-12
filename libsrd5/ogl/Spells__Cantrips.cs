using System;

namespace srd5 {
    public partial struct Spells {
        public static readonly Spell AcidSplash = new Spell(
                    ID.ACID_SPLASH, SpellSchool.CONJURATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 60, VS,
                    SpellDuration.INSTANTANEOUS, 5, 2, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        Damage damage = DamageLevelScaling(caster, Die.D6, DamageType.ACID);
                        foreach (Combattant target in targets) {
                            int amount = damage.Dice.Roll();
                            if (!target.DC(ID.ACID_SPLASH, dc, AbilityType.DEXTERITY)) {
                                GlobalEvents.AffectBySpell(caster, ID.ACID_SPLASH, target, true);
                                target.TakeDamage(ID.ACID_SPLASH, damage.Type, amount);
                            } else {
                                GlobalEvents.AffectBySpell(caster, ID.ACID_SPLASH, target, false);
                            }
                        }
                    }
                );

        public static readonly Spell ChillTouch = new Spell(
                    ID.CHILL_TOUCH, SpellSchool.NECROMANCY, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 120, VS,
                    SpellDuration.INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        Damage damage = DamageLevelScaling(caster, Die.D8, DamageType.NECROTIC);
                        Combattant target = targets[0];
                        bool hit = SpellAttack(ID.CHILL_TOUCH, ground, caster, damage, modifier, target, 120);
                        if (hit) {
                            target.AddEffect(Effect.CANNOT_REGAIN_HITPOINTS);
                            caster.AddStartOfTurnEvent(delegate () {
                                target.RemoveEffect(Effect.CANNOT_REGAIN_HITPOINTS);
                                return true;
                            });
                            bool undead = target is Monster monster && monster.Type == Monsters.Type.UNDEAD;
                            if (undead) {
                                target.AddEffect(Effect.DISADVANTAGE_ON_ATTACK);
                                int rounds = 2;
                                caster.AddEndOfTurnEvent(delegate () {
                                    if (--rounds > 0) return false;
                                    if (undead) target.RemoveEffect(Effect.DISADVANTAGE_ON_ATTACK);
                                    return true;
                                });
                            }
                        }
                    }
        );

        public static readonly Spell DancingLights = new Spell(
                    ID.DANCING_LIGHTS, SpellSchool.EVOCATION, SpellLevel.CANTRIP, CastingTime.ONE_MINUTE, 120, VSM,
                    SpellDuration.INSTANTANEOUS, 0, 1, SpellWithoutEffect(ID.DANCING_LIGHTS)
        );

        public static readonly Spell Druidcraft = new Spell(ID.DRUIDCRAFT, SpellSchool.TRANSMUTATION,
                    SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 30, VS, SpellDuration.INSTANTANEOUS, 0, 0,
                    SpellWithoutEffect(ID.DRUIDCRAFT));

        public static readonly Spell EldritchBlast = new Spell(ID.ELDRITCH_BLAST, SpellSchool.EVOCATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 120, VS, SpellDuration.INSTANTANEOUS, 0, 4,
            delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                Damage damage = new Damage(DamageType.FORCE, "1d10");
                for (int i = 0; i < DiceLevelScaling(caster); i++) {
                    SpellAttack(ID.ELDRITCH_BLAST, ground, caster, damage, modifier, targets[i], 120);
                }
            });

        public static readonly Spell FireBolt = new Spell(
                ID.FIRE_BOLT, SpellSchool.EVOCATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 120, VS,
                SpellDuration.INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Damage damage = DamageLevelScaling(caster, Die.D10, DamageType.FIRE);
                    SpellAttack(ID.FIRE_BOLT, ground, caster, damage, modifier, targets[0], 120);
                }
        );

        public static readonly Spell Guidance = new Spell(
            ID.GUIDANCE, SpellSchool.DIVINATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 5, VS,
            SpellDuration.ONE_MINUTE, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                targets[0].AddEffect(Effect.SPELL_GUIDANCE);
            }
        );

        public static readonly Spell Light = new Spell(
            ID.LIGHT, SpellSchool.EVOCATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 0, VM,
            SpellDuration.ONE_HOUR, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                Combattant target = targets[0];
                if (target.DC(ID.LIGHT, dc, AbilityType.DEXTERITY)) {
                    GlobalEvents.AffectBySpell(caster, ID.LIGHT, target, false);
                } else {
                    GlobalEvents.AffectBySpell(caster, ID.LIGHT, target, true);
                    target.AddEffect(Effect.SPELL_LIGHT);
                }
            }
        );

        public static readonly Spell MageHand = new Spell(
            ID.MENDING, SpellSchool.CONJURATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 30, VS,
            SpellDuration.ONE_MINUTE, 0, 0, SpellWithoutEffect(ID.MAGE_HAND)
        );


        public static readonly Spell Mending = new Spell(
            ID.MENDING, SpellSchool.TRANSMUTATION, SpellLevel.CANTRIP, CastingTime.ONE_MINUTE, 0, VSM,
            SpellDuration.INSTANTANEOUS, 0, 1, SpellWithoutEffect(ID.MENDING)
        );

        public static readonly Spell Message = new Spell(
            ID.MENDING, SpellSchool.TRANSMUTATION, SpellLevel.CANTRIP, CastingTime.ONE_ROUND, 120, VSM,
            SpellDuration.ONE_ROUND, 0, 1, SpellWithoutEffect(ID.MESSAGE)
        );

        public static readonly Spell MinorIllusion = new Spell(
            ID.MINOR_ILLUSION, SpellSchool.ILLUSION, SpellLevel.CANTRIP, CastingTime.ONE_ROUND, 30, SM,
            SpellDuration.ONE_MINUTE, 0, 0, SpellWithoutEffect(ID.MINOR_ILLUSION)
        );

        public static readonly Spell PoisonSpray = new Spell(ID.POISON_SPRAY, SpellSchool.CONJURATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 10, VS, SpellDuration.INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
            Damage damage = DamageLevelScaling(caster, Die.D12, DamageType.POISON);
            Combattant target = targets[0];
            int amount = damage.Dice.Roll();
            if (target.DC(ID.POISON_SPRAY, dc, AbilityType.CONSTITUTION)) {
                GlobalEvents.AffectBySpell(caster, ID.POISON_SPRAY, target, false);
            } else {
                GlobalEvents.AffectBySpell(caster, ID.POISON_SPRAY, target, true);
                target.TakeDamage(ID.POISON_SPRAY, damage.Type, amount);
            }
        });

        public static readonly Spell Prestidigitation = new Spell(
            ID.PRESTIDIGITATION, SpellSchool.TRANSMUTATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 10, VS,
            SpellDuration.ONE_HOUR, 0, 0, SpellWithoutEffect(ID.PRESTIDIGITATION)
        );


        public static readonly Spell ProduceFlame = new Spell(
            ID.PRODUCE_FLAME, SpellSchool.CONJURATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 30, VS,
            SpellDuration.INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                int bonus = modifier + caster.ProficiencyBonus;
                Damage damage = DamageLevelScaling(caster, Die.D8, DamageType.FIRE);
                SpellAttack(ID.PRODUCE_FLAME, ground, caster, damage, modifier, targets[0], 30);
            }
        );

        public static readonly Spell RayOfFrost = new Spell(
            ID.RAY_OF_FROST, SpellSchool.EVOCATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 60, VS,
            SpellDuration.INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                int bonus = modifier + caster.ProficiencyBonus;
                Damage damage = DamageLevelScaling(caster, Die.D8, DamageType.COLD);
                Combattant target = targets[0];
                bool hit = SpellAttack(ID.RAY_OF_FROST, ground, caster, damage, modifier, target, 60);
                if (hit) {
                    target.AddEffect(Effect.SPELL_RAY_OF_FROST);
                    caster.AddStartOfTurnEvent(delegate () {
                        target.RemoveEffect(Effect.SPELL_RAY_OF_FROST);
                        return true;
                    });
                }
            }
        );

        public static readonly Spell Resistance = new Spell(
            ID.RESISTANCE, SpellSchool.ABJURATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 0, VSM,
            SpellDuration.ONE_MINUTE, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                GlobalEvents.AffectBySpell(caster, ID.RESISTANCE, targets[0], true);
                targets[0].AddEffect(Effect.SPELL_RESISTANCE);
            }
        );

        public static readonly Spell SacredFlame = new Spell(ID.SACRED_FLAME, SpellSchool.EVOCATION,
                SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 60, VS, SpellDuration.INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.SACRED_FLAME));

        public static readonly Spell Shillelagh = new Spell(
            ID.SHILLELAGH, SpellSchool.TRANSMUTATION, SpellLevel.CANTRIP, CastingTime.BONUS_ACTION, 0, VSM,
            SpellDuration.ONE_MINUTE, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
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
                if (!sheet.Inventory.MainHand.Is(Weapons.Club) && !sheet.Inventory.MainHand.Is(Weapons.Quarterstaff)) {
                    GlobalEvents.AffectBySpell(caster, ID.SHILLELAGH, caster, false);
                    return;
                }
                // replace melee attacks by shillelagh attacks
                GlobalEvents.AffectBySpell(caster, ID.SHILLELAGH, caster, true);
                foreach (Attack attack in sheet.MeleeAttacks) {
                    attack.Name = ID.SHILLELAGH.Name();
                    attack.Damage.Dice = new Dice(1, 8, modifier);
                    attack.AttackBonus = modifier + sheet.ProficiencyBonus;
                }
                if (caster.BonusAttack != null) {
                    caster.BonusAttack.Name = ID.SHILLELAGH.Name();
                    caster.BonusAttack.Damage.Dice = new Dice(1, 8, modifier);
                    caster.BonusAttack.AttackBonus = modifier + sheet.ProficiencyBonus;
                }
            }
        );

        public static readonly Spell ShockingGrasp = new Spell(
            ID.SHOCKING_GRASP, SpellSchool.EVOCATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 5, VS,
            SpellDuration.INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                Damage damage = DamageLevelScaling(caster, Die.D8, DamageType.LIGHTNING);
                Combattant target = targets[0];
                bool hit = SpellAttack(ID.SHOCKING_GRASP, ground, caster, damage, modifier, target, 5);
                if (hit) {
                    target.AddEffect(Effect.CANNOT_TAKE_REACTIONS);
                    caster.AddStartOfTurnEvent(delegate () {
                        target.RemoveEffect(Effect.CANNOT_TAKE_REACTIONS);
                        return true;
                    });
                }
            }
        );

        public static readonly Spell SpareTheDying = new Spell(ID.SPARE_THE_DYING, SpellSchool.NECROMANCY, SpellLevel.CANTRIP,
            CastingTime.ONE_ACTION, 5, VS, SpellDuration.INSTANTANEOUS, 0, 0,
            delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                if (targets[0].HasEffect(Effect.FIGHTING_DEATH)) {
                    targets[0].AddEffect(Effect.FIGHTING_DEATH_STABILIZED);
                }
            });

        public static readonly Spell Thaumaturgy = new Spell(ID.THAUMATURGY, SpellSchool.TRANSMUTATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 30, V, SpellDuration.ONE_MINUTE, 0, 0, SpellWithoutEffect(ID.THAUMATURGY));

        public static readonly Spell TrueStrike = new Spell(
            ID.TRUE_STRIKE, SpellSchool.DIVINATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 30, S,
            SpellDuration.ONE_ROUND, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                int turn = ground.Turn;
                caster.AddAttackModifyingEffect(delegate (ref bool advantage, ref bool disadvantage, ref Attack attack, ref Combattant target) {
                    if (ground.Turn > turn + 1) return true; // no longer active
                    if (ground.Turn < turn + 1) return false; // not yet active
                    if (target == targets[0]) {
                        advantage = true;
                        return true;
                    } else {
                        return false;
                    }
                });
                GlobalEvents.AffectBySpell(caster, ID.TRUE_STRIKE, targets[0], true);
            }
        );

        public static readonly Spell ViciousMockery = new Spell(ID.VICIOUS_MOCKERY, SpellSchool.ENCHANTMENT, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 60, V, SpellDuration.INSTANTANEOUS, 0, 0,
            delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                Damage damage = DamageLevelScaling(caster, Die.D4, DamageType.PSYCHIC);
                Combattant target = targets[0];
                int damageTaken = target.TakeDamage(ID.VICIOUS_MOCKERY, damage.Type, damage.Dice.Roll(), DCEffect.NULLIFIES_DAMAGE, dc, AbilityType.WISDOM, out _);
                if (damageTaken == 0) {
                    GlobalEvents.AffectBySpell(caster, ID.VICIOUS_MOCKERY, target, false);
                } else {
                    GlobalEvents.AffectBySpell(caster, ID.VICIOUS_MOCKERY, target, true);
                    target.AddEffect(Effect.DISADVANTAGE_ON_ATTACK);
                    target.AddEndOfTurnEvent(
                        delegate () {
                            target.RemoveEffect(Effect.DISADVANTAGE_ON_ATTACK);
                            return true;
                        }
                    );
                }
            }
        );
    }
}
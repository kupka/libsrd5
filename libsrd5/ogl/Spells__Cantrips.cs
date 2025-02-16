using static srd5.Die;

namespace srd5 {
    public partial struct Spells {
        public static Spell AcidSplash {
            get {
                return new Spell(
                    ID.ACID_SPLASH, SpellSchool.CONJURATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 60, VS,
                    SpellDuration.INSTANTANEOUS, 5, 2, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        Dice dice = DiceLevelScaling(caster, D6);
                        foreach (Combattant target in targets) {
                            if (!target.DC(ID.ACID_SPLASH, dc, AbilityType.DEXTERITY)) {
                                GlobalEvents.AffectBySpell(caster, ID.ACID_SPLASH, target, true);
                                target.TakeDamage(ID.ACID_SPLASH, DamageType.ACID, dice);
                            } else {
                                GlobalEvents.AffectBySpell(caster, ID.ACID_SPLASH, target, false);
                            }
                        }
                    }
                );
            }
        }

        public static Spell ChillTouch {
            get {
                return new Spell(
                    ID.CHILL_TOUCH, SpellSchool.NECROMANCY, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 120, VS,
                    SpellDuration.INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        Dice dice = DiceLevelScaling(caster, D8);
                        Combattant target = targets[0];
                        bool hit = SpellAttack(ID.CHILL_TOUCH, ground, caster, DamageType.NECROTIC, dice, modifier, target, 120);
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
            }
        }

        public static Spell DancingLights {
            get {
                return new Spell(
                    ID.DANCING_LIGHTS, SpellSchool.EVOCATION, SpellLevel.CANTRIP, CastingTime.ONE_MINUTE, 120, VSM,
                    SpellDuration.INSTANTANEOUS, 0, 1, SpellWithoutEffect(ID.DANCING_LIGHTS)
                );
            }
        }

        public static Spell Druidcraft {
            get {
                return new Spell(ID.DRUIDCRAFT, SpellSchool.TRANSMUTATION,
                    SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 30, VS, SpellDuration.INSTANTANEOUS, 0, 0,
                    SpellWithoutEffect(ID.DRUIDCRAFT)
                );
            }
        }

        public static Spell EldritchBlast {
            get {
                return new Spell(ID.ELDRITCH_BLAST, SpellSchool.EVOCATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 120, VS, SpellDuration.INSTANTANEOUS, 0, 4,
                    delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        Damage damage = new Damage(DamageType.FORCE, "1d10");
                        Dice dice = DiceLevelScaling(caster, D10);
                        for (int i = 0; i < dice.Amount; i++) {
                            SpellAttack(ID.ELDRITCH_BLAST, ground, caster, DamageType.FORCE, new Dice("1d10"), modifier, targets[i], 120);
                        }
                    }
                );
            }
        }

        public static Spell FireBolt {
            get {
                return new Spell(
                    ID.FIRE_BOLT, SpellSchool.EVOCATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 120, VS,
                    SpellDuration.INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        Dice dice = DiceLevelScaling(caster, D10);
                        SpellAttack(ID.FIRE_BOLT, ground, caster, DamageType.FIRE, dice, modifier, targets[0], 120);
                    }
                );
            }
        }

        public static Spell Guidance {
            get {
                return new Spell(
                    ID.GUIDANCE, SpellSchool.DIVINATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 5, VS,
                    SpellDuration.ONE_MINUTE, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        targets[0].AddEffect(Effect.SPELL_GUIDANCE);
                    }
                );
            }
        }

        public static Spell Light {
            get {
                return new Spell(
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
            }
        }

        public static Spell MageHand {
            get {
                return new Spell(
                    ID.MENDING, SpellSchool.CONJURATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 30, VS,
                    SpellDuration.ONE_MINUTE, 0, 0, SpellWithoutEffect(ID.MAGE_HAND)
                );
            }
        }


        public static Spell Mending {
            get {
                return new Spell(
                    ID.MENDING, SpellSchool.TRANSMUTATION, SpellLevel.CANTRIP, CastingTime.ONE_MINUTE, 0, VSM,
                    SpellDuration.INSTANTANEOUS, 0, 1, SpellWithoutEffect(ID.MENDING)
                );
            }
        }

        public static Spell Message {
            get {
                return new Spell(
                    ID.MENDING, SpellSchool.TRANSMUTATION, SpellLevel.CANTRIP, CastingTime.ONE_ROUND, 120, VSM,
                    SpellDuration.ONE_ROUND, 0, 1, SpellWithoutEffect(ID.MESSAGE)
                );
            }
        }

        public static Spell MinorIllusion {
            get {
                return new Spell(
                    ID.MINOR_ILLUSION, SpellSchool.ILLUSION, SpellLevel.CANTRIP, CastingTime.ONE_ROUND, 30, SM,
                    SpellDuration.ONE_MINUTE, 0, 0, SpellWithoutEffect(ID.MINOR_ILLUSION)
                );
            }
        }

        public static Spell PoisonSpray {
            get {
                return new Spell(ID.POISON_SPRAY, SpellSchool.CONJURATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 10, VS, SpellDuration.INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Dice dice = DiceLevelScaling(caster, D12);
                    Combattant target = targets[0];
                    if (target.DC(ID.POISON_SPRAY, dc, AbilityType.CONSTITUTION)) {
                        GlobalEvents.AffectBySpell(caster, ID.POISON_SPRAY, target, false);
                    } else {
                        GlobalEvents.AffectBySpell(caster, ID.POISON_SPRAY, target, true);
                        target.TakeDamage(ID.POISON_SPRAY, DamageType.POISON, dice);
                    }
                });
            }
        }

        public static Spell Prestidigitation {
            get {
                return new Spell(
                    ID.PRESTIDIGITATION, SpellSchool.TRANSMUTATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 10, VS,
                    SpellDuration.ONE_HOUR, 0, 0, SpellWithoutEffect(ID.PRESTIDIGITATION)
                );
            }
        }


        public static Spell ProduceFlame {
            get {
                return new Spell(
                    ID.PRODUCE_FLAME, SpellSchool.CONJURATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 30, VS,
                    SpellDuration.INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        int bonus = modifier + caster.ProficiencyBonus;
                        Dice dice = DiceLevelScaling(caster, D8);
                        SpellAttack(ID.PRODUCE_FLAME, ground, caster, DamageType.FIRE, dice, modifier, targets[0], 30);
                    }
                );
            }
        }

        public static Spell RayOfFrost {
            get {
                return new Spell(
                    ID.RAY_OF_FROST, SpellSchool.EVOCATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 60, VS,
                    SpellDuration.INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        int bonus = modifier + caster.ProficiencyBonus;
                        Dice dice = DiceLevelScaling(caster, D8);
                        Combattant target = targets[0];
                        bool hit = SpellAttack(ID.RAY_OF_FROST, ground, caster, DamageType.COLD, dice, modifier, target, 60);
                        if (hit) {
                            target.AddEffect(Effect.SPELL_RAY_OF_FROST);
                            caster.AddStartOfTurnEvent(delegate () {
                                target.RemoveEffect(Effect.SPELL_RAY_OF_FROST);
                                return true;
                            });
                        }
                    }
                );
            }
        }

        public static Spell Resistance {
            get {
                return new Spell(
                    ID.RESISTANCE, SpellSchool.ABJURATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 0, VSM,
                    SpellDuration.ONE_MINUTE, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        GlobalEvents.AffectBySpell(caster, ID.RESISTANCE, targets[0], true);
                        targets[0].AddEffect(Effect.SPELL_RESISTANCE);
                    }
                );
            }
        }

        public static Spell SacredFlame {
            get {
                return new Spell(
                    ID.SACRED_FLAME, SpellSchool.EVOCATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 60, VS, SpellDuration.INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.SACRED_FLAME)
                );
            }
        }

        public static Spell Shillelagh {
            get {
                return new Spell(
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
            }
        }

        public static Spell ShockingGrasp {
            get {
                return new Spell(
                    ID.SHOCKING_GRASP, SpellSchool.EVOCATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 5, VS,
                    SpellDuration.INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        Dice dice = DiceLevelScaling(caster, D8);
                        Combattant target = targets[0];
                        bool hit = SpellAttack(ID.SHOCKING_GRASP, ground, caster, DamageType.LIGHTNING, dice, modifier, target, 5);
                        if (hit) {
                            target.AddEffect(Effect.CANNOT_TAKE_REACTIONS);
                            caster.AddStartOfTurnEvent(delegate () {
                                target.RemoveEffect(Effect.CANNOT_TAKE_REACTIONS);
                                return true;
                            });
                        }
                    }
                );
            }
        }

        public static Spell SpareTheDying {
            get {
                return new Spell(ID.SPARE_THE_DYING, SpellSchool.NECROMANCY, SpellLevel.CANTRIP,
                    CastingTime.ONE_ACTION, 5, VS, SpellDuration.INSTANTANEOUS, 0, 0,
                    delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        if (targets[0].HasEffect(Effect.FIGHTING_DEATH)) {
                            targets[0].AddEffect(Effect.FIGHTING_DEATH_STABILIZED);
                        }
                    }
                );
            }
        }

        public static Spell Thaumaturgy {
            get {
                return new Spell(ID.THAUMATURGY, SpellSchool.TRANSMUTATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 30, V, SpellDuration.ONE_MINUTE, 0, 0, SpellWithoutEffect(ID.THAUMATURGY));
            }
        }

        public static Spell TrueStrike {
            get {
                return new Spell(
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
            }
        }

        public static Spell ViciousMockery {
            get {
                return new Spell(ID.VICIOUS_MOCKERY, SpellSchool.ENCHANTMENT, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 60, V, SpellDuration.INSTANTANEOUS, 0, 0,
                    delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        Dice dice = DiceLevelScaling(caster, D4);
                        Combattant target = targets[0];
                        int damageTaken = target.TakeDamage(ID.VICIOUS_MOCKERY, DamageType.PSYCHIC, dice, DamageMitigation.NULLIFIES_DAMAGE, dc, AbilityType.WISDOM, out _);
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
    }
}
using System;

namespace srd5 {
    public partial struct Spells {
        public static readonly Spell AcidSplash = new Spell(
                    ID.ACID_SPLASH, SpellSchool.CONJURATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 60, VS,
                    SpellDuration.INSTANTANEOUS, 5, 2, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
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
                            if (!target.DC(ID.ACID_SPLASH, dc, AbilityType.DEXTERITY)) {
                                GlobalEvents.AffectBySpell(caster, ID.ACID_SPLASH, target, true);
                                target.TakeDamage(damage.Type, amount);
                            } else {
                                GlobalEvents.AffectBySpell(caster, ID.ACID_SPLASH, target, false);
                            }
                        }
                    }
                );

        public static readonly Spell ChillTouch = new Spell(
                    ID.CHILL_TOUCH, SpellSchool.NECROMANCY, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 120, VS,
                    SpellDuration.INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        Damage damage;
                        int bonus = modifier + caster.ProficiencyBonus;
                        if (caster.EffectiveLevel > 16)
                            damage = new Damage(DamageType.NECROTIC, "4d8");
                        else if (caster.EffectiveLevel > 10)
                            damage = new Damage(DamageType.NECROTIC, "3d8");
                        else if (caster.EffectiveLevel > 4)
                            damage = new Damage(DamageType.NECROTIC, "2d8");
                        else
                            damage = new Damage(DamageType.NECROTIC, "1d8");
                        Combattant target = targets[0];
                        Attack attack = new Attack(ID.CHILL_TOUCH.Name(), bonus, damage, 0, 120, 120);
                        int distance = ground.LocateCombattant(caster).Distance(ground.LocateCombattant(target));
                        bool hit = caster.Attack(attack, target, distance, true, true);
                        if (hit) {
                            bool undead = (target is Monster) && ((Monster)target).Type == MonsterType.UNDEAD;
                            target.AddEffect(Effect.CANNOT_REGENERATE_HITPOINTS);
                            caster.AddStartOfTurnEvent(delegate (Combattant combattant) {
                                target.RemoveEffect(Effect.CANNOT_REGENERATE_HITPOINTS);
                                return true;
                            });
                            if (undead) {
                                target.AddEffect(Effect.DISADVANTAGE_ON_ATTACK);
                                int rounds = 2;
                                caster.AddEndOfTurnEvent(delegate (Combattant combattant) {
                                    if (--rounds > 0) return false;
                                    if (undead) target.RemoveEffect(Effect.DISADVANTAGE_ON_ATTACK);
                                    return true;
                                });
                            }
                        }
                        GlobalEvents.AffectBySpell(caster, ID.CHILL_TOUCH, target, hit);
                    }
        );

        public static readonly Spell DancingLights = new Spell(
                    ID.DANCING_LIGHTS, SpellSchool.EVOCATION, SpellLevel.CANTRIP, CastingTime.ONE_MINUTE, 120, VSM,
                    SpellDuration.INSTANTANEOUS, 0, 1, doNothing
        );

        public static readonly Spell FireBolt = new Spell(
                    ID.FIRE_BOLT, SpellSchool.EVOCATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 120, VS,
                    SpellDuration.INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        Damage damage;
                        int bonus = modifier + caster.ProficiencyBonus;
                        if (caster.EffectiveLevel > 16)
                            damage = new Damage(DamageType.NECROTIC, "4d10");
                        else if (caster.EffectiveLevel > 10)
                            damage = new Damage(DamageType.NECROTIC, "3d10");
                        else if (caster.EffectiveLevel > 4)
                            damage = new Damage(DamageType.NECROTIC, "2d10");
                        else
                            damage = new Damage(DamageType.NECROTIC, "1d10");
                        Combattant target = targets[0];
                        Attack attack = new Attack(ID.CHILL_TOUCH.Name(), bonus, damage, 0, 120, 120);
                        int distance = ground.LocateCombattant(caster).Distance(ground.LocateCombattant(target));
                        bool hit = caster.Attack(attack, target, distance, true, true);
                        GlobalEvents.AffectBySpell(caster, ID.FIRE_BOLT, target, hit);
                    }
        );

        public static readonly Spell Guidance = new Spell(
            ID.GUIDANCE, SpellSchool.DIVINATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 0, VS,
            SpellDuration.ONE_MINUTE, 0, 1, doNothing
        );

        public static readonly Spell Light = new Spell(
            ID.LIGHT, SpellSchool.EVOCATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 0, VM,
            SpellDuration.ONE_HOUR, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                Combattant target = targets[0];
                if (target.DC(ID.LIGHT, dc, AbilityType.DEXTERITY)) {
                    GlobalEvents.AffectBySpell(caster, ID.LIGHT, target, false);
                } else {
                    GlobalEvents.AffectBySpell(caster, ID.LIGHT, target, false);
                    target.AddEffect(Effect.LIGHT);
                }
            }
        );

        public static readonly Spell MageHand = new Spell(
            ID.MENDING, SpellSchool.CONJURATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 30, VS,
            SpellDuration.ONE_MINUTE, 0, 0, doNothing
        );


        public static readonly Spell Mending = new Spell(
            ID.MENDING, SpellSchool.TRANSMUTATION, SpellLevel.CANTRIP, CastingTime.ONE_MINUTE, 0, VSM,
            SpellDuration.INSTANTANEOUS, 0, 1, doNothing
        );

        public static readonly Spell Message = new Spell(
            ID.MENDING, SpellSchool.TRANSMUTATION, SpellLevel.CANTRIP, CastingTime.ONE_ROUND, 120, VSM,
            SpellDuration.ONE_ROUND, 0, 1, doNothing
        );

        public static readonly Spell MinorIllusion = new Spell(
            ID.MINOR_ILLUSION, SpellSchool.ILLUSION, SpellLevel.CANTRIP, CastingTime.ONE_ROUND, 30, SM,
            SpellDuration.ONE_MINUTE, 0, 0, doNothing
        );

        public static readonly Spell PRESTIDIGITATION = new Spell(
            ID.PRESTIDIGITATION, SpellSchool.TRANSMUTATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 10, VS,
            SpellDuration.ONE_HOUR, 0, 0, doNothing
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
                Combattant target = targets[0];
                int distance = ground.LocateCombattant(caster).Distance(ground.LocateCombattant(target));
                bool hit = caster.Attack(attack, target, distance, true, true);
                GlobalEvents.AffectBySpell(caster, ID.PRODUCE_FLAME, target, hit);
            }
        );

        public static readonly Spell RayOfFrost = new Spell(
            ID.RAY_OF_FROST, SpellSchool.EVOCATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 60, VS,
            SpellDuration.INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                Damage damage;
                int bonus = modifier + caster.ProficiencyBonus;
                if (caster.EffectiveLevel > 16)
                    damage = new Damage(DamageType.COLD, "4d8");
                else if (caster.EffectiveLevel > 10)
                    damage = new Damage(DamageType.COLD, "3d8");
                else if (caster.EffectiveLevel > 4)
                    damage = new Damage(DamageType.COLD, "2d8");
                else
                    damage = new Damage(DamageType.COLD, "1d8");
                Combattant target = targets[0];
                Attack attack = new Attack(ID.RAY_OF_FROST.Name(), bonus, damage, 0, 60, 60);
                int distance = ground.LocateCombattant(caster).Distance(ground.LocateCombattant(target));
                bool hit = caster.Attack(attack, target, distance, true, true);
                if (hit) {
                    target.AddEffect(Effect.RAY_OF_FROST);
                    caster.AddStartOfTurnEvent(delegate (Combattant combattant) {
                        target.RemoveEffect(Effect.RAY_OF_FROST);
                        return true;
                    });
                }
                GlobalEvents.AffectBySpell(caster, ID.RAY_OF_FROST, target, hit);
            }
        );

        public static readonly Spell Resistance = new Spell(
            ID.RESISTANCE, SpellSchool.ABJURATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 0, VSM,
            SpellDuration.ONE_MINUTE, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                GlobalEvents.AffectBySpell(caster, ID.RESISTANCE, targets[0], true);
                targets[0].AddEffect(Effect.RESISTANCE);
            }
        );

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

        public static readonly Spell ShockingGrasp = new Spell(
            ID.SHOCKING_GRASP, SpellSchool.EVOCATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 5, VS,
            SpellDuration.INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                Damage damage;
                int bonus = modifier + caster.ProficiencyBonus;
                if (caster.EffectiveLevel > 16)
                    damage = new Damage(DamageType.LIGHTNING, "4d8");
                else if (caster.EffectiveLevel > 10)
                    damage = new Damage(DamageType.LIGHTNING, "3d8");
                else if (caster.EffectiveLevel > 4)
                    damage = new Damage(DamageType.LIGHTNING, "2d8");
                else
                    damage = new Damage(DamageType.LIGHTNING, "1d8");
                Combattant target = targets[0];
                Attack attack = new Attack(ID.SHOCKING_GRASP.Name(), bonus, damage, 5);
                int distance = ground.LocateCombattant(caster).Distance(ground.LocateCombattant(target));
                bool hit = caster.Attack(attack, target, distance, false, true);
                if (hit) {
                    target.AddEffect(Effect.CANNOT_TAKE_REACTIONS);
                    caster.AddStartOfTurnEvent(delegate (Combattant combattant) {
                        target.RemoveEffect(Effect.CANNOT_TAKE_REACTIONS);
                        return true;
                    });
                }
                GlobalEvents.AffectBySpell(caster, ID.SHOCKING_GRASP, target, hit);
            }
        );
    }
}
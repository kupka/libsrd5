using System;
using static srd5.Die;
using static srd5.SpellVariant;
using static srd5.SpellSchool;
using static srd5.SpellLevel;
using static srd5.SpellDuration;
using static srd5.DamageType;
using static srd5.Spells.DamageMitigation;
using static srd5.Effect;
using static srd5.AbilityType;

namespace srd5 {
    public partial struct Spells {
        public static Spell AnimateDead {
            get {
                return new Spell(ID.ANIMATE_DEAD, NECROMANCY, THIRD, CastingTime.ONE_MINUTE, 10, VSM, INSTANTANEOUS, 0, 13, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    // TODO: Targetting bone piles to create skeletons requires objects on the battleground that aren't combattants
                    int maxTargets = ((int)slot - 3) * 2 + 1;
                    for (int i = 0; i < maxTargets && i < targets.Length; i++) {
                        Combattant target = targets[i];
                        // Only dead, small or medium humanoids can be targetted
                        if (target.Dead && (target.Size == Size.MEDIUM || target.Size == Size.SMALL) && (target is CharacterSheet || (target is Monster monster && monster.Type == Monsters.Type.HUMANOID)) && !target.HasEffect(SPELL_ANIMATE_DEAD)) {
                            GlobalEvents.AffectBySpell(caster, ID.ANIMATE_DEAD, target, true);
                            target.AddEffect(SPELL_ANIMATE_DEAD);
                            target.AddStartOfTurnEvent(delegate () {
                                if (target.HasEffect(SPELL_ANIMATE_DEAD)) {
                                    return false;
                                } else {
                                    target.Die();
                                    return true;
                                }
                            });
                            if (ground is Battleground2D battleground2D) {
                                Coord location = battleground2D.LocateCombattant2D(target);
                                battleground2D.AddCombattant(Monsters.Zombie, location.X, location.Y);
                                // TODO: Add logic to put the Zombie under the caster's control
                            } else if (ground is BattleGroundClassic battleGroundClassic) {
                                ClassicLocation location = battleGroundClassic.LocateClassicCombattant(target);
                                battleGroundClassic.AddCombattant(Monsters.Zombie, location.Location);
                            }
                        } else {
                            GlobalEvents.AffectBySpell(caster, ID.ANIMATE_DEAD, target, false);
                        }
                    }
                });
            }
        }

        public static Spell BeaconOfHope {
            get {
                return new Spell(ID.BEACON_OF_HOPE, ABJURATION, THIRD, CastingTime.ONE_ACTION, 30, VS, ONE_MINUTE, 0, 20, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    foreach (Combattant target in targets) {
                        AddEffectsForDuration(ID.BEACON_OF_HOPE, caster, target, ONE_MINUTE, SPELL_BEACON_OF_HOPE);
                    }
                });
            }
        }

        public static Spell BestowCurse {
            get {
                Spell curse = new Spell(ID.BESTOW_CURSE, NECROMANCY, THIRD, CastingTime.ONE_ACTION, 0, VS, ONE_MINUTE, 0, 1);
                curse.Variants = new SpellVariant[] {
                    SpellVariant.DISADVANTAGE_CHARISMA_SAVES,
                    SpellVariant.DISADVANTAGE_CONSTITUTION_SAVES,
                    SpellVariant.DISADVANTAGE_DEXTERITY_SAVES,
                    SpellVariant.DISADVANTAGE_INTELLIGENCE_SAVES,
                    SpellVariant.DISADVANTAGE_STRENGTH_SAVES,
                    SpellVariant.DISADVANTAGE_WISDOM_SAVES,
                    SpellVariant.DISADVANTAGE_ON_ATTACK,
                    SpellVariant.LOSE_TURN_ON_FAILED_WISDOM_SAVE,
                    SpellVariant.TAKE_ADDITIONAL_DAMAGE
                };
                SpellCastEffect castEffect = delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    if (target.DC(ID.BESTOW_CURSE, dc, WISDOM)) {
                        GlobalEvents.AffectBySpell(caster, ID.BESTOW_CURSE, target, false);
                        return;
                    }
                    SpellDuration duration = ONE_MINUTE;
                    if (slot == NINTH) duration = UNTIL_DISPELLED;
                    else if (slot > SIXTH) duration = ONE_DAY;
                    else if (slot > FOURTH) duration = EIGHT_HOURS;
                    else if (slot > THIRD) duration = TEN_MINUTES;
                    switch (curse.Variant) {
                        case SpellVariant.DISADVANTAGE_CHARISMA_SAVES:
                        case SpellVariant.DISADVANTAGE_CONSTITUTION_SAVES:
                        case SpellVariant.DISADVANTAGE_DEXTERITY_SAVES:
                        case SpellVariant.DISADVANTAGE_INTELLIGENCE_SAVES:
                        case SpellVariant.DISADVANTAGE_STRENGTH_SAVES:
                        case SpellVariant.DISADVANTAGE_WISDOM_SAVES:
                        case SpellVariant.DISADVANTAGE_ON_ATTACK:
                            AddEffectsForDuration(ID.BESTOW_CURSE, caster, target, duration, SPELL_BESTOW_CURSE, (Effect)Enum.Parse(typeof(Effect), Enum.GetName(typeof(SpellVariant), curse.Variant)));
                            break;
                        case SpellVariant.LOSE_TURN_ON_FAILED_WISDOM_SAVE:
                            AddEffectsForDuration(ID.BESTOW_CURSE, caster, target, duration, SPELL_BESTOW_CURSE_LOSE_TURN_ON_FAILED_WISDOM_SAVE);
                            target.AddStartOfTurnEvent(delegate () {
                                if (!target.HasEffect(SPELL_BESTOW_CURSE_LOSE_TURN_ON_FAILED_WISDOM_SAVE)) return true;
                                if (!target.DC(SPELL_BESTOW_CURSE_LOSE_TURN_ON_FAILED_WISDOM_SAVE, dc, WISDOM)) {
                                    target.AddEffect(SPELL_BESTOW_CURSE_LOST_TURN);
                                }
                                return true;
                            });
                            break;
                        case SpellVariant.TAKE_ADDITIONAL_DAMAGE:
                            AddEffectsForDuration(ID.BESTOW_CURSE, caster, target, duration, SPELL_BESTOW_CURSE_TAKE_ADDITIONAL_DAMAGE);
                            target.AddDamageTakenEvent(delegate (DamageSource source, Damage damage) {
                                if (!target.HasEffect(SPELL_BESTOW_CURSE_TAKE_ADDITIONAL_DAMAGE)) return true;
                                if (source.Equals(caster)) {
                                    target.TakeDamage(new DamageSource(ID.BESTOW_CURSE, caster), NECROTIC, D8);
                                }
                                return false;
                            });
                            break;
                    }
                };
                curse.CastEffect = castEffect;
                return curse;
            }
        }

        public static Spell Blink {
            get {
                return new Spell(ID.BLINK, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 0, VS, ONE_MINUTE, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    GlobalEvents.AffectBySpell(caster, ID.BLINK, caster, true);
                    int remainingRounds = (int)ONE_MINUTE;
                    caster.AddEndOfTurnEvent(delegate () {
                        if (--remainingRounds < 1) return true;
                        int roll = D20.Value;
                        if (roll > 11) {
                            caster.AddEffect(CANNOT_BE_ATTACKED);
                            caster.AddStartOfTurnEvent(delegate () {
                                caster.RemoveEffect(CANNOT_BE_ATTACKED);
                                return true;
                            });
                        }
                        return false;
                    });
                });
            }
        }

        public static Spell CallLightning {
            get {
                // TODO: If you are outdoors in stormy conditions when you cast this spell, the spell gives you control over the existing storm 
                // instead of creating a new one. Under such conditions, the spell's damage increases by 1d10.
                return new Spell(ID.CALL_LIGHTNING, CONJURATION, THIRD, CastingTime.ONE_ACTION, 120, VS, TEN_MINUTES, 5, 9, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    // This is modelled by creating a Cantrip that the caster can use. After the Duration, the cantrip is removed
                    Dice dice = DiceSlotScaling(THIRD, slot, D10, 1);
                    Damage damage = new Damage(LIGHTNING, dice);
                    foreach (Combattant target in targets) {
                        GlobalEvents.AffectBySpell(caster, ID.CALL_LIGHTNING, target, true);
                        target.TakeDamage(new DamageSource(ID.CALL_LIGHTNING, caster), LIGHTNING, dice, HALVES_DAMAGE, dc, DEXTERITY, out _);
                    }
                    // TODO: This cantrip workaround should be replaced by correctly implementing situative actions
                    Spell lightningCantrip = new Spell(ID.CALL_LIGHTNING_ATTACK, CONJURATION, CANTRIP, CastingTime.ONE_ACTION, 120, V, INSTANTANEOUS, 5, 9, delegate (Battleground ground2, Combattant caster2, int dc2, SpellLevel slot2, int modifier2, Combattant[] targets2) {
                        foreach (Combattant target2 in targets2) {
                            GlobalEvents.AffectBySpell(caster2, ID.CALL_LIGHTNING_ATTACK, target2, true);
                            target2.TakeDamage(new DamageSource(ID.CALL_LIGHTNING_ATTACK, caster), LIGHTNING, dice, HALVES_DAMAGE, dc2, DEXTERITY, out _);
                        }
                    });
                    caster.AvailableSpells[0].AddKnownSpell(lightningCantrip);
                    caster.AvailableSpells[0].AddPreparedSpell(lightningCantrip);
                    int remainingRounds = (int)TEN_MINUTES;
                    caster.AddEndOfTurnEvent(delegate () {
                        if (--remainingRounds < 1) {
                            caster.AvailableSpells[0].RemoveKnownSpell(lightningCantrip);
                            caster.AvailableSpells[0].RemovePreparedSpell(lightningCantrip);
                            return true;
                        } else {
                            return false;
                        }
                    });
                });
            }
        }

        public static Spell Clairvoyance {
            get {
                return new Spell(ID.CLAIRVOYANCE, DIVINATION, THIRD, CastingTime.TEN_MINUTES, 5280, VSM, TEN_MINUTES, 0, 0, 
                    delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        AddEffectsForDuration(ID.CLAIRVOYANCE, caster, caster, TEN_MINUTES, SPELL_CLAIRVOYANCE);
                    }
                );
            }
        }

        public static Spell ConjureAnimals {
            get {
                Spell conjure = new Spell(ID.CONJURE_ANIMALS, CONJURATION, THIRD, CastingTime.ONE_ACTION, 60, VS, ONE_HOUR, 0, 0);
                conjure.Variants = new SpellVariant[] { CR_QUARTER, CR_HALF, CR_ONE, CR_TWO };
                SpellCastEffect effect = delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Monster[] randomBeasts;
                    int beastAmount;
                    switch (conjure.Variant) {
                        case CR_QUARTER:
                            randomBeasts = new Monster[] {
                                Monsters.AxeBeak, Monsters.Boar, Monsters.ConstrictorSnake, Monsters.DraftHorse, Monsters.Elk, Monsters.GiantBadger, Monsters.GiantBat, Monsters.GiantCentipede, Monsters.GiantFrog, Monsters.GiantLizard, Monsters.GiantOwl, Monsters.GiantPoisonousSnake, Monsters.GiantWolfSpider, Monsters.Panther, Monsters.RidingHorse, Monsters.Wolf
                            };
                            beastAmount = 8;
                            break;
                        case CR_HALF:
                            randomBeasts = new Monster[] {
                                Monsters.Ape, Monsters.BlackBear, Monsters.Crocodile, Monsters.GiantGoat, Monsters.GiantWasp, Monsters.Warhorse
                            };
                            beastAmount = 4;
                            break;
                        case CR_ONE:
                            randomBeasts = new Monster[] {
                               Monsters.BrownBear, Monsters.DireWolf, Monsters.GiantEagle, Monsters.GiantHyena, Monsters.GiantSpider, Monsters.GiantToad, Monsters.GiantVulture, Monsters.Lion, Monsters.Tiger
                            };
                            beastAmount = 2;
                            break;
                        case CR_TWO:
                            randomBeasts = new Monster[] {
                                Monsters.GiantBoar, Monsters.GiantConstrictorSnake, Monsters.GiantElk, Monsters.PolarBear, Monsters.Rhinoceros, Monsters.SaberToothedTiger
                            };
                            beastAmount = 1;
                            break;
                        default:
                            throw new Srd5ArgumentException("Invalid spell variant. " + conjure.Variant);
                    }
                    if (slot > SIXTH)
                        beastAmount *= 3;
                    else if (slot > FOURTH)
                        beastAmount *= 2;
                    for (int i = 0; i < beastAmount; i++) {
                        if (ground is Battleground2D battleground2D) {
                            Coord location = battleground2D.LocateCombattant2D(caster);
                            battleground2D.AddCombattantNextTo(randomBeasts[D20.Value % randomBeasts.Length], location.X, location.Y);
                        } else if (ground is BattleGroundClassic battleGroundClassic) {
                            ClassicLocation location = battleGroundClassic.LocateClassicCombattant(caster);
                            battleGroundClassic.AddCombattant(randomBeasts[D20.Value % randomBeasts.Length], location.Location);
                        }
                    }
                    // TODO: Put the beasts under the caster's control
                };
                conjure.CastEffect = effect;
                return conjure;
            }
        }

        // TODO: Requires reactions to casting a spell implemented
        public static Spell Counterspell {
            get {
                return new Spell(ID.COUNTERSPELL, ABJURATION, THIRD, CastingTime.REACTION, 60, S, INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.COUNTERSPELL));
            }
        }

        // TODO: Requires hunger/thirst mechanics first
        public static Spell CreateFoodandWater {
            get {
                return new Spell(ID.CREATE_FOOD_AND_WATER, CONJURATION, THIRD, CastingTime.ONE_ACTION, 30, VS, INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.CREATE_FOOD_AND_WATER));
            }
        }

        // TODO: Requires light/darkness mechanics first
        public static Spell Daylight {
            get {
                return new Spell(ID.DAYLIGHT, EVOCATION, THIRD, CastingTime.ONE_ACTION, 60, VS, ONE_HOUR, 60, 0, SpellWithoutEffect(ID.DAYLIGHT));
            }
        }

        public static Spell DispelMagic {
            get {
                return new Spell(ID.DISPEL_MAGIC, ABJURATION, THIRD, CastingTime.ONE_ACTION, 120, VS, INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    GlobalEvents.AffectBySpell(caster, ID.DISPEL_MAGIC, target, true);
                    // Remove all spelleffects that are equal or lower the slot
                    for (int i = (int)slot; i >= 0; i--) {
                        foreach (Effect effect in Effects.GetSpellEffects((SpellLevel)i)) {
                            target.RemoveEffect(effect);
                        }
                    }
                    // Now, try to remove the remaining spell effects
                    foreach (Effect effect in target.Effects) {
                        if (effect.IsSpell()) {
                            if (caster.DC(ID.DISPEL_MAGIC, 10 + (int)effect.SpellLevel(), caster.SpellCastingAbility(ID.DISPEL_MAGIC))) {
                                target.RemoveEffect(effect);
                            }
                        }
                    }
                });
            }
        }
        
        public static Spell Fear {
            get {
                return new Spell(ID.FEAR, ILLUSION, THIRD, CastingTime.ONE_ACTION, 0, VSM, ONE_MINUTE, 30, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    foreach (Combattant target in targets) {
                        // Save vs fear
                        if (target.DC(ID.FEAR, dc, WISDOM)) {
                            GlobalEvents.AffectBySpell(caster, ID.FEAR, target, false);
                            continue;
                        }

                        // Drop whatever the target is holding (if applicable)
                        if (target is CharacterSheet sheet) {
                            sheet.Unequip(sheet.Inventory.MainHand);
                            sheet.Unequip(sheet.Inventory.OffHand);
                        }

                        // Apply frightened condition and a spell effect so it can be removed later
                        target.AddCondition(ConditionType.FRIGHTENED);
                        target.AddEffect(SPELL_FEAR);

                        // Duration handling (converts ONE_MINUTE to rounds)
                        int remainingRounds = (int)ONE_MINUTE;
                        target.AddStartOfTurnEvent(delegate () {
                            if (--remainingRounds < 1) {
                                target.RemoveEffect(SPELL_FEAR);
                                target.RemoveCondition(ConditionType.FRIGHTENED);
                                return true;
                            }
                            // While frightened the creature is expected to take the Dash action and move away from the caster.
                            // Movement AI is not implemented here; the presence of the FRIGHTENED condition should influence
                            // higher-level turn logic to force dash/movement away when available.
                            return false;
                        });

                        // At the end of the target's turn, if it doesn't have line of sight to the caster it may attempt
                        // a Wisdom save to end the effect. As an approximation, treat being more than 300 ft away as lacking
                        // line of sight for this check.
                        target.AddEndOfTurnEvent(delegate () {
                            if (!target.HasCondition(ConditionType.FRIGHTENED)) return true;
                            Location tLoc = ground.LocateCombattant(target);
                            Location cLoc = ground.LocateCombattant(caster);
                            if (tLoc != null && cLoc != null && tLoc.Distance(cLoc) > 300) {
                                if (target.DC(ID.FEAR, dc, WISDOM)) {
                                    target.RemoveEffect(SPELL_FEAR);
                                    target.RemoveCondition(ConditionType.FRIGHTENED);
                                    return true;
                                }
                            }
                            return false;
                        });

                        GlobalEvents.AffectBySpell(caster, ID.FEAR, target, true);
                    }
                });
            }
        }
        public static Spell Fireball {
            get {
                return new Spell(ID.FIREBALL, EVOCATION, THIRD, CastingTime.ONE_ACTION, 150, VSM, INSTANTANEOUS, 20, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    // 8d6 base + 1d6 for each level above 3rd
                    Dice damage = DiceSlotScaling(THIRD, slot, D6, 8);

                    foreach (Combattant target in targets) {
                        GlobalEvents.AffectBySpell(caster, ID.FIREBALL, target, true);
                        target.TakeDamage(new DamageSource(ID.FIREBALL, caster), FIRE, damage, HALVES_DAMAGE, dc, DEXTERITY, out _);
                        // TODO: The fire spreads around corners. It ignites flammable objects in the area that aren’t being worn or carried.
                    }
                });
            }
        }
        // TODO: Requires flying movement mechanic for full effect
        public static Spell Fly {
            get {
                return new Spell(ID.FLY, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 0, VSM, TEN_MINUTES, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    GlobalEvents.AffectBySpell(caster, ID.FLY, target, true);
                    AddEffectsForDuration(ID.FLY, caster, target, TEN_MINUTES, SPELL_FLY);
                });
            }
        }
        // TODO: Requires gaseous movement/resistance mechanics for full effect
        public static Spell GaseousForm {
            get {
                return new Spell(ID.GASEOUS_FORM, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    GlobalEvents.AffectBySpell(caster, ID.GASEOUS_FORM, caster, true);
                    AddEffectsForDuration(ID.GASEOUS_FORM, caster, caster, ONE_HOUR, SPELL_GASEOUS_FORM);
                });
            }
        }
        /* TODO */
        public static Spell GlyphofWarding {
            get {
                return new Spell(ID.GLYPH_OF_WARDING, ABJURATION, THIRD, CastingTime.ONE_HOUR, 0, VSM, UNTIL_DISPELLED, 0, 0, doNothing);
            }
        }
        public static Spell Haste {
            get {
                return new Spell(ID.HASTE, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 30, VSM, ONE_MINUTE, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    GlobalEvents.AffectBySpell(caster, ID.HASTE, target, true);
                    AddEffectsForDuration(ID.HASTE, caster, target, ONE_MINUTE, SPELL_HASTE);
                });
            }
        }
        // TODO: Only creatures that can see the pattern should be affected (sight/blindness not modelled).
        // TODO: Another creature should be able to spend an action to shake an affected creature awake (no such action mechanic yet).
        public static Spell HypnoticPattern {
            get {
                return new Spell(ID.HYPNOTIC_PATTERN, ILLUSION, THIRD, CastingTime.ONE_ACTION, 120, SM, ONE_MINUTE, 30, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    foreach (Combattant target in targets) {
                        // Wisdom saving throw to resist the pattern
                        if (target.DC(ID.HYPNOTIC_PATTERN, dc, WISDOM)) {
                            GlobalEvents.AffectBySpell(caster, ID.HYPNOTIC_PATTERN, target, false);
                            continue;
                        }
                        GlobalEvents.AffectBySpell(caster, ID.HYPNOTIC_PATTERN, target, true);

                        // While charmed by this spell, the creature is incapacitated and has a speed of 0
                        Combattant affected = target;
                        int originalSpeed = affected.Speed;
                        affected.Speed = 0;
                        affected.AddCondition(ConditionType.CHARMED, ConditionType.INCAPACITATED);
                        affected.AddEffect(SPELL_HYPNOTIC_PATTERN);

                        bool ended = false;
                        // Local teardown: restore speed, remove conditions and effect exactly once
                        Func<bool> end = delegate () {
                            if (ended) return true;
                            ended = true;
                            affected.Speed = originalSpeed;
                            affected.RemoveCondition(ConditionType.CHARMED, ConditionType.INCAPACITATED);
                            affected.RemoveEffect(SPELL_HYPNOTIC_PATTERN);
                            return true;
                        };

                        // The spell ends for an affected creature if it takes any damage
                        affected.AddDamageTakenEvent(delegate (DamageSource source, Damage damage) {
                            if (ended) return true;
                            return end();
                        });

                        // Duration handling (also ends if the effect was removed externally, e.g. by Dispel Magic)
                        int remainingRounds = (int)ONE_MINUTE;
                        affected.AddEndOfTurnEvent(delegate () {
                            if (ended) return true;
                            if (!affected.HasEffect(SPELL_HYPNOTIC_PATTERN) || --remainingRounds < 1) {
                                return end();
                            }
                            return false;
                        });
                    }
                });
            }
        }
        public static Spell LightningBolt {
            get {
                return new Spell(ID.LIGHTNING_BOLT, EVOCATION, THIRD, CastingTime.ONE_ACTION, 0, VSM, INSTANTANEOUS, 100, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    // 8d6 base + 1d6 for each level above 3rd
                    Dice damage = DiceSlotScaling(THIRD, slot, D6, 8);

                    foreach (Combattant target in targets) {
                        GlobalEvents.AffectBySpell(caster, ID.LIGHTNING_BOLT, target, true);
                        target.TakeDamage(new DamageSource(ID.LIGHTNING_BOLT, caster), LIGHTNING, damage, HALVES_DAMAGE, dc, DEXTERITY, out _);
                        // TODO: The lightning ignites flammable objects in the area that aren’t being worn or carried.
                    }
                });
            }
        }
        /* TODO */
        public static Spell MagicCircle {
            get {
                return new Spell(ID.MAGIC_CIRCLE, ABJURATION, THIRD, CastingTime.ONE_MINUTE, 10, VSM, ONE_HOUR, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MajorImage {
            get {
                return new Spell(ID.MAJOR_IMAGE, ILLUSION, THIRD, CastingTime.ONE_ACTION, 120, VSM, TEN_MINUTES, 0, 0, doNothing);
            }
        }
        public static Spell MassHealingWord {
            get {
                return new Spell(ID.MASS_HEALING_WORD, EVOCATION, THIRD, CastingTime.BONUS_ACTION, 60, V, INSTANTANEOUS, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    // 1d4 per level above 1st (3rd level = 3d4 base)
                    foreach (Combattant target in targets) {
                        if (target is Monster monster) {
                            if (monster.Type == Monsters.Type.CONSTRUCT || monster.Type == Monsters.Type.UNDEAD) {
                                GlobalEvents.AffectBySpell(caster, ID.MASS_HEALING_WORD, target, false);
                                continue;
                            }
                        }
                        Dice dice = DiceSlotScaling(FIRST, slot, D4, 1, modifier);
                        GlobalEvents.AffectBySpell(caster, ID.MASS_HEALING_WORD, target, true);
                        target.HealDamage(dice);
                    }
                });
            }
        }
        // TODO: Requires stone-merging mechanics for full effect
        public static Spell MeldIntoStone {
            get {
                return new Spell(ID.MELD_INTO_STONE, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 0, VS, EIGHT_HOURS, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    GlobalEvents.AffectBySpell(caster, ID.MELD_INTO_STONE, caster, true);
                    AddEffectsForDuration(ID.MELD_INTO_STONE, caster, caster, EIGHT_HOURS, SPELL_MELD_INTO_STONE);
                });
            }
        }
        // TODO: Requires divination-blocking mechanics for full effect
        public static Spell Nondetection {
            get {
                return new Spell(ID.NONDETECTION, ABJURATION, THIRD, CastingTime.ONE_ACTION, 0, VSM, EIGHT_HOURS, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    GlobalEvents.AffectBySpell(caster, ID.NONDETECTION, target, true);
                    AddEffectsForDuration(ID.NONDETECTION, caster, target, EIGHT_HOURS, SPELL_NONDETECTION);
                });
            }
        }
        /* TODO */
        public static Spell PhantomSteed {
            get {
                return new Spell(ID.PHANTOM_STEED, ILLUSION, THIRD, CastingTime.ONE_MINUTE, 30, VS, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PlantGrowth {
            get {
                return new Spell(ID.PLANT_GROWTH, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 150, VS, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        public static Spell ProtectionFromEnergy {
            get {
                Spell protection = new Spell(ID.PROTECTION_FROM_ENERGY, ABJURATION, THIRD, CastingTime.ONE_ACTION, 0, VS, ONE_HOUR, 0, 0);
                protection.Variants = new SpellVariant[] {
                    DAMAGE_ACID,
                    DAMAGE_COLD,
                    DAMAGE_FIRE,
                    DAMAGE_LIGHTNING,
                    DAMAGE_THUNDER
                };
                SpellCastEffect castEffect = delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    GlobalEvents.AffectBySpell(caster, ID.PROTECTION_FROM_ENERGY, target, true);

                    // Map variant to resistance effect
                    Effect resistanceEffect = RESISTANCE_FIRE;
                    switch (protection.Variant) {
                        case DAMAGE_ACID:
                            resistanceEffect = RESISTANCE_ACID;
                            break;
                        case DAMAGE_COLD:
                            resistanceEffect = RESISTANCE_COLD;
                            break;
                        case DAMAGE_FIRE:
                            resistanceEffect = RESISTANCE_FIRE;
                            break;
                        case DAMAGE_LIGHTNING:
                            resistanceEffect = RESISTANCE_LIGHTNING;
                            break;
                        case DAMAGE_THUNDER:
                            resistanceEffect = RESISTANCE_THUNDER;
                            break;
                    }
                    AddEffectsForDuration(ID.PROTECTION_FROM_ENERGY, caster, target, ONE_HOUR, SPELL_PROTECTION_FROM_ENERGY, resistanceEffect);
                };
                protection.CastEffect = castEffect;
                return protection;
            }
        }
        public static Spell RemoveCurse {
            get {
                return new Spell(ID.REMOVE_CURSE, ABJURATION, THIRD, CastingTime.ONE_ACTION, 0, VS, INSTANTANEOUS, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    bool affected = false;

                    // Try to remove any curse effect
                    foreach (Effect effect in target.Effects) {
                        if (effect.IsCurse()) {
                            target.RemoveEffect(effect);
                            affected = true;
                        }
                    }

                    // TODO:  If the object is a cursed magic item, its curse remains, but the spell breaks its owner’s attunement to the object so it can be removed or discarded.

                    GlobalEvents.AffectBySpell(caster, ID.REMOVE_CURSE, target, affected);
                });
            }
        }
        public static Spell Revivify {
            get {
                return new Spell(ID.REVIVIFY, NECROMANCY, THIRD, CastingTime.ONE_ACTION, 0, VSM, INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    // Only dead creatures can be targeted
                    if (!target.Dead) {
                        GlobalEvents.AffectBySpell(caster, ID.REVIVIFY, target, false);
                        return;
                    }
                    // TODO: Spell does not affect creatures that have died of old age or have been dead for more than 1 minute
                    // Revivify the target and restore 1 hit point
                    GlobalEvents.AffectBySpell(caster, ID.REVIVIFY, target, true);
                    target.Dead = false;
                    target.HitPoints = 1;
                });
            }
        }
        /* TODO */
        public static Spell Sending {
            get {
                return new Spell(ID.SENDING, EVOCATION, THIRD, CastingTime.ONE_ACTION, -1, VSM, ONE_ROUND, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell SleetStorm {
            get {
                return new Spell(ID.SLEET_STORM, CONJURATION, THIRD, CastingTime.ONE_ACTION, 150, VSM, ONE_MINUTE, 40, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    GlobalEvents.AffectBySpell(caster, ID.SLEET_STORM, caster, true);

                    // Create the sleet storm effect for each target in the area
                    foreach (Combattant target in targets) {
                        // Dexterity saving throw to avoid falling prone when entering or starting turn in area
                        if (target.DC(ID.SLEET_STORM, dc, DEXTERITY)) {
                            GlobalEvents.AffectBySpell(caster, ID.SLEET_STORM, target, false);
                            continue;
                        }

                        GlobalEvents.AffectBySpell(caster, ID.SLEET_STORM, target, true);
                        target.AddCondition(ConditionType.PRONE);
                        target.AddEffect(SPELL_SLEET_STORM);

                        // At the start of each turn, creature must make DEX save or fall prone again if affected
                        target.AddStartOfTurnEvent(delegate () {
                            if (!target.HasEffect(SPELL_SLEET_STORM)) return true;
                            if (!target.DC(ID.SLEET_STORM, dc, DEXTERITY)) {
                                if (!target.HasCondition(ConditionType.PRONE)) {
                                    target.AddCondition(ConditionType.PRONE);
                                }
                            }
                            return false;
                        });
                    }

                    // Duration handling - spell lasts up to 1 minute with concentration
                    int remainingRounds = (int)ONE_MINUTE;
                    caster.AddEndOfTurnEvent(delegate () {
                        if (--remainingRounds < 1) {
                            // Remove spell effect from all affected creatures
                            foreach (Combattant target in targets) {
                                target.RemoveEffect(SPELL_SLEET_STORM);
                            }
                            return true;
                        }
                        return false;
                    });
                });
            }
        }
        public static Spell Slow {
            get {
                return new Spell(ID.SLOW, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 120, VSM, ONE_MINUTE, 40, 6, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    foreach (Combattant target in targets) {
                        if (target.DC(ID.SLOW, dc, WISDOM)) {
                            GlobalEvents.AffectBySpell(caster, ID.SLOW, target, false);
                            continue;
                        }
                        GlobalEvents.AffectBySpell(caster, ID.SLOW, target, true);
                        AddEffectsForDuration(ID.SLOW, caster, target, ONE_MINUTE, SPELL_SLOW);
                    }
                });
            }
        }
        /* TODO */
        public static Spell SpeakwithDead {
            get {
                return new Spell(ID.SPEAK_WITH_DEAD, NECROMANCY, THIRD, CastingTime.ONE_ACTION, 10, VSM, TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell SpeakwithPlants {
            get {
                return new Spell(ID.SPEAK_WITH_PLANTS, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 0, VS, TEN_MINUTES, 30, 0, doNothing);
            }
        }
        public static Spell SpiritGuardians {
            get {
                return new Spell(ID.SPIRIT_GUARDIANS, CONJURATION, THIRD, CastingTime.ONE_ACTION, 0, VSM, TEN_MINUTES, 15, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    // Damage type depends on caster alignment: evil → necrotic, good or neutral → radiant
                    DamageType damageType = caster.Alignment.IsEvil() ? NECROTIC : RADIANT;

                    foreach (Combattant target in targets) {
                        // The caster is always unaffected
                        if (target == caster) continue;

                        GlobalEvents.AffectBySpell(caster, ID.SPIRIT_GUARDIANS, target, true);

                        // Halve the target's speed for the duration via the effect Apply/Unapply system
                        AddEffectsForDuration(ID.SPIRIT_GUARDIANS, caster, target, TEN_MINUTES, SPELL_SPIRIT_GUARDIANS);

                        // Apply damage on the initial cast (creature enters the area)
                        target.TakeDamage(new DamageSource(ID.SPIRIT_GUARDIANS, caster), damageType, new Dice("3d8"), HALVES_DAMAGE, dc, WISDOM, out _);

                        // At the start of each of the target's turns while the effect persists, re-apply the damage
                        target.AddStartOfTurnEvent(delegate () {
                            // Effect removed (dispelled or duration expired) — stop
                            if (!target.HasEffect(SPELL_SPIRIT_GUARDIANS)) return true;
                            // Still in range: deal damage with WIS save for half
                            // TODO: Remove effect when target moves outside the 15-foot radius
                            target.TakeDamage(new DamageSource(ID.SPIRIT_GUARDIANS, caster), damageType, new Dice("3d8"), HALVES_DAMAGE, dc, WISDOM, out _);
                            return false;
                        });
                    }
                });
            }
        }
        
        public static Spell StinkingCloud {
            get {
                return new Spell(ID.STINKING_CLOUD, CONJURATION, THIRD, CastingTime.ONE_ACTION, 90, VSM, ONE_MINUTE, 20, 20,
                    delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        GlobalEvents.AffectBySpell(caster, ID.STINKING_CLOUD, caster, true);

                        foreach (Combattant target in targets) {
                            // Creatures that don't need to breathe (undead, constructs) or are immune to poison automatically succeed
                            bool immuneToEffect = target.HasEffect(IMMUNITY_POISON) || target.HasEffect(IMMUNITY_POISONED);
                            if (!immuneToEffect && target is Monster poisonMonster) {
                                if (poisonMonster.Type == Monsters.Type.UNDEAD || poisonMonster.Type == Monsters.Type.CONSTRUCT) {
                                    immuneToEffect = true;
                                }
                            }

                            if (immuneToEffect) {
                                GlobalEvents.AffectBySpell(caster, ID.STINKING_CLOUD, target, false);
                                continue;
                            }

                            // Mark this creature as being in the cloud
                            GlobalEvents.AffectBySpell(caster, ID.STINKING_CLOUD, target, true);
                            target.AddEffect(SPELL_STINKING_CLOUD);

                            // At the start of each turn inside the cloud, make a CON save vs poison
                            target.AddStartOfTurnEvent(delegate () {
                                if (!target.HasEffect(SPELL_STINKING_CLOUD)) return true;

                                if (!target.DC(ID.STINKING_CLOUD, dc, CONSTITUTION)) {
                                    // Failed save: spends action retching and reeling
                                    target.AddEffect(CANNOT_TAKE_ACTIONS);
                                    target.AddEndOfTurnEvent(delegate () {
                                        target.RemoveEffect(CANNOT_TAKE_ACTIONS);
                                        return true;
                                    });
                                }
                                return false;
                            });

                            // TODO: Add logic to remove effect when target moves outside the cloud
                        }

                        // Duration: cloud lingers for 1 minute
                        int remainingRounds = (int)ONE_MINUTE;
                        caster.AddEndOfTurnEvent(delegate () {
                            if (--remainingRounds < 1) {
                                foreach (Combattant target in targets) {
                                    target.RemoveEffect(SPELL_STINKING_CLOUD);
                                }
                                return true;
                            }
                            return false;
                        });
                    });
            }
        }
        /* TODO */
        public static Spell TinyHut {
            get {
                return new Spell(ID.TINY_HUT, EVOCATION, THIRD, CastingTime.ONE_MINUTE, 0, VSM, EIGHT_HOURS, 10, 0, doNothing);
            }
        }
        // TODO: Requires language comprehension mechanics for full effect
        public static Spell Tongues {
            get {
                return new Spell(ID.TONGUES, DIVINATION, THIRD, CastingTime.ONE_ACTION, 0, VM, ONE_HOUR, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    GlobalEvents.AffectBySpell(caster, ID.TONGUES, target, true);
                    AddEffectsForDuration(ID.TONGUES, caster, target, ONE_HOUR, SPELL_TONGUES);
                });
            }
        }
        public static Spell VampiricTouch {
            get {
                return new Spell(ID.VAMPIRIC_TOUCH, NECROMANCY, THIRD, CastingTime.ONE_ACTION, 0, VS, ONE_MINUTE, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    GlobalEvents.AffectBySpell(caster, ID.VAMPIRIC_TOUCH, caster, true);

                    // Damage scaling: 3d6 base + 1d6 for each level above 3rd
                    Dice damageDice = DiceSlotScaling(THIRD, slot, D6, 3);

                    // Create a temporary cantrip-like spell for making melee spell attacks during the duration
                    Spell vampiricTouchAttack = new Spell(ID.VAMPIRIC_TOUCH_ATTACK, NECROMANCY, CANTRIP, CastingTime.ONE_ACTION, 0, VS, INSTANTANEOUS, 0, 1,
                        delegate (Battleground ground2, Combattant caster2, int dc2, SpellLevel slot2, int modifier2, Combattant[] targets2) {
                            foreach (Combattant target in targets2) {
                                // Make a melee spell attack against the target (attack roll must meet or exceed AC)
                                int attackRoll = D20.Value + modifier2;
                                if (attackRoll >= target.ArmorClass) {
                                    GlobalEvents.AffectBySpell(caster2, ID.VAMPIRIC_TOUCH_ATTACK, target, true);
                                    // Roll damage and apply it
                                    int damageDealt = damageDice.Roll();
                                    target.TakeDamage(new DamageSource(ID.VAMPIRIC_TOUCH_ATTACK, caster2), NECROTIC, damageDice);
                                    // Heal caster for half the damage dealt
                                    int healAmount = damageDealt / 2;
                                    caster2.HitPoints = Math.Min(caster2.HitPoints + healAmount, caster2.HitPointsMax);
                                } else {
                                    GlobalEvents.AffectBySpell(caster2, ID.VAMPIRIC_TOUCH_ATTACK, target, false);
                                }
                            }
                        });

                    caster.AvailableSpells[0].AddKnownSpell(vampiricTouchAttack);
                    caster.AvailableSpells[0].AddPreparedSpell(vampiricTouchAttack);

                    // Handle duration removal
                    int remainingRounds = (int)ONE_MINUTE;
                    caster.AddEndOfTurnEvent(delegate () {
                        if (--remainingRounds < 1) {
                            caster.AvailableSpells[0].RemoveKnownSpell(vampiricTouchAttack);
                            caster.AvailableSpells[0].RemovePreparedSpell(vampiricTouchAttack);
                            return true;
                        } else {
                            return false;
                        }
                    });

                    // execute the initial attack as part of the casting
                    vampiricTouchAttack.CastEffect(ground, caster, dc, slot, modifier, targets);
                });
            }
        }
        // TODO: Requires underwater breathing mechanics for full effect
        public static Spell WaterBreathing {
            get {
                return new Spell(ID.WATER_BREATHING, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 30, VSM, ONE_DAY, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    foreach (Combattant target in targets) {
                        GlobalEvents.AffectBySpell(caster, ID.WATER_BREATHING, target, true);
                        AddEffectsForDuration(ID.WATER_BREATHING, caster, target, ONE_DAY, SPELL_WATER_BREATHING);
                    }
                });
            }
        }
        // TODO: Requires liquid-surface traversal mechanics for full effect
        public static Spell WaterWalk {
            get {
                return new Spell(ID.WATER_WALK, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 30, VSM, ONE_HOUR, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    foreach (Combattant target in targets) {
                        GlobalEvents.AffectBySpell(caster, ID.WATER_WALK, target, true);
                        AddEffectsForDuration(ID.WATER_WALK, caster, target, ONE_HOUR, SPELL_WATER_WALK);
                    }
                });
            }
        }
        public static Spell WindWall {
            get {
                return new Spell(ID.WIND_WALL, EVOCATION, THIRD, CastingTime.ONE_ACTION, 120, VSM, ONE_MINUTE, 50, 20, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    foreach (Combattant target in targets) {
                        GlobalEvents.AffectBySpell(caster, ID.WIND_WALL, target, true);
                        target.TakeDamage(new DamageSource(ID.WIND_WALL, caster), BLUDGEONING, new Dice("3d8"), HALVES_DAMAGE, dc, STRENGTH, out _);
                    }
                });
            }
        }
    }
}

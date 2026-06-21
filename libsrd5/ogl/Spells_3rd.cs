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
                return new Spell(ID.ANIMATE_DEAD, NECROMANCY, THIRD, CastingTime.ONE_MINUTE, 10, VSM, INSTANTANEOUS, 0, 13, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // TODO: Targetting bone piles to create skeletons requires objects on the battleground that aren't combatants
                    int maxTargets = ((int)slot - 3) * 2 + 1;
                    for (int i = 0; i < maxTargets && i < targets.Length; i++) {
                        Combatant target = targets[i];
                        // Only dead, small or medium humanoids can be targetted
                        if (target.Dead && (target.Size == Size.MEDIUM || target.Size == Size.SMALL) && (target is CharacterSheet || ((Monster)target).Type == Monsters.Type.HUMANOID)) {
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
                                Coord location = battleground2D.LocateCombatant2D(target);
                                battleground2D.AddCombatant(Monsters.Zombie, location.X, location.Y);
                                // TODO: Add logic to put the Zombie under the caster's control
                            } else if (ground is BattleGroundClassic battleGroundClassic) {
                                ClassicLocation location = battleGroundClassic.LocateClassicCombatant(target);
                                battleGroundClassic.AddCombatant(Monsters.Zombie, location.Location);
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
                return new Spell(ID.BEACON_OF_HOPE, ABJURATION, THIRD, CastingTime.ONE_ACTION, 30, VS, ONE_MINUTE, 0, 20, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    foreach (Combatant target in targets) {
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
                curse.Variant = TAKE_ADDITIONAL_DAMAGE;
                SpellCastEffect castEffect = delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
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
                                if (source.Origin is ID && (ID)source.Origin == ID.BESTOW_CURSE) return false; // prevent recursion
                                if (source.Origin.Equals(caster)) {
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
                return new Spell(ID.BLINK, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 0, VS, ONE_MINUTE, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
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
                return new Spell(ID.CALL_LIGHTNING, CONJURATION, THIRD, CastingTime.ONE_ACTION, 120, VS, TEN_MINUTES, 5, 9, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // This is modelled by creating a Cantrip that the caster can use. After the Duration, the cantrip is removed
                    Dice dice = DiceSlotScaling(THIRD, slot, D10, 1);
                    Damage damage = new Damage(LIGHTNING, dice);
                    foreach (Combatant target in targets) {
                        GlobalEvents.AffectBySpell(caster, ID.CALL_LIGHTNING, target, true);
                        target.TakeDamage(new DamageSource(ID.CALL_LIGHTNING, caster), LIGHTNING, dice, HALVES_DAMAGE, dc, DEXTERITY, out _);
                    }
                    // TODO: This cantrip workaround should be replaced by correctly implementing situative actions
                    Spell lightningCantrip = new Spell(ID.CALL_LIGHTNING_ATTACK, CONJURATION, CANTRIP, CastingTime.ONE_ACTION, 120, V, INSTANTANEOUS, 5, 9, delegate (Battleground ground2, Combatant caster2, int dc2, SpellLevel slot2, int modifier2, Combatant[] targets2) {
                        foreach (Combatant target2 in targets2) {
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
                    delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        AddEffectsForDuration(ID.CLAIRVOYANCE, caster, caster, TEN_MINUTES, SPELL_CLAIRVOYANCE);
                    }
                );
            }
        }

        public static Spell ConjureAnimals {
            get {
                Spell conjure = new Spell(ID.CONJURE_ANIMALS, CONJURATION, THIRD, CastingTime.ONE_ACTION, 60, VS, ONE_HOUR, 0, 0);
                conjure.Variants = new SpellVariant[] { CR_QUARTER, CR_HALF, CR_ONE, CR_TWO };
                conjure.Variant = CR_TWO;
                SpellCastEffect effect = delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Monsters.ID[] randomBeasts;
                    int beastAmount;
                    switch (conjure.Variant) {
                        case CR_QUARTER:
                            randomBeasts = new Monsters.ID[] {
                                Monsters.ID.AXE_BEAK, Monsters.ID.BOAR, Monsters.ID.CONSTRICTOR_SNAKE, Monsters.ID.DRAFT_HORSE, Monsters.ID.ELK, Monsters.ID.GIANT_BADGER, Monsters.ID.GIANT_BAT, Monsters.ID.GIANT_CENTIPEDE, Monsters.ID.GIANT_FROG, Monsters.ID.GIANT_LIZARD, Monsters.ID.GIANT_OWL, Monsters.ID.GIANT_POISONOUS_SNAKE, Monsters.ID.GIANT_WOLF_SPIDER, Monsters.ID.PANTHER, Monsters.ID.RIDING_HORSE, Monsters.ID.WOLF
                            };
                            beastAmount = 8;
                            break;
                        case CR_HALF:
                            randomBeasts = new Monsters.ID[] {
                                Monsters.ID.APE, Monsters.ID.BLACK_BEAR, Monsters.ID.CROCODILE, Monsters.ID.GIANT_GOAT, Monsters.ID.GIANT_WASP, Monsters.ID.WARHORSE
                            };
                            beastAmount = 4;
                            break;
                        case CR_ONE:
                            randomBeasts = new Monsters.ID[] {
                               Monsters.ID.BROWN_BEAR, Monsters.ID.DIRE_WOLF, Monsters.ID.GIANT_EAGLE, Monsters.ID.GIANT_HYENA, Monsters.ID.GIANT_SPIDER, Monsters.ID.GIANT_TOAD, Monsters.ID.GIANT_VULTURE, Monsters.ID.LION, Monsters.ID.TIGER
                            };
                            beastAmount = 2;
                            break;
                        case CR_TWO:
                        default:
                            randomBeasts = new Monsters.ID[] {
                                Monsters.ID.GIANT_BOAR, Monsters.ID.GIANT_CONSTRICTOR_SNAKE, Monsters.ID.GIANT_ELK, Monsters.ID.POLAR_BEAR, Monsters.ID.RHINOCEROS, Monsters.ID.SABER_TOOTHED_TIGER
                            };
                            beastAmount = 1;
                            break;
                    }
                    if (slot > SIXTH)
                        beastAmount *= 3;
                    else if (slot > FOURTH)
                        beastAmount *= 2;
                    for (int i = 0; i < beastAmount; i++) {
                        if (ground is Battleground2D battleground2D) {
                            Coord location = battleground2D.LocateCombatant2D(caster);
                            battleground2D.AddCombatantNextTo(Monsters.Get(randomBeasts[D20.Value % randomBeasts.Length]), location.X, location.Y);
                        } else if (ground is BattleGroundClassic battleGroundClassic) {
                            ClassicLocation location = battleGroundClassic.LocateClassicCombatant(caster);
                            battleGroundClassic.AddCombatant(Monsters.Get(randomBeasts[D20.Value % randomBeasts.Length]), location.Location);
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
                return new Spell(ID.DISPEL_MAGIC, ABJURATION, THIRD, CastingTime.ONE_ACTION, 120, VS, INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
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
                return new Spell(ID.FEAR, ILLUSION, THIRD, CastingTime.ONE_ACTION, 0, VSM, ONE_MINUTE, 30, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    foreach (Combatant target in targets) {
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
                            if (ground.LocateCombatant(target).Distance(ground.LocateCombatant(caster)) > 300) {
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
                return new Spell(ID.FIREBALL, EVOCATION, THIRD, CastingTime.ONE_ACTION, 150, VSM, INSTANTANEOUS, 20, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // 8d6 base + 1d6 for each level above 3rd
                    Dice damage = DiceSlotScaling(THIRD, slot, D6, 8);

                    foreach (Combatant target in targets) {
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
                return new Spell(ID.FLY, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 0, VSM, TEN_MINUTES, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    GlobalEvents.AffectBySpell(caster, ID.FLY, target, true);
                    AddEffectsForDuration(ID.FLY, caster, target, TEN_MINUTES, SPELL_FLY);
                });
            }
        }
        // TODO: Requires gaseous movement/resistance mechanics for full effect
        public static Spell GaseousForm {
            get {
                return new Spell(ID.GASEOUS_FORM, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    GlobalEvents.AffectBySpell(caster, ID.GASEOUS_FORM, caster, true);
                    AddEffectsForDuration(ID.GASEOUS_FORM, caster, caster, ONE_HOUR, SPELL_GASEOUS_FORM);
                });
            }
        }
        /* TODO:
        When you cast this spell, you inscribe a glyph that harms other creatures, either upon a surface (such as a table or a section of floor or wall) or within an object that can be closed (such as a book, a scroll, or a treasure chest) to conceal the glyph. If you choose a surface, the glyph can cover an area of the surface no larger than 10 feet in diameter. If you choose an object, that object must remain in its place; if the object is moved more than 10 feet from where you cast this spell, the glyph is broken, and the spell ends without being triggered.
        The glyph is nearly invisible and requires a successful Intelligence (Investigation) check against your spell save DC to be found.
        You decide what triggers the glyph when you cast the spell. For glyphs inscribed on a surface, the most typical triggers include touching or standing on the glyph, removing another object covering the glyph, approaching within a certain distance of the glyph, or manipulating the object on which the glyph is inscribed. For glyphs inscribed within an object, the most common triggers include opening that object, approaching within a certain distance of the object, or seeing or reading the glyph. Once a glyph is triggered, this spell ends.
        You can further refine the trigger so the spell activates only under certain circumstances or according to physical characteristics (such as height or weight), creature kind (for example, the ward could be set to affect aberrations or drow), or alignment. You can also set conditions for creatures that don't trigger the glyph, such as those who say a certain password.
        When you inscribe the glyph, choose explosive runes or a spell glyph.
        Explosive Runes. When triggered, the glyph erupts with magical energy in a 20-foot-radius sphere centered on the glyph. The sphere spreads around corners. Each creature in the area must make a Dexterity saving throw. A creature takes 5d8 acid, cold, fire, lightning, or thunder damage on a failed saving throw (your choice when you create the glyph), or half as much damage on a successful one.
        Spell Glyph. You can store a prepared spell of 3rd level or lower in the glyph by casting it as part of creating the glyph. The spell must target a single creature or an area. The spell being stored has no immediate effect when cast in this way. When the glyph is triggered, the stored spell is cast. If the spell has a target, it targets the creature that triggered the glyph. If the spell affects an area, the area is centered on that creature. If the spell summons hostile creatures or creates harmful objects or traps, they appear as close as possible to the intruder and attack it. If the spell requires concentration, it lasts until the end of its full duration.

        At Higher Levels. When you cast this spell using a spell slot of 4th level or higher, the damage of an explosive runes glyph increases by 1d8 for each slot level above 3rd. If you create a spell glyph, you can store any spell of up to the same level as the slot you use for the glyph of warding.         
        */
        public static Spell GlyphofWarding {
            get {
                return new Spell(ID.GLYPH_OF_WARDING, ABJURATION, THIRD, CastingTime.ONE_HOUR, 0, VSM, UNTIL_DISPELLED, 0, 0, doNothing);
            }
        }
        public static Spell Haste {
            get {
                return new Spell(ID.HASTE, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 30, VSM, ONE_MINUTE, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    GlobalEvents.AffectBySpell(caster, ID.HASTE, target, true);
                    AddEffectsForDuration(ID.HASTE, caster, target, ONE_MINUTE, SPELL_HASTE);
                });
            }
        }
        // TODO: Only creatures that can see the pattern should be affected (sight/blindness not modelled).
        // TODO: Another creature should be able to spend an action to shake an affected creature awake (no such action mechanic yet).
        public static Spell HypnoticPattern {
            get {
                return new Spell(ID.HYPNOTIC_PATTERN, ILLUSION, THIRD, CastingTime.ONE_ACTION, 120, SM, ONE_MINUTE, 30, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    foreach (Combatant target in targets) {
                        // Wisdom saving throw to resist the pattern
                        if (target.DC(ID.HYPNOTIC_PATTERN, dc, WISDOM)) {
                            GlobalEvents.AffectBySpell(caster, ID.HYPNOTIC_PATTERN, target, false);
                            continue;
                        }
                        GlobalEvents.AffectBySpell(caster, ID.HYPNOTIC_PATTERN, target, true);

                        // While charmed by this spell, the creature is incapacitated
                        Combatant affected = target;
                        affected.AddCondition(ConditionType.CHARMED, ConditionType.INCAPACITATED);
                        affected.AddEffect(SPELL_HYPNOTIC_PATTERN);

                        bool ended = false;
                        // The spell ends for an affected creature if it takes any damage
                        affected.AddDamageTakenEvent(delegate (DamageSource source, Damage damage) {
                            if (ended) return true;
                            ended = true;
                            affected.RemoveCondition(ConditionType.CHARMED, ConditionType.INCAPACITATED);
                            affected.RemoveEffect(SPELL_HYPNOTIC_PATTERN);
                            return true;
                        });

                        // Duration handling (also ends if the effect was removed externally, e.g. by Dispel Magic)
                        int remainingRounds = (int)ONE_MINUTE;
                        affected.AddEndOfTurnEvent(delegate () {
                            if (ended) return true;
                            if (!affected.HasEffect(SPELL_HYPNOTIC_PATTERN) || --remainingRounds < 1) {
                                ended = true;
                                affected.RemoveCondition(ConditionType.CHARMED, ConditionType.INCAPACITATED);
                                affected.RemoveEffect(SPELL_HYPNOTIC_PATTERN);
                                return true;
                            }
                            return false;
                        });
                    }
                });
            }
        }
        public static Spell LightningBolt {
            get {
                return new Spell(ID.LIGHTNING_BOLT, EVOCATION, THIRD, CastingTime.ONE_ACTION, 0, VSM, INSTANTANEOUS, 100, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // 8d6 base + 1d6 for each level above 3rd
                    Dice damage = DiceSlotScaling(THIRD, slot, D6, 8);

                    foreach (Combatant target in targets) {
                        GlobalEvents.AffectBySpell(caster, ID.LIGHTNING_BOLT, target, true);
                        target.TakeDamage(new DamageSource(ID.LIGHTNING_BOLT, caster), LIGHTNING, damage, HALVES_DAMAGE, dc, DEXTERITY, out _);
                        // TODO: The lightning ignites flammable objects in the area that aren’t being worn or carried.
                    }
                });
            }
        }
        /* TODO:
        You create a 10-foot-radius, 20-foot-tall cylinder of magical energy centered on a point on the ground that you can see within range. Glowing runes appear wherever the cylinder intersects with the floor or other surface.
        Choose one or more of the following types of creatures: celestials, elementals, fey, fiends, or undead. The circle affects a creature of the chosen type in the following ways:

        The creature can't willingly enter the cylinder by nonmagical means. If the creature tries to use teleportation or interplanar travel to do so, it must first succeed on a Charisma saving throw.
        The creature has disadvantage on attack rolls against targets within the cylinder.
        Targets within the cylinder can't be charmed, frightened, or possessed by the creature.

        When you cast this spell, you can elect to cause its magic to operate in the reverse direction, preventing a creature of the specified type from leaving the cylinder and protecting targets outside it.

        At Higher Levels. When you cast this spell using a spell slot of 4th level or higher, the duration increases by 1 hour for each slot level above 3rd.
         */
        public static Spell MagicCircle {
            get {
                return new Spell(ID.MAGIC_CIRCLE, ABJURATION, THIRD, CastingTime.ONE_MINUTE, 10, VSM, ONE_HOUR, 10, 0, doNothing);
            }
        }
        /* TODO:
        You create the image of an object, a creature, or some other visible phenomenon that is no larger than a 20-foot cube. The image appears at a spot that you can see within range and lasts for the duration. It seems completely real, including sounds, smells, and temperature appropriate to the thing depicted. You can't create sufficient heat or cold to cause damage, a sound loud enough to deal thunder damage or deafen a creature, or a smell that might sicken a creature (like a troglodyte's stench).
        As long as you are within range of the illusion, you can use your action to cause the image to move to any other spot within range. As the image changes location, you can alter its appearance so that its movements appear natural for the image. For example, if you create an image of a creature and move it, you can alter the image so that it appears to be walking. Similarly, you can cause the illusion to make different sounds at different times, even making it carry on a conversation, for example.
        Physical interaction with the image reveals it to be an illusion, because things can pass through it. A creature that uses its action to examine the image can determine that it is an illusion with a successful Intelligence (Investigation) check against your spell save DC. If a creature discerns the illusion for what it is, the creature can see through the image, and its other sensory qualities become faint to the creature.

        At Higher Levels. When you cast this spell using a spell slot of 6th level or higher, the spell lasts until dispelled, without requiring your concentration.         
        */
        public static Spell MajorImage {
            get {
                return new Spell(ID.MAJOR_IMAGE, ILLUSION, THIRD, CastingTime.ONE_ACTION, 120, VSM, TEN_MINUTES, 0, 0, doNothing);
            }
        }
        public static Spell MassHealingWord {
            get {
                return new Spell(ID.MASS_HEALING_WORD, EVOCATION, THIRD, CastingTime.BONUS_ACTION, 60, V, INSTANTANEOUS, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // 1d4 per level above 1st (3rd level = 3d4 base)
                    foreach (Combatant target in targets) {
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
                return new Spell(ID.MELD_INTO_STONE, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 0, VS, EIGHT_HOURS, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    GlobalEvents.AffectBySpell(caster, ID.MELD_INTO_STONE, caster, true);
                    AddEffectsForDuration(ID.MELD_INTO_STONE, caster, caster, EIGHT_HOURS, SPELL_MELD_INTO_STONE);
                });
            }
        }
        // TODO: Requires divination-blocking mechanics for full effect
        public static Spell Nondetection {
            get {
                return new Spell(ID.NONDETECTION, ABJURATION, THIRD, CastingTime.ONE_ACTION, 0, VSM, EIGHT_HOURS, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    GlobalEvents.AffectBySpell(caster, ID.NONDETECTION, target, true);
                    AddEffectsForDuration(ID.NONDETECTION, caster, target, EIGHT_HOURS, SPELL_NONDETECTION);
                });
            }
        }
        /* TODO:
        A Large quasi-real, horselike creature appears on the ground in an unoccupied space of your choice within range. You decide the creature's appearance, but it is equipped with a saddle, bit, and bridle. Any of the equipment created by the spell vanishes in a puff of smoke if it is carried more than 10 feet away from the steed.
        For the duration, you or a creature you choose can ride the steed. The creature uses the statistics for a riding horse, except it has a speed of 100 feet and can travel 10 miles in an hour, or 13 miles at a fast pace. When the spell ends, the steed gradually fades, giving the rider 1 minute to dismount. The spell ends if you use an action to dismiss it or if the steed takes any damage.        
        */
        public static Spell PhantomSteed {
            get {
                return new Spell(ID.PHANTOM_STEED, ILLUSION, THIRD, CastingTime.ONE_MINUTE, 30, VS, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO:
        This spell channels vitality into plants within a specific area. There are two possible uses for the spell, granting either immediate or long-term benefits.
        If you cast this spell using 1 action, choose a point within range. All normal plants in a 100-foot radius centered on that point become thick and overgrown. A creature moving through the area must spend 4 feet of movement for every 1 foot it moves.
        You can exclude one or more areas of any size within the spell's area from being affected.
        If you cast this spell over 8 hours, you enrich the land. All plants in a half-mile radius centered on a point within range become enriched for 1 year. The plants yield twice the normal amount of food when harvested.         
        */
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
                protection.Variant = DAMAGE_FIRE;
                SpellCastEffect castEffect = delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
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
                return new Spell(ID.REMOVE_CURSE, ABJURATION, THIRD, CastingTime.ONE_ACTION, 0, VS, INSTANTANEOUS, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
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
                return new Spell(ID.REVIVIFY, NECROMANCY, THIRD, CastingTime.ONE_ACTION, 0, VSM, INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
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
        /* TODO:
        You send a short message of twenty-five words or less to a creature with which you are familiar. The creature hears the message in its mind, recognizes you as the sender if it knows you, and can answer in a like manner immediately. The spell enables creatures with Intelligence scores of at least 1 to understand the meaning of your message.
        You can send the message across any distance and even to other planes of existence, but if the target is on a different plane than you, there is a 5 percent chance that the message doesn't arrive.         
        */
        public static Spell Sending {
            get {
                return new Spell(ID.SENDING, EVOCATION, THIRD, CastingTime.ONE_ACTION, -1, VSM, ONE_ROUND, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell SleetStorm {
            get {
                return new Spell(ID.SLEET_STORM, CONJURATION, THIRD, CastingTime.ONE_ACTION, 150, VSM, ONE_MINUTE, 40, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    GlobalEvents.AffectBySpell(caster, ID.SLEET_STORM, caster, true);

                    // Create the sleet storm effect for each target in the area
                    foreach (Combatant target in targets) {
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
                                GlobalEvents.AffectBySpell(caster, ID.SLEET_STORM, target, true);
                                target.AddCondition(ConditionType.PRONE);
                            }
                            return false;
                        });
                    }

                    // Duration handling - spell lasts up to 1 minute with concentration
                    int remainingRounds = (int)ONE_MINUTE;
                    caster.AddEndOfTurnEvent(delegate () {
                        if (--remainingRounds < 1) {
                            // Remove spell effect from all affected creatures
                            foreach (Combatant target in targets) {
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
                return new Spell(ID.SLOW, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 120, VSM, ONE_MINUTE, 40, 6, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    foreach (Combatant target in targets) {
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
        /* TODO:
        You grant the semblance of life and intelligence to a corpse of your choice within range, allowing it to answer the questions you pose. The corpse must still have a mouth and can't be undead. The spell fails if the corpse was the target of this spell within the last 10 days.
        Until the spell ends, you can ask the corpse up to five questions. The corpse knows only what it knew in life, including the languages it knew. Answers are usually brief, cryptic, or repetitive, and the corpse is under no compulsion to offer a truthful answer if you are hostile to it or it recognizes you as an enemy. This spell doesn't return the creature's soul to its body, only its animating spirit. Thus, the corpse can't learn new information, doesn't comprehend anything that has happened since it died, and can't speculate about future events.
        */
        public static Spell SpeakwithDead {
            get {
                return new Spell(ID.SPEAK_WITH_DEAD, NECROMANCY, THIRD, CastingTime.ONE_ACTION, 10, VSM, TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO:
        You imbue plants within 30 feet of you with limited sentience and animation, giving them the ability to communicate with you and follow your simple commands. You can question plants about events in the spell's area within the past day, gaining information about creatures that have passed, weather, and other circumstances.
        You can also turn difficult terrain caused by plant growth (such as thickets and undergrowth) into ordinary terrain that lasts for the duration. Or you can turn ordinary terrain where plants are present into difficult terrain that lasts for the duration, causing vines and branches to hinder pursuers, for example.
        Plants might be able to perform other tasks on your behalf, at the GM's discretion. The spell doesn't enable plants to uproot themselves and move about, but they can freely move branches, tendrils, and stalks.
        If a plant creature is in the area, you can communicate with it as if you shared a common language, but you gain no magical ability to influence it.
        This spell can cause the plants created by the entangle spell to release a restrained creature.         
        */
        public static Spell SpeakwithPlants {
            get {
                return new Spell(ID.SPEAK_WITH_PLANTS, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 0, VS, TEN_MINUTES, 30, 0, doNothing);
            }
        }
        public static Spell SpiritGuardians {
            get {
                return new Spell(ID.SPIRIT_GUARDIANS, CONJURATION, THIRD, CastingTime.ONE_ACTION, 0, VSM, TEN_MINUTES, 15, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // Damage type depends on caster alignment: evil → necrotic, good or neutral → radiant
                    DamageType damageType = caster.Alignment.IsEvil() ? NECROTIC : RADIANT;

                    foreach (Combatant target in targets) {
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
                    delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        GlobalEvents.AffectBySpell(caster, ID.STINKING_CLOUD, caster, true);

                        foreach (Combatant target in targets) {
                            // Creatures that don't need to breathe (undead, constructs) or are immune to poison automatically succeed
                            bool immuneToEffect = target.HasEffect(IMMUNITY_POISON) || target.HasEffect(IMMUNITY_POISONED);
                            if (!immuneToEffect && target is Monster monster) {
                                if (monster.Type == Monsters.Type.UNDEAD || monster.Type == Monsters.Type.CONSTRUCT) {
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
                                foreach (Combatant target in targets) {
                                    target.RemoveEffect(SPELL_STINKING_CLOUD);
                                }
                                return true;
                            }
                            return false;
                        });
                    });
            }
        }
        /* TODO:
        A 10-foot-radius immobile dome of force springs into existence around and above you and remains stationary for the duration. The spell ends if you leave its area.
Nine creatures of Medium size or smaller can fit inside the dome with you. The spell fails if its area includes a larger creature or more than nine creatures. Creatures and objects within the dome when you cast this spell can move through it freely. All other creatures and objects are barred from passing through it. Spells and other magical effects can't extend through the dome or be cast through it. The atmosphere inside the space is comfortable and dry, regardless of the weather outside.
Until the spell ends, you can command the interior to become dimly lit or dark. The dome is opaque from the outside, of any color you choose, but it is transparent from the inside. 
        */
        public static Spell TinyHut {
            get {
                return new Spell(ID.TINY_HUT, EVOCATION, THIRD, CastingTime.ONE_MINUTE, 0, VSM, EIGHT_HOURS, 10, 0, doNothing);
            }
        }
        // TODO: Requires language comprehension mechanics for full effect
        public static Spell Tongues {
            get {
                return new Spell(ID.TONGUES, DIVINATION, THIRD, CastingTime.ONE_ACTION, 0, VM, ONE_HOUR, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    GlobalEvents.AffectBySpell(caster, ID.TONGUES, target, true);
                    AddEffectsForDuration(ID.TONGUES, caster, target, ONE_HOUR, SPELL_TONGUES);
                });
            }
        }
        public static Spell VampiricTouch {
            get {
                return new Spell(ID.VAMPIRIC_TOUCH, NECROMANCY, THIRD, CastingTime.ONE_ACTION, 0, VS, ONE_MINUTE, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    GlobalEvents.AffectBySpell(caster, ID.VAMPIRIC_TOUCH, caster, true);

                    // Damage scaling: 3d6 base + 1d6 for each level above 3rd
                    Dice damageDice = DiceSlotScaling(THIRD, slot, D6, 3);

                    // Create a temporary cantrip-like spell for making melee spell attacks during the duration
                    Spell vampiricTouchAttack = new Spell(ID.VAMPIRIC_TOUCH_ATTACK, NECROMANCY, CANTRIP, CastingTime.ONE_ACTION, 0, VS, INSTANTANEOUS, 0, 1,
                        delegate (Battleground ground2, Combatant caster2, int dc2, SpellLevel slot2, int modifier2, Combatant[] targets2) {
                            foreach (Combatant target in targets2) {
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
                return new Spell(ID.WATER_BREATHING, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 30, VSM, ONE_DAY, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    foreach (Combatant target in targets) {
                        GlobalEvents.AffectBySpell(caster, ID.WATER_BREATHING, target, true);
                        AddEffectsForDuration(ID.WATER_BREATHING, caster, target, ONE_DAY, SPELL_WATER_BREATHING);
                    }
                });
            }
        }
        // TODO: Requires liquid-surface traversal mechanics for full effect
        public static Spell WaterWalk {
            get {
                return new Spell(ID.WATER_WALK, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 30, VSM, ONE_HOUR, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    foreach (Combatant target in targets) {
                        GlobalEvents.AffectBySpell(caster, ID.WATER_WALK, target, true);
                        AddEffectsForDuration(ID.WATER_WALK, caster, target, ONE_HOUR, SPELL_WATER_WALK);
                    }
                });
            }
        }
        public static Spell WindWall {
            get {
                return new Spell(ID.WIND_WALL, EVOCATION, THIRD, CastingTime.ONE_ACTION, 120, VSM, ONE_MINUTE, 50, 20, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    foreach (Combatant target in targets) {
                        GlobalEvents.AffectBySpell(caster, ID.WIND_WALL, target, true);
                        target.TakeDamage(new DamageSource(ID.WIND_WALL, caster), BLUDGEONING, new Dice("3d8"), HALVES_DAMAGE, dc, STRENGTH, out _);
                    }
                });
            }
        }
    }
}

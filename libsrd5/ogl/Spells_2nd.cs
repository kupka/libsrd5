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
        public static Spell AcidArrow {
            get {
                return new Spell(ID.ACID_ARROW, EVOCATION, SECOND, CastingTime.ONE_ACTION, 90, VSM, INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    Dice dice = DiceSlotScaling(SECOND, slot, D4, 4, 0, 1);
                    Dice additionalDice = DiceSlotScaling(SECOND, slot, D4, 2, 0, 1);
                    bool hit = SpellAttack(ID.ACID_ARROW, ground, caster, ACID, dice, 0, target, 90, HALVES_DAMAGE);
                    if (hit) {
                        target.AddEndOfTurnEvent(delegate () {
                            target.TakeDamage(SPELL_ACID_ARRORW_BURN, ACID, additionalDice);
                            return true;
                        });
                    }
                });
            }
        }

        public static Spell Aid {
            get {
                return new Spell(ID.AID, ABJURATION, SECOND, CastingTime.ONE_ACTION, 30, VSM, EIGHT_HOURS, 0, 3, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    int amount = 5 * ((int)slot - 1);
                    foreach (Combattant target in targets) {
                        if (target.HasEffect(SPELL_AID)) {
                            GlobalEvents.AffectBySpell(caster, ID.AID, target, false);
                        } else {
                            target.AddHitPointMaximumModifiers(new HitPointMaxiumModifier(amount, HitPointMaxiumModifier.RemovedByEffect.AFTER_8_HOURS));
                            target.HealDamage(amount);
                            target.AddEffect(SPELL_AID);
                            GlobalEvents.AffectBySpell(caster, ID.AID, target, true);
                        }
                    }
                });
            }
        }

        public static Spell AlterSelf {
            get {
                return new Spell(ID.ALTER_SELF, TRANSMUTATION, SECOND, CastingTime.ONE_ACTION, 0, VS, ONE_HOUR, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    // TODO: Aquatic Adaption and Change Appearance require work elsewhere
                    // We cannot chose the type of weapons so let's grow Claws
                    caster.AddEffect(SPELL_ALTER_SELF_CLAWS);
                    GlobalEvents.AffectBySpell(caster, ID.ALTER_SELF, caster, true);
                });
            }
        }

        public static Spell AnimalMessenger {
            get {
                return new Spell(ID.ANIMAL_MESSENGER, ENCHANTMENT, SECOND, CastingTime.ONE_ACTION, 30, VSM, ONE_DAY, 0, 0, SpellWithoutEffect(ID.ANIMAL_MESSENGER));
            }
        }

        public static Spell ArcaneLock {
            get {
                return new Spell(ID.ARCANE_LOCK, ABJURATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, UNTIL_DISPELLED, 0, 0, SpellWithoutEffect(ID.ARCANE_LOCK));
            }
        }

        public static Spell ArcanistsMagicAura {
            get {
                return new Spell(ID.ARCANISTS_MAGIC_AURA, ILLUSION, SECOND, CastingTime.ONE_ACTION, 0, VSM, ONE_DAY, 0, 0, SpellWithoutEffect(ID.ARCANISTS_MAGIC_AURA));
            }
        }

        public static Spell Augury {
            get {
                return new Spell(ID.AUGURY, DIVINATION, SECOND, CastingTime.ONE_MINUTE, 0, VSM, INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.AUGURY));
            }
        }

        public static Spell Barkskin {
            get {
                return new Spell(ID.BARKSKIN, TRANSMUTATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    target.AddEffect(SPELL_BARKSKIN);
                    GlobalEvents.AffectBySpell(caster, ID.BARKSKIN, target, true);
                });
            }
        }

        public static Spell BlindnessDeafness {
            get {
                return new Spell(ID.BLINDNESS_DEAFNESS, NECROMANCY, SECOND, CastingTime.ONE_ACTION, 30, V, ONE_MINUTE, 0, 6, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    // SRD5 says target is either blinded or deafened, but we do both
                    // otherwise we would need to split this into two spells
                    int maxTargets = (int)slot - 1;
                    for (int i = 0; i < maxTargets && i < targets.Length; i++) {
                        Combattant target = targets[i];
                        if (target.DC(ID.BLINDNESS_DEAFNESS, dc, CONSTITUTION)) {
                            GlobalEvents.AffectBySpell(caster, ID.BLINDNESS_DEAFNESS, target, false);
                        } else {
                            AddEffectAndConditionsForDuration(ID.BLINDNESS_DEAFNESS, caster, target, ONE_MINUTE, SPELL_BLINDNESS_DEAFNESS, ConditionType.BLINDED, ConditionType.DEAFENED);
                        }
                    }
                });
            }
        }

        public static Spell Blur {
            get {
                return new Spell(ID.BLUR, ILLUSION, SECOND, CastingTime.ONE_ACTION, 0, V, ONE_MINUTE, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    AddEffectsForDuration(ID.BLUR, caster, caster, ONE_MINUTE, SPELL_BLUR);
                });
            }
        }

        public static Spell BrandingSmite {
            get {
                return new Spell(ID.BRANDING_SMITE, EVOCATION, SECOND, CastingTime.BONUS_ACTION, 0, V, ONE_MINUTE, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Dice dice = DiceSlotScaling(SECOND, slot, D6, 2);
                    Damage additionalDamage = new Damage(RADIANT, dice);
                    foreach (Attack attack in caster.MeleeAttacks) {
                        attack.AddAdditionalDamage(additionalDamage);
                        attack.AddAttackEffect(delegate (Combattant attacker, Combattant target) {
                            foreach (Attack meleeAttack in caster.MeleeAttacks) {
                                meleeAttack.RemoveAdditionalDamage(additionalDamage);
                            }
                            return true;
                        });
                    }
                });
            }
        }

        public static Spell CalmEmotions {
            get {
                return new Spell(ID.CALM_EMOTIONS, ENCHANTMENT, SECOND, CastingTime.ONE_ACTION, 60, VS, ONE_MINUTE, 20, 10, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    // TODO: Here, only the immunity to being charmed and frightned is implemented
                    // Alternatively, you can make a target indifferent about creatures of your choice that it is hostile toward. 
                    // This indifference ends if the target is attacked or harmed by a spell or if it witnesses any of its friends being harmed. 
                    // When the spell ends, the creature becomes hostile again, unless the GM rules otherwise.
                    foreach (Combattant target in targets) {
                        if (target is Monster monster) {
                            if (monster.Type != Monsters.Type.HUMANOID) {
                                GlobalEvents.AffectBySpell(caster, ID.CALM_EMOTIONS, target, false);
                                continue;
                            }
                        }
                        AddEffectsForDuration(ID.CALM_EMOTIONS, caster, target, ONE_MINUTE, SPELL_CALM_EMOTIONS);
                    }
                });
            }
        }

        public static Spell ContinualFlame {
            get {
                return new Spell(ID.CONTINUAL_FLAME, EVOCATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, UNTIL_DISPELLED, 0, 0, SpellWithoutEffect(ID.CONTINUAL_FLAME));
            }
        }

        public static Spell Darkness {
            get {
                return new Spell(ID.DARKNESS, EVOCATION, SECOND, CastingTime.ONE_ACTION, 60, VM, TEN_MINUTES, 15, 0, SpellWithoutEffect(ID.DARKNESS));
            }
        }

        public static Spell Darkvision {
            get {
                return new Spell(ID.DARKVISION, TRANSMUTATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, EIGHT_HOURS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    AddEffectsForDuration(ID.DARKVISION, caster, target, EIGHT_HOURS, SPELL_DARKVISION);
                });
            }
        }

        public static Spell DetectThoughts {
            get {
                return new Spell(ID.DETECT_THOUGHTS, DIVINATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, ONE_MINUTE, 0, 0, SpellWithoutEffect(ID.DETECT_THOUGHTS));
            }
        }
        /* TODO */
        public static Spell EnhanceAbility {
            get {
                Spell spell = new Spell(ID.ENHANCE_ABILITY, TRANSMUTATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 7);
                spell.Variants = new SpellVariant[] { BEARS_ENDURANCE, BULLS_STRENGTH, CATS_GRACE, EAGLES_SPLENDOR, FOX_CUNNING, OWLS_WISDOM };
                spell.Variant = BEARS_ENDURANCE;
                spell.CastEffect = delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    int maxTargets = (int)slot - 1;
                    for (int i = 0; i < maxTargets && i < targets.Length; i++) {
                        Combattant target = targets[i];
                        if (target.HasEffect(SPELL_ENHANCE_ABILITY)) {
                            GlobalEvents.AffectBySpell(caster, ID.ENHANCE_ABILITY, target, false);
                            return;
                        }
                        switch (spell.Variant) {
                            case BULLS_STRENGTH:
                                AddEffectsForDuration(ID.ENHANCE_ABILITY, caster, target, spell.Duration, SPELL_ENHANCE_ABILITY, ADVANTAGE_STRENGTH_SAVES);
                                // TODO: Double carrying capacity
                                break;
                            case CATS_GRACE:
                                AddEffectsForDuration(ID.ENHANCE_ABILITY, caster, target, spell.Duration, SPELL_ENHANCE_ABILITY, ADVANTAGE_DEXTERITY_SAVES);
                                break;
                            case EAGLES_SPLENDOR:
                                AddEffectsForDuration(ID.ENHANCE_ABILITY, caster, target, spell.Duration, SPELL_ENHANCE_ABILITY, ADVANTAGE_CHARISMA_SAVES);
                                break;
                            case FOX_CUNNING:
                                AddEffectsForDuration(ID.ENHANCE_ABILITY, caster, target, spell.Duration, SPELL_ENHANCE_ABILITY, ADVANTAGE_INTELLIGENCE_SAVES);
                                break;
                            case OWLS_WISDOM:
                                AddEffectsForDuration(ID.ENHANCE_ABILITY, caster, target, spell.Duration, SPELL_ENHANCE_ABILITY, ADVANTAGE_WISDOM_SAVES);
                                break;
                            case BEARS_ENDURANCE:
                                AddEffectsForDuration(ID.ENHANCE_ABILITY, caster, target, spell.Duration, SPELL_ENHANCE_ABILITY, ADVANTAGE_CONSTITUTION_SAVES);
                                target.AddTemporaryHitpoints(Roll("2d6"), ONE_HOUR, ID.ENHANCE_ABILITY);
                                break;
                        }
                    }
                };
                return spell;
            }
        }
        /* TODO */
        public static Spell EnlargeReduce {
            get {
                Spell spell = new Spell(ID.ENLARGE_REDUCE, TRANSMUTATION, SECOND, CastingTime.ONE_ACTION, 30, VSM, ONE_MINUTE, 0, 1);
                spell.Variants = new SpellVariant[] { ENLARGE, REDUCE };
                spell.Variant = ENLARGE;
                spell.CastEffect = delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    switch (spell.Variant) {
                        case ENLARGE:
                            if (target.HasEffect(SPELL_ENLARGE)) {
                                GlobalEvents.AffectBySpell(caster, ID.ENLARGE_REDUCE, target, false);
                            } else if (target.HasEffect(SPELL_REDUCE)) {
                                GlobalEvents.AffectBySpell(caster, ID.ENLARGE_REDUCE, target, true);
                                target.RemoveEffect(SPELL_REDUCE, DISADVANTAGE_STRENGTH_SAVES);
                            } else {
                                AddEffectsForDuration(ID.ENHANCE_ABILITY, caster, target, spell.Duration, SPELL_ENLARGE, ADVANTAGE_STRENGTH_SAVES);
                            }
                            break;
                        case REDUCE:
                            if (target.HasEffect(SPELL_REDUCE) || target.DC(spell.ID, dc, CONSTITUTION)) {
                                GlobalEvents.AffectBySpell(caster, ID.ENLARGE_REDUCE, target, false);
                            } else if (target.HasEffect(SPELL_ENLARGE)) {
                                GlobalEvents.AffectBySpell(caster, ID.ENLARGE_REDUCE, target, true);
                                target.RemoveEffect(SPELL_ENLARGE, ADVANTAGE_STRENGTH_SAVES);
                            } else {
                                AddEffectsForDuration(ID.ENHANCE_ABILITY, caster, target, spell.Duration, SPELL_REDUCE, DISADVANTAGE_STRENGTH_SAVES);
                            }
                            break;
                    }
                };
                return spell;
            }
        }

        public static Spell Enthrall {
            get {
                // TODO: Probably when perception checks are implemented, we can make use of Enthrall
                return new Spell(ID.ENTHRALL, ENCHANTMENT, SECOND, CastingTime.ONE_ACTION, 60, VS, ONE_MINUTE, 0, 0, SpellWithoutEffect(ID.ENTHRALL));
            }
        }

        public static Spell FindSteed {
            get {
                // TODO: Should be implemeted once/if mounts are implemented
                return new Spell(ID.FIND_STEED, CONJURATION, SECOND, CastingTime.TEN_MINUTES, 30, VS, INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.FIND_STEED));
            }
        }

        public static Spell FindTraps {
            get {
                // TODO: Should be implemented once/if traps are implemented
                return new Spell(ID.FIND_TRAPS, DIVINATION, SECOND, CastingTime.ONE_ACTION, 120, VS, INSTANTANEOUS, 0, 0, doNothing);
            }
        }

        public static Spell FlameBlade {
            get {
                return new Spell(ID.FLAME_BLADE, EVOCATION, SECOND, CastingTime.BONUS_ACTION, 0, VSM, TEN_MINUTES, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    // This is modelled by creating a Cantrip that the druid can use. After the Duration, the cantrip is removed
                    int dice = 3 + ((int)slot - 2) / 2;
                    Damage damage = new Damage(FIRE, new Dice(dice, D6));
                    // TODO: This cantrip workaround should be replaced by correctly implementing situative actions
                    Spell flamingBladeCantrip = new Spell(ID.FLAME_BLADE, EVOCATION, CANTRIP, CastingTime.ONE_ACTION, 5, V, INSTANTANEOUS, 0, 1, delegate (Battleground ground2, Combattant caster2, int dc2, SpellLevel slot2, int modifier2, Combattant[] targets2) {
                        SpellAttack(ID.FLAME_BLADE, ground2, caster2, damage.Type, damage.Dice, modifier2, targets2[0], 5);
                    });
                    caster.AvailableSpells[0].AddKnownSpell(flamingBladeCantrip);
                    caster.AvailableSpells[0].AddPreparedSpell(flamingBladeCantrip);
                    int remainingRounds = (int)TEN_MINUTES;
                    caster.AddEndOfTurnEvent(delegate () {
                        if (--remainingRounds < 1) {
                            caster.AvailableSpells[0].RemoveKnownSpell(flamingBladeCantrip);
                            caster.AvailableSpells[0].RemovePreparedSpell(flamingBladeCantrip);
                            return true;
                        } else {
                            return false;
                        }
                    });
                });
            }
        }

        public static Spell FlamingSphere {
            get {
                // "As a bonus action, you can move the sphere up to 30 feet. If you ram the sphere into a creature, 
                // that creature must make the saving throw against the sphere's damage, and the sphere stops moving this turn."
                //
                // Note: Since we cannot currently place objects on a Battlefield and move them around, 
                // the current implementation sort of implies that the sphere is following the caster and can
                // be sent on a target within 30 feet as a bonus action
                return new Spell(ID.FLAMING_SPHERE, CONJURATION, SECOND, CastingTime.ONE_ACTION, 60, VSM, ONE_MINUTE, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    // This is modelled by creating a Cantrip that the caster can use. After the Duration, the cantrip is removed
                    Dice dice = DiceSlotScaling(SECOND, slot, D6, 2);
                    Damage damage = new Damage(FIRE, dice);
                    // TODO: This cantrip workaround should be replaced by correctly implementing situative actions
                    Spell flamingSphereCantrip = new Spell(ID.FLAMING_SPHERE, CONJURATION, CANTRIP, CastingTime.BONUS_ACTION, 30, V, INSTANTANEOUS, 0, 1, delegate (Battleground ground2, Combattant caster2, int dc2, SpellLevel slot2, int modifier2, Combattant[] targets2) {
                        Combattant target2 = targets2[0];
                        GlobalEvents.AffectBySpell(caster2, ID.FLAMING_SPHERE, target2, true);
                        target2.TakeDamage(ID.FLAMING_SPHERE, FIRE, dice, HALVES_DAMAGE, dc2, DEXTERITY, out _);
                    });
                    caster.AvailableSpells[0].AddKnownSpell(flamingSphereCantrip);
                    caster.AvailableSpells[0].AddPreparedSpell(flamingSphereCantrip);
                    int remainingRounds = (int)ONE_MINUTE;
                    caster.AddEndOfTurnEvent(delegate () {
                        if (--remainingRounds < 1) {
                            caster.AvailableSpells[0].RemoveKnownSpell(flamingSphereCantrip);
                            caster.AvailableSpells[0].RemovePreparedSpell(flamingSphereCantrip);
                            return true;
                        } else {
                            return false;
                        }
                    });
                });
            }
        }

        public static Spell GentleRepose {
            get {
                return new Spell(ID.GENTLE_REPOSE, NECROMANCY, SECOND, CastingTime.ONE_ACTION, 0, VSM, TEN_DAYS, 0, 0, SpellWithoutEffect(ID.GENTLE_REPOSE));
            }
        }
        /* TODO */
        public static Spell GustofWind {
            get {
                return new Spell(ID.GUST_OF_WIND, EVOCATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, ONE_MINUTE, 60, 5, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    // Fix the location where the spell was cast to create the push-vector
                    Location location = ground.LocateCombattant(caster);
                    foreach (Combattant target in targets) {
                        AddEffectsForDuration(ID.GUST_OF_WIND, caster, target, ONE_MINUTE, SPELL_GUST_OF_WIND);
                        int remainingRounds = (int)ONE_MINUTE;
                        target.AddStartOfTurnEvent(delegate () {
                            if (--remainingRounds < 1) {
                                return true;
                            } else if (!target.DC(ID.GUST_OF_WIND, dc, STRENGTH)) {
                                ground.Push(location, target, 15);
                            }
                            return false;
                        });
                    }
                });
            }
        }

        public static Spell HeatMetal {
            get {
                // TODO: In order to support this, we would need to give Monsters weapons and armors
                return new Spell(ID.HEAT_METAL, TRANSMUTATION, SECOND, CastingTime.ONE_ACTION, 60, VSM, ONE_MINUTE, 0, 0, SpellWithoutEffect(ID.HEAT_METAL));
            }
        }

        public static Spell HoldPerson {
            get {
                return new Spell(
                           ID.HOLD_PERSON, ENCHANTMENT, SECOND, CastingTime.ONE_ACTION, 60, VSM,
                           ONE_MINUTE, 0, 20, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                               // one target per slot above 2nd
                               for (int i = 0; i < (int)slot - 1 && i < targets.Length; i++) {
                                   Combattant target = targets[i];
                                   // only affect humanoid monsters
                                   if (target is Monster monster) {
                                       if (monster.Type != Monsters.Type.HUMANOID) {
                                           GlobalEvents.AffectBySpell(caster, ID.HOLD_PERSON, monster, false);
                                           continue;
                                       }
                                   }
                                   // Wisdom save
                                   if (!target.DC(ID.HOLD_PERSON, dc, WISDOM) && target.AddCondition(ConditionType.PARALYZED)) {
                                       GlobalEvents.AffectBySpell(caster, ID.HOLD_PERSON, target, true);
                                       target.AddEndOfTurnEvent(delegate () {
                                           bool success = target.DC(ID.HOLD_PERSON, dc, WISDOM);
                                           if (success) {
                                               target.RemoveCondition(ConditionType.PARALYZED);
                                           }
                                           return success;
                                       });
                                   } else {
                                       GlobalEvents.AffectBySpell(caster, ID.HOLD_PERSON, target, false);
                                   }
                               }
                           }
                       );
            }
        }

        public static Spell Invisibility {
            get {
                return new Spell(ID.INVISIBILITY, ILLUSION, SECOND, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    target.AddCondition(ConditionType.INVISIBLE);
                    bool spellEnded = false;
                    EventHandler<GlobalEvents.AttackRolled> attackHandler = delegate (object sender, GlobalEvents.AttackRolled attack) {
                        if (attack.Attacker.Equals(target)) {
                            target.RemoveCondition(ConditionType.INVISIBLE);
                            spellEnded = true;
                        }
                    };
                    EventHandler<GlobalEvents.SpellCast> castHandler = delegate (object sender, GlobalEvents.SpellCast cast) {
                        if (cast.Caster.Equals(target)) {
                            target.RemoveCondition(ConditionType.INVISIBLE);
                            spellEnded = true;
                        }
                    };
                    GlobalEvents.AttackRolledHandlers += attackHandler;
                    GlobalEvents.SpellCastHandlers += castHandler;
                    target.AddEndOfTurnEvent(delegate () {
                        if (spellEnded) {
                            GlobalEvents.AttackRolledHandlers -= attackHandler;
                            GlobalEvents.SpellCastHandlers -= castHandler;
                        }
                        return spellEnded;
                    });
                });
            }
        }

        public static Spell Knock {
            get {
                // TODO: Should be implemented once locked items are available
                return new Spell(ID.KNOCK, TRANSMUTATION, SECOND, CastingTime.ONE_ACTION, 60, V, INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.KNOCK));
            }
        }

        public static Spell LesserRestoration {
            get {
                Spell spell = new Spell(ID.LESSER_RESTORATION, ABJURATION, SECOND, CastingTime.ONE_ACTION, 0, VS, INSTANTANEOUS, 0, 1);
                spell.Variants = new SpellVariant[] { BLINDNESS, DEAFNESS, PARALYZATION, POISONS, DISEASES };
                spell.CastEffect = delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    GlobalEvents.AffectBySpell(caster, ID.LESSER_RESTORATION, target, true);
                    switch (spell.Variant) {
                        case BLINDNESS:
                            target.RemoveCondition(ConditionType.BLINDED);
                            break;
                        case DEAFNESS:
                            target.RemoveCondition(ConditionType.DEAFENED);
                            break;
                        case PARALYZATION:
                            target.RemoveCondition(ConditionType.PARALYZED);
                            break;
                        case POISONS:
                            target.RemoveCondition(ConditionType.POISONED);
                            break;
                        case DISEASES:
                            foreach (Effect effect in target.Effects) {
                                if (effect.IsDisease()) {
                                    target.RemoveEffect(effect);
                                    break;
                                }
                            }
                            break;
                    }
                };
                return spell;
            }
        }

        public static Spell Levitate {
            get {
                // We assume that this spell is used for Crowd Control to make a target incapable of melee attacks but also immune to melee attacks
                // Ranged attacks should work normally. The Weight limit of 500 pounds is translated to a maximum size of Large
                return new Spell(ID.LEVITATE, TRANSMUTATION, SECOND, CastingTime.ONE_ACTION, 60, VSM, TEN_MINUTES, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    if (target.Size > Size.LARGE || target.DC(ID.LEVITATE, dc, CONSTITUTION)) {
                        GlobalEvents.AffectBySpell(caster, ID.LEVITATE, target, false);
                        return;
                    }
                    AddEffectsForDuration(ID.LEVITATE, caster, target, TEN_MINUTES, SPELL_LEVITATE, CANNOT_BE_MELEE_ATTACKED, CANNOT_MELEE_ATTACK);
                });
            }
        }

        public static Spell LocateAnimalsOrPlants {
            get {
                return new Spell(ID.LOCATE_ANIMALS_OR_PLANTS, DIVINATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.LOCATE_ANIMALS_OR_PLANTS));
            }
        }

        public static Spell LocateObject {
            get {
                return new Spell(ID.LOCATE_OBJECT, DIVINATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, TEN_MINUTES, 0, 0, SpellWithoutEffect(ID.LOCATE_OBJECT));
            }
        }

        public static Spell MagicMouth {
            get {
                return new Spell(ID.MAGIC_MOUTH, ILLUSION, SECOND, CastingTime.ONE_MINUTE, 30, VSM, UNTIL_DISPELLED, 0, 0, SpellWithoutEffect(ID.MAGIC_MOUTH));
            }
        }

        public static Spell MagicWeapon {
            get {
                return new Spell(ID.MAGIC_WEAPON, TRANSMUTATION, SECOND, CastingTime.BONUS_ACTION, 0, VS, ONE_HOUR, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    // Since we cannot directly target a Weapon, we check the mainhand of the target if it is a nonmagic weapon
                    if (target is CharacterSheet hero && hero.Inventory.MainHand is Weapon) {
                        Weapon weapon = hero.Inventory.MainHand;
                        if (weapon.HasProperty(WeaponProperty.MAGIC)) {
                            GlobalEvents.AffectBySpell(caster, ID.MAGIC_WEAPON, target, false);
                        } else {
                            GlobalEvents.AffectBySpell(caster, ID.MAGIC_WEAPON, target, true);
                            WeaponProperty plus = WeaponProperty.PLUS_1;
                            if ((int)slot > 5)
                                plus = WeaponProperty.PLUS_3;
                            else if ((int)slot > 3)
                                plus = WeaponProperty.PLUS_2;
                            Utils.Push<WeaponProperty>(ref weapon.properties, WeaponProperty.MAGIC, plus);
                            int remainingRounds = (int)ONE_HOUR;
                            target.AddEndOfTurnEvent(delegate () {
                                if (--remainingRounds < 1) {
                                    Utils.RemoveSingle<WeaponProperty>(ref weapon.properties, WeaponProperty.MAGIC);
                                    Utils.RemoveSingle<WeaponProperty>(ref weapon.properties, plus);
                                    return true;
                                }
                                return false;
                            });
                        }
                    } else {
                        GlobalEvents.AffectBySpell(caster, ID.MAGIC_WEAPON, target, false);
                    }
                });
            }
        }
        /* TODO */
        public static Spell MirrorImage {
            get {
                return new Spell(ID.MIRROR_IMAGE, ILLUSION, SECOND, CastingTime.ONE_ACTION, 0, VS, ONE_MINUTE, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    caster.RemoveEffect(SPELL_MIRROR_IMAGE_1, SPELL_MIRROR_IMAGE_2, SPELL_MIRROR_IMAGE_3);
                    caster.AddEffect(SPELL_MIRROR_IMAGE_3);
                    bool spellEnded = false;
                    caster.AddStartOfTurnEvent(delegate () {
                        if (caster.HasEffect(SPELL_MIRROR_IMAGE_3) || caster.HasEffect(SPELL_MIRROR_IMAGE_2) || caster.HasEffect(SPELL_MIRROR_IMAGE_3)) {
                            return false;
                        } else {
                            spellEnded = true;
                            return true;
                        }
                    });
                    int remainingRounds = (int)ONE_MINUTE;
                    caster.AddEndOfTurnEvent(delegate () {
                        if (spellEnded) {
                            return true;
                        } else if (--remainingRounds < 1) {
                            caster.RemoveEffect(SPELL_MIRROR_IMAGE_1, SPELL_MIRROR_IMAGE_2, SPELL_MIRROR_IMAGE_3);
                            return true;
                        } else {
                            return false;
                        }
                    });
                });
            }
        }

        public static Spell MistyStep {
            get {
                // TODO: At some point we want to allow teleporting on a battleground
                return new Spell(ID.MISTY_STEP, CONJURATION, SECOND, CastingTime.BONUS_ACTION, 0, V, INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.MISTY_STEP));
            }
        }

        public static Spell Moonbeam {
            get {
                // Similar to Flaming Sphere, we model this as a temporary Cantrip that can be cast to damage enemies with a range of 60ft
                return new Spell(ID.MOONBEAM, EVOCATION, SECOND, CastingTime.ONE_ACTION, 120, VSM, ONE_MINUTE, 5, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    Dice dice = DiceSlotScaling(SECOND, slot, D10, 2);
                    Damage damage = new Damage(RADIANT, dice);
                    GlobalEvents.AffectBySpell(caster, ID.MOONBEAM, target, true);
                    bool shapeChanger = false;
                    foreach (Feat feat in target.Feats) {
                        if (feat.IsShapeChanger()) {
                            shapeChanger = true;
                        }
                    }
                    if (shapeChanger) {
                        bool success = target.DC(ID.MOONBEAM, dc, CONSTITUTION, out _, false, true);
                        int dmg = dice.Roll();
                        if (success) {
                            target.TakeDamage(ID.MOONBEAM, RADIANT, dmg / 2);
                        } else {
                            target.TakeDamage(ID.MOONBEAM, RADIANT, dmg);
                        }
                    } else {
                        target.TakeDamage(ID.MOONBEAM, RADIANT, dice, HALVES_DAMAGE, dc, CONSTITUTION, out _);
                    }
                    // TODO: This cantrip workaround should be replaced by correctly implementing situative actions
                    Spell moonbeamCantrip = new Spell(ID.MOONBEAM, EVOCATION, CANTRIP, CastingTime.BONUS_ACTION, 60, V, INSTANTANEOUS, 0, 1, delegate (Battleground ground2, Combattant caster2, int dc2, SpellLevel slot2, int modifier2, Combattant[] targets2) {
                        Combattant target2 = targets2[0];
                        GlobalEvents.AffectBySpell(caster, ID.MOONBEAM, target2, true);
                        bool shapeChanger2 = false;
                        foreach (Feat feat in target2.Feats) {
                            if (feat.IsShapeChanger()) {
                                shapeChanger2 = true;
                            }
                        }
                        if (shapeChanger2) {
                            bool success = target2.DC(ID.MOONBEAM, dc2, CONSTITUTION, out _, false, true);
                            int dmg = dice.Roll();
                            if (success) {
                                target2.TakeDamage(ID.MOONBEAM, RADIANT, dmg / 2);
                            } else {
                                target2.TakeDamage(ID.MOONBEAM, RADIANT, dmg);
                            }
                        } else {
                            target2.TakeDamage(ID.MOONBEAM, RADIANT, dice, HALVES_DAMAGE, dc2, CONSTITUTION, out _);
                        }
                    });
                    caster.AvailableSpells[0].AddKnownSpell(moonbeamCantrip);
                    caster.AvailableSpells[0].AddPreparedSpell(moonbeamCantrip);
                    int remainingRounds = (int)ONE_MINUTE;
                    caster.AddEndOfTurnEvent(delegate () {
                        if (--remainingRounds < 1) {
                            caster.AvailableSpells[0].RemoveKnownSpell(moonbeamCantrip);
                            caster.AvailableSpells[0].RemovePreparedSpell(moonbeamCantrip);
                            return true;
                        } else {
                            return false;
                        }
                    });
                });
            }
        }

        public static Spell PassWithoutTrace {
            get {
                return new Spell(ID.PASS_WITHOUT_TRACE, ABJURATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 10, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    foreach (Combattant target in targets) {
                        AddEffectsForDuration(ID.PASS_WITHOUT_TRACE, caster, target, ONE_HOUR, SPELL_PASS_WITHOUT_TRACE);
                    }
                });
            }
        }

        public static Spell PrayerofHealing {
            get {
                return new Spell(ID.PRAYER_OF_HEALING, EVOCATION, SECOND, CastingTime.TEN_MINUTES, 30, V, INSTANTANEOUS, 0, 10, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Dice dice = DiceSlotScaling(SECOND, slot, D8, 2, modifier);
                    foreach (Combattant target in targets) {
                        if (target is Monster monster && (monster.Type == Monsters.Type.CONSTRUCT || monster.Type == Monsters.Type.UNDEAD)) {
                            GlobalEvents.AffectBySpell(caster, ID.PRAYER_OF_HEALING, target, false);
                        } else {
                            GlobalEvents.AffectBySpell(caster, ID.PRAYER_OF_HEALING, target, true);
                            target.HealDamage(dice.Roll());
                        }
                    }
                });
            }
        }

        public static Spell ProtectionfromPoison {
            get {
                return new Spell(ID.PROTECTION_FROM_POISON, ABJURATION, SECOND, CastingTime.ONE_ACTION, 0, VS, ONE_HOUR, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    GlobalEvents.AffectBySpell(caster, ID.PROTECTION_FROM_POISON, target, true);
                    foreach (Effect effect in target.Effects) {
                        if (effect.IsPoison()) {
                            target.RemoveEffect(effect);
                            break;
                        }
                    }
                    AddEffectsForDuration(ID.PROTECTION_FROM_POISON, caster, target, ONE_HOUR, SPELL_PROTECTION_FROM_POISON);
                });
            }
        }

        public static Spell RayofEnfeeblement {
            get {
                return new Spell(ID.RAY_OF_ENFEEBLEMENT, NECROMANCY, SECOND, CastingTime.ONE_ACTION, 60, VS, ONE_MINUTE, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    if (SpellAttack(ID.RAY_OF_ENFEEBLEMENT, ground, caster, TRUE_DAMAGE, null, 0, target, 60)) {
                        AddEffectsForDuration(ID.RAY_OF_ENFEEBLEMENT, caster, target, ONE_MINUTE, SPELL_RAY_OF_ENFEEBLEMENT);
                    }
                });
            }
        }

        public static Spell RopeTrick {
            get {
                return new Spell(ID.ROPE_TRICK, TRANSMUTATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 0, SpellWithoutEffect(ID.ROPE_TRICK));
            }
        }

        public static Spell ScorchingRay {
            get {
                return new Spell(ID.SCORCHING_RAY, EVOCATION, SECOND, CastingTime.ONE_ACTION, 120, VS, INSTANTANEOUS, 0, 10, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    int rays = (int)slot - 2 + 3;
                    for (int i = 0; i < rays; i++) {
                        Combattant target = targets[i % targets.Length];
                        SpellAttack(ID.SCORCHING_RAY, ground, caster, FIRE, new Dice("2d6"), modifier, target, 120);
                    }
                });
            }
        }

        public static Spell SeeInvisibility {
            get {
                return new Spell(ID.SEE_INVISIBILITY, DIVINATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    AddEffectsForDuration(ID.SEE_INVISIBILITY, caster, caster, ONE_HOUR, SPELL_SEE_INVISIBILITY);
                });
            }
        }

        public static Spell Shatter {
            get {
                return new Spell(ID.SHATTER, EVOCATION, SECOND, CastingTime.ONE_ACTION, 60, VSM, INSTANTANEOUS, 15, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Dice dice = DiceSlotScaling(SECOND, slot, D8, 3);
                    foreach (Combattant target in targets) {
                        // Constructs have disadvantage on DC, not Flesh Golem though, since it is made from organic material
                        bool disadvantage = target is Monster monster && monster.Type == Monsters.Type.CONSTRUCT && monster.ID != Monsters.ID.FLESH_GOLEM;
                        GlobalEvents.AffectBySpell(caster, ID.SHATTER, target, true);
                        target.TakeDamage(ID.SHATTER, THUNDER, dice, HALVES_DAMAGE, dc, CONSTITUTION, out _);
                    }
                });
            }
        }

        public static Spell Silence {
            get {
                return new Spell(ID.SILENCE, ILLUSION, SECOND, CastingTime.ONE_ACTION, 120, VS, TEN_MINUTES, 20, 10, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    // TODO: The effect should end when targets move out of the sphere of influence
                    // TODO: Casting a spell that includes a verbal component is impossible there
                    foreach (Combattant target in targets) {
                        AddEffectsForDuration(ID.SILENCE, caster, target, TEN_MINUTES, SPELL_SILENCE);
                    }
                });
            }
        }

        public static Spell SpiderClimb {
            get {
                return new Spell(ID.SPIDER_CLIMB, TRANSMUTATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    AddEffectsForDuration(ID.SPIDER_CLIMB, caster, target, ONE_HOUR, SPELL_SPIDER_CLIMB);
                });
            }
        }

        public static Spell SpikeGrowth {
            get {
                // TODO: At some point we want to be able to modify terrain
                // The area becomes difficult terrain for the duration. 
                // When a creature moves into or within the area, it takes 2d4 piercing damage for every 5 feet it travels.
                return new Spell(ID.SPIKE_GROWTH, TRANSMUTATION, SECOND, CastingTime.ONE_ACTION, 150, VSM, TEN_MINUTES, 20, 0, doNothing);
            }
        }

        public static Spell SpiritualWeapon {
            get {
                return new Spell(ID.SPIRITUAL_WEAPON, EVOCATION, SECOND, CastingTime.BONUS_ACTION, 60, VS, ONE_MINUTE, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    Dice dice = new Dice((int)slot / 2, D8, modifier);
                    SpellAttack(ID.SPIRITUAL_WEAPON, ground, caster, FORCE, dice, modifier, target, 65);
                    // TODO: This cantrip workaround should be replaced by correctly implementing situative actions
                    Spell weaponCantrip = new Spell(ID.SPIRITUAL_WEAPON, EVOCATION, CANTRIP, CastingTime.BONUS_ACTION, 25, V, INSTANTANEOUS, 0, 1, delegate (Battleground ground2, Combattant caster2, int dc2, SpellLevel slot2, int modifier2, Combattant[] targets2) {
                        Combattant target2 = targets2[0];
                        SpellAttack(ID.SPIRITUAL_WEAPON, ground2, caster2, FORCE, dice, modifier2, target2, 25);
                    });
                    caster.AvailableSpells[0].AddKnownSpell(weaponCantrip);
                    caster.AvailableSpells[0].AddPreparedSpell(weaponCantrip);
                    int remainingRounds = (int)ONE_MINUTE;
                    caster.AddEndOfTurnEvent(delegate () {
                        if (--remainingRounds < 1) {
                            caster.AvailableSpells[0].RemoveKnownSpell(weaponCantrip);
                            caster.AvailableSpells[0].RemovePreparedSpell(weaponCantrip);
                            return true;
                        } else {
                            return false;
                        }
                    });
                });
            }
        }

        public static Spell Suggestion {
            get {
                // In order to not make this spell too powerful (compare with Dominate line of spells)
                // we make the target only unable to attack. Effect ends when the target takes damage.
                return new Spell(ID.SUGGESTION, ENCHANTMENT, SECOND, CastingTime.ONE_ACTION, 30, VM, EIGHT_HOURS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    if (target.HasEffect(IMMUNITY_CHARMED) || target.DC(ID.SUGGESTION, dc, WISDOM)) {
                        GlobalEvents.AffectBySpell(caster, ID.SUGGESTION, target, false);
                    } else {
                        AddEffectsForDuration(ID.SUGGESTION, caster, target, EIGHT_HOURS, SPELL_SUGGESTION);
                        target.AddDamageTakenEvent(delegate (object source, Damage damage) {
                            target.RemoveEffect(SPELL_SUGGESTION);
                            return true;
                        });
                    }
                });
            }
        }

        public static Spell WardingBond {
            get {
                return new Spell(ID.WARDING_BOND, ABJURATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    if (target.Equals(caster)) {
                        GlobalEvents.FailAction(caster, GlobalEvents.ActionFailed.Reasons.INVALID_TARGET);
                        return;
                    }
                    // Spell ends if the spell is cast again on either of the connected creatures.
                    bool anyEffectActive = false;
                    if (caster.HasEffect(SPELL_WARDING_BOND_CASTER)) {
                        caster.RemoveEffect(SPELL_WARDING_BOND_CASTER);
                        anyEffectActive = true;
                    }
                    if (target.HasEffect(SPELL_WARDING_BOND_CASTER)) {
                        target.RemoveEffect(SPELL_WARDING_BOND_CASTER);
                        anyEffectActive = true;
                    }
                    if (caster.HasEffect(SPELL_WARDING_BOND)) {
                        caster.RemoveEffect(SPELL_WARDING_BOND);
                        anyEffectActive = true;
                    }
                    if (target.HasEffect(SPELL_WARDING_BOND)) {
                        target.RemoveEffect(SPELL_WARDING_BOND);
                        anyEffectActive = true;
                    }
                    if (anyEffectActive) return;
                    AddEffectsForDuration(ID.WARDING_BOND, caster, target, ONE_HOUR, SPELL_WARDING_BOND);
                    AddEffectsForDuration(ID.WARDING_BOND, caster, caster, ONE_HOUR, SPELL_WARDING_BOND_CASTER);
                    target.AddDamageTakenEvent(delegate (object source, Damage damage) {
                        if (!target.HasEffect(SPELL_WARDING_BOND) || !caster.HasEffect(SPELL_WARDING_BOND_CASTER)) {
                            target.RemoveEffect(SPELL_WARDING_BOND);
                            caster.RemoveEffect(SPELL_WARDING_BOND_CASTER);
                            return true;
                        }
                        caster.TakeDamage(source, damage.Type, damage.Dice);
                        return false;
                    });
                    caster.AddDamageTakenEvent(delegate (object source, Damage damage) {
                        if (!target.HasEffect(SPELL_WARDING_BOND) || !caster.HasEffect(SPELL_WARDING_BOND_CASTER)) {
                            target.RemoveEffect(SPELL_WARDING_BOND);
                            caster.RemoveEffect(SPELL_WARDING_BOND_CASTER);
                            return true;
                        }
                        if (caster.HitPoints == 0) {
                            target.RemoveEffect(SPELL_WARDING_BOND);
                            caster.RemoveEffect(SPELL_WARDING_BOND_CASTER);
                            return true;
                        }
                        return false;
                    });
                    TurnEvent distanceCheck = delegate () {
                        if (!target.HasEffect(SPELL_WARDING_BOND) || !caster.HasEffect(SPELL_WARDING_BOND_CASTER)) {
                            target.RemoveEffect(SPELL_WARDING_BOND);
                            caster.RemoveEffect(SPELL_WARDING_BOND_CASTER);
                            return true;
                        }
                        int distance = ground.Distance(caster, target);
                        if (distance > 60) {
                            target.RemoveEffect(SPELL_WARDING_BOND);
                            caster.RemoveEffect(SPELL_WARDING_BOND_CASTER);
                            return true;
                        }
                        return false;
                    };
                    target.AddStartOfTurnEvent(distanceCheck);
                    caster.AddStartOfTurnEvent(distanceCheck);
                    // TODO: You can also dismiss the spell as an action.
                });
            }
        }
        /* TODO */
        public static Spell Web {
            get {
                return new Spell(ID.WEB, CONJURATION, SECOND, CastingTime.ONE_ACTION, 60, VSM, ONE_HOUR, 20, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ZoneofTruth {
            get {
                return new Spell(ID.ZONE_OF_TRUTH, ENCHANTMENT, SECOND, CastingTime.ONE_ACTION, 60, VS, TEN_MINUTES, 15, 0, doNothing);
            }
        }
    }
}
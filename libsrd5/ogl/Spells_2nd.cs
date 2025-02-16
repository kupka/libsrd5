using static srd5.Die;

namespace srd5 {
    public partial struct Spells {
        public static Spell AcidArrow {
            get {
                return new Spell(ID.ACID_ARROW, SpellSchool.EVOCATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 90, VSM, SpellDuration.INSTANTANEOUS, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    Dice dice = DiceSlotScaling(SpellLevel.SECOND, slot, D4, 4, 0, 1);
                    Dice additionalDice = DiceSlotScaling(SpellLevel.SECOND, slot, D4, 2, 0, 1);
                    bool hit = SpellAttack(ID.ACID_ARROW, ground, caster, DamageType.ACID, dice, 0, target, 90, DamageMitigation.HALVES_DAMAGE);
                    if (hit) {
                        target.AddEndOfTurnEvent(delegate () {
                            target.TakeDamage(Effect.SPELL_ACID_ARRORW_BURN, DamageType.ACID, additionalDice);
                            return true;
                        });
                    }
                });
            }
        }

        public static Spell Aid {
            get {
                return new Spell(ID.AID, SpellSchool.ABJURATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 30, VSM, SpellDuration.EIGHT_HOURS, 0, 3, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    int amount = 5 * ((int)slot - 1);
                    foreach (Combattant target in targets) {
                        if (target.HasEffect(Effect.SPELL_AID)) {
                            GlobalEvents.AffectBySpell(caster, ID.AID, target, false);
                        } else {
                            target.AddHitPointMaximumModifiers(new HitPointMaxiumModifier(amount, HitPointMaxiumModifier.RemovedByEffect.AFTER_8_HOURS));
                            target.HealDamage(amount);
                            target.AddEffect(Effect.SPELL_AID);
                            GlobalEvents.AffectBySpell(caster, ID.AID, target, true);
                        }
                    }
                });
            }
        }

        public static Spell AlterSelf {
            get {
                return new Spell(ID.ALTER_SELF, SpellSchool.TRANSMUTATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VS, SpellDuration.ONE_HOUR, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    // TODO: Aquatic Adaption and Change Appearance require work elsewhere
                    // We cannot chose the type of weapons so let's grow Claws
                    caster.AddEffect(Effect.SPELL_ALTER_SELF_CLAWS);
                    GlobalEvents.AffectBySpell(caster, ID.ALTER_SELF, caster, true);
                });
            }
        }

        public static Spell AnimalMessenger {
            get {
                return new Spell(ID.ANIMAL_MESSENGER, SpellSchool.ENCHANTMENT, SpellLevel.SECOND, CastingTime.ONE_ACTION, 30, VSM, SpellDuration.ONE_DAY, 0, 0, SpellWithoutEffect(ID.ANIMAL_MESSENGER));
            }
        }

        public static Spell ArcaneLock {
            get {
                return new Spell(ID.ARCANE_LOCK, SpellSchool.ABJURATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.UNTIL_DISPELLED, 0, 0, SpellWithoutEffect(ID.ARCANE_LOCK));
            }
        }

        public static Spell ArcanistsMagicAura {
            get {
                return new Spell(ID.ARCANISTS_MAGIC_AURA, SpellSchool.ILLUSION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_DAY, 0, 0, SpellWithoutEffect(ID.ARCANISTS_MAGIC_AURA));
            }
        }

        public static Spell Augury {
            get {
                return new Spell(ID.AUGURY, SpellSchool.DIVINATION, SpellLevel.SECOND, CastingTime.ONE_MINUTE, 0, VSM, SpellDuration.INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.AUGURY));
            }
        }

        public static Spell Barkskin {
            get {
                return new Spell(ID.BARKSKIN, SpellSchool.TRANSMUTATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_HOUR, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    target.AddEffect(Effect.SPELL_BARKSKIN);
                    GlobalEvents.AffectBySpell(caster, ID.BARKSKIN, target, true);
                });
            }
        }

        public static Spell BlindnessDeafness {
            get {
                return new Spell(ID.BLINDNESS_DEAFNESS, SpellSchool.NECROMANCY, SpellLevel.SECOND, CastingTime.ONE_ACTION, 30, V, SpellDuration.ONE_MINUTE, 0, 6, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    // SRD5 says target is either blinded or deafened, but we do both
                    // otherwise we would need to split this into two spells
                    int maxTargets = (int)slot - 1;
                    for (int i = 0; i < maxTargets && i < targets.Length; i++) {
                        Combattant target = targets[i];
                        if (target.DC(ID.BLINDNESS_DEAFNESS, dc, AbilityType.CONSTITUTION)) {
                            GlobalEvents.AffectBySpell(caster, ID.BLINDNESS_DEAFNESS, target, false);
                        } else {
                            AddEffectAndConditionsForDuration(ID.BLINDNESS_DEAFNESS, caster, target, SpellDuration.ONE_MINUTE, Effect.SPELL_BLINDNESS_DEAFNESS, ConditionType.BLINDED, ConditionType.DEAFENED);
                        }
                    }
                });
            }
        }

        public static Spell Blur {
            get {
                return new Spell(ID.BLUR, SpellSchool.ILLUSION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, V, SpellDuration.ONE_MINUTE, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    AddEffectForDuration(ID.BLUR, caster, caster, Effect.SPELL_BLUR, SpellDuration.ONE_MINUTE);
                });
            }
        }

        public static Spell BrandingSmite {
            get {
                return new Spell(ID.BRANDING_SMITE, SpellSchool.EVOCATION, SpellLevel.SECOND, CastingTime.BONUS_ACTION, 0, V, SpellDuration.ONE_MINUTE, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Dice dice = DiceSlotScaling(SpellLevel.SECOND, slot, D6, 2);
                    Damage additionalDamage = new Damage(DamageType.RADIANT, dice);
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
                return new Spell(ID.CALM_EMOTIONS, SpellSchool.ENCHANTMENT, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, VS, SpellDuration.ONE_MINUTE, 20, 10, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
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
                        AddEffectForDuration(ID.CALM_EMOTIONS, caster, target, Effect.SPELL_CALM_EMOTIONS, SpellDuration.ONE_MINUTE);
                    }
                });
            }
        }

        public static Spell ContinualFlame {
            get {
                return new Spell(ID.CONTINUAL_FLAME, SpellSchool.EVOCATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.UNTIL_DISPELLED, 0, 0, SpellWithoutEffect(ID.CONTINUAL_FLAME));
            }
        }

        public static Spell Darkness {
            get {
                return new Spell(ID.DARKNESS, SpellSchool.EVOCATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, VM, SpellDuration.TEN_MINUTES, 15, 0, SpellWithoutEffect(ID.DARKNESS));
            }
        }

        public static Spell Darkvision {
            get {
                return new Spell(ID.DARKVISION, SpellSchool.TRANSMUTATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.EIGHT_HOURS, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    AddEffectForDuration(ID.DARKVISION, caster, target, Effect.SPELL_DARKVISION, SpellDuration.EIGHT_HOURS);
                });
            }
        }

        public static Spell DetectThoughts {
            get {
                return new Spell(ID.DETECT_THOUGHTS, SpellSchool.DIVINATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_MINUTE, 0, 0, SpellWithoutEffect(ID.DETECT_THOUGHTS));
            }
        }
        /* TODO */
        public static Spell EnhanceAbility {
            get {
                return new Spell(ID.ENHANCE_ABILITY, SpellSchool.TRANSMUTATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell EnlargeReduce {
            get {
                return new Spell(ID.ENLARGE_REDUCE, SpellSchool.TRANSMUTATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 30, VSM, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Enthrall {
            get {
                return new Spell(ID.ENTHRALL, SpellSchool.ENCHANTMENT, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, VS, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell FindSteed {
            get {
                return new Spell(ID.FIND_STEED, SpellSchool.CONJURATION, SpellLevel.SECOND, CastingTime.TEN_MINUTES, 30, VS, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell FindTraps {
            get {
                return new Spell(ID.FIND_TRAPS, SpellSchool.DIVINATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 120, VS, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell FlameBlade {
            get {
                return new Spell(ID.FLAME_BLADE, SpellSchool.EVOCATION, SpellLevel.SECOND, CastingTime.BONUS_ACTION, 0, VSM, SpellDuration.TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell FlamingSphere {
            get {
                return new Spell(ID.FLAMING_SPHERE, SpellSchool.CONJURATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, VSM, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell GentleRepose {
            get {
                return new Spell(ID.GENTLE_REPOSE, SpellSchool.NECROMANCY, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.TEN_DAYS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell GustofWind {
            get {
                return new Spell(ID.GUST_OF_WIND, SpellSchool.EVOCATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_MINUTE, 60, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell HeatMetal {
            get {
                return new Spell(ID.HEAT_METAL, SpellSchool.TRANSMUTATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, VSM, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }

        public static Spell HoldPerson {
            get {
                return new Spell(
                           ID.HOLD_PERSON, SpellSchool.ENCHANTMENT, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, VSM,
                           SpellDuration.ONE_MINUTE, 0, 20, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
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
                                   if (!target.DC(ID.HOLD_PERSON, dc, AbilityType.WISDOM) && target.AddCondition(ConditionType.PARALYZED)) {
                                       GlobalEvents.AffectBySpell(caster, ID.HOLD_PERSON, target, true);
                                       target.AddEndOfTurnEvent(delegate () {
                                           bool success = target.DC(ID.HOLD_PERSON, dc, AbilityType.WISDOM);
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

        /* TODO */
        public static Spell Invisibility {
            get {
                return new Spell(ID.INVISIBILITY, SpellSchool.ILLUSION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Knock {
            get {
                return new Spell(ID.KNOCK, SpellSchool.TRANSMUTATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, V, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell LesserRestoration {
            get {
                return new Spell(ID.LESSER_RESTORATION, SpellSchool.ABJURATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VS, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Levitate {
            get {
                return new Spell(ID.LEVITATE, SpellSchool.TRANSMUTATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, VSM, SpellDuration.TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell LocateAnimalsorPlants {
            get {
                return new Spell(ID.LOCATE_ANIMALS_OR_PLANTS, SpellSchool.DIVINATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell LocateObject {
            get {
                return new Spell(ID.LOCATE_OBJECT, SpellSchool.DIVINATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MagicMouth {
            get {
                return new Spell(ID.MAGIC_MOUTH, SpellSchool.ILLUSION, SpellLevel.SECOND, CastingTime.ONE_MINUTE, 30, VSM, SpellDuration.UNTIL_DISPELLED, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MagicWeapon {
            get {
                return new Spell(ID.MAGIC_WEAPON, SpellSchool.TRANSMUTATION, SpellLevel.SECOND, CastingTime.BONUS_ACTION, 0, VS, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MirrorImage {
            get {
                return new Spell(ID.MIRROR_IMAGE, SpellSchool.ILLUSION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VS, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MistyStep {
            get {
                return new Spell(ID.MISTY_STEP, SpellSchool.CONJURATION, SpellLevel.SECOND, CastingTime.BONUS_ACTION, 0, V, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Moonbeam {
            get {
                return new Spell(ID.MOONBEAM, SpellSchool.EVOCATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 120, VSM, SpellDuration.ONE_MINUTE, 5, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PassWithoutTrace {
            get {
                return new Spell(ID.PASS_WITHOUT_TRACE, SpellSchool.ABJURATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PrayerofHealing {
            get {
                return new Spell(ID.PRAYER_OF_HEALING, SpellSchool.EVOCATION, SpellLevel.SECOND, CastingTime.TEN_MINUTES, 30, V, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ProtectionfromPoison {
            get {
                return new Spell(ID.PROTECTION_FROM_POISON, SpellSchool.ABJURATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VS, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell RayofEnfeeblement {
            get {
                return new Spell(ID.RAY_OF_ENFEEBLEMENT, SpellSchool.NECROMANCY, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, VS, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell RopeTrick {
            get {
                return new Spell(ID.ROPE_TRICK, SpellSchool.TRANSMUTATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ScorchingRay {
            get {
                return new Spell(ID.SCORCHING_RAY, SpellSchool.EVOCATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 120, VS, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell SeeInvisibility {
            get {
                return new Spell(ID.SEE_INVISIBILITY, SpellSchool.DIVINATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Shatter {
            get {
                return new Spell(ID.SHATTER, SpellSchool.EVOCATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, VSM, SpellDuration.INSTANTANEOUS, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Silence {
            get {
                return new Spell(ID.SILENCE, SpellSchool.ILLUSION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 120, VS, SpellDuration.TEN_MINUTES, 20, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell SpiderClimb {
            get {
                return new Spell(ID.SPIDER_CLIMB, SpellSchool.TRANSMUTATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell SpikeGrowth {
            get {
                return new Spell(ID.SPIKE_GROWTH, SpellSchool.TRANSMUTATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 150, VSM, SpellDuration.TEN_MINUTES, 20, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell SpiritualWeapon {
            get {
                return new Spell(ID.SPIRITUAL_WEAPON, SpellSchool.EVOCATION, SpellLevel.SECOND, CastingTime.BONUS_ACTION, 60, VS, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Suggestion {
            get {
                return new Spell(ID.SUGGESTION, SpellSchool.ENCHANTMENT, SpellLevel.SECOND, CastingTime.ONE_ACTION, 30, VM, SpellDuration.EIGHT_HOURS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell WardingBond {
            get {
                return new Spell(ID.WARDING_BOND, SpellSchool.ABJURATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Web {
            get {
                return new Spell(ID.WEB, SpellSchool.CONJURATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, VSM, SpellDuration.ONE_HOUR, 20, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ZoneofTruth {
            get {
                return new Spell(ID.ZONE_OF_TRUTH, SpellSchool.ENCHANTMENT, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, VS, SpellDuration.TEN_MINUTES, 15, 0, doNothing);
            }
        }
    }
}
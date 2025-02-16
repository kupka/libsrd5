using static srd5.Die;

namespace srd5 {
    public partial struct Spells {
        public static readonly Spell AcidArrow = new Spell(ID.ACID_ARROW, SpellSchool.EVOCATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 90, VSM, SpellDuration.INSTANTANEOUS, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
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

        public static readonly Spell Aid = new Spell(ID.AID, SpellSchool.ABJURATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 30, VSM, SpellDuration.EIGHT_HOURS, 0, 3, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
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

        public static readonly Spell AlterSelf = new Spell(ID.ALTER_SELF, SpellSchool.TRANSMUTATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VS, SpellDuration.ONE_HOUR, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
            // TODO: Aquatic Adaption and Change Appearance require work elsewhere
            // We cannot chose the type of weapons so let's grow Claws
            caster.AddEffect(Effect.SPELL_ALTER_SELF_CLAWS);
            GlobalEvents.AffectBySpell(caster, ID.ALTER_SELF, caster, true);
        });

        public static readonly Spell AnimalMessenger = new Spell(ID.ANIMAL_MESSENGER, SpellSchool.ENCHANTMENT, SpellLevel.SECOND, CastingTime.ONE_ACTION, 30, VSM, SpellDuration.ONE_DAY, 0, 0, SpellWithoutEffect(ID.ANIMAL_MESSENGER));

        public static readonly Spell ArcaneLock = new Spell(ID.ARCANE_LOCK, SpellSchool.ABJURATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.UNTIL_DISPELLED, 0, 0, SpellWithoutEffect(ID.ARCANE_LOCK));

        public static readonly Spell ArcanistsMagicAura = new Spell(ID.ARCANISTS_MAGIC_AURA, SpellSchool.ILLUSION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_DAY, 0, 0, SpellWithoutEffect(ID.ARCANISTS_MAGIC_AURA));

        public static readonly Spell Augury = new Spell(ID.AUGURY, SpellSchool.DIVINATION, SpellLevel.SECOND, CastingTime.ONE_MINUTE, 0, VSM, SpellDuration.INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.AUGURY));

        public static readonly Spell Barkskin = new Spell(ID.BARKSKIN, SpellSchool.TRANSMUTATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_HOUR, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
            Combattant target = targets[0];
            target.AddEffect(Effect.SPELL_BARKSKIN);
            GlobalEvents.AffectBySpell(caster, ID.BARKSKIN, target, true);
        });

        public static readonly Spell BlindnessDeafness = new Spell(ID.BLINDNESS_DEAFNESS, SpellSchool.NECROMANCY, SpellLevel.SECOND, CastingTime.ONE_ACTION, 30, V, SpellDuration.ONE_MINUTE, 0, 6, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
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

        public static readonly Spell Blur = new Spell(ID.BLUR, SpellSchool.ILLUSION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, V, SpellDuration.ONE_MINUTE, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
            AddEffectForDuration(ID.BLUR, caster, caster, Effect.SPELL_BLUR, SpellDuration.ONE_MINUTE);
        });

        public static readonly Spell BrandingSmite = new Spell(ID.BRANDING_SMITE, SpellSchool.EVOCATION, SpellLevel.SECOND, CastingTime.BONUS_ACTION, 0, V, SpellDuration.ONE_MINUTE, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
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

        public static readonly Spell CalmEmotions = new Spell(ID.CALM_EMOTIONS, SpellSchool.ENCHANTMENT, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, VS, SpellDuration.ONE_MINUTE, 20, 10, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
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
        /* TODO */
        public static readonly Spell ContinualFlame = new Spell(ID.CONTINUAL_FLAME, SpellSchool.EVOCATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.UNTIL_DISPELLED, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell Darkness = new Spell(ID.DARKNESS, SpellSchool.EVOCATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, VM, SpellDuration.TEN_MINUTES, 15, 0, doNothing);
        /* TODO */
        public static readonly Spell Darkvision = new Spell(ID.DARKVISION, SpellSchool.TRANSMUTATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.EIGHT_HOURS, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell DetectThoughts = new Spell(ID.DETECT_THOUGHTS, SpellSchool.DIVINATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell EnhanceAbility = new Spell(ID.ENHANCE_ABILITY, SpellSchool.TRANSMUTATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_HOUR, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell EnlargeReduce = new Spell(ID.ENLARGE_REDUCE, SpellSchool.TRANSMUTATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 30, VSM, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell Enthrall = new Spell(ID.ENTHRALL, SpellSchool.ENCHANTMENT, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, VS, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell FindSteed = new Spell(ID.FIND_STEED, SpellSchool.CONJURATION, SpellLevel.SECOND, CastingTime.TEN_MINUTES, 30, VS, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell FindTraps = new Spell(ID.FIND_TRAPS, SpellSchool.DIVINATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 120, VS, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell FlameBlade = new Spell(ID.FLAME_BLADE, SpellSchool.EVOCATION, SpellLevel.SECOND, CastingTime.BONUS_ACTION, 0, VSM, SpellDuration.TEN_MINUTES, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell FlamingSphere = new Spell(ID.FLAMING_SPHERE, SpellSchool.CONJURATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, VSM, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell GentleRepose = new Spell(ID.GENTLE_REPOSE, SpellSchool.NECROMANCY, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.TEN_DAYS, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell GustofWind = new Spell(ID.GUST_OF_WIND, SpellSchool.EVOCATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_MINUTE, 60, 0, doNothing);
        /* TODO */
        public static readonly Spell HeatMetal = new Spell(ID.HEAT_METAL, SpellSchool.TRANSMUTATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, VSM, SpellDuration.ONE_MINUTE, 0, 0, doNothing);

        public static readonly Spell HoldPerson = new Spell(
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

        /* TODO */
        public static readonly Spell Invisibility = new Spell(ID.INVISIBILITY, SpellSchool.ILLUSION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_HOUR, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell Knock = new Spell(ID.KNOCK, SpellSchool.TRANSMUTATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, V, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell LesserRestoration = new Spell(ID.LESSER_RESTORATION, SpellSchool.ABJURATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VS, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell Levitate = new Spell(ID.LEVITATE, SpellSchool.TRANSMUTATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, VSM, SpellDuration.TEN_MINUTES, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell LocateAnimalsorPlants = new Spell(ID.LOCATE_ANIMALS_OR_PLANTS, SpellSchool.DIVINATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell LocateObject = new Spell(ID.LOCATE_OBJECT, SpellSchool.DIVINATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.TEN_MINUTES, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell MagicMouth = new Spell(ID.MAGIC_MOUTH, SpellSchool.ILLUSION, SpellLevel.SECOND, CastingTime.ONE_MINUTE, 30, VSM, SpellDuration.UNTIL_DISPELLED, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell MagicWeapon = new Spell(ID.MAGIC_WEAPON, SpellSchool.TRANSMUTATION, SpellLevel.SECOND, CastingTime.BONUS_ACTION, 0, VS, SpellDuration.ONE_HOUR, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell MirrorImage = new Spell(ID.MIRROR_IMAGE, SpellSchool.ILLUSION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VS, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell MistyStep = new Spell(ID.MISTY_STEP, SpellSchool.CONJURATION, SpellLevel.SECOND, CastingTime.BONUS_ACTION, 0, V, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell Moonbeam = new Spell(ID.MOONBEAM, SpellSchool.EVOCATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 120, VSM, SpellDuration.ONE_MINUTE, 5, 0, doNothing);
        /* TODO */
        public static readonly Spell PassWithoutTrace = new Spell(ID.PASS_WITHOUT_TRACE, SpellSchool.ABJURATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_HOUR, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell PrayerofHealing = new Spell(ID.PRAYER_OF_HEALING, SpellSchool.EVOCATION, SpellLevel.SECOND, CastingTime.TEN_MINUTES, 30, V, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell ProtectionfromPoison = new Spell(ID.PROTECTION_FROM_POISON, SpellSchool.ABJURATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VS, SpellDuration.ONE_HOUR, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell RayofEnfeeblement = new Spell(ID.RAY_OF_ENFEEBLEMENT, SpellSchool.NECROMANCY, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, VS, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell RopeTrick = new Spell(ID.ROPE_TRICK, SpellSchool.TRANSMUTATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_HOUR, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell ScorchingRay = new Spell(ID.SCORCHING_RAY, SpellSchool.EVOCATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 120, VS, SpellDuration.INSTANTANEOUS, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell SeeInvisibility = new Spell(ID.SEE_INVISIBILITY, SpellSchool.DIVINATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_HOUR, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell Shatter = new Spell(ID.SHATTER, SpellSchool.EVOCATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, VSM, SpellDuration.INSTANTANEOUS, 10, 0, doNothing);
        /* TODO */
        public static readonly Spell Silence = new Spell(ID.SILENCE, SpellSchool.ILLUSION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 120, VS, SpellDuration.TEN_MINUTES, 20, 0, doNothing);
        /* TODO */
        public static readonly Spell SpiderClimb = new Spell(ID.SPIDER_CLIMB, SpellSchool.TRANSMUTATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_HOUR, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell SpikeGrowth = new Spell(ID.SPIKE_GROWTH, SpellSchool.TRANSMUTATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 150, VSM, SpellDuration.TEN_MINUTES, 20, 0, doNothing);
        /* TODO */
        public static readonly Spell SpiritualWeapon = new Spell(ID.SPIRITUAL_WEAPON, SpellSchool.EVOCATION, SpellLevel.SECOND, CastingTime.BONUS_ACTION, 60, VS, SpellDuration.ONE_MINUTE, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell Suggestion = new Spell(ID.SUGGESTION, SpellSchool.ENCHANTMENT, SpellLevel.SECOND, CastingTime.ONE_ACTION, 30, VM, SpellDuration.EIGHT_HOURS, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell WardingBond = new Spell(ID.WARDING_BOND, SpellSchool.ABJURATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 0, VSM, SpellDuration.ONE_HOUR, 0, 0, doNothing);
        /* TODO */
        public static readonly Spell Web = new Spell(ID.WEB, SpellSchool.CONJURATION, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, VSM, SpellDuration.ONE_HOUR, 20, 0, doNothing);
        /* TODO */
        public static readonly Spell ZoneofTruth = new Spell(ID.ZONE_OF_TRUTH, SpellSchool.ENCHANTMENT, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, VS, SpellDuration.TEN_MINUTES, 15, 0, doNothing);
    }
}
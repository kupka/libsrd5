using System;
using static srd5.Die;
using static srd5.SpellSchool;
using static srd5.SpellLevel;
using static srd5.SpellDuration;

namespace srd5 {
    public partial struct Spells {
        public static Spell Alarm {
            get {
                return new Spell(ID.ALARM, ABJURATION, FIRST, CastingTime.ONE_MINUTE, 30, VSM, EIGHT_HOURS, 20, 0, SpellWithoutEffect(ID.ALARM));
            }
        }

        public static Spell AnimalFriendship {
            get {
                return new Spell(ID.ANIMAL_FRIENDSHIP, ENCHANTMENT, FIRST, CastingTime.ONE_ACTION, 30, VSM, ONE_DAY, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    if (target is Monster monster
                            && monster.Type == Monsters.Type.BEAST
                            && monster.Intelligence.Value < 4
                            && !monster.HasEffect(Effect.IMMUNITY_CHARMED)
                            // Wisdom save with advantage since we assume a fight
                            && !monster.DC(ID.ANIMAL_FRIENDSHIP, dc, AbilityType.WISDOM, false, true)) {
                        monster.AddEffect(Effect.SPELL_ANIMAL_FRIENDSHIP);
                        monster.AddCondition(ConditionType.CHARMED);
                        GlobalEvents.AffectBySpell(caster, ID.ANIMAL_FRIENDSHIP, target, true);
                    } else {
                        GlobalEvents.AffectBySpell(caster, ID.ANIMAL_FRIENDSHIP, target, false);
                    }
                });
            }
        }

        public static Spell Bane {
            get {
                return new Spell(ID.BANE, ENCHANTMENT, FIRST, CastingTime.ONE_ACTION, 30, VSM, ONE_MINUTE, 0, 3, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    foreach (Combattant target in targets) {
                        if (target.DC(ID.BANE, dc, AbilityType.CHARISMA)) {
                            GlobalEvents.AffectBySpell(caster, ID.BANE, target, false);
                        } else {
                            AddEffectsForDuration(ID.BANE, caster, target, ONE_MINUTE, Effect.SPELL_BANE);
                        }
                    }
                });
            }
        }


        public static Spell Bless {
            get {
                return new Spell(ID.BLESS, ENCHANTMENT, FIRST, CastingTime.ONE_ACTION, 30, VSM, ONE_MINUTE, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    foreach (Combattant target in targets) {
                        AddEffectsForDuration(ID.BLESS, caster, target, ONE_MINUTE, Effect.SPELL_BLESS);
                    }
                });
            }
        }


        public static Spell BurningHands {
            get {
                return new Spell(ID.BURNING_HANDS, EVOCATION, FIRST, CastingTime.ONE_ACTION, 0, VS, INSTANTANEOUS, 15, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Dice dice = DiceSlotScaling(FIRST, slot, D6, 3);
                    foreach (Combattant target in targets) {
                        target.TakeDamage(ID.BURNING_HANDS, DamageType.FIRE, dice.Roll(), DamageMitigation.HALVES_DAMAGE, dc, AbilityType.DEXTERITY, out _);
                        GlobalEvents.AffectBySpell(caster, ID.BURNING_HANDS, target, true);
                    }
                });
            }
        }

        public static Spell CharmPerson {
            get {
                return new Spell(
                    ID.CHARM_PERSON, ENCHANTMENT, FIRST, CastingTime.ONE_ACTION, 30, VS,
                    ONE_HOUR, 0, 20, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        // one target per slot
                        for (int i = 0; i < (int)slot && i < targets.Length; i++) {
                            Combattant target = targets[i];
                            // only affect humanoid monsters
                            if (target is Monster monster) {
                                if (monster.Type != Monsters.Type.HUMANOID) {
                                    GlobalEvents.AffectBySpell(caster, ID.CHARM_PERSON, monster, false);
                                    continue;
                                }
                            }
                            // Wisdom save with advantage since we assume a fight
                            if (!target.DC(ID.CHARM_PERSON, dc, AbilityType.WISDOM, true) && target.AddCondition(ConditionType.CHARMED)) {
                                GlobalEvents.AffectBySpell(caster, ID.CHARM_PERSON, target, true);
                            } else {
                                GlobalEvents.AffectBySpell(caster, ID.CHARM_PERSON, target, false);
                            }
                        }
                    }
                );
            }
        }

        public static Spell ColorSpray {
            get {
                return new Spell(ID.COLOR_SPRAY, ILLUSION, FIRST, CastingTime.ONE_ACTION, 0, VSM, ONE_ROUND, 15, 10, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Dice dice = DiceSlotScaling(FIRST, slot, D10, 5, 0, 2);
                    int remainingHitpoints = dice.Roll();
                    Array.Sort(targets, (t1, t2) => {
                        return t1.HitPoints.CompareTo(t2.HitPoints);
                    });
                    for (int i = 0; i < targets.Length && targets[i].HitPoints <= remainingHitpoints; i++) {
                        Combattant target = targets[i];
                        // ignoring unconscious creatures
                        if (target.HasCondition(ConditionType.UNCONSCIOUS)) continue;
                        // Creatures immune to being blinded aren't affected by this spell
                        if (target.HasEffect(Effect.IMMUNITY_BLINDED)) continue;
                        // substract hitpoints and make target blind for one round
                        remainingHitpoints -= target.HitPoints;
                        target.AddCondition(ConditionType.BLINDED);
                        caster.AddStartOfTurnEvent(delegate () {
                            target.RemoveCondition(ConditionType.BLINDED);
                            return true;
                        });
                    }
                });
            }
        }

        public static Spell Command {
            get {
                return new Spell(ID.COMMAND, ENCHANTMENT, FIRST, CastingTime.ONE_ACTION, 60, V, ONE_ROUND, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    // Command knows multiple effects, but here only the "Grovel" command seems to be feasible for implementation
                    Combattant target = targets[0];
                    bool affected = true;
                    if (target is Monster monster && monster.Type == Monsters.Type.UNDEAD) {
                        affected = false;
                    } else if (target.DC(ID.COMMAND, dc, AbilityType.WISDOM)) {
                        affected = false;
                    } else {
                        target.AddCondition(ConditionType.PRONE);
                        target.AddEffect(Effect.SPELL_COMMAND_GROVEL);
                        target.AddEndOfTurnEvent(delegate () {
                            target.RemoveEffect(Effect.SPELL_COMMAND_GROVEL);
                            return true;
                        });
                    }
                    GlobalEvents.AffectBySpell(caster, ID.COMMAND, target, affected);
                });
            }
        }

        public static Spell ComprehendLanguages {
            get {
                return new Spell(ID.COMPREHEND_LANGUAGES, DIVINATION, FIRST, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 0, SpellWithoutEffect(ID.COMPREHEND_LANGUAGES));
            }
        }

        public static Spell CreateorDestroyWater {
            get {
                return new Spell(
                    ID.CREATE_OR_DESTROY_WATER, TRANSMUTATION, FIRST, CastingTime.ONE_ACTION, 30, VS,
                    INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.CREATE_OR_DESTROY_WATER)
                );
            }
        }

        public static Spell CureWounds {
            get {
                return new Spell(
                    ID.CURE_WOUNDS, EVOCATION, FIRST, CastingTime.ONE_ACTION, 5, VS,
                    INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        Combattant target = targets[0];
                        if (target is Monster monster) {
                            if (monster.Type == Monsters.Type.CONSTRUCT || monster.Type == Monsters.Type.UNDEAD) {
                                GlobalEvents.AffectBySpell(caster, ID.CURE_WOUNDS, monster, false);
                                return;
                            }
                        }
                        Dice dice = DiceSlotScaling(FIRST, slot, D8, 1, modifier);
                        GlobalEvents.AffectBySpell(caster, ID.CURE_WOUNDS, target, true);
                        target.HealDamage(dice.Roll());
                    }
                );
            }
        }

        public static Spell DetectEvilandGood {
            get {
                return new Spell(
                    ID.DETECT_EVIL_AND_GOOD, DIVINATION, FIRST, CastingTime.ONE_ACTION, 0, VS, TEN_MINUTES, 30, 0, SpellWithoutEffect(ID.DETECT_EVIL_AND_GOOD)
                );
            }
        }

        public static Spell DetectMagic {
            get {
                return new Spell(
                    ID.DETECT_MAGIC, DIVINATION, FIRST, CastingTime.ONE_ACTION, 0, VS,
                    TEN_MINUTES, 30, 0, SpellWithoutEffect(ID.DETECT_MAGIC)
                );
            }
        }

        public static Spell DetectPoisonAndDisease {
            get {
                return new Spell(
                    ID.DETECT_POISON_AND_DISEASE, DIVINATION, FIRST, CastingTime.ONE_ACTION, 0, VSM,
                    TEN_MINUTES, 30, 0, SpellWithoutEffect(ID.DETECT_POISON_AND_DISEASE)
                );
            }
        }

        public static Spell DisguiseSelf {
            get {
                return new Spell(ID.DISGUISE_SELF, ILLUSION, FIRST, CastingTime.ONE_ACTION, 0, VS, ONE_HOUR, 0, 0, SpellWithoutEffect(ID.DISGUISE_SELF));
            }
        }

        public static Spell DivineFavor {
            get {
                return new Spell(ID.DIVINE_FAVOR, EVOCATION, FIRST, CastingTime.BONUS_ACTION, 0, VS, ONE_MINUTE, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    AddEffectsForDuration(ID.BANE, caster, target, ONE_MINUTE, Effect.SPELL_DIVINE_FAVOR);
                });
            }
        }

        public static Spell Entangle {
            get {
                return new Spell(
                    ID.ENTANGLE, CONJURATION, FIRST, CastingTime.ONE_ACTION, 90, VS,
                    ONE_MINUTE, 20, 20, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        foreach (Combattant target in targets) {
                            if (target.DC(ID.ENTANGLE, dc, AbilityType.STRENGTH)) {
                                GlobalEvents.AffectBySpell(caster, ID.ENTANGLE, target, false);
                            } else {
                                AddEffectAndConditionsForDuration(ID.ENTANGLE, caster, target, ONE_MINUTE, Effect.SPELL_ENTANGLE, ConditionType.RESTRAINED);
                            }
                        }
                    }
                );
            }
        }

        /* TODO: Needs implementation of "Dash" Bonus Action */
        public static Spell ExpeditiousRetreat {
            get {
                return new Spell(ID.EXPEDITIOUS_RETREAT, TRANSMUTATION, FIRST, CastingTime.BONUS_ACTION, 0, VS, TEN_MINUTES, 0, 0, doNothing);
            }
        }

        public static Spell FaerieFire {
            get {
                return new Spell(
                    ID.FAERIE_FIRE, EVOCATION, FIRST, CastingTime.ONE_ACTION, 60, V,
                    ONE_MINUTE, 20, 20, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        foreach (Combattant target in targets) {
                            if (target.DC(ID.FAERIE_FIRE, dc, AbilityType.DEXTERITY)) {
                                GlobalEvents.AffectBySpell(caster, ID.FAERIE_FIRE, target, false);
                            } else {
                                AddEffectsForDuration(ID.FAERIE_FIRE, caster, target, ONE_MINUTE, Effect.SPELL_FAIRIE_FIRE);
                            }
                        }
                    }
                );
            }
        }

        public static Spell FalseLife {
            get {
                return new Spell(ID.FALSE_LIFE, NECROMANCY, FIRST, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    int temporaryHitpoints = D4.Value + 4 + ((int)slot - 1) * 5;
                    GlobalEvents.AffectBySpell(caster, ID.FALSE_LIFE, caster, true);
                    caster.AddTemporaryHitpoints(temporaryHitpoints, ONE_HOUR, ID.FALSE_LIFE);
                });
            }
        }

        public static Spell FeatherFall {
            get {
                return new Spell(ID.FEATHER_FALL, TRANSMUTATION, FIRST, CastingTime.REACTION, 60, VM, ONE_MINUTE, 0, 5, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    foreach (Combattant target in targets) {
                        AddEffectsForDuration(ID.FEATHER_FALL, caster, target, ONE_MINUTE, Effect.SPELL_FEATHER_FALL);
                    }
                });
            }
        }

        public static Spell FindFamiliar {
            get {
                return new Spell(ID.FIND_FAMILIAR, CONJURATION, FIRST, CastingTime.ONE_HOUR, 10, VSM, INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.FIND_FAMILIAR));
            }
        }

        public static Spell FloatingDisk {
            get {
                return new Spell(ID.FLOATING_DISK, CONJURATION, FIRST, CastingTime.ONE_ACTION, 30, VSM, ONE_HOUR, 0, 0, SpellWithoutEffect(ID.FLOATING_DISK));
            }
        }

        public static Spell FogCloud {
            get {
                return new Spell(
                    ID.FOG_CLOUD, CONJURATION, FIRST, CastingTime.ONE_ACTION, 120, VS,
                    ONE_HOUR, 20, 0, SpellWithoutEffect(ID.FOG_CLOUD)
                );
            }
        }

        public static Spell Goodberry {
            get {
                return new Spell(ID.GOODBERRY, TRANSMUTATION, FIRST, CastingTime.ONE_ACTION, 0, VSM, INSTANTANEOUS, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    if (caster is CharacterSheet hero) {
                        for (int i = 0; i < 10; i++) {
                            hero.Inventory.AddToBag(Potions.Goodberry);
                        }
                    }
                });
            }
        }

        public static Spell Grease {
            get {
                return new Spell(ID.GREASE, CONJURATION, FIRST, CastingTime.ONE_ACTION, 60, VSM, ONE_MINUTE, 10, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    foreach (Combattant target in targets) {
                        if (!target.HasEffect(Effect.IMMUNITY_PRONE) && !target.DC(ID.GREASE, dc, AbilityType.DEXTERITY)) {
                            target.AddCondition(ConditionType.PRONE);
                            GlobalEvents.AffectBySpell(caster, ID.GREASE, target, true);
                        } else {
                            GlobalEvents.AffectBySpell(caster, ID.GREASE, target, false);
                        }
                    }
                });
            }
        }

        public static Spell GuidingBolt {
            get {
                return new Spell(ID.GUIDING_BOLT, EVOCATION, FIRST, CastingTime.ONE_ACTION, 120, VS, ONE_ROUND, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    Dice dice = DiceSlotScaling(FIRST, slot, D6, 3);
                    bool hit = SpellAttack(ID.GUIDING_BOLT, ground, caster, DamageType.RADIANT, dice, modifier, target, 120);
                    if (hit) {
                        target.AddEffect(Effect.ADVANTAGE_ON_BEING_ATTACKED);
                        bool removeNextRound = false;
                        caster.AddStartOfTurnEvent(delegate () {
                            removeNextRound = true;
                            return true;
                        });
                        caster.AddEndOfTurnEvent(delegate () {
                            if (removeNextRound) {
                                target.RemoveEffect(Effect.ADVANTAGE_ON_BEING_ATTACKED);
                                return true;
                            } else {
                                return false;
                            }
                        });
                    }
                });
            }
        }

        public static Spell HealingWord {
            get {
                return new Spell(
                    ID.HEALING_WORD, EVOCATION, FIRST, CastingTime.BONUS_ACTION, 60, V,
                    INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        Combattant target = targets[0];
                        if (target is Monster monster) {
                            if (monster.Type == Monsters.Type.CONSTRUCT || monster.Type == Monsters.Type.UNDEAD) {
                                GlobalEvents.AffectBySpell(caster, ID.HEALING_WORD, monster, false);
                                return;
                            };
                        }
                        Dice healed = DiceSlotScaling(FIRST, slot, D4, 1, modifier);
                        GlobalEvents.AffectBySpell(caster, ID.HEALING_WORD, target, true);
                        target.HealDamage(healed.Roll());
                    }
                );
            }
        }

        public static Spell HellishRebuke {
            get {
                return new Spell(ID.HELLISH_REBUKE, EVOCATION, FIRST, CastingTime.REACTION, 60, VS, INSTANTANEOUS, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    // Should only affect targets that damaged the caster but we can't determine this here
                    Dice dice = DiceSlotScaling(FIRST, slot, D10, 2);
                    Combattant target = targets[0];
                    target.TakeDamage(ID.HELLISH_REBUKE, DamageType.FIRE, dice.Roll(), DamageMitigation.HALVES_DAMAGE, dc, AbilityType.DEXTERITY, out _);
                    GlobalEvents.AffectBySpell(caster, ID.HELLISH_REBUKE, target, true);
                });
            }
        }

        public static Spell Heroism {
            get {
                return new Spell(ID.HEROISM, ENCHANTMENT, FIRST, CastingTime.ONE_ACTION, 0, VS, ONE_MINUTE, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    target.AddEffect(Effect.IMMUNITY_FRIGHTENED);
                    int remainingTurns = 10;
                    target.AddStartOfTurnEvent(delegate () {
                        target.AddTemporaryHitpoints(modifier, ONE_MINUTE, ID.HEROISM);
                        return --remainingTurns < 1;
                    });
                    target.AddEndOfTurnEvent(delegate () {
                        if (remainingTurns < 1) {
                            target.RemoveEffect(Effect.IMMUNITY_FRIGHTENED);
                            target.RemoveTemporaryHitpoints(ID.HEROISM);
                            return true;
                        } else {
                            return false;
                        }
                    });
                });
            }
        }

        public static Spell HideousLaughter {
            get {
                return new Spell(ID.HIDEOUS_LAUGHTER, ENCHANTMENT, FIRST, CastingTime.ONE_ACTION, 30, VSM, ONE_MINUTE, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    if (target.Intelligence.Value < 5 || target.DC(ID.HIDEOUS_LAUGHTER, dc, AbilityType.WISDOM)) {
                        GlobalEvents.AffectBySpell(caster, ID.HIDEOUS_LAUGHTER, target, false);
                    } else {
                        GlobalEvents.AffectBySpell(caster, ID.HIDEOUS_LAUGHTER, target, true);
                        target.AddCondition(ConditionType.PRONE, ConditionType.INCAPACITATED);
                        target.AddEffect(Effect.SPELL_HIDEOUS_LAUGHTER);
                        int remainingRounds = 10;
                        bool madeDC = false;
                        target.AddDamageTakenEvent(delegate (object source, Damage damage) {
                            if (madeDC) {
                                return true;
                            } else if (target.DC(ID.HIDEOUS_LAUGHTER, dc, AbilityType.WISDOM, out _, true)) {
                                madeDC = true;
                                remainingRounds = 0;
                                target.RemoveEffect(Effect.SPELL_HIDEOUS_LAUGHTER);
                                target.RemoveCondition(ConditionType.INCAPACITATED);
                                return true;
                            } else {
                                return false;
                            }
                        });
                        target.AddEndOfTurnEvent(delegate () {
                            if (madeDC) {
                                return true;
                            } else if (--remainingRounds < 1 || target.DC(ID.HIDEOUS_LAUGHTER, dc, AbilityType.WISDOM)) {
                                madeDC = true;
                                target.RemoveEffect(Effect.SPELL_HIDEOUS_LAUGHTER);
                                target.RemoveCondition(ConditionType.INCAPACITATED);
                                return true;
                            } else {
                                return false;
                            }
                        });
                    }
                });
            }
        }

        public static Spell HuntersMark {
            get {
                return new Spell(ID.HUNTERS_MARK, DIVINATION, FIRST, CastingTime.BONUS_ACTION, 90, V, ONE_HOUR, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    target.AddDamageTakenEvent(delegate (object source, Damage damage) {
                        if (caster.Equals(source)) {
                            target.TakeDamage(ID.HUNTERS_MARK, DamageType.TRUE_DAMAGE, "1d6");
                        }
                        return false;
                    });
                });
            }
        }

        /* TODO: At some point we will want to have unidentified items*/
        public static Spell Identify {
            get {
                return new Spell(ID.IDENTIFY, DIVINATION, FIRST, CastingTime.ONE_MINUTE, 0, VSM, INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.IDENTIFY));
            }
        }

        public static Spell IllusoryScript {
            get {
                return new Spell(ID.ILLUSORY_SCRIPT, ILLUSION, FIRST, CastingTime.ONE_MINUTE, 0, SM, TEN_DAYS, 0, 0, SpellWithoutEffect(ID.ILLUSORY_SCRIPT));
            }
        }

        public static Spell InflictWounds {
            get {
                return new Spell(ID.INFLICT_WOUNDS, NECROMANCY, FIRST, CastingTime.ONE_ACTION, 0, VS, INSTANTANEOUS, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    Dice dice = DiceSlotScaling(FIRST, slot, D10, 2);
                    SpellAttack(ID.INFLICT_WOUNDS, ground, caster, DamageType.NECROTIC, dice, modifier, target, 5);
                });
            }
        }

        public static Spell Jump {
            get {
                return new Spell(
                    ID.JUMP, TRANSMUTATION, FIRST, CastingTime.ONE_ACTION, 0, VSM,
                    ONE_MINUTE, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        Combattant target = targets[0];
                        GlobalEvents.AffectBySpell(caster, ID.JUMP, target, true);
                        target.AddEffect(Effect.SPELL_JUMP);
                    }
                );
            }
        }

        public static Spell Longstrider {
            get {
                return new Spell(
                    ID.LONGSTRIDER, TRANSMUTATION, FIRST, CastingTime.ONE_ACTION, 0, VSM,
                    ONE_HOUR, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        Combattant target = targets[0];
                        GlobalEvents.AffectBySpell(caster, ID.LONGSTRIDER, target, true);
                        target.AddEffect(Effect.SPELL_LONGSTRIDER);
                    }
                );
            }
        }

        public static Spell MageArmor {
            get {
                return new Spell(ID.MAGE_ARMOR, ABJURATION, FIRST, CastingTime.ONE_ACTION, 0, VSM, EIGHT_HOURS, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    if (target is CharacterSheet hero && hero.Inventory.Armor == null) {
                        GlobalEvents.AffectBySpell(caster, ID.MAGE_ARMOR, hero, true);
                        hero.Equip(Armors.MageArmor);
                    } else {
                        GlobalEvents.AffectBySpell(caster, ID.MAGE_ARMOR, target, true);
                    }
                });
            }
        }

        public static Spell MagicMissile {
            get {
                return new Spell(
                    ID.MAGIC_MISSILE, EVOCATION, FIRST, CastingTime.ONE_ACTION, 120, VS,
                    INSTANTANEOUS, 0, 20, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        Damage damage = new Damage(DamageType.FORCE, "1d4+1");
                        int missilesTotal = (int)slot + 2;
                        foreach (Combattant possibleTarget in targets) {
                            Combattant target = possibleTarget;
                            if (target.HasFeat(Feat.REFLECTIVE_CARAPACE)) {
                                GlobalEvents.ActivateFeat(target, Feat.REFLECTIVE_CARAPACE);
                                GlobalEvents.AffectBySpell(caster, ID.MAGIC_MISSILE, target, false);
                                if (D6.Value == 6) {
                                    target = caster;
                                }
                            }
                            GlobalEvents.AffectBySpell(caster, ID.MAGIC_MISSILE, target, true);
                            int bonusMissiles = missilesTotal % targets.Length;
                            bonusMissiles = Math.Min(1, bonusMissiles);
                            missilesTotal -= bonusMissiles;
                            for (int m = 0; m < missilesTotal / targets.Length + bonusMissiles; m++) {
                                if (target.HasEffect(Effect.SPELL_SHIELD)) {
                                    target.TakeDamage(ID.MAGIC_MISSILE, damage.Type, 0);
                                } else {
                                    target.TakeDamage(ID.MAGIC_MISSILE, damage.Type, damage.Dice.Roll());
                                }
                            }
                        }
                    }
                );
            }
        }

        public static Spell ProtectionfromEvilandGood {
            get {
                return new Spell(ID.PROTECTION_FROM_EVIL_AND_GOOD, ABJURATION, FIRST, CastingTime.ONE_ACTION, 0, VSM, TEN_MINUTES, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    // TODO: The target also can't be charmed, frightened, or possessed by them. If the target is already charmed, frightened, 
                    //       or possessed by such a creature, the target has advantage on any new saving throw against the relevant effect.
                    Combattant target = targets[0];
                    AddEffectsForDuration(ID.PROTECTION_FROM_EVIL_AND_GOOD, caster, target, TEN_MINUTES, Effect.SPELL_PROTECTION_FROM_EVIL_AND_GOOD);
                });
            }
        }

        public static Spell PurifyFoodAndDrink {
            get {
                return new Spell(
                    ID.PURIFY_FOOD_AND_DRINK, TRANSMUTATION, FIRST, CastingTime.ONE_ACTION, 10, VS,
                    INSTANTANEOUS, 5, 0, SpellWithoutEffect(ID.PURIFY_FOOD_AND_DRINK)
                );
            }
        }

        // TODO: Right now, we don't have a means to redirect a target
        public static Spell Sanctuary {
            get {
                return new Spell(ID.SANCTUARY, ABJURATION, FIRST, CastingTime.BONUS_ACTION, 30, VSM, ONE_MINUTE, 0, 0, SpellWithoutEffect(ID.SANCTUARY));
            }
        }

        public static Spell Shield {
            get {
                return new Spell(ID.SHIELD, ABJURATION, FIRST, CastingTime.REACTION, 0, VS, ONE_ROUND, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    // TODO: Right now, there is no way to apply the +5 AC buff to the attack that this spell is used as a reaction
                    GlobalEvents.AffectBySpell(caster, ID.SHIELD, caster, true);
                    caster.AddEffect(Effect.SPELL_SHIELD);
                    caster.ArmorClassModifier += 5;
                    caster.AddStartOfTurnEvent(delegate () {
                        caster.ArmorClassModifier -= 5;
                        caster.RemoveEffect(Effect.SPELL_SHIELD);
                        return true;
                    });
                });
            }
        }

        public static Spell ShieldofFaith {
            get {
                return new Spell(ID.SHIELD_OF_FAITH, ABJURATION, FIRST, CastingTime.BONUS_ACTION, 60, VSM, TEN_MINUTES, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    if (target.HasEffect(Effect.SPELL_SHIELD_OF_FAITH)) {
                        GlobalEvents.AffectBySpell(caster, ID.SHIELD_OF_FAITH, target, false);
                    } else {
                        GlobalEvents.AffectBySpell(caster, ID.SHIELD_OF_FAITH, target, true);
                        target.AddEffect(Effect.SPELL_SHIELD_OF_FAITH);
                        target.ArmorClassModifier += 2;
                        int remainingRounds = 100;
                        target.AddEndOfTurnEvent(delegate () {
                            if (--remainingRounds < 1) {
                                target.ArmorClassModifier -= 2;
                                target.RemoveEffect(Effect.SPELL_SHIELD_OF_FAITH);
                                return true;
                            } else {
                                return false;
                            }
                        });
                    }
                });
            }
        }

        public static Spell SilentImage {
            get {
                return new Spell(ID.SILENT_IMAGE, ILLUSION, FIRST, CastingTime.ONE_ACTION, 60, VSM, TEN_MINUTES, 15, 0, SpellWithoutEffect(ID.SILENT_IMAGE));
            }
        }

        public static Spell Sleep {
            get {
                return new Spell(ID.SLEEP, ENCHANTMENT, FIRST, CastingTime.ONE_ACTION, 90, VSM, ONE_MINUTE, 20, 99,
                    delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        Dice dice = DiceSlotScaling(FIRST, slot, D8, 5, 0, 2);
                        int remainingHitpoints = dice.Roll();
                        Array.Sort(targets, (t1, t2) => {
                            return t1.HitPoints.CompareTo(t2.HitPoints);
                        });
                        for (int i = 0; i < targets.Length && targets[i].HitPoints <= remainingHitpoints; i++) {
                            Combattant target = targets[i];
                            // ignoring unconscious creatures
                            if (target.HasCondition(ConditionType.UNCONSCIOUS)) continue;
                            // Undead and creatures immune to being charmed aren't affected by this spell
                            if (target.HasEffect(Effect.IMMUNITY_CHARMED)) continue;
                            if (target is Monster monster && monster.Type == Monsters.Type.UNDEAD) continue;
                            // substract hitpoints and make target unconcious for one minute (10 rounds)
                            int remainingRounds = 10;
                            remainingHitpoints -= target.HitPoints;
                            target.AddCondition(ConditionType.UNCONSCIOUS);
                            bool targetTookDamage = false;
                            target.AddDamageTakenEvent(delegate (object source, Damage damage) {
                                targetTookDamage = true;
                                return true;
                            });

                            target.AddEndOfTurnEvent(delegate () {
                                if (targetTookDamage || --remainingRounds < 1) {
                                    target.RemoveCondition(ConditionType.UNCONSCIOUS);
                                    return true;
                                }
                                return false;
                            });
                        }
                    }
                );
            }
        }

        public static Spell SpeakWithAnimals {
            get {
                return new Spell(
                    ID.SPEAK_WITH_ANIMALS, DIVINATION, FIRST, CastingTime.ONE_ACTION, 0, VS,
                    TEN_MINUTES, 0, 0, SpellWithoutEffect(ID.SPEAK_WITH_ANIMALS)
                );
            }
        }

        public static Spell Thunderwave {
            get {
                return new Spell(
                    ID.THUNDERWAVE, EVOCATION, FIRST, CastingTime.ONE_ACTION, 15, VS,
                    INSTANTANEOUS, 15, 20, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                        Dice dice = DiceSlotScaling(FIRST, slot, D8);
                        foreach (Combattant target in targets) {
                            GlobalEvents.AffectBySpell(caster, ID.THUNDERWAVE, target, true);
                            target.TakeDamage(ID.THUNDERWAVE, DamageType.THUNDER, dice, DamageMitigation.HALVES_DAMAGE, dc, AbilityType.CONSTITUTION, out bool dcResult);
                            if (!dcResult) {
                                ground.Push(ground.LocateCombattant(caster), target, 10);
                            }
                        }
                    }
                );
            }
        }

        public static Spell UnseenServant {
            get {
                return new Spell(ID.UNSEEN_SERVANT, CONJURATION, FIRST, CastingTime.ONE_ACTION, 60, VSM, ONE_HOUR, 0, 0, SpellWithoutEffect(ID.UNSEEN_SERVANT));
            }
        }
    }
}
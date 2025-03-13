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
                SpellCastEffect castEffect = delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                    Combattant target = targets[0];
                    if (target.DC(ID.BESTOW_CURSE, dc, WISDOM)) {
                        GlobalEvents.AffectBySpell(caster, ID.BESTOW_CURSE, target, false);
                        return;
                    }
                    SpellDuration duration = ONE_MINUTE;
                    if (slot == NINETH) duration = UNTIL_DISPELLED;
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
                return new Spell(ID.CALL_LIGHTNING, CONJURATION, THIRD, CastingTime.ONE_ACTION, 120, VS, TEN_MINUTES, 5, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                });
            }
        }
        /* TODO */
        public static Spell Clairvoyance {
            get {
                return new Spell(ID.CLAIRVOYANCE, DIVINATION, THIRD, CastingTime.TEN_MINUTES, 5280, VSM, TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ConjureAnimals {
            get {
                return new Spell(ID.CONJURE_ANIMALS, CONJURATION, THIRD, CastingTime.ONE_ACTION, 60, VS, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Counterspell {
            get {
                return new Spell(ID.COUNTERSPELL, ABJURATION, THIRD, CastingTime.REACTION, 60, S, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell CreateFoodandWater {
            get {
                return new Spell(ID.CREATE_FOOD_AND_WATER, CONJURATION, THIRD, CastingTime.ONE_ACTION, 30, VS, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Daylight {
            get {
                return new Spell(ID.DAYLIGHT, EVOCATION, THIRD, CastingTime.ONE_ACTION, 60, VS, ONE_HOUR, 60, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell DispelMagic {
            get {
                return new Spell(ID.DISPEL_MAGIC, ABJURATION, THIRD, CastingTime.ONE_ACTION, 120, VS, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Fear {
            get {
                return new Spell(ID.FEAR, ILLUSION, THIRD, CastingTime.ONE_ACTION, 0, VSM, ONE_MINUTE, 30, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Fireball {
            get {
                return new Spell(ID.FIREBALL, EVOCATION, THIRD, CastingTime.ONE_ACTION, 150, VSM, INSTANTANEOUS, 20, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Fly {
            get {
                return new Spell(ID.FLY, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 0, VSM, TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell GaseousForm {
            get {
                return new Spell(ID.GASEOUS_FORM, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell GlyphofWarding {
            get {
                return new Spell(ID.GLYPH_OF_WARDING, ABJURATION, THIRD, CastingTime.ONE_HOUR, 0, VSM, UNTIL_DISPELLED, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Haste {
            get {
                return new Spell(ID.HASTE, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 30, VSM, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell HypnoticPattern {
            get {
                return new Spell(ID.HYPNOTIC_PATTERN, ILLUSION, THIRD, CastingTime.ONE_ACTION, 120, SM, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell LightningBolt {
            get {
                return new Spell(ID.LIGHTNING_BOLT, EVOCATION, THIRD, CastingTime.ONE_ACTION, 0, VSM, INSTANTANEOUS, 100, 0, doNothing);
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
        /* TODO */
        public static Spell MassHealingWord {
            get {
                return new Spell(ID.MASS_HEALING_WORD, EVOCATION, THIRD, CastingTime.BONUS_ACTION, 60, V, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell MeldIntoStone {
            get {
                return new Spell(ID.MELD_INTO_STONE, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 0, VS, EIGHT_HOURS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Nondetection {
            get {
                return new Spell(ID.NONDETECTION, ABJURATION, THIRD, CastingTime.ONE_ACTION, 0, VSM, EIGHT_HOURS, 0, 0, doNothing);
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
        /* TODO */
        public static Spell ProtectionFromEnergy {
            get {
                return new Spell(ID.PROTECTION_FROM_ENERGY, ABJURATION, THIRD, CastingTime.ONE_ACTION, 0, VS, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell RemoveCurse {
            get {
                return new Spell(ID.REMOVE_CURSE, ABJURATION, THIRD, CastingTime.ONE_ACTION, 0, VS, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Revivify {
            get {
                return new Spell(ID.REVIVIFY, CONJURATION, THIRD, CastingTime.ONE_ACTION, 0, VSM, INSTANTANEOUS, 0, 0, doNothing);
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
                return new Spell(ID.SLEET_STORM, CONJURATION, THIRD, CastingTime.ONE_ACTION, 150, VSM, ONE_MINUTE, 40, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Slow {
            get {
                return new Spell(ID.SLOW, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 120, VSM, ONE_MINUTE, 40, 0, doNothing);
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
        /* TODO */
        public static Spell SpiritGuardians {
            get {
                return new Spell(ID.SPIRIT_GUARDIANS, CONJURATION, THIRD, CastingTime.ONE_ACTION, 0, VSM, TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell StinkingCloud {
            get {
                return new Spell(ID.STINKING_CLOUD, CONJURATION, THIRD, CastingTime.ONE_ACTION, 90, VSM, ONE_MINUTE, 20, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell TinyHut {
            get {
                return new Spell(ID.TINY_HUT, EVOCATION, THIRD, CastingTime.ONE_MINUTE, 0, VSM, EIGHT_HOURS, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Tongues {
            get {
                return new Spell(ID.TONGUES, DIVINATION, THIRD, CastingTime.ONE_ACTION, 0, VM, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell VampiricTouch {
            get {
                return new Spell(ID.VAMPIRIC_TOUCH, NECROMANCY, THIRD, CastingTime.ONE_ACTION, 0, VS, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell WaterBreathing {
            get {
                return new Spell(ID.WATER_BREATHING, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 30, VSM, ONE_DAY, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell WaterWalk {
            get {
                return new Spell(ID.WATER_WALK, TRANSMUTATION, THIRD, CastingTime.ONE_ACTION, 30, VSM, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell WindWall {
            get {
                return new Spell(ID.WIND_WALL, EVOCATION, THIRD, CastingTime.ONE_ACTION, 120, VSM, ONE_MINUTE, 50, 0, doNothing);
            }
        }
    }
}
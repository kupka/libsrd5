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

        /* TODO:
        Objects come to life at your command.
        Choose up to ten nonmagical objects within range that are not being worn or
        carried.
        Medium targets count as two objects, Large targets count as four objects, Huge
        targets count as eight objects.
        You can't animate any object larger than Huge.
        Each target animates and becomes a creature under your control until the spell
        ends or until reduced to 0 hit points.
        As a bonus action, you can mentally command any creature you made with this spell
        if the creature is within 500 feet of you (if you control multiple creatures, you
        can command any or all of them at the same time, issuing the same command to each
        one).
        You decide what action the creature will take and where it will move during its
        next turn, or you can issue a general command, such as to guard a particular
        chamber or corridor.
        If you issue no commands, the creature only defends itself against hostile
        creatures.
        Once given an order, the creature continues to follow it until its task is
        complete.
        An animated object is a construct with AC, hit points, attacks, Strength, and
        Dexterity determined by its size.
        Its Constitution is 10 and its Intelligence and Wisdom are 3, and its Charisma is
        1.
        Its speed is 30 feet; if the object lacks legs or other appendages it can use for
        locomotion, it instead has a flying speed of 30 feet and can hover.
        If the object is securely attached to a surface or a larger object, such as a
        chain bolted to a wall, its speed is 0.
        It has blindsight with a radius of 30 feet and is blind beyond that distance.
        When the animated object drops to 0 hit points, it reverts to its original object
        form, and any remaining damage carries over to its original object form.
        If you command an object to attack, it can make a single melee attack against a
        creature within 5 feet of it.
        It makes a slam attack with an attack bonus and bludgeoning damage determined by
        its size.
        The DM might rule that a specific object inflicts slashing or piercing damage
        based on its form.
        If you cast this spell using a spell slot of 6th level or higher, you can animate
        two additional objects for each slot level above 5th.
         */
        public static Spell AnimateObjects {
            get {
                return new Spell(ID.ANIMATE_OBJECTS, TRANSMUTATION, FIFTH, CastingTime.ONE_ACTION, 120, VS, ONE_MINUTE, 0, 0, doNothing);
            }
        }

        /*
        A shimmering barrier extends out from you in a 10-foot radius and moves with you,
        remaining centered on you and hedging out creatures other than undead and
        constructs.
        The barrier lasts for the duration.
        The barrier prevents an affected creature from passing or reaching through.
        An affected creature can cast spells or make attacks with ranged or reach weapons
        through the barrier.
        If you move so that an affected creature is forced to pass through the barrier,
        the spell ends.
         */
        public static Spell AntilifeShell {
            get {
                return new Spell(ID.ANTILIFE_SHELL, ABJURATION, FIFTH, CastingTime.ONE_ACTION, 0, VS, ONE_HOUR, 10, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // The barrier moves with the caster. Creatures other than undead and constructs can't reach
                    // through it, so their melee attacks against the caster fail (see Combatant.Attack).
                    // Ranged attacks and attacks with reach weapons still pass the barrier.
                    // TODO: The spell ends if the caster moves so that an affected creature is forced to pass through the barrier
                    AddEffectsForDuration(ID.ANTILIFE_SHELL, caster, caster, ONE_HOUR, SPELL_ANTILIFE_SHELL);
                });
            }
        }

        /*
        You create a Large hand of shimmering, translucent force in an unoccupied space
        that you can see within range.
        The hand lasts for the spell's duration, and it moves at your command, mimicking
        the movements of your own hand.
        The hand is an object that has AC 20 and hit points equal to your hit point
        maximum.
        If it drops to 0 hit points, the spell ends.
        It has a Strength of 26 (+8) and a Dexterity of 10 (+0).
        The hand doesn't fill its space.
        When you cast the spell and as a bonus action on your subsequent turns, you can
        move the hand up to 60 feet and then cause one of the following effects with it.
        ***Clenched Fist.*** The hand strikes one creature or object within 5 feet of it.
        Make a melee spell attack for the hand using your game statistics.
        On a hit, the target takes 4d8 force damage.
        ***Forceful Hand.*** The hand attempts to push a creature within 5 feet of it in a
        direction you choose.
        Make a check with the hand's Strength contested by the Strength (Athletics) check
        of the target.
        If the target is Medium or smaller, you have advantage on the check.
        If you succeed, the hand pushes the target up to 5 feet plus a number of feet
        equal to five times your spellcasting ability modifier.
        The hand moves with the target to remain within 5 feet of it.
        ***Grasping Hand.*** The hand attempts to grapple a Huge or smaller creature
        within 5 feet of it.
        You use the hand's Strength score to resolve the grapple.
        If the target is Medium or smaller, you have advantage on the check.
        While the hand is grappling the target, you can use a bonus action to have the
        hand crush it.
        When you do so, the target takes bludgeoning damage equal to 2d6 + your
        spellcasting ability modifier.
        ***Interposing Hand.*** The hand interposes itself between you and a creature you
        choose until you give the hand a different command.
        The hand moves to stay between you and the target, providing you with half cover
        against the target.
        The target can't move through the hand's space if its Strength score is less than
        or equal to the hand's Strength score.
        If its Strength score is higher than the hand's Strength score, the target can
        move toward you through the hand's space, but that space is difficult terrain for
        the target.
        When you cast this spell using a spell slot of 6th level or higher, the damage
        from the clenched fist option increases by 2d8 and the damage from the grasping
        hand increases by 2d6 for each slot level above 5th.
         */
        public static Spell ArcaneHand {
            get {
                // Note: Since we cannot currently place objects on a Battlefield and move them around,
                // the hand sort of follows the caster: on casting it can reach a creature within 125 feet
                // (placed within 120 feet + 5 feet reach), afterwards within 65 feet (moves 60 feet + 5 feet reach).
                // TODO: The hand is an object with AC 20 and hit points equal to the caster's hit point maximum
                // TODO: Interposing Hand doesn't restrict the movement of the target yet
                Spell arcaneHand = new Spell(ID.ARCANE_HAND, EVOCATION, FIFTH, CastingTime.ONE_ACTION, 120, VSM, ONE_MINUTE, 0, 1);
                arcaneHand.Variants = new SpellVariant[] { CLENCHED_FIST, FORCEFUL_HAND, GRASPING_HAND, CRUSH, INTERPOSING_HAND };
                arcaneHand.Variant = CLENCHED_FIST;
                arcaneHand.CastEffect = delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // The hand has a Strength of 26 (+8)
                    const int handStrength = 26;
                    const int handStrengthModifier = 8;
                    Combatant grasped = null;
                    // Each interposing command gets a new token, so outdated cover effects can detect that they are no longer active
                    object interposition = null;
                    bool spellEnded = false;

                    void releaseGrasp() {
                        if (grasped != null && grasped.HasCondition(ConditionType.GRAPPLED_DC26))
                            grasped.RemoveCondition(ConditionType.GRAPPLED_DC26);
                        grasped = null;
                    }

                    // The target resists the grapple with either Strength (Athletics) or Dexterity (Acrobatics), whichever is better
                    bool resistsGrapple(Combatant target, bool disadvantage) {
                        int athletics = target.Strength.Modifier + (target.IsProficient(Skill.ATHLETICS) ? target.ProficiencyBonus : 0);
                        int acrobatics = target.Dexterity.Modifier + (target.IsProficient(Skill.ACROBATICS) ? target.ProficiencyBonus : 0);
                        Skill skill = athletics >= acrobatics ? Skill.ATHLETICS : Skill.ACROBATICS;
                        return target.DC(ID.ARCANE_HAND, handStrength, skill, false, disadvantage);
                    }

                    // Half cover: the interposed target's attacks against the caster get -2 (equal to +2 AC)
                    void interpose(Combatant target) {
                        object token = new object();
                        interposition = token;
                        target.AddAttackModifyingEffect(delegate (ref bool advantage, ref bool disadvantage, ref Attack attack, ref Combatant attacked) {
                            if (interposition != token) return true; // hand received a different command or the spell ended
                            if (attacked != caster) return false;
                            // Use a copy, so the target's attack is not modified permanently
                            Attack covered = new Attack(attack.Name, attack.AttackBonus - 2, attack.Damage, attack.Reach, attack.RangeNormal, attack.RangeLong);
                            covered.AddAdditionalDamage(attack.AdditionalDamage);
                            covered.AddAttackEffect(attack.EffectOnHit);
                            covered.WithProperties(attack.Properties);
                            covered.LockedTarget = attack.LockedTarget;
                            attack = covered;
                            return false;
                        });
                    }

                    void command(ID id, SpellVariant variant, Combatant target, int range, int spellModifier) {
                        bool holdsTarget = grasped == target && target.HasCondition(ConditionType.GRAPPLED_DC26);
                        // Any command ends the interposition, and the hand lets go unless it keeps (or crushes) the grasped target
                        interposition = null;
                        if (!(variant == CRUSH || (variant == GRASPING_HAND && holdsTarget))) releaseGrasp();
                        int distance = ground.Distance(caster, target);
                        if (distance > range) {
                            GlobalEvents.AffectBySpell(caster, id, target, false);
                            return;
                        }
                        // The hand has advantage on Strength checks against Medium or smaller targets
                        bool handAdvantage = target.Size <= Size.MEDIUM;
                        switch (variant) {
                            case CLENCHED_FIST:
                                // Melee spell attack made by the hand next to the target: modelled with the hand's reach,
                                // so it doesn't count as a ranged attack (no disadvantage when the caster is within 5 feet of the target)
                                // 4d8 force + 2d8 for each slot level above 5th
                                Attack fist = new Attack(id.Name(), spellModifier + caster.ProficiencyBonus, new Damage(FORCE, DiceSlotScaling(FIFTH, slot, D8, 4, 0, 2)), range);
                                GlobalEvents.AffectBySpell(caster, id, target, caster.Attack(fist, target, distance, false, true));
                                break;
                            case FORCEFUL_HAND:
                                // Contest: the hand's Strength check against the target's Strength (Athletics), the target wins ties
                                int handCheck = (handAdvantage ? D20Advantage : D20).Value + handStrengthModifier;
                                if (target.DC(id, handCheck, Skill.ATHLETICS)) {
                                    GlobalEvents.AffectBySpell(caster, id, target, false);
                                } else {
                                    GlobalEvents.AffectBySpell(caster, id, target, true);
                                    ground.Push(ground.LocateCombatant(caster), target, 5 + 5 * Math.Max(0, spellModifier));
                                }
                                break;
                            case GRASPING_HAND:
                                // The hand's advantage is modelled as disadvantage on the target's check against DC 26
                                if (holdsTarget || target.Size > Size.HUGE || target.HasEffect(IMMUNITY_GRAPPLED) || resistsGrapple(target, handAdvantage)) {
                                    GlobalEvents.AffectBySpell(caster, id, target, false);
                                } else {
                                    GlobalEvents.AffectBySpell(caster, id, target, true);
                                    target.AddCondition(ConditionType.GRAPPLED_DC26);
                                    grasped = target;
                                }
                                break;
                            case CRUSH:
                                // Only possible while the hand is grappling the target
                                if (!holdsTarget) {
                                    GlobalEvents.AffectBySpell(caster, id, target, false);
                                } else {
                                    // 2d6 + spellcasting ability modifier bludgeoning + 2d6 for each slot level above 5th
                                    GlobalEvents.AffectBySpell(caster, id, target, true);
                                    target.TakeDamage(new DamageSource(id, caster), BLUDGEONING, DiceSlotScaling(FIFTH, slot, D6, 2, spellModifier, 2));
                                }
                                break;
                            case INTERPOSING_HAND:
                            default:
                                GlobalEvents.AffectBySpell(caster, id, target, true);
                                interpose(target);
                                break;
                        }
                    }

                    command(ID.ARCANE_HAND, arcaneHand.Variant, targets[0], 125, modifier);

                    // As a bonus action on subsequent turns, the caster can command the hand again
                    // TODO: This cantrip workaround should be replaced by correctly implementing situative actions
                    Spell handCantrip = new Spell(ID.ARCANE_HAND_ATTACK, EVOCATION, CANTRIP, CastingTime.BONUS_ACTION, 65, V, INSTANTANEOUS, 0, 1);
                    handCantrip.Variants = arcaneHand.Variants;
                    handCantrip.Variant = CLENCHED_FIST;
                    handCantrip.CastEffect = delegate (Battleground ground2, Combatant caster2, int dc2, SpellLevel slot2, int modifier2, Combatant[] targets2) {
                        if (spellEnded) return;
                        command(ID.ARCANE_HAND_ATTACK, handCantrip.Variant, targets2[0], 65, modifier2);
                    };
                    caster.AvailableSpells[0].AddKnownSpell(handCantrip);
                    caster.AvailableSpells[0].AddPreparedSpell(handCantrip);
                    int remainingRounds = (int)ONE_MINUTE;
                    caster.AddEndOfTurnEvent(delegate () {
                        if (--remainingRounds > 0) return false;
                        spellEnded = true;
                        interposition = null;
                        releaseGrasp();
                        caster.AvailableSpells[0].RemoveKnownSpell(handCantrip);
                        caster.AvailableSpells[0].RemovePreparedSpell(handCantrip);
                        return true;
                    });
                };
                return arcaneHand;
            }
        }

        /*
        After spending the casting time tracing magical pathways within a precious
        gemstone, you touch a Huge or smaller beast or plant.
        The target must have either no Intelligence score or an Intelligence of 3 or less.
        The target gains an Intelligence of 10.
        The target also gains the ability to speak one language you know.
        If the target is a plant, it gains the ability to move its limbs, roots, vines,
        creepers, and so forth, and it gains senses similar to a human's.
        Your DM chooses statistics appropriate for the awakened plant, such as the
        statistics for the awakened shrub or the awakened tree.
        The awakened beast or plant is charmed by you for 30 days or until you or your
        companions do anything harmful to it.
        When the charmed condition ends, the awakened creature chooses whether to remain
        friendly to you, based on how you treated it while it was charmed.
         */
        public static Spell Awaken {
            get {
                return new Spell(ID.AWAKEN, TRANSMUTATION, FIFTH, CastingTime.EIGHT_HOURS, 0, VSM, INSTANTANEOUS, 0, 1,
                        delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                            Combatant target = targets[0];
                            // Only a Huge or smaller beast or plant with an Intelligence of 3 or less can be awakened
                            if (!(target is Monster monster) || (monster.Type != Monsters.Type.BEAST && monster.Type != Monsters.Type.PLANT)
                                    || monster.Intelligence.Value > 3 || monster.Size > Size.HUGE) {
                                GlobalEvents.AffectBySpell(caster, ID.AWAKEN, target, false);
                                return;
                            }
                            GlobalEvents.AffectBySpell(caster, ID.AWAKEN, target, true);
                            // The awakening itself is permanent
                            // TODO: The target gains the ability to speak one language the caster knows, plants gain the ability to move and senses
                            monster.Intelligence.BaseValue = 10;
                            if (monster.HasEffect(IMMUNITY_CHARMED)) return;

                            // The awakened creature is charmed by the caster for 30 days
                            monster.AddEffect(SPELL_AWAKEN);
                            monster.AddCondition(ConditionType.CHARMED);
                            Team originalTeam = ground.GetTeam(monster);
                            ground.SetTeam(monster, ground.GetTeam(caster));
                            bool charmEnded = false;
                            void endCharm() {
                                charmEnded = true;
                                monster.RemoveEffect(SPELL_AWAKEN);
                                monster.RemoveCondition(ConditionType.CHARMED);
                                ground.SetTeam(monster, originalTeam);
                            }
                            // The charm ends if the caster or the caster's companions harm the creature
                            monster.AddDamageTakenEvent(delegate (DamageSource source, Damage damage) {
                                if (charmEnded) return true;
                                Combatant attacker = source.Source;
                                if (attacker == null || Array.IndexOf(ground.combatants, attacker) < 0 || ground.GetTeam(attacker) != ground.GetTeam(caster)) return false;
                                endCharm();
                                return true;
                            });
                            int remainingRounds = (int)THIRTY_DAYS;
                            caster.AddEndOfTurnEvent(delegate () {
                                if (charmEnded) return true;
                                if (--remainingRounds < 1 || !monster.HasEffect(SPELL_AWAKEN)) {
                                    endCharm();
                                    return true;
                                }
                                return false;
                            });
                        });
            }
        }

        /*
        You create a 20-foot-radius sphere of poisonous, yellow-green fog centered on a
        point you choose within range.
        The fog spreads around corners.
        It lasts for the duration or until strong wind disperses the fog, ending the
        spell.
        Its area is heavily obscured.
        When a creature enters the spell's area for the first time on a turn or starts its
        turn there, that creature must make a constitution saving throw.
        The creature takes 5d8 poison damage on a failed save, or half as much damage on a
        successful one.
        Creatures are affected even if they hold their breath or don't need to breathe.
        The fog moves 10 feet away from you at the start of each of your turns, rolling
        along the surface of the ground.
        The vapors, being heavier than air, sink to the lowest level of the land, even
        pouring down openings.
        When you cast this spell using a spell slot of 6th level or higher, the damage
        increases by 1d8 for each slot level above 5th.
         */
        public static Spell Cloudkill {
            get {
                return new Spell(ID.CLOUDKILL, CONJURATION, FIFTH, CastingTime.ONE_ACTION, 120, VS, TEN_MINUTES, 20, 20,
                        delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                            // 5d8 poison base + 1d8 for each slot level above 5th
                            Dice damage = DiceSlotScaling(FIFTH, slot, D8, 5);
                            GlobalEvents.AffectBySpell(caster, ID.CLOUDKILL, caster, true);

                            foreach (Combatant target in targets) {
                                // Mark this creature as being in the cloud
                                GlobalEvents.AffectBySpell(caster, ID.CLOUDKILL, target, true);
                                target.AddEffect(SPELL_CLOUDKILL);

                                // Creature is in the area when the cloud appears: CON save for half
                                target.TakeDamage(new DamageSource(ID.CLOUDKILL, caster), POISON, damage, HALVES_DAMAGE, dc, CONSTITUTION, out _);

                                // At the start of each turn inside the cloud, the creature must save again
                                target.AddStartOfTurnEvent(delegate () {
                                    if (!target.HasEffect(SPELL_CLOUDKILL)) return true;
                                    target.TakeDamage(new DamageSource(ID.CLOUDKILL, caster), POISON, damage, HALVES_DAMAGE, dc, CONSTITUTION, out _);
                                    return false;
                                });

                                // TODO: Remove effect when target moves outside the cloud
                                // TODO: The cloud moves 10 feet away from the caster at the start of each of its turns
                            }

                            // Duration: cloud lingers for 10 minutes
                            int remainingRounds = (int)TEN_MINUTES;
                            caster.AddEndOfTurnEvent(delegate () {
                                if (--remainingRounds < 1) {
                                    foreach (Combatant target in targets) {
                                        target.RemoveEffect(SPELL_CLOUDKILL);
                                    }
                                    return true;
                                }
                                return false;
                            });
                        });
            }
        }

        /* TODO:
        You contact your deity or a divine proxy and ask up to three questions that can be
        answered with a yes or no.
        You must ask your questions before the spell ends.
        You receive a correct answer for each question.
        Divine beings aren't necessarily omniscient, so you might receive "unclear" as an
        answer if a question pertains to information that lies beyond the deity's
        knowledge.
        In a case where a one-word answer could be misleading or contrary to the deity's
        interests, the DM might offer a short phrase as an answer instead.
        If you cast the spell two or more times before finishing your next long rest,
        there is a cumulative 25 percent chance for each casting after the first that you
        get no answer.
        The DM makes this roll in secret.
         */
        public static Spell Commune {
            get {
                return new Spell(ID.COMMUNE, DIVINATION, FIFTH, CastingTime.ONE_MINUTE, 0, VSM, ONE_MINUTE, 0, 0, doNothing);
            }
        }

        /* TODO:
        You briefly become one with nature and gain knowledge of the surrounding
        territory.
        In the outdoors, the spell gives you knowledge of the land within 3 miles of you.
        In caves and other natural underground settings, the radius is limited to 300
        feet.
        The spell doesn't function where nature has been replaced by construction, such as
        in dungeons and towns.
        You instantly gain knowledge of up to three facts of your choice about any of the
        following subjects as they relate to the area:
        - terrain and bodies of water
        - prevalent plants, minerals, animals, or peoples
        - powerful celestials, fey, fiends, elementals, or undead
        - influence from other planes of existence
        - buildings
        For example, you could determine the location of powerful undead in the area, the
        location of major sources of safe drinking water, and the location of any nearby
        towns.
         */
        public static Spell CommuneWithNature {
            get {
                return new Spell(ID.COMMUNE_WITH_NATURE, DIVINATION, FIFTH, CastingTime.ONE_MINUTE, 0, VS, INSTANTANEOUS, 0, 0, doNothing);
            }
        }

        /*
        A blast of cold air erupts from your hands.
        Each creature in a 60-foot cone must make a constitution saving throw.
        A creature takes 8d8 cold damage on a failed save, or half as much damage on a
        successful one.
        A creature killed by this spell becomes a frozen statue until it thaws.
        When you cast this spell using a spell slot of 6th level or higher, the damage
        increases by 1d8 for each slot level above 5th.
         */
        public static Spell ConeOfCold {
            get {
                return new Spell(ID.CONE_OF_COLD, EVOCATION, FIFTH, CastingTime.ONE_ACTION, 0, VSM, INSTANTANEOUS, 60, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // 8d8 base + 1d8 for each slot level above 5th
                    Dice damage = DiceSlotScaling(FIFTH, slot, D8, 8);

                    foreach (Combatant target in targets) {
                        GlobalEvents.AffectBySpell(caster, ID.CONE_OF_COLD, target, true);
                        target.TakeDamage(new DamageSource(ID.CONE_OF_COLD, caster), COLD, damage, HALVES_DAMAGE, dc, CONSTITUTION, out _);
                        // TODO: A creature killed by this spell becomes a frozen statue until it thaws.
                    }
                });
            }
        }

        /*
        You call forth an elemental servant.
        Choose an area of air, earth, fire, or water that fills a 10-foot cube within
        range.
        An elemental of challenge rating 5 or lower appropriate to the area you chose
        appears in an unoccupied space within 10 feet of it.
        For example, a fire elemental emerges from a bonfire, and an earth elemental rises
        up from the ground.
        The elemental disappears when it drops to 0 hit points or when the spell ends.
        The elemental is friendly to you and your companions for the duration.
        Roll initiative for the elemental, which has its own turns.
        It obeys any verbal commands that you issue to it (no action required by you).
        If you don't issue any commands to the elemental, it defends itself from hostile
        creatures but otherwise takes no actions.
        If your concentration is broken, the elemental doesn't disappear.
        Instead, you lose control of the elemental, it becomes hostile toward you and your
        companions, and it might attack.
        An uncontrolled elemental can't be dismissed by you, and it disappears 1 hour
        after you summoned it.
        The DM has the elemental's statistics.
        When you cast this spell using a spell slot of 6th level or higher, the challenge
        rating increases by 1 for each slot level above 5th.
         */
        public static Spell ConjureElemental {
            get {
                Spell conjure = new Spell(ID.CONJURE_ELEMENTAL, CONJURATION, FIFTH, CastingTime.ONE_MINUTE, 90, VSM, ONE_HOUR, 10, 0);
                conjure.Variants = new SpellVariant[] { AIR_ELEMENTAL, EARTH_ELEMENTAL, FIRE_ELEMENTAL, WATER_ELEMENTAL };
                conjure.Variant = AIR_ELEMENTAL;
                conjure.CastEffect = delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Monsters.ID elemental;
                    switch (conjure.Variant) {
                        case AIR_ELEMENTAL:
                            elemental = Monsters.ID.AIR_ELEMENTAL;
                            break;
                        case FIRE_ELEMENTAL:
                            elemental = Monsters.ID.FIRE_ELEMENTAL;
                            break;
                        case WATER_ELEMENTAL:
                            elemental = Monsters.ID.WATER_ELEMENTAL;
                            break;
                        case EARTH_ELEMENTAL:
                        default:
                            elemental = Monsters.ID.EARTH_ELEMENTAL;
                            break;
                    }
                    // TODO: Higher spell slots allow elementals with a higher challenge rating
                    // TODO: If concentration is broken, the elemental becomes hostile instead of disappearing
                    if (ground is Battleground2D battleground2D) {
                        Coord location = battleground2D.LocateCombatant2D(caster);
                        battleground2D.AddCombatantNextTo(Monsters.Get(elemental), location.X, location.Y, ground.GetTeam(caster));
                    } else if (ground is BattleGroundClassic battleGroundClassic) {
                        ClassicLocation location = battleGroundClassic.LocateClassicCombatant(caster);
                        battleGroundClassic.AddCombatant(Monsters.Get(elemental), location.Location, ground.GetTeam(caster));
                    }
                };
                return conjure;
            }
        }

        /*
        You mentally contact a demigod, the spirit of a long-dead sage, or some other
        mysterious entity from another plane.
        Contacting this extraplanar intelligence can strain or even break your mind.
        When you cast this spell, make a DC 15 intelligence saving throw.
        On a failure, you take 6d6 psychic damage and are insane until you finish a long
        rest.
        While insane, you can't take actions, can't understand what other creatures say,
        can't read, and speak only in gibberish.
        A greater restoration spell cast on you ends this effect.
        On a successful save, you can ask the entity up to five questions.
        You must ask your questions before the spell ends.
        The DM answers each question with one word, such as "yes," "no," "maybe," "never,"
        "irrelevant," or "unclear" (if the entity doesn't know the answer to the
        question).
        If a one-word answer would be misleading, the DM might instead offer a short
        phrase as an answer.
         */
        public static Spell ContactOtherPlane {
            get {
                return new Spell(ID.CONTACT_OTHER_PLANE, DIVINATION, FIFTH, CastingTime.ONE_MINUTE, 0, V, ONE_MINUTE, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // Contacting the extraplanar intelligence requires a DC 15 Intelligence saving throw
                    if (caster.DC(ID.CONTACT_OTHER_PLANE, 15, INTELLIGENCE)) {
                        // Asking the entity up to five questions is done via game logic, not here in the spell code
                        GlobalEvents.AffectBySpell(caster, ID.CONTACT_OTHER_PLANE, caster, true);
                        return;
                    }
                    // On a failure, the caster takes 6d6 psychic damage and is insane until finishing a long rest
                    // (or until Greater Restoration is cast on the caster)
                    GlobalEvents.AffectBySpell(caster, ID.CONTACT_OTHER_PLANE, caster, false);
                    caster.TakeDamage(new DamageSource(ID.CONTACT_OTHER_PLANE, caster), PSYCHIC, 6 * D6);
                    caster.AddEffect(SPELL_CONTACT_OTHER_PLANE_INSANITY);
                });
            }
        }

        /*
        Your touch inflicts disease.
        Make a melee spell attack against a creature within your reach.
        On a hit, you afflict the creature with a disease of your choice from any of the
        ones described below.
        At the end of each of the target's turns, it must make a constitution saving
        throw.
        After failing three of these saving throws, the disease's effects last for the
        duration, and the creature stops making these saves.
        After succeeding on three of these saving throws, the creature recovers from the
        disease, and the spell ends.
        Since this spell induces a natural disease in its target, any effect that removes
        a disease or otherwise ameliorates a disease's effects apply to it.
        ***Blinding Sickness.*** Pain grips the creature's mind, and its eyes turn milky
        white.
        The creature has disadvantage on wisdom checks and wisdom saving throws and is
        blinded.
        ***Filth Fever.*** A raging fever sweeps through the creature's body.
        The creature has disadvantage on strength checks, strength saving throws, and
        attack rolls that use Strength.
        ***Flesh Rot.*** The creature's flesh decays.
        The creature has disadvantage on Charisma checks and vulnerability to all damage.
        ***Mindfire.*** The creature's mind becomes feverish.
        The creature has disadvantage on intelligence checks and intelligence saving
        throws, and the creature behaves as if under the effects of the confusion spell
        during combat.
        ***Seizure.*** The creature is overcome with shaking.
        The creature has disadvantage on dexterity checks, dexterity saving throws, and
        attack rolls that use Dexterity.
        ***Slimy Doom.*** The creature begins to bleed uncontrollably.
        The creature has disadvantage on constitution checks and constitution saving
        throws.
        In addition, whenever the creature takes damage, it is stunned until the end of
        its next turn.
         */
        public static Spell Contagion {
            get {
                Spell spell = new Spell(ID.CONTAGION, NECROMANCY, FIFTH, CastingTime.ONE_ACTION, 0, VS, SEVEN_DAYS, 0, 1);
                spell.Variants = new SpellVariant[] { BLINDING_SICKNESS, FILTH_FEVER, FLESH_ROT, MINDFIRE, SEIZURE, SLIMY_DOOM };
                spell.Variant = BLINDING_SICKNESS;
                spell.CastEffect = delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    // The disease effects are in the same order as the variants
                    Effect[] diseases = {
                        SPELL_CONTAGION_BLINDING_SICKNESS_DISEASE, SPELL_CONTAGION_FILTH_FEVER_DISEASE, SPELL_CONTAGION_FLESH_ROT_DISEASE,
                        SPELL_CONTAGION_MINDFIRE_DISEASE, SPELL_CONTAGION_SEIZURE_DISEASE, SPELL_CONTAGION_SLIMY_DOOM_DISEASE
                    };
                    Effect disease = diseases[Array.IndexOf(spell.Variants, spell.Variant)];

                    // Melee spell attack that deals no damage, but afflicts the target with the disease on a hit
                    bool hit = SpellAttack(ID.CONTAGION, ground, caster, NECROTIC, null, modifier, target, 5);
                    GlobalEvents.AffectBySpell(caster, ID.CONTAGION, target, hit);
                    if (!hit) return;
                    target.AddEffect(disease);

                    // Slimy Doom: whenever the creature takes damage, it is stunned until the end of its next turn
                    if (disease == SPELL_CONTAGION_SLIMY_DOOM_DISEASE) {
                        target.AddDamageTakenEvent(delegate (DamageSource source, Damage damage) {
                            if (!target.HasEffect(SPELL_CONTAGION_SLIMY_DOOM_DISEASE)) return true;
                            target.AddCondition(ConditionType.STUNNED);
                            target.AddEndOfTurnEvent(delegate () {
                                target.RemoveCondition(ConditionType.STUNNED);
                                return true;
                            });
                            return false;
                        });
                    }

                    // Constitution save at the end of each of the target's turns:
                    // three successes cure the disease, after three failures it lasts for the whole duration
                    int successes = 0, failures = 0;
                    int remainingRounds = (int)SEVEN_DAYS;
                    target.AddEndOfTurnEvent(delegate () {
                        if (!target.HasEffect(disease)) return true;
                        if (failures < 3) {
                            if (!target.DC(ID.CONTAGION, dc, CONSTITUTION)) {
                                failures++;
                            } else if (++successes >= 3) {
                                target.RemoveEffect(disease);
                                return true;
                            }
                        }
                        if (--remainingRounds < 1) {
                            target.RemoveEffect(disease);
                            return true;
                        }
                        return false;
                    });
                };
                return spell;
            }
        }

        /* TODO:
        You pull wisps of shadow material from the Shadowfell to create a nonliving object
        of vegetable matter within range: soft goods, rope, wood, or something similar.
        You can also use this spell to create mineral objects such as stone, crystal, or
        metal.
        The object created must be no larger than a 5-foot cube, and the object must be of
        a form and material that you have seen before.
        The duration depends on the object's material.
        If the object is composed of multiple materials, use the shortest duration.
        Using any material created by this spell as another spell's material component
        causes that spell to fail.
        When you cast this spell using a spell slot of 6th level or higher, the cube
        increases by 5 feet for each slot level above 5th.
         */
        public static Spell Creation {
            get {
                return new Spell(ID.CREATION, ILLUSION, FIFTH, CastingTime.ONE_MINUTE, 30, VSM, SPECIAL, 5, 0, doNothing);
            }
        }

        /*
        Shimmering energy surrounds and protects you from fey, undead, and creatures
        originating from beyond the Material Plane.
        For the duration, celestials, elementals, fey, fiends, and undead have
        disadvantage on attack rolls against you.
        You can end the spell early by using either of the following special functions.
        ***Break Enchantment.*** As your action, you touch a creature you can reach that
        is charmed, frightened, or possessed by a celestial, an elemental, a fey, a fiend,
        or an undead.
        The creature you touch is no longer charmed, frightened, or possessed by such
        creatures.
        ***Dismissal.*** As your action, make a melee spell attack against a celestial, an
        elemental, a fey, a fiend, or an undead you can reach.
        On a hit, you attempt to drive the creature back to its home plane.
        The creature must succeed on a charisma saving throw or be sent back to its home
        plane (if it isn't there already).
        If they aren't on their home plane, undead are sent to the Shadowfell, and fey are
        sent to the Feywild.
         */
        public static Spell DispelEvilandGood {
            get {
                return new Spell(ID.DISPEL_EVIL_AND_GOOD, ABJURATION, FIFTH, CastingTime.ONE_ACTION, 0, VSM, ONE_MINUTE, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // Celestials, elementals, fey, fiends and undead have disadvantage on attack rolls against the caster (see Combatant.Attack)
                    // TODO: The special functions Break Enchantment and Dismissal, which end the spell early
                    AddEffectsForDuration(ID.DISPEL_EVIL_AND_GOOD, caster, caster, ONE_MINUTE, SPELL_DISPEL_EVIL_AND_GOOD);
                });
            }
        }

        /*
        You attempt to beguile a humanoid that you can see within range.
        It must succeed on a wisdom saving throw or be charmed by you for the duration.
        If you or creatures that are friendly to you are fighting it, it has advantage on
        the saving throw.
        While the target is charmed, you have a telepathic link with it as long as the two
        of you are on the same plane of existence.
        You can use this telepathic link to issue commands to the creature while you are
        conscious (no action required), which it does its best to obey.
        You can specify a simple and general course of action, such as "Attack that
        creature," "Run over there," or "Fetch that object." If the creature completes the
        order and doesn't receive further direction from you, it defends and preserves
        itself to the best of its ability.
        You can use your action to take total and precise control of the target.
        Until the end of your next turn, the creature takes only the actions you choose,
        and doesn't do anything that you don't allow it to do.
        During this time you can also cause the creature to use a reaction, but this
        requires you to use your own reaction as well.
        Each time the target takes damage, it makes a new wisdom saving throw against the
        spell.
        If the saving throw succeeds, the spell ends.
        When you cast this spell using a 6th-level spell slot, the duration is
        concentration, up to 10 minutes.
        When you use a 7th-level spell slot, the duration is concentration, up to 1 hour.
        When you use a spell slot of 8th level or higher, the duration is concentration,
        up to 8 hours.
         */
        public static Spell DominatePerson {
            get {
                return new Spell(ID.DOMINATE_PERSON, ENCHANTMENT, FIFTH, CastingTime.ONE_ACTION, 60, VS, ONE_MINUTE, 0, 2, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    // the second target designates who the charmed humanoid is commanded to attack; without one it attacks no one
                    Combatant attackTarget = targets.Length > 1 ? targets[1] : null;

                    // only humanoids can be dominated by this spell
                    if (target is Monster monster && monster.Type != Monsters.Type.HUMANOID) {
                        GlobalEvents.AffectBySpell(caster, ID.DOMINATE_PERSON, target, false);
                        return;
                    }

                    // Wisdom save with advantage since we assume a fight
                    if (target.HasEffect(IMMUNITY_CHARMED) || target.DC(ID.DOMINATE_PERSON, dc, WISDOM, true)) {
                        GlobalEvents.AffectBySpell(caster, ID.DOMINATE_PERSON, target, false);
                        return;
                    }

                    GlobalEvents.AffectBySpell(caster, ID.DOMINATE_PERSON, target, true);
                    target.AddCondition(ConditionType.CHARMED);
                    target.AddEffect(SPELL_DOMINATE_PERSON);
                    Team originalTeam = ground.GetTeam(target);
                    ground.SetTeam(target, ground.GetTeam(caster));

                    bool spellEnded = false;
                    void endSpell() {
                        spellEnded = true;
                        target.RemoveCondition(ConditionType.CHARMED);
                        target.RemoveEffect(SPELL_DOMINATE_PERSON);
                        ground.SetTeam(target, originalTeam);
                    }
                    // Each time the target takes damage, it makes a new Wisdom saving throw against the spell
                    target.AddDamageTakenEvent(delegate (DamageSource source, Damage damage) {
                        if (spellEnded) return true;
                        if (!target.DC(ID.DOMINATE_PERSON, dc, WISDOM)) return false;
                        endSpell();
                        return true;
                    });

                    // commanded to attack the designated target on its turn; without one it does not attack anyone
                    target.AddStartOfTurnEvent(delegate () {
                        if (spellEnded || !target.HasEffect(SPELL_DOMINATE_PERSON)) return true;
                        if (attackTarget == null || attackTarget.HitPoints <= 0) return false;
                        // Move towards the attack target if not in reach

                        // Attack the target if in reach
                        return false;
                    });

                    // Higher spell slots increase the duration: 6th = 10 minutes, 7th = 1 hour, 8th or higher = 8 hours
                    SpellDuration duration = ONE_MINUTE;
                    if (slot >= EIGHTH) duration = EIGHT_HOURS;
                    else if (slot == SEVENTH) duration = ONE_HOUR;
                    else if (slot == SIXTH) duration = TEN_MINUTES;
                    int remainingRounds = (int)duration;
                    caster.AddEndOfTurnEvent(delegate () {
                        if (spellEnded) return true;
                        // The spell also ends when its effect was removed otherwise (e.g. by Greater Restoration)
                        if (--remainingRounds < 1 || !target.HasEffect(SPELL_DOMINATE_PERSON)) {
                            endSpell();
                            return true;
                        }
                        return false;
                    });
                });
            }
        }

        /* TODO:
        This spell shapes a creature's dreams.
        Choose a creature known to you as the target of this spell.
        The target must be on the same plane of existence as you.
        Creatures that don't sleep, such as elves, can't be contacted by this spell.
        You, or a willing creature you touch, enters a trance state, acting as a
        messenger.
        While in the trance, the messenger is aware of his or her surroundings, but can't
        take actions or move.
        If the target is asleep, the messenger appears in the target's dreams and can
        converse with the target as long as it remains asleep, through the duration of the
        spell.
        The messenger can also shape the environment of the dream, creating landscapes,
        objects, and other images.
        The messenger can emerge from the trance at any time, ending the effect of the
        spell early.
        The target recalls the dream perfectly upon waking.
        If the target is awake when you cast the spell, the messenger knows it, and can
        either end the trance (and the spell) or wait for the target to fall asleep, at
        which point the messenger appears in the target's dreams.
        You can make the messenger appear monstrous and terrifying to the target.
        If you do, the messenger can deliver a message of no more than ten words and then
        the target must make a wisdom saving throw.
        On a failed save, echoes of the phantasmal monstrosity spawn a nightmare that
        lasts the duration of the target's sleep and prevents the target from gaining any
        benefit from that rest.
        In addition, when the target wakes up, it takes 3d6 psychic damage.
        If you have a body part, lock of hair, clipping from a nail, or similar portion of
        the target's body, the target makes its saving throw with disadvantage.
         */
        public static Spell Dream {
            get {
                return new Spell(ID.DREAM, ILLUSION, FIFTH, CastingTime.ONE_MINUTE, -1, VSM, EIGHT_HOURS, 0, 0, doNothing);
            }
        }

        /*
        A vertical column of divine fire roars down from the heavens in a location you
        specify.
        Each creature in a 10-foot-radius, 40-foot-high cylinder centered on a point
        within range must make a dexterity saving throw.
        A creature takes 4d6 fire damage and 4d6 radiant damage on a failed save, or half
        as much damage on a successful one.
        When you cast this spell using a spell slot of 6th level or higher, the fire
        damage or the radiant damage (your choice) increases by 1d6 for each slot level
        above 5th.
         */
        public static Spell FlameStrike {
            get {
                Spell spell = new Spell(ID.FLAME_STRIKE, EVOCATION, FIFTH, CastingTime.ONE_ACTION, 60, VSM, INSTANTANEOUS, 10, 0);
                // The variant determines which damage type (fire or radiant) scales with higher spell slots
                spell.Variants = new SpellVariant[] { DAMAGE_FIRE, DAMAGE_RADIANT };
                spell.Variant = DAMAGE_FIRE;
                spell.CastEffect = delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // 4d6 fire and 4d6 radiant base, the chosen damage type gains 1d6 for each slot level above 5th
                    Dice scaledDamage = DiceSlotScaling(FIFTH, slot, D6, 4);
                    Dice baseDamage = 4 * D6;
                    bool scaleRadiant = spell.Variant == DAMAGE_RADIANT;
                    Dice fireDamage = scaleRadiant ? baseDamage : scaledDamage;
                    Dice radiantDamage = scaleRadiant ? scaledDamage : baseDamage;

                    foreach (Combatant target in targets) {
                        GlobalEvents.AffectBySpell(caster, ID.FLAME_STRIKE, target, true);
                        // Single DEX save halves both damage components together
                        bool saved = target.DC(ID.FLAME_STRIKE, dc, DEXTERITY);
                        int fire = fireDamage.Roll();
                        int radiant = radiantDamage.Roll();
                        if (saved) {
                            fire /= 2;
                            radiant /= 2;
                        }
                        target.TakeDamage(new DamageSource(ID.FLAME_STRIKE, caster), FIRE, fire);
                        target.TakeDamage(new DamageSource(ID.FLAME_STRIKE, caster), RADIANT, radiant);
                    }
                };
                return spell;
            }
        }

        /* TODO:
        You place a magical command on a creature that you can see within range, forcing
        it to carry out some service or refrain from some action or course of activity as
        you decide.
        If the creature can understand you, it must succeed on a wisdom saving throw or
        become charmed by you for the duration.
        While the creature is charmed by you, it takes 5d10 psychic damage each time it
        acts in a manner directly counter to your instructions, but no more than once each
        day.
        A creature that can't understand you is unaffected by the spell.
        You can issue any command you choose, short of an activity that would result in
        certain death.
        Should you issue a suicidal command, the spell ends.
        You can end the spell early by using an action to dismiss it.
        A remove curse, greater restoration, or wish spell also ends it.
        When you cast this spell using a spell slot of 7th or 8th level, the duration is 1
        year.
        When you cast this spell using a spell slot of 9th level, the spell lasts until it
        is ended by one of the spells mentioned above.
         */
        public static Spell Geas {
            get {
                return new Spell(ID.GEAS, ENCHANTMENT, FIFTH, CastingTime.ONE_MINUTE, 60, V, THIRTY_DAYS, 0, 0, doNothing);
            }
        }

        /*
        You imbue a creature you touch with positive energy to undo a debilitating effect.
        You can reduce the target's exhaustion level by one, or end one of the following
        effects on the target:
        - One effect that charmed or petrified the target
        - One curse, including the target's attunement to a cursed magic item
        - Any reduction to one of the target's ability scores
        - One effect reducing the target's hit point maximum
         */
        public static Spell GreaterRestoration {
            get {
                Spell spell = new Spell(ID.GREATER_RESTORATION, ABJURATION, FIFTH, CastingTime.ONE_ACTION, 0, VSM, INSTANTANEOUS, 0, 1);
                spell.Variants = new SpellVariant[] { EXHAUSTION, CHARM, PETRIFICATION, CURSE, ABILITY_SCORE_REDUCTION, HIT_POINT_MAXIMUM_REDUCTION };
                spell.Variant = EXHAUSTION;
                spell.CastEffect = delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    GlobalEvents.AffectBySpell(caster, ID.GREATER_RESTORATION, target, true);
                    switch (spell.Variant) {
                        case EXHAUSTION:
                            for (ConditionType level = ConditionType.EXHAUSTED_6; level >= ConditionType.EXHAUSTED_1; level--) {
                                if (!target.HasCondition(level)) continue;
                                target.RemoveCondition(level);
                                if (level > ConditionType.EXHAUSTED_1) target.AddCondition(level - 1);
                                return;
                            }
                            break;
                        case CHARM:
                            Effect[] charmingEffects = { SPELL_ANIMAL_FRIENDSHIP, SPELL_AWAKEN, SPELL_DOMINATE_BEAST, SPELL_DOMINATE_PERSON, SPELL_MODIFY_MEMORY };
                            target.RemoveCondition(ConditionType.CHARMED);
                            foreach (Effect effect in charmingEffects) {
                                if (target.HasEffect(effect)) {
                                    target.RemoveEffect(effect);
                                    return;
                                }
                            }
                            break;
                        case PETRIFICATION:
                            target.RemoveCondition(ConditionType.PETRIFIED);
                            break;
                        case CURSE:
                            foreach (Effect effect in (Effect[])target.Effects.Clone()) {
                                if (effect.IsCurse()) {
                                    target.RemoveEffect(effect);
                                    return;
                                }
                            }
                            break;
                        case ABILITY_SCORE_REDUCTION:
                            Ability mostReduced = null;
                            foreach (AbilityType type in new AbilityType[] { STRENGTH, DEXTERITY, CONSTITUTION, INTELLIGENCE, WISDOM, CHARISMA }) {
                                Ability ability = target.GetAbility(type);
                                if (ability.ValueModifier < 0 && (mostReduced == null || ability.ValueModifier < mostReduced.ValueModifier)) {
                                    mostReduced = ability;
                                }
                            }
                            if (mostReduced != null) mostReduced.ValueModifier = 0;
                            break;
                        case HIT_POINT_MAXIMUM_REDUCTION:
                            foreach (HitPointMaxiumModifier hitPointModifier in target.HitPointMaxiumModifiers) {
                                if (hitPointModifier.Amount < 0) {
                                    target.RemoveHitPointsMaximumModifiers(hitPointModifier);
                                    return;
                                }
                            }
                            break;
                    }
                };
                return spell;
            }
        }

        /* TODO:
        You touch a point and infuse an area around it with holy (or unholy) power.
        The area can have a radius up to 60 feet, and the spell fails if the radius
        includes an area already under the effect a hallow spell.
        The affected area is subject to the following effects.
        First, celestials, elementals, fey, fiends, and undead can't enter the area, nor
        can such creatures charm, frighten, or possess creatures within it.
        Any creature charmed, frightened, or possessed by such a creature is no longer
        charmed, frightened, or possessed upon entering the area.
        You can exclude one or more of those types of creatures from this effect.
        Second, you can bind an extra effect to the area.
        Choose the effect from the following list, or choose an effect offered by the DM.
        Some of these effects apply to creatures in the area; you can designate whether
        the effect applies to all creatures, creatures that follow a specific deity or
        leader, or creatures of a specific sort, such as ores or trolls.
        When a creature that would be affected enters the spell's area for the first time
        on a turn or starts its turn there, it can make a charisma saving throw.
        On a success, the creature ignores the extra effect until it leaves the area.
        ***Courage.*** Affected creatures can't be frightened while in the area.
        ***Darkness.*** Darkness fills the area.
        Normal light, as well as magical light created by spells of a lower level than the
        slot you used to cast this spell, can't illuminate the area.
        ***Daylight.*** Bright light fills the area.
        Magical darkness created by spells of a lower level than the slot you used to cast
        this spell can't extinguish the light.
        ***Energy Protection.*** Affected creatures in the area have resistance to one
        damage type of your choice, except for bludgeoning, piercing, or slashing.
        ***Energy Vulnerability.*** Affected creatures in the area have vulnerability to
        one damage type of your choice, except for bludgeoning, piercing, or slashing.
        ***Everlasting Rest.*** Dead bodies interred in the area can't be turned into
        undead.
        ***Extradimensional Interference.*** Affected creatures can't move or travel using
        teleportation or by extradimensional or interplanar means.
        ***Fear.*** Affected creatures are frightened while in the area.
        ***Silence.*** No sound can emanate from within the area, and no sound can reach
        into it.
        ***Tongues.*** Affected creatures can communicate with any other creature in the
        area, even if they don't share a common language.
         */
        public static Spell Hallow {
            get {
                return new Spell(ID.HALLOW, EVOCATION, FIFTH, CastingTime.ONE_DAY, 0, VSM, UNTIL_DISPELLED, 60, 0, doNothing);
            }
        }

        /*
        Choose a creature that you can see within range.
        The target must succeed on a wisdom saving throw or be paralyzed for the duration.
        This spell has no effect on undead.
        At the end of each of its turns, the target can make another wisdom saving throw.
        On a success, the spell ends on the target.
        When you cast this spell using a spell slot of 6th level or higher, you can target
        one additional creature for each slot level above 5th.
        The creatures must be within 30 feet of each other when you target them.
         */
        public static Spell HoldMonster {
            get {
                return new Spell(ID.HOLD_MONSTER, ENCHANTMENT, FIFTH, CastingTime.ONE_ACTION, 90, VSM, ONE_MINUTE, 0, 5, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // one additional target per slot above 5th
                    for (int i = 0; i < (int)slot - 4 && i < targets.Length; i++) {
                        Combatant target = targets[i];
                        if (target is Monster monster && monster.Type == Monsters.Type.UNDEAD || target.HasEffect(IMMUNITY_PARALYZED)) {
                            GlobalEvents.AffectBySpell(caster, ID.HOLD_MONSTER, target, false);
                            continue;
                        }
                        if (!target.DC(ID.HOLD_MONSTER, dc, WISDOM) && target.AddCondition(ConditionType.PARALYZED)) {
                            GlobalEvents.AffectBySpell(caster, ID.HOLD_MONSTER, target, true);
                            int remainingRounds = (int)ONE_MINUTE;
                            target.AddEndOfTurnEvent(delegate () {
                                bool ended = --remainingRounds < 1 || target.DC(ID.HOLD_MONSTER, dc, WISDOM);
                                if (ended) {
                                    target.RemoveCondition(ConditionType.PARALYZED);
                                }
                                return ended;
                            });
                        } else {
                            GlobalEvents.AffectBySpell(caster, ID.HOLD_MONSTER, target, false);
                        }
                    }
                });
            }
        }

        /*
        Swarming, biting locusts fill a 20-foot-radius sphere centered on a point you
        choose within range.
        The sphere spreads around corners.
        The sphere remains for the duration, and its area is lightly obscured.
        The sphere's area is difficult terrain.
        When the area appears, each creature in it must make a constitution saving throw.
        A creature takes 4d10 piercing damage on a failed save, or half as much damage on
        a successful one.
        A creature must also make this saving throw when it enters the spell's area for
        the first time on a turn or ends its turn there.
        When you cast this spell using a spell slot of 6th level or higher, the damage
        increases by 1d10 for each slot level above 5th.
         */
        public static Spell InsectPlague {
            get {
                return new Spell(ID.INSECT_PLAGUE, CONJURATION, FIFTH, CastingTime.ONE_ACTION, 300, VSM, TEN_MINUTES, 20, 20, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // 4d10 piercing base + 1d10 for each slot level above 5th
                    Dice damage = DiceSlotScaling(FIFTH, slot, D10, 4);
                    GlobalEvents.AffectBySpell(caster, ID.INSECT_PLAGUE, caster, true);

                    foreach (Combatant target in targets) {
                        // Mark this creature as being in the swarm
                        GlobalEvents.AffectBySpell(caster, ID.INSECT_PLAGUE, target, true);
                        target.AddEffect(SPELL_INSECT_PLAGUE);

                        // Creature is in the area when the swarm appears: CON save for half
                        target.TakeDamage(new DamageSource(ID.INSECT_PLAGUE, caster), PIERCING, damage, HALVES_DAMAGE, dc, CONSTITUTION, out _);

                        // At the end of each turn inside the swarm, the creature must save again
                        target.AddEndOfTurnEvent(delegate () {
                            if (!target.HasEffect(SPELL_INSECT_PLAGUE)) return true;
                            target.TakeDamage(new DamageSource(ID.INSECT_PLAGUE, caster), PIERCING, damage, HALVES_DAMAGE, dc, CONSTITUTION, out _);
                            return false;
                        });

                        // TODO: Remove effect when target moves outside the swarm
                        // TODO: The area is lightly obscured and difficult terrain
                    }

                    // Duration: swarm lingers for 10 minutes
                    int remainingRounds = (int)TEN_MINUTES;
                    caster.AddEndOfTurnEvent(delegate () {
                        if (--remainingRounds < 1) {
                            foreach (Combatant target in targets) {
                                target.RemoveEffect(SPELL_INSECT_PLAGUE);
                            }
                            return true;
                        }
                        return false;
                    });
                });
            }
        }

        /* TODO:
        Name or describe a person, place, or object.
        The spell brings to your mind a brief summary of the significant lore about the
        thing you named.
        The lore might consist of current tales, forgotten stories, or even secret lore
        that has never been widely known.
        If the thing you named isn't of legendary importance, you gain no information.
        The more information you already have about the thing, the more precise and
        detailed the information you receive is.
        The information you learn is accurate but might be couched in figurative language.
        For example, if you have a mysterious magic axe on hand the spell might yield this
        information: "Woe to the evildoer whose hand touches the axe, for even the haft
        slices the hand of the evil ones.
        Only a true Child of Stone, lover and beloved of Moradin, may awaken the true
        powers of the axe, and only with the sacred word *Rudnogg* on the lips."
         */
        public static Spell LegendLore {
            get {
                return new Spell(ID.LEGEND_LORE, DIVINATION, FIFTH, CastingTime.TEN_MINUTES, 0, VSM, INSTANTANEOUS, 0, 0, doNothing);
            }
        }

        /*
        A wave of healing energy washes out from a point of your choice within range.
        Choose up to six creatures in a 30-foot-radius sphere centered on that point.
        Each target regains hit points equal to 3d8 + your spellcasting ability modifier.
        This spell has no effect on undead or constructs.
        When you cast this spell using a spell slot of 6th level or higher, the healing
        increases by 1d8 for each slot level above 5th.
         */
        public static Spell MassCureWounds {
            get {
                return new Spell(ID.MASS_CURE_WOUNDS, CONJURATION, FIFTH, CastingTime.ONE_ACTION, 60, VS, INSTANTANEOUS, 30, 6, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // up to six creatures, 3d8 + modifier, +1d8 for each slot level above 5th
                    for (int i = 0; i < 6 && i < targets.Length; i++) {
                        Combatant target = targets[i];
                        if (target is Monster monster) {
                            if (monster.Type == Monsters.Type.CONSTRUCT || monster.Type == Monsters.Type.UNDEAD) {
                                GlobalEvents.AffectBySpell(caster, ID.MASS_CURE_WOUNDS, target, false);
                                continue;
                            }
                        }
                        Dice dice = DiceSlotScaling(FIFTH, slot, D8, 3, modifier);
                        GlobalEvents.AffectBySpell(caster, ID.MASS_CURE_WOUNDS, target, true);
                        target.HealDamage(dice);
                    }
                });
            }
        }

        /*
        You become invisible at the same time that an illusory double of you appears where
        you are standing.
        The double lasts for the duration, but the invisibility ends if you attack or cast
        a spell.
        You can use your action to move your illusory double up to twice your speed and
        make it gesture, speak, and behave in whatever way you choose.
        You can see through its eyes and hear through its ears as if you were located
        where it is.
        On each of your turns as a bonus action, you can switch from using its senses to
        using your own, or back again.
        While you are using its senses, you are blinded and deafened in regard to your own
        surroundings.
         */
        public static Spell Mislead {
            get {
                return new Spell(ID.MISLEAD, ILLUSION, FIFTH, CastingTime.ONE_ACTION, 0, S, ONE_HOUR, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // TODO: The illusory double, which can be moved and whose senses can be used, is not simulated
                    AddEffectsForDuration(ID.MISLEAD, caster, caster, ONE_HOUR, SPELL_MISLEAD);
                    // The invisibility ends if the caster attacks or casts a spell
                    EventHandler<GlobalEvents.AttackRolled> attackHandler = delegate (object sender, GlobalEvents.AttackRolled attack) {
                        if (attack.Attacker.Equals(caster)) caster.RemoveEffect(SPELL_MISLEAD);
                    };
                    EventHandler<GlobalEvents.SpellCast> castHandler = delegate (object sender, GlobalEvents.SpellCast cast) {
                        if (cast.Caster.Equals(caster)) caster.RemoveEffect(SPELL_MISLEAD);
                    };
                    GlobalEvents.AttackRolledHandlers += attackHandler;
                    GlobalEvents.SpellCastHandlers += castHandler;
                    caster.AddEndOfTurnEvent(delegate () {
                        if (caster.HasEffect(SPELL_MISLEAD)) return false;
                        GlobalEvents.AttackRolledHandlers -= attackHandler;
                        GlobalEvents.SpellCastHandlers -= castHandler;
                        return true;
                    });
                });
            }
        }

        /*
        You attempt to reshape another creature's memories.
        One creature that you can see must make a wisdom saving throw.
        If you are fighting the creature, it has advantage on the saving throw.
        On a failed save, the target becomes charmed by you for the duration.
        The charmed target is incapacitated and unaware of its surroundings, though it can
        still hear you.
        If it takes any damage or is targeted by another spell, this spell ends, and none
        of the target's memories are modified.
        While this charm lasts, you can affect the target's memory of an event that it
        experienced within the last 24 hours and that lasted no more than 10 minutes.
        You can permanently eliminate all memory of the event, allow the target to recall
        the event with perfect clarity and exacting detail, change its memory of the
        details of the event, or create a memory of some other event.
        You must speak to the target to describe how its memories are affected, and it
        must be able to understand your language for the modified memories to take root.
        Its mind fills in any gaps in the details of your description.
        If the spell ends before you have finished describing the modified memories, the
        creature's memory isn't altered.
        Otherwise, the modified memories take hold when the spell ends.
        A modified memory doesn't necessarily affect how a creature behaves, particularly
        if the memory contradicts the creature's natural inclinations, alignment, or
        beliefs.
        An illogical modified memory, such as implanting a memory of how much the creature
        enjoyed dousing itself in acid, is dismissed, perhaps as a bad dream.
        The DM might deem a modified memory too nonsensical to affect a creature in a
        significant manner.
        A remove curse or greater restoration spell cast on the target restores the
        creature's true memory.
        If you cast this spell using a spell slot of 6th level or higher, you can alter
        the target's memories of an event that took place up to 7 days ago (6th level), 30
        days ago (7th level), 1 year ago (8th level), or any time in the creature's past
        (9th level).
         */
        public static Spell ModifyMemory {
            get {
                return new Spell(ID.MODIFY_MEMORY, ENCHANTMENT, FIFTH, CastingTime.ONE_ACTION, 30, VS, ONE_MINUTE, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    // Wisdom save with advantage since we assume a fight
                    if (target.HasEffect(IMMUNITY_CHARMED) || target.DC(ID.MODIFY_MEMORY, dc, WISDOM, true)) {
                        GlobalEvents.AffectBySpell(caster, ID.MODIFY_MEMORY, target, false);
                        return;
                    }
                    // The target is charmed, incapacitated and unaware of its surroundings
                    // TODO: Modifying the target's memories is narrative and not simulated
                    GlobalEvents.AffectBySpell(caster, ID.MODIFY_MEMORY, target, true);
                    target.AddEffect(SPELL_MODIFY_MEMORY);

                    // The spell ends if the target takes any damage or is targeted by another spell
                    target.AddDamageTakenEvent(delegate (DamageSource source, Damage damage) {
                        target.RemoveEffect(SPELL_MODIFY_MEMORY);
                        return true;
                    });
                    EventHandler<GlobalEvents.SpellAffection> spellHandler = delegate (object sender, GlobalEvents.SpellAffection affection) {
                        if (affection.Target.Equals(target) && affection.Spell != ID.MODIFY_MEMORY) target.RemoveEffect(SPELL_MODIFY_MEMORY);
                    };
                    GlobalEvents.SpellAffectionHandlers += spellHandler;

                    int remainingRounds = (int)ONE_MINUTE;
                    caster.AddEndOfTurnEvent(delegate () {
                        if (--remainingRounds < 1) target.RemoveEffect(SPELL_MODIFY_MEMORY);
                        if (target.HasEffect(SPELL_MODIFY_MEMORY)) return false;
                        GlobalEvents.SpellAffectionHandlers -= spellHandler;
                        return true;
                    });
                });
            }
        }

        /* TODO:
        A passage appears at a point of your choice that you can see on a wooden, plaster,
        or stone surface (such as a wall, a ceiling, or a floor) within range, and lasts
        for the duration.
        You choose the opening's dimensions: up to 5 feet wide, 8 feet tall, and 20 feet
        deep.
        The passage creates no instability in a structure surrounding it.
        When the opening disappears, any creatures or objects still in the passage created
        by the spell are safely ejected to an unoccupied space nearest to the surface on
        which you cast the spell.
         */
        public static Spell Passwall {
            get {
                return new Spell(ID.PASSWALL, TRANSMUTATION, FIFTH, CastingTime.ONE_ACTION, 30, VSM, ONE_HOUR, 0, 0, doNothing);
            }
        }

        /*
        With this spell, you attempt to bind a celestial, an elemental, a fey, or a fiend
        to your service.
        The creature must be within range for the entire casting of the spell. (Typically,
        the creature is first summoned into the center of an inverted magic circle in
        order to keep it trapped while this spell is cast.) At the completion of the
        casting, the target must make a charisma saving throw.
        On a failed save, it is bound to serve you for the duration.
        If the creature was summoned or created by another spell, that spell's duration is
        extended to match the duration of this spell.
        A bound creature must follow your instructions to the best of its ability.
        You might command the creature to accompany you on an adventure, to guard a
        location, or to deliver a message.
        The creature obeys the letter of your instructions, but if the creature is hostile
        to you, it strives to twist your words to achieve its own objectives.
        If the creature carries out your instructions completely before the spell ends, it
        travels to you to report this fact if you are on the same plane of existence.
        If you are on a different plane of existence, it returns to the place where you
        bound it and remains there until the spell ends.
        When you cast this spell using a spell slot of a higher level, the duration
        increases to 10 days with a 6th-level slot, to 30 days with a 7th-level slot, to
        180 days with an 8th-level slot, and to a year and a day with a 9th-level spell
        slot.
         */
        public static Spell PlanarBinding {
            get {
                return new Spell(ID.PLANAR_BINDING, ABJURATION, FIFTH, CastingTime.ONE_HOUR, 60, VSM, ONE_DAY, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    // Only celestials, elementals, fey and fiends can be bound
                    bool bindable = target is Monster monster && (monster.Type == Monsters.Type.CELESTIAL || monster.Type == Monsters.Type.ELEMENTAL
                                                                || monster.Type == Monsters.Type.FEY || monster.Type == Monsters.Type.FIEND);
                    if (!bindable || target.DC(ID.PLANAR_BINDING, dc, CHARISMA)) {
                        GlobalEvents.AffectBySpell(caster, ID.PLANAR_BINDING, target, false);
                        return;
                    }
                    // The bound creature serves the caster for the duration
                    // TODO: If the creature was summoned by another spell, that spell's duration is extended to match
                    GlobalEvents.AffectBySpell(caster, ID.PLANAR_BINDING, target, true);
                    target.AddEffect(SPELL_PLANAR_BINDING);
                    Team originalTeam = ground.GetTeam(target);
                    ground.SetTeam(target, ground.GetTeam(caster));

                    // Duration in days: 24 hours at 5th level, 10 days at 6th, 30 days at 7th, 180 days at 8th and a year and a day at 9th
                    int[] days = { 1, 10, 30, 180, 366 };
                    int remainingRounds = days[slot - FIFTH] * (int)ONE_DAY;
                    caster.AddEndOfTurnEvent(delegate () {
                        if (--remainingRounds < 1) target.RemoveEffect(SPELL_PLANAR_BINDING);
                        if (target.HasEffect(SPELL_PLANAR_BINDING)) return false;
                        ground.SetTeam(target, originalTeam);
                        return true;
                    });
                });
            }
        }

        /*
        You return a dead creature you touch to life, provided that it has been dead no
        longer than 10 days.
        If the creature's soul is both willing and at liberty to rejoin the body, the
        creature returns to life with 1 hit point.
        This spell also neutralizes any poisons and cures nonmagical diseases that
        affected the creature at the time it died.
        This spell doesn't, however, remove magical diseases, curses, or similar effects;
        if these aren't first removed prior to casting the spell, they take effect when
        the creature returns to life.
        The spell can't return an undead creature to life.
        This spell closes all mortal wounds, but it doesn't restore missing body parts.
        If the creature is lacking body parts or organs integral for its survival--its
        head, for instance--the spell automatically fails.
        Coming back from the dead is an ordeal.
        The target takes a -4 penalty to all attack rolls, saving throws, and ability
        checks.
        Every time the target finishes a long rest, the penalty is reduced by 1 until it
        disappears.
         */
        public static Spell RaiseDead {
            get {
                return new Spell(ID.RAISE_DEAD, NECROMANCY, FIFTH, CastingTime.ONE_HOUR, 0, VSM, INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    // Only dead creatures can be targeted, and the spell can't return an undead creature to life
                    if (!target.Dead || (target is Monster monster && monster.Type == Monsters.Type.UNDEAD)) {
                        GlobalEvents.AffectBySpell(caster, ID.RAISE_DEAD, target, false);
                        return;
                    }
                    // Return the target to life with 1 hit point
                    GlobalEvents.AffectBySpell(caster, ID.RAISE_DEAD, target, true);
                    target.Dead = false;
                    target.HitPoints = 1;
                    // We don't neutralize any poisons or diseases or curses because in this context, everything is magical, so there is nothing to be neutralized.

                    // TODO: Missing body parts are not restored
                    // TODO: -4 penalty to attack rolls, saving throws and ability checks, reduced by 1 after each long rest
                });
            }
        }

        /* TODO:
        You touch a dead humanoid or a piece of a dead humanoid.
        Provided that the creature has been dead no longer than 10 days, the spell forms a
        new adult body for it and then calls the soul to enter that body.
        If the target's soul isn't free or willing to do so, the spell fails.
        The magic fashions a new body for the creature to inhabit, which likely causes the
        creature's race to change.
        The DM rolls a d100 and consults the following table to determine what form the
        creature takes when restored to life, or the DM chooses a form.
        The reincarnated creature recalls its former life and experiences.
        It retains the capabilities it had in its original form, except it exchanges its
        original race for the new one and changes its racial traits accordingly.
         */
        public static Spell Reincarnate {
            get {
                return new Spell(ID.REINCARNATE, TRANSMUTATION, FIFTH, CastingTime.ONE_HOUR, 0, VSM, INSTANTANEOUS, 0, 0, doNothing);
            }
        }

        /* TODO:
        You can see and hear a particular creature you choose that is on the same plane of
        existence as you.
        The target must make a wisdom saving throw, which is modified by how well you know
        the target and the sort of physical connection you have to it.
        If a target knows you're casting this spell, it can fail the saving throw
        voluntarily if it wants to be observed.
        On a successful save, the target isn't affected, and you can't use this spell
        against it again for 24 hours.
        On a failed save, the spell creates an invisible sensor within 10 feet of the
        target.
        You can see and hear through the sensor as if you were there.
        The sensor moves with the target, remaining within 10 feet of it for the duration.
        A creature that can see invisible objects sees the sensor as a luminous orb about
        the size of your fist.
        Instead of targeting a creature, you can choose a location you have seen before as
        the target of this spell.
        When you do, the sensor appears at that location and doesn't move.
         */
        public static Spell Scrying {
            get {
                return new Spell(ID.SCRYING, DIVINATION, FIFTH, CastingTime.TEN_MINUTES, 0, VSM, TEN_MINUTES, 0, 0, doNothing);
            }
        }

        /* TODO:
        This spell allows you to change the appearance of any number of creatures that you
        can see within range.
        You give each target you choose a new, illusory appearance.
        An unwilling target can make a charisma saving throw, and if it succeeds, it is
        unaffected by this spell.
        The spell disguises physical appearance as well as clothing, armor, weapons, and
        equipment.
        You can make each creature seem 1 foot shorter or taller and appear thin, fat, or
        in between.
        You can't change a target's body type, so you must choose a form that has the same
        basic arrangement of limbs.
        Otherwise, the extent of the illusion is up to you.
        The spell lasts for the duration, unless you use your action to dismiss it sooner.
        The changes wrought by this spell fail to hold up to physical inspection.
        For example, if you use this spell to add a hat to a creature's outfit, objects
        pass through the hat, and anyone who touches it would feel nothing or would feel
        the creature's head and hair.
        If you use this spell to appear thinner than you are, the hand of someone who
        reaches out to touch you would bump into you while it was seemingly still in
        midair.
        A creature can use its action to inspect a target and make an Intelligence
        (Investigation) check against your spell save DC.
        If it succeeds, it becomes aware that the target is disguised.
         */
        public static Spell Seeming {
            get {
                return new Spell(ID.SEEMING, ILLUSION, FIFTH, CastingTime.ONE_ACTION, 30, VS, EIGHT_HOURS, 0, 0, doNothing);
            }
        }

        /* TODO:
        You gain the ability to move or manipulate creatures or objects by thought.
        When you cast the spell, and as your action each round for the duration, you can
        exert your will on one creature or object that you can see within range, causing
        the appropriate effect below.
        You can affect the same target round after round, or choose a new one at any time.
        If you switch targets, the prior target is no longer affected by the spell.
        ***Creature.*** You can try to move a Huge or smaller creature.
        Make an ability check with your spellcasting ability contested by the creature's
        Strength check.
        If you win the contest, you move the creature up to 30 feet in any direction,
        including upward but not beyond the range of this spell.
        Until the end of your next turn, the creature is restrained in your telekinetic
        grip.
        A creature lifted upward is suspended in mid-air.
        On subsequent rounds, you can use your action to attempt to maintain your
        telekinetic grip on the creature by repeating the contest.
        ***Object.*** You can try to move an object that weighs up to 1,000 pounds.
        If the object isn't being worn or carried, you automatically move it up to 30 feet
        in any direction, but not beyond the range of this spell.
        If the object is worn or carried by a creature, you must make an ability check
        with your spellcasting ability contested by that creature's Strength check.
        If you succeed, you pull the object away from that creature and can move it up to
        30 feet in any direction but not beyond the range of this spell.
        You can exert fine control on objects with your telekinetic grip, such as
        manipulating a simple tool, opening a door or a container, stowing or retrieving
        an item from an open container, or pouring the contents from a vial.
         */
        public static Spell Telekinesis {
            get {
                return new Spell(ID.TELEKINESIS, TRANSMUTATION, FIFTH, CastingTime.ONE_ACTION, 60, VS, TEN_MINUTES, 30, 0, doNothing);
            }
        }

        /* TODO:
        You forge a telepathic link among up to eight willing creatures of your choice
        within range, psychically linking each creature to all the others for the
        duration.
        Creatures with Intelligence scores of 2 or less aren't affected by this spell.
        Until the spell ends, the targets can communicate telepathically through the bond
        whether or not they have a common language.
        The communication is possible over any distance, though it can't extend to other
        planes of existence.
         */
        public static Spell TelepathicBond {
            get {
                return new Spell(ID.TELEPATHIC_BOND, DIVINATION, FIFTH, CastingTime.ONE_ACTION, 30, VSM, ONE_HOUR, 0, 0, doNothing);
            }
        }

        /* TODO:
        As you cast the spell, you draw a 10-foot-diameter circle on the ground inscribed
        with sigils that link your location to a permanent teleportation circle of your
        choice whose sigil sequence you know and that is on the same plane of existence as
        you.
        A shimmering portal opens within the circle you drew and remains open until the
        end of your next turn.
        Any creature that enters the portal instantly appears within 5 feet of the
        destination circle or in the nearest unoccupied space if that space is occupied.
        Many major temples, guilds, and other important places have permanent
        teleportation circles inscribed somewhere within their confines.
        Each such circle includes a unique sigil sequence--a string of magical runes
        arranged in a particular pattern.
        When you first gain the ability to cast this spell, you learn the sigil sequences
        for two destinations on the Material Plane, determined by the DM.
        You can learn additional sigil sequences during your adventures.
        You can commit a new sigil sequence to memory after studying it for 1 minute.
        You can create a permanent teleportation circle by casting this spell in the same
        location every day for one year.
        You need not use the circle to teleport when you cast the spell in this way.
         */
        public static Spell TeleportationCircle {
            get {
                return new Spell(ID.TELEPORTATION_CIRCLE, CONJURATION, FIFTH, CastingTime.ONE_MINUTE, 10, VM, ONE_ROUND, 10, 0, doNothing);
            }
        }

        /* TODO:
        You gain the ability to enter a tree and move from inside it to inside another
        tree of the same kind within 500 feet.
        Both trees must be living and at least the same size as you.
        You must use 5 feet of movement to enter a tree.
        You instantly know the location of all other trees of the same kind within 500
        feet and, as part of the move used to enter the tree, can either pass into one of
        those trees or step out of the tree you're in.
        You appear in a spot of your choice within 5 feet of the destination tree, using
        another 5 feet of movement.
        If you have no movement left, you appear within 5 feet of the tree you entered.
        You can use this transportation ability once per round for the duration.
        You must end each turn outside a tree.
         */
        public static Spell TreeStride {
            get {
                return new Spell(ID.TREE_STRIDE, CONJURATION, FIFTH, CastingTime.ONE_ACTION, 0, VS, ONE_MINUTE, 0, 0, doNothing);
            }
        }

        /* TODO:
        An invisible wall of force springs into existence at a point you choose within
        range.
        The wall appears in any orientation you choose, as a horizontal or vertical
        barrier or at an angle.
        It can be free floating or resting on a solid surface.
        You can form it into a hemispherical dome or a sphere with a radius of up to 10
        feet, or you can shape a flat surface made up of ten 10-foot-by-10-foot panels.
        Each panel must be contiguous with another panel.
        In any form, the wall is 1/4 inch thick.
        It lasts for the duration.
        If the wall cuts through a creature's space when it appears, the creature is
        pushed to one side of the wall (your choice which side).
        Nothing can physically pass through the wall.
        It is immune to all damage and can't be dispelled by dispel magic.
        A disintegrate spell destroys the wall instantly, however.
        The wall also extends into the Ethereal Plane, blocking ethereal travel through
        the wall.
         */
        public static Spell WallOfForce {
            get {
                return new Spell(ID.WALL_OF_FORCE, EVOCATION, FIFTH, CastingTime.ONE_ACTION, 120, VSM, TEN_MINUTES, 0, 0, doNothing);
            }
        }

        /* TODO:
        A nonmagical wall of solid stone springs into existence at a point you choose
        within range.
        The wall is 6 inches thick and is composed of ten 10-foot-by-10-foot panels.
        Each panel must be contiguous with at least one other panel.
        Alternatively, you can create 10-foot-by-20-foot panels that are only 3 inches
        thick.
        If the wall cuts through a creature's space when it appears, the creature is
        pushed to one side of the wall (your choice).
        If a creature would be surrounded on all sides by the wall (or the wall and
        another solid surface), that creature can make a dexterity saving throw.
        On a success, it can use its reaction to move up to its speed so that it is no
        longer enclosed by the wall.
        The wall can have any shape you desire, though it can't occupy the same space as a
        creature or object.
        The wall doesn't need to be vertical or rest on any firm foundation.
        It must, however, merge with and be solidly supported by existing stone.
        Thus, you can use this spell to bridge a chasm or create a ramp.
        If you create a span greater than 20 feet in length, you must halve the size of
        each panel to create supports.
        You can crudely shape the wall to create crenellations, battlements, and so on.
        The wall is an object made of stone that can be damaged and thus breached.
        Each panel has AC 15 and 30 hit points per inch of thickness.
        Reducing a panel to 0 hit points destroys it and might cause connected panels to
        collapse at the DM's discretion.
        If you maintain your concentration on this spell for its whole duration, the wall
        becomes permanent and can't be dispelled.
        Otherwise, the wall disappears when the spell ends.
         */
        public static Spell WallOfStone {
            get {
                return new Spell(ID.WALL_OF_STONE, EVOCATION, FIFTH, CastingTime.ONE_ACTION, 120, VSM, TEN_MINUTES, 0, 0, doNothing);
            }
        }
    }
}
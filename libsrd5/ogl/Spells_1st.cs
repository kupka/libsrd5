using System;
using static srd5.Die;
using static srd5.SpellSchool;
using static srd5.SpellLevel;
using static srd5.SpellDuration;
using static srd5.DamageType;
using static srd5.Spells.DamageMitigation;
using static srd5.Effect;
using static srd5.AbilityType;

namespace srd5 {
    public partial struct Spells {

        /*
        You set an alarm against unwanted intrusion. Choose a door, a window, or an area
        within range that is no larger than a 20-foot cube. Until the spell ends, an alarm
        alerts you whenever a Tiny or larger creature touches or enters the warded area.
        When you cast the spell, you can designate creatures that won't set off the alarm.
        You also choose whether the alarm is mental or audible.
        A mental alarm alerts you with a ping in your mind if you are within 1 mile of the
        warded area. This ping awakens you if you are sleeping.
        An audible alarm produces the sound of a hand bell for 10 seconds within 60 feet.
         */
        public static Spell Alarm {
            get {
                return new Spell(ID.ALARM, ABJURATION, FIRST, CastingTime.ONE_MINUTE, 30, VSM, EIGHT_HOURS, 20, 0, SpellWithoutEffect(ID.ALARM));
            }
        }

        /*
        This spell lets you convince a beast that you mean it no harm. Choose a beast that
        you can see within range. It must see and hear you. If the beast's Intelligence is
        4 or higher, the spell fails. Otherwise, the beast must succeed on a wisdom saving
        throw or be charmed by you for the spell's duration. If you or one of your
        companions harms the target, the spells ends.
         */
        public static Spell AnimalFriendship {
            get {
                return new Spell(ID.ANIMAL_FRIENDSHIP, ENCHANTMENT, FIRST, CastingTime.ONE_ACTION, 30, VSM, ONE_DAY, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    if (target is Monster monster
                            && monster.Type == Monsters.Type.BEAST
                            && monster.Intelligence.Value < 4
                            && !monster.HasEffect(IMMUNITY_CHARMED)
                            // Wisdom save with advantage since we assume a fight
                            && !monster.DC(ID.ANIMAL_FRIENDSHIP, dc, WISDOM, false, true)) {
                        monster.AddEffect(SPELL_ANIMAL_FRIENDSHIP);
                        monster.AddCondition(ConditionType.CHARMED);
                        Team originalTeam = ground.GetTeam(monster);
                        ground.SetTeam(monster, ground.GetTeam(caster));
                        GlobalEvents.AffectBySpell(caster, ID.ANIMAL_FRIENDSHIP, target, true);

                        int remainingRounds = (int)ONE_DAY;
                        caster.AddEndOfTurnEvent(delegate () {
                            if (!monster.HasEffect(SPELL_ANIMAL_FRIENDSHIP)) {
                                ground.SetTeam(monster, originalTeam);
                                return true;
                            }
                            if (--remainingRounds < 1) {
                                monster.RemoveEffect(SPELL_ANIMAL_FRIENDSHIP);
                                monster.RemoveCondition(ConditionType.CHARMED);
                                ground.SetTeam(monster, originalTeam);
                                return true;
                            }
                            return false;
                        });
                    } else {
                        GlobalEvents.AffectBySpell(caster, ID.ANIMAL_FRIENDSHIP, target, false);
                    }
                });
            }
        }

        /*
        Up to three creatures of your choice that you can see within range must make
        charisma saving throws. Whenever a target that fails this saving throw makes an
        attack roll or a saving throw before the spell ends, the target must roll a d4 and
        subtract the number rolled from the attack roll or saving throw.
        When you cast this spell using a spell slot of 2nd level or higher, you can target
        one additional creature for each slot level above 1st.
         */
        public static Spell Bane {
            get {
                return new Spell(ID.BANE, ENCHANTMENT, FIRST, CastingTime.ONE_ACTION, 30, VSM, ONE_MINUTE, 0, 3, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    foreach (Combatant target in targets) {
                        if (target.DC(ID.BANE, dc, CHARISMA)) {
                            GlobalEvents.AffectBySpell(caster, ID.BANE, target, false);
                        } else {
                            AddEffectsForDuration(ID.BANE, caster, target, ONE_MINUTE, SPELL_BANE);
                        }
                    }
                });
            }
        }

        /*
        You bless up to three creatures of your choice within range. Whenever a target
        makes an attack roll or a saving throw before the spell ends, the target can roll
        a d4 and add the number rolled to the attack roll or saving throw.
        When you cast this spell using a spell slot of 2nd level or higher, you can target
        one additional creature for each slot level above 1st.
         */
        public static Spell Bless {
            get {
                return new Spell(ID.BLESS, ENCHANTMENT, FIRST, CastingTime.ONE_ACTION, 30, VSM, ONE_MINUTE, 0, 3, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    foreach (Combatant target in targets) {
                        AddEffectsForDuration(ID.BLESS, caster, target, ONE_MINUTE, SPELL_BLESS);
                    }
                });
            }
        }

        /*
        As you hold your hands with thumbs touching and fingers spread, a thin sheet of
        flames shoots forth from your outstretched fingertips. Each creature in a 15-foot
        cone must make a dexterity saving throw. A creature takes 3d6 fire damage on a
        failed save, or half as much damage on a successful one.
        The fire ignites any flammable objects in the area that aren't being worn or
        carried.
        When you cast this spell using a spell slot of 2nd level or higher, the damage
        increases by 1d6 for each slot level above 1st.
         */
        public static Spell BurningHands {
            get {
                return new Spell(ID.BURNING_HANDS, EVOCATION, FIRST, CastingTime.ONE_ACTION, 0, VS, INSTANTANEOUS, 15, 4, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Dice dice = DiceSlotScaling(FIRST, slot, D6, 3);
                    foreach (Combatant target in targets) {
                        target.TakeDamage(new DamageSource(ID.BURNING_HANDS, caster), FIRE, dice.Roll(), HALVES_DAMAGE, dc, DEXTERITY, out _);
                        GlobalEvents.AffectBySpell(caster, ID.BURNING_HANDS, target, true);
                    }
                });
            }
        }

        /*
        You attempt to charm a humanoid you can see within range. It must make a wisdom
        saving throw, and does so with advantage if you or your companions are fighting
        it. If it fails the saving throw, it is charmed by you until the spell ends or
        until you or your companions do anything harmful to it. The charmed creature
        regards you as a friendly acquaintance. When the spell ends, the creature knows it
        was charmed by you.
        When you cast this spell using a spell slot of 2nd level or higher, you can target
        one additional creature for each slot level above 1st. The creatures must be
        within 30 feet of each other when you target them.
         */
        public static Spell CharmPerson {
            get {
                return new Spell(
                    ID.CHARM_PERSON, ENCHANTMENT, FIRST, CastingTime.ONE_ACTION, 30, VS,
                    ONE_HOUR, 0, 20, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        Combatant[] charmed = new Combatant[0];
                        Team[] originalTeams = new Team[0];
                        // one target per slot
                        for (int i = 0; i < (int)slot && i < targets.Length; i++) {
                            Combatant target = targets[i];
                            // only affect humanoid monsters
                            if (target is Monster monster) {
                                if (monster.Type != Monsters.Type.HUMANOID) {
                                    GlobalEvents.AffectBySpell(caster, ID.CHARM_PERSON, monster, false);
                                    continue;
                                }
                            }
                            // Wisdom save with advantage since we assume a fight
                            if (!target.DC(ID.CHARM_PERSON, dc, WISDOM, true) && target.AddCondition(ConditionType.CHARMED)) {
                                Utils.Push<Combatant>(ref charmed, target);
                                Utils.Push<Team>(ref originalTeams, ground.GetTeam(target));
                                ground.SetTeam(target, ground.GetTeam(caster));
                                GlobalEvents.AffectBySpell(caster, ID.CHARM_PERSON, target, true);
                            } else {
                                GlobalEvents.AffectBySpell(caster, ID.CHARM_PERSON, target, false);
                            }
                        }

                        if (charmed.Length > 0) {
                            int remainingRounds = (int)ONE_HOUR;
                            caster.AddEndOfTurnEvent(delegate () {
                                if (--remainingRounds < 1) {
                                    for (int i = 0; i < charmed.Length; i++) {
                                        charmed[i].RemoveCondition(ConditionType.CHARMED);
                                        ground.SetTeam(charmed[i], originalTeams[i]);
                                    }
                                    return true;
                                }
                                return false;
                            });
                        }
                    }
                );
            }
        }

        /*
        A dazzling array of flashing, colored light springs from your hand. Roll 6d10; the
        total is how many hit points of creatures this spell can effect. Creatures in a
        15-foot cone originating from you are affected in ascending order of their current
        hit points (ignoring unconscious creatures and creatures that can't see).
        Starting with the creature that has the lowest current hit points, each creature
        affected by this spell is blinded until the spell ends. Subtract each creature's
        hit points from the total before moving on to the creature with the next lowest
        hit points. A creature's hit points must be equal to or less than the remaining
        total for that creature to be affected.
        When you cast this spell using a spell slot of 2nd level or higher, roll an
        additional 2d10 for each slot level above 1st.
         */
        public static Spell ColorSpray {
            get {
                return new Spell(ID.COLOR_SPRAY, ILLUSION, FIRST, CastingTime.ONE_ACTION, 0, VSM, ONE_ROUND, 15, 10, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Dice dice = DiceSlotScaling(FIRST, slot, D10, 5, 0, 2);
                    int remainingHitpoints = dice.Roll();
                    Array.Sort(targets, (t1, t2) => {
                        return t1.HitPoints.CompareTo(t2.HitPoints);
                    });
                    for (int i = 0; i < targets.Length && targets[i].HitPoints <= remainingHitpoints; i++) {
                        Combatant target = targets[i];
                        // ignoring unconscious creatures
                        if (target.HasCondition(ConditionType.UNCONSCIOUS)) continue;
                        // Creatures immune to being blinded aren't affected by this spell
                        if (target.HasEffect(IMMUNITY_BLINDED)) continue;
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

        /*
        You speak a one-word command to a creature you can see within range. The target
        must succeed on a wisdom saving throw or follow the command on its next turn. The
        spell has no effect if the target is undead, if it doesn't understand your
        language, or if your command is directly harmful to it.
        Some typical commands and their effects follow. You might issue a command other
        than one described here. If you do so, the DM determines how the target behaves.
        If the target can't follow your command, the spell ends.
        ***Approach.*** The target moves toward you by the shortest and most direct route,
        ending its turn if it moves within 5 feet of you.
        ***Drop.*** The target drops whatever it is holding and then ends its turn.
        ***Flee.*** The target spends its turn moving away from you by the fastest
        available means.
        ***Grovel.*** The target falls prone and then ends its turn.
        ***Halt.*** The target doesn't move and takes no actions. A flying creature stays
        aloft, provided that it is able to do so. If it must move to stay aloft, it flies
        the minimum distance needed to remain in the air.
        When you cast this spell using a spell slot of 2nd level or higher, you can affect
        one additional creature for each slot level above 1st. The creatures must be
        within 30 feet of each other when you target them.
         */
        public static Spell Command {
            get {
                return new Spell(ID.COMMAND, ENCHANTMENT, FIRST, CastingTime.ONE_ACTION, 60, V, ONE_ROUND, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // Command knows multiple effects, but here only the "Grovel" command seems to be feasible for implementation
                    Combatant target = targets[0];
                    bool affected = true;
                    if (target is Monster monster && monster.Type == Monsters.Type.UNDEAD) {
                        affected = false;
                    } else if (target.DC(ID.COMMAND, dc, WISDOM)) {
                        affected = false;
                    } else {
                        target.AddCondition(ConditionType.PRONE);
                        target.AddEffect(SPELL_COMMAND_GROVEL);
                        target.AddEndOfTurnEvent(delegate () {
                            target.RemoveEffect(SPELL_COMMAND_GROVEL);
                            return true;
                        });
                    }
                    GlobalEvents.AffectBySpell(caster, ID.COMMAND, target, affected);
                });
            }
        }

        /*
        For the duration, you understand the literal meaning of any spoken language that
        you hear. You also understand any written language that you see, but you must be
        touching the surface on which the words are written. It takes about 1 minute to
        read one page of text.
        This spell doesn't decode secret messages in a text or a glyph, such as an arcane
        sigil, that isn't part of a written language.
         */
        public static Spell ComprehendLanguages {
            get {
                return new Spell(ID.COMPREHEND_LANGUAGES, DIVINATION, FIRST, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    AddEffectsForDuration(ID.COMPREHEND_LANGUAGES, caster, caster, ONE_HOUR, SPELL_COMPREHEND_LANGUAGES);
                });
            }
        }

        /*
        You either create or destroy water.
        ***Create Water.*** You create up to 10 gallons of clean water within range in an
        open container. Alternatively, the water falls as rain in a 30-foot cube within
        range.
        ***Destroy Water.*** You destroy up to 10 gallons of water in an open container
        within range. Alternatively, you destroy fog in a 30-foot cube within range.
        When you cast this spell using a spell slot of 2nd level or higher, you create or
        destroy 10 additional gallons of water, or the size of the cube increases by 5
        feet, for each slot level above 1st.
         */
        public static Spell CreateorDestroyWater {
            get {
                return new Spell(
                    ID.CREATE_OR_DESTROY_WATER, TRANSMUTATION, FIRST, CastingTime.ONE_ACTION, 30, VS,
                    INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.CREATE_OR_DESTROY_WATER)
                );
            }
        }

        /*
        A creature you touch regains a number of hit points equal to 1d8 + your
        spellcasting ability modifier. This spell has no effect on undead or constructs.
        When you cast this spell using a spell slot of 2nd level or higher, the healing
        increases by 1d8 for each slot level above 1st.
         */
        public static Spell CureWounds {
            get {
                return new Spell(
                    ID.CURE_WOUNDS, EVOCATION, FIRST, CastingTime.ONE_ACTION, 5, VS,
                    INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        Combatant target = targets[0];
                        if (target is Monster monster) {
                            if (monster.Type == Monsters.Type.CONSTRUCT || monster.Type == Monsters.Type.UNDEAD) {
                                GlobalEvents.AffectBySpell(caster, ID.CURE_WOUNDS, monster, false);
                                return;
                            }
                        }
                        Dice dice = DiceSlotScaling(FIRST, slot, D8, 1, modifier);
                        GlobalEvents.AffectBySpell(caster, ID.CURE_WOUNDS, target, true);
                        target.HealDamage(dice);
                    }
                );
            }
        }

        /*
        For the duration, you know if there is an aberration, celestial, elemental, fey,
        fiend, or undead within 30 feet of you, as well as where the creature is located.
        Similarly, you know if there is a place or object within 30 feet of you that has
        been magically consecrated or desecrated.
        The spell can penetrate most barriers, but it is blocked by 1 foot of stone, 1
        inch of common metal, a thin sheet of lead, or 3 feet of wood or dirt.
         */
        public static Spell DetectEvilandGood {
            get {
                return new Spell(ID.DETECT_EVIL_AND_GOOD, DIVINATION, FIRST, CastingTime.ONE_ACTION, 0, VS, TEN_MINUTES, 30, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    AddEffectsForDuration(ID.DETECT_EVIL_AND_GOOD, caster, caster, TEN_MINUTES, SPELL_DETECT_EVIL_AND_GOOD);
                });
            }
        }

        /*
        For the duration, you sense the presence of magic within 30 feet of you. If you
        sense magic in this way, you can use your action to see a faint aura around any
        visible creature or object in the area that bears magic, and you learn its school
        of magic, if any.
        The spell can penetrate most barriers, but it is blocked by 1 foot of stone, 1
        inch of common metal, a thin sheet of lead, or 3 feet of wood or dirt.
         */
        public static Spell DetectMagic {
            get {
                return new Spell(ID.DETECT_MAGIC, DIVINATION, FIRST, CastingTime.ONE_ACTION, 0, VS, TEN_MINUTES, 30, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    AddEffectsForDuration(ID.DETECT_MAGIC, caster, caster, TEN_MINUTES, SPELL_DETECT_MAGIC);
                });
            }
        }

        /*
        For the duration, you can sense the presence and location of poisons, poisonous
        creatures, and diseases within 30 feet of you. You also identify the kind of
        poison, poisonous creature, or disease in each case.
        The spell can penetrate most barriers, but it is blocked by 1 foot of stone, 1
        inch of common metal, a thin sheet of lead, or 3 feet of wood or dirt.
         */
        public static Spell DetectPoisonAndDisease {
            get {
                return new Spell(ID.DETECT_POISON_AND_DISEASE, DIVINATION, FIRST, CastingTime.ONE_ACTION, 0, VSM, TEN_MINUTES, 30, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    AddEffectsForDuration(ID.DETECT_POISON_AND_DISEASE, caster, caster, TEN_MINUTES, SPELL_DETECT_POISON_AND_DISEASE);
                });
            }
        }

        /*
        You make yourself--including your clothing, armor, weapons, and other belongings
        on your person--look different until the spell ends or until you use your action
        to dismiss it. You can seem 1 foot shorter or taller and can appear thin, fat, or
        in between. You can't change your body type, so you must adopt a form that has the
        same basic arrangement of limbs. Otherwise, the extent of the illusion is up to
        you.
        The changes wrought by this spell fail to hold up to physical inspection. For
        example, if you use this spell to add a hat to your outfit, objects pass through
        the hat, and anyone who touches it would feel nothing or would feel your head and
        hair. If you use this spell to appear thinner than you are, the hand of someone
        who reaches out to touch you would bump into you while it was seemingly still in
        midair.
        To discern that you are disguised, a creature can use its action to inspect your
        appearance and must succeed on an Intelligence (Investigation) check against your
        spell save DC.
         */
        public static Spell DisguiseSelf {
            get {
                return new Spell(ID.DISGUISE_SELF, ILLUSION, FIRST, CastingTime.ONE_ACTION, 0, VS, ONE_HOUR, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    AddEffectsForDuration(ID.DISGUISE_SELF, caster, caster, ONE_HOUR, SPELL_DISGUISE_SELF);
                });
            }
        }

        /*
        Your prayer empowers you with divine radiance. Until the spell ends, your weapon
        attacks deal an extra 1d4 radiant damage on a hit.
         */
        public static Spell DivineFavor {
            get {
                return new Spell(ID.DIVINE_FAVOR, EVOCATION, FIRST, CastingTime.BONUS_ACTION, 0, VS, ONE_MINUTE, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    AddEffectsForDuration(ID.BANE, caster, target, ONE_MINUTE, SPELL_DIVINE_FAVOR);
                });
            }
        }

        /*
        Grasping weeds and vines sprout from the ground in a 20-foot square starting form
        a point within range. For the duration, these plants turn the ground in the area
        into difficult terrain.
        A creature in the area when you cast the spell must succeed on a strength saving
        throw or be restrained by the entangling plants until the spell ends. A creature
        restrained by the plants can use its action to make a Strength check against your
        spell save DC. On a success, it frees itself.
        When the spell ends, the conjured plants wilt away.
         */
        public static Spell Entangle {
            get {
                return new Spell(
                    ID.ENTANGLE, CONJURATION, FIRST, CastingTime.ONE_ACTION, 90, VS,
                    ONE_MINUTE, 20, 20, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        foreach (Combatant target in targets) {
                            if (target.DC(ID.ENTANGLE, dc, STRENGTH)) {
                                GlobalEvents.AffectBySpell(caster, ID.ENTANGLE, target, false);
                            } else {
                                AddEffectAndConditionsForDuration(ID.ENTANGLE, caster, target, ONE_MINUTE, SPELL_ENTANGLE, ConditionType.RESTRAINED);
                            }
                        }
                    }
                );
            }
        }

        /* TODO:
        NOTE: Needs implementation of "Dash" Bonus Action
        This spell allows you to move at an incredible pace. When you cast this spell, and
        then as a bonus action on each of your turns until the spell ends, you can take
        the Dash action.
         */
        public static Spell ExpeditiousRetreat {
            get {
                return new Spell(ID.EXPEDITIOUS_RETREAT, TRANSMUTATION, FIRST, CastingTime.BONUS_ACTION, 0, VS, TEN_MINUTES, 0, 0, doNothing);
            }
        }

        /*
        Each object in a 20-foot cube within range is outlined in blue, green, or violet
        light (your choice). Any creature in the area when the spell is cast is also
        outlined in light if it fails a dexterity saving throw. For the duration, objects
        and affected creatures shed dim light in a 10-foot radius.
        Any attack roll against an affected creature or object has advantage if the
        attacker can see it, and the affected creature or object can't benefit from being
        invisible.
         */
        public static Spell FaerieFire {
            get {
                return new Spell(
                    ID.FAERIE_FIRE, EVOCATION, FIRST, CastingTime.ONE_ACTION, 60, V,
                    ONE_MINUTE, 20, 20, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        foreach (Combatant target in targets) {
                            if (target.DC(ID.FAERIE_FIRE, dc, DEXTERITY)) {
                                GlobalEvents.AffectBySpell(caster, ID.FAERIE_FIRE, target, false);
                            } else {
                                AddEffectsForDuration(ID.FAERIE_FIRE, caster, target, ONE_MINUTE, SPELL_FAIRIE_FIRE);
                            }
                        }
                    }
                );
            }
        }

        /*
        Bolstering yourself with a necromantic facsimile of life, you gain 1d4 + 4
        temporary hit points for the duration.
        When you cast this spell using a spell slot of 2nd level or higher, you gain 5
        additional temporary hit points for each slot level above 1st.
         */
        public static Spell FalseLife {
            get {
                return new Spell(ID.FALSE_LIFE, NECROMANCY, FIRST, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    int temporaryHitpoints = D4.Value + 4 + ((int)slot - 1) * 5;
                    GlobalEvents.AffectBySpell(caster, ID.FALSE_LIFE, caster, true);
                    caster.AddTemporaryHitpoints(temporaryHitpoints, ONE_HOUR, ID.FALSE_LIFE);
                });
            }
        }

        /*
        Choose up to five falling creatures within range. A falling creature's rate of
        descent slows to 60 feet per round until the spell ends. If the creature lands
        before the spell ends, it takes no falling damage and can land on its feet, and
        the spell ends for that creature.
         */
        public static Spell FeatherFall {
            get {
                return new Spell(ID.FEATHER_FALL, TRANSMUTATION, FIRST, CastingTime.REACTION, 60, VM, ONE_MINUTE, 0, 5, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    foreach (Combatant target in targets) {
                        AddEffectsForDuration(ID.FEATHER_FALL, caster, target, ONE_MINUTE, SPELL_FEATHER_FALL);
                    }
                });
            }
        }

        /*
        You gain the service of a familiar, a spirit that takes an animal form you choose:
        bat, cat, crab, frog (toad), hawk, lizard, octopus, owl, poisonous snake, fish
        (quipper), rat, raven, sea horse, spider, or weasel. Appearing in an unoccupied
        space within range, the familiar has the statistics of the chosen form, though it
        is a celestial, fey, or fiend (your choice) instead of a beast.
        Your familiar acts independently of you, but it always obeys your commands. In
        combat, it rolls its own initiative and acts on its own turn. A familiar can't
        attack, but it can take other actions as normal.
        When the familiar drops to 0 hit points, it disappears, leaving behind no physical
        form. It reappears after you cast this spell again.
        While your familiar is within 100 feet of you, you can communicate with it
        telepathically. Additionally, as an action, you can see through your familiar's
        eyes and hear what it hears until the start of your next turn, gaining the
        benefits of any special senses that the familiar has. During this time, you are
        deaf and blind with regard to your own senses.
        As an action, you can temporarily dismiss your familiar. It disappears into a
        pocket dimension where it awaits your summons. Alternatively, you can dismiss it
        forever. As an action while it is temporarily dismissed, you can cause it to
        reappear in any unoccupied space within 30 feet of you.
        You can't have more than one familiar at a time. If you cast this spell while you
        already have a familiar, you instead cause it to adopt a new form. Choose one of
        the forms from the above list. Your familiar transforms into the chosen creature.
        Finally, when you cast a spell with a range of touch, your familiar can deliver
        the spell as if it had cast the spell. Your familiar must be within 100 feet of
        you, and it must use its reaction to deliver the spell when you cast it. If the
        spell requires an attack roll, you use your action modifier for the roll.
         */
        public static Spell FindFamiliar {
            get {
                return new Spell(ID.FIND_FAMILIAR, CONJURATION, FIRST, CastingTime.ONE_HOUR, 10, VSM, INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.FIND_FAMILIAR));
            }
        }

        /*
        This spell creates a circular, horizontal plane of force, 3 feet in diameter and 1
        inch thick, that floats 3 feet above the ground in an unoccupied space of your
        choice that you can see within range. The disk remains for the duration, and can
        hold up to 500 pounds. If more weight is placed on it, the spell ends, and
        everything on the disk falls to the ground.
        The disk is immobile while you are within 20 feet of it. If you move more than 20
        feet away from it, the disk follows you so that it remains within 20 feet of you.
        If can move across uneven terrain, up or down stairs, slopes and the like, but it
        can't cross an elevation change of 10 feet or more. For example, the disk can't
        move across a 10-foot-deep pit, nor could it leave such a pit if it was created at
        the bottom.
        If you move more than 100 feet away from the disk (typically because it can't move
        around an obstacle to follow you), the spell ends.
         */
        public static Spell FloatingDisk {
            get {
                return new Spell(ID.FLOATING_DISK, CONJURATION, FIRST, CastingTime.ONE_ACTION, 30, VSM, ONE_HOUR, 0, 0, SpellWithoutEffect(ID.FLOATING_DISK));
            }
        }

        /*
        You create a 20-foot-radius sphere of fog centered on a point within range. The
        sphere spreads around corners, and its area is heavily obscured. It lasts for the
        duration or until a wind of moderate or greater speed (at least 10 miles per hour)
        disperses it.
        When you cast this spell using a spell slot of 2nd level or higher, the radius of
        the fog increases by 20 feet for each slot level above 1st.
         */
        public static Spell FogCloud {
            get {
                return new Spell(
                    ID.FOG_CLOUD, CONJURATION, FIRST, CastingTime.ONE_ACTION, 120, VS,
                    ONE_HOUR, 20, 0, SpellWithoutEffect(ID.FOG_CLOUD)
                );
            }
        }

        /*
        Up to ten berries appear in your hand and are infused with magic for the duration.
        A creature can use its action to eat one berry. Eating a berry restores 1 hit
        point, and the berry provides enough nourishment to sustain a creature for a day.
        The berries lose their potency if they have not been consumed within 24 hours of
        the casting of this spell.
         */
        public static Spell Goodberry {
            get {
                return new Spell(ID.GOODBERRY, TRANSMUTATION, FIRST, CastingTime.ONE_ACTION, 0, VSM, INSTANTANEOUS, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    if (caster is CharacterSheet hero) {
                        for (int i = 0; i < 10; i++) {
                            hero.Inventory.AddToBag(Potions.Goodberry);
                        }
                    }
                });
            }
        }

        /*
        Slick grease covers the ground in a 10-foot square centered on a point within
        range and turns it into difficult terrain for the duration.
        When the grease appears, each creature standing in its area must succeed on a
        dexterity saving throw or fall prone. A creature that enters the area or ends its
        turn there must also succeed on a dexterity saving throw or fall prone.
         */
        public static Spell Grease {
            get {
                return new Spell(ID.GREASE, CONJURATION, FIRST, CastingTime.ONE_ACTION, 60, VSM, ONE_MINUTE, 10, 4, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    foreach (Combatant target in targets) {
                        if (!target.HasEffect(IMMUNITY_PRONE) && !target.DC(ID.GREASE, dc, DEXTERITY)) {
                            target.AddCondition(ConditionType.PRONE);
                            GlobalEvents.AffectBySpell(caster, ID.GREASE, target, true);
                        } else {
                            GlobalEvents.AffectBySpell(caster, ID.GREASE, target, false);
                        }
                    }
                });
            }
        }

        /*
        A flash of light streaks toward a creature of your choice within range. Make a
        ranged spell attack against the target. On a hit, the target takes 4d6 radiant
        damage, and the next attack roll made against this target before the end of your
        next turn has advantage, thanks to the mystical dim light glittering on the target
        until then.
        When you cast this spell using a spell slot of 2nd level or higher, the damage
        increases by 1d6 for each slot level above 1st.
         */
        public static Spell GuidingBolt {
            get {
                return new Spell(ID.GUIDING_BOLT, EVOCATION, FIRST, CastingTime.ONE_ACTION, 120, VS, ONE_ROUND, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    Dice dice = DiceSlotScaling(FIRST, slot, D6, 3);
                    bool hit = SpellAttack(ID.GUIDING_BOLT, ground, caster, RADIANT, dice, modifier, target, 120);
                    if (hit) {
                        target.AddEffect(ADVANTAGE_ON_BEING_ATTACKED);
                        bool removeNextRound = false;
                        caster.AddStartOfTurnEvent(delegate () {
                            removeNextRound = true;
                            return true;
                        });
                        caster.AddEndOfTurnEvent(delegate () {
                            if (removeNextRound) {
                                target.RemoveEffect(ADVANTAGE_ON_BEING_ATTACKED);
                                return true;
                            } else {
                                return false;
                            }
                        });
                    }
                });
            }
        }

        /*
        A creature of your choice that you can see within range regains hit points equal
        to 1d4 + your spellcasting ability modifier. This spell has no effect on undead or
        constructs.
        When you cast this spell using a spell slot of 2nd level or higher, the healing
        increases by 1d4 for each slot level above 1st.
         */
        public static Spell HealingWord {
            get {
                return new Spell(
                    ID.HEALING_WORD, EVOCATION, FIRST, CastingTime.BONUS_ACTION, 60, V,
                    INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        Combatant target = targets[0];
                        if (target is Monster monster) {
                            if (monster.Type == Monsters.Type.CONSTRUCT || monster.Type == Monsters.Type.UNDEAD) {
                                GlobalEvents.AffectBySpell(caster, ID.HEALING_WORD, monster, false);
                                return;
                            }
                            ;
                        }
                        Dice healed = DiceSlotScaling(FIRST, slot, D4, 1, modifier);
                        GlobalEvents.AffectBySpell(caster, ID.HEALING_WORD, target, true);
                        target.HealDamage(healed);
                    }
                );
            }
        }

        /*
        You point your finger, and the creature that damaged you is momentarily surrounded
        by hellish flames. The creature must make a dexterity saving throw. It takes 2d10
        fire damage on a failed save, or half as much damage on a successful one.
         */
        public static Spell HellishRebuke {
            get {
                return new Spell(ID.HELLISH_REBUKE, EVOCATION, FIRST, CastingTime.REACTION, 60, VS, INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // TODO: Should only affect targets that damaged the caster but we can't determine this here
                    Dice dice = DiceSlotScaling(FIRST, slot, D10, 2);
                    Combatant target = targets[0];
                    target.TakeDamage(new DamageSource(ID.HELLISH_REBUKE, caster), FIRE, dice.Roll(), HALVES_DAMAGE, dc, DEXTERITY, out _);
                    GlobalEvents.AffectBySpell(caster, ID.HELLISH_REBUKE, target, true);
                });
            }
        }

        /*
        A willing creature you touch is imbued with bravery. Until the spell ends, the
        creature is immune to being frightened and gains temporary hit points equal to
        your spellcasting ability modifier at the start of each of its turns. When the
        spell ends, the target loses any remaining temporary hit points from this spell.
         */
        public static Spell Heroism {
            get {
                return new Spell(ID.HEROISM, ENCHANTMENT, FIRST, CastingTime.ONE_ACTION, 0, VS, ONE_MINUTE, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    target.AddEffect(IMMUNITY_FRIGHTENED);
                    int remainingTurns = 10;
                    target.AddStartOfTurnEvent(delegate () {
                        target.AddTemporaryHitpoints(modifier, ONE_MINUTE, ID.HEROISM);
                        return --remainingTurns < 1;
                    });
                    target.AddEndOfTurnEvent(delegate () {
                        if (remainingTurns < 1) {
                            target.RemoveEffect(IMMUNITY_FRIGHTENED);
                            target.RemoveTemporaryHitpoints(ID.HEROISM);
                            return true;
                        } else {
                            return false;
                        }
                    });
                });
            }
        }

        /*
        A creature of your choice that you can see within range perceives everything as
        hilariously funny and falls into fits of laughter if this spell affects it. The
        target must succeed on a wisdom saving throw or fall prone, becoming incapacitated
        and unable to stand up for the duration. A creature with an Intelligence score of
        4 or less isn't affected.
        At the end of each of its turns, and each time it takes damage, the target can
        make another wisdom saving throw. The target had advantage on the saving throw if
        it's triggered by damage. On a success, the spell ends.
         */
        public static Spell HideousLaughter {
            get {
                return new Spell(ID.HIDEOUS_LAUGHTER, ENCHANTMENT, FIRST, CastingTime.ONE_ACTION, 30, VSM, ONE_MINUTE, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    if (target.Intelligence.Value < 5 || target.DC(ID.HIDEOUS_LAUGHTER, dc, WISDOM)) {
                        GlobalEvents.AffectBySpell(caster, ID.HIDEOUS_LAUGHTER, target, false);
                    } else {
                        GlobalEvents.AffectBySpell(caster, ID.HIDEOUS_LAUGHTER, target, true);
                        target.AddCondition(ConditionType.PRONE, ConditionType.INCAPACITATED);
                        target.AddEffect(SPELL_HIDEOUS_LAUGHTER);
                        int remainingRounds = 10;
                        bool madeDC = false;
                        target.AddDamageTakenEvent(delegate (DamageSource source, Damage damage) {
                            if (madeDC) {
                                return true;
                            } else if (target.DC(ID.HIDEOUS_LAUGHTER, dc, WISDOM, out _, true)) {
                                madeDC = true;
                                remainingRounds = 0;
                                target.RemoveEffect(SPELL_HIDEOUS_LAUGHTER);
                                target.RemoveCondition(ConditionType.INCAPACITATED);
                                return true;
                            } else {
                                return false;
                            }
                        });
                        target.AddEndOfTurnEvent(delegate () {
                            if (madeDC) {
                                return true;
                            } else if (--remainingRounds < 1 || target.DC(ID.HIDEOUS_LAUGHTER, dc, WISDOM)) {
                                madeDC = true;
                                target.RemoveEffect(SPELL_HIDEOUS_LAUGHTER);
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

        /*
        You choose a creature you can see within range and mystically mark it as your
        quarry. Until the spell ends, you deal an extra 1d6 damage to the target whenever
        you hit it with a weapon attack, and you have advantage on any Wisdom (Perception)
        or Wisdom (Survival) check you make to find it. If the target drops to 0 hit
        points before this spell ends, you can use a bonus action on a subsequent turn of
        yours to mark a new creature.
        When you cast this spell using a spell slot of 3rd or 4th level, you can maintain
        your concentration on the spell for up to 8 hours. When you use a spell slot of
        5th level or higher, you can maintain your concentration on the spell for up to 24
        hours.
         */
        public static Spell HuntersMark {
            get {
                return new Spell(ID.HUNTERS_MARK, DIVINATION, FIRST, CastingTime.BONUS_ACTION, 90, V, ONE_HOUR, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    target.AddDamageTakenEvent(delegate (DamageSource source, Damage damage) {
                        if (caster.Equals(source.Source)) {
                            target.TakeDamage(new DamageSource(DamageSourceType.SPELL, ID.HUNTERS_MARK, null), TRUE_DAMAGE, D6);
                        }
                        return false;
                    });
                });
            }
        }

        /* TODO:
        NOTE: At some point we will want to have unidentified items
        You choose one object that you must touch throughout the casting of the spell. If
        it is a magic item or some other magic-imbued object, you learn its properties and
        how to use them, whether it requires attunement to use, and how many charges it
        has, if any. You learn whether any spells are affecting the item and what they
        are. If the item was created by a spell, you learn which spell created it.
        If you instead touch a creature throughout the casting, you learn what spells, if
        any, are currently affecting it.
         */
        public static Spell Identify {
            get {
                return new Spell(ID.IDENTIFY, DIVINATION, FIRST, CastingTime.ONE_MINUTE, 0, VSM, INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.IDENTIFY));
            }
        }

        /*
        You write on parchment, paper, or some other suitable writing material and imbue
        it with a potent illusion that lasts for the duration.
        To you and any creatures you designate when you cast the spell, the writing
        appears normal, written in your hand, and conveys whatever meaning you intended
        when you wrote the text. To all others, the writing appears as if it were written
        in an unknown or magical script that is unintelligible. Alternatively, you can
        cause the writing to appear to be an entirely different message, written in a
        different hand and language, though the language must be one you know.
        Should the spell be dispelled, the original script and the illusion both
        disappear.
        A creature with truesight can read the hidden message.
         */
        public static Spell IllusoryScript {
            get {
                return new Spell(ID.ILLUSORY_SCRIPT, ILLUSION, FIRST, CastingTime.ONE_MINUTE, 0, SM, TEN_DAYS, 0, 0, SpellWithoutEffect(ID.ILLUSORY_SCRIPT));
            }
        }

        /*
        Make a melee spell attack against a creature you can reach. On a hit, the target
        takes 3d10 necrotic damage.
        When you cast this spell using a spell slot of 2nd level or higher, the damage
        increases by 1d10 for each slot level above 1st.
         */
        public static Spell InflictWounds {
            get {
                return new Spell(ID.INFLICT_WOUNDS, NECROMANCY, FIRST, CastingTime.ONE_ACTION, 0, VS, INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    Dice dice = DiceSlotScaling(FIRST, slot, D10, 2);
                    SpellAttack(ID.INFLICT_WOUNDS, ground, caster, NECROTIC, dice, modifier, target, 5);
                });
            }
        }

        /*
        You touch a creature. The creature's jump distance is tripled until the spell
        ends.
         */
        public static Spell Jump {
            get {
                return new Spell(
                    ID.JUMP, TRANSMUTATION, FIRST, CastingTime.ONE_ACTION, 0, VSM,
                    ONE_MINUTE, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        Combatant target = targets[0];
                        GlobalEvents.AffectBySpell(caster, ID.JUMP, target, true);
                        target.AddEffect(SPELL_JUMP);
                    }
                );
            }
        }

        /*
        You touch a creature. The target's speed increases by 10 feet until the spell
        ends.
        When you cast this spell using a spell slot of 2nd level or higher, you can target
        one additional creature for each spell slot above 1st.
         */
        public static Spell Longstrider {
            get {
                return new Spell(
                    ID.LONGSTRIDER, TRANSMUTATION, FIRST, CastingTime.ONE_ACTION, 0, VSM,
                    ONE_HOUR, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        Combatant target = targets[0];
                        GlobalEvents.AffectBySpell(caster, ID.LONGSTRIDER, target, true);
                        target.AddEffect(SPELL_LONGSTRIDER);
                    }
                );
            }
        }

        /*
        You touch a willing creature who isn't wearing armor, and a protective magical
        force surrounds it until the spell ends. The target's base AC becomes 13 + its
        Dexterity modifier. The spell ends if the target dons armor or if you dismiss the
        spell as an action.
         */
        public static Spell MageArmor {
            get {
                return new Spell(ID.MAGE_ARMOR, ABJURATION, FIRST, CastingTime.ONE_ACTION, 0, VSM, EIGHT_HOURS, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    if (target is CharacterSheet hero && hero.Inventory.Armor == null) {
                        GlobalEvents.AffectBySpell(caster, ID.MAGE_ARMOR, hero, true);
                        hero.Equip(Armors.MageArmor);
                    } else {
                        GlobalEvents.AffectBySpell(caster, ID.MAGE_ARMOR, target, true);
                    }
                });
            }
        }

        /*
        You create three glowing darts of magical force. Each dart hits a creature of your
        choice that you can see within range. A dart deals 1d4 + 1 force damage to its
        target. The darts all strike simultaneously, and you can direct them to hit one
        creature or several.
        When you cast this spell using a spell slot of 2nd level or higher, the spell
        creates one more dart for each slot level above 1st.
         */
        public static Spell MagicMissile {
            get {
                return new Spell(
                    ID.MAGIC_MISSILE, EVOCATION, FIRST, CastingTime.ONE_ACTION, 120, VS,
                    INSTANTANEOUS, 0, 20, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        Damage damage = new Damage(FORCE, D4 + 1);
                        int missilesTotal = (int)slot + 2;
                        foreach (Combatant possibleTarget in targets) {
                            Combatant target = possibleTarget;
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
                                if (target.HasEffect(SPELL_SHIELD)) {
                                    target.TakeDamage(new DamageSource(ID.MAGIC_MISSILE, caster), damage.Type, 0);
                                } else {
                                    target.TakeDamage(new DamageSource(ID.MAGIC_MISSILE, caster), damage.Type, damage.Dice);
                                }
                            }
                        }
                    }
                );
            }
        }

        /*
        Until the spell ends, one willing creature you touch is protected against certain
        types of creatures: aberrations, celestials, elementals, fey, fiends, and undead.
        The protection grants several benefits. Creatures of those types have disadvantage
        on attack rolls against the target. The target also can't be charmed, frightened,
        or possessed by them. If the target is already charmed, frightened, or possessed
        by such a creature, the target has advantage on any new saving throw against the
        relevant effect.
         */
        public static Spell ProtectionfromEvilandGood {
            get {
                return new Spell(ID.PROTECTION_FROM_EVIL_AND_GOOD, ABJURATION, FIRST, CastingTime.ONE_ACTION, 0, VSM, TEN_MINUTES, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // TODO: The target also can't be charmed, frightened, or possessed by them. If the target is already charmed, frightened, 
                    //       or possessed by such a creature, the target has advantage on any new saving throw against the relevant effect.
                    Combatant target = targets[0];
                    AddEffectsForDuration(ID.PROTECTION_FROM_EVIL_AND_GOOD, caster, target, TEN_MINUTES, SPELL_PROTECTION_FROM_EVIL_AND_GOOD);
                });
            }
        }

        /*
        All nonmagical food and drink within a 5-foot radius sphere centered on a point of
        your choice within range is purified and rendered free of poison and disease.
         */
        public static Spell PurifyFoodAndDrink {
            get {
                return new Spell(
                    ID.PURIFY_FOOD_AND_DRINK, TRANSMUTATION, FIRST, CastingTime.ONE_ACTION, 10, VS,
                    INSTANTANEOUS, 5, 0, SpellWithoutEffect(ID.PURIFY_FOOD_AND_DRINK)
                );
            }
        }

        // TODO: Right now, we don't have a means to redirect a target

        /*
        You ward a creature within range against attack. Until the spell ends, any
        creature who targets the warded creature with an attack or a harmful spell must
        first make a wisdom saving throw. On a failed save, the creature must choose a new
        target or lose the attack or spell. This spell doesn't protect the warded creature
        from area effects, such as the explosion of a fireball.
        If the warded creature makes an attack or casts a spell that affects an enemy
        creature, this spell ends.
         */
        public static Spell Sanctuary {
            get {
                return new Spell(ID.SANCTUARY, ABJURATION, FIRST, CastingTime.BONUS_ACTION, 30, VSM, ONE_MINUTE, 0, 0, SpellWithoutEffect(ID.SANCTUARY));
            }
        }

        /*
        An invisible barrier of magical force appears and protects you. Until the start of
        your next turn, you have a +5 bonus to AC, including against the triggering
        attack, and you take no damage from magic missile.
         */
        public static Spell Shield {
            get {
                return new Spell(ID.SHIELD, ABJURATION, FIRST, CastingTime.REACTION, 0, VS, ONE_ROUND, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // TODO: Right now, there is no way to apply the +5 AC buff to the attack that this spell is used as a reaction
                    GlobalEvents.AffectBySpell(caster, ID.SHIELD, caster, true);
                    caster.AddEffect(SPELL_SHIELD);
                    caster.ArmorClassModifier += 5;
                    caster.AddStartOfTurnEvent(delegate () {
                        caster.ArmorClassModifier -= 5;
                        caster.RemoveEffect(SPELL_SHIELD);
                        return true;
                    });
                });
            }
        }

        /*
        A shimmering field appears and surrounds a creature of your choice within range,
        granting it a +2 bonus to AC for the duration.
         */
        public static Spell ShieldofFaith {
            get {
                return new Spell(ID.SHIELD_OF_FAITH, ABJURATION, FIRST, CastingTime.BONUS_ACTION, 60, VSM, TEN_MINUTES, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    if (target.HasEffect(SPELL_SHIELD_OF_FAITH)) {
                        GlobalEvents.AffectBySpell(caster, ID.SHIELD_OF_FAITH, target, false);
                    } else {
                        GlobalEvents.AffectBySpell(caster, ID.SHIELD_OF_FAITH, target, true);
                        target.AddEffect(SPELL_SHIELD_OF_FAITH);
                        target.ArmorClassModifier += 2;
                        int remainingRounds = 100;
                        target.AddEndOfTurnEvent(delegate () {
                            if (--remainingRounds < 1) {
                                target.ArmorClassModifier -= 2;
                                target.RemoveEffect(SPELL_SHIELD_OF_FAITH);
                                return true;
                            } else {
                                return false;
                            }
                        });
                    }
                });
            }
        }

        /*
        You create the image of an object, a creature, or some other visible phenomenon
        that is no larger than a 15-foot cube. The image appears at a spot within range
        and lasts for the duration. The image is purely visual; it isn't accompanied by
        sound, smell, or other sensory effects.
        You can use your action to cause the image to move to any spot within range. As
        the image changes location, you can alter its appearance so that its movements
        appear natural for the image. For example, if you create an image of a creature
        and move it, you can alter the image so that it appears to be walking.
        Physical interaction with the image reveals it to be an illusion, because things
        can pass through it. A creature that uses its action to examine the image can
        determine that it is an illusion with a successful Intelligence (Investigation)
        check against your spell save DC. If a creature discerns the illusion for what it
        is, the creature can see through the image.
         */
        public static Spell SilentImage {
            get {
                return new Spell(ID.SILENT_IMAGE, ILLUSION, FIRST, CastingTime.ONE_ACTION, 60, VSM, TEN_MINUTES, 15, 0, SpellWithoutEffect(ID.SILENT_IMAGE));
            }
        }

        /*
        This spell sends creatures into a magical slumber. Roll 5d8; the total is how many
        hit points of creatures this spell can affect. Creatures within 20 feet of a point
        you choose within range are affected in ascending order of their current hit
        points (ignoring unconscious creatures).
        Starting with the creature that has the lowest current hit points, each creature
        affected by this spell falls unconscious until the spell ends, the sleeper takes
        damage, or someone uses an action to shake or slap the sleeper awake. Subtract
        each creature's hit points from the total before moving on to the creature with
        the next lowest hit points. A creature's hit points must be equal to or less than
        the remaining total for that creature to be affected.
        Undead and creatures immune to being charmed aren't affected by this spell.
        When you cast this spell using a spell slot of 2nd level or higher, roll an
        additional 2d8 for each slot level above 1st.
         */
        public static Spell Sleep {
            get {
                return new Spell(ID.SLEEP, ENCHANTMENT, FIRST, CastingTime.ONE_ACTION, 90, VSM, ONE_MINUTE, 20, 99,
                    delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        Dice dice = DiceSlotScaling(FIRST, slot, D8, 5, 0, 2);
                        int remainingHitpoints = dice.Roll();
                        Array.Sort(targets, (t1, t2) => {
                            return t1.HitPoints.CompareTo(t2.HitPoints);
                        });
                        for (int i = 0; i < targets.Length && targets[i].HitPoints <= remainingHitpoints; i++) {
                            Combatant target = targets[i];
                            // ignoring unconscious creatures
                            if (target.HasCondition(ConditionType.UNCONSCIOUS)) continue;
                            // Undead and creatures immune to being charmed aren't affected by this spell
                            if (target.HasEffect(IMMUNITY_CHARMED)) continue;
                            if (target is Monster monster && monster.Type == Monsters.Type.UNDEAD) continue;
                            // substract hitpoints and make target unconcious for one minute (10 rounds)
                            int remainingRounds = 10;
                            remainingHitpoints -= target.HitPoints;
                            target.AddCondition(ConditionType.UNCONSCIOUS);
                            bool targetTookDamage = false;
                            target.AddDamageTakenEvent(delegate (DamageSource source, Damage damage) {
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

        /*
        You gain the ability to comprehend and verbally communicate with beasts for the
        duration. The knowledge and awareness of many beasts is limited by their
        intelligence, but at a minimum, beasts can give you information about nearby
        locations and monsters, including whatever they can perceive or have perceived
        within the past day. You might be able to persuade a beast to perform a small
        favor for you, at the DM's discretion.
         */
        public static Spell SpeakWithAnimals {
            get {
                return new Spell(
                    ID.SPEAK_WITH_ANIMALS, DIVINATION, FIRST, CastingTime.ONE_ACTION, 0, VS,
                    TEN_MINUTES, 0, 0, SpellWithoutEffect(ID.SPEAK_WITH_ANIMALS)
                );
            }
        }

        /*
        A wave of thunderous force sweeps out from you. Each creature in a 15-foot cube
        originating from you must make a constitution saving throw. On a failed save, a
        creature takes 2d8 thunder damage and is pushed 10 feet away from you. On a
        successful save, the creature takes half as much damage and isn't pushed.
        In addition, unsecured objects that are completely within the area of effect are
        automatically pushed 10 feet away from you by the spell's effect, and the spell
        emits a thunderous boom audible out to 300 feet.
        When you cast this spell using a spell slot of 2nd level or higher, the damage
        increases by 1d8 for each slot level above 1st.
         */
        public static Spell Thunderwave {
            get {
                return new Spell(
                    ID.THUNDERWAVE, EVOCATION, FIRST, CastingTime.ONE_ACTION, 15, VS,
                    INSTANTANEOUS, 15, 20, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        Dice dice = DiceSlotScaling(FIRST, slot, D8);
                        foreach (Combatant target in targets) {
                            GlobalEvents.AffectBySpell(caster, ID.THUNDERWAVE, target, true);
                            target.TakeDamage(new DamageSource(ID.THUNDERWAVE, caster), THUNDER, dice, HALVES_DAMAGE, dc, CONSTITUTION, out bool dcResult);
                            if (!dcResult) {
                                ground.Push(ground.LocateCombatant(caster), target, 10);
                            }
                        }
                    }
                );
            }
        }

        /*
        This spell creates an invisible, mindless, shapeless force that performs simple
        tasks at your command until the spell ends. The servant springs into existence in
        an unoccupied space on the ground within range. It has AC 10, 1 hit point, and a
        Strength of 2, and it can't attack. If it drops to 0 hit points, the spell ends.
        Once on each of your turns as a bonus action, you can mentally command the servant
        to move up to 15 feet and interact with an object. The servant can perform simple
        tasks that a human servant could do, such as fetching things, cleaning, mending,
        folding clothes, lighting fires, serving food, and pouring wine. Once you give the
        command, the servant performs the task to the best of its ability until it
        completes the task, then waits for your next command.
        If you command the servant to perform a task that would move it more than 60 feet
        away from you, the spell ends.
         */
        public static Spell UnseenServant {
            get {
                return new Spell(ID.UNSEEN_SERVANT, CONJURATION, FIRST, CastingTime.ONE_ACTION, 60, VSM, ONE_HOUR, 0, 0, SpellWithoutEffect(ID.UNSEEN_SERVANT));
            }
        }
    }
}
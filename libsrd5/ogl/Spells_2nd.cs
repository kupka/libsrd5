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

        /*
        A shimmering green arrow streaks toward a target within range and bursts in a
        spray of acid. Make a ranged spell attack against the target. On a hit, the target
        takes 4d4 acid damage immediately and 2d4 acid damage at the end of its next turn.
        On a miss, the arrow splashes the target with acid for half as much of the initial
        damage and no damage at the end of its next turn.
        When you cast this spell using a spell slot of 3rd level or higher, the damage
        (both initial and later) increases by 1d4 for each slot level above 2nd.
         */
        public static Spell AcidArrow {
            get {
                return new Spell(ID.ACID_ARROW, EVOCATION, SECOND, CastingTime.ONE_ACTION, 90, VSM, INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    Dice dice = DiceSlotScaling(SECOND, slot, D4, 4, 0, 1);
                    Dice additionalDice = DiceSlotScaling(SECOND, slot, D4, 2, 0, 1);
                    bool hit = SpellAttack(ID.ACID_ARROW, ground, caster, ACID, dice, 0, target, 90, HALVES_DAMAGE);
                    if (hit) {
                        target.AddEndOfTurnEvent(delegate () {
                            target.TakeDamage(new DamageSource(SPELL_ACID_ARRORW_BURN, caster), ACID, additionalDice);
                            return true;
                        });
                    }
                });
            }
        }

        /*
        Your spell bolsters your allies with toughness and resolve. Choose up to three
        creatures within range. Each target's hit point maximum and current hit points
        increase by 5 for the duration.
        When you cast this spell using a spell slot of 3rd level or higher, a target's hit
        points increase by an additional 5 for each slot level above 2nd.
         */
        public static Spell Aid {
            get {
                return new Spell(ID.AID, ABJURATION, SECOND, CastingTime.ONE_ACTION, 30, VSM, EIGHT_HOURS, 0, 3, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    int amount = 5 * ((int)slot - 1);
                    foreach (Combatant target in targets) {
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

        /*
        You assume a different form. When you cast the spell, choose one of the following
        options, the effects of which last for the duration of the spell. While the spell
        lasts, you can end one option as an action to gain the benefits of a different
        one.
        ***Aquatic Adaptation.*** You adapt your body to an aquatic environment, sprouting
        gills and growing webbing between your fingers. You can breathe underwater and
        gain a swimming speed equal to your walking speed.
        ***Change Appearance.*** You transform your appearance. You decide what you look
        like, including your height, weight, facial features, sound of your voice, hair
        length, coloration, and distinguishing characteristics, if any. You can make
        yourself appear as a member of another race, though none of your statistics
        change. You also can't appear as a creature of a different size than you, and your
        basic shape stays the same; if you're bipedal, you can't use this spell to become
        quadrupedal, for instance. At any time for the duration of the spell, you can use
        your action to change your appearance in this way again.
        ***Natural Weapons.*** You grow claws, fangs, spines, horns, or a different
        natural weapon of your choice. Your unarmed strikes deal 1d6 bludgeoning,
        piercing, or slashing damage, as appropriate to the natural weapon you chose, and
        you are proficient with your unarmed strikes. Finally, the natural weapon is magic
        and you have a +1 bonus to the attack and damage rolls you make using it.
         */
        public static Spell AlterSelf {
            get {
                return new Spell(ID.ALTER_SELF, TRANSMUTATION, SECOND, CastingTime.ONE_ACTION, 0, VS, ONE_HOUR, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // TODO: Aquatic Adaption and Change Appearance require work elsewhere
                    // We cannot chose the type of weapons so let's grow Claws
                    caster.AddEffect(SPELL_ALTER_SELF_CLAWS);
                    GlobalEvents.AffectBySpell(caster, ID.ALTER_SELF, caster, true);
                });
            }
        }

        /*
        By means of this spell, you use an animal to deliver a message. Choose a Tiny
        beast you can see within range, such as a squirrel, a blue jay, or a bat. You
        specify a location, which you must have visited, and a recipient who matches a
        general description, such as "a man or woman dressed in the uniform of the town
        guard" or "a red-haired dwarf wearing a pointed hat." You also speak a message of
        up to twenty-five words. The target beast travels for the duration of the spell
        toward the specified location, covering about 50 miles per 24 hours for a flying
        messenger, or 25 miles for other animals.
        When the messenger arrives, it delivers your message to the creature that you
        described, replicating the sound of your voice. The messenger speaks only to a
        creature matching the description you gave. If the messenger doesn't reach its
        destination before the spell ends, the message is lost, and the beast makes its
        way back to where you cast this spell.
        If you cast this spell using a spell slot of 3nd level or higher, the duration of
        the spell increases by 48 hours for each slot level above 2nd.
         */
        public static Spell AnimalMessenger {
            get {
                return new Spell(ID.ANIMAL_MESSENGER, ENCHANTMENT, SECOND, CastingTime.ONE_ACTION, 30, VSM, ONE_DAY, 0, 0, SpellWithoutEffect(ID.ANIMAL_MESSENGER));
            }
        }

        /*
        You touch a closed door, window, gate, chest, or other entryway, and it becomes
        locked for the duration. You and the creatures you designate when you cast this
        spell can open the object normally. You can also set a password that, when spoken
        within 5 feet of the object, suppresses this spell for 1 minute. Otherwise, it is
        impassable until it is broken or the spell is dispelled or suppressed. Casting
        knock on the object suppresses arcane lock for 10 minutes.
        While affected by this spell, the object is more difficult to break or force open;
        the DC to break it or pick any locks on it increases by 10.
         */
        public static Spell ArcaneLock {
            get {
                return new Spell(ID.ARCANE_LOCK, ABJURATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, UNTIL_DISPELLED, 0, 0, SpellWithoutEffect(ID.ARCANE_LOCK));
            }
        }

        /*
        You place an illusion on a creature or an object you touch so that divination
        spells reveal false information about it. The target can be a willing creature or
        an object that isn't being carried or worn by another creature.
        When you cast the spell, choose one or both of the following effects. The effect
        lasts for the duration. If you cast this spell on the same creature or object
        every day for 30 days, placing the same effect on it each time, the illusion lasts
        until it is dispelled.
        ***False Aura.*** You change the way the target appears to spells and magical
        effects, such as detect magic, that detect magical auras. You can make a
        nonmagical object appear magical, a magical object appear nonmagical, or change
        the object's magical aura so that it appears to belong to a specific school of
        magic that you choose. When you use this effect on an object, you can make the
        false magic apparent to any creature that handles the item.
        ***Mask.*** You change the way the target appears to spells and magical effects
        that detect creature types, such as a paladin's Divine Sense or the trigger of a
        symbol spell. You choose a creature type and other spells and magical effects
        treat the target as if it were a creature of that type or of that alignment.
         */
        public static Spell ArcanistsMagicAura {
            get {
                return new Spell(ID.ARCANISTS_MAGIC_AURA, ILLUSION, SECOND, CastingTime.ONE_ACTION, 0, VSM, ONE_DAY, 0, 0, SpellWithoutEffect(ID.ARCANISTS_MAGIC_AURA));
            }
        }

        /*
        By casting gem-inlaid sticks, rolling dragon bones, laying out ornate cards, or
        employing some other divining tool, you receive an omen from an otherworldly
        entity about the results of a specific course of action that you plan to take
        within the next 30 minutes. The DM chooses from the following possible omens:
        - Weal, for good results
        - Woe, for bad results
        - Weal and woe, for both good and bad results
        - Nothing, for results that aren't especially good or bad
        The spell doesn't take into account any possible circumstances that might change
        the outcome, such as the casting of additional spells or the loss or gain of a
        companion.
        If you cast the spell two or more times before completing your next long rest,
        there is a cumulative 25 percent chance for each casting after the first that you
        get a random reading. The DM makes this roll in secret.
         */
        public static Spell Augury {
            get {
                return new Spell(ID.AUGURY, DIVINATION, SECOND, CastingTime.ONE_MINUTE, 0, VSM, INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.AUGURY));
            }
        }

        /*
        You touch a willing creature. Until the spell ends, the target's skin has a rough,
        bark-like appearance, and the target's AC can't be less than 16, regardless of
        what kind of armor it is wearing.
         */
        public static Spell Barkskin {
            get {
                return new Spell(ID.BARKSKIN, TRANSMUTATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    target.AddEffect(SPELL_BARKSKIN);
                    GlobalEvents.AffectBySpell(caster, ID.BARKSKIN, target, true);
                });
            }
        }

        /*
        You can blind or deafen a foe. Choose one creature that you can see within range
        to make a constitution saving throw. If it fails, the target is either blinded or
        deafened (your choice) for the duration. At the end of each of its turns, the
        target can make a constitution saving throw. On a success, the spell ends.
        When you cast this spell using a spell slot of 3rd level or higher, you can target
        one additional creature for each slot level above 2nd.
         */
        public static Spell BlindnessDeafness {
            get {
                return new Spell(ID.BLINDNESS_DEAFNESS, NECROMANCY, SECOND, CastingTime.ONE_ACTION, 30, V, ONE_MINUTE, 0, 6, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // SRD5 says target is either blinded or deafened, but we do both
                    // otherwise we would need to split this into two spells
                    int maxTargets = (int)slot - 1;
                    for (int i = 0; i < maxTargets && i < targets.Length; i++) {
                        Combatant target = targets[i];
                        if (target.DC(ID.BLINDNESS_DEAFNESS, dc, CONSTITUTION)) {
                            GlobalEvents.AffectBySpell(caster, ID.BLINDNESS_DEAFNESS, target, false);
                        } else {
                            AddEffectAndConditionsForDuration(ID.BLINDNESS_DEAFNESS, caster, target, ONE_MINUTE, SPELL_BLINDNESS_DEAFNESS, ConditionType.BLINDED, ConditionType.DEAFENED);
                        }
                    }
                });
            }
        }

        /*
        Your body becomes blurred, shifting and wavering to all who can see you. For the
        duration, any creature has disadvantage on attack rolls against you. An attacker
        is immune to this effect if it doesn't rely on sight, as with blindsight, or can
        see through illusions, as with truesight.
         */
        public static Spell Blur {
            get {
                return new Spell(ID.BLUR, ILLUSION, SECOND, CastingTime.ONE_ACTION, 0, V, ONE_MINUTE, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    AddEffectsForDuration(ID.BLUR, caster, caster, ONE_MINUTE, SPELL_BLUR);
                });
            }
        }

        /*
        The next time you hit a creature with a weapon attack before this spell ends, the
        weapon gleams with astral radiance as you strike. The attack deals an extra 2d6
        radiant damage to the target, which becomes visible if it's invisible, and the
        target sheds dim light in a 5-foot radius and can't become invisible until the
        spell ends.
        When you cast this spell using a spell slot of 3rd level or higher, the extra
        damage increases by 1d6 for each slot level above 2nd.
         */
        public static Spell BrandingSmite {
            get {
                return new Spell(ID.BRANDING_SMITE, EVOCATION, SECOND, CastingTime.BONUS_ACTION, 0, V, ONE_MINUTE, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Dice dice = DiceSlotScaling(SECOND, slot, D6, 2);
                    Damage additionalDamage = new Damage(RADIANT, dice);
                    foreach (Attack attack in caster.MeleeAttacks) {
                        attack.AddAdditionalDamage(additionalDamage);
                        attack.AddAttackEffect(delegate (Combatant attacker, Combatant target) {
                            foreach (Attack meleeAttack in caster.MeleeAttacks) {
                                meleeAttack.RemoveAdditionalDamage(additionalDamage);
                            }
                            return true;
                        });
                    }
                });
            }
        }

        /*
        You attempt to suppress strong emotions in a group of people. Each humanoid in a
        20-foot-radius sphere centered on a point you choose within range must make a
        charisma saving throw; a creature can choose to fail this saving throw if it
        wishes. If a creature fails its saving throw, choose one of the following two
        effects. You can suppress any effect causing a target to be charmed or frightened.
        When this spell ends, any suppressed effect resumes, provided that its duration
        has not expired in the meantime.
        Alternatively, you can make a target indifferent about creatures of your choice
        that it is hostile toward. This indifference ends if the target is attacked or
        harmed by a spell or if it witnesses any of its friends being harmed. When the
        spell ends, the creature becomes hostile again, unless the DM rules otherwise.
         */
        public static Spell CalmEmotions {
            get {
                return new Spell(ID.CALM_EMOTIONS, ENCHANTMENT, SECOND, CastingTime.ONE_ACTION, 60, VS, ONE_MINUTE, 20, 10, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // TODO: Here, only the immunity to being charmed and frightned is implemented
                    // Alternatively, you can make a target indifferent about creatures of your choice that it is hostile toward. 
                    // This indifference ends if the target is attacked or harmed by a spell or if it witnesses any of its friends being harmed. 
                    // When the spell ends, the creature becomes hostile again, unless the GM rules otherwise.
                    foreach (Combatant target in targets) {
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

        /*
        A flame, equivalent in brightness to a torch, springs forth from an object that
        you touch. The effect looks like a regular flame, but it creates no heat and
        doesn't use oxygen. A continual flame can be covered or hidden but not smothered
        or quenched.
         */
        public static Spell ContinualFlame {
            get {
                return new Spell(ID.CONTINUAL_FLAME, EVOCATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, UNTIL_DISPELLED, 0, 0, SpellWithoutEffect(ID.CONTINUAL_FLAME));
            }
        }

        /*
        Magical darkness spreads from a point you choose within range to fill a
        15-foot-radius sphere for the duration. The darkness spreads around corners. A
        creature with darkvision can't see through this darkness, and nonmagical light
        can't illuminate it.
        If the point you choose is on an object you are holding or one that isn't being
        worn or carried, the darkness emanates from the object and moves with it.
        Completely covering the source of the darkness with an opaque object, such as a
        bowl or a helm, blocks the darkness.
        If any of this spell's area overlaps with an area of light created by a spell of
        2nd level or lower, the spell that created the light is dispelled.
         */
        public static Spell Darkness {
            get {
                return new Spell(ID.DARKNESS, EVOCATION, SECOND, CastingTime.ONE_ACTION, 60, VM, TEN_MINUTES, 15, 0, SpellWithoutEffect(ID.DARKNESS));
            }
        }

        /*
        You touch a willing creature to grant it the ability to see in the dark. For the
        duration, that creature has darkvision out to a range of 60 feet.
         */
        public static Spell Darkvision {
            get {
                return new Spell(ID.DARKVISION, TRANSMUTATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, EIGHT_HOURS, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    AddEffectsForDuration(ID.DARKVISION, caster, target, EIGHT_HOURS, SPELL_DARKVISION);
                });
            }
        }

        /*
        For the duration, you can read the thoughts of certain creatures. When you cast
        the spell and as your action on each turn until the spell ends, you can focus your
        mind on any one creature that you can see within 30 feet of you. If the creature
        you choose has an Intelligence of 3 or lower or doesn't speak any language, the
        creature is unaffected.
        You initially learn the surface thoughts of the creature - what is most on its
        mind in that moment. As an action, you can either shift your attention to another
        creature's thoughts or attempt to probe deeper into the same creature's mind. If
        you probe deeper, the target must make a Wisdom saving throw. If it fails, you
        gain insight into its reasoning (if any), its emotional state, and something that
        looms large in its mind (such as something it worries over, loves, or hates). If
        it succeeds, the spell ends. Either way, the target knows that you are probing
        into its mind, and unless you shift your attention to another creature's thoughts,
        the creature can use its action on its turn to make an Intelligence check
        contested by your Intelligence check; if it succeeds, the spell ends.
        Questions verbally directed at the target creature naturally shape the course of
        its thoughts, so this spell is particularly effective as part of an interrogation.
        You can also use this spell to detect the presence of thinking creatures you can't
        see. When you cast the spell or as your action during the duration, you can search
        for thoughts within 30 feet of you. The spell can penetrate barriers, but 2 feet
        of rock, 2 inches of any metal other than lead, or a thin sheet of lead blocks
        you. You can't detect a creature with an Intelligence of 3 or lower or one that
        doesn't speak any language.
        Once you detect the presence of a creature in this way, you can read its thoughts
        for the rest of the duration as described above, even if you can't see it, but it
        must still be within range.
         */
        public static Spell DetectThoughts {
            get {
                return new Spell(ID.DETECT_THOUGHTS, DIVINATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, ONE_MINUTE, 0, 0, SpellWithoutEffect(ID.DETECT_THOUGHTS));
            }
        }

        /* TODO:
        You touch a creature and bestow upon it a magical enhancement. Choose one of the
        following effects; the target gains that effect until the spell ends.
        ***Bear's Endurance.*** The target has advantage on constitution checks. It also
        gains 2d6 temporary hit points, which are lost when the spell ends.
        ***Bull's Strength.*** The target has advantage on strength checks, and his or her
        carrying capacity doubles.
        ***Cat's Grace.*** The target has advantage on dexterity checks. It also doesn't
        take damage from falling 20 feet or less if it isn't incapacitated.
        ***Eagle's Splendor.*** The target has advantage on Charisma checks.
        ***Fox's Cunning.*** The target has advantage on intelligence checks.
        ***Owl's Wisdom.*** The target has advantage on wisdom checks.
        When you cast this spell using a spell slot of 3rd level or higher, you can target
        one additional creature for each slot level above 2nd.
         */
        public static Spell EnhanceAbility {
            get {
                Spell spell = new Spell(ID.ENHANCE_ABILITY, TRANSMUTATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 7);
                spell.Variants = new SpellVariant[] { BEARS_ENDURANCE, BULLS_STRENGTH, CATS_GRACE, EAGLES_SPLENDOR, FOX_CUNNING, OWLS_WISDOM };
                spell.Variant = BEARS_ENDURANCE;
                spell.CastEffect = delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    int maxTargets = (int)slot - 1;
                    for (int i = 0; i < maxTargets && i < targets.Length; i++) {
                        Combatant target = targets[i];
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

        /* TODO:
        You cause a creature or an object you can see within range to grow larger or
        smaller for the duration. Choose either a creature or an object that is neither
        worn nor carried. If the target is unwilling, it can make a Constitution saving
        throw. On a success, the spell has no effect.
        If the target is a creature, everything it is wearing and carrying changes size
        with it. Any item dropped by an affected creature returns to normal size at once.
        ***Enlarge.*** The target's size doubles in all dimensions, and its weight is
        multiplied by eight. This growth increases its size by one category-from Medium to
        Large, for example. If there isn't enough room for the target to double its size,
        the creature or object attains the maximum possible size in the space available.
        Until the spell ends, the target also has advantage on Strength checks and
        Strength saving throws. The target's weapons also grow to match its new size.
        While these weapons are enlarged, the target's attacks with them deal 1d4 extra
        damage.
        ***Reduce.*** The target's size is halved in all dimensions, and its weight is
        reduced to one-eighth of normal. This reduction decreases its size by one
        category-from Medium to Small, for example. Until the spell ends, the target also
        has disadvantage on Strength checks and Strength saving throws. The target's
        weapons also shrink to match its new size. While these weapons are reduced, the
        target's attacks with them deal 1d4 less damage (this can't reduce the damage
        below 1).
         */
        public static Spell EnlargeReduce {
            get {
                Spell spell = new Spell(ID.ENLARGE_REDUCE, TRANSMUTATION, SECOND, CastingTime.ONE_ACTION, 30, VSM, ONE_MINUTE, 0, 1);
                spell.Variants = new SpellVariant[] { ENLARGE, REDUCE };
                spell.Variant = ENLARGE;
                spell.CastEffect = delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    switch (spell.Variant) {
                        case ENLARGE:
                            if (target.HasEffect(SPELL_ENLARGE)) {
                                GlobalEvents.AffectBySpell(caster, ID.ENLARGE_REDUCE, target, false);
                            } else if (target.HasEffect(SPELL_REDUCE)) {
                                GlobalEvents.AffectBySpell(caster, ID.ENLARGE_REDUCE, target, true);
                                target.RemoveEffect(SPELL_REDUCE, Effect.DISADVANTAGE_STRENGTH_SAVES);
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
                                AddEffectsForDuration(ID.ENHANCE_ABILITY, caster, target, spell.Duration, SPELL_REDUCE, Effect.DISADVANTAGE_STRENGTH_SAVES);
                            }
                            break;
                    }
                };
                return spell;
            }
        }

        /*
        You weave a distracting string of words, causing creatures of your choice that you
        can see within range and that can hear you to make a wisdom saving throw. Any
        creature that can't be charmed succeeds on this saving throw automatically, and if
        you or your companions are fighting a creature, it has advantage on the save. On a
        failed save, the target has disadvantage on Wisdom (Perception) checks made to
        perceive any creature other than you until the spell ends or until the target can
        no longer hear you. The spell ends if you are incapacitated or can no longer
        speak.
         */
        public static Spell Enthrall {
            get {
                // TODO: Probably when perception checks are implemented, we can make use of Enthrall
                return new Spell(ID.ENTHRALL, ENCHANTMENT, SECOND, CastingTime.ONE_ACTION, 60, VS, ONE_MINUTE, 0, 0, SpellWithoutEffect(ID.ENTHRALL));
            }
        }

        /*
        You summon a spirit that assumes the form of an unusually intelligent, strong, and
        loyal steed, creating a long-lasting bond with it. Appearing in an unoccupied
        space within range, the steed takes on a form that you choose, such as a warhorse,
        a pony, a camel, an elk, or a mastiff. (Your DM might allow other animals to be
        summoned as steeds.) The steed has the statistics of the chosen form, though it is
        a celestial, fey, or fiend (your choice) instead of its normal type. Additionally,
        if your steed has an Intelligence of 5 or less, its Intelligence becomes 6, and it
        gains the ability to understand one language of your choice that you speak.
        Your steed serves you as a mount, both in combat and out, and you have an
        instinctive bond with it that allows you to fight as a seamless unit. While
        mounted on your steed, you can make any spell you cast that targets only you also
        target your steed.
        When the steed drops to 0 hit points, it disappears, leaving behind no physical
        form. You can also dismiss your steed at any time as an action, causing it to
        disappear. In either case, casting this spell again summons the same steed,
        restored to its hit point maximum.
        While your steed is within 1 mile of you, you can communicate with it
        telepathically.
        You can't have more than one steed bonded by this spell at a time. As an action,
        you can release the steed from its bond at any time, causing it to disappear.
         */
        public static Spell FindSteed {
            get {
                // TODO: Should be implemeted once/if mounts are implemented
                return new Spell(ID.FIND_STEED, CONJURATION, SECOND, CastingTime.TEN_MINUTES, 30, VS, INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.FIND_STEED));
            }
        }

        /*
        You sense the presence of any trap within range that is within line of sight. A
        trap, for the purpose of this spell, includes anything that would inflict a sudden
        or unexpected effect you consider harmful or undesirable, which was specifically
        intended as such by its creator. Thus, the spell would sense an area affected by
        the alarm spell, a glyph of warding, or a mechanical pit trap, but it would not
        reveal a natural weakness in the floor, an unstable ceiling, or a hidden sinkhole.
        This spell merely reveals that a trap is present. You don't learn the location of
        each trap, but you do learn the general nature of the danger posed by a trap you
        sense.
         */
        public static Spell FindTraps {
            get {
                // TODO: Should be implemented once/if traps are implemented
                return new Spell(ID.FIND_TRAPS, DIVINATION, SECOND, CastingTime.ONE_ACTION, 120, VS, INSTANTANEOUS, 0, 0, doNothing);
            }
        }

        /*
        You evoke a fiery blade in your free hand. The blade is similar in size and shape
        to a scimitar, and it lasts for the duration. If you let go of the blade, it
        disappears, but you can evoke the blade again as a bonus action.
        You can use your action to make a melee spell attack with the fiery blade. On a
        hit, the target takes 3d6 fire damage.
        The flaming blade sheds bright light in a 10-foot radius and dim light for an
        additional 10 feet.
        When you cast this spell using a spell slot of 4th level or higher, the damage
        increases by 1d6 for every two slot levels above 2nd.
         */
        public static Spell FlameBlade {
            get {
                return new Spell(ID.FLAME_BLADE, EVOCATION, SECOND, CastingTime.BONUS_ACTION, 0, VSM, TEN_MINUTES, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // This is modelled by creating a Cantrip that the druid can use. After the Duration, the cantrip is removed
                    int dice = 3 + ((int)slot - 2) / 2;
                    Damage damage = new Damage(FIRE, new Dice(dice, D6));
                    // TODO: This cantrip workaround should be replaced by correctly implementing situative actions
                    Spell flamingBladeCantrip = new Spell(ID.FLAME_BLADE_ATTACK, EVOCATION, CANTRIP, CastingTime.ONE_ACTION, 5, V, INSTANTANEOUS, 0, 1, delegate (Battleground ground2, Combatant caster2, int dc2, SpellLevel slot2, int modifier2, Combatant[] targets2) {
                        SpellAttack(ID.FLAME_BLADE_ATTACK, ground2, caster2, damage.Type, damage.Dice, modifier2, targets2[0], 5);
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

        /*
        A 5-foot-diameter sphere of fire appears in an unoccupied space of your choice
        within range and lasts for the duration. Any creature that ends its turn within 5
        feet of the sphere must make a dexterity saving throw. The creature takes 2d6 fire
        damage on a failed save, or half as much damage on a successful one.
        As a bonus action, you can move the sphere up to 30 feet. If you ram the sphere
        into a creature, that creature must make the saving throw against the sphere's
        damage, and the sphere stops moving this turn.
        When you move the sphere, you can direct it over barriers up to 5 feet tall and
        jump it across pits up to 10 feet wide. The sphere ignites flammable objects not
        being worn or carried, and it sheds bright light in a 20-foot radius and dim light
        for an additional 20 feet.
        When you cast this spell using a spell slot of 3rd level or higher, the damage
        increases by 1d6 for each slot level above 2nd.
         */
        public static Spell FlamingSphere {
            get {
                // "As a bonus action, you can move the sphere up to 30 feet. If you ram the sphere into a creature, 
                // that creature must make the saving throw against the sphere's damage, and the sphere stops moving this turn."
                //
                // Note: Since we cannot currently place objects on a Battlefield and move them around, 
                // the current implementation sort of implies that the sphere is following the caster and can
                // be sent on a target within 30 feet as a bonus action
                return new Spell(ID.FLAMING_SPHERE, CONJURATION, SECOND, CastingTime.ONE_ACTION, 60, VSM, ONE_MINUTE, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // This is modelled by creating a Cantrip that the caster can use. After the Duration, the cantrip is removed
                    Dice dice = DiceSlotScaling(SECOND, slot, D6, 2);
                    Damage damage = new Damage(FIRE, dice);
                    // TODO: This cantrip workaround should be replaced by correctly implementing situative actions
                    Spell flamingSphereCantrip = new Spell(ID.FLAMING_SPHERE_ATTACK, CONJURATION, CANTRIP, CastingTime.BONUS_ACTION, 30, V, INSTANTANEOUS, 0, 1, delegate (Battleground ground2, Combatant caster2, int dc2, SpellLevel slot2, int modifier2, Combatant[] targets2) {
                        Combatant target2 = targets2[0];
                        GlobalEvents.AffectBySpell(caster2, ID.FLAMING_SPHERE_ATTACK, target2, true);
                        target2.TakeDamage(new DamageSource(ID.FLAMING_SPHERE_ATTACK, caster), FIRE, dice, HALVES_DAMAGE, dc2, DEXTERITY, out _);
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

        /*
        You touch a corpse or other remains. For the duration, the target is protected
        from decay and can't become undead.
        The spell also effectively extends the time limit on raising the target from the
        dead, since days spent under the influence of this spell don't count against the
        time limit of spells such as raise dead.
         */
        public static Spell GentleRepose {
            get {
                return new Spell(ID.GENTLE_REPOSE, NECROMANCY, SECOND, CastingTime.ONE_ACTION, 0, VSM, TEN_DAYS, 0, 0, SpellWithoutEffect(ID.GENTLE_REPOSE));
            }
        }

        /* TODO:
        A line of strong wind 60 feet long and 10 feet wide blasts from you in a direction
        you choose for the spell's duration. Each creature that starts its turn in the
        line must succeed on a strength saving throw or be pushed 15 feet away from you in
        a direction following the line.
        Any creature in the line must spend 2 feet of movement for every 1 foot it moves
        when moving closer to you.
        The gust disperses gas or vapor, and it extinguishes candles, torches, and similar
        unprotected flames in the area. It causes protected flames, such as those of
        lanterns, to dance wildly and has a 50 percent chance to extinguish them.
        As a bonus action on each of your turns before the spell ends, you can change the
        direction in which the line blasts from you.
         */
        public static Spell GustofWind {
            get {
                return new Spell(ID.GUST_OF_WIND, EVOCATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, ONE_MINUTE, 60, 5, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // Fix the location where the spell was cast to create the push-vector
                    Location location = ground.LocateCombatant(caster);
                    foreach (Combatant target in targets) {
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

        /*
        Choose a manufactured metal object, such as a metal weapon or a suit of heavy or
        medium metal armor, that you can see within range. You cause the object to glow
        red-hot. Any creature in physical contact with the object takes 2d8 fire damage
        when you cast the spell. Until the spell ends, you can use a bonus action on each
        of your subsequent turns to cause this damage again.
        If a creature is holding or wearing the object and takes the damage from it, the
        creature must succeed on a constitution saving throw or drop the object if it can.
        If it doesn't drop the object, it has disadvantage on attack rolls and ability
        checks until the start of your next turn.
        When you cast this spell using a spell slot of 3rd level or higher, the damage
        increases by 1d8 for each slot level above 2nd.
         */
        public static Spell HeatMetal {
            get {
                // TODO: In order to support this, we would need to give Monsters weapons and armors
                return new Spell(ID.HEAT_METAL, TRANSMUTATION, SECOND, CastingTime.ONE_ACTION, 60, VSM, ONE_MINUTE, 0, 0, SpellWithoutEffect(ID.HEAT_METAL));
            }
        }

        /*
        Choose a humanoid that you can see within range. The target must succeed on a
        wisdom saving throw or be paralyzed for the duration. At the end of each of its
        turns, the target can make another wisdom saving throw. On a success, the spell
        ends on the target.
        When you cast this spell using a spell slot of 3rd level or higher, you can target
        one additional humanoid for each slot level above 2nd. The humanoids must be
        within 30 feet of each other when you target them.
         */
        public static Spell HoldPerson {
            get {
                return new Spell(
                           ID.HOLD_PERSON, ENCHANTMENT, SECOND, CastingTime.ONE_ACTION, 60, VSM,
                           ONE_MINUTE, 0, 20, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                               // one target per slot above 2nd
                               for (int i = 0; i < (int)slot - 1 && i < targets.Length; i++) {
                                   Combatant target = targets[i];
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

        /*
        A creature you touch becomes invisible until the spell ends. Anything the target
        is wearing or carrying is invisible as long as it is on the target's person. The
        spell ends for a target that attacks or casts a spell.
        When you cast this spell using a spell slot of 3rd level or higher, you can target
        one additional creature for each slot level above 2nd.
         */
        public static Spell Invisibility {
            get {
                return new Spell(ID.INVISIBILITY, ILLUSION, SECOND, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    AddEffectsForDuration(ID.INVISIBILITY, caster, target, ONE_HOUR, SPELL_INVISIBILITY);
                    EventHandler<GlobalEvents.AttackRolled> attackHandler = delegate (object sender, GlobalEvents.AttackRolled attack) {
                        if (attack.Attacker.Equals(target)) {
                            target.RemoveEffect(SPELL_INVISIBILITY);
                        }
                    };
                    EventHandler<GlobalEvents.SpellCast> castHandler = delegate (object sender, GlobalEvents.SpellCast cast) {
                        if (cast.Caster.Equals(target)) {
                            target.RemoveEffect(SPELL_INVISIBILITY);
                        }
                    };
                    GlobalEvents.AttackRolledHandlers += attackHandler;
                    GlobalEvents.SpellCastHandlers += castHandler;
                    target.AddEndOfTurnEvent(delegate () {
                        if (!target.HasEffect(SPELL_INVISIBILITY)) {
                            GlobalEvents.AttackRolledHandlers -= attackHandler;
                            GlobalEvents.SpellCastHandlers -= castHandler;
                            return true;
                        }
                        return false;
                    });
                });
            }
        }

        /*
        Choose an object that you can see within range. The object can be a door, a box, a
        chest, a set of manacles, a padlock, or another object that contains a mundane or
        magical means that prevents access.
        A target that is held shut by a mundane lock or that is stuck or barred becomes
        unlocked, unstuck, or unbarred. If the object has multiple locks, only one of them
        is unlocked.
        If you choose a target that is held shut with arcane lock, that spell is
        suppressed for 10 minutes, during which time the target can be opened and shut
        normally.
        When you cast the spell, a loud knock, audible from as far away as 300 feet,
        emanates from the target object.
         */
        public static Spell Knock {
            get {
                // TODO: Should be implemented once locked items are available
                return new Spell(ID.KNOCK, TRANSMUTATION, SECOND, CastingTime.ONE_ACTION, 60, V, INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.KNOCK));
            }
        }

        /*
        You touch a creature and can end either one disease or one condition afflicting
        it. The condition can be blinded, deafened, paralyzed, or poisoned.
         */
        public static Spell LesserRestoration {
            get {
                Spell spell = new Spell(ID.LESSER_RESTORATION, ABJURATION, SECOND, CastingTime.ONE_ACTION, 0, VS, INSTANTANEOUS, 0, 1);
                spell.Variants = new SpellVariant[] { BLINDNESS, DEAFNESS, PARALYZATION, POISONS, DISEASES };
                spell.Variant = BLINDNESS;
                spell.CastEffect = delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
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

        /*
        One creature or object of your choice that you can see within range rises
        vertically, up to 20 feet, and remains suspended there for the duration. The spell
        can levitate a target that weighs up to 500 pounds. An unwilling creature that
        succeeds on a constitution saving throw is unaffected.
        The target can move only by pushing or pulling against a fixed object or surface
        within reach (such as a wall or a ceiling), which allows it to move as if it were
        climbing. You can change the target's altitude by up to 20 feet in either
        direction on your turn. If you are the target, you can move up or down as part of
        your move. Otherwise, you can use your action to move the target, which must
        remain within the spell's range.
        When the spell ends, the target floats gently to the ground if it is still aloft.
         */
        public static Spell Levitate {
            get {
                // We assume that this spell is used for Crowd Control to make a target incapable of melee attacks but also immune to melee attacks
                // Ranged attacks should work normally. The Weight limit of 500 pounds is translated to a maximum size of Large
                return new Spell(ID.LEVITATE, TRANSMUTATION, SECOND, CastingTime.ONE_ACTION, 60, VSM, TEN_MINUTES, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    if (target.Size > Size.LARGE || target.DC(ID.LEVITATE, dc, CONSTITUTION)) {
                        GlobalEvents.AffectBySpell(caster, ID.LEVITATE, target, false);
                        return;
                    }
                    AddEffectsForDuration(ID.LEVITATE, caster, target, TEN_MINUTES, SPELL_LEVITATE, CANNOT_BE_MELEE_ATTACKED, CANNOT_MELEE_ATTACK);
                });
            }
        }

        /*
        Describe or name a specific kind of beast or plant. Concentrating on the voice of
        nature in your surroundings, you learn the direction and distance to the closest
        creature or plant of that kind within 5 miles, if any are present.
         */
        public static Spell LocateAnimalsOrPlants {
            get {
                return new Spell(ID.LOCATE_ANIMALS_OR_PLANTS, DIVINATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.LOCATE_ANIMALS_OR_PLANTS));
            }
        }

        /*
        Describe or name an object that is familiar to you. You sense the direction to the
        object's location, as long as that object is within 1,000 feet of you. If the
        object is in motion, you know the direction of its movement.
        The spell can locate a specific object known to you, as long as you have seen it
        up close--within 30 feet--at least once. Alternatively, the spell can locate the
        nearest object of a particular kind, such as a certain kind of apparel, jewelry,
        furniture, tool, or weapon.
        This spell can't locate an object if any thickness of lead, even a thin sheet,
        blocks a direct path between you and the object.
         */
        public static Spell LocateObject {
            get {
                return new Spell(ID.LOCATE_OBJECT, DIVINATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, TEN_MINUTES, 0, 0, SpellWithoutEffect(ID.LOCATE_OBJECT));
            }
        }

        /*
        You plant a message to an object in the range of the spell. The message is
        verbalized when the trigger conditions are met. Choose an object that you see, and
        that is not worn or carried by another creature. Then say the message, which
        should not exceed 25 words but listening can take up to 10 minutes. Finally,
        establish the circumstances that trigger the spell to deliver your message.
        When these conditions are satisfied, a magical mouth appears on the object and it
        articulates the message imitating your voice, the same tone used during
        implantation of the message. If the selected object has a mouth or something that
        approaches such as the mouth of a statue, the magic mouth come alive at this
        point, giving the illusion that the words come from the mouth of the object.
        When you cast this spell, you may decide that the spell ends when the message is
        delivered or it can persist and repeat the message whenever circumstances occur.
        The triggering circumstance can be as general or as detailed as you like, though
        it must be based on visual or audible conditions that occur within 30 feet of the
        object. For example, you could instruct the mouth to speak when any creature moves
        within 30 feet of the object or when a silver bell rings within 30 feet of it.
         */
        public static Spell MagicMouth {
            get {
                return new Spell(ID.MAGIC_MOUTH, ILLUSION, SECOND, CastingTime.ONE_MINUTE, 30, VSM, UNTIL_DISPELLED, 0, 0, SpellWithoutEffect(ID.MAGIC_MOUTH));
            }
        }

        /*
        You touch a nonmagical weapon. Until the spell ends, that weapon becomes a magic
        weapon with a +1 bonus to attack rolls and damage rolls.
        When you cast this spell using a spell slot of 4th level or higher, the bonus
        increases to +2. When you use a spell slot of 6th level or higher, the bonus
        increases to +3.
         */
        public static Spell MagicWeapon {
            get {
                return new Spell(ID.MAGIC_WEAPON, TRANSMUTATION, SECOND, CastingTime.BONUS_ACTION, 0, VS, ONE_HOUR, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
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

        /* TODO:
        Three illusory duplicates of yourself appear in your space. Until the spell ends,
        the duplicates move with you and mimic your actions, shifting position so it's
        impossible to track which image is real. You can use your action to dismiss the
        illusory duplicates.
        Each time a creature targets you with an attack during the spell's duration, roll
        a d20 to determine whether the attack instead targets one of your duplicates.
        If you have three duplicates, you must roll a 6 or higher to change the attack's
        target to a duplicate. With two duplicates, you must roll an 8 or higher. With one
        duplicate, you must roll an 11 or higher.
        A duplicate's AC equals 10 + your Dexterity modifier. If an attack hits a
        duplicate, the duplicate is destroyed. A duplicate can be destroyed only by an
        attack that hits it. It ignores all other damage and effects. The spell ends when
        all three duplicates are destroyed.
        A creature is unaffected by this spell if it can't see, if it relies on senses
        other than sight, such as blindsight, or if it can perceive illusions as false, as
        with truesight.
         */
        public static Spell MirrorImage {
            get {
                return new Spell(ID.MIRROR_IMAGE, ILLUSION, SECOND, CastingTime.ONE_ACTION, 0, VS, ONE_MINUTE, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
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

        /*
        Briefly surrounded by silvery mist, you teleport up to 30 feet to an unoccupied
        space that you can see.
         */
        public static Spell MistyStep {
            get {
                // TODO: At some point we want to allow teleporting on a battleground
                return new Spell(ID.MISTY_STEP, CONJURATION, SECOND, CastingTime.BONUS_ACTION, 0, V, INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.MISTY_STEP));
            }
        }

        /*
        A silvery beam of pale light shines down in a 5-foot radius, 40-foot-high cylinder
        centered on a point within range. Until the spell ends, dim light fills the
        cylinder.
        When a creature enters the spell's area for the first time on a turn or starts its
        turn there, it is engulfed in ghostly flames that cause searing pain, and it must
        make a constitution saving throw. It takes 2d10 radiant damage on a failed save,
        or half as much damage on a successful one.
        A shapechanger makes its saving throw with disadvantage. If it fails, it also
        instantly reverts to its original form and can't assume a different form until it
        leaves the spell's light.
        On each of your turns after you cast this spell, you can use an action to move the
        beam 60 feet in any direction.
        When you cast this spell using a spell slot of 3rd level or higher, the damage
        increases by 1dl0 for each slot level above 2nd.
         */
        public static Spell Moonbeam {
            get {
                // Similar to Flaming Sphere, we model this as a temporary Cantrip that can be cast to damage enemies with a range of 60ft
                return new Spell(ID.MOONBEAM, EVOCATION, SECOND, CastingTime.ONE_ACTION, 120, VSM, ONE_MINUTE, 5, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
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
                            target.TakeDamage(new DamageSource(ID.MOONBEAM, caster), RADIANT, dmg / 2);
                        } else {
                            target.TakeDamage(new DamageSource(ID.MOONBEAM, caster), RADIANT, dmg);
                        }
                    } else {
                        target.TakeDamage(new DamageSource(ID.MOONBEAM, caster), RADIANT, dice, HALVES_DAMAGE, dc, CONSTITUTION, out _);
                    }
                    // TODO: This cantrip workaround should be replaced by correctly implementing situative actions
                    Spell moonbeamCantrip = new Spell(ID.MOONBEAM_ATTACK, EVOCATION, CANTRIP, CastingTime.BONUS_ACTION, 60, V, INSTANTANEOUS, 0, 1, delegate (Battleground ground2, Combatant caster2, int dc2, SpellLevel slot2, int modifier2, Combatant[] targets2) {
                        Combatant target2 = targets2[0];
                        GlobalEvents.AffectBySpell(caster, ID.MOONBEAM_ATTACK, target2, true);
                        bool shapeChanger2 = false;
                        foreach (Feat feat in target2.Feats) {
                            if (feat.IsShapeChanger()) {
                                shapeChanger2 = true;
                            }
                        }
                        if (shapeChanger2) {
                            bool success = target2.DC(ID.MOONBEAM_ATTACK, dc2, CONSTITUTION, out _, false, true);
                            int dmg = dice.Roll();
                            if (success) {
                                target2.TakeDamage(new DamageSource(ID.MOONBEAM_ATTACK, caster), RADIANT, dmg / 2);
                            } else {
                                target2.TakeDamage(new DamageSource(ID.MOONBEAM_ATTACK, caster), RADIANT, dmg);
                            }
                        } else {
                            target2.TakeDamage(new DamageSource(ID.MOONBEAM_ATTACK, caster), RADIANT, dice, HALVES_DAMAGE, dc2, CONSTITUTION, out _);
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

        /*
        A veil of shadows and silence radiates from you, masking you and your companions
        from detection. For the duration, each creature you choose within 30 feet of you
        (including you) has a +10 bonus to Dexterity (Stealth) checks and can't be tracked
        except by magical means. A creature that receives this bonus leaves behind no
        tracks or other traces of its passage.
         */
        public static Spell PassWithoutTrace {
            get {
                return new Spell(ID.PASS_WITHOUT_TRACE, ABJURATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 10, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    foreach (Combatant target in targets) {
                        AddEffectsForDuration(ID.PASS_WITHOUT_TRACE, caster, target, ONE_HOUR, SPELL_PASS_WITHOUT_TRACE);
                    }
                });
            }
        }

        /*
        Up to six creatures of your choice that you can see within range each regain hit
        points equal to 2d8 + your spellcasting ability modifier. This spell has no effect
        on undead or constructs.
        When you cast this spell using a spell slot of 3rd level or higher, the healing
        increases by 1d8 for each slot level above 2nd.
         */
        public static Spell PrayerofHealing {
            get {
                return new Spell(ID.PRAYER_OF_HEALING, EVOCATION, SECOND, CastingTime.TEN_MINUTES, 30, V, INSTANTANEOUS, 0, 10, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Dice dice = DiceSlotScaling(SECOND, slot, D8, 2, modifier);
                    foreach (Combatant target in targets) {
                        if (target is Monster monster && (monster.Type == Monsters.Type.CONSTRUCT || monster.Type == Monsters.Type.UNDEAD)) {
                            GlobalEvents.AffectBySpell(caster, ID.PRAYER_OF_HEALING, target, false);
                        } else {
                            GlobalEvents.AffectBySpell(caster, ID.PRAYER_OF_HEALING, target, true);
                            target.HealDamage(dice);
                        }
                    }
                });
            }
        }

        /*
        You touch a creature. If it is poisoned, you neutralize the poison. If more than
        one poison afflicts the target, you neutralize one poison that you know is
        present, or you neutralize one at random.
        For the duration, the target has advantage on saving throws against being
        poisoned, and it has resistance to poison damage.
         */
        public static Spell ProtectionfromPoison {
            get {
                return new Spell(ID.PROTECTION_FROM_POISON, ABJURATION, SECOND, CastingTime.ONE_ACTION, 0, VS, ONE_HOUR, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
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

        /*
        A black beam of enervating energy springs from your finger toward a creature
        within range. Make a ranged spell attack against the target. On a hit, the target
        deals only half damage with weapon attacks that use Strength until the spell ends.
        At the end of each of the target's turns, it can make a constitution saving throw
        against the spell. On a success, the spell ends.
         */
        public static Spell RayofEnfeeblement {
            get {
                return new Spell(ID.RAY_OF_ENFEEBLEMENT, NECROMANCY, SECOND, CastingTime.ONE_ACTION, 60, VS, ONE_MINUTE, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    if (SpellAttack(ID.RAY_OF_ENFEEBLEMENT, ground, caster, TRUE_DAMAGE, null, 0, target, 60)) {
                        AddEffectsForDuration(ID.RAY_OF_ENFEEBLEMENT, caster, target, ONE_MINUTE, SPELL_RAY_OF_ENFEEBLEMENT);
                    }
                });
            }
        }

        /*
        You touch a length of rope that is up to 60 feet long. One end of the rope then
        rises into the air until the whole rope hangs perpendicular to the ground. At the
        upper end of the rope, an invisible entrance opens to an extradimensional space
        that lasts until the spell ends.
        The extradimensional space can be reached by climbing to the top of the rope. The
        space can hold as many as eight Medium or smaller creatures. The rope can be
        pulled into the space, making the rope disappear from view outside the space.
        Attacks and spells can't cross through the entrance into or out of the
        extradimensional space, but those inside can see out of it as if through a
        3-foot-by-5-foot window centered on the rope.
        Anything inside the extradimensional space drops out when the spell ends.
         */
        public static Spell RopeTrick {
            get {
                return new Spell(ID.ROPE_TRICK, TRANSMUTATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 0, SpellWithoutEffect(ID.ROPE_TRICK));
            }
        }

        /*
        You create three rays of fire and hurl them at targets within range. You can hurl
        them at one target or several.
        Make a ranged spell attack for each ray. On a hit, the target takes 2d6 fire
        damage.
        When you cast this spell using a spell slot of 3rd level or higher, you create one
        additional ray for each slot level above 2nd.
         */
        public static Spell ScorchingRay {
            get {
                return new Spell(ID.SCORCHING_RAY, EVOCATION, SECOND, CastingTime.ONE_ACTION, 120, VS, INSTANTANEOUS, 0, 10, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    int rays = (int)slot - 2 + 3;
                    for (int i = 0; i < rays; i++) {
                        Combatant target = targets[i % targets.Length];
                        SpellAttack(ID.SCORCHING_RAY, ground, caster, FIRE, new Dice("2d6"), modifier, target, 120);
                    }
                });
            }
        }

        /*
        For the duration of the spell, you see invisible creatures and objects as if they
        were visible, and you can see through Ethereal. The ethereal objects and creatures
        appear ghostly translucent.
         */
        public static Spell SeeInvisibility {
            get {
                return new Spell(ID.SEE_INVISIBILITY, DIVINATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    AddEffectsForDuration(ID.SEE_INVISIBILITY, caster, caster, ONE_HOUR, SPELL_SEE_INVISIBILITY);
                });
            }
        }

        /*
        A sudden loud ringing noise, painfully intense, erupts from a point of your choice
        within range. Each creature in a 10-foot-radius sphere centered on that point must
        make a Constitution saving throw. A creature takes 3d8 thunder damage on a failed
        save, or half as much damage on a successful one. A creature made of inorganic
        material such as stone, crystal, or metal has disadvantage on this saving throw.
        A non-magical item that is not worn or carried also suffers damage if it is in the
        area of the spell.
        When you cast this spell using a 3 or higher level spell slot, the damage of the
        spell increases by 1d8 for each level of higher spell slot 2.
         */
        public static Spell Shatter {
            get {
                return new Spell(ID.SHATTER, EVOCATION, SECOND, CastingTime.ONE_ACTION, 60, VSM, INSTANTANEOUS, 15, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Dice dice = DiceSlotScaling(SECOND, slot, D8, 3);
                    foreach (Combatant target in targets) {
                        // Constructs have disadvantage on DC, not Flesh Golem though, since it is made from organic material
                        bool disadvantage = target is Monster monster && monster.Type == Monsters.Type.CONSTRUCT && monster.ID != Monsters.ID.FLESH_GOLEM;
                        GlobalEvents.AffectBySpell(caster, ID.SHATTER, target, true);
                        target.TakeDamage(new DamageSource(ID.SHATTER, caster), THUNDER, dice, HALVES_DAMAGE, dc, CONSTITUTION, out _);
                    }
                });
            }
        }

        /*
        For the duration, no sound can be created within or pass through a 20-foot-radius
        sphere centered on a point you choose within range. Any creature or object
        entirely inside the sphere is immune to thunder damage, and creatures are deafened
        while entirely inside it.
        Casting a spell that includes a verbal component is impossible there.
         */
        public static Spell Silence {
            get {
                return new Spell(ID.SILENCE, ILLUSION, SECOND, CastingTime.ONE_ACTION, 120, VS, TEN_MINUTES, 20, 10, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // TODO: The effect should end when targets move out of the sphere of influence
                    // TODO: Casting a spell that includes a verbal component is impossible there
                    foreach (Combatant target in targets) {
                        AddEffectsForDuration(ID.SILENCE, caster, target, TEN_MINUTES, SPELL_SILENCE);
                    }
                });
            }
        }

        /*
        Until the spell ends, one willing creature you touch gains the ability to move up,
        down, and across vertical surfaces and upside down along ceilings, while leaving
        its hands free. The target also gains a climbing speed equal to its walking speed.
         */
        public static Spell SpiderClimb {
            get {
                return new Spell(ID.SPIDER_CLIMB, TRANSMUTATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    AddEffectsForDuration(ID.SPIDER_CLIMB, caster, target, ONE_HOUR, SPELL_SPIDER_CLIMB);
                });
            }
        }

        /*
        The ground in a 20-foot radius centered on a point within range twists and sprouts
        hard spikes and thorns. The area becomes difficult terrain for the duration. When
        a creature moves into or within the area, it takes 2d4 piercing damage for every 5
        feet it travels.
        The transformation of the ground is camouflaged to look natural. Any creature that
        can't see the area at the time the spell is cast can make a Wisdom (Perciption)
        check against your spell save DC to recognize the terrain as hazardous before
        entering it.
         */
        public static Spell SpikeGrowth {
            get {
                // TODO: At some point we want to be able to modify terrain
                // The area becomes difficult terrain for the duration. 
                // When a creature moves into or within the area, it takes 2d4 piercing damage for every 5 feet it travels.
                return new Spell(ID.SPIKE_GROWTH, TRANSMUTATION, SECOND, CastingTime.ONE_ACTION, 150, VSM, TEN_MINUTES, 20, 0, doNothing);
            }
        }

        /*
        You create a floating, spectral weapon within range that lasts for the duration or
        until you cast this spell again. When you cast the spell, you can make a melee
        spell attack against a creature within 5 feet of the weapon. On a hit, the target
        takes force damage equal to 1d8 + your spellcasting ability modifier.
        As a bonus action on your turn, you can move the weapon up to 20 feet and repeat
        the attack against a creature within 5 feet of it.
        The weapon can take whatever form you choose. Clerics of deities who are
        associated with a particular weapon (as St. Cuthbert is known for his mace and
        Thor for his hammer) make this spell's effect resemble that weapon.
        When you cast this spell using a spell slot of 3rd level or higher, the damage
        increases by 1d8 for every two slot levels above the 2nd.
         */
        public static Spell SpiritualWeapon {
            get {
                return new Spell(ID.SPIRITUAL_WEAPON, EVOCATION, SECOND, CastingTime.BONUS_ACTION, 60, VS, ONE_MINUTE, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    Dice dice = new Dice((int)slot / 2, D8, modifier);
                    SpellAttack(ID.SPIRITUAL_WEAPON, ground, caster, FORCE, dice, modifier, target, 65);
                    // TODO: This cantrip workaround should be replaced by correctly implementing situative actions
                    Spell weaponCantrip = new Spell(ID.SPIRITUAL_WEAPON_ATTACK, EVOCATION, CANTRIP, CastingTime.BONUS_ACTION, 25, V, INSTANTANEOUS, 0, 1, delegate (Battleground ground2, Combatant caster2, int dc2, SpellLevel slot2, int modifier2, Combatant[] targets2) {
                        Combatant target2 = targets2[0];
                        SpellAttack(ID.SPIRITUAL_WEAPON_ATTACK, ground2, caster2, FORCE, dice, modifier2, target2, 25);
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

        /*
        You suggest a course of activity (limited to a sentence or two) and magically
        influence a creature you can see within range that can hear and understand you.
        Creatures that can't be charmed are immune to this effect. The suggestion must be
        worded in such a manner as to make the course of action sound reasonable. Asking
        the creature to stab itself, throw itself onto a spear, immolate itself, or do
        some other obviously harmful act ends the spell.
        The target must make a wisdom saving throw. On a failed save, it pursues the
        course of action you described to the best of its ability. The suggested course of
        action can continue for the entire duration. If the suggested activity can be
        completed in a shorter time, the spell ends when the subject finishes what it was
        asked to do.
        You can also specify conditions that will trigger a special activity during the
        duration. For example, you might suggest that a knight give her warhorse to the
        first beggar she meets. If the condition isn't met before the spell expires, the
        activity isn't performed.
        If you or any of your companions damage the target, the spell ends.
         */
        public static Spell Suggestion {
            get {
                // In order to not make this spell too powerful (compare with Dominate line of spells)
                // we make the target only unable to attack. Effect ends when the target takes damage.
                return new Spell(ID.SUGGESTION, ENCHANTMENT, SECOND, CastingTime.ONE_ACTION, 30, VM, EIGHT_HOURS, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    if (target.HasEffect(IMMUNITY_CHARMED) || target.DC(ID.SUGGESTION, dc, WISDOM)) {
                        GlobalEvents.AffectBySpell(caster, ID.SUGGESTION, target, false);
                    } else {
                        AddEffectsForDuration(ID.SUGGESTION, caster, target, EIGHT_HOURS, SPELL_SUGGESTION);
                        target.AddDamageTakenEvent(delegate (DamageSource source, Damage damage) {
                            target.RemoveEffect(SPELL_SUGGESTION);
                            return true;
                        });
                    }
                });
            }
        }

        /*
        This spell wards a willing creature you touch and creates a mystic connection
        between you and the target until the spell ends. While the target is within 60
        feet of you, it gains a +1 bonus to AC and saving throws, and it has resistance to
        all damage. Also, each time it takes damage, you take the same amount of damage.
        The spell ends if you drop to 0 hit points or if you and the target become
        separated by more than 60 feet.
        It also ends if the spell is cast again on either of the connected creatures. You
        can also dismiss the spell as an action.
         */
        public static Spell WardingBond {
            get {
                return new Spell(ID.WARDING_BOND, ABJURATION, SECOND, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
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
                    target.AddDamageTakenEvent(delegate (DamageSource source, Damage damage) {
                        if (!target.HasEffect(SPELL_WARDING_BOND) || !caster.HasEffect(SPELL_WARDING_BOND_CASTER)) {
                            target.RemoveEffect(SPELL_WARDING_BOND);
                            caster.RemoveEffect(SPELL_WARDING_BOND_CASTER);
                            return true;
                        }
                        caster.TakeDamage(source, damage.Type, damage.Dice);
                        return false;
                    });
                    caster.AddDamageTakenEvent(delegate (DamageSource source, Damage damage) {
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

        /*
        You conjure a mass of thick, sticky webbing at a point of your choice within
        range. The webs fill a 20-foot cube from that point for the duration. The webs are
        difficult terrain and lightly obscure their area.
        If the webs aren't anchored between two solid masses (such as walls or trees) or
        layered across a floor, wall, or ceiling, the conjured web collapses on itself,
        and the spell ends at the start of your next turn. Webs layered over a flat
        surface have a depth of 5 feet.
        Each creature that starts its turn in the webs or that enters them during its turn
        must make a dexterity saving throw. On a failed save, the creature is restrained
        as long as it remains in the webs or until it breaks free.
        A creature restrained by the webs can use its action to make a Strength check
        against your spell save DC. If it succeeds, it is no longer restrained.
        The webs are flammable. Any 5-foot cube of webs exposed to fire burns away in 1
        round, dealing 2d4 fire damage to any creature that starts its turn in the fire.
         */
        public static Spell Web {
            get {
                // TODO: Needs a means to place obstacles on Battlefields
                return new Spell(ID.WEB, CONJURATION, SECOND, CastingTime.ONE_ACTION, 60, VSM, ONE_HOUR, 20, 0, SpellWithoutEffect(ID.WEB));
            }
        }

        /*
        You create a magical zone that guards against deception in a 15-foot-radius sphere
        centered on a point of your choice within range. Until the spell ends, a creature
        that enters the spell's area for the first time on a turn or starts its turn there
        must make a Charisma saving throw. On a failed save, a creature can't speak a
        deliberate lie while in the radius. You know whether each creature succeeds or
        fails on its saving throw.
        An affected creature is aware of the spell and can thus avoid answering questions
        to which it would normally respond with a lie. Such a creature can remain evasive
        in its answers as long as it remains within the boundaries of the truth.
         */
        public static Spell ZoneofTruth {
            get {
                return new Spell(ID.ZONE_OF_TRUTH, ENCHANTMENT, SECOND, CastingTime.ONE_ACTION, 60, VS, TEN_MINUTES, 15, 0, SpellWithoutEffect(ID.ZONE_OF_TRUTH));
            }
        }
    }
}
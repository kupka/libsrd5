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
        You hurl a bubble of acid. Choose one creature within range, or choose two
        creatures within range that are within 5 feet of each other. A target must succeed
        on a dexterity saving throw or take 1d6 acid damage.
        This spell's damage increases by 1d6 when you reach 5th level (2d6), 11th level
        (3d6), and 17th level (4d6).
         */
        public static Spell AcidSplash {
            get {
                return new Spell(
                    ID.ACID_SPLASH, CONJURATION, CANTRIP, CastingTime.ONE_ACTION, 60, VS,
                    INSTANTANEOUS, 5, 2, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        Dice dice = DiceLevelScaling(caster, D6);
                        foreach (Combatant target in targets) {
                            if (!target.DC(ID.ACID_SPLASH, dc, DEXTERITY)) {
                                GlobalEvents.AffectBySpell(caster, ID.ACID_SPLASH, target, true);
                                target.TakeDamage(new DamageSource(ID.ACID_SPLASH, caster), ACID, dice);
                            } else {
                                GlobalEvents.AffectBySpell(caster, ID.ACID_SPLASH, target, false);
                            }
                        }
                    }
                );
            }
        }

        /*
        You create a ghostly, skeletal hand in the space of a creature within range. Make
        a ranged spell attack against the creature to assail it with the chill of the
        grave. On a hit, the target takes 1d8 necrotic damage, and it can't regain hit
        points until the start of your next turn. Until then, the hand clings to the
        target.
        If you hit an undead target, it also has disadvantage on attack rolls against you
        until the end of your next turn.
        This spell's damage increases by 1d8 when you reach 5th level (2d8), 11th level
        (3d8), and 17th level (4d8).
         */
        public static Spell ChillTouch {
            get {
                return new Spell(
                    ID.CHILL_TOUCH, NECROMANCY, CANTRIP, CastingTime.ONE_ACTION, 120, VS,
                    INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        Dice dice = DiceLevelScaling(caster, D8);
                        Combatant target = targets[0];
                        bool hit = SpellAttack(ID.CHILL_TOUCH, ground, caster, NECROTIC, dice, modifier, target, 120);
                        if (hit) {
                            target.AddEffect(CANNOT_REGAIN_HITPOINTS);
                            caster.AddStartOfTurnEvent(delegate () {
                                target.RemoveEffect(CANNOT_REGAIN_HITPOINTS);
                                return true;
                            });
                            bool undead = target is Monster monster && monster.Type == Monsters.Type.UNDEAD;
                            if (undead) {
                                target.AddEffect(DISADVANTAGE_ON_ATTACK);
                                int rounds = 2;
                                caster.AddEndOfTurnEvent(delegate () {
                                    if (--rounds > 0) return false;
                                    if (undead) target.RemoveEffect(DISADVANTAGE_ON_ATTACK);
                                    return true;
                                });
                            }
                        }
                    }
                );
            }
        }

        /*
        You create up to four torch-sized lights within range, making them appear as
        torches, lanterns, or glowing orbs that hover in the air for the duration. You can
        also combine the four lights into one glowing vaguely humanoid form of Medium
        size. Whichever form you choose, each light sheds dim light in a 10-foot radius.
        As a bonus action on your turn, you can move the lights up to 60 feet to a new
        spot within range. A light must be within 20 feet of another light created by this
        spell, and a light winks out if it exceeds the spell's range.
         */
        public static Spell DancingLights {
            get {
                return new Spell(
                    ID.DANCING_LIGHTS, EVOCATION, CANTRIP, CastingTime.ONE_MINUTE, 120, VSM,
                    INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.DANCING_LIGHTS)
                );
            }
        }

        /*
        Whispering to the spirits of nature, you create one of the following effects
        within 'range':
        - You create a tiny, harmless sensory effect that predicts what the weather will
        be at your location for the next 24 hours. The effect might manifest as a golden
        orb for clear skies, a cloud for rain, falling snowflakes for snow, and so on.
        This effect persists for 1 round.
        - You instantly make a flower bloom, a seed pod open, or a leaf bud bloom.
        - You create an instantaneous, harmless sensory effect, such as falling leaves, a
        puff of wind, the sound of a small animal, or the faint order of skunk. The effect
        must fit in a 5-foot cube.
        - You instantly light or snuff out a candle, a torch, or a small campfire.
         */
        public static Spell Druidcraft {
            get {
                return new Spell(ID.DRUIDCRAFT, TRANSMUTATION,
                    CANTRIP, CastingTime.ONE_ACTION, 30, VS, INSTANTANEOUS, 0, 0,
                    SpellWithoutEffect(ID.DRUIDCRAFT)
                );
            }
        }

        /*
        A beam of crackling energy streaks toward a creature within range. Make a ranged
        spell attack against the target. On a hit, the target takes 1d10 force damage. The
        spell creates more than one beam when you reach higher levels: two beams at 5th
        level, three beams at 11th level, and four beams at 17th level. You can direct the
        beams at the same target or at different ones. Make a separate attack roll for
        each beam.
         */
        public static Spell EldritchBlast {
            get {
                return new Spell(ID.ELDRITCH_BLAST, EVOCATION, CANTRIP, CastingTime.ONE_ACTION, 120, VS, INSTANTANEOUS, 0, 4,
                    delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        Damage damage = new Damage(FORCE, "1d10");
                        Dice dice = DiceLevelScaling(caster, D10);
                        for (int i = 0; i < dice.Amount; i++) {
                            SpellAttack(ID.ELDRITCH_BLAST, ground, caster, FORCE, new Dice("1d10"), modifier, targets[i % targets.Length], 120);
                        }
                    }
                );
            }
        }

        /*
        You hurl a mote of fire at a creature or object within range. Make a ranged spell
        attack against the target. On a hit, the target takes 1d10 fire damage. A
        flammable object hit by this spell ignites if it isn't being worn or carried.
        This spell's damage increases by 1d10 when you reach 5th level (2d10), 11th level
        (3d10), and 17th level (4d10).
         */
        public static Spell FireBolt {
            get {
                return new Spell(
                    ID.FIRE_BOLT, EVOCATION, CANTRIP, CastingTime.ONE_ACTION, 120, VS,
                    INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        Dice dice = DiceLevelScaling(caster, D10);
                        SpellAttack(ID.FIRE_BOLT, ground, caster, FIRE, dice, modifier, targets[0], 120);
                    }
                );
            }
        }

        /*
        You touch one willing creature. Once before the spell ends, the target can roll a
        d4 and add the number rolled to one ability check of its choice. It can roll the
        die before or after making the ability check. The spell then ends.
         */
        public static Spell Guidance {
            get {
                return new Spell(
                    ID.GUIDANCE, DIVINATION, CANTRIP, CastingTime.ONE_ACTION, 5, VS,
                    ONE_MINUTE, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        Combatant target = targets[0];
                        AddEffectsForDuration(ID.GUIDANCE, caster, target, ONE_MINUTE, SPELL_GUIDANCE);
                    }
                );
            }
        }

        /*
        You touch one object that is no larger than 10 feet in any dimension. Until the
        spell ends, the object sheds bright light in a 20-foot radius and dim light for an
        additional 20 feet. The light can be colored as you like. Completely covering the
        object with something opaque blocks the light. The spell ends if you cast it again
        or dismiss it as an action.
        If you target an object held or worn by a hostile creature, that creature must
        succeed on a dexterity saving throw to avoid the spell.
         */
        public static Spell Light {
            get {
                return new Spell(
                    ID.LIGHT, EVOCATION, CANTRIP, CastingTime.ONE_ACTION, 0, VM,
                    ONE_HOUR, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        Combatant target = targets[0];
                        if (target.DC(ID.LIGHT, dc, DEXTERITY)) {
                            GlobalEvents.AffectBySpell(caster, ID.LIGHT, target, false);
                        } else {
                            GlobalEvents.AffectBySpell(caster, ID.LIGHT, target, true);
                            target.AddEffect(SPELL_LIGHT);
                        }
                    }
                );
            }
        }

        /*
        This spell repairs a single break or tear in an object you touch, such as a broken
        key, a torn cloak, or a leaking wineskin. As long as the break or tear is no
        longer than 1 foot in any dimension, you mend it, leaving no trace of the former
        damage.
        This spell can physically repair a magic item or construct, but the spell can't
        restore magic to such an object.
         */
        public static Spell MageHand {
            get {
                return new Spell(
                    ID.MENDING, CONJURATION, CANTRIP, CastingTime.ONE_ACTION, 30, VS,
                    ONE_MINUTE, 0, 0, SpellWithoutEffect(ID.MAGE_HAND)
                );
            }
        }

        /*
        This spell repairs a single break or tear in an object you touch, such as a broken
        key, a torn cloak, or a leaking wineskin. As long as the break or tear is no
        longer than 1 foot in any dimension, you mend it, leaving no trace of the former
        damage.
        This spell can physically repair a magic item or construct, but the spell can't
        restore magic to such an object.
         */
        public static Spell Mending {
            get {
                return new Spell(
                    ID.MENDING, TRANSMUTATION, CANTRIP, CastingTime.ONE_MINUTE, 0, VSM,
                    INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.MENDING)
                );
            }
        }

        /*
        This spell repairs a single break or tear in an object you touch, such as a broken
        key, a torn cloak, or a leaking wineskin. As long as the break or tear is no
        longer than 1 foot in any dimension, you mend it, leaving no trace of the former
        damage.
        This spell can physically repair a magic item or construct, but the spell can't
        restore magic to such an object.
         */
        public static Spell Message {
            get {
                return new Spell(
                    ID.MENDING, TRANSMUTATION, CANTRIP, CastingTime.ONE_ROUND, 120, VSM,
                    ONE_ROUND, 0, 0, SpellWithoutEffect(ID.MESSAGE)
                );
            }
        }

        /*
        You create a sound or an image of an object within range that lasts for the
        duration. The illusion also ends if you dismiss it as an action or cast this spell
        again.
        If you create a sound, its volume can range from a whisper to a scream. It can be
        your voice, someone else's voice, a lion's roar, a beating of drums, or any other
        sound you choose. The sound continues unabated throughout the duration, or you can
        make discrete sounds at different times before the spell ends.
        If you create an image of an object--such as a chair, muddy footprints, or a small
        chest--it must be no larger than a 5-foot cube. The image can't create sound,
        light, smell, or any other sensory effect. Physical interaction with the image
        reveals it to be an illusion, because things can pass through it.
        If a creature uses its action to examine the sound or image, the creature can
        determine that it is an illusion with a successful Intelligence (Investigation)
        check against your spell save DC. If a creature discerns the illusion for what it
        is, the illusion becomes faint to the creature.
         */
        public static Spell MinorIllusion {
            get {
                return new Spell(
                    ID.MINOR_ILLUSION, ILLUSION, CANTRIP, CastingTime.ONE_ROUND, 30, SM,
                    ONE_MINUTE, 0, 0, SpellWithoutEffect(ID.MINOR_ILLUSION)
                );
            }
        }

        /*
        You extend your hand toward a creature you can see within range and project a puff
        of noxious gas from your palm. The creature must succeed on a constitution saving
        throw or take 1d12 poison damage.
        This spell's damage increases by 1d12 when you reach 5th level (2d12), 11th level
        (3d12), and 17th level (4d12).
         */
        public static Spell PoisonSpray {
            get {
                return new Spell(ID.POISON_SPRAY, CONJURATION, CANTRIP, CastingTime.ONE_ACTION, 10, VS, INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Dice dice = DiceLevelScaling(caster, D12);
                    Combatant target = targets[0];
                    if (target.DC(ID.POISON_SPRAY, dc, CONSTITUTION)) {
                        GlobalEvents.AffectBySpell(caster, ID.POISON_SPRAY, target, false);
                    } else {
                        GlobalEvents.AffectBySpell(caster, ID.POISON_SPRAY, target, true);
                        target.TakeDamage(new DamageSource(ID.POISON_SPRAY, caster), POISON, dice);
                    }
                });
            }
        }

        /*
        This spell is a minor magical trick that novice spellcasters use for practice. You
        create one of the following magical effects within 'range':
        You create an instantaneous, harmless sensory effect, such as a shower of sparks,
        a puff of wind, faint musical notes, or an odd odor.
        You instantaneously light or snuff out a candle, a torch, or a small campfire.
        You instantaneously clean or soil an object no larger than 1 cubic foot.
        You chill, warm, or flavor up to 1 cubic foot of nonliving material for 1 hour.
        You make a color, a small mark, or a symbol appear on an object or a surface for 1
        hour.
        You create a nonmagical trinket or an illusory image that can fit in your hand and
        that lasts until the end of your next turn.
        If you cast this spell multiple times, you can have up to three of its
        non-instantaneous effects active at a time, and you can dismiss such an effect as
        an action.
         */
        public static Spell Prestidigitation {
            get {
                return new Spell(
                    ID.PRESTIDIGITATION, TRANSMUTATION, CANTRIP, CastingTime.ONE_ACTION, 10, VS,
                    ONE_HOUR, 0, 0, SpellWithoutEffect(ID.PRESTIDIGITATION)
                );
            }
        }

        /*
        A flickering flame appears in your hand. The flame remains there for the duration
        and harms neither you nor your equipment. The flame sheds bright light in a
        10-foot radius and dim light for an additional 10 feet. The spell ends if you
        dismiss it as an action or if you cast it again.
        You can also attack with the flame, although doing so ends the spell. When you
        cast this spell, or as an action on a later turn, you can hurl the flame at a
        creature within 30 feet of you. Make a ranged spell attack. On a hit, the target
        takes 1d8 fire damage.
        This spell's damage increases by 1d8 when you reach 5th level (2d8), 11th level
        (3d8), and 17th level (4d8).
         */
        public static Spell ProduceFlame {
            get {
                return new Spell(
                    ID.PRODUCE_FLAME, CONJURATION, CANTRIP, CastingTime.ONE_ACTION, 30, VS,
                    INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        Combatant target = targets[0];
                        int bonus = modifier + caster.ProficiencyBonus;
                        Dice dice = DiceLevelScaling(caster, D8);
                        SpellAttack(ID.PRODUCE_FLAME, ground, caster, FIRE, dice, modifier, target, 30);
                    }
                );
            }
        }

        /*
        A frigid beam of blue-white light streaks toward a creature within range. Make a
        ranged spell attack against the target. On a hit, it takes 1d8 cold damage, and
        its speed is reduced by 10 feet until the start of your next turn.
        The spell's damage increases by 1d8 when you reach 5th level (2d8), 11th level
        (3d8), and 17th level (4d8).
         */
        public static Spell RayOfFrost {
            get {
                return new Spell(
                    ID.RAY_OF_FROST, EVOCATION, CANTRIP, CastingTime.ONE_ACTION, 60, VS,
                    INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        int bonus = modifier + caster.ProficiencyBonus;
                        Dice dice = DiceLevelScaling(caster, D8);
                        Combatant target = targets[0];
                        bool hit = SpellAttack(ID.RAY_OF_FROST, ground, caster, COLD, dice, modifier, target, 60);
                        if (hit) {
                            target.AddEffect(SPELL_RAY_OF_FROST);
                            caster.AddStartOfTurnEvent(delegate () {
                                target.RemoveEffect(SPELL_RAY_OF_FROST);
                                return true;
                            });
                        }
                    }
                );
            }
        }

        /*
        You touch one willing creature. Once before the spell ends, the target can roll a
        d4 and add the number rolled to one saving throw of its choice. It can roll the
        die before or after making the saving throw. The spell then ends.
         */
        public static Spell Resistance {
            get {
                return new Spell(
                    ID.RESISTANCE, ABJURATION, CANTRIP, CastingTime.ONE_ACTION, 0, VSM,
                    ONE_MINUTE, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        GlobalEvents.AffectBySpell(caster, ID.RESISTANCE, targets[0], true);
                        targets[0].AddEffect(SPELL_RESISTANCE);
                    }
                );
            }
        }

        /*
        Flame-like radiance descends on a creature that you can see within range. The
        target must succeed on a dexterity saving throw or take 1d8 radiant damage. The
        target gains no benefit from cover for this saving throw.
        The spell's damage increases by 1d8 when you reach 5th level (2d8), 11th level
        (3d8), and 17th level (4d8).
         */
        public static Spell SacredFlame {
            get {
                return new Spell(
                    ID.SACRED_FLAME, EVOCATION, CANTRIP, CastingTime.ONE_ACTION, 60, VS, INSTANTANEOUS, 0, 0, SpellWithoutEffect(ID.SACRED_FLAME)
                );
            }
        }

        /*
        The wood of a club or a quarterstaff you are holding is imbued with nature's
        power. For the duration, you can use your spellcasting ability instead of Strength
        for the attack and damage rolls of melee attacks using that weapon, and the
        weapon's damage die becomes a d8. The weapon also becomes magical, if it isn't
        already. The spell ends if you cast it again or if you let go of the weapon.
         */
        public static Spell Shillelagh {
            get {
                return new Spell(
                    ID.SHILLELAGH, TRANSMUTATION, CANTRIP, CastingTime.BONUS_ACTION, 0, VSM,
                    ONE_MINUTE, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        // can only be cast by PCs or NPCs
                        if (!(caster is CharacterSheet)) {
                            GlobalEvents.AffectBySpell(caster, ID.SHILLELAGH, caster, false);
                            return;
                        }
                        ;
                        CharacterSheet sheet = (CharacterSheet)caster;
                        // spell requires a quarterstaff or club
                        if (sheet.Inventory.MainHand == null) {
                            GlobalEvents.AffectBySpell(caster, ID.SHILLELAGH, caster, false);
                            return;
                        }
                        if (!sheet.Inventory.MainHand.Is(Weapons.Club) && !sheet.Inventory.MainHand.Is(Weapons.Quarterstaff)) {
                            GlobalEvents.AffectBySpell(caster, ID.SHILLELAGH, caster, false);
                            return;
                        }
                        // replace melee attacks by shillelagh attacks
                        GlobalEvents.AffectBySpell(caster, ID.SHILLELAGH, caster, true);
                        foreach (Attack attack in sheet.MeleeAttacks) {
                            attack.Name = ID.SHILLELAGH.Name();
                            attack.Damage.Dice = new Dice(1, 8, modifier);
                            attack.AttackBonus = modifier + sheet.ProficiencyBonus;
                        }
                        if (caster.BonusAttack != null) {
                            caster.BonusAttack.Name = ID.SHILLELAGH.Name();
                            caster.BonusAttack.Damage.Dice = new Dice(1, 8, modifier);
                            caster.BonusAttack.AttackBonus = modifier + sheet.ProficiencyBonus;
                        }
                    }
                );
            }
        }

        /*
        Lightning springs from your hand to deliver a shock to a creature you try to
        touch. Make a melee spell attack against the target. You have advantage on the
        attack roll if the target is wearing armor made of metal. On a hit, the target
        takes 1d8 lightning damage, and it can't take reactions until the start of its
        next turn.
        The spell's damage increases by 1d8 when you reach 5th level (2d8), 11th level
        (3d8), and 17th level (4d8).
         */
        public static Spell ShockingGrasp {
            get {
                return new Spell(
                    ID.SHOCKING_GRASP, EVOCATION, CANTRIP, CastingTime.ONE_ACTION, 5, VS,
                    INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        Dice dice = DiceLevelScaling(caster, D8);
                        Combatant target = targets[0];
                        bool hit = SpellAttack(ID.SHOCKING_GRASP, ground, caster, LIGHTNING, dice, modifier, target, 5);
                        if (hit) {
                            target.AddEffect(CANNOT_TAKE_REACTIONS);
                            caster.AddStartOfTurnEvent(delegate () {
                                target.RemoveEffect(CANNOT_TAKE_REACTIONS);
                                return true;
                            });
                        }
                    }
                );
            }
        }

        /*
        You touch a living creature that has 0 hit points. The creature becomes stable.
        This spell has no effect on undead or constructs.
         */
        public static Spell SpareTheDying {
            get {
                return new Spell(ID.SPARE_THE_DYING, NECROMANCY, CANTRIP,
                    CastingTime.ONE_ACTION, 5, VS, INSTANTANEOUS, 0, 1,
                    delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        Combatant target = targets[0];
                        if (target.HasEffect(FIGHTING_DEATH)) {
                            target.AddEffect(FIGHTING_DEATH_STABILIZED);
                        }
                    }
                );
            }
        }

        /*
        You manifest a minor wonder, a sign of supernatural power, within range. You
        create one of the following magical effects within range.
        - Your voice booms up to three times as loud as normal for 1 minute.
        - You cause flames to flicker, brighten, dim, or change color for 1 minute.
        - You cause harmless tremors in the ground for 1 minute.
        - You create an instantaneous sound that originates from a point of your choice
        within range, such as a rumble of thunder, the cry of a raven, or ominous
        whispers.
        - You instantaneously cause an unlocked door or window to fly open or slam shut.
        - You alter the appearance of your eyes for 1 minute.
        If you cast this spell multiple times, you can have up to three of its 1-minute
        effects active at a time, and you can dismiss such an effect as an action.
         */
        public static Spell Thaumaturgy {
            get {
                return new Spell(ID.THAUMATURGY, TRANSMUTATION, CANTRIP, CastingTime.ONE_ACTION, 30, V, ONE_MINUTE, 0, 0, SpellWithoutEffect(ID.THAUMATURGY));
            }
        }

        /*
        You extend your hand and point a finger at a target in range. Your magic grants
        you a brief insight into the target's defenses. On your next turn, you gain
        advantage on your first attack roll against the target, provided that this spell
        hasn't ended.
         */
        public static Spell TrueStrike {
            get {
                return new Spell(
                    ID.TRUE_STRIKE, DIVINATION, CANTRIP, CastingTime.ONE_ACTION, 30, S,
                    ONE_ROUND, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        int turn = ground.Turn;
                        caster.AddAttackModifyingEffect(delegate (ref bool advantage, ref bool disadvantage, ref Attack attack, ref Combatant target) {
                            if (ground.Turn > turn + 1) return true; // no longer active
                            if (ground.Turn < turn + 1) return false; // not yet active
                            if (target == targets[0]) {
                                advantage = true;
                                return true;
                            } else {
                                return false;
                            }
                        });
                        GlobalEvents.AffectBySpell(caster, ID.TRUE_STRIKE, targets[0], true);
                    }
                );
            }
        }

        /*
        You unleash a string of insults laced with subtle enchantments at a creature you
        can see within range. If the target can hear you (though it need not understand
        you), it must succeed on a wisdom saving throw or take 1d4 psychic damage and have
        disadvantage on the next attack roll it makes before the end of its next turn.
        This spell's damage increases by 1d4 when you reach 5th level (2d4), 11th level
        (3d4), and 17th level (4d4).
         */
        public static Spell ViciousMockery {
            get {
                return new Spell(ID.VICIOUS_MOCKERY, ENCHANTMENT, CANTRIP, CastingTime.ONE_ACTION, 60, V, INSTANTANEOUS, 0, 1,
                    delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                        Dice dice = DiceLevelScaling(caster, D4);
                        Combatant target = targets[0];
                        int damageTaken = target.TakeDamage(new DamageSource(ID.VICIOUS_MOCKERY, caster), PSYCHIC, dice, NULLIFIES_DAMAGE, dc, WISDOM, out _);
                        if (damageTaken == 0) {
                            GlobalEvents.AffectBySpell(caster, ID.VICIOUS_MOCKERY, target, false);
                        } else {
                            GlobalEvents.AffectBySpell(caster, ID.VICIOUS_MOCKERY, target, true);
                            target.AddEffect(DISADVANTAGE_ON_ATTACK);
                            target.AddEndOfTurnEvent(
                                delegate () {
                                    target.RemoveEffect(DISADVANTAGE_ON_ATTACK);
                                    return true;
                                }
                            );
                        }
                    }
                );
            }
        }
    }
}
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
        You create an invisible, magical eye within range that hovers in the air for the duration.
        You mentally receive visual information from the eye, which has normal vision and darkvision out to 30 feet. 
        The eye can look in every direction.
        As an action, you can move the eye up to 30 feet in any direction. 
        There is no limit to how far away from you the eye can move, but it can't enter another plane of existence. 
        A solid barrier blocks the eye's movement, but the eye can pass through an opening as small as 1 inch in diameter.
         */
        public static Spell ArcaneEye {
            get {
                return new Spell(ID.ARCANE_EYE, DIVINATION, FOURTH, CastingTime.ONE_ACTION, 30, VSM, ONE_HOUR, 30, 0, doNothing);
            }
        }
        /* TODO:
        You attempt to send one creature that you can see within range to another plane of existence. 
        The target must succeed on a charisma saving throw or be banished.
        If the target is native to the plane of existence you're on, you banish the target to a harmless demiplane. 
        While there, the target is incapacitated. The target remains there until the spell ends, 
        at which point the target reappears in the space it left or in the nearest unoccupied space if that space is occupied.
        If the target is native to a different plane of existence than the one you're on, the target is banished with a faint popping noise, 
        returning to its home plane. If the spell ends before 1 minute has passed, 
        the target reappears in the space it left or in the nearest unoccupied space if that space is occupied. 
        Otherwise, the target doesn't return.
        */
        public static Spell Banishment {
            get {
                return new Spell(ID.BANISHMENT, ABJURATION, FOURTH, CastingTime.ONE_ACTION, 60, VSM, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        public static Spell BlackTentacles {
            get {
                return new Spell(ID.BLACK_TENTACLES, CONJURATION, FOURTH, CastingTime.ONE_ACTION, 90, VSM, ONE_MINUTE, 20, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    GlobalEvents.AffectBySpell(caster, ID.BLACK_TENTACLES, caster, true);

                    foreach (Combatant target in targets) {
                        // On entering the area, target must make a DEX save or take 3d6 bludgeoning damage and be restrained
                        if (target.DC(ID.BLACK_TENTACLES, dc, DEXTERITY)) {
                            GlobalEvents.AffectBySpell(caster, ID.BLACK_TENTACLES, target, false);
                            continue;
                        }

                        GlobalEvents.AffectBySpell(caster, ID.BLACK_TENTACLES, target, true);
                        target.TakeDamage(new DamageSource(ID.BLACK_TENTACLES, caster), BLUDGEONING, new Dice("3d6"));
                        target.AddEffect(SPELL_BLACK_TENTACLES);

                        // At the start of each turn: restrained creatures take automatic 3d6 damage;
                        // unrestrained creatures in the area (e.g. escaped) must save again
                        target.AddStartOfTurnEvent(delegate () {
                            if (!target.HasEffect(SPELL_BLACK_TENTACLES)) return true;
                            if (target.HasCondition(ConditionType.RESTRAINED)) {
                                // Already restrained: automatic 3d6 bludgeoning damage
                                target.TakeDamage(new DamageSource(ID.BLACK_TENTACLES, caster), BLUDGEONING, new Dice("3d6"));
                            } else {
                                // Escaped restraint: DEX save or take damage and become restrained again
                                if (!target.DC(ID.BLACK_TENTACLES, dc, DEXTERITY)) {
                                    GlobalEvents.AffectBySpell(caster, ID.BLACK_TENTACLES, target, true);
                                    target.TakeDamage(new DamageSource(ID.BLACK_TENTACLES, caster), BLUDGEONING, new Dice("3d6"));
                                    target.AddCondition(ConditionType.RESTRAINED);
                                }
                            }
                            return false;
                        });

                        // Add action to escape restraint: DEX save or take damage and remain restrained
                        ActionEffect escape = delegate () {
                            if (!target.DC(ID.BLACK_TENTACLES, dc, DEXTERITY)) {
                                GlobalEvents.AffectBySpell(caster, ID.BLACK_TENTACLES, target, true);
                                target.TakeDamage(new DamageSource(ID.BLACK_TENTACLES, caster), BLUDGEONING, new Dice("3d6"));
                                return false;
                            }
                            target.RemoveCondition(ConditionType.RESTRAINED);
                            return true;
                        };
                        Action escapeAction = new Action(Actions.ID.ESCAPE_FROM_SPELL_BLACK_TENTACLES, escape);
                        target.AddConditionalAction(escapeAction);
                    }

                    // Duration: 1 minute; remove effec t (and with it RESTRAINED) from all targets when expired
                    int remainingRounds = (int)ONE_MINUTE;
                    caster.AddEndOfTurnEvent(delegate () {
                        if (--remainingRounds < 1) {
                            foreach (Combatant target in targets) {
                                target.RemoveEffect(SPELL_BLACK_TENTACLES);
                            }
                            return true;
                        }
                        return false;
                    });
                });
            }
        }

        public static Spell Blight {
            get {
                return new Spell(ID.BLIGHT, NECROMANCY, FOURTH, CastingTime.ONE_ACTION, 30, VS, INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];

                    // No effect on undead or constructs
                    if (target is Monster monster && (monster.Type == Monsters.Type.UNDEAD || monster.Type == Monsters.Type.CONSTRUCT)) {
                        GlobalEvents.AffectBySpell(caster, ID.BLIGHT, target, false);
                        return;
                    }

                    GlobalEvents.AffectBySpell(caster, ID.BLIGHT, target, true);
                    Dice damage = DiceSlotScaling(FOURTH, slot, D8, 8);

                    // Plant creature: save with disadvantage, spell deals maximum damage
                    if (target is Monster plant && plant.Type == Monsters.Type.PLANT) {
                        target.TakeDamage(new DamageSource(ID.BLIGHT, caster), NECROTIC, damage.Max, HALVES_DAMAGE, dc, CONSTITUTION, out _, false, true);
                    } else {
                        target.TakeDamage(new DamageSource(ID.BLIGHT, caster), NECROTIC, damage, HALVES_DAMAGE, dc, CONSTITUTION, out _);
                    }
                });
            }
        }
        /* TODO:
        Creatures of your choice that you can see within range and that can hear you must make a wisdom saving throw. 
        A target automatically succeeds on this saving throw if it can't be charmed. On a failed save, a target is affected by this spell. 
        Until the spell ends, you can use a bonus action on each of your turns to designate a direction that is horizontal to you. 
        Each affected target must use as much of its movement as possible to move in that direction on its next turn. 
        It can take any action before it moves. After moving in this way, it can make another Wisdom save to try to end the effect.
        A target isn't compelled to move into an obviously deadly hazard, such as a fire or a pit, 
        but it will provoke opportunity attacks to move in the designated direction.
         */
        public static Spell Compulsion {
            get {
                return new Spell(ID.COMPULSION, ENCHANTMENT, FOURTH, CastingTime.ONE_ACTION, 30, VS, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        public static Spell Confusion {
            get {
                return new Spell(ID.CONFUSION, ENCHANTMENT, FOURTH, CastingTime.ONE_ACTION, 90, VSM, ONE_MINUTE, 10, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    foreach (Combatant target in targets) {
                        if (target.DC(ID.CONFUSION, dc, WISDOM)) {
                            GlobalEvents.AffectBySpell(caster, ID.CONFUSION, target, false);
                            continue;
                        }

                        GlobalEvents.AffectBySpell(caster, ID.CONFUSION, target, true);
                        target.AddEffect(SPELL_CONFUSION); // adds CANNOT_TAKE_REACTIONS

                        // At the start of each turn, roll d10 to determine behavior
                        target.AddStartOfTurnEvent(delegate () {
                            if (!target.HasEffect(SPELL_CONFUSION)) return true;

                            int roll = D10.Value;
                            if (roll <= 6) {
                                // 1: random movement, no action; 2-6: no movement or action
                                // Block actions for this turn; remove at end of turn
                                target.AddEffect(CANNOT_TAKE_ACTIONS);
                                target.AddEndOfTurnEvent(delegate () {
                                    target.RemoveEffect(CANNOT_TAKE_ACTIONS);
                                    return true;
                                });
                            } else if (roll <= 8) {
                                // Determine Melee Attack with longest reach
                                Attack longestReachAttack = null;
                                foreach (Attack meleeAttack in target.MeleeAttacks) {
                                    if (longestReachAttack == null || meleeAttack.Reach > longestReachAttack.Reach) {
                                        longestReachAttack = meleeAttack;
                                    }
                                }
                                // 7-8: melee attack against a randomly determined creature within reach
                                if (longestReachAttack != null) {
                                    int reach = longestReachAttack.Reach;
                                    Combatant[] inReach = new Combatant[0];
                                    foreach (Combatant other in ground.combatants) {
                                        if (other == target || other.HitPoints <= 0) continue;
                                        if (ground.Distance(target, other) <= reach) {
                                            Utils.Push<Combatant>(ref inReach, other);
                                        }
                                    }
                                    if (inReach.Length > 0) {
                                        Combatant attackTarget = inReach[Random.Get(0, inReach.Length - 1)];
                                        target.Attack(longestReachAttack, attackTarget, ground.Distance(target, attackTarget));
                                    }
                                }
                                target.AddEffect(CANNOT_TAKE_ACTIONS);
                                target.AddEndOfTurnEvent(delegate () {
                                    target.RemoveEffect(CANNOT_TAKE_ACTIONS);
                                    return true;
                                });
                            }
                            // 9-10: act and move normally — no restriction
                            return false;
                        });

                        // At the end of each turn, Wisdom save to end the effect
                        target.AddEndOfTurnEvent(delegate () {
                            if (!target.HasEffect(SPELL_CONFUSION)) return true;
                            if (target.DC(ID.CONFUSION, dc, WISDOM)) {
                                target.RemoveEffect(SPELL_CONFUSION);
                                return true;
                            }
                            return false;
                        });
                    }

                    // Remove effect from all targets after 1 minute
                    int remainingRounds = (int)ONE_MINUTE;
                    caster.AddEndOfTurnEvent(delegate () {
                        if (--remainingRounds < 1) {
                            foreach (Combatant t in targets) {
                                t.RemoveEffect(SPELL_CONFUSION);
                            }
                            return true;
                        }
                        return false;
                    });
                });
            }
        }
        /* TODO:
        You summon elementals that appear in unoccupied spaces that you can see within range. 
        You choose one the following options for what appears:
        - One elemental of challenge rating 2 or lower
        - Two elementals of challenge rating 1 or lower
        - Four elementals of challenge rating 1/2 or lower
        - Eight elementals of challenge rating 1/4 or lower.
        An elemental summoned by this spell disappears when it drops to 0 hit points or when the spell ends.
        The summoned creatures are friendly to you and your companions. 
        Roll initiative for the summoned creatures as a group, which has its own turns. 
        They obey any verbal commands that you issue to them (no action required by you). 
        If you don't issue any commands to them, they defend themselves from hostile creatures, but otherwise take no actions.
        */
        public static Spell ConjureMinorElementals {
            get {
                return new Spell(ID.CONJURE_MINOR_ELEMENTALS, CONJURATION, FOURTH, CastingTime.ONE_MINUTE, 90, VS, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO: 
        You summon fey creatures that appear in unoccupied spaces that you can see within range. 
        Choose one of the following options for what appears:
        - One fey creature of challenge rating 2 or lower
        - Two fey creatures of challenge rating 1 or lower
        - Four fey creatures of challenge rating 1/2 or lower
        - Eight fey creatures of challenge rating 1/4 or lower
        A summoned creature disappears when it drops to 0 hit points or when the spell ends.
        The summoned creatures are friendly to you and your companions. Roll initiative for the summoned creatures as a group, which have their own turns.
        They obey any verbal commands that you issue to them (no action required by you).
        If you don't issue any commands to them, they defend themselves from hostile creatures, but otherwise take no actions.      
        */
        public static Spell ConjureWoodlandBeings {
            get {
                return new Spell(ID.CONJURE_WOODLAND_BEINGS, CONJURATION, FOURTH, CastingTime.ONE_ACTION, 60, VSM, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO:
        Until the spell ends, you control any freestanding water inside an area you choose that is a cube up to 100 feet on a side. 
        You can choose from any of the following effects when you cast this spell. 
        As an action on your turn, you can repeat the same effect or choose a different one.
        Flood:
            You cause the water level of all standing water in the area to rise by as much as 20 feet. 
            If the area includes a shore, the flooding water spills over onto dry land.
            If you choose an area in a large body of water, you instead create a 20-foot tall wave that travels 
            from one side of the area to the other and then crashes down. 
            Any Huge or smaller vehicles in the wave's path are carried with it to the other side. 
            Any Huge or smaller vehicles struck by the wave have a 25 percent chance of capsizing.
            "The water level remains elevated until the spell ends or you choose a different effect. 
            If this effect produced a wave, the wave repeats on the start of your next turn while the flood effect lasts.
        Part Water:
            You cause water in the area to move apart and create a trench. 
            The trench extends across the spell's area, and the separated water forms a wall to either side. 
            The trench remains until the spell ends or you choose a different effect. 
            The water then slowly fills in the trench over the course of the next round until the normal water level is restored.
        Redirect Flow: 
            You cause flowing water in the area to move in a direction you choose, even if the water has to flow over obstacles, up walls, 
            or in other unlikely directions. The water in the area moves as you direct it, but once it moves beyond the spell's area, 
            it resumes its flow based on the terrain conditions. 
            The water continues to move in the direction you chose until the spell ends or you choose a different effect.
        Whirlpool:
            This effect requires a body of water at least 50 feet square and 25 feet deep. 
            You cause a whirlpool to form in the center of the area. 
            The whirlpool forms a vortex that is 5 feet wide at the base, up to 50 feet wide at the top, and 25 feet tall. 
            Any creature or object in the water and within 25 feet of the vortex is pulled 10 feet toward it. 
            A creature can swim away from the vortex by making a Strength (Athletics) check against your spell save DC.
            When a creature enters the vortex for the first time on a turn or starts its turn there, it must make a strength saving throw. 
            On a failed save, the creature takes 2d8 bludgeoning damage and is caught in the vortex until the spell ends. 
            On a successful save, the creature takes half damage, and isn't caught in the vortex. 
            A creature caught in the vortex can use its action to try to swim away from the vortex as described above, 
            but has disadvantage on the Strength (Athletics) check to do so.
            The first time each turn that an object enters the vortex, the object takes 2d8 bludgeoning damage; 
            this damage occurs each round it remains in the vortex.
         */
        public static Spell ControlWater {
            get {
                return new Spell(ID.CONTROL_WATER, TRANSMUTATION, FOURTH, CastingTime.ONE_ACTION, 300, VSM, TEN_MINUTES, 100, 0, doNothing);
            }
        }

        public static Spell DeathWard {
            get {
                return new Spell(ID.DEATH_WARD, ABJURATION, FOURTH, CastingTime.ONE_ACTION, 0, VSM, EIGHT_HOURS, 0, 0, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    Combatant target = targets[0];
                    AddEffectsForDuration(ID.DEATH_WARD, caster, target, EIGHT_HOURS, SPELL_DEATH_WARD);
                });
            }
        }
        /* TODO:
        You teleport yourself from your current location to any other spot within range. 
        You arrive at exactly the spot desired. It can be a place you can see, one you can visualize, 
        or one you can describe by stating distance and direction, such as "200 feet straight downward" 
        or "upward to the northwest at a 45- degree angle, 300 feet."
        You can bring along objects as long as their weight doesn't exceed what you can carry. 
        You can also bring one willing creature of your size or smaller who is carrying gear up to its carrying capacity. The creature must be within 5 feet of you when you cast this spell.
        If you would arrive in a place already occupied by an object or a creature, you and any creature traveling with you each take 4d6 force damage, and the spell fails to teleport you. 
        */
        public static Spell DimensionDoor {
            get {
                return new Spell(ID.DIMENSION_DOOR, CONJURATION, FOURTH, CastingTime.ONE_ACTION, 500, V, INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combatant caster, int dc, SpellLevel slot, int modifier, Combatant[] targets) {
                    // Optional companion: targets[0] may be the companion when cast via Battleground.SpellCastAction.
                    Combatant companion = null;
                    Target target = null;
                    foreach (Combatant combatant in targets) {
                        if (combatant is Target t) {
                            target = t;
                        } else {
                            companion = combatant;
                        }
                    }

                    if (target == null) {
                        throw new ArgumentException("Dimension Door requires a target to teleport to.");
                    }

                    // If destination is occupied by someone else, caster (and companion) take 4d6 force and spell fails
                    if (ground.IsOccupied(target.Location)) {
                        Dice damage = new Dice("4d6");
                        caster.TakeDamage(new DamageSource(ID.DIMENSION_DOOR, caster), FORCE, damage);
                        if (companion != null) companion.TakeDamage(new DamageSource(ID.DIMENSION_DOOR, caster), FORCE, damage);
                        GlobalEvents.AffectBySpell(caster, ID.DIMENSION_DOOR, caster, false);
                        return;
                    }

                    // Teleport caster and companion
                    ground.SetLocation(caster, target.Location);
                    GlobalEvents.AffectBySpell(caster, ID.DIMENSION_DOOR, caster, true);
                    if (companion != null) {
                        ground.SetLocation(companion, target.Location);
                        GlobalEvents.AffectBySpell(caster, ID.DIMENSION_DOOR, companion, true);
                    }
                });
            }
        }
        /* TODO */
        public static Spell Divination {
            get {
                return new Spell(ID.DIVINATION, DIVINATION, FOURTH, CastingTime.ONE_ACTION, 0, VSM, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell DominateBeast {
            get {
                return new Spell(ID.DOMINATE_BEAST, ENCHANTMENT, FOURTH, CastingTime.ONE_ACTION, 60, VS, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Fabricate {
            get {
                return new Spell(ID.FABRICATE, TRANSMUTATION, FOURTH, CastingTime.TEN_MINUTES, 120, VS, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell FaithfulHound {
            get {
                return new Spell(ID.FAITHFUL_HOUND, CONJURATION, FOURTH, CastingTime.ONE_ACTION, 30, VSM, EIGHT_HOURS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell FireShield {
            get {
                return new Spell(ID.FIRE_SHIELD, EVOCATION, FOURTH, CastingTime.ONE_ACTION, 0, VSM, TEN_MINUTES, 5, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell FreedomOfMovement {
            get {
                return new Spell(ID.FREEDOM_OF_MOVEMENT, ABJURATION, FOURTH, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell GiantInsect {
            get {
                return new Spell(ID.GIANT_INSECT, TRANSMUTATION, FOURTH, CastingTime.ONE_ACTION, 30, VS, TEN_MINUTES, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell GreaterInvisibility {
            get {
                return new Spell(ID.GREATER_INVISIBILITY, ILLUSION, FOURTH, CastingTime.ONE_ACTION, 0, VS, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell GuardianOfFaith {
            get {
                return new Spell(ID.GUARDIAN_OF_FAITH, CONJURATION, FOURTH, CastingTime.ONE_ACTION, 30, V, EIGHT_HOURS, 10, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell HallucinatoryTerrain {
            get {
                return new Spell(ID.HALLUCINATORY_TERRAIN, ILLUSION, FOURTH, CastingTime.TEN_MINUTES, 300, VSM, ONE_DAY, 150, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell IceStorm {
            get {
                return new Spell(ID.ICE_STORM, EVOCATION, FOURTH, CastingTime.ONE_ACTION, 300, VSM, INSTANTANEOUS, 20, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell LocateCreature {
            get {
                return new Spell(ID.LOCATE_CREATURE, DIVINATION, FOURTH, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PhantasmalKiller {
            get {
                return new Spell(ID.PHANTASMAL_KILLER, ILLUSION, FOURTH, CastingTime.ONE_ACTION, 120, VS, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Polymorph {
            get {
                return new Spell(ID.POLYMORPH, TRANSMUTATION, FOURTH, CastingTime.ONE_ACTION, 60, VSM, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell PrivateSanctum {
            get {
                return new Spell(ID.PRIVATE_SANCTUM, ABJURATION, FOURTH, CastingTime.TEN_MINUTES, 120, VSM, ONE_DAY, 100, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell ResilientSphere {
            get {
                return new Spell(ID.RESILIENT_SPHERE, EVOCATION, FOURTH, CastingTime.ONE_ACTION, 30, VSM, ONE_MINUTE, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell SecretChest {
            get {
                return new Spell(ID.SECRET_CHEST, CONJURATION, FOURTH, CastingTime.ONE_ACTION, 0, VSM, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell StoneShape {
            get {
                return new Spell(ID.STONE_SHAPE, TRANSMUTATION, FOURTH, CastingTime.ONE_ACTION, 0, VSM, INSTANTANEOUS, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell Stoneskin {
            get {
                return new Spell(ID.STONESKIN, ABJURATION, FOURTH, CastingTime.ONE_ACTION, 0, VSM, ONE_HOUR, 0, 0, doNothing);
            }
        }
        /* TODO */
        public static Spell WallOfFire {
            get {
                return new Spell(ID.WALL_OF_FIRE, EVOCATION, FOURTH, CastingTime.ONE_ACTION, 120, VSM, ONE_MINUTE, 60, 0, doNothing);
            }
        }
    }
}
namespace srd5 {
    public partial struct Attacks {
        public static readonly AttackEffect HalfRedDragonVeteranLongswordEffect = delegate (Combattant attacker, Combattant target) {
        };
        public static readonly Attack HalfRedDragonVeteranLongsword = new Attack("Longsword", 5, new Damage(DamageType.SLASHING, "1d10+3"), 5);
        public static readonly Attack HalfRedDragonVeteranShortsword = new Attack("Shortsword", 5, new Damage(DamageType.PIERCING, "1d6+3"), 5);
        public static readonly Attack HalfRedDragonVeteranHeavyCrossbow = new Attack("Heavy Crossbow", 3, new Damage(DamageType.PIERCING, "1d10+1"), 5, 100, 400);
        public static readonly Attack HarpyClaws = new Attack("Claws", 3, new Damage(DamageType.SLASHING, "2d4+1"), 5);
        public static readonly Attack HarpyClub = new Attack("Club", 3, new Damage(DamageType.BLUDGEONING, "1d4+1"), 5);
        public static readonly Attack HawkTalons = new Attack("Talons", 5, new Damage(DamageType.SLASHING, "1d1"), 5);
        public static readonly Attack HellHoundBite = new Attack("Bite", 5, new Damage(DamageType.PIERCING, "1d8+3"), 5, new Damage(DamageType.FIRE, "(2d6)"));
        public static readonly Attack HezrouBite = new Attack("Bite", 7, new Damage(DamageType.PIERCING, "2d10+4"), 5);
        public static readonly Attack HezrouClaws = new Attack("Claws", 7, new Damage(DamageType.SLASHING, "2d6+4"), 5);
        public static readonly Attack HillGiantGreatclub = new Attack("Greatclub", 8, new Damage(DamageType.BLUDGEONING, "3d8+5"), 10);
        public static readonly Attack HillGiantRock = new Attack("Rock", 8, new Damage(DamageType.BLUDGEONING, "3d10+5"), 5, 60, 240);
        public static readonly Attack HippogriffBeak = new Attack("Beak", 5, new Damage(DamageType.PIERCING, "1d10+3"), 5);
        public static readonly Attack HippogriffClaws = new Attack("Claws", 5, new Damage(DamageType.SLASHING, "2d6+3"), 5);
        public static readonly Attack HobgoblinLongsword = new Attack("Longsword", 3, new Damage(DamageType.SLASHING, "1d10+1"), 5);
        public static readonly Attack HobgoblinLongbow = new Attack("Longbow", 3, new Damage(DamageType.PIERCING, "1d8+1"), 5, 150, 600);
        public static readonly AttackEffect HomunculusBiteEffect = delegate (Combattant attacker, Combattant target) {
            if (target.IsImmune(DamageType.POISON)) return;
            int dc;
            if (target.DC(HomunculusBite, 10, AbilityType.CONSTITUTION, out dc)) return;
            if (dc < 6) {
                target.AddEffect(Effect.HOMUNCULUS_POISON_UNCONCIOUSNESS);
                int duration = Dice.D10.Value * 10;
                int turnsPassed = 0;
                target.AddEndOfTurnEvent(delegate (Combattant combattant) {
                    if (++turnsPassed > duration) {
                        combattant.RemoveEffect(Effect.HOMUNCULUS_POISON_UNCONCIOUSNESS);
                        return true;
                    }
                    return false;
                });
            } else {
                target.AddEffect(Effect.HOMUNCULUS_POISON);
                int turnsPassed = 0;
                target.AddEndOfTurnEvent(delegate (Combattant combattant) {
                    if (++turnsPassed > 10) {
                        combattant.RemoveEffect(Effect.HOMUNCULUS_POISON);
                        return true;
                    }
                    return false;
                });
            }
        };
        public static readonly Attack HomunculusBite = new Attack("Bite", 4, new Damage(DamageType.PIERCING, "1d1"), 5, null, HomunculusBiteEffect);
        public static readonly AttackEffect HornedDevilTailEffect = delegate (Combattant attacker, Combattant target) {
            // do not affect undead and constructs
            if (target is Monster) {
                Monster monster = (Monster)target;
                if (monster.Type == Monsters.Type.UNDEAD || monster.Type == Monsters.Type.CONSTRUCT) return;
            }
            if (target.DC(BeardedDevilGlaive, 17, AbilityType.CONSTITUTION)) return;
            // TODO: Any creature can take an action to stanch the wound with a successful DC 12 Wisdom (Medicine) check.
            // The wound also closes if the target receives magical healing.
            // add infernal wound affect if newly applied
            if (!target.HasEffect(Effect.INFERNAL_WOUND_HORNED_DEVIL)) {
                target.AddStartOfTurnEvent(delegate (Combattant combattant) {
                    foreach (Effect effect in combattant.Effects) {
                        if (effect != Effect.INFERNAL_WOUND_HORNED_DEVIL) continue;
                        combattant.TakeDamage(DamageType.TRUE_DAMAGE, "3d6");
                    }
                    return combattant.HasEffect(Effect.INFERNAL_WOUND_HORNED_DEVIL);
                });
            }
            // increase infernal wound stack by one
            target.AddEffect(Effect.INFERNAL_WOUND_HORNED_DEVIL);
        };
        public static readonly Attack HornedDevilTail = new Attack("Tail", 10, new Damage(DamageType.PIERCING, "1d8+6"), 5, null, HornedDevilTailEffect);
        public static readonly AttackEffect HornedDevilHurlFlameEffect = delegate (Combattant attacker, Combattant target) {
            // TODO: If the target is a flammable object that isn't being worn or carried, it also catches fire.
        };
        public static readonly Attack HornedDevilHurlFlame = new Attack("Hurl Flame", 7, new Damage(DamageType.FIRE, "4d6"), 150, 150, null, HornedDevilHurlFlameEffect);
        public static readonly Attack HornedDevilFork = new Attack("Fork", 10, new Damage(DamageType.PIERCING, "2d8+6"), 10);
        public static readonly Attack HunterSharkBite = new Attack("Bite", 6, new Damage(DamageType.PIERCING, "2d8+4"), 5);
        public static readonly Attack HydraBite = new Attack("Bite", 8, new Damage(DamageType.PIERCING, "1d10+5"), 10);
        public static readonly Attack HyenaBite = new Attack("Bite", 2, new Damage(DamageType.PIERCING, "1d6"), 5);
    }
}
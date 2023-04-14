namespace srd5 {
    public partial struct Attacks {
        public static readonly AttackEffect DarkmantleCrushEffect = delegate (Combattant attacker, Combattant target) {
            if (target.Size > Size.MEDIUM) return;
            if (attacker.HasEffect(Effect.ATTACHED_TO_TARGET)) return;
            attacker.AddEffect(Effect.ATTACHED_TO_TARGET);
            attacker.AddEffect(Effect.ADVANTAGE_ON_ATTACK);
            foreach (Attack attack in attacker.MeleeAttacks) {
                attack.LockedTarget = target;
            }
            target.AddCondition(ConditionType.BLINDED);
            target.AddEffect(Effect.UNABLE_TO_BREATHE);
        };
        public static readonly Attack DarkmantleCrush = new Attack("Crush", 5, new Damage(DamageType.BLUDGEONING, "1d6+3"), 5, null, DarkmantleCrushEffect);
        public static readonly AttackEffect DeathDogBiteEffect = delegate (Combattant attacker, Combattant target) {
            if (target.DC(DeathDogBite, 12, AbilityType.CONSTITUTION)) return;
            target.AddCondition(ConditionType.POISONED);
            target.AddEffect(Effect.DEATH_DOG_DISEASE);
        };
        public static readonly Attack DeathDogBite = new Attack("Bite", 4, new Damage(DamageType.PIERCING, "1d4+2"), 5, null, DeathDogBiteEffect);
        public static readonly AttackEffect DeepGnomeSvirfneblinPoisonedDartEffect = delegate (Combattant attacker, Combattant target) {
            if (target.DC(DeepGnomeSvirfneblinPoisonedDart, 12, AbilityType.CONSTITUTION)) return;
            target.AddCondition(ConditionType.POISONED);
            int turn = 0;
            target.AddEndOfTurnEvent(delegate (Combattant combattant) {
                if (turn++ > 9 || combattant.DC(DeepGnomeSvirfneblinPoisonedDart, 12, AbilityType.CONSTITUTION)) {
                    combattant.RemoveCondition(ConditionType.POISONED);
                    return true;
                }
                return false;
            });
        };
        public static readonly Attack DeepGnomeSvirfneblinPoisonedDart = new Attack("Poisoned Dart", 4, new Damage(DamageType.PIERCING, "1d6+0"), 5, null, DeepGnomeSvirfneblinPoisonedDartEffect);
        public static readonly Attack DeepGnomeSvirfneblinWarPick = new Attack("War Pick", 4, new Damage(DamageType.PIERCING, "1d8+2"), 5);
        public static readonly Attack DeerBite = new Attack("Bite", 2, new Damage(DamageType.PIERCING, "1d4"), 5);
        public static readonly Attack DevaMace = new Attack("Mace", 8, new Damage(DamageType.BLUDGEONING, "1d6+4"), 5, new Damage(DamageType.RADIANT, "4d8"));
        public static readonly AttackEffect DireWolfBiteEffect = delegate (Combattant attacker, Combattant target) {
            if (target.DC(DireWolfBite, 13, AbilityType.STRENGTH)) return;
            target.AddCondition(ConditionType.PRONE);
        };
        public static readonly Attack DireWolfBite = new Attack("Bite", 5, new Damage(DamageType.PIERCING, "2d6+3"), 5, null, DireWolfBiteEffect);
        public static readonly AttackEffect DjinniScimitarEffect = delegate (Combattant attacker, Combattant target) {
            if (Dice.D20.Value > 10) {
                target.TakeDamage(DamageType.LIGHTNING, Dice.D6.Value);
            } else {
                target.TakeDamage(DamageType.THUNDER, Dice.D6.Value);
            }
        };
        public static readonly Attack DjinniScimitar = new Attack("Scimitar", 9, new Damage(DamageType.SLASHING, "2d6+5"), 5, null, DjinniScimitarEffect);
        public static readonly Attack DoppelgangerSlam = new Attack("Slam", 6, new Damage(DamageType.BLUDGEONING, "1d6+4"), 5);
        public static readonly Attack DraftHorseHooves = new Attack("Hooves", 6, new Damage(DamageType.BLUDGEONING, "2d4+4"), 5);
        public static readonly AttackEffect DragonTurtleTailEffect = delegate (Combattant attacker, Combattant target) {
            if (target.DC(DragonTurtleTail, 20, AbilityType.STRENGTH)) return;
            target.AddCondition(ConditionType.PRONE);
            // TODO: Push 10ft away
        };
        public static readonly Attack DragonTurtleTail = new Attack("Tail", 13, new Damage(DamageType.BLUDGEONING, "3d12+7"), 5, null, DragonTurtleTailEffect);
        public static readonly Attack DragonTurtleBite = new Attack("Bite", 13, new Damage(DamageType.PIERCING, "3d12+7"), 15);
        public static readonly Attack DragonTurtleClaw = new Attack("Claw", 13, new Damage(DamageType.SLASHING, "2d8+7"), 10);
        public static readonly Attack DretchBite = new Attack("Bite", 2, new Damage(DamageType.PIERCING, "1d6"), 5);
        public static readonly Attack DretchClaws = new Attack("Claws", 2, new Damage(DamageType.SLASHING, "2d4"), 5);
        public static readonly Attack DriderLongsword = new Attack("Longsword", 6, new Damage(DamageType.SLASHING, "1d8+3"), 5);
        public static readonly Attack DriderLongbow = new Attack("Longbow", 6, new Damage(DamageType.PIERCING, "1d8+3"), 150, 600, new Damage(DamageType.POISON, "1d8"));
        public static readonly Attack DriderBite = new Attack("Bite", 6, new Damage(DamageType.PIERCING, "1d4"), 5, new Damage(DamageType.POISON, "2d8"));
        public static readonly AttackEffect DrowHandCrossbowEffect = delegate (Combattant attacker, Combattant target) {
            int value;
            if (target.IsImmune(DamageType.POISON)) return;
            if (target.DC(DrowHandCrossbow, 13, AbilityType.CONSTITUTION, out value)) return;
            target.AddEffect(Effect.DROW_POISON);
            if (value < 9) {
                target.AddCondition(ConditionType.UNCONSCIOUS);
            }
            target.AddDamageTakenEvent(delegate (Combattant combattant) {
                if (!target.HasEffect(Effect.DROW_POISON)) return true;
                target.RemoveEffect(Effect.DROW_POISON);
                target.RemoveCondition(ConditionType.UNCONSCIOUS);
                return true;
            });
        };
        public static readonly Attack DrowHandCrossbow = new Attack("Hand Crossbow", 4, new Damage(DamageType.PIERCING, "1d6+2"), 30, 120, null, DrowHandCrossbowEffect);
        public static readonly Attack DrowShortsword = new Attack("Shortsword", 4, new Damage(DamageType.PIERCING, "1d6+2"), 5);
        public static readonly Attack DruidQuarterstaff = new Attack("Quarterstaff", 2, new Damage(DamageType.BLUDGEONING, "1d6"), 5);
        public static readonly Attack DryadClub = new Attack("Club", 2, new Damage(DamageType.BLUDGEONING, "1d4"), 5);
        public static readonly Attack DuergarWarPick = new Attack("War Pick", 4, new Damage(DamageType.PIERCING, "1d8+2"), 5);
        public static readonly Attack DuergarJavelin = new Attack("Javelin", 4, new Damage(DamageType.PIERCING, "1d6+2"), 5);
        public static readonly Attack DuergarJavelinRanged = new Attack("Javelin", 4, new Damage(DamageType.PIERCING, "1d6+2"), 30, 120);
        public static readonly Attack DustMephitClaws = new Attack("Claws", 4, new Damage(DamageType.SLASHING, "1d4+2"), 5);

    }
}
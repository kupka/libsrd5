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
        // !!!!!!!!!!!!!!!!!!!!!!UNPARSABLE ATTACK!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // DevaMace
        // {"name":"Mace","desc":"Melee Weapon Attack: +8 to hit, reach 5 ft., one target. Hit: 7 (1d6 + 4) bludgeoning damage plus 18 (4d8) radiant damage.","attack_bonus":8,"damage":[{"damage_type":{"index":"bludgeoning","name":"Bludgeoning","url":"/api/damage-types/bludgeoning"},"damage_dice":"1d6+4"},{"damage_type":{"index":"radiant","name":"Radiant","url":"/api/damage-types/radiant"},"damage_dice":"4d8"}]}
        public static readonly AttackEffect DevaMaceEffect = delegate (Combattant attacker, Combattant target) {
        };
        public static readonly Attack DevaMace = new Attack("Mace", 8, new Damage(DamageType.BLUDGEONING, "1d6+4"), 5, null, DevaMaceEffect);
        // !!!!!!!!!!!!!!!!!!!!!!UNPARSABLE ATTACK!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // DireWolfBite
        // {"name":"Bite","desc":"Melee Weapon Attack: +5 to hit, reach 5 ft., one target. Hit: 10 (2d6 + 3) piercing damage. If the target is a creature, it must succeed on a DC 13 Strength saving throw or be knocked prone.","attack_bonus":5,"damage":[{"damage_type":{"index":"piercing","name":"Piercing","url":"/api/damage-types/piercing"},"damage_dice":"2d6+3"}]}
        public static readonly AttackEffect DireWolfBiteEffect = delegate (Combattant attacker, Combattant target) {
        };
        public static readonly Attack DireWolfBite = new Attack("Bite", 5, new Damage(DamageType.PIERCING, "2d6+3"), 5, null, DireWolfBiteEffect);
        // !!!!!!!!!!!!!!!!!!!!!!UNPARSABLE ATTACK!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // DjinniScimitar
        // {"name":"Scimitar","desc":"Melee Weapon Attack: +9 to hit, reach 5 ft., one target. Hit: 12 (2d6 + 5) slashing damage plus 3 (1d6) lightning or thunder damage (djinni's choice).","attack_bonus":9,"damage":[{"damage_type":{"index":"slashing","name":"Slashing","url":"/api/damage-types/slashing"},"damage_dice":"2d6+5"},{"choose":1,"type":"damage","from":{"option_set_type":"options_array","options":[{"option_type":"damage","damage_type":{"index":"lightning","name":"Lightning","url":"/api/damage-types/lightning"},"damage_dice":"1d6"},{"option_type":"damage","damage_type":{"index":"thunder","name":"Thunder","url":"/api/damage-types/thunder"},"damage_dice":"1d6"}]}}]}
        public static readonly AttackEffect DjinniScimitarEffect = delegate (Combattant attacker, Combattant target) {
        };
        public static readonly Attack DjinniScimitar = new Attack("Scimitar", 9, new Damage(DamageType.SLASHING, "2d6+5"), 5, null, DjinniScimitarEffect);
        public static readonly Attack DoppelgangerSlam = new Attack("Slam", 6, new Damage(DamageType.BLUDGEONING, "1d6+4"), 5);
        public static readonly Attack DraftHorseHooves = new Attack("Hooves", 6, new Damage(DamageType.BLUDGEONING, "2d4+4"), 5);
        // !!!!!!!!!!!!!!!!!!!!!!UNPARSABLE ATTACK!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // DragonTurtleTail
        // {"name":"Tail","desc":"Melee Weapon Attack: +13 to hit, reach 15 ft., one target. Hit: 26 (3d12 + 7) bludgeoning damage. If the target is a creature, it must succeed on a DC 20 Strength saving throw or be pushed up to 10 feet away from the dragon turtle and knocked prone.","attack_bonus":13,"damage":[{"damage_type":{"index":"bludgeoning","name":"Bludgeoning","url":"/api/damage-types/bludgeoning"},"damage_dice":"3d12+7"}]}
        public static readonly AttackEffect DragonTurtleTailEffect = delegate (Combattant attacker, Combattant target) {
        };
        public static readonly Attack DragonTurtleTail = new Attack("Tail", 13, new Damage(DamageType.BLUDGEONING, "3d12+7"), 5, null, DragonTurtleTailEffect);
        public static readonly Attack DragonTurtleBite = new Attack("Bite", 13, new Damage(DamageType.PIERCING, "3d12+7"), 15);
        public static readonly Attack DragonTurtleClaw = new Attack("Claw", 13, new Damage(DamageType.SLASHING, "2d8+7"), 10);
        public static readonly Attack DretchBite = new Attack("Bite", 2, new Damage(DamageType.PIERCING, "1d6"), 5);
        public static readonly Attack DretchClaws = new Attack("Claws", 2, new Damage(DamageType.SLASHING, "2d4"), 5);
        // !!!!!!!!!!!!!!!!!!!!!!UNPARSABLE ATTACK!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // DriderLongsword
        // {"name":"Longsword","desc":"Melee Weapon Attack: +6 to hit, reach 5 ft., one target. Hit: 7 (1d8 + 3) slashing damage, or 8 (1d10 + 3) slashing damage if used with two hands.","attack_bonus":6,"damage":[{"choose":1,"type":"damage","from":{"option_set_type":"options_array","options":[{"option_type":"damage","damage_type":{"index":"slashing","name":"Slashing","url":"/api/damage-types/slashing"},"damage_dice":"1d8+3","notes":"One handed"},{"option_type":"damage","damage_type":{"index":"slashing","name":"Slashing","url":"/api/damage-types/slashing"},"damage_dice":"1d10+3","notes":"Two handed"}]}}]}
        public static readonly AttackEffect DriderLongswordEffect = delegate (Combattant attacker, Combattant target) {
        };
        public static readonly Attack DriderLongsword = new Attack("Longsword", 6, new Damage(DamageType.SLASHING, "1d8+3"), 5, null, DriderLongswordEffect);
        public static readonly AttackEffect DriderLongbowEffect = delegate (Combattant attacker, Combattant target) {
        };
        public static readonly Attack DriderLongbow = new Attack("Longbow", 6, new Damage(DamageType.PIERCING, "1d8+3"), 150, 600, new Damage(DamageType.POISON, "1d8"), DriderLongbowEffect);
        public static readonly Attack DriderBite = new Attack("Bite", 6, new Damage(DamageType.PIERCING, "1d4"), 5, new Damage(DamageType.POISON, "2d8"));
        // !!!!!!!!!!!!!!!!!!!!!!UNPARSABLE ATTACK!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // DrowHandCrossbow
        // {"name":"Hand Crossbow","desc":"Ranged Weapon Attack: +4 to hit, range 30/120 ft., one target. Hit: 5 (1d6 + 2) piercing damage, and the target must succeed on a DC 13 Constitution saving throw or be poisoned for 1 hour. If the saving throw fails by 5 or more, the target is also unconscious while poisoned in this way. The target wakes up if it takes damage or if another creature takes an action to shake it awake.","attack_bonus":4,"damage":[{"damage_type":{"index":"piercing","name":"Piercing","url":"/api/damage-types/piercing"},"damage_dice":"1d6+2"}]}
        public static readonly AttackEffect DrowHandCrossbowEffect = delegate (Combattant attacker, Combattant target) {
        };
        public static readonly Attack DrowHandCrossbow = new Attack("Hand Crossbow", 4, new Damage(DamageType.PIERCING, "1d6+2"), 30, 120, null, DrowHandCrossbowEffect);
        public static readonly Attack DrowShortsword = new Attack("Shortsword", 4, new Damage(DamageType.PIERCING, "1d6+2"), 5);
        // !!!!!!!!!!!!!!!!!!!!!!UNPARSABLE ATTACK!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // DruidQuarterstaff
        // {"name":"Quarterstaff","desc":" Melee Weapon Attack: +2 to hit (+4 to hit with shillelagh), reach 5 ft., one target. Hit: 3 (1d6) bludgeoning damage, 4 (1d8) bludgeoning damage if wielded with two hands, or 6 (1d8 + 2) bludgeoning damage with shillelagh.","attack_bonus":2,"damage":[{"choose":1,"type":"damage","from":{"option_set_type":"options_array","options":[{"option_type":"damage","damage_type":{"index":"bludgeoning","name":"Bludgeoning","url":"/api/damage-types/bludgeoning"},"damage_dice":"1d6","notes":"One handed"},{"option_type":"damage","damage_type":{"index":"bludgeoning","name":"Bludgeoning","url":"/api/damage-types/bludgeoning"},"damage_dice":"1d8","notes":"Two handed"},{"option_type":"damage","damage_type":{"index":"bludgeoning","name":"Bludgeoning","url":"/api/damage-types/bludgeoning"},"damage_dice":"1d8+2","notes":"With shillelagh"}]}}]}
        public static readonly AttackEffect DruidQuarterstaffEffect = delegate (Combattant attacker, Combattant target) {
        };
        public static readonly Attack DruidQuarterstaff = new Attack("Quarterstaff", 2, new Damage(DamageType.BLUDGEONING, "1d6"), 5, null, DruidQuarterstaffEffect);
        // !!!!!!!!!!!!!!!!!!!!!!UNPARSABLE ATTACK!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // DryadClub
        // {"name":"Club","desc":"Melee Weapon Attack: +2 to hit (+6 to hit with shillelagh), reach 5 ft., one target. Hit: 2 (1 d4) bludgeoning damage, or 8 (1d8 + 4) bludgeoning damage with shillelagh.","attack_bonus":2,"damage":[{"damage_type":{"index":"bludgeoning","name":"Bludgeoning","url":"/api/damage-types/bludgeoning"},"damage_dice":"1d4"}]}
        public static readonly AttackEffect DryadClubEffect = delegate (Combattant attacker, Combattant target) {
        };
        public static readonly Attack DryadClub = new Attack("Club", 2, new Damage(DamageType.BLUDGEONING, "1d4"), 5, null, DryadClubEffect);
        // !!!!!!!!!!!!!!!!!!!!!!UNPARSABLE ATTACK!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // DuergarWarPick
        // {"name":"War Pick","desc":"Melee Weapon Attack: +4 to hit, reach 5 ft., one target. Hit: 6 (1d8 + 2) piercing damage, or 11 (2d8 + 2) piercing damage while enlarged.","attack_bonus":4,"damage":[{"damage_type":{"index":"piercing","name":"Piercing","url":"/api/damage-types/piercing"},"damage_dice":"1d8+2"}]}
        public static readonly AttackEffect DuergarWarPickEffect = delegate (Combattant attacker, Combattant target) {
        };
        public static readonly Attack DuergarWarPick = new Attack("War Pick", 4, new Damage(DamageType.PIERCING, "1d8+2"), 5, null, DuergarWarPickEffect);
        // !!!!!!!!!!!!!!!!!!!!!!UNPARSABLE ATTACK!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // DuergarJavelin
        // {"name":"Javelin","desc":"Melee or Ranged Weapon Attack: +4 to hit, reach 5 ft. or range 30/120 ft., one target. Hit: 5 (1d6 + 2) piercing damage, or 9 (2d6 + 2) piercing damage while enlarged.","attack_bonus":4,"damage":[{"damage_type":{"index":"bludgeoning","name":"Bludgeoning","url":"/api/damage-types/bludgeoning"},"damage_dice":"1d6+2"}]}
        public static readonly AttackEffect DuergarJavelinEffect = delegate (Combattant attacker, Combattant target) {
        };
        public static readonly Attack DuergarJavelin = new Attack("Javelin", 4, new Damage(DamageType.PIERCING, "1d6+2"), 5, null, DuergarJavelinEffect);
        public static readonly Attack DuergarJavelinRanged = new Attack("Javelin", 4, new Damage(DamageType.PIERCING, "1d6+2"), 30, 120, null, DuergarJavelinEffect);
        public static readonly Attack DustMephitClaws = new Attack("Claws", 4, new Damage(DamageType.SLASHING, "1d4+2"), 5);

    }
}
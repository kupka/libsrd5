namespace d20 {
    public enum ConditionType {
        BLINDED, // Disadvantage on attacks, Advantage on being attacked
        CHARMED, // Cannot attack source of charm
        DEAFENED, // Fail hearing checks
        EXHAUSTED_1, // Disadvantage on all ability checks
        EXHAUSTED_2, // Speed halved
        EXHAUSTED_3, // Disadvantage on attack and save
        EXHAUSTED_4, // Max HPs halved
        EXHAUSTED_5, // Speed = 0
        EXHAUSTED_6, // Death
        FRIGHTENED, // Disadvantage on ability and attack when source is close, cannot approach source
        GRAPPLED, // Speed = 0
        INCAPACITATED, // Cannot take actions and reactions
        INVISIBLE, // Advantage on attacks, Disadvantage on being attacked
        PARALYZED, // Incapacitated & fail STR/DEX checks, advantage on being attacked, takes auto crits
        PETRIFIED, // Incapacitated & fail STR/DEX checks, advantage on being attacked,
                   // resistance against all damage, immune against poison and disease
        POISONED,  // Disadvantage on ability and attack
        PRONE, // Disadvantage on attack, Advantage on being melee attacked, Disadvantage on being ranged attacked
        RESTRAINED, // Speed = 0, Disadvantage on attacks, Advantage on being attacked, Disadvantage on DEX saves
        STUNNED, // Incapacitated & fail STR/DEX checks, Advantage on being attacked
        UNCONSCIOUS // Paralyzed & Fully Disarmed
    }
}
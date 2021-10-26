namespace srd5 {
    public enum Feat {
        NONE,
        // Racial Feats
        // Dwarves
        DWARVEN_ABILITY_INCREASE,
        DWARVEN_DARKVISION,
        DWARVEN_RESILIENCE,
        DWARVEN_SMITH,
        DWARVEN_BREWER,
        DWARVEN_MASON,
        DWARVEN_COMBAT_TRAINING,
        STONECUNNING,
        HILL_DWARVEN_ABILITY_INCREASE,
        DWARVEN_TOUGHNESS,
        // Elves
        ELVEN_ABILITY_INCREASE,
        ELVEN_DARKVISION,
        KEEN_SENSES,
        FEY_ANCESTRY,
        HIGH_ELVEN_ABILITY_INCREASE,
        HIGH_ELVEN_WEAPON_TRAINING,
        HIGH_ELVEN_CANTRIP,
        // Humans
        HUMAN_ABILITY_INCREASE,

        // Class Feats
        // Barbarian
        RAGE,
        UNARMORED_DEFENSE,
        RECKLESS_ATTACK,
        DANGER_SENSE,
        FRENZY,

    }

    public static class FeatExtension {
        public static void Apply(this Feat feat, CharacterSheet sheet) {
            switch (feat) {
                case Feat.DWARVEN_ABILITY_INCREASE:
                    sheet.Constitution.BaseValue += 2;
                    break;
                case Feat.DWARVEN_DARKVISION:
                case Feat.ELVEN_DARKVISION:
                    sheet.AddEffect(Effect.DARKVISION);
                    break;
                case Feat.DWARVEN_RESILIENCE:
                    sheet.AddEffect(Effect.RESISTANCE_POISON);
                    sheet.AddEffect(Effect.ADVANTAGE_SAVE_POISON);
                    break;
                case Feat.DWARVEN_SMITH:
                    sheet.AddProficiency(Proficiency.SMITH);
                    break;
                case Feat.DWARVEN_BREWER:
                    sheet.AddProficiency(Proficiency.BREWER);
                    break;
                case Feat.DWARVEN_MASON:
                    sheet.AddProficiency(Proficiency.MASON);
                    break;
                case Feat.DWARVEN_COMBAT_TRAINING:
                    sheet.AddProficiency(Proficiency.BATTLEAXE);
                    sheet.AddProficiency(Proficiency.HANDAXE);
                    sheet.AddProficiency(Proficiency.LIGHT_HAMMER);
                    sheet.AddProficiency(Proficiency.WARHAMMER);
                    sheet.AddEffect(Effect.NO_SPEED_PENALITY_FOR_HEAVY_ARMOR);
                    break;
                case Feat.STONECUNNING:
                    sheet.AddProficiency(Proficiency.HISTORY);
                    sheet.AddEffect(Effect.DOUBLE_PROFICIENCY_BONUS_HISTORY);
                    break;
                case Feat.HILL_DWARVEN_ABILITY_INCREASE:
                    sheet.Wisdom.BaseValue += 1;
                    break;
                case Feat.DWARVEN_TOUGHNESS:
                    sheet.AddEffect(Effect.ADDITIONAL_HP_PER_LEVEL);
                    break;
                case Feat.ELVEN_ABILITY_INCREASE:
                    sheet.Dexterity.BaseValue += 2;
                    break;
                case Feat.KEEN_SENSES:
                    sheet.AddProficiency(Proficiency.PERCEPTION);
                    break;
                case Feat.FEY_ANCESTRY:
                    sheet.AddEffect(Effect.IMMUNITY_SLEEP);
                    sheet.AddEffect(Effect.ADVANTAGE_SAVE_CHARM);
                    break;
                case Feat.HIGH_ELVEN_ABILITY_INCREASE:
                    sheet.Intelligence.BaseValue += 1;
                    break;
                case Feat.HIGH_ELVEN_WEAPON_TRAINING:
                    sheet.AddProficiency(Proficiency.SHORTBOW);
                    sheet.AddProficiency(Proficiency.SHORTSWORD);
                    sheet.AddProficiency(Proficiency.LONGBOW);
                    sheet.AddProficiency(Proficiency.LONGSWORD);
                    break;
                case Feat.HIGH_ELVEN_CANTRIP:
                    break;
                case Feat.HUMAN_ABILITY_INCREASE:
                    sheet.Strength.BaseValue++;
                    sheet.Constitution.BaseValue++;
                    sheet.Dexterity.BaseValue++;
                    sheet.Wisdom.BaseValue++;
                    sheet.Intelligence.BaseValue++;
                    sheet.Charisma.BaseValue++;
                    break;
            }
        }
    }
}
namespace srd5 {
    public enum FeatType {
        RACIAL,
        CLASS,
        COMMON
    }
    public class DwarvenAbilityIncrease : RacialFeat {

        public override void Apply(CharacterSheet sheet) {
            sheet.Constitution.Value += 2;
            sheet.Wisdom.Value += 1;
        }
    }

    public class Darkvision : RacialFeat {
        public override void Apply(CharacterSheet sheet) {
            sheet.AddEffect(Effect.DARKVISION);
        }
    }

    public class DwarvenResilience : RacialFeat {
        public override void Apply(CharacterSheet sheet) {
            sheet.AddEffect(Effect.RESISTANCE_POISON);
            sheet.AddEffect(Effect.ADVANTAGE_SAVE_POISON);
        }
    }

    public class DwarvenSmith : RacialFeat {
        public override void Apply(CharacterSheet sheet) {
            sheet.AddProficiency(Proficiency.SMITH);
        }
    }

    public class DwarvenBrewer : RacialFeat {
        public override void Apply(CharacterSheet sheet) {
            sheet.AddProficiency(Proficiency.BREWER);
        }
    }

    public class DwarvenMason : RacialFeat {
        public override void Apply(CharacterSheet sheet) {
            sheet.AddProficiency(Proficiency.MASON);
        }
    }

    public class DwarvenCombatTraining : RacialFeat {
        public override void Apply(CharacterSheet sheet) {
            sheet.AddProficiency(Proficiency.BATTLEAXE);
            sheet.AddProficiency(Proficiency.HANDAXE);
            sheet.AddProficiency(Proficiency.LIGHT_HAMMER);
            sheet.AddProficiency(Proficiency.WARHAMMER);
        }
    }

    public class Stonecunning : RacialFeat {
        public override void Apply(CharacterSheet sheet) {
            sheet.AddProficiency(Proficiency.HISTORY);
            sheet.AddEffect(Effect.DOUBLE_PROFICIENCY_BONUS_HISTORY);
        }
    }

    public class DwarvenToughness : RacialFeat {
        public override void Apply(CharacterSheet sheet) {
            sheet.AddEffect(Effect.ADDITIONAL_HP_PER_LEVEL);
        }
    }

    public class ElvenAbilityIncrease : RacialFeat {
        public override void Apply(CharacterSheet sheet) {
            sheet.Dexterity.Value += 2;
            sheet.Intelligence.Value += 1;
        }
    }

    public class KeenSenses : RacialFeat {
        public override void Apply(CharacterSheet sheet) {
            sheet.AddProficiency(Proficiency.PERCEPTION);
        }
    }

    public class FeyAncestry : RacialFeat {
        public override void Apply(CharacterSheet sheet) {
            sheet.AddEffect(Effect.IMMUNITY_SLEEP);
            sheet.AddEffect(Effect.ADVANTAGE_SAVE_CHARM);
        }
    }

    public class ElvenWeaponTraining : RacialFeat {
        public override void Apply(CharacterSheet sheet) {
            sheet.AddProficiency(Proficiency.SHORTBOW);
            sheet.AddProficiency(Proficiency.SHORTSWORD);
            sheet.AddProficiency(Proficiency.LONGBOW);
            sheet.AddProficiency(Proficiency.LONGSWORD);
        }
    }

    public class Cantrip : RacialFeat { }

    public class RacialFeats {
        public static readonly DwarvenAbilityIncrease DwarvenAbilityIncrease = new DwarvenAbilityIncrease();
        public static readonly Darkvision Darkvision = new Darkvision();
        public static readonly DwarvenResilience DwarvenResilience = new DwarvenResilience();
        public static readonly DwarvenCombatTraining DwarvenCombatTraining = new DwarvenCombatTraining();
        public static readonly DwarvenSmith DwarvenSmith = new DwarvenSmith();
        public static readonly DwarvenBrewer DwarvenBrewer = new DwarvenBrewer();
        public static readonly DwarvenMason DwarvenMason = new DwarvenMason();
        public static readonly Stonecunning Stonecunning = new Stonecunning();
        public static readonly DwarvenToughness DwarvenToughness = new DwarvenToughness();
        public static readonly ElvenAbilityIncrease ElvenAbilityIncrease = new ElvenAbilityIncrease();
        public static readonly KeenSenses KeenSenses = new KeenSenses();
        public static readonly FeyAncestry FeyAncestry = new FeyAncestry();
        public static readonly ElvenWeaponTraining ElvenWeaponTraining = new ElvenWeaponTraining();
        public static readonly Cantrip Cantrip = new Cantrip();
    }
}
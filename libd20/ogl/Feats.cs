namespace d20 {
    public enum FeatType {
        RACIAL,
        CLASS,
        COMMON
    }
    public class DwarvenConstitution : RacialFeat {

        public override void Apply(CharacterSheet sheet) {
            sheet.Constitution.Value += 2;
        }
    }

    public class DarkVision : RacialFeat { }

    public class DwarvenCombatTraining : RacialFeat {
        public override void Apply(CharacterSheet sheet) {
            sheet.AddProficiency(Proficiency.BATTLEAXE);
            sheet.AddProficiency(Proficiency.HANDAXE);
            sheet.AddProficiency(Proficiency.LIGHT_HAMMER);
            sheet.AddProficiency(Proficiency.WARHAMMER);
        }
    }

    public class RacialFeats {
        public static readonly DwarvenConstitution DwarvenConstitution = new DwarvenConstitution();
        public static readonly DarkVision DarkVision = new DarkVision();
        public static readonly DwarvenCombatTraining DwarvenCombatTraining = new DwarvenCombatTraining();
    }
}
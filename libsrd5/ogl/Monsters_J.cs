namespace srd5 {
    public partial struct Attacks {
        public static readonly Attack JackalBite = new Attack("Bite", 1, new Damage(DamageType.PIERCING, "1d4-1"), 5);
    }

    public partial struct Monsters {
        /* TODO */
        public static Monster Jackal {
            get {
                Monster jackal = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.JACKAL, Alignment.UNALIGNED, 8, 15, 11, 3, 12, 6, 12, "1d6", 40, 0,
                    new Attack[] { Attacks.JackalBite }, new Attack[] { }, Size.SMALL
                );
                jackal.AddProficiency(Proficiency.PERCEPTION);
                jackal.AddFeat(Feat.KEEN_HEARING_AND_SMELL);
                jackal.AddFeat(Feat.PACK_TACTICS);
                return jackal;
            }
        }
    }
}
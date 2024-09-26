namespace srd5 {
    public partial struct Attacks {
        public static readonly Attack XornBite = new Attack("Bite", 6, new Damage(DamageType.PIERCING, "3d6+3"), 5);
        public static readonly Attack XornClaw = new Attack("Claw", 6, new Damage(DamageType.SLASHING, "1d6+3"), 5);
    }

    public partial struct Monsters {
        /* TODO */
        public static Monster Xorn {
            get {
                Monster xorn = new Monster(
                    Monsters.Type.ELEMENTAL, Monsters.ID.XORN, Alignment.NEUTRAL, 17, 10, 22, 11, 10, 11, 19, "7d8+42", 40, 5,
                    new Attack[] { Attacks.XornBite, Attacks.XornClaw }, new Attack[] { }, Size.MEDIUM
                );
                xorn.AddProficiency(Proficiency.PERCEPTION);
                xorn.AddProficiency(Proficiency.STEALTH);
                xorn.AddEffect(Effect.RESISTANCE_NONMAGIC);
                xorn.AddFeat(Feat.EARTH_GLIDE);
                xorn.AddFeat(Feat.STONE_CAMOUFLAGE);
                xorn.AddFeat(Feat.TREASURE_SENSE);
                return xorn;
            }
        }
    }

}
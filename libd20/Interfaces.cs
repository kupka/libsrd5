namespace d20 {
    public abstract class Combattant {
        public int ArmorClass { get; internal set; }
        public int HitPoints { get; set; }
        public int HitPointsMax { get; internal set; }
    }
}
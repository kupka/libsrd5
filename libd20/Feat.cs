namespace d20 {
    public abstract class Feat {
        public override bool Equals(object obj) {
            if (obj == null) return false;
            return this.GetType().Name == obj.GetType().Name;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public abstract FeatType Type { get; }
        public abstract void Apply(CharacterSheet sheet);
    }

    public abstract class RacialFeat : Feat {
        public override FeatType Type {
            get {
                return FeatType.RACIAL;
            }
        }

        public override void Apply(CharacterSheet sheet) {

        }
    }
}
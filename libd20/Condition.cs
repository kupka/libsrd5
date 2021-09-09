namespace d20 {
    public abstract class Condition {
        public ConditionType Type { get; internal set; }

        public Condition(ConditionType type) {
            Type = type;
        }

        public abstract void Apply(CharacterSheet sheet);

        public abstract void Unapply(CharacterSheet sheet);

        public override int GetHashCode() {
            return (int)Type;
        }

        public override bool Equals(object obj) {
            if (obj == null) return false;
            return this.GetHashCode() == obj.GetHashCode();
        }
    }
}
namespace srd5 {
    public delegate bool ActionEffect();
    public class Action {
        public enum Type {
            STANDARD,
            BONUS,
            REACTION,
            FREE,
        }
        public Actions.ID ID {
            get;
            private set;
        }

        internal ActionEffect Effect {
            get;
            private set;
        }

        public Action(Actions.ID id, ActionEffect effect) {
            ID = id;
            Effect = effect;
        }

        public override bool Equals(object obj) {
            if (obj is Action other) {
                return ID == other.ID;
            }
            return false;
        }

        public override int GetHashCode() {
            return ID.GetHashCode();
        }
    }
}
using Xunit;

namespace srd5 {
    public class ActionTest {
        [Fact]
        public void TestEquals() {
            Action action1 = new Action(Actions.ID.ESCAPE_FROM_GRAPPLE, () => true);
            Action action2 = new Action(Actions.ID.ESCAPE_FROM_GRAPPLE, () => false);
            Action action3 = new Action(Actions.ID.ESCAPE_FROM_SPELL_BLACK_TENTACLES, () => true);

            Assert.Equal(action1, action2); // Same ID, different effects
            Assert.NotEqual(action1, action3); // Different IDs
            Assert.False(action2.Equals("Foobar")); // Different IDs
        }

        [Fact]
        public void TestGetHashCode() {
            Action action1 = new Action(Actions.ID.ESCAPE_FROM_GRAPPLE, () => true);
            Action action2 = new Action(Actions.ID.ESCAPE_FROM_GRAPPLE, () => false);
            Action action3 = new Action(Actions.ID.ESCAPE_FROM_SPELL_BLACK_TENTACLES, () => true);

            Assert.Equal(action1.GetHashCode(), action2.GetHashCode()); // Same ID, same hash code
            Assert.NotEqual(action1.GetHashCode(), action3.GetHashCode()); // Different IDs, different hash codes
        }
    }
}
using System;
using Xunit;

namespace srd5 {
    public class UtilsTest {
        [Fact]
        public void RemoveTest() {
            int[] a = { 2, 1, 7, 9, 2 };
            RemoveResult result = Utils.RemoveSingle<int>(ref a, 10);
            Assert.Equal(5, a.Length);
            result = Utils.RemoveSingle<int>(ref a, 2);
            Assert.Equal(RemoveResult.REMOVED_BUT_REMAINS, result);
            Assert.Equal(4, a.Length);
            result = Utils.RemoveSingle<int>(ref a, 2);
            Assert.Equal(RemoveResult.REMOVED_AND_GONE, result);
            Assert.Equal(3, a.Length);
        }

        [Fact]
        public void MaxTest() {
            int[] a = new int[0];
            Assert.Equal(0, Utils.Max<int>(null));
            Assert.Equal(0, Utils.Max<int>(a));
            a = new int[] { 3, 20, 3 };
            Assert.Equal(20, Utils.Max<int>(a));
        }

        [Fact]
        public void GuidClassTest() {
            Monster aboleth = Monsters.Aboleth;
            Assert.True(aboleth.Equals(aboleth));
            Assert.False(aboleth.Equals(Monsters.Aboleth));
            Assert.False(aboleth.Equals("Aboleth"));
        }

        [Fact]
        public void PushTest() {
            string[] a = { "a", "b" };
            Utils.Push<string>(ref a, "c", "d");
            Assert.Equal(4, a.Length);
            Assert.Equal(new string[] { "a", "b", "c", "d" }, a);
        }

        [Fact]
        public void PushUniqueTest() {
            string[] a = { "a", "b" };
            Assert.True(Utils.PushUnique<string>(ref a, "c"));
            Assert.Equal(3, a.Length);
            Assert.Equal(new string[] { "a", "b", "c" }, a);

            Assert.False(Utils.PushUnique<string>(ref a, "b"));
            Assert.Equal(4, a.Length);
            Assert.Equal(new string[] { "a", "b", "c", "b" }, a);
        }

        [Fact]
        public void ExpandTest() {
            string[] a = Utils.Expand<string>("x", 3);
            Assert.Equal(3, a.Length);
            Assert.Equal(new string[] { "x", "x", "x" }, a);
        }

        [Fact]
        public void GuidClassExtendedTest() {
            Monster m1 = Monsters.Aboleth;
            Monster m2 = Monsters.Aboleth;
            Monster m3 = Monsters.Ogre;
            Monster m4 = Monsters.Aboleth;
            Item i1 = Armors.Breastplate;

            // GetHashCode
            Assert.Equal(m1.Guid.GetHashCode(), m1.GetHashCode());

            // Is
            Assert.True(m1.Is(m2));
            Assert.False(m3.Is(m4));
            Assert.False(m1.Is(i1));
            Assert.False(m1.Is("Aboleth"));

            // ToString
            Assert.Equal(m1.Name + "#" + m1.Guid, m1.ToString());
        }
    }
}
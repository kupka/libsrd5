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
    }
}
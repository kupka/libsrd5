using System;
using Xunit;

namespace srd5 {
    public class UtilsTest {
        [Fact]
        public void MaxTest() {
            int[] a = new int[0];
            Assert.Equal(0, Utils.Max<int>(a));
            a = new int[] { 3, 20, 3 };
            Assert.Equal(20, Utils.Max<int>(a));
        }
    }
}
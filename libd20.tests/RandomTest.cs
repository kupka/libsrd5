using System;
using Xunit;

namespace d20 {
    public class RandomTest {
        [Fact]
        public void TestRandomRange() {
            uint r = Random.Get(1, 6);
            Assert.InRange<uint>(r, 1, 6);
        }

        [Fact]
        public void TestRandomDistribution() {
            uint[] c = new uint[2];
            for(int i = 0; i < 1000; i++) {
                uint r = Random.Get(0,1);
                c[r]++;
            }
            Assert.InRange<uint>(c[0], 400, 600);
        }
    }
}

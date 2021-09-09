using System;
using Xunit;

namespace srd5 {
    public class RandomTest {
        [Fact]
        public void TestRandomRange() {
            int r = Random.Get(1, 6);
            Assert.InRange<int>(r, 1, 6);
        }

        [Fact]
        public void TestRandomDistribution() {
            int[] c = new int[10];
            for (int i = 0; i < 1000; i++) {
                int r = Random.Get(0, 9);
                c[r]++;
            }
            Assert.InRange<int>(c[0], 80, 120);
            Assert.InRange<int>(c[1], 80, 120);
            Assert.InRange<int>(c[2], 80, 120);
            Assert.InRange<int>(c[3], 80, 120);
            Assert.InRange<int>(c[4], 80, 120);
            Assert.InRange<int>(c[5], 80, 120);
            Assert.InRange<int>(c[6], 80, 120);
            Assert.InRange<int>(c[7], 80, 120);
            Assert.InRange<int>(c[8], 80, 120);
            Assert.InRange<int>(c[9], 80, 120);
        }

        [Fact]
        public void StaticSeed1() {
            uint seed = (uint)((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();
            Random.State = seed;
            int[] results1 = new int[100];
            for (int i = 0; i < 100; i++) {
                results1[i] = Random.Get(0, 1000);
            }
            Random.State = seed;
            int[] results2 = new int[100];
            for (int i = 0; i < 100; i++) {
                results2[i] = Random.Get(0, 1000);
            }
            for (int i = 0; i < 100; i++) {
                Assert.Equal(results1[i], results2[i]);
            }
        }
    }
}

using System;
using Xunit;

namespace srd5 {
    [CollectionDefinition("SingleThreaded", DisableParallelization = true)]
    [Collection("SingleThreaded")]
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
            Assert.InRange<int>(c[0], 70, 130);
            Assert.InRange<int>(c[1], 70, 130);
            Assert.InRange<int>(c[2], 70, 130);
            Assert.InRange<int>(c[3], 70, 130);
            Assert.InRange<int>(c[4], 70, 130);
            Assert.InRange<int>(c[5], 70, 130);
            Assert.InRange<int>(c[6], 70, 130);
            Assert.InRange<int>(c[7], 70, 130);
            Assert.InRange<int>(c[8], 70, 130);
            Assert.InRange<int>(c[9], 70, 130);
        }

        [Fact]
        public void StaticSeed() {
            uint seed = 130213522;
            Random.State = seed;
            Assert.Equal(seed, Random.State);
            int[] results1 = new int[100];
            for (int i = 0; i < 100; i++) {
                results1[i] = Random.Get(0, 1000);
            }
            Random.State = seed;
            Assert.Equal(seed, Random.State);
            int[] results2 = new int[100];
            for (int i = 0; i < 100; i++) {
                results2[i] = Random.Get(0, 1000);
            }
            for (int i = 0; i < 100; i++) {
                Assert.Equal(results1[i], results2[i]);
            }
        }

        [Fact]
        public void WrongUsageTest() {
            Assert.Throws<Srd5ArgumentException>(delegate { Random.Get(-1, 5); });
            Assert.Throws<Srd5ArgumentException>(delegate { Random.Get(5, 1); });
        }
    }
}

using Xunit;

namespace srd5 {
    public class ExperienceTest {
        [Fact]
        public void TestMonsterByCR() {
            int previous = Experience.MonsterByCR(0);
            int current = Experience.MonsterByCR(ChallengeRating.EIGHTH);
            Assert.True(previous < current);
            current = Experience.MonsterByCR(ChallengeRating.QUARTER);
            Assert.True(previous < current);
            previous = current;
            current = Experience.MonsterByCR(ChallengeRating.HALF);
            Assert.True(previous < current);
            previous = current;
            for (int i = 1; i <= 30; i++) {
                current = Experience.MonsterByCR(i);
                Assert.True(previous < current);
                previous = current;
            }
            Assert.Throws<Srd5ArgumentException>(delegate {
                Experience.MonsterByCR(31);
            });
        }

        [Fact]
        public void TestRequiredForLevel() {
            int previous = Experience.RequiredForLevel(1);
            int current;
            for (int i = 2; i <= 20; i++) {
                current = Experience.RequiredForLevel(i);
                Assert.True(previous < current);
                previous = current;
            }
            Assert.Throws<Srd5ArgumentException>(delegate {
                Experience.RequiredForLevel(21);
            });
        }
    }
}
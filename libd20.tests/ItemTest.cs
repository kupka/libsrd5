using System;
using Xunit;

namespace d20 {
    public class ItemTest {
        [Fact]
        public void EqualTest() {
            Weapon club1 = Weapons.Club;
            Weapon club2 = Weapons.Club;
            Assert.Equal(club1, club2);
        }

        [Fact]
        public void UnEqualTest() {
            Weapon club = Weapons.Club;
            Weapon dagger = Weapons.Dagger;
            Assert.NotEqual(club, dagger);
        }

        [Fact]
        public void ThingsUnEqualTest() {
            Thing<Weapon> club1 = new Thing<Weapon>(Weapons.Club);
            Thing<Weapon> club2 = new Thing<Weapon>(Weapons.Club);
            Assert.NotEqual(club1, club2);
        }
    }
}
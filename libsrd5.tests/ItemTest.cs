using System;
using Xunit;

namespace srd5 {
    public class ItemTest {
        [Fact]
        public void NameEqualTest() {
            Weapon club1 = Weapons.Club;
            Weapon club2 = Weapons.Club;
            Assert.Equal(club1.Name, club2.Name);
        }

        [Fact]
        public void UnEqualTest() {
            Weapon club = Weapons.Club;
            Weapon dagger = Weapons.Dagger;
            Assert.NotEqual(club, dagger);
        }

        [Fact]
        public void ThingsUnEqualTest() {
            Weapon club1 = Weapons.Club;
            Weapon club2 = Weapons.Club;
            Assert.NotEqual(club1, club2);
        }
    }
}
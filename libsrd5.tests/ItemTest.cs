using System;
using System.Reflection;
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

        [Fact]
        public void GetterTest() {
            foreach (PropertyInfo property in typeof(Weapons).GetProperties()) {
                object o = property.GetMethod.Invoke(null, null);
                Assert.True(o is Weapon);
            }
            foreach (PropertyInfo property in typeof(Armors).GetProperties()) {
                object o = property.GetMethod.Invoke(null, null);
                Assert.True(o is Armor);
            }
            foreach (PropertyInfo property in typeof(Amulets).GetProperties()) {
                object o = property.GetMethod.Invoke(null, null);
                Assert.True(o is Amulet);
            }
            foreach (PropertyInfo property in typeof(Rings).GetProperties()) {
                object o = property.GetMethod.Invoke(null, null);
                Assert.True(o is Ring);
            }
            foreach (PropertyInfo property in typeof(Bootss).GetProperties()) {
                object o = property.GetMethod.Invoke(null, null);
                Assert.True(o is Boots);
            }
            foreach (PropertyInfo property in typeof(Helmets).GetProperties()) {
                object o = property.GetMethod.Invoke(null, null);
                Assert.True(o is Helmet);
            }
        }
    }
}
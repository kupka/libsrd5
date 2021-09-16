using Xunit;
using System;

namespace srd5 {
    [Collection("SingleThreaded")]
    public class BattlegroundTest {
        [Fact]
        public void Setup2DTest() {
            Battleground2D ground = new Battleground2D(100, 100);
            CharacterSheet hero = new CharacterSheet(CharacterRaces.Human);
            hero.Name = "Bob";
            Monster badguy = Monsters.Ogre;
            Random.State = 7; // Fix deterministic random so that ogre wins initiative
            ground.AddCombattant(hero, 10, 10);
            ground.AddCombattant(badguy, 30, 30);
            Assert.Equal(hero.Name, ground.CurrentCombattant.Name);
            Assert.Equal(ground.LocateCombattant(hero), ground.LocateCombattant2D(hero));
            Assert.Equal(10, ground.LocateCombattant2D(hero).X);
            Assert.Equal(30, ground.LocateCombattant2D(badguy).Y);
            Assert.Equal(141, ground.LocateCombattant(hero).Distance(ground.LocateCombattant(badguy)));
            Assert.Throws<ArgumentException>(delegate {
                ground.LocateCombattant(hero).Distance(new ClassicLocation(ClassicLocation.Row.FRONT));
            });
            ground.Initialize();
            Assert.Equal(badguy.Name, ground.CurrentCombattant.Name);
            Assert.Equal(30, ground.LocateCombattant2D(badguy).X);
            ground.Initialize(); // nothing should happen
            Assert.Equal(badguy.Name, ground.CurrentCombattant.Name);
            Assert.Equal(10, ground.LocateCombattant2D(hero).X);
        }

        [Fact]
        public void SetupClassicTest() {

        }

        [Fact]
        public void ClassicDistanceTest() {
            ClassicLocation front = new ClassicLocation(ClassicLocation.Row.FRONT);
            ClassicLocation back = new ClassicLocation(ClassicLocation.Row.BACK);
            Assert.True(front.Distance(back) == back.Distance(front));
            Assert.True(back.Distance(front) > front.Distance(front));
            Assert.True(back.Distance(back) > back.Distance(front));
        }

        [Fact]
        public void MoveTest() {
            CharacterSheet sheet = new CharacterSheet(CharacterRaces.HillDwarf);
            Battleground2D ground = new Battleground2D(50, 50);
            ground.AddCombattant(sheet, 10, 10);
            ground.Initialize();
            Assert.True(ground.MoveAction(new Coord(13, 13))); // distance 21 => remaining speed = 4
            Assert.Equal(13, ground.LocateCombattant2D(sheet).X);
            Assert.False(ground.MoveAction(new Coord(14, 13))); // distance 5 => can't move
            Assert.Equal(13, ground.LocateCombattant2D(sheet).X);
            ground.NextPhase();
            Assert.Equal(1, ground.Turn);
            ground.NextPhase();
            Assert.Equal(2, ground.Turn);
        }
    }
}
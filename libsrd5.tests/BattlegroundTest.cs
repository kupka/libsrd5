using Xunit;
using System;

namespace srd5 {
    [Collection("SingleThreaded")]
    public class BattlegroundTest {
        [Fact]
        public void Setup2DTest() {
            Battleground2D ground = new Battleground2D(100, 100);
            CharacterSheet hero = new CharacterSheet(Race.HUMAN);
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
            CharacterSheet sheet = new CharacterSheet(Race.HILL_DWARF);
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

        [Fact]
        public void AttackTest2D() {
            Battleground2D ground = new Battleground2D(5, 5);
            CharacterSheet hero = new CharacterSheet(Race.HILL_DWARF);
            hero.Strength.BaseValue = 18;
            hero.Dexterity.BaseValue = 10;
            hero.AddLevel(CharacterClasses.Barbarian);
            hero.AddLevel(CharacterClasses.Barbarian);
            hero.AddLevel(CharacterClasses.Barbarian);
            hero.AddLevel(CharacterClasses.Barbarian);
            hero.AddLevel(CharacterClasses.Barbarian);
            hero.HitPoints = hero.HitPointsMax;
            hero.Equip(new Thing<Weapon>(Weapons.Greataxe));
            Random.State = 1; // Fix deterministic random so that badger goes first
            ground.AddCombattant(hero, 1, 1);
            Monster badger = Monsters.GiantBadger;
            ground.AddCombattant(badger, 1, 2);
            ground.Initialize();
            ground.NextPhase(); // skip move
            Assert.True(ground.MeleeAttackAction(hero));
            Assert.Equal(hero, ground.CurrentCombattant);
            ground.NextPhase(); // skip move
            hero.BonusAttack = new Attack("Test Attack", 0, new Damage(DamageType.BLUDGEONING, "1d6+4"));
            Random.State = 11; // Fix deterministic random to guarantee critical hit
            Assert.True(ground.MeleeAttackAction(badger));
            Assert.True(ground.MeleeAttackAction(badger));
            Assert.False(ground.MeleeAttackAction(hero));
        }

        [Fact]
        public void AttackTest2DWithBonusDamage() {
            Battleground2D ground = new Battleground2D(5, 5);
            CharacterSheet hero = new CharacterSheet(Race.HILL_DWARF);
            hero.Strength.BaseValue = 18;
            hero.Dexterity.BaseValue = 10;
            hero.AddLevel(CharacterClasses.Barbarian);
            hero.AddLevel(CharacterClasses.Barbarian);
            hero.AddLevel(CharacterClasses.Barbarian);
            hero.AddLevel(CharacterClasses.Barbarian);
            hero.AddLevel(CharacterClasses.Barbarian);
            hero.HitPoints = hero.HitPointsMax;
            hero.Equip(new Thing<Weapon>(Weapons.Greataxe));
            Random.State = 3; // Fix deterministic random so that ogre goes first
            ground.AddCombattant(hero, 1, 1);
            Monster ogre = Monsters.Ogre;
            ground.AddCombattant(ogre, 1, 2);
            ground.Initialize();
            ground.NextPhase(); // skip move
            Assert.True(ground.MeleeAttackAction(hero));
            Assert.Equal(hero, ground.CurrentCombattant);
            ground.NextPhase(); // skip move
            hero.BonusAttack = new Attack("Test Attack", 0, new Damage(DamageType.BLUDGEONING, "1d6+4"), 5, 0, 0, new Damage(DamageType.COLD, "1d4+1"));
            Random.State = 11; // Fix deterministic random to guarantee critical hit
            Assert.True(ground.MeleeAttackAction(ogre));
            Assert.True(ground.MeleeAttackAction(ogre));
            Assert.False(ground.MeleeAttackAction(hero));
        }

        [Fact]
        public void OutOfRangeTest() {
            Battleground2D ground = new Battleground2D(5, 5);
            CharacterSheet hero = new CharacterSheet(Race.HILL_DWARF);
            hero.Strength.BaseValue = 18;
            hero.Dexterity.BaseValue = 10;
            hero.AddLevel(CharacterClasses.Barbarian);
            ground.AddCombattant(hero, 1, 1);
            Monster ogre = Monsters.Ogre;
            Random.State = 3; // Fix deterministic random so that ogre goes first
            ground.AddCombattant(ogre, 4, 4);
            ground.Initialize();
            ground.NextPhase(); // skip move  
            Assert.Equal(hero, ground.CurrentCombattant);
            Assert.False(ground.MeleeAttackAction(ogre));
        }
    }
}
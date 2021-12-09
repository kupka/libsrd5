using System;
using Xunit;

namespace srd5 {
    public class SpellTest {
        [Fact]
        public void AcidSplashTest() {
            CharacterSheet hero = new CharacterSheet(Race.HUMAN, true);
            Monster ogre = Monsters.Ogre;
            int hpBefore = ogre.HitPoints;
            for (int i = 0; i < 17; i++) {
                hero.AddLevel(CharacterClasses.Druid);
                if (i == 1 || i == 4 || i == 10 || i == 16) {
                    hpBefore = ogre.HitPoints;
                    Spells.AcidSplash.Cast(hero, 8 + hero.Proficiency + hero.Intelligence.Modifier, SpellLevel.CANTRIP, ogre);
                    Assert.True(ogre.HitPoints <= hpBefore);
                }
            }
        }

        [Fact]
        public void MagicMissileTest() {
            CharacterSheet hero = new CharacterSheet(Race.HUMAN, true);
            Monster ogre1 = Monsters.Ogre;
            Monster ogre2 = Monsters.Ogre;
            Monster ogre3 = Monsters.Ogre;
            Monster ogre4 = Monsters.Ogre;
            Monster ogre5 = Monsters.Ogre;
            Spells.MagicMissile.Cast(hero, 8 + hero.Proficiency + hero.Intelligence.Modifier, SpellLevel.SECOND, ogre1, ogre2, ogre3, ogre4, ogre5);
            Assert.True(ogre1.HitPoints < ogre1.HitPointsMax);
            Assert.True(ogre2.HitPoints < ogre2.HitPointsMax);
            Assert.True(ogre3.HitPoints < ogre3.HitPointsMax);
            Assert.True(ogre4.HitPoints < ogre4.HitPointsMax);
            Assert.Equal(ogre5.HitPointsMax, ogre5.HitPoints);
        }

        [Fact]
        public void CureWoundsTest() {
            CharacterSheet hero = new CharacterSheet(Race.GNOME);
            hero.AddLevel(CharacterClasses.Druid);
            hero.HitPoints = 1;
            Spells.CureWounds.Cast(hero, 0, SpellLevel.NINETH, hero);
            Assert.Equal(hero.HitPointsMax, hero.HitPoints);
        }

        [Fact]
        public void ShillelaghTest() {
            CharacterSheet hero;
            // Execute this multiple times because of random character generation
            for (int i = 0; i < 10; i++) {
                hero = new CharacterSheet(Race.HALF_ELF, true);
                hero.AddLevel(CharacterClasses.Druid);
                hero.Equip(new Thing<Weapon>(Weapons.Club));
                Assert.Equal(hero.Proficiency + hero.Strength.Modifier, hero.MeleeAttacks[0].AttackBonus);
                Spells.Shillelagh.Cast(hero, 0, SpellLevel.CANTRIP);
                Assert.Equal(hero.Proficiency + hero.Wisdom.Modifier, hero.MeleeAttacks[0].AttackBonus);
            }
            // Also check with wrong weapon
            hero = new CharacterSheet(Race.HALF_ELF, true);
            hero.AddLevel(CharacterClasses.Druid);
            hero.Equip(new Thing<Weapon>(Weapons.Greataxe));
            Assert.Equal(hero.Strength.Modifier, hero.MeleeAttacks[0].AttackBonus);
            Spells.Shillelagh.Cast(hero, 0, SpellLevel.CANTRIP);
            Assert.Equal(hero.Strength.Modifier, hero.MeleeAttacks[0].AttackBonus);
        }
    }
}
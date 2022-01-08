using System;
using Xunit;

namespace srd5 {
    [CollectionDefinition("SingleThreaded", DisableParallelization = true)]
    [Collection("SingleThreaded")]
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
                    Spells.AcidSplash.Cast(hero, 8 + hero.Proficiency + hero.Intelligence.Modifier, SpellLevel.CANTRIP, hero.Intelligence.Modifier, ogre);
                    Assert.True(ogre.HitPoints <= hpBefore);
                }
            }
        }

        [Fact]
        public void EqualTest() {
            Spell spell = Spells.AcidSplash;
            Assert.True(Spells.AcidSplash.Equals(spell));
            Assert.False(spell.Equals("foo"));
            Assert.Equal(Spells.ID.ACID_SPLASH.Name(), spell.Name);
        }

        [Fact]
        public void MagicMissileTest() {
            CharacterSheet hero = new CharacterSheet(Race.HUMAN, true);
            Monster ogre1 = Monsters.Ogre;
            Monster ogre2 = Monsters.Ogre;
            Monster ogre3 = Monsters.Ogre;
            Monster ogre4 = Monsters.Ogre;
            Monster ogre5 = Monsters.Ogre;
            Spells.MagicMissile.Cast(hero, 8 + hero.Proficiency + hero.Intelligence.Modifier, SpellLevel.SECOND, hero.Intelligence.Modifier, ogre1, ogre2, ogre3, ogre4, ogre5);
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
            Spells.CureWounds.Cast(hero, 0, SpellLevel.NINETH, hero.Wisdom.Modifier, hero);
            Assert.Equal(hero.HitPointsMax, hero.HitPoints);
            // doesn't affect undead
            Monster shadow = Monsters.Shadow;
            shadow.HitPoints = shadow.HitPointsMax - 1;
            Spells.CureWounds.Cast(hero, 0, SpellLevel.NINETH, hero.Wisdom.Modifier, shadow);
            Assert.Equal(shadow.HitPointsMax - 1, shadow.HitPoints);
            // doesn't affect constructs
            Monster golem = Monsters.ClayGolem;
            golem.HitPoints = golem.HitPointsMax - 1;
            Spells.CureWounds.Cast(hero, 0, SpellLevel.NINETH, hero.Wisdom.Modifier, golem);
            Assert.Equal(golem.HitPointsMax - 1, golem.HitPoints);
            // affects giants
            Monster ogre = Monsters.Ogre;
            ogre.HitPoints = ogre.HitPointsMax - 10;
            Spells.CureWounds.Cast(hero, 0, SpellLevel.NINETH, hero.Wisdom.Modifier, ogre);
            Assert.Equal(ogre.HitPointsMax, ogre.HitPoints);
        }

        [Fact]
        public void HealingWordTest() {
            CharacterSheet hero = new CharacterSheet(Race.GNOME);
            hero.AddLevel(CharacterClasses.Druid);
            hero.HitPoints = 1;
            Spells.HealingWord.Cast(hero, 0, SpellLevel.SEVENTH, hero.Wisdom.Modifier, hero);
            Assert.Equal(hero.HitPointsMax, hero.HitPoints);
            // doesn't affect undead
            Monster shadow = Monsters.Shadow;
            shadow.HitPoints = shadow.HitPointsMax - 1;
            Spells.HealingWord.Cast(hero, 0, SpellLevel.NINETH, hero.Wisdom.Modifier, shadow);
            Assert.Equal(shadow.HitPointsMax - 1, shadow.HitPoints);
            // doesn't affect constructs
            Monster golem = Monsters.ClayGolem;
            golem.HitPoints = golem.HitPointsMax - 1;
            Spells.HealingWord.Cast(hero, 0, SpellLevel.NINETH, hero.Wisdom.Modifier, golem);
            Assert.Equal(golem.HitPointsMax - 1, golem.HitPoints);
            // affects giants
            Monster ogre = Monsters.Ogre;
            ogre.HitPoints = ogre.HitPointsMax - 10;
            Spells.HealingWord.Cast(hero, 0, SpellLevel.NINETH, hero.Wisdom.Modifier, ogre);
            Assert.Equal(ogre.HitPointsMax, ogre.HitPoints);
        }

        [Fact]
        public void ShillelaghTest() {
            CharacterSheet hero;
            // Execute this multiple times because of random character generation
            for (int i = 0; i < 10; i++) {
                hero = new CharacterSheet(Race.HALF_ELF, true);
                hero.AddLevel(CharacterClasses.Druid);
                if (i % 2 == 0)
                    hero.Equip(Weapons.Club);
                else
                    hero.Equip(Weapons.Quarterstaff);
                Assert.Equal(hero.Proficiency + hero.Strength.Modifier, hero.MeleeAttacks[0].AttackBonus);
                Spells.Shillelagh.Cast(hero, 0, SpellLevel.CANTRIP, hero.Wisdom.Modifier);
                Assert.Equal(hero.Proficiency + hero.Wisdom.Modifier, hero.MeleeAttacks[0].AttackBonus);
            }
            // Also check with wrong weapon
            hero = new CharacterSheet(Race.HALF_ELF, true);
            hero.AddLevel(CharacterClasses.Druid);
            hero.Equip(Weapons.Greataxe);
            Assert.Equal(hero.Strength.Modifier, hero.MeleeAttacks[0].AttackBonus);
            Spells.Shillelagh.Cast(hero, 0, SpellLevel.CANTRIP, hero.Wisdom.Modifier);
            Assert.Equal(hero.Strength.Modifier, hero.MeleeAttacks[0].AttackBonus);
        }

        [Fact]
        public void CharmPersonTest() {
            CharacterSheet hero = new CharacterSheet(Race.HIGH_ELF, true);
            Monster badger = Monsters.GiantBadger;
            Monster orc1 = Monsters.Orc;
            Monster orc2 = Monsters.Orc;
            Monster orc3 = Monsters.Orc;
            Monster orc4 = Monsters.Orc;
            Monster orc5 = Monsters.Orc;
            Monster orc6 = Monsters.Orc;
            Random.State = 1;
            Spells.CharmPerson.Cast(hero, 14, SpellLevel.SIXTH, 0, badger, orc1, orc2, orc3, orc4, orc5, orc6);
            Assert.False(badger.HasCondition(ConditionType.CHARMED));
            Assert.False(orc6.HasCondition(ConditionType.CHARMED));
            Assert.True(orc1.HasCondition(ConditionType.CHARMED) || orc2.HasCondition(ConditionType.CHARMED)
                || orc3.HasCondition(ConditionType.CHARMED) || orc4.HasCondition(ConditionType.CHARMED) || orc5.HasCondition(ConditionType.CHARMED));
        }

        [Fact]
        public void HoldPersonTest() {
            CharacterSheet hero = new CharacterSheet(Race.HIGH_ELF, true);
            Monster badger = Monsters.GiantBadger;
            Monster orc1 = Monsters.Orc;
            Monster orc2 = Monsters.Orc;
            Monster orc3 = Monsters.Orc;
            Monster orc4 = Monsters.Orc;
            Monster orc5 = Monsters.Orc;
            Monster orc6 = Monsters.Orc;
            Random.State = 1;
            Spells.HoldPerson.Cast(hero, 14, SpellLevel.SEVENTH, 0, badger, orc1, orc2, orc3, orc4, orc5, orc6);
            Assert.False(badger.HasCondition(ConditionType.PARALYZED));
            Assert.False(orc6.HasCondition(ConditionType.PARALYZED));
            Assert.True(orc1.HasCondition(ConditionType.PARALYZED) || orc2.HasCondition(ConditionType.PARALYZED)
                || orc3.HasCondition(ConditionType.PARALYZED) || orc4.HasCondition(ConditionType.PARALYZED) || orc5.HasCondition(ConditionType.PARALYZED));
            for (int i = 0; i < 100; i++) {
                orc1.OnEndOfTurn();
                orc2.OnEndOfTurn();
                orc3.OnEndOfTurn();
                orc4.OnEndOfTurn();
                orc5.OnEndOfTurn();
            }
            Assert.False(orc1.HasCondition(ConditionType.PARALYZED) || orc2.HasCondition(ConditionType.PARALYZED)
               || orc3.HasCondition(ConditionType.PARALYZED) || orc4.HasCondition(ConditionType.PARALYZED) || orc5.HasCondition(ConditionType.PARALYZED));
        }
    }
}
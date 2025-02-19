using System;
using Xunit;

namespace srd5 {
    public partial class SpellTest {
        [Fact]
        public void ChillTouchTest() {
            CharacterSheet wizard = new CharacterSheet(Race.GNOME, true);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard);
            CharacterSheet barbarian = new CharacterSheet(Race.HALF_ORC, true);
            barbarian.AddLevel(CharacterClasses.Barbarian);
            Monster orc = Monsters.Orc;
            Monster shadow = Monsters.Shadow;
            Battleground2D ground = new Battleground2D(10, 10);
            Random.State = 2;
            ground.AddCombattant(wizard, 5, 5);
            ground.AddCombattant(orc, 7, 7);
            ground.AddCombattant(shadow, 8, 8);
            ground.AddCombattant(barbarian, 9, 9);
            Spells.ChillTouch.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, barbarian);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard);
            Spells.ChillTouch.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, orc);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard);
            Spells.ChillTouch.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, shadow);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard);
            Spells.ChillTouch.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, shadow);
            Assert.True(shadow.HasEffect(Effect.CANNOT_REGAIN_HITPOINTS));
            Assert.True(shadow.HasEffect(Effect.DISADVANTAGE_ON_ATTACK));
            wizard.OnStartOfTurn();
            wizard.OnEndOfTurn();
            Assert.False(shadow.HasEffect(Effect.CANNOT_REGAIN_HITPOINTS));
            Assert.True(shadow.HasEffect(Effect.DISADVANTAGE_ON_ATTACK));
            wizard.OnEndOfTurn();
            Assert.False(shadow.HasEffect(Effect.DISADVANTAGE_ON_ATTACK));
        }

        [Fact]
        public void FireBoltTest() {
            CharacterSheet wizard = new CharacterSheet(Race.GNOME, true);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard);
            Monster orc = Monsters.Orc;
            Battleground2D ground = new Battleground2D(10, 10);
            Random.State = 1;
            ground.AddCombattant(wizard, 5, 5);
            ground.AddCombattant(orc, 7, 7);
            Spells.FireBolt.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, orc);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard);
            Spells.FireBolt.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, orc);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard);
            Spells.FireBolt.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, orc);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard);
            Spells.FireBolt.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, orc);
            Assert.Equal(0, orc.HitPoints);
        }

        [Fact]
        public void LightTest() {
            DefaultSpellTest(Spells.Light, 12, SpellLevel.CANTRIP, null, Effect.SPELL_LIGHT, null);
        }

        [Fact]
        public void RayOfFrostTest() {
            CharacterSheet wizard = new CharacterSheet(Race.GNOME, true);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard);
            CharacterSheet barbarian = new CharacterSheet(Race.HALF_ORC, true);
            barbarian.AddLevel(CharacterClasses.Barbarian);
            Monster orc = Monsters.Orc;
            Monster shadow = Monsters.Shadow;
            Battleground2D ground = new Battleground2D(10, 50);
            Random.State = 1;
            ground.AddCombattant(wizard, 5, 5);
            ground.AddCombattant(orc, 7, 7);
            ground.AddCombattant(shadow, 8, 8);
            ground.AddCombattant(barbarian, 9, 49);
            Spells.RayOfFrost.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, barbarian);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard);
            Spells.RayOfFrost.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, orc);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard);
            Spells.RayOfFrost.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, shadow);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard);
            Spells.RayOfFrost.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, shadow);
            Assert.True(shadow.HasEffect(Effect.SPELL_RAY_OF_FROST));
            wizard.OnStartOfTurn();
            Assert.False(shadow.HasEffect(Effect.SPELL_RAY_OF_FROST));
        }

        [Fact]
        public void ShockingGraspTest() {
            CharacterSheet wizard = new CharacterSheet(Race.GNOME, true);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard);
            CharacterSheet barbarian = new CharacterSheet(Race.HALF_ORC, true);
            barbarian.AddLevel(CharacterClasses.Barbarian);
            Monster orc = Monsters.Orc;
            Monster shadow = Monsters.Shadow;
            Battleground2D ground = new Battleground2D(10, 10);
            Random.State = 1;
            ground.AddCombattant(wizard, 5, 5);
            ground.AddCombattant(orc, 7, 7);
            ground.AddCombattant(shadow, 5, 6);
            ground.AddCombattant(barbarian, 9, 9);
            Spells.ShockingGrasp.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, barbarian);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard);
            Spells.ShockingGrasp.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, orc);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard);
            Spells.ShockingGrasp.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, shadow);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard, CharacterClasses.Wizard);
            Spells.ShockingGrasp.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, shadow);
            Assert.True(shadow.HasEffect(Effect.CANNOT_TAKE_REACTIONS));
            wizard.OnStartOfTurn();
            Assert.False(shadow.HasEffect(Effect.CANNOT_TAKE_REACTIONS));
        }

        [Fact]
        public void TrueStrikeTest() {
            CharacterSheet wizard = new CharacterSheet(Race.GNOME, true);
            wizard.AddLevels(CharacterClasses.Wizard, CharacterClasses.Wizard);
            Monster orc1 = Monsters.Orc;
            Monster orc2 = Monsters.Orc;
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombattant(wizard, 5, 5);
            ground.AddCombattant(orc1, 5, 6);
            ground.AddCombattant(orc2, 6, 5);
            ground.Initialize();
            Spells.TrueStrike.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, orc1);
            wizard.Attack(Attacks.GiantBadgerBite, orc1, 5); // not yet active
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            wizard.Attack(Attacks.GiantBadgerBite, orc2, 5); // wrong target
            wizard.Attack(Attacks.GiantBadgerBite, orc1, 5); // correct target and turn
            Spells.TrueStrike.Cast(ground, wizard, 14, SpellLevel.CANTRIP, 0, orc2);
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            ground.NextPhase();
            wizard.Attack(Attacks.GiantBadgerBite, orc2, 5); // no longer active
        }

        [Fact]
        public void DancingLightsTest() {
            CharacterSheet wizard = new CharacterSheet(Race.GNOME, true);
            Spells.DancingLights.Cast(wizard, 14, SpellLevel.CANTRIP, 0);
        }

        [Fact]
        public void SleepTest() {
            Monster hag = Monsters.NightHag;
            CharacterSheet hero = new CharacterSheet(Race.GNOME);
            hero.AddLevel(CharacterClasses.Druid);
            Monster badger1 = Monsters.Badger;
            badger1.AddCondition(ConditionType.UNCONSCIOUS);
            Monster badger2 = Monsters.Badger;
            Monster badger3 = Monsters.Badger;
            Monster zombie = Monsters.Zombie;
            Monster bandit = Monsters.Bandit;
            bandit.AddEffect(Effect.IMMUNITY_CHARMED);
            Battleground ground = createBattleground(hag, badger1, zombie, hero, bandit, badger2);
            Spells.Sleep.Cast(ground, hag, 18, SpellLevel.THIRD, hag.ProficiencyBonus, badger3, hero, badger1, zombie, badger2, bandit);
            Assert.True(badger2.HasCondition(ConditionType.UNCONSCIOUS) && badger3.HasCondition(ConditionType.UNCONSCIOUS));
            // wake up after 1 minute
            for (int i = 0; i < 10; i++) {
                badger2.OnEndOfTurn();
            }
            // wake up after damage taken
            badger3.OnDamageTaken(hero, new Damage(DamageType.TRUE_DAMAGE, 1));
            badger3.OnEndOfTurn();
            Assert.False(badger2.HasCondition(ConditionType.UNCONSCIOUS));
            Assert.False(badger3.HasCondition(ConditionType.UNCONSCIOUS));
            Assert.False(zombie.HasCondition(ConditionType.UNCONSCIOUS));
            Assert.False(bandit.HasCondition(ConditionType.UNCONSCIOUS));
        }

        [Fact]
        public void FalseLifeTest() {
            Monster hag = Monsters.NightHag;
            Spells.FalseLife.Cast(hag, 0, SpellLevel.FIRST, 0);
            hag.TakeDamage(this, DamageType.FIRE, 1);
            Assert.Equal(hag.HitPointsMax, hag.HitPoints);
            hag.TakeDamage(this, DamageType.FIRE, 30);
            Assert.True(hag.HitPointsMax > hag.HitPoints);
            hag.HealDamage(100);
            Spells.FalseLife.Cast(hag, 0, SpellLevel.NINETH, 0);
            Spells.FalseLife.Cast(hag, 0, SpellLevel.THIRD, 0);
            hag.TakeDamage(this, DamageType.FIRE, 30);
            Assert.Equal(hag.HitPointsMax, hag.HitPoints);
        }

        [Fact]
        public void BurningHandsTest() {
            DamagingSpellTesting(Spells.BurningHands, 12, DamageType.FIRE);
        }

        [Fact]
        public void ColorSprayTest() {
            DefaultSpellTest(Spells.ColorSpray, 12, SpellLevel.FIRST, ConditionType.BLINDED, null, 1);
        }

        [Fact]
        public void FeatherFallTest() {
            DefaultSpellTest(Spells.FeatherFall, 12, SpellLevel.FIRST, null, Effect.SPELL_FEATHER_FALL, 10);
        }

        [Fact]
        public void GreaseTest() {
            DefaultSpellTest(Spells.Grease, 12, SpellLevel.FIRST, ConditionType.PRONE, null, null);
        }

        [Fact]
        public void HideousLaughterTest() {
            DefaultSpellTest(Spells.HideousLaughter, 25, SpellLevel.THIRD, ConditionType.INCAPACITATED, Effect.SPELL_HIDEOUS_LAUGHTER, 10);
        }

        [Fact]
        public void MageArmorTest() {
            CharacterSheet hero = new CharacterSheet(Race.HALF_ORC);
            hero.AddLevel(CharacterClasses.Barbarian);
            int ac = hero.ArmorClass;
            Spells.MageArmor.Cast(hero, 10, SpellLevel.FIRST, 0);
            Assert.True(hero.ArmorClass > ac);
            Assert.True(hero.Inventory.Armor.Is(Armors.MageArmor));
            ac = hero.ArmorClass;
            hero.Equip(Armors.HideArmor);
            Assert.True(hero.ArmorClass < ac);
            Spells.MageArmor.Cast(hero, 10, SpellLevel.FIRST, 0);
            Assert.True(hero.Inventory.Armor.Is(Armors.HideArmor));
            Monster rat = Monsters.Rat;
            ac = rat.ArmorClass;
            Spells.MageArmor.Cast(rat, 12, SpellLevel.THIRD, 2);
            Assert.Equal(ac, rat.ArmorClass);
        }

        [Fact]
        public void ShieldTest() {
            Monster hag = Monsters.NightHag;
            int ac = hag.ArmorClass;
            Spells.Shield.Cast(hag, 10, SpellLevel.FIRST, 0);
            Assert.Equal(ac + 5, hag.ArmorClass);
            Spells.MagicMissile.Cast(hag, 12, SpellLevel.THIRD, 0);
            Assert.Equal(hag.HitPointsMax, hag.HitPoints);
            DefaultSpellTest(Spells.Shield, 12, Spells.Shield.Level, null, Effect.SPELL_SHIELD, 1);
        }

        [Fact]
        public void AcidArrowTest() {
            for (int i = 0; i < 10; i++) {
                Monster hag = Monsters.NightHag;
                Monster ogre = Monsters.Ogre;
                Battleground ground = createBattleground(hag, ogre);
                Spells.AcidArrow.Cast(ground, hag, 12, SpellLevel.THIRD, 0, ogre);
                ogre.OnEndOfTurn();
                Assert.True(ogre.HitPointsMax > ogre.HitPoints);
                int hp = ogre.HitPoints;
                ogre.OnEndOfTurn();
                Assert.True(hp == ogre.HitPoints);
            }
        }

        [Fact]
        public void AlterSelfTest() {
            Monster hag = Monsters.NightHag;
            Spells.AlterSelf.Cast(hag, 10, SpellLevel.SECOND, 0);
            Assert.True(hag.HasEffect(Effect.SPELL_ALTER_SELF_CLAWS));
            CharacterSheet hero = new CharacterSheet(Race.HILL_DWARF);
            Item club = Weapons.Club;
            hero.Equip(club);
            Spells.AlterSelf.Cast(hero, 10, SpellLevel.FIFTH, 5);
            Assert.True(hero.Inventory.MainHand.Is(Weapons.Claws));
            Assert.True(Array.IndexOf(hero.Inventory.Bag, club) == 0);
            hero.RemoveEffect(Effect.SPELL_ALTER_SELF_CLAWS);
            Assert.True(hero.Inventory.MainHand == null);
        }

        [Fact]
        public void BlindnessDeafnessTest() {
            DefaultSpellTest(Spells.BlindnessDeafness, 12, SpellLevel.THIRD, ConditionType.BLINDED, Effect.SPELL_BLINDNESS_DEAFNESS, Spells.BlindnessDeafness.Duration);
        }

        [Fact]
        public void BlurTest() {
            DefaultSpellTest(Spells.Blur, 12, SpellLevel.THIRD, null, Effect.DISADVANTAGE_ON_BEING_ATTACKED, Spells.Blur.Duration);
        }

        [Fact]
        public void InvisibilityTest() {
            Monster hag1 = Monsters.NightHag;
            Monster hag2 = Monsters.NightHag;
            Monster badger = Monsters.Badger;
            Battleground ground = createBattleground(hag2, badger);
            Spells.Invisibility.Cast(hag1, 10, SpellLevel.SECOND, 5);
            Spells.Invisibility.Cast(hag2, 10, SpellLevel.FOURTH, -1);
            Assert.True(hag1.HasCondition(ConditionType.INVISIBLE));
            Assert.True(hag2.HasCondition(ConditionType.INVISIBLE));
            hag1.Attack(Attacks.NightHagClaws, badger, 5);
            hag1.OnEndOfTurn();
            hag2.OnEndOfTurn();
            Assert.False(hag1.HasCondition(ConditionType.INVISIBLE));
            Assert.True(hag2.HasCondition(ConditionType.INVISIBLE));
            Spells.Invisibility.Cast(hag1, 10, SpellLevel.THIRD, 0);
            Assert.True(hag1.HasCondition(ConditionType.INVISIBLE));
            Assert.True(hag2.HasCondition(ConditionType.INVISIBLE));
            Spells.AcidArrow.Cast(ground, hag2, 12, SpellLevel.SECOND, 5, badger);
            Assert.True(hag1.HasCondition(ConditionType.INVISIBLE));
            Assert.False(hag2.HasCondition(ConditionType.INVISIBLE));
        }

        [Fact]
        public void LevitateTest() {
            DefaultSpellTest(Spells.Levitate, 15, SpellLevel.SECOND, null, Effect.CANNOT_BE_MELEE_ATTACKED, Spells.Levitate.Duration);
        }

        [Fact]
        public void MagicWeaponTest() {
            int failures = 0;
            EventHandler<GlobalEvents.SpellAffection> handler = delegate (object source, GlobalEvents.SpellAffection args) {
                if (!args.Affected) failures++;
            };
            GlobalEvents.SpellAffectionHandlers += handler;
            Spells.MagicWeapon.Cast(Monsters.Druid, 10, SpellLevel.SIXTH, 5); // fail #1
            CharacterSheet hero = new CharacterSheet(Race.HILL_DWARF);
            Spells.MagicWeapon.Cast(hero, 10, SpellLevel.SIXTH, 5); // fail #2
            hero.Equip(Weapons.CreatePlus1Weapon(Weapons.Handaxe));
            Spells.MagicWeapon.Cast(hero, 10, SpellLevel.SIXTH, 5); // fail #3
            hero.Inventory.MainHand = Weapons.Longsword;
            Spells.MagicWeapon.Cast(hero, 10, SpellLevel.THIRD, 5);
            Assert.True(hero.Inventory.MainHand.HasProperty(WeaponProperty.MAGIC));
            Assert.True(hero.Inventory.MainHand.HasProperty(WeaponProperty.PLUS_1));
            hero.Inventory.MainHand = Weapons.Longsword;
            Spells.MagicWeapon.Cast(hero, 10, SpellLevel.FIFTH, 5);
            Assert.True(hero.Inventory.MainHand.HasProperty(WeaponProperty.MAGIC));
            Assert.True(hero.Inventory.MainHand.HasProperty(WeaponProperty.PLUS_2));
            hero.Inventory.MainHand = Weapons.Longsword;
            Spells.MagicWeapon.Cast(hero, 10, SpellLevel.NINETH, 5);
            Assert.True(hero.Inventory.MainHand.HasProperty(WeaponProperty.MAGIC));
            Assert.True(hero.Inventory.MainHand.HasProperty(WeaponProperty.PLUS_3));
            GlobalEvents.SpellAffectionHandlers -= handler;
            Assert.Equal(3, failures);
            for (int i = 0; i < (int)Spells.MagicWeapon.Duration; i++) {
                hero.OnEndOfTurn();
            }
            Assert.False(hero.Inventory.MainHand.HasProperty(WeaponProperty.MAGIC));
            Assert.False(hero.Inventory.MainHand.HasProperty(WeaponProperty.PLUS_3));
        }
    }
}
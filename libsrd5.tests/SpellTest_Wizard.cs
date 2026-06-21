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
            ground.AddCombatant(wizard, 5, 5);
            ground.AddCombatant(orc, 7, 7);
            ground.AddCombatant(shadow, 8, 8);
            ground.AddCombatant(barbarian, 9, 9);
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
            ground.AddCombatant(wizard, 5, 5);
            ground.AddCombatant(orc, 7, 7);
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
            ground.AddCombatant(wizard, 5, 5);
            ground.AddCombatant(orc, 7, 7);
            ground.AddCombatant(shadow, 8, 8);
            ground.AddCombatant(barbarian, 9, 49);
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
            ground.AddCombatant(wizard, 5, 5);
            ground.AddCombatant(orc, 7, 7);
            ground.AddCombatant(shadow, 5, 6);
            ground.AddCombatant(barbarian, 9, 9);
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
            ground.AddCombatant(wizard, 5, 5);
            ground.AddCombatant(orc1, 5, 6);
            ground.AddCombatant(orc2, 6, 5);
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
            badger3.OnDamageTaken(new DamageSource(Attacks.NightHagClaws, hag), new Damage(DamageType.TRUE_DAMAGE, 1));
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
            hag.TakeDamage(new DamageSource(DamageSourceType.OTHER, this, hag), DamageType.FIRE, 1);
            Assert.Equal(hag.HitPointsMax, hag.HitPoints);
            hag.TakeDamage(new DamageSource(DamageSourceType.OTHER, this, hag), DamageType.FIRE, 30);
            Assert.True(hag.HitPointsMax > hag.HitPoints);
            hag.HealDamage(100);
            Spells.FalseLife.Cast(hag, 0, SpellLevel.NINTH, 0);
            Spells.FalseLife.Cast(hag, 0, SpellLevel.THIRD, 0);
            hag.TakeDamage(new DamageSource(DamageSourceType.OTHER, this, hag), DamageType.FIRE, 30);
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
        public void HypnoticPatternTest() {
            DefaultSpellTest(Spells.HypnoticPattern, 25, SpellLevel.THIRD, ConditionType.CHARMED, Effect.SPELL_HYPNOTIC_PATTERN, 10);
        }

        [Fact]
        public void HypnoticPatternEndsOnDamageTest() {
            CharacterSheet wizard = new CharacterSheet(Race.HUMAN);
            Monster orc = Monsters.Orc;
            int originalSpeed = orc.Speed;
            Battleground ground = createBattleground(wizard, orc);
            // High DC guarantees the orc fails its save and becomes charmed
            Random.State = 42;
            Spells.HypnoticPattern.Cast(ground, wizard, 25, SpellLevel.THIRD, 0, orc);
            Assert.True(orc.HasCondition(ConditionType.CHARMED));
            Assert.True(orc.HasCondition(ConditionType.INCAPACITATED));
            Assert.True(orc.HasEffect(Effect.SPELL_HYPNOTIC_PATTERN));
            Assert.Equal(0, orc.Speed);
            // Taking any damage ends the spell
            orc.TakeDamage(new DamageSource(Spells.ID.HYPNOTIC_PATTERN, wizard), DamageType.FIRE, 1);
            Assert.False(orc.HasCondition(ConditionType.CHARMED));
            Assert.False(orc.HasCondition(ConditionType.INCAPACITATED));
            Assert.False(orc.HasEffect(Effect.SPELL_HYPNOTIC_PATTERN));
            Assert.Equal(originalSpeed, orc.Speed);
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
            Spells.MagicWeapon.Cast(hero, 10, SpellLevel.NINTH, 5);
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

        [Fact]
        public void MirrorImageTest() {
            DefaultSpellTest(Spells.MirrorImage, 12, SpellLevel.SECOND, null, Effect.SPELL_MIRROR_IMAGE_3, Spells.MirrorImage.Duration);
            Monster hag = Monsters.NightHag;
            Monster ogre = Monsters.Ogre;
            Spells.MirrorImage.Cast(hag, 10, SpellLevel.FOURTH, 5);
            for (int i = 0; i < 20; i++) {
                ogre.Attack(Attacks.BadgerBite, hag, 5);
                hag.OnStartOfTurn();
            }
            hag.OnEndOfTurn();
            Assert.True(hag.StartOfTurnEvents.Length == 0);
            Assert.True(hag.EndOfTurnEvents.Length == 0);
        }

        [Fact]
        public void RayofEnfeeblementTest() {
            DefaultSpellTest(Spells.RayofEnfeeblement, 15, SpellLevel.SECOND, null, Effect.SPELL_RAY_OF_ENFEEBLEMENT, Spells.RayofEnfeeblement.Duration);
            Monster ogre = Monsters.Ogre;
            Monster bandit = Monsters.Bandit;
            ogre.AddEffect(Effect.SPELL_RAY_OF_ENFEEBLEMENT);
            for (int i = 0; i < 20; i++) {
                ogre.Attack(Attacks.OgreGreatclub, bandit, 5); // could be fatal without effect
                Assert.False(bandit.Dead);
                bandit.HealDamage(100);
            }
        }

        [Fact]
        public void ScorchingRayTest() {
            Monster hag = Monsters.NightHag;
            Monster orc = Monsters.Orc;
            Monster bandit = Monsters.Bandit;
            Battleground ground = createBattleground(hag, orc, bandit);
            Spells.ScorchingRay.Cast(ground, hag, 20, SpellLevel.NINTH, 5, orc, bandit);
            Assert.True(orc.Dead);
            Assert.True(bandit.Dead);
        }

        [Fact]
        public void ShatterTest() {
            Monster hag = Monsters.NightHag;
            Monster orc = Monsters.Orc;
            Monster stonegolem = Monsters.StoneGolem;
            Monster fleshgolem = Monsters.FleshGolem;
            Battleground ground = createBattleground(hag, orc, stonegolem, fleshgolem);
            Spells.Shatter.Cast(ground, hag, 20, SpellLevel.FIFTH, 5, orc, stonegolem, fleshgolem);
            Assert.True(orc.HitPointsMax > orc.HitPoints);
            Assert.True(stonegolem.HitPointsMax > stonegolem.HitPoints);
            Assert.True(fleshgolem.HitPointsMax > fleshgolem.HitPoints);
        }

        [Fact]
        public void HasteTest() {
            Monster wizard = Monsters.Mage;
            int originalSpeed = wizard.Speed;
            int originalAC = wizard.ArmorClass;
            Spells.Haste.Cast(wizard, 12, SpellLevel.THIRD, 0);
            Assert.True(wizard.HasEffect(Effect.SPELL_HASTE));
            Assert.Equal(originalSpeed * 2, wizard.Speed);
            Assert.Equal(originalAC + 2, wizard.ArmorClass);
            Assert.True(wizard.HasEffect(Effect.ONE_EXTRA_ATTACK));
            // Test duration cleanup
            wizard.RemoveEffect(Effect.SPELL_HASTE);
            Assert.Equal(originalSpeed, wizard.Speed);
            Assert.Equal(originalAC, wizard.ArmorClass);
            Assert.False(wizard.HasEffect(Effect.ONE_EXTRA_ATTACK));
        }

        [Fact]
        public void SlowTest() {
            DefaultSpellTest(Spells.Slow, 15, SpellLevel.THIRD, null, Effect.SPELL_SLOW, Spells.Slow.Duration);

            Monster orc = Monsters.Orc;
            int originalSpeed = orc.Speed;
            Spells.Slow.Cast(orc, 100, SpellLevel.THIRD, 0);
            Assert.True(orc.HasEffect(Effect.SPELL_SLOW));
            Assert.True(orc.HasEffect(Effect.DISADVANTAGE_DEXTERITY_SAVES));
            Assert.True(orc.HasEffect(Effect.DISADVANTAGE_ON_ATTACK));
            Assert.True(orc.HasEffect(Effect.CANNOT_TAKE_REACTIONS));
            Assert.Equal(originalSpeed / 2, orc.Speed);
            // Test duration cleanup
            orc.RemoveEffect(Effect.SPELL_SLOW);
            Assert.Equal(originalSpeed, orc.Speed);
            Assert.False(orc.HasEffect(Effect.DISADVANTAGE_DEXTERITY_SAVES));
            Assert.False(orc.HasEffect(Effect.DISADVANTAGE_ON_ATTACK));
            Assert.False(orc.HasEffect(Effect.CANNOT_TAKE_REACTIONS));
        }

        [Fact]
        public void ProtectionFromEnergyTest() {
            Monster orc = Monsters.Orc;
            int originalHP = orc.HitPoints;
            // Test Fire resistance variant
            Spell spell = Spells.ProtectionFromEnergy;
            spell.Variant = SpellVariant.DAMAGE_FIRE;
            spell.Cast(orc, 12, SpellLevel.THIRD, 0);
            Assert.True(orc.HasEffect(Effect.SPELL_PROTECTION_FROM_ENERGY));
            Assert.True(orc.HasEffect(Effect.RESISTANCE_FIRE));
            orc.TakeDamage(new DamageSource(DamageSourceType.OTHER, this, orc), DamageType.FIRE, 20);
            int damageTaken = originalHP - orc.HitPoints;
            Assert.True(damageTaken <= 10); // half damage due to resistance
            // Test Cold resistance variant
            Monster bandit = Monsters.Bandit;
            spell.Variant = SpellVariant.DAMAGE_COLD;
            int banditOriginalHP = bandit.HitPoints;
            spell.Cast(bandit, 12, SpellLevel.THIRD, 0);
            Assert.True(bandit.HasEffect(Effect.RESISTANCE_COLD));
            bandit.TakeDamage(new DamageSource(DamageSourceType.OTHER, this, bandit), DamageType.COLD, 20);
            int coldDamageTaken = banditOriginalHP - bandit.HitPoints;
            Assert.True(coldDamageTaken <= 10);
        }

        [Fact]
        public void ProtectionFromEnergyLightningTest() {
            Monster orc = Monsters.Orc;
            Spell spell = Spells.ProtectionFromEnergy;
            spell.Variant = SpellVariant.DAMAGE_LIGHTNING;
            spell.Cast(orc, 12, SpellLevel.THIRD, 0);
            Assert.True(orc.HasEffect(Effect.RESISTANCE_LIGHTNING));
        }

        [Fact]
        public void ProtectionFromEnergyThunderTest() {
            Monster bandit = Monsters.Bandit;
            Spell spell = Spells.ProtectionFromEnergy;
            spell.Variant = SpellVariant.DAMAGE_THUNDER;
            spell.Cast(bandit, 12, SpellLevel.THIRD, 0);
            Assert.True(bandit.HasEffect(Effect.RESISTANCE_THUNDER));
        }

        [Fact]
        public void BestowCurseTest() {
            Spell curse = Spells.BestowCurse;
            curse.Variant = SpellVariant.DISADVANTAGE_CHARISMA_SAVES;
            DefaultSpellTest(curse, 15, SpellLevel.THIRD, null, Effect.DISADVANTAGE_CHARISMA_SAVES, SpellDuration.ONE_MINUTE);
            DefaultSpellTest(curse, 15, SpellLevel.FOURTH, null, Effect.DISADVANTAGE_CHARISMA_SAVES, SpellDuration.TEN_MINUTES);
            DefaultSpellTest(curse, 15, SpellLevel.FIFTH, null, Effect.DISADVANTAGE_CHARISMA_SAVES, SpellDuration.EIGHT_HOURS);
            DefaultSpellTest(curse, 15, SpellLevel.EIGHTH, null, Effect.DISADVANTAGE_CHARISMA_SAVES, SpellDuration.ONE_DAY);
        }

        [Fact]
        public void BestowCurseSaveSuccessTest() {
            // Target succeeds the WIS save (DC=1) → spell has no effect
            Spell curse = Spells.BestowCurse;
            curse.Variant = SpellVariant.DISADVANTAGE_CHARISMA_SAVES;
            Monster orc = Monsters.Orc;
            Battleground ground = createBattleground(orc, orc);
            Random.State = 42; // D20=13 which beats DC=1
            curse.Cast(ground, orc, 1, SpellLevel.THIRD, 0, orc);
            Assert.False(orc.HasEffect(Effect.SPELL_BESTOW_CURSE));
        }

        [Fact]
        public void BestowCurseLoseTurnTest() {
            // LOSE_TURN variant: target fails initial save then fails StartOfTurn save → LOST_TURN added
            CharacterSheet wizard = new CharacterSheet(Race.HUMAN);
            wizard.AddLevel(CharacterClasses.Wizard);
            Monster orc = Monsters.Orc;
            Battleground ground = createBattleground(wizard, orc);
            Spell curse = Spells.BestowCurse;
            curse.Variant = SpellVariant.LOSE_TURN_ON_FAILED_WISDOM_SAVE;
            DefaultSpellTest(curse, 25, SpellLevel.THIRD, null, Effect.SPELL_BESTOW_CURSE_LOSE_TURN_ON_FAILED_WISDOM_SAVE, SpellDuration.ONE_MINUTE);
            Random.State = 42; // D20=13 < DC=25 → orc fails initial save
            curse.Cast(ground, wizard, 25, SpellLevel.THIRD, 0, orc);
            Assert.True(orc.HasEffect(Effect.SPELL_BESTOW_CURSE_LOSE_TURN_ON_FAILED_WISDOM_SAVE));
            // Reseed to ensure StartOfTurn save also fails (D20=13 < DC=25)
            Random.State = 42;
            orc.OnStartOfTurn();
            Assert.True(orc.HasEffect(Effect.SPELL_BESTOW_CURSE_LOST_TURN));
        }

        [Fact]
        public void BestowCurseTakeAdditionalDamageTest() {
            // TAKE_ADDITIONAL_DAMAGE variant: fires DamageTakenEvent when target takes damage
            CharacterSheet wizard = new CharacterSheet(Race.HUMAN);
            wizard.AddLevel(CharacterClasses.Wizard);
            Monster orc = Monsters.Orc;
            int hpBefore = orc.HitPoints;
            Battleground ground = createBattleground(wizard, orc);
            Spell curse = Spells.BestowCurse;
            curse.Variant = SpellVariant.TAKE_ADDITIONAL_DAMAGE;
            Random.State = 42; // D20=13 < DC=25 → orc fails initial save
            curse.Cast(ground, wizard, 25, SpellLevel.THIRD, 0, orc);
            Assert.True(orc.HasEffect(Effect.SPELL_BESTOW_CURSE_TAKE_ADDITIONAL_DAMAGE));
            // Trigger the DamageTakenEvent delegate body by dealing damage
            orc.TakeDamage(new DamageSource(DamageSourceType.SPELL, wizard, orc), DamageType.FIRE, 1);
            Assert.True(orc.HitPoints < hpBefore - 1); // should take more than 1 damage
            hpBefore = orc.HitPoints;
            orc.RemoveEffect(Effect.SPELL_BESTOW_CURSE_TAKE_ADDITIONAL_DAMAGE);
            orc.TakeDamage(new DamageSource(DamageSourceType.OTHER, wizard, orc), DamageType.FIRE, 1);
            Assert.Equal(hpBefore - 1, orc.HitPoints); // should take exactly one damage
        }

        [Fact]
        public void BlinkTest() {
            CharacterSheet wizard = new CharacterSheet(Race.HUMAN);
            wizard.AddLevel(CharacterClasses.Wizard);
            Spells.Blink.Cast(wizard, 12, SpellLevel.THIRD, 0);
            Assert.False(wizard.HasEffect(Effect.CANNOT_BE_ATTACKED));
            // Seed 11 → first D20 = 20 > 11, so CANNOT_BE_ATTACKED is applied
            Random.State = 11;
            wizard.OnEndOfTurn();
            Assert.True(wizard.HasEffect(Effect.CANNOT_BE_ATTACKED));
            // Next start-of-turn removes the effect
            wizard.OnStartOfTurn();
            Assert.False(wizard.HasEffect(Effect.CANNOT_BE_ATTACKED));
            Spells.Blink.Cast(wizard, 12, SpellLevel.THIRD, 0);
            // Expire effect
            for (int i = 0; i < (int)Spells.Blink.Duration; i++) {
                wizard.OnEndOfTurn();
                wizard.OnStartOfTurn();
            }
            Assert.False(wizard.HasEffect(Effect.CANNOT_BE_ATTACKED));
        }

        [Fact]
        public void DispelMagicHigherLevelSpellTest() {
            // Caster dispels a higher-level (3rd) effect when casting at 2nd slot via DC check
            CharacterSheet wizard = new CharacterSheet(Race.HUMAN);
            wizard.AddLevel(CharacterClasses.Wizard);
            wizard.AvailableSpells[0].AddKnownSpell(Spells.DispelMagic);
            Monster orc = Monsters.Orc;
            orc.AddEffect(Effect.SPELL_FEAR); // 3rd-level spell effect
            Battleground ground = createBattleground(wizard, orc);
            // Seed 2 → D20=19; wizard INT mod=0 + prof=2 → 21 >= DC 13 (10 + SpellLevel.THIRD) → dispelled
            Random.State = 2;
            Spells.DispelMagic.Cast(ground, wizard, 12, SpellLevel.SECOND, 0, orc);
            Assert.False(orc.HasEffect(Effect.SPELL_FEAR));
        }

        [Fact]
        public void FearDropsEquipmentTest() {
            // Fear applied to a CharacterSheet unequips their held weapon
            CharacterSheet hero = new CharacterSheet(Race.HUMAN);
            hero.AddLevel(CharacterClasses.Barbarian);
            hero.Equip(Weapons.Dagger);
            Assert.True(hero.Inventory.MainHand.Is(Weapons.Dagger));
            CharacterSheet wizard = new CharacterSheet(Race.HUMAN);
            Battleground ground = createBattleground(wizard, hero);
            Random.State = 42; // D20=13 < DC=25 → hero fails WIS save
            Spells.Fear.Cast(ground, wizard, 25, SpellLevel.THIRD, 0, hero);
            Assert.True(hero.HasCondition(ConditionType.FRIGHTENED));
            // Weapon should have been unequipped (Fear drops held items on CharacterSheets)
            Assert.Null(hero.Inventory.MainHand);
        }

        [Fact]
        public void FearDurationExpiresTest() {
            DefaultSpellTest(Spells.Fear, 25, SpellLevel.THIRD, ConditionType.FRIGHTENED, Effect.SPELL_FEAR, SpellDuration.ONE_MINUTE);
            // After ONE_MINUTE (10) start-of-turn events, FRIGHTENED and SPELL_FEAR are removed
            CharacterSheet wizard = new CharacterSheet(Race.HUMAN);
            Monster orc = Monsters.Orc;
            Battleground ground = createBattleground(wizard, orc);
            Random.State = 42; // ensures initial WIS save fails (D20=13 < DC=25)
            Spells.Fear.Cast(ground, wizard, 25, SpellLevel.THIRD, 0, orc);
            Assert.True(orc.HasCondition(ConditionType.FRIGHTENED));
            // Simulate 10 start-of-turn ticks; remainingRounds reaches 0 on the last one
            for (int i = 0; i < 10; i++) {
                orc.OnStartOfTurn();
            }
            Assert.False(orc.HasCondition(ConditionType.FRIGHTENED));
            Assert.False(orc.HasEffect(Effect.SPELL_FEAR));
        }

        [Fact]
        public void FearDistanceSaveTest() {
            // When target is > 300ft from caster, EndOfTurnEvent allows a WIS save to end Fear
            CharacterSheet wizard = new CharacterSheet(Race.HUMAN);
            Monster orc = Monsters.Orc;
            // 62 tiles × 5ft = 310ft > 300ft threshold
            Battleground2D ground = new Battleground2D(70, 5);
            ground.AddCombatant(wizard, 1, 1);
            ground.AddCombatant(orc, 63, 1);
            // Seed 42 → D20=13 (< DC=25) → orc fails initial WIS save, becomes FRIGHTENED
            Random.State = 42;
            Spells.Fear.Cast(ground, wizard, 25, SpellLevel.THIRD, 0, orc);
            Assert.True(orc.HasCondition(ConditionType.FRIGHTENED));
            // Seed 11 → D20=20 (nat 20 auto-succeeds DC=25) → EndOfTurnEvent removes FRIGHTENED
            Random.State = 11;
            orc.OnEndOfTurn();
            Assert.False(orc.HasCondition(ConditionType.FRIGHTENED));
            Assert.False(orc.HasEffect(Effect.SPELL_FEAR));
        }

        [Fact]
        public void VampiricTouchMissTest() {
            // Initial attack roll misses → AffectBySpell(false) fires on the attack sub-spell
            CharacterSheet wizard = new CharacterSheet(Race.HUMAN);
            wizard.AddLevel(CharacterClasses.Wizard);
            Monster orc = Monsters.Orc; // AC=13
            int hpBefore = wizard.HitPoints;
            Battleground ground = createBattleground(wizard, orc);
            // Seed 1 → D20=10; 10 + modifier(0) = 10 < 13 (orc AC) → miss
            Random.State = 1;
            Spells.VampiricTouch.Cast(ground, wizard, 12, SpellLevel.THIRD, 0, orc);
            // Caster should not have healed (miss means no damage dealt)
            Assert.Equal(hpBefore, wizard.HitPoints);
        }

        [Fact]
        public void VampiricTouchDurationExpiresTest() {
            // After ONE_MINUTE (10) end-of-turn events the attack cantrip is removed
            CharacterSheet wizard = new CharacterSheet(Race.HUMAN);
            wizard.AddLevel(CharacterClasses.Wizard);
            Monster orc = Monsters.Orc;
            int knownSpellsBeforeCast = wizard.AvailableSpells[0].KnownSpells.Length;
            Battleground ground = createBattleground(wizard, orc);
            // High modifier guarantees the initial attack hits so we don't rely on RNG for the attack
            Spells.VampiricTouch.Cast(ground, wizard, 12, SpellLevel.THIRD, 100, orc);
            Assert.Equal(knownSpellsBeforeCast + 1, wizard.AvailableSpells[0].KnownSpells.Length);
            // Simulate 10 end-of-turn events; the 10th expires the duration and removes the cantrip
            for (int i = 0; i < 10; i++) {
                wizard.OnEndOfTurn();
            }
            Assert.Equal(knownSpellsBeforeCast, wizard.AvailableSpells[0].KnownSpells.Length);
        }
    }
}
using System;
using System.Reflection;
using Xunit;
using static srd5.Die;

namespace srd5 {
    [CollectionDefinition("SingleThreaded", DisableParallelization = true)]
    [Collection("SingleThreaded")]
    public partial class SpellTest {
        [Fact]
        public void AllSpellsTest() {
            foreach (PropertyInfo property in typeof(Spells).GetProperties()) {
                object o = property.GetMethod.Invoke(null, null);
                Assert.True(o is Spell);
            }
        }
        private BattleGroundClassic createBattleground(Combattant caster, params Combattant[] targets) {
            BattleGroundClassic ground = new BattleGroundClassic();
            ground.AddCombattant(caster, ClassicLocation.Row.FRONT_LEFT);
            foreach (Combattant target in targets) {
                ground.AddCombattant(target, ClassicLocation.Row.FRONT_RIGHT);
            }
            return ground;
        }

        [Fact]
        public void DiceSlotScalingTest() {
            Dice dice = Spells.DiceSlotScaling(SpellLevel.FIRST, SpellLevel.SECOND, D6, 1, 2, 2);
            Assert.Equal("3d6+2", dice.ToString());
            dice = Spells.DiceSlotScaling(SpellLevel.FIRST, SpellLevel.THIRD, D8, 1, -2, 2);
            Assert.Equal("5d8-2", dice.ToString());
            Assert.Throws<Srd5ArgumentException>(delegate {
                dice = Spells.DiceSlotScaling(SpellLevel.THIRD, SpellLevel.SECOND, D6, 1, 2, 2);
            });
        }

        [Fact]
        public void EffectAndConditionTest() {
            Monster bandit = Monsters.Bandit;
            Spells.AddEffectAndConditionsForDuration(Spells.ID.AID, bandit, bandit, SpellDuration.ONE_MINUTE, Effect.SPELL_AID, ConditionType.BLINDED);
            for (int i = 0; i < 3; i++) {
                bandit.OnStartOfTurn();
                bandit.OnEndOfTurn();
                bandit.RemoveEffect(Effect.SPELL_AID);
                bandit.RemoveCondition(ConditionType.BLINDED);
            }
            Assert.True(bandit.StartOfTurnEvents.Length == 0);
            Assert.True(bandit.EndOfTurnEvents.Length == 0);
        }


        [Fact]
        public void AcidSplashTest() {
            CharacterSheet hero = new CharacterSheet(Race.HUMAN, true);
            Monster ogre = Monsters.Ogre;
            for (int i = 0; i < 17; i++) {
                hero.AddLevel(CharacterClasses.Druid);
                if (i == 1 || i == 4 || i == 10 || i == 16) {
                    int hpBefore = ogre.HitPoints;
                    Spells.AcidSplash.Cast(createBattleground(hero, ogre), hero, 8 + hero.ProficiencyBonus + hero.Intelligence.Modifier, SpellLevel.CANTRIP, hero.Intelligence.Modifier, ogre);
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
            Spells.MagicMissile.Cast(createBattleground(hero, ogre1, ogre2, ogre3, ogre4, ogre5), hero, 8 + hero.ProficiencyBonus + hero.Intelligence.Modifier, SpellLevel.SECOND, hero.Intelligence.Modifier, ogre1, ogre2, ogre3, ogre4, ogre5);
            Assert.True(ogre1.HitPoints < ogre1.HitPointsMax);
            Assert.True(ogre2.HitPoints < ogre2.HitPointsMax);
            Assert.True(ogre3.HitPoints < ogre3.HitPointsMax);
            Assert.True(ogre4.HitPoints < ogre4.HitPointsMax);
            Assert.Equal(ogre5.HitPointsMax, ogre5.HitPoints);
        }

        [Fact]
        public void CureWoundsTest() {
            CharacterSheet hero = new CharacterSheet(Race.GNOME);
            Battleground ground = createBattleground(hero);
            hero.AddLevel(CharacterClasses.Druid);
            hero.HitPoints = 1;
            Spells.CureWounds.Cast(ground, hero, 0, SpellLevel.NINETH, hero.Wisdom.Modifier, hero);
            Assert.Equal(hero.HitPointsMax, hero.HitPoints);
            // doesn't affect undead
            Monster shadow = Monsters.Shadow;
            shadow.HitPoints = shadow.HitPointsMax - 1;
            Spells.CureWounds.Cast(ground, hero, 0, SpellLevel.NINETH, hero.Wisdom.Modifier, shadow);
            Assert.Equal(shadow.HitPointsMax - 1, shadow.HitPoints);
            // doesn't affect constructs
            Monster golem = Monsters.ClayGolem;
            golem.HitPoints = golem.HitPointsMax - 1;
            Spells.CureWounds.Cast(ground, hero, 0, SpellLevel.NINETH, hero.Wisdom.Modifier, golem);
            Assert.Equal(golem.HitPointsMax - 1, golem.HitPoints);
            // affects giants
            Monster ogre = Monsters.Ogre;
            ogre.HitPoints = ogre.HitPointsMax - 10;
            Spells.CureWounds.Cast(ground, hero, 0, SpellLevel.NINETH, hero.Wisdom.Modifier, ogre);
            Assert.Equal(ogre.HitPointsMax, ogre.HitPoints);
        }

        [Fact]
        public void HealingWordTest() {
            CharacterSheet hero = new CharacterSheet(Race.GNOME);
            hero.AddLevel(CharacterClasses.Druid);
            hero.HitPoints = 1;
            Spells.HealingWord.Cast(createBattleground(hero), hero, 0, SpellLevel.SEVENTH, hero.Wisdom.Modifier, hero);
            Assert.Equal(hero.HitPointsMax, hero.HitPoints);
            // doesn't affect undead
            Monster shadow = Monsters.Shadow;
            shadow.HitPoints = shadow.HitPointsMax - 1;
            Spells.HealingWord.Cast(createBattleground(hero, shadow), hero, 0, SpellLevel.NINETH, hero.Wisdom.Modifier, shadow);
            Assert.Equal(shadow.HitPointsMax - 1, shadow.HitPoints);
            // doesn't affect constructs
            Monster golem = Monsters.ClayGolem;
            golem.HitPoints = golem.HitPointsMax - 1;
            Spells.HealingWord.Cast(createBattleground(hero, golem), hero, 0, SpellLevel.NINETH, hero.Wisdom.Modifier, golem);
            Assert.Equal(golem.HitPointsMax - 1, golem.HitPoints);
            // affects giants
            Monster ogre = Monsters.Ogre;
            ogre.HitPoints = ogre.HitPointsMax - 10;
            Spells.HealingWord.Cast(createBattleground(hero, ogre), hero, 0, SpellLevel.NINETH, hero.Wisdom.Modifier, ogre);
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
                else {
                    hero.Equip(Weapons.Quarterstaff);
                    hero.BonusAttack = Attack.FromWeapon(hero.AttackProficiency, "1d6", Weapons.Quarterstaff);
                }
                Assert.Equal(hero.ProficiencyBonus + hero.Strength.Modifier, hero.MeleeAttacks[0].AttackBonus);
                Spells.Shillelagh.Cast(hero, 0, SpellLevel.CANTRIP, hero.Wisdom.Modifier);
                Assert.Equal(hero.ProficiencyBonus + hero.Wisdom.Modifier, hero.MeleeAttacks[0].AttackBonus);
                if (hero.Inventory.MainHand.Is(Weapons.Quarterstaff)) {
                    Assert.Equal(Spells.ID.SHILLELAGH.Name(), hero.BonusAttack.Name);
                }
            }
            // Also check with wrong weapon
            hero = new CharacterSheet(Race.HALF_ELF, true);
            hero.AddLevel(CharacterClasses.Druid);
            hero.Equip(Weapons.Greataxe);
            Assert.Equal(hero.Strength.Modifier, hero.MeleeAttacks[0].AttackBonus);
            Spells.Shillelagh.Cast(hero, 0, SpellLevel.CANTRIP, hero.Wisdom.Modifier);
            Assert.Equal(hero.Strength.Modifier, hero.MeleeAttacks[0].AttackBonus);
            // Monster test (cannot cast Shillelagh yet)
            Spells.Shillelagh.Cast(Monsters.Goblin, 0, SpellLevel.CANTRIP, 3);
        }

        [Fact]
        public void SpellTargetTest() {
            Monster druid = Monsters.Druid;
            Monster bandit = Monsters.Bandit;
            bandit.HitPoints = 6;
            Battleground ground = createBattleground(druid, bandit);
            Assert.Throws<Srd5ArgumentException>(delegate () {
                Spells.Moonbeam.Cast(ground, druid, 10, SpellLevel.SIXTH, 0);
            });
        }

        private void DefaultSpellTest(Spell spell, int dc, SpellLevel slot, ConditionType? checkForCondition, Effect? checkForEffect, SpellDuration simulateTurns, Monsters.Type monsterType = Monsters.Type.BEAST) {
            DefaultSpellTest(spell, dc, slot, checkForCondition, checkForEffect, (int)simulateTurns, monsterType);
        }

        private void DefaultSpellTest(Spell spell, int dc, SpellLevel slot, ConditionType? checkForCondition, Effect? checkForEffect, int? simulateTurns, Monsters.Type monsterType = Monsters.Type.BEAST) {
            if (checkForCondition == null && checkForEffect == null) throw new ArgumentException("Don't use is when not checking for Condition and/or Effect");
            CharacterSheet hero = new CharacterSheet(Race.DRAGONBORN, true);
            hero.AddLevels(CharacterClasses.Wizard, CharacterClasses.Druid, CharacterClasses.Bard, CharacterClasses.Barbarian);
            Combattant nonMonster1 = new CharacterSheet(Race.HUMAN);
            Combattant nonMonster2 = new CharacterSheet(Race.HALFLING);
            Monster orc1 = Monsters.Orc;
            Monster orc2 = Monsters.Orc;
            Monster orc3 = Monsters.Orc;
            Monster badger = Monsters.Badger;
            Monster zombie = Monsters.Zombie;
            Monster dragon = Monsters.AncientBlackDragon;
            Monster typed = new Monster(monsterType, Monsters.ID.MANTICORE, Alignment.UNALIGNED, 10, 10, 10, 10, 10, 10, 10, "5d8", 30, 2, new Attack[0], new Attack[0], Size.MEDIUM, 5);
            Monster typedImmune = new Monster(monsterType, Monsters.ID.MANTICORE, Alignment.UNALIGNED, 10, 10, 10, 10, 10, 10, 10, "5d8", 30, 2, new Attack[0], new Attack[0], Size.MEDIUM, 5);
            typedImmune.AddEffect(Effect.IMMUNITY_ACID, Effect.IMMUNITY_BLINDED, Effect.IMMUNITY_BLUDGEONING, Effect.IMMUNITY_CHARMED, Effect.IMMUNITY_COLD, Effect.IMMUNITY_DAMAGE_FROM_SPELLS,
                Effect.IMMUNITY_DEAFENED, Effect.IMMUNITY_EXHAUSTION, Effect.IMMUNITY_FIRE, Effect.IMMUNITY_FORCE, Effect.IMMUNITY_FRIGHTENED, Effect.IMMUNITY_GRAPPLED, Effect.IMMUNITY_INCAPACITATED,
                Effect.IMMUNITY_INVISIBLE, Effect.IMMUNITY_LIGHTNING, Effect.IMMUNITY_NECROTIC, Effect.IMMUNITY_NONMAGIC, Effect.IMMUNITY_PARALYZED, Effect.IMMUNITY_PETRIFIED, Effect.IMMUNITY_PIERCING,
                Effect.IMMUNITY_POISON, Effect.IMMUNITY_POISONED, Effect.IMMUNITY_PRONE, Effect.IMMUNITY_PSYCHIC, Effect.IMMUNITY_RADIANT, Effect.IMMUNITY_RESTRAINED, Effect.IMMUNITY_SLEEP,
                Effect.IMMUNITY_SLEEP, Effect.IMMUNITY_STUNNED, Effect.IMMUNITY_THUNDER, Effect.IMMUNITY_UNCONSCIOUS);

            Combattant[] targets = new Combattant[] {
                nonMonster1, nonMonster2, orc1, orc2, orc3, badger, zombie, dragon, typed, typedImmune
            };

            Battleground ground = createBattleground(hero, nonMonster1, nonMonster2, orc1, orc2, orc3, badger, zombie, dragon, typed, typedImmune);
            Random.State = 1;
            if (spell.MaximumTargets > 1) {
                for (int i = 0; i < 5; i++) {
                    spell.Cast(ground, hero, dc, slot, 5, targets[2 * i], targets[2 * i + 1]);
                }
            } else {
                foreach (Combattant target in targets) {
                    spell.Cast(ground, hero, dc, slot, 5, target);
                }
            }
            if (checkForCondition != null) {
                ConditionType cond = (ConditionType)checkForCondition;
                Assert.True(
                    hero.HasCondition(cond) || nonMonster1.HasCondition(cond) || nonMonster2.HasCondition(cond) || orc1.HasCondition(cond) || orc2.HasCondition(cond) || orc3.HasCondition(cond) || badger.HasCondition(cond) || zombie.HasCondition(cond) || dragon.HasCondition(cond) || typed.HasCondition(cond)
                );
                Assert.False(typedImmune.HasCondition(cond));
            }
            if (checkForEffect != null) {
                Effect eff = (Effect)checkForEffect;
                Assert.True(
                    hero.HasEffect(eff) || nonMonster1.HasEffect(eff) || nonMonster2.HasEffect(eff) || orc1.HasEffect(eff) || orc2.HasEffect(eff) || orc3.HasEffect(eff) || badger.HasEffect(eff) || zombie.HasEffect(eff) || dragon.HasEffect(eff) || typed.HasEffect(eff)
                );
            }
            if (simulateTurns != null) {
                int turns = (int)simulateTurns;
                if (checkForEffect != null) {
                    orc3.RemoveEffect((Effect)checkForEffect);
                }
                if (checkForCondition != null) {
                    orc3.RemoveCondition((ConditionType)checkForCondition);
                }
                for (int i = 0; i < turns; i++) {
                    hero.OnEndOfTurn();

                    foreach (Combattant target in targets) {
                        target.OnStartOfTurn();
                    }

                    hero.OnStartOfTurn();
                    hero.OnEndOfTurn();

                    foreach (Combattant target in targets) {
                        target.OnEndOfTurn();
                    }

                    foreach (Combattant target in targets) {
                        target.OnDamageTaken(this, new Damage(DamageType.THUNDER, 1));
                    }
                }
                if (checkForCondition != null) {
                    ConditionType cond = (ConditionType)checkForCondition;
                    Assert.False(
                        hero.HasCondition(cond) || nonMonster1.HasCondition(cond) || nonMonster2.HasCondition(cond) || orc1.HasCondition(cond) || orc2.HasCondition(cond) || orc3.HasCondition(cond) || badger.HasCondition(cond) || zombie.HasCondition(cond) || dragon.HasCondition(cond) || typed.HasCondition(cond)
                    );
                }
                if (checkForEffect != null) {
                    Effect eff = (Effect)checkForEffect;
                    Assert.False(
                        hero.HasEffect(eff) || nonMonster1.HasEffect(eff) || nonMonster2.HasEffect(eff) || orc1.HasEffect(eff) || orc2.HasEffect(eff) || orc3.HasEffect(eff) || badger.HasEffect(eff) || zombie.HasEffect(eff) || dragon.HasEffect(eff) || typed.HasEffect(eff)
                    );
                }
            }
        }

        private void DamagingSpellTesting(Spell spell, int dc, DamageType damageType) {
            Monster hag = Monsters.NightHag;
            Monster monster1 = Monsters.Bandit;
            Monster monster2 = Monsters.Baboon;
            monster2.AddEffect(Enum.Parse<Effect>("IMMUNITY_" + Enum.GetName<DamageType>(damageType)));
            Battleground ground = createBattleground(hag, monster1, monster2);
            for (int i = 0; i < 10; i++) {
                spell.Cast(ground, hag, dc, spell.Level, 0, monster1, monster2);
                spell.Cast(ground, hag, dc, spell.Level, 0, monster2, monster1);
            }
            Assert.True(monster1.HitPoints < monster1.HitPointsMax);
            Assert.True(monster2.HitPoints == monster2.HitPointsMax);
        }

        [Fact]
        public void CharmPersonTest() {
            Combattant hag = Monsters.NightHag;
            Combattant badger = Monsters.GiantBadger;
            Spells.CharmPerson.Cast(Monsters.NightHag, 10, SpellLevel.CANTRIP, 10);
            Spells.CharmPerson.Cast(createBattleground(hag, badger), hag, 10, SpellLevel.SECOND, 10, badger); // not affected
            DefaultSpellTest(Spells.CharmPerson, 14, SpellLevel.SIXTH, ConditionType.CHARMED, null, null);
        }

        [Fact]
        public void HoldPersonTest() {
            Combattant hag = Monsters.NightHag;
            Combattant badger = Monsters.GiantBadger;
            CharacterSheet hero = new CharacterSheet(Race.HUMAN);
            Spells.HoldPerson.Cast(createBattleground(hag, badger), hag, 10, SpellLevel.SECOND, 10, badger); // not affected

            hero.AddEffect(Effect.IMMUNITY_PARALYZED);
            Spells.HoldPerson.Cast(createBattleground(hag, hero), hag, 10, SpellLevel.SECOND, 10, hero); // immune to paralyze
            DefaultSpellTest(Spells.HoldPerson, 14, SpellLevel.SEVENTH, ConditionType.PARALYZED, null, 100);
        }

        [Fact]
        public void EntangleTest() {
            DefaultSpellTest(Spells.Entangle, 14, SpellLevel.FIRST, null, Effect.SPELL_ENTANGLE, 100);
        }

        [Fact]
        public void FairieFireTest() {
            DefaultSpellTest(Spells.FaerieFire, 14, SpellLevel.SECOND, null, Effect.SPELL_FAIRIE_FIRE, 100);
        }

        [Fact]
        public void JumpTest() {
            DefaultSpellTest(Spells.Jump, 14, SpellLevel.THIRD, null, Effect.SPELL_JUMP, null);
        }

        [Fact]
        public void LongStriderTest() {
            CharacterSheet hero = new CharacterSheet(Race.GNOME);
            int speed = hero.Speed;
            Spells.Longstrider.Cast(hero, 10, SpellLevel.FIRST, 0);
            Assert.True(hero.Speed > speed);
            hero.RemoveEffect(Effect.SPELL_LONGSTRIDER);
            Assert.Equal(speed, hero.Speed);
        }

        [Fact]
        public void ProduceFlameTest() {
            CharacterSheet hero = new CharacterSheet(Race.GNOME);
            hero.AddLevel(CharacterClasses.Druid);
            Monster badger = Monsters.GiantBadger;
            int hps = badger.HitPoints;
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombattant(hero, 3, 3);
            ground.AddCombattant(badger, 5, 5);
            Spells.ProduceFlame.Cast(ground, hero, 10, SpellLevel.FIRST, 0, badger);
            hero.AddLevels(CharacterClasses.Druid, CharacterClasses.Druid, CharacterClasses.Druid, CharacterClasses.Druid, CharacterClasses.Druid);
            Spells.ProduceFlame.Cast(ground, hero, 10, SpellLevel.FIRST, 0, badger);
            hero.AddLevels(CharacterClasses.Druid, CharacterClasses.Druid, CharacterClasses.Druid, CharacterClasses.Druid, CharacterClasses.Druid, CharacterClasses.Druid);
            Spells.ProduceFlame.Cast(ground, hero, 10, SpellLevel.FIRST, 0, badger);
            hero.AddLevels(CharacterClasses.Druid, CharacterClasses.Druid, CharacterClasses.Druid, CharacterClasses.Druid, CharacterClasses.Druid, CharacterClasses.Druid);
            Spells.ProduceFlame.Cast(ground, hero, 10, SpellLevel.FIRST, 0, badger);
            Assert.True(badger.HitPoints < hps);
        }

        [Fact]
        public void ThunderwaveTest() {
            CharacterSheet hero = new CharacterSheet(Race.GNOME);
            hero.AddLevel(CharacterClasses.Druid);
            Monster badger = Monsters.Badger;
            int hps = badger.HitPoints;
            Random.State = 1;
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombattant(hero, 3, 3);
            ground.AddCombattant(badger, 5, 5);
            Assert.Equal(5, ground.LocateCombattant2D(badger).X);
            Spells.Thunderwave.Cast(ground, hero, 25, SpellLevel.FIRST, 0, badger);
            Spells.Thunderwave.Cast(ground, hero, 25, SpellLevel.FIRST, 0, badger);
            Spells.Thunderwave.Cast(ground, hero, 25, SpellLevel.FIRST, 0, badger);
            Assert.True(badger.HitPoints < hps);
            Assert.True(ground.LocateCombattant2D(badger).X > 5);

            BattleGroundClassic classic = new BattleGroundClassic();
            badger.HealDamage(1000);
            classic.AddCombattant(hero, ClassicLocation.Row.FRONT_LEFT);
            classic.AddCombattant(badger, ClassicLocation.Row.FRONT_RIGHT);
            Spells.Thunderwave.Cast(classic, hero, 25, SpellLevel.FIRST, 0, badger);
            Spells.Thunderwave.Cast(classic, hero, 25, SpellLevel.FIRST, 0, badger);
            Spells.Thunderwave.Cast(classic, hero, 25, SpellLevel.FIRST, 0, badger);
            Assert.True(badger.HitPoints < hps);
            Assert.Equal(ClassicLocation.Row.BACK_RIGHT, classic.LocateClassicCombattant(badger).Location);
        }

        [Fact]
        public void ResistanceTest() {
            CharacterSheet hero = new CharacterSheet(Race.GNOME);
            Spells.Resistance.Cast(hero, 10, SpellLevel.FIRST, 0);
            Assert.True(hero.HasEffect(Effect.SPELL_RESISTANCE));
            hero.DC(null, 10, AbilityType.STRENGTH);
            Assert.False(hero.HasEffect(Effect.SPELL_RESISTANCE));
        }

        [Fact]
        public void AnimalFriendshipTest() {
            DefaultSpellTest(Spells.AnimalFriendship, 14, SpellLevel.FIRST, ConditionType.CHARMED, null, null, Monsters.Type.BEAST);
        }

        [Fact]
        public void GoodberryTest() {
            CharacterSheet hero = new CharacterSheet(Race.GNOME);
            hero.AddLevel(CharacterClasses.Druid);
            Spells.Goodberry.Cast(hero, 12, SpellLevel.FIRST, 0);
            Assert.True(hero.Inventory.Bag.Length > 0);
            Assert.True(hero.Inventory.Bag[0].Name == Potions.Goodberry.Name);
            hero.TakeDamage(this, DamageType.TRUE_DAMAGE, 1);
            Assert.Equal(hero.HitPointsMax - 1, hero.HitPoints);
            hero.Consume(Potions.Goodberry);
            Assert.Equal(hero.HitPointsMax, hero.HitPoints);
        }

        [Fact]
        public void BarkskinTest() {
            Monster rat = Monsters.Rat;
            Monster dragon = Monsters.AncientBlackDragon;
            Spells.Barkskin.Cast(rat, 10, SpellLevel.FOURTH, 5);
            Assert.Equal(16, rat.ArmorClass);
            Assert.True(dragon.ArmorClass > 16);
            CharacterSheet hero = new CharacterSheet(Race.HILL_DWARF);
            hero.AddLevels(CharacterClasses.Barbarian);
            hero.Strength.BaseValue = 20;
            hero.Dexterity.BaseValue = 14;
            Spells.Barkskin.Cast(hero, 10, SpellLevel.SECOND, 0);
            Assert.Equal(16, hero.ArmorClass);
            hero.Equip(Armors.PlateArmor);
            Assert.True(hero.ArmorClass > 16);
        }

        [Fact]
        public void DarkvisionTest() {
            DefaultSpellTest(Spells.Darkvision, 20, SpellLevel.SECOND, null, Effect.DARKVISION, SpellDuration.EIGHT_HOURS);
        }

        [Fact]
        public void EnhanceAbilityTest() {
            SpellVariant[] variants = new SpellVariant[] { SpellVariant.BEARS_ENDURANCE, SpellVariant.BULLS_STRENGTH, SpellVariant.CATS_GRACE, SpellVariant.EAGLES_SPLENDOR, SpellVariant.FOX_CUNNING, SpellVariant.OWLS_WISDOM };
            Effect[] effects = new Effect[] { Effect.ADVANTAGE_CONSTITUTION_SAVES, Effect.ADVANTAGE_STRENGTH_SAVES, Effect.ADVANTAGE_DEXTERITY_SAVES, Effect.ADVANTAGE_CHARISMA_SAVES, Effect.ADVANTAGE_INTELLIGENCE_SAVES, Effect.ADVANTAGE_WISDOM_SAVES };
            AbilityType[] abilities = new AbilityType[] { AbilityType.CONSTITUTION, AbilityType.STRENGTH, AbilityType.DEXTERITY, AbilityType.CHARISMA, AbilityType.INTELLIGENCE, AbilityType.WISDOM };
            int successesWithoutAdvantage = 0;
            int successesWithAdvantage = 0;
            Random.State = 2;
            for (int i = 0; i < variants.Length; i++) {
                Monster bandit1 = Monsters.Bandit;
                Monster bandit2 = Monsters.Bandit;
                Monster bandit3 = Monsters.Bandit;
                Monster acolyte = Monsters.Acolyte;
                Battleground ground = createBattleground(acolyte, bandit1, bandit2, bandit3);
                SpellVariant variant = variants[i];
                AbilityType ability = abilities[i];
                Effect effect = effects[i];
                Spell spell = Spells.EnhanceAbility;
                spell.Variant = variant;
                spell.Cast(ground, acolyte, 12, SpellLevel.THIRD, 2, bandit1, bandit2, bandit3);
                Assert.True(bandit1.HasEffect(effect));
                Assert.True(bandit2.HasEffect(effect));
                Assert.False(bandit3.HasEffect(effect));
                if (i == 0) {
                    spell.Variant = SpellVariant.BULLS_STRENGTH;
                    spell.Cast(ground, acolyte, 12, SpellLevel.THIRD, 2, bandit1);
                    Assert.False(bandit1.HasEffect(Effect.ADVANTAGE_STRENGTH_SAVES));
                }
                if (bandit1.DC(this, 10, ability)) successesWithAdvantage++;
                if (bandit3.DC(this, 10, ability)) successesWithoutAdvantage++;
            }
            Assert.True(successesWithAdvantage > successesWithoutAdvantage);
        }

        [Fact]
        public void EnlargeTest() {
            Spell spell = Spells.EnlargeReduce;
            spell.Variant = SpellVariant.ENLARGE;
            Monster bandit = Monsters.Bandit;
            Size size = bandit.Size;
            bandit.AddEffect(Effect.SPELL_REDUCE);
            Assert.True(bandit.Size < size);
            spell.Cast(bandit, 12, SpellLevel.SECOND, 3);
            Assert.True(bandit.Size == size);
            spell.Cast(bandit, 12, SpellLevel.SECOND, 3);
            Assert.True(bandit.Size > size);
            size = bandit.Size;
            spell.Cast(bandit, 12, SpellLevel.SECOND, 3);
            Assert.True(bandit.Size == size);
            bandit.Attack(Attacks.BanditScimitar, Monsters.Baboon, 5);
        }

        [Fact]
        public void ReduceTest() {
            Spell spell = Spells.EnlargeReduce;
            spell.Variant = SpellVariant.REDUCE;
            Monster bandit = Monsters.Bandit;
            Size size = bandit.Size;
            Random.State = 1;
            spell.Cast(bandit, 1, SpellLevel.SECOND, 3);
            Assert.True(bandit.Size == size);
            bandit.AddEffect(Effect.SPELL_ENLARGE);
            Assert.True(bandit.Size > size);
            spell.Cast(bandit, 30, SpellLevel.SECOND, 3);
            Assert.True(bandit.Size == size);
            spell.Cast(bandit, 30, SpellLevel.SECOND, 3);
            Assert.True(bandit.Size < size);
            size = bandit.Size;
            spell.Cast(bandit, 30, SpellLevel.SECOND, 3);
            Assert.True(bandit.Size == size);
            bandit.Attack(Attacks.BanditScimitar, Monsters.Baboon, 5);
            bandit.DC(this, 20, AbilityType.STRENGTH);
        }

        [Fact]
        public void FlameBladeTest() {
            Monster druid = Monsters.Druid;
            Monster bandit = Monsters.Bandit;
            bandit.ArmorClass = 0;
            bandit.HitPoints = 6;
            Battleground ground = createBattleground(druid, bandit);
            Spells.FlameBlade.Cast(druid, 10, SpellLevel.NINETH, 0);
            Assert.True(druid.AvailableSpells[0].PreparedSpells[0].ID == Spells.ID.FLAME_BLADE);
            druid.AvailableSpells[0].PreparedSpells[0].Cast(ground, druid, 15, SpellLevel.CANTRIP, 1, bandit);
            Assert.True(bandit.Dead);
            for (int i = 0; i < (int)SpellDuration.TEN_MINUTES; i++) {
                druid.OnEndOfTurn();
            }
            Assert.True(druid.AvailableSpells[0].PreparedSpells.Length == 0);
        }

        [Fact]
        public void FlamingSphereTest() {
            Monster druid = Monsters.Druid;
            Monster bandit = Monsters.Bandit;
            bandit.HitPoints = 6;
            Battleground ground = createBattleground(druid, bandit);
            Spells.FlamingSphere.Cast(druid, 10, SpellLevel.SIXTH, 0);
            Assert.True(druid.AvailableSpells[0].PreparedSpells[0].ID == Spells.ID.FLAMING_SPHERE);
            druid.AvailableSpells[0].PreparedSpells[0].Cast(ground, druid, 15, SpellLevel.CANTRIP, 1, bandit);
            Assert.True(bandit.Dead);
            for (int i = 0; i < (int)SpellDuration.ONE_MINUTE; i++) {
                druid.OnEndOfTurn();
            }
            Assert.True(druid.AvailableSpells[0].PreparedSpells.Length == 0);
        }

        [Fact]
        public void GustofWindTest() {
            Monster druid = Monsters.Druid;
            Monster bandit = Monsters.Bandit;
            bandit.HitPoints = 6;
            Battleground ground = createBattleground(druid, bandit);
            Location location = ground.LocateCombattant(bandit);
            int speed = bandit.Speed;
            Spells.GustofWind.Cast(ground, druid, 30, SpellLevel.SECOND, 20, bandit);
            Assert.True(bandit.HasEffect(Effect.SPELL_GUST_OF_WIND));
            Assert.True(bandit.Speed < speed);
            for (int i = 0; i < (int)SpellDuration.ONE_MINUTE; i++) {
                bandit.OnStartOfTurn();
                bandit.OnEndOfTurn();
            }
            Assert.True(location.Distance(ground.LocateCombattant(bandit)) > 0);
            Assert.True(bandit.Speed == speed);
        }

        [Fact]
        public void LesserRestorationTest() {
            Monster druid = Monsters.Druid;
            druid.AddCondition(ConditionType.BLINDED, ConditionType.DEAFENED, ConditionType.POISONED, ConditionType.PARALYZED);
            druid.AddEffect(Effect.ADVANTAGE_DEXTERITY_SAVES, Effect.DEATH_DOG_DISEASE, Effect.ABOLETH_DISEASE_TENTACLE);
            Spell lesserRestoration = Spells.LesserRestoration;
            lesserRestoration.Variant = SpellVariant.DISEASE;
            lesserRestoration.Cast(druid, 10, SpellLevel.FIFTH, 5);
            Assert.False(druid.HasEffect(Effect.DEATH_DOG_DISEASE));
            Assert.True(druid.HasEffect(Effect.ADVANTAGE_DEXTERITY_SAVES));
            Assert.True(druid.HasEffect(Effect.ABOLETH_DISEASE_TENTACLE));

            lesserRestoration.Variant = SpellVariant.PARALYZATION;
            lesserRestoration.Cast(druid, 10, SpellLevel.FIFTH, 5);
            Assert.False(druid.HasCondition(ConditionType.PARALYZED));
            Assert.True(druid.HasCondition(ConditionType.POISONED));

            lesserRestoration.Variant = SpellVariant.POISON;
            lesserRestoration.Cast(druid, 10, SpellLevel.FIFTH, 5);
            Assert.False(druid.HasCondition(ConditionType.POISONED));
            Assert.True(druid.HasCondition(ConditionType.DEAFENED));

            lesserRestoration.Variant = SpellVariant.DEAFNESS;
            lesserRestoration.Cast(druid, 10, SpellLevel.FIFTH, 5);
            Assert.False(druid.HasCondition(ConditionType.DEAFENED));
            Assert.True(druid.HasCondition(ConditionType.BLINDED));

            lesserRestoration.Variant = SpellVariant.BLINDNESS;
            lesserRestoration.Cast(druid, 10, SpellLevel.FIFTH, 5);
            Assert.False(druid.HasCondition(ConditionType.BLINDED));
        }


        [Fact]
        public void MoonbeamTest() {
            Monster druid = Monsters.Druid;
            Monster bandit = Monsters.Bandit;
            Monster werewolf = Monsters.Werewolf;
            bandit.HitPoints = 6;
            Battleground ground = createBattleground(druid, bandit);
            Spells.Moonbeam.Cast(ground, druid, 10, SpellLevel.SIXTH, 0, bandit);
            Spells.Moonbeam.Cast(ground, druid, 10, SpellLevel.SIXTH, 0, werewolf);
            Assert.True(bandit.Dead);
            bandit = Monsters.Bandit;
            bandit.HitPoints = 6;
            Assert.True(druid.AvailableSpells[0].PreparedSpells[0].ID == Spells.ID.MOONBEAM);
            druid.AvailableSpells[0].PreparedSpells[0].Cast(ground, druid, 15, SpellLevel.CANTRIP, 1, bandit);
            druid.AvailableSpells[0].PreparedSpells[0].Cast(ground, druid, 15, SpellLevel.CANTRIP, 1, werewolf);
            Assert.True(bandit.Dead);
            for (int i = 0; i < (int)SpellDuration.ONE_MINUTE; i++) {
                druid.OnEndOfTurn();
            }
            Assert.True(druid.AvailableSpells[0].PreparedSpells.Length == 0);
        }

    }
}
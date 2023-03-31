using Xunit;

namespace srd5 {
    public class AttackEffectTest {
        private Monster uberMonster = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.ORC, Alignment.LAWFUL_EVIL, 30, 30, 30, 30, 30, 30, 30, "1d6+10000", 40, 16,
                    new Attack[] { }, new Attack[] { }, Size.HUGE
                );

        private Monster averageMonster = new Monster(
                    Monsters.Type.HUMANOID, Monsters.ID.OWLBEAR, Alignment.CHAOTIC_GOOD, 10, 11, 12, 13, 14, 15, 10, "1d6+10000", 40, 16,
                    new Attack[] { }, new Attack[] { }, Size.MEDIUM
                );

        private Monster pansyMonster = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.GOAT, Alignment.LAWFUL_EVIL, 2, 1, 1, 1, 1, 1, 1, "1d6+10000", 40, 16,
                    new Attack[] { }, new Attack[] { }, Size.MEDIUM
                );

        private void restoreMonsters() {
            uberMonster = new Monster(
                                Monsters.Type.DRAGON, Monsters.ID.ORC, Alignment.LAWFUL_EVIL, 30, 30, 30, 30, 30, 30, 30, "1d6+10000", 40, 16,
                                new Attack[] { }, new Attack[] { }, Size.HUGE
                            );
            averageMonster = new Monster(
                                Monsters.Type.HUMANOID, Monsters.ID.OWLBEAR, Alignment.CHAOTIC_GOOD, 10, 11, 12, 13, 14, 15, 10, "1d6+10000", 40, 16,
                                new Attack[] { }, new Attack[] { }, Size.MEDIUM
                            );
            pansyMonster = new Monster(
                                Monsters.Type.BEAST, Monsters.ID.GOAT, Alignment.LAWFUL_EVIL, 2, 1, 1, 1, 1, 1, 1, "1d6+10000", 40, 16,
                                new Attack[] { }, new Attack[] { }, Size.MEDIUM
                            );
        }


        private void attackEffectTest(AttackEffect effect) {
            for (int i = 0; i < 10; i++) {
                restoreMonsters();
                effect.Invoke(Monsters.Aboleth, uberMonster);
                effect.Invoke(Monsters.Aboleth, averageMonster);
                effect.Invoke(Monsters.Aboleth, pansyMonster);

                for (int j = 0; j < 20; j++) {
                    uberMonster.EscapeFromGrapple();
                    uberMonster.OnStartOfTurn();
                    uberMonster.OnEndOfTurn();
                    averageMonster.EscapeFromGrapple();
                    averageMonster.OnStartOfTurn();
                    averageMonster.OnEndOfTurn();
                    pansyMonster.EscapeFromGrapple();
                    pansyMonster.OnStartOfTurn();
                    pansyMonster.OnEndOfTurn();
                }
            }
        }

        [Fact]
        public void TestAttackEffects_A() {
            attackEffectTest(Attacks.AbolethTentacleEffect);
            attackEffectTest(Attacks.AnkhegBiteEffect);
            attackEffectTest(Attacks.AssassinShortswordEffect);
        }

        [Fact]
        public void TestAttackEffects_B() {
            attackEffectTest(Attacks.BalorWhipEffect);
            attackEffectTest(Attacks.BeardedDevilBeardEffect);
            attackEffectTest(Attacks.BeardedDevilGlaiveEffect);
            attackEffectTest(Attacks.BehirConstrictEffect);
            attackEffectTest(Attacks.BlackPuddingPseudopodEffect);
            attackEffectTest(Attacks.BoneDevilStingEffect);
        }

        [Fact]
        public void TestAttackEffects_C() {
            attackEffectTest(Attacks.ChainDevilChainEffect);
            attackEffectTest(Attacks.ChuulPincerEffect);
            attackEffectTest(Attacks.ClayGolemSlamEffect);
            attackEffectTest(Attacks.CloakerBiteEffect);
            attackEffectTest(Attacks.CockatriceBiteEffect);
            attackEffectTest(Attacks.ConstrictorSnakeConstrictEffect);
            attackEffectTest(Attacks.CouatlBiteEffect);
            attackEffectTest(Attacks.CouatlConstrictEffect);
            attackEffectTest(Attacks.CrocodileBiteEffect);
            attackEffectTest(Attacks.GiantScorpionStingEffect);
        }

        [Fact]
        public void BalorLongswordTest() {
            Assert.True(Attacks.BalorLongsword.Properties.Length == 1);
            Assert.True(Attacks.BalorLongsword.HasProperty(Attack.Property.TRIPLE_DICE_ON_CRIT));
            for (int i = 0; i < 100; i++) {
                Monsters.Balor.Attack(Attacks.BalorLongsword, uberMonster, 5);
            }
        }

        [Fact]
        public void BeardedDevilGlaiveEffect() {
            Monster golem = Monsters.ClayGolem;
            Monster shadow = Monsters.Shadow;
            Attacks.BeardedDevilGlaiveEffect.Invoke(Monsters.Aboleth, golem); // don't affect construct
            Assert.False(golem.HasEffect(Effect.INFERNAL_WOUND));
            Attacks.BeardedDevilGlaiveEffect.Invoke(Monsters.Aboleth, shadow); // don't affect undead
            Assert.False(shadow.HasEffect(Effect.INFERNAL_WOUND));
        }

        [Fact]
        public void BlackPuddingPseudopodEffect() {
            CharacterSheet hero = new CharacterSheet(Race.HUMAN);
            hero.AddLevel(CharacterClasses.Barbarian);
            Attacks.BlackPuddingPseudopodEffect.Invoke(Monsters.Aboleth, hero);
            hero.Equip(Armors.LeatherArmor);
            Armor leatherArmor = hero.Inventory.Armor;
            Attacks.BlackPuddingPseudopodEffect.Invoke(Monsters.Aboleth, hero);
            Assert.Null(hero.Inventory.Armor);
            Assert.True(leatherArmor.Destroyed);
            hero.Equip(Armors.Breastplate);
            for (int i = 0; i < 3; i++) {
                Attacks.BlackPuddingPseudopodEffect.Invoke(Monsters.Aboleth, hero);
            }
            Assert.False(hero.Inventory.Armor.Destroyed);
            Attacks.BlackPuddingPseudopodEffect.Invoke(Monsters.Aboleth, hero);
            Assert.Null(hero.Inventory.Armor);
            Armor magicArmor = Armors.CreatePlus1Armor(Armors.LeatherArmor);
            hero.Equip(magicArmor);
            int ac = magicArmor.AC;
            for (int i = 0; i < 3; i++) {
                Attacks.BlackPuddingPseudopodEffect.Invoke(Monsters.Aboleth, hero);
            }
            Assert.Equal(ac, hero.Inventory.Armor.AC);
        }

        [Fact]
        public void CloakerBiteTest() {
            Monster cloaker = Monsters.Cloaker;
            Monster bat = Monsters.Bat;
            for (int i = 0; i < 5; i++) {
                cloaker.Attack(cloaker.MeleeAttacks[0], bat, 5);
            }
            Assert.True(cloaker.MeleeAttacks[0].LockedTarget == bat);
        }


        [Fact]
        public void ClayGolemSlamTest() {
            Combattant golem = Monsters.ClayGolem;
            Monster bandit = Monsters.Bandit;
            for (int i = 0; i < 10; i++) {
                golem.Attack(golem.MeleeAttacks[0], bandit, 5);
            }
            Assert.True(bandit.HitPointsMax <= 0);
        }

        [Fact]
        public void CrocodileBiteTest() {
            Monster crocodile = new Monster(
                Monsters.Type.BEAST, Monsters.ID.CROCODILE, Alignment.UNALIGNED, 15, 10, 13, 2, 10, 5, 12, "3d10+3", 40, ChallengeRating.HALF,
                new Attack[] { Attacks.CrocodileBite, Attacks.AbolethTail }, new Attack[] { }, Size.LARGE
            );
            Monster bandit = Monsters.Bandit;
            for (int i = 0; i < 10; i++) {
                crocodile.Attack(crocodile.MeleeAttacks[0], bandit, 5);
            }
            Assert.True(bandit.HasCondition(ConditionType.RESTRAINED));
            Assert.Equal(bandit, crocodile.MeleeAttacks[0].LockedTarget);
        }

        [Fact]
        public void ChuulPincerTest() {
            Monster chuul = Monsters.Chuul;
            Monster n00b1 = Monsters.Commoner;
            Monster n00b2 = Monsters.Commoner;
            Monster n00b3 = Monsters.Commoner;
            for (int i = 0; i < 10; i++) {
                chuul.Attack(chuul.MeleeAttacks[0], n00b1, 5);
            }
            for (int i = 0; i < 10; i++) {
                chuul.Attack(chuul.MeleeAttacks[0], n00b2, 5);
            }
            for (int i = 0; i < 10; i++) {
                chuul.Attack(chuul.MeleeAttacks[0], n00b3, 5);
            }
            Assert.True(n00b1.HasCondition(ConditionType.GRAPPLED_DC14));
            Assert.True(n00b2.HasCondition(ConditionType.GRAPPLED_DC14));
            Assert.False(n00b3.HasCondition(ConditionType.GRAPPLED_DC14));
        }
    }
}
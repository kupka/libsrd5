using Xunit;

namespace srd5 {
    public class AttackEffectTest {
        private Monster uberMonster = new Monster(
                    Monsters.Type.DRAGON, Monsters.ID.ORC, Alignment.LAWFUL_EVIL, 30, 30, 30, 30, 30, 30, 30, "1d6+10000", 40, 16,
                    new Attack[] { }, new Attack[] { }, Size.HUGE
                );

        private Monster pansyMonster = new Monster(
                    Monsters.Type.BEAST, Monsters.ID.GOAT, Alignment.LAWFUL_EVIL, 2, 1, 1, 1, 1, 1, 1, "1d6+10000", 40, 16,
                    new Attack[] { }, new Attack[] { }, Size.HUGE
                );


        private void attackEffectTest(AttackEffect effect) {
            for (int i = 0; i < 10; i++) {
                effect.Invoke(Monsters.Aboleth, uberMonster);
                effect.Invoke(Monsters.Aboleth, pansyMonster);
            }
        }

        [Fact]
        public void TestAttackEffects_A() {
            attackEffectTest(Attacks.AbolethTentacleEffect);
            attackEffectTest(Attacks.AnkhegBiteEffect);
            attackEffectTest(Attacks.AssassinShortswordEffect);
            attackEffectTest(Attacks.BalorWhipEffect);
            attackEffectTest(Attacks.BeardedDevilBeardEffect);
            attackEffectTest(Attacks.BeardedDevilGlaiveEffect);
            attackEffectTest(Attacks.BehirConstrictEffect);
            attackEffectTest(Attacks.BlackPuddingPseudopodEffect);
            attackEffectTest(Attacks.BoneDevilStingEffect);
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

            for (int i = 0; i < 10; i++) {
                uberMonster.OnStartOfTurn();
                uberMonster.OnEndOfTurn();
                pansyMonster.OnStartOfTurn();
                pansyMonster.OnEndOfTurn();
            }
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
    }
}
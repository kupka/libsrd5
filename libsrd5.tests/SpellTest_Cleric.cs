using Xunit;

namespace srd5 {
    public partial class SpellTest {
        [Fact]
        public void SpareTheDyingTest() {
            CharacterSheet hero = new CharacterSheet(Race.HUMAN);
            hero.AddLevel(CharacterClasses.Barbarian);
            hero.TakeDamage(new DamageSource(DamageSourceType.OTHER, this, hero), DamageType.TRUE_DAMAGE, hero.HitPointsMax);
            Assert.True(hero.HasEffect(Effect.FIGHTING_DEATH));
            Spells.SpareTheDying.Cast(hero, 16, SpellLevel.CANTRIP, 0);
            hero.OnStartOfTurn();
            Assert.False(hero.HasEffect(Effect.FIGHTING_DEATH));
        }

        [Fact]
        public void GuidanceTest() {
            CharacterSheet hero = new CharacterSheet(Race.HUMAN);
            hero.AddLevel(CharacterClasses.Barbarian);
            Spells.Guidance.Cast(hero, 10, SpellLevel.FIRST, 0);
            Assert.True(hero.HasEffect(Effect.SPELL_GUIDANCE));
            hero.DC(Attacks.AbolethTail, 12, AbilityType.STRENGTH);
            Assert.False(hero.HasEffect(Effect.SPELL_GUIDANCE));
        }

        [Fact]
        public void BaneTest() {
            DefaultSpellTest(Spells.Bane, 12, SpellLevel.FIFTH, null, Effect.SPELL_BANE, Spells.Bane.Duration);
        }

        [Fact]
        public void BlessTest() {
            DefaultSpellTest(Spells.Bless, 12, SpellLevel.FIFTH, null, Effect.SPELL_BLESS, Spells.Bless.Duration);
        }

        [Fact]
        public void CommandTest() {
            DefaultSpellTest(Spells.Command, 12, SpellLevel.THIRD, ConditionType.PRONE, Effect.SPELL_COMMAND_GROVEL, null);
            DefaultSpellTest(Spells.Command, 12, SpellLevel.THIRD, null, Effect.SPELL_COMMAND_GROVEL, 1);
        }

        [Fact]
        public void DivineFavorTest() {
            DefaultSpellTest(Spells.DivineFavor, 12, SpellLevel.SECOND, null, Effect.SPELL_DIVINE_FAVOR, Spells.DivineFavor.Duration);
        }

        [Fact]
        public void GuidingBoltTest() {
            DamagingSpellTesting(Spells.GuidingBolt, 12, DamageType.RADIANT);
            DefaultSpellTest(Spells.GuidingBolt, 12, SpellLevel.NINTH, null, Effect.ADVANTAGE_ON_BEING_ATTACKED, 1);
        }

        [Fact]
        public void InflictWoundsTest() {
            DamagingSpellTesting(Spells.InflictWounds, 15, DamageType.NECROTIC);
        }

        [Fact]
        public void ProtectionfromEvilandGoodTest() {
            DefaultSpellTest(Spells.ProtectionfromEvilandGood, 12, SpellLevel.SECOND, null, Effect.SPELL_PROTECTION_FROM_EVIL_AND_GOOD, 100);

            CharacterSheet hero = new CharacterSheet(Race.HALF_ELF);
            hero.AddLevel(CharacterClasses.Druid);
            Spells.ProtectionfromEvilandGood.Cast(hero, 12, SpellLevel.THIRD, 5);
            Combatant[] allCombatantTypes = [
                Monsters.Badger, Monsters.Solar, Monsters.IronGolem, Monsters.AncientBlackDragon, Monsters.FireElemental,
                Monsters.Dryad, Monsters.BarbedDevil, Monsters.HillGiant, Monsters.Bandit, Monsters.BlackPudding,
                Monsters.Treant, Monsters.SwarmOfQuippers, Monsters.Zombie, hero
             ];
            foreach (Combatant combatant in allCombatantTypes) {
                combatant.Attack(Attacks.AcolyteClub, hero, 5);
            }
        }

        [Fact]
        public void ShieldofFaithTest() {
            Monster acolyte = Monsters.Acolyte;
            int ac = acolyte.ArmorClass;
            Spells.ShieldofFaith.Cast(acolyte, 10, SpellLevel.FIRST, 0);
            Assert.Equal(ac + 2, acolyte.ArmorClass);
            Spells.ShieldofFaith.Cast(acolyte, 10, SpellLevel.FIRST, 0);
            Assert.Equal(ac + 2, acolyte.ArmorClass);
            DefaultSpellTest(Spells.ShieldofFaith, 10, SpellLevel.SECOND, null, Effect.SPELL_SHIELD_OF_FAITH, Spells.ShieldofFaith.Duration);
        }

        [Fact]
        public void AidTest() {
            Monster ogre = Monsters.Ogre;
            int hpExpected = ogre.HitPointsMax + 10;
            Spells.Aid.Cast(ogre, 12, SpellLevel.THIRD, 0);
            Assert.Equal(hpExpected, ogre.HitPointsMax);
            Assert.Equal(hpExpected, ogre.HitPoints);
            // Aditional cast does nothing
            Spells.Aid.Cast(ogre, 12, SpellLevel.THIRD, 0);
            Assert.Equal(hpExpected, ogre.HitPointsMax);
            Assert.Equal(hpExpected, ogre.HitPoints);
        }

        [Fact]
        public void PrayerofHealingTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            cleric.AddLevel(CharacterClasses.Druid);
            cleric.HitPoints = 1;
            Monster ogre = Monsters.Ogre;
            Monster shadow = Monsters.Shadow;
            Monster golem = Monsters.ClayGolem;
            ogre.HitPoints = 1;
            shadow.HitPoints = 1;
            golem.HitPoints = 1;
            Battleground ground = createBattleground(cleric, ogre, shadow, golem);
            Spells.PrayerofHealing.Cast(ground, cleric, 12, SpellLevel.NINTH, 50, cleric, ogre, shadow, golem);
            Assert.Equal(cleric.HitPointsMax, cleric.HitPoints);
            Assert.Equal(ogre.HitPointsMax, ogre.HitPoints);
            Assert.Equal(1, shadow.HitPoints);
            Assert.Equal(1, golem.HitPoints);
        }

        [Fact]
        public void SilenceTest() {
            DefaultSpellTest(Spells.Silence, 20, SpellLevel.FIFTH, ConditionType.DEAFENED, Effect.IMMUNITY_THUNDER, Spells.Silence.Duration);
        }

        [Fact]
        public void SpiritualWeaponTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            cleric.AddLevel(CharacterClasses.Druid);
            Monster orc = Monsters.Orc;
            Monster bandit = Monsters.Bandit;
            Battleground ground = createBattleground(cleric, orc, bandit);
            Spells.SpiritualWeapon.Cast(ground, cleric, 15, SpellLevel.FIFTH, 15, orc);
            Assert.True(orc.HitPoints < orc.HitPointsMax);
            cleric.AvailableSpells[0].KnownSpells[0].Cast(ground, cleric, 15, SpellLevel.CANTRIP, 15, bandit);
            Assert.True(bandit.HitPoints < bandit.HitPointsMax);
            for (int i = 0; i < (int)Spells.SpiritualWeapon.Duration; i++) {
                cleric.OnEndOfTurn();
            }
            Assert.Empty(cleric.AvailableSpells[0].KnownSpells);
        }

        [Fact]
        public void WardingBondTest_CasterZeroHitpoints() {
            Monster cleric = Monsters.Acolyte;
            Monster bandit = Monsters.Bandit;
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombatant(cleric, 0, 0);
            ground.AddCombatant(bandit, 5, 2);
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, bandit);
            Assert.True(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.True(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
            bandit.TakeDamage(new DamageSource(DamageSourceType.OTHER, this, cleric), DamageType.BLUDGEONING, 10);
            Assert.True(cleric.HitPoints == cleric.HitPointsMax - 5);
            Assert.True(bandit.HitPoints == bandit.HitPointsMax - 5);
            cleric.TakeDamage(new DamageSource(DamageSourceType.OTHER, this, bandit), DamageType.POISON, 100);
            Assert.False(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.False(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
        }

        [Fact]
        public void WardingBondTest_DoubleCast1() {
            Monster cleric = Monsters.Acolyte;
            Monster bandit = Monsters.Bandit;
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombatant(cleric, 0, 0);
            ground.AddCombatant(bandit, 5, 2);
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, bandit);
            Assert.True(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.True(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, bandit);
            Assert.False(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.False(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
        }

        [Fact]
        public void WardingBondTest_DoubleCast2() {
            Monster cleric = Monsters.Acolyte;
            Monster bandit = Monsters.Bandit;
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombatant(cleric, 0, 0);
            ground.AddCombatant(bandit, 5, 2);
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, cleric);
            Assert.False(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.False(cleric.HasEffect(Effect.SPELL_WARDING_BOND));
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, bandit);
            Assert.True(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.True(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
            Spells.WardingBond.Cast(ground, bandit, 12, SpellLevel.SECOND, 5, cleric);
            Assert.False(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.False(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
        }

        [Fact]
        public void WardingBondTest_RemovedCasterEffect1() {
            Monster cleric = Monsters.Acolyte;
            Monster bandit = Monsters.Bandit;
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombatant(cleric, 0, 0);
            ground.AddCombatant(bandit, 5, 2);
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, bandit);
            Assert.True(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.True(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
            cleric.RemoveEffect(Effect.SPELL_WARDING_BOND_CASTER);
            bandit.TakeDamage(new DamageSource(DamageSourceType.OTHER, this, cleric), DamageType.TRUE_DAMAGE, 2);
            Assert.False(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
        }

        [Fact]
        public void WardingBondTest_RemovedCasterEffect2() {
            Monster cleric = Monsters.Acolyte;
            Monster bandit = Monsters.Bandit;
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombatant(cleric, 0, 0);
            ground.AddCombatant(bandit, 5, 2);
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, bandit);
            Assert.True(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.True(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
            cleric.RemoveEffect(Effect.SPELL_WARDING_BOND_CASTER);
            cleric.TakeDamage(new DamageSource(DamageSourceType.OTHER, this, bandit), DamageType.TRUE_DAMAGE, 2);
            Assert.False(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
        }

        [Fact]
        public void WardingBondTest_RemovedCasterEffect3() {
            Monster cleric = Monsters.Acolyte;
            Monster bandit = Monsters.Bandit;
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombatant(cleric, 0, 0);
            ground.AddCombatant(bandit, 5, 2);
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, bandit);
            Assert.True(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.True(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
            cleric.RemoveEffect(Effect.SPELL_WARDING_BOND_CASTER);
            cleric.OnStartOfTurn();
            Assert.False(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
        }

        [Fact]
        public void WardingBondTest_RemovedTargetEffect1() {
            Monster cleric = Monsters.Acolyte;
            Monster bandit = Monsters.Bandit;
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombatant(cleric, 0, 0);
            ground.AddCombatant(bandit, 5, 2);
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, bandit);
            Assert.True(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.True(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
            bandit.RemoveEffect(Effect.SPELL_WARDING_BOND);
            bandit.TakeDamage(new DamageSource(DamageSourceType.OTHER, this, cleric), DamageType.TRUE_DAMAGE, 2);
            Assert.False(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
        }

        [Fact]
        public void WardingBondTest_RemovedTargetEffect2() {
            Monster cleric = Monsters.Acolyte;
            Monster bandit = Monsters.Bandit;
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombatant(cleric, 0, 0);
            ground.AddCombatant(bandit, 5, 2);
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, bandit);
            Assert.True(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.True(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
            bandit.RemoveEffect(Effect.SPELL_WARDING_BOND);
            cleric.TakeDamage(new DamageSource(DamageSourceType.OTHER, this, bandit), DamageType.TRUE_DAMAGE, 2);
            Assert.False(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
        }

        [Fact]
        public void WardingBondTest_RemovedTargetEffect3() {
            Monster cleric = Monsters.Acolyte;
            Monster bandit = Monsters.Bandit;
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombatant(cleric, 0, 0);
            ground.AddCombatant(bandit, 5, 2);
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, bandit);
            Assert.True(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.True(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
            bandit.RemoveEffect(Effect.SPELL_WARDING_BOND);
            bandit.OnStartOfTurn();
            Assert.False(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
        }

        [Fact]
        public void WardingBondTest_MoveTooFarTest() {
            Monster cleric = Monsters.Acolyte;
            Monster bandit = Monsters.Bandit;
            Battleground2D ground = new Battleground2D(20, 20);
            ground.AddCombatant(cleric, 0, 0);
            ground.AddCombatant(bandit, 5, 5);
            Spells.WardingBond.Cast(ground, cleric, 12, SpellLevel.SECOND, 5, bandit);
            Assert.True(cleric.HasEffect(Effect.SPELL_WARDING_BOND_CASTER));
            Assert.True(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
            cleric.OnStartOfTurn();
            Assert.True(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
            ground.Push(new Coord(0, 0), bandit, 50);
            cleric.OnStartOfTurn();
            Assert.False(bandit.HasEffect(Effect.SPELL_WARDING_BOND));
        }

        [Fact]
        public void AnimateDeadTest() {
            Monster bandit1 = Monsters.Bandit;
            bandit1.Die();
            Monster bandit2 = Monsters.Bandit;
            Monster rat = Monsters.GiantRat;
            Monster hillGiant = Monsters.HillGiant;
            CharacterSheet wizard = new CharacterSheet(Race.HALF_ELF);
            wizard.Die();
            CharacterSheet cleric = new CharacterSheet(Race.HILL_DWARF);

            Battleground ground = createBattleground(cleric, bandit1, bandit2, hillGiant, rat, wizard);
            Spells.AnimateDead.Cast(ground, cleric, 12, SpellLevel.NINTH, 0, bandit1, bandit2, rat, wizard);
            Assert.True(bandit1.HasEffect(Effect.SPELL_ANIMATE_DEAD));
            Assert.False(bandit2.HasEffect(Effect.SPELL_ANIMATE_DEAD));
            Assert.False(rat.HasEffect(Effect.SPELL_ANIMATE_DEAD));
            Assert.False(hillGiant.HasEffect(Effect.SPELL_ANIMATE_DEAD));
            Assert.True(wizard.HasEffect(Effect.SPELL_ANIMATE_DEAD));
        }

        [Fact]
        public void MassHealingWordTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            cleric.HitPoints = 1;
            Monster ogre = Monsters.Ogre;
            Monster shadow = Monsters.Shadow;
            Monster golem = Monsters.ClayGolem;
            ogre.HitPoints = 1;
            shadow.HitPoints = 1;
            golem.HitPoints = 1;
            Battleground ground = createBattleground(cleric, ogre, shadow, golem);
            Spells.MassHealingWord.Cast(ground, cleric, 12, SpellLevel.NINTH, 50, cleric, ogre, shadow, golem);
            Assert.Equal(cleric.HitPointsMax, cleric.HitPoints);
            Assert.Equal(ogre.HitPointsMax, ogre.HitPoints);
            Assert.Equal(1, shadow.HitPoints); // undead not affected
            Assert.Equal(1, golem.HitPoints); // construct not affected
        }

        [Fact]
        public void RemoveCurseTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            Monster cursedMonster = Monsters.Mummy;
            cursedMonster.AddEffect(Effect.CURSE_MUMMY_ROT);
            Assert.True(cursedMonster.HasEffect(Effect.CURSE_MUMMY_ROT));
            Spells.RemoveCurse.Cast(cursedMonster, 12, SpellLevel.THIRD, 0);
            Assert.False(cursedMonster.HasEffect(Effect.CURSE_MUMMY_ROT));
        }

        [Fact]
        public void SpiritGuardiansTest_GoodCasterDealsRadiantDamage() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            cleric.Alignment = Alignment.LAWFUL_GOOD;
            Monster orc = Monsters.Orc;
            int originalSpeed = orc.Speed;
            Battleground ground = createBattleground(cleric, orc);
            Spells.SpiritGuardians.Cast(ground, cleric, 20, SpellLevel.THIRD, 0, orc);
            // Orc should have taken radiant damage (DC 20 = always fails)
            Assert.True(orc.HitPoints < orc.HitPointsMax);
            // Speed should be halved
            Assert.Equal(originalSpeed / 2, orc.Speed);
            // Cleric should be unharmed
            Assert.Equal(cleric.HitPointsMax, cleric.HitPoints);
        }

        [Fact]
        public void SpiritGuardiansTest_EvilCasterDealsNecroticDamage() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            cleric.Alignment = Alignment.CHAOTIC_EVIL;
            Monster orc = Monsters.Orc;
            int originalSpeed = orc.Speed;
            Battleground ground = createBattleground(cleric, orc);
            Spells.SpiritGuardians.Cast(ground, cleric, 20, SpellLevel.THIRD, 0, orc);
            Assert.True(orc.HitPoints < orc.HitPointsMax);
            Assert.Equal(originalSpeed / 2, orc.Speed);
        }

        [Fact]
        public void SpiritGuardiansTest_PerTurnDamage() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            cleric.Alignment = Alignment.NEUTRAL_GOOD;
            // Use a high-HP monster so it survives the initial cast and the per-turn tick
            Monster hillGiant = Monsters.HillGiant;
            Battleground ground = createBattleground(cleric, hillGiant);
            Spells.SpiritGuardians.Cast(ground, cleric, 20, SpellLevel.THIRD, 0, hillGiant);
            int hpAfterCast = hillGiant.HitPoints;
            // Each start-of-turn should apply damage again
            hillGiant.OnStartOfTurn();
            Assert.True(hillGiant.HitPoints < hpAfterCast);
        }

        [Fact]
        public void SpiritGuardiansTest_DurationExpiry() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            cleric.Alignment = Alignment.LAWFUL_GOOD;
            Monster orc = Monsters.Orc;
            int originalSpeed = orc.Speed;
            Battleground ground = createBattleground(cleric, orc);
            Spells.SpiritGuardians.Cast(ground, cleric, 20, SpellLevel.THIRD, 0, orc);
            Assert.Equal(originalSpeed / 2, orc.Speed);
            // Tick through the full TEN_MINUTES duration on the target's end-of-turn events
            for (int i = 0; i < (int)Spells.SpiritGuardians.Duration; i++) {
                orc.OnEndOfTurn();
            }
            Assert.False(orc.HasEffect(Effect.SPELL_SPIRIT_GUARDIANS));
            Assert.Equal(originalSpeed, orc.Speed);
        }

        [Fact]
        public void SpiritGuardiansTest_SuccessfulSaveHalvesDamage() {
            const uint seed = 1;
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            cleric.Alignment = Alignment.LAWFUL_GOOD;
            Monster giant = Monsters.HillGiant;
            Battleground ground = createBattleground(cleric, giant);

            // Predict the spell's 3d8 damage roll from this seed (the cast draws the damage
            // dice first, then the d20 save), so we can verify the half-damage result exactly.
            Random.State = seed;
            int rawDamage = new Dice("3d8").Roll();

            bool saveSucceeded = false;
            int damageDealt = -1;
            System.EventHandler<System.EventArgs> handler = delegate (object sender, System.EventArgs args) {
                if (GlobalEvents.EventTypes.DC.Equals(sender) && args is GlobalEvents.DCRolled dc && dc.Ability.Type == AbilityType.WISDOM) {
                    saveSucceeded = dc.Success;
                } else if (GlobalEvents.EventTypes.DAMAGED.Equals(sender) && args is GlobalEvents.DamageReceived dmg && dmg.Victim == giant) {
                    damageDealt = dmg.Amount;
                }
            };
            GlobalEvents.Handlers += handler;
            try {
                // Re-seed so the cast rolls the same 3d8 for damage; DC 1 makes the save
                // succeed unless a natural 1 is rolled.
                Random.State = seed;
                Spells.SpiritGuardians.Cast(ground, cleric, 1, SpellLevel.THIRD, 0, giant);
            } finally {
                GlobalEvents.Handlers -= handler;
            }

            // The successful-save branch must have been exercised and dealt half damage.
            Assert.True(saveSucceeded);
            Assert.Equal(rawDamage / 2, damageDealt);
        }

        [Fact]
        public void FlyTest() {
            DefaultSpellTest(Spells.Fly, 12, SpellLevel.THIRD, null, Effect.SPELL_FLY, Spells.Fly.Duration);
        }

        [Fact]
        public void GaseousFormTest() {
            DefaultSpellTest(Spells.GaseousForm, 12, SpellLevel.THIRD, null, Effect.SPELL_GASEOUS_FORM, Spells.GaseousForm.Duration);
        }

        [Fact]
        public void MeldIntoStoneTest() {
            DefaultSpellTest(Spells.MeldIntoStone, 12, SpellLevel.THIRD, null, Effect.SPELL_MELD_INTO_STONE, Spells.MeldIntoStone.Duration);
        }

        [Fact]
        public void NondetectionTest() {
            DefaultSpellTest(Spells.Nondetection, 12, SpellLevel.THIRD, null, Effect.SPELL_NONDETECTION, Spells.Nondetection.Duration);
        }

        [Fact]
        public void TonguesTest() {
            DefaultSpellTest(Spells.Tongues, 12, SpellLevel.THIRD, null, Effect.SPELL_TONGUES, Spells.Tongues.Duration);
        }

        [Fact]
        public void WaterBreathingTest() {
            DefaultSpellTest(Spells.WaterBreathing, 12, SpellLevel.THIRD, null, Effect.SPELL_WATER_BREATHING, Spells.WaterBreathing.Duration);
        }

        [Fact]
        public void WaterWalkTest() {
            DefaultSpellTest(Spells.WaterWalk, 12, SpellLevel.THIRD, null, Effect.SPELL_WATER_WALK, Spells.WaterWalk.Duration);
        }

        [Fact]
        public void AnimateDeadStartOfTurnTest() {
            // Covers the StartOfTurnEvent inside AnimateDead:
            //   - effect still present → return false (line 27)
            //   - effect removed externally → target.Die() + return true (lines 28-30)
            Monster bandit = Monsters.Bandit;
            bandit.Die();
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            Battleground ground = createBattleground(cleric, bandit);
            Spells.AnimateDead.Cast(ground, cleric, 12, SpellLevel.THIRD, 0, bandit);
            Assert.True(bandit.HasEffect(Effect.SPELL_ANIMATE_DEAD));
            // Fire the event while the effect is still present → should keep running (return false)
            bandit.OnStartOfTurn();
            // Effect is still present (event returned false and remains queued)
            Assert.True(bandit.HasEffect(Effect.SPELL_ANIMATE_DEAD));
            // Remove the effect to simulate Dispel Magic, then fire the event again → event terminates
            bandit.RemoveEffect(Effect.SPELL_ANIMATE_DEAD);
            bandit.OnStartOfTurn();
            // Die() was called inside the event; bandit was already dead, but the event completed cleanly
            Assert.True(bandit.Dead);
        }

        [Fact]
        public void AnimateDeadBattleground2DTest() {
            // Covers the Battleground2D zombie-spawn branch (lines 34-35)
            Monster bandit = Monsters.Bandit;
            bandit.Die();
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            Battleground2D ground = new Battleground2D(10, 10);
            ground.AddCombatant(cleric, 5, 5);
            ground.AddCombatant(bandit, 6, 5);
            Spells.AnimateDead.Cast(ground, cleric, 12, SpellLevel.THIRD, 0, bandit);
            Assert.True(bandit.HasEffect(Effect.SPELL_ANIMATE_DEAD));
        }

        [Fact]
        public void RevivifyTest() {
            CharacterSheet cleric = new CharacterSheet(Race.HUMAN);
            Monster orc = Monsters.Orc;
            Battleground ground = createBattleground(cleric, orc);
            // Target must be dead for Revivify to work
            orc.TakeDamage(new DamageSource(Spells.ID.POWER_WORD_KILL, cleric), DamageType.TRUE_DAMAGE, orc.HitPointsMax + 100);
            Assert.True(orc.Dead);
            Spells.Revivify.Cast(ground, cleric, 12, SpellLevel.THIRD, 0, orc);
            Assert.False(orc.Dead);
            Assert.Equal(1, orc.HitPoints);
        }
    }
}

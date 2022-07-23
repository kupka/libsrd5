using System;

namespace srd5 {
    public partial struct Spells {
        public static readonly Spell AcidSplash = new Spell(
                    ID.ACID_SPLASH, SpellSchool.CONJURATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 60, VS,
                    SpellDuration.INSTANTANEOUS, 5, 2, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifer, Combattant[] targets) {
                        Damage damage;
                        if (caster.EffectiveLevel > 16)
                            damage = new Damage(DamageType.ACID, "4d6");
                        else if (caster.EffectiveLevel > 10)
                            damage = new Damage(DamageType.ACID, "3d6");
                        else if (caster.EffectiveLevel > 4)
                            damage = new Damage(DamageType.ACID, "2d6");
                        else
                            damage = new Damage(DamageType.ACID, "1d6");
                        foreach (Combattant target in targets) {
                            int amount = damage.Dices.Roll();
                            if (!target.DC(dc, AbilityType.DEXTERITY)) {
                                GlobalEvents.AffectBySpell(caster, ID.ACID_SPLASH, target, true);
                                target.TakeDamage(damage.Type, amount);
                            } else {
                                GlobalEvents.AffectBySpell(caster, ID.ACID_SPLASH, target, false);
                            }
                        }
                    }
                );



        public static readonly Spell Guidance = new Spell(
            ID.GUIDANCE, SpellSchool.DIVINATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 0, VS,
            SpellDuration.CONCENTRATION_ONE_MINUTE, 0, 1, doNothing
        );

        public static readonly Spell Mending = new Spell(
            ID.MENDING, SpellSchool.TRANSMUTATION, SpellLevel.CANTRIP, CastingTime.ONE_MINUTE, 0, VSM,
            SpellDuration.INSTANTANEOUS, 0, 1, doNothing
        );

        public static readonly Spell ProduceFlame = new Spell(
            ID.PRODUCE_FLAME, SpellSchool.CONJURATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 30, VS,
            SpellDuration.INSTANTANEOUS, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                int bonus = modifier + caster.ProficiencyBonus;
                string diceString = "1d8";
                if (caster.EffectiveLevel >= 17)
                    diceString = "4d8";
                else if (caster.EffectiveLevel >= 11)
                    diceString = "3d8";
                else if (caster.EffectiveLevel >= 5)
                    diceString = "2d8";
                Damage damage = new Damage(DamageType.FIRE, diceString);
                Attack attack = new Attack(ID.PRODUCE_FLAME.Name(), bonus, damage, 0, 30, 30);
                int distance = ground.LocateCombattant(caster).Distance(ground.LocateCombattant(targets[0]));
                caster.Attack(attack, targets[0], distance, true);
            }
        );

        public static readonly Spell Resistance = new Spell(
            ID.RESISTANCE, SpellSchool.ABJURATION, SpellLevel.CANTRIP, CastingTime.ONE_ACTION, 0, VSM,
            SpellDuration.CONCENTRATION_ONE_MINUTE, 0, 1, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                GlobalEvents.AffectBySpell(caster, ID.RESISTANCE, targets[0], true);
                targets[0].AddEffect(Effect.RESISTANCE);
            }
        );

        public static readonly Spell Shillelagh = new Spell(
            ID.SHILLELAGH, SpellSchool.TRANSMUTATION, SpellLevel.CANTRIP, CastingTime.BONUS_ACTION, 0, VSM,
            SpellDuration.CONCENTRATION_ONE_MINUTE, 0, 0, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                // can only be cast by PCs or NPCs
                if (!(caster is CharacterSheet)) {
                    GlobalEvents.AffectBySpell(caster, ID.SHILLELAGH, caster, false);
                    return;
                };
                CharacterSheet sheet = (CharacterSheet)caster;
                // spell requires a quarterstaff or club
                if (sheet.Inventory.MainHand == null) {
                    GlobalEvents.AffectBySpell(caster, ID.SHILLELAGH, caster, false);
                    return;
                }
                if (!sheet.Inventory.MainHand.IsThisA(Weapons.Club) && !sheet.Inventory.MainHand.IsThisA(Weapons.Quarterstaff)) {
                    GlobalEvents.AffectBySpell(caster, ID.SHILLELAGH, caster, false);
                    return;
                }
                // replace melee attacks by shillelagh attacks
                GlobalEvents.AffectBySpell(caster, ID.SHILLELAGH, caster, true);
                foreach (Attack attack in sheet.MeleeAttacks) {
                    attack.Name = ID.SHILLELAGH.Name();
                    attack.Damage.Dices = new Dices(1, 8, modifier);
                    attack.AttackBonus = modifier + sheet.ProficiencyBonus;
                }
                if (caster.BonusAttack != null) {
                    caster.BonusAttack.Name = ID.SHILLELAGH.Name();
                    caster.BonusAttack.Damage.Dices = new Dices(1, 8, modifier);
                    caster.BonusAttack.AttackBonus = modifier + sheet.ProficiencyBonus;
                }
            }
        );
    }
}
using System;

namespace srd5 {
    public class CharacterLevel {
        public int Levels { get; internal set; }
        public CharacterClass Class { get; internal set; }
    }

    public class CharacterInventory {
        public Thing<Weapon> MainHand { get; internal set; }
        public Thing<Item> OffHand { get; internal set; }
        public Thing<Armor> Armor { get; internal set; }
        public Thing<Helmet> Helmet { get; internal set; }
        public Thing<Amulet> Amulet { get; internal set; }
        public Thing<Ring> RingRight { get; internal set; }
        public Thing<Ring> RingLeft { get; internal set; }
        public Thing<Boots> Boots { get; internal set; }
    }

    public class CharacterSheet : Combattant {
        public CharacterRace Race { get { return race; } }
        private CharacterRace race;
        public CharacterLevel[] Levels { get { return levels; } }
        private CharacterLevel[] levels = new CharacterLevel[0];
        public Proficiency[] Proficiencies { get { return proficiencies; } }
        private Proficiency[] proficiencies = new Proficiency[0];
        public Feat[] Feats { get; }
        private Feat[] feats = new Feat[0];
        public Effect[] Effects { get { return effects; } }
        private Effect[] effects = new Effect[0];
        public Dice[] HitDice { get { return hitDice; } }
        private Dice[] hitDice = new Dice[0];
        public ConditionType[] Conditions { get { return conditions; } }
        private ConditionType[] conditions = new ConditionType[0];
        public CharacterInventory Inventory { get; internal set; } = new CharacterInventory();
        public int Attacks {
            get {
                if (HasEffect(Effect.THREE_EXTRA_ATTACKS))
                    return 4;
                else if (HasEffect(Effect.TWO_EXTRA_ATTACKS))
                    return 3;
                else if (HasEffect(Effect.ONE_EXTRA_ATTACK))
                    return 2;
                else
                    return 1;
            }
        }
        public new int ArmorClass {
            get {
                int ac = 10 + Dexterity.Modifier;
                if (Inventory.Armor != null) {
                    ac = Inventory.Armor.Item.AC + Math.Min(Inventory.Armor.Item.MaxDexBonus, Dexterity.Modifier);
                }
                return ac + ArmorClassModifier;
            }
        }

        public new int HitPointsMax {
            get {
                int hp = 0;
                int additionalHp = HasEffect(Effect.ADDITIONAL_HP_PER_LEVEL) ? 1 : 0;
                foreach (Dice dice in hitDice) {
                    hp += dice.Value + Constitution.Modifier + additionalHp;
                }
                return hp;
            }
        }

        public int AttackProficiency {
            get {
                Thing<Weapon> mainhand = Inventory.MainHand;
                int bonus = 0;
                // calculate base proficiency bonus if character is proficient
                if (mainhand == null || IsProficient(mainhand.Item)) {
                    int totalLevel = 0;
                    foreach (CharacterLevel level in levels) {
                        totalLevel += level.Levels;
                    }
                    bonus = (2 + ((totalLevel - 1) / 4));
                }
                // get bonus from strength or dex
                if (mainhand == null) { // unarmed, use strength
                    bonus += Strength.Modifier;
                } else if (mainhand.Item.HasProperty(WeaponProperty.FINESSE)) { // check whether dex is better than str
                    if (Strength.Modifier > Dexterity.Modifier)
                        bonus += Strength.Modifier;
                    else
                        bonus += Dexterity.Modifier;
                    // ranged weapons use dex
                } else if (mainhand.Item.HasProperty(WeaponProperty.AMMUNITION)) {
                    bonus += Dexterity.Modifier;
                } else {
                    bonus += Strength.Modifier;
                }
                // get bonus from feats etc.                
                return bonus;
            }
        }

        public CharacterSheet(Race race) {
            SetRace(race.CharacterRace());
        }

        public void Equip(Thing<Weapon> thing) {
            Weapon weapon = thing.Item;
            // don't equip a weapon that is already equipped in one hand
            if (thing.Equals(Inventory.MainHand) || thing.Equals(Inventory.OffHand)) return;
            if (weapon.HasProperty(WeaponProperty.TWO_HANDED)) {
                Unequip(Inventory.OffHand);
                Unequip(Inventory.MainHand);
                Inventory.MainHand = thing;
            } else if (Inventory.MainHand == null) {
                Inventory.MainHand = thing;
            } else if (Inventory.MainHand.Item.HasProperty(WeaponProperty.TWO_HANDED)) {
                Unequip(Inventory.MainHand);
                Inventory.MainHand = thing;
            } else if (Inventory.OffHand == null && weapon.HasProperty(WeaponProperty.LIGHT)) {
                Inventory.OffHand = Thing<Item>.Cast<Weapon>(thing);
            } else {
                Unequip(Inventory.MainHand);
                Inventory.MainHand = thing;
            }
            RecalculateAttacks();
        }

        internal void RecalculateAttacks() {
            string dmgString;
            if (Inventory.MainHand == null) {
                // unarmed attack
                dmgString = concatDamageString("1d1", Strength.Modifier);
                MeleeAttacks = Utils.Expand<Attack>(new Attack("Unarmed", AttackProficiency, new Damage(DamageType.BLUDGEONING, dmgString)), Attacks);
                RangedAttacks = new Attack[0];
                return;
            }
            Weapon weapon = Inventory.MainHand.Item;
            int modifier = calculateModifier(weapon);
            dmgString = concatDamageString(weapon.Damage.Dices.ToString(), modifier);
            if (weapon.HasProperty(WeaponProperty.VERSATILE) && Inventory.OffHand == null) {
                // increase damage dice because versatile weapon is used two-handed
                dmgString = dmgString.Replace("d10", "d12");
                dmgString = dmgString.Replace("d8", "d10");
                dmgString = dmgString.Replace("d6", "d8");
                dmgString = dmgString.Replace("d4", "d6");
            }
            if (weapon.HasProperty(WeaponProperty.AMMUNITION)) {
                RangedAttacks = Utils.Expand<Attack>(Attack.FromWeapon(AttackProficiency, dmgString, weapon), Attacks);
                MeleeAttacks = new Attack[0];
            } else {
                MeleeAttacks = Utils.Expand<Attack>(Attack.FromWeapon(AttackProficiency, dmgString, weapon), Attacks);
                RangedAttacks = new Attack[0];
            }
            if (Inventory.OffHand == null || !(Inventory.OffHand.Item is Weapon)) return;
            weapon = (Weapon)Inventory.OffHand.Item;
            modifier = calculateModifier(weapon);
            dmgString = concatDamageString(weapon.Damage.Dices.ToString(), modifier);
            if (modifier > 0) modifier = 0; // only negative modifiers for bonus action
            BonusAttack = Attack.FromWeapon(AttackProficiency, dmgString, weapon);
        }

        private int calculateModifier(Weapon weapon) {
            int modifier = Strength.Modifier;
            if (weapon.HasProperty(WeaponProperty.FINESSE)) {
                if (Dexterity.Modifier > modifier)
                    modifier = Dexterity.Modifier;
            } else if (weapon.HasProperty(WeaponProperty.AMMUNITION)) {
                modifier = Dexterity.Modifier;
            }
            return modifier;
        }

        private string concatDamageString(string damageString, int modifier) {
            if (modifier > 0)
                return damageString + "+" + modifier;
            else if (modifier < 0)
                return damageString + modifier;
            return damageString;
        }

        public void Equip(Thing<Shield> thing) {
            if (thing == null) return;
            Shield shield = thing.Item;
            if (Inventory.MainHand != null && Inventory.MainHand.Item.HasProperty(WeaponProperty.TWO_HANDED)) {
                Unequip(Inventory.MainHand);
            }
            Unequip(Inventory.OffHand);
            Inventory.OffHand = Thing<Item>.Cast<Shield>(thing);
            RecalculateAttacks();
        }

        public void Equip(Thing<Armor> armor) {
            if (armor == null) return;
            Unequip(Inventory.Armor);
            Inventory.Armor = armor;
            // calculate speed penality if applicable
            if (!HasEffect(Effect.NO_SPEED_PENALITY_FOR_HEAVY_ARMOR) && armor.Item.Strength > Strength.Value) {
                AddEffect(Effect.HEAVY_ARMOR_SPEED_PENALITY);
            }
        }

        public void Equip(Thing<Ring> ring) {
            if (ring == null) return;
            if (Inventory.RingLeft == null)
                Inventory.RingLeft = ring;
            else if (Inventory.RingRight == null)
                Inventory.RingRight = ring;
            else {
                Unequip(Inventory.RingLeft);
                Inventory.RingLeft = ring;
            }
            addEffects(ring.Item);
        }

        public void Equip(Thing<Helmet> helmet) {
            if (helmet == null) return;
            Unequip(Inventory.Helmet);
            Inventory.Helmet = helmet;
            addEffects(helmet.Item);
        }

        public void Equip(Thing<Boots> boots) {
            if (boots == null) return;
            Unequip(Inventory.Boots);
            Inventory.Boots = boots;
            addEffects(boots.Item);
        }

        public void Equip(Thing<Amulet> amulet) {
            if (amulet == null) return;
            Unequip(Inventory.Amulet);
            Inventory.Amulet = amulet;
            addEffects(amulet.Item);
        }

        private void addEffects(MagicItem item) {
            foreach (Effect effect in item.Effects) {
                AddEffect(effect);
            }
        }

        private void removeEffects(MagicItem item) {
            foreach (Effect effect in item.Effects) {
                RemoveEffect(effect);
            }
        }

        public void Unequip<T>(Thing<T> thing) where T : Item {
            if (thing == null) return;
            switch (thing.Item.Type) {
                case ItemType.WEAPON:
                    if (thing.Equals(Inventory.MainHand))
                        Inventory.MainHand = null;
                    else if (thing.Equals(Inventory.OffHand))
                        Inventory.OffHand = null;
                    break;
                case ItemType.ARMOR:
                    Inventory.Armor = null;
                    RemoveEffect(Effect.HEAVY_ARMOR_SPEED_PENALITY);
                    break;
                case ItemType.HELMET:
                    Inventory.Helmet = null;
                    break;
                case ItemType.RING:
                    if (thing.Equals(Inventory.RingLeft)) {
                        Inventory.RingLeft = null;

                    } else if (thing.Equals(Inventory.RingRight)) {
                        Inventory.RingRight = null;
                    }
                    break;
                case ItemType.AMULET:
                    Inventory.Amulet = null;
                    break;
                case ItemType.BOOTS:
                    Inventory.Boots = null;
                    break;
            }
            if (thing.Item is MagicItem) {
                MagicItem magicItem = (MagicItem)(object)thing.Item;
                removeEffects(magicItem);
            }
        }

        public bool IsProficient(Proficiency proficiency) {
            return Array.IndexOf(proficiencies, proficiency) > -1;
        }

        public bool IsProficient(Item item) {
            if (item == null) return true;
            foreach (Proficiency proficiency in item.Proficiencies) {
                if (IsProficient(proficiency))
                    return true;
            }
            return false;
        }

        public void AddLevel(CharacterClass characterClass) {
            Dice dice = Dice.Get(characterClass.HitDice);
            int additionalHp = HasEffect(Effect.ADDITIONAL_HP_PER_LEVEL) ? 1 : 0;
            foreach (CharacterLevel level in levels) {
                if (level.Class.Class == characterClass.Class) {
                    level.Levels++;
                    Utils.Push<Dice>(ref hitDice, dice);
                    HitPoints += dice.Value + additionalHp + Constitution.Modifier;
                    return;
                }
            }
            CharacterLevel newLevel = new CharacterLevel();
            newLevel.Class = characterClass;
            newLevel.Levels = 1;
            if (levels.Length == 0) { // maximum hitpoints when this is the first level
                dice.Value = dice.MaxValue;
            }
            Utils.Push(ref levels, newLevel);
            Utils.Push<Dice>(ref hitDice, dice);
            HitPoints += dice.Value + additionalHp + Constitution.Modifier;
            foreach (Proficiency proficiency in characterClass.Proficiencies) {
                if (!IsProficient(proficiency)) {
                    Utils.Push<Proficiency>(ref proficiencies, proficiency);
                }
            }
        }

        public bool HasEffect(Effect type) {
            return Array.IndexOf(effects, type) >= 0;
        }

        public void AddProficiency(Proficiency proficiency) {
            Utils.PushUnique<Proficiency>(ref proficiencies, proficiency);
        }

        private void SetRace(CharacterRace race) {
            this.race = race;
            foreach (Feat feat in race.RacialFeats) {
                AddFeat(feat);
            }
            Speed = race.Speed;
        }

        public void AddFeat(Feat feat) {
            if (Utils.PushUnique<Feat>(ref feats, feat))
                feat.Apply(this);
        }

        public override void AddEffect(Effect effect) {
            bool pushed = Utils.PushUnique<Effect>(ref effects, effect);
            if (pushed)
                effect.Apply(this);
        }

        public override void RemoveEffect(Effect effect) {
            RemoveResult result = Utils.RemoveSingle<Effect>(ref effects, effect);
            if (result == RemoveResult.NOT_FOUND) return;
            if (result == RemoveResult.REMOVED_AND_GONE)
                effect.Unapply(this);
        }

        public void AddCondition(ConditionType condition) {
            if (Utils.PushUnique<ConditionType>(ref conditions, condition))
                condition.Apply(this);
        }
        public void RemoveCondition(ConditionType condition) {
            RemoveResult result = Utils.RemoveSingle<ConditionType>(ref conditions, condition);
            if (result == RemoveResult.REMOVED_AND_GONE)
                condition.Unapply(this);
        }

    }
}
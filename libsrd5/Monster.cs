using System;

namespace srd5 {
    public class InnateSpellcasting {
        public enum Frequencies {
            NONE = 0,
            AT_WILL = -1,
            TWICE_PER_DAY = 2
        }

        public Spell Spell { get; private set; }

        public Frequencies Frequency { get; private set; }

        public int Uses { get; internal set; }

        public InnateSpellcasting(Spell spell, InnateSpellcasting.Frequencies frequency = Frequencies.AT_WILL) {
            Spell = spell;
            Frequency = frequency;
            Uses = 0;
        }
    }
    public struct ChallengeRating {
        public static readonly int EIGHTH = -8;
        public static readonly int QUARTER = -4;
        public static readonly int HALF = -2;
    }

    public class Monster : Combattant {
        public Monsters.Type Type { get; internal set; }

        public Monsters.ID ID { get; internal set; }

        public int Challenge { get; internal set; } = 1;

        public int Experience {
            get {
                return srd5.Experience.MonsterByCR(Challenge);
            }
        }

        public int SpellCastDC { get; private set; } = 0;

        public override int ProficiencyBonus {
            get {
                if (Challenge <= 4) return 2;
                return (int)Math.Ceiling((Challenge - 4) / 4.0f) + 2;
            }
        }

        public override string Name {
            get {
                return ID.Name();
            }
        }

        private int baseArmorClass = 0;
        public override int ArmorClass {
            get {
                int ac = baseArmorClass + ArmorClassModifier;
                if (HasEffect(Effect.SPELL_BARKSKIN) && ac < 16)
                    return 16;
                else
                    return ac;
            }
            internal set {
                baseArmorClass = value;
            }
        }

        // Abilities that can be cast like spell, but do not require any
        // Spell Slot to be expended. "Innate Spellcasting"
        private InnateSpellcasting[] innateSpellCasting = new InnateSpellcasting[0];
        public InnateSpellcasting[] InnateSpellCasting {
            get {
                return innateSpellCasting;
            }
        }

        public Monster(Monsters.Type type, Monsters.ID id, Alignment alignment, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma,
                        int armorClass, string hitDice, int speed, int challenge, Attack[] meleeAttacks, Attack[] rangedAttacks, Size size, int spellCastDC = 0) {
            Type = type;
            ID = id;
            Alignment = alignment;
            Strength.BaseValue = strength;
            Dexterity.BaseValue = dexterity;
            Constitution.BaseValue = constitution;
            Intelligence.BaseValue = intelligence;
            Wisdom.BaseValue = wisdom;
            Charisma.BaseValue = charisma;
            ArmorClass = armorClass;
            int hp = new Dice(hitDice).Roll();
            HitPointsMax = hp;
            HitPoints = hp;
            Speed = speed;
            Challenge = challenge;
            EffectiveLevel = challenge;
            MeleeAttacks = meleeAttacks;
            RangedAttacks = rangedAttacks;
            Size = size;
            SpellCastDC = spellCastDC;
        }

        public void AddInnateSpellcasting(params InnateSpellcasting[] innateSpellcastings) {
            Utils.Push<InnateSpellcasting>(ref innateSpellCasting, innateSpellcastings);
        }

        public InnateSpellcasting InnateSpellcastingBySpell(Spell spell) {
            foreach (InnateSpellcasting isc in InnateSpellCasting) {
                if (spell.Is(isc.Spell)) return isc;
            }
            return null;
        }
    }
}
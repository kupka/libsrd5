using System;

namespace srd5 {
    public partial struct Spells {
        public static readonly Spell HoldPerson = new Spell(
            ID.HOLD_PERSON, SpellSchool.ENCHANTMENT, SpellLevel.SECOND, CastingTime.ONE_ACTION, 60, VSM,
            SpellDuration.ONE_MINUTE, 0, 20, delegate (Battleground ground, Combattant caster, int dc, SpellLevel slot, int modifier, Combattant[] targets) {
                // one target per slot above 2nd
                for (int i = 0; i < (int)slot - 1 && i < targets.Length; i++) {
                    Combattant target = targets[i];
                    // only affect humanoid monsters
                    if (target is Monster) {
                        Monster monster = (Monster)target;
                        if (monster.Type != MonsterType.HUMANOID) {
                            GlobalEvents.AffectBySpell(caster, ID.HOLD_PERSON, monster, false);
                            continue;
                        }
                    }
                    // Wisdom save
                    if (!target.DC(ID.HOLD_PERSON, dc, AbilityType.WISDOM)) {
                        GlobalEvents.AffectBySpell(caster, ID.HOLD_PERSON, target, true);
                        target.AddCondition(ConditionType.PARALYZED);
                        target.AddEndOfTurnEvent(delegate (Combattant combattant) {
                            bool success = combattant.DC(ID.HOLD_PERSON, dc, AbilityType.WISDOM);
                            if (success) {
                                combattant.RemoveCondition(ConditionType.PARALYZED);
                            }
                            return success;
                        });
                    } else {
                        GlobalEvents.AffectBySpell(caster, ID.HOLD_PERSON, target, false);
                    }
                }
            }
        );
    }
}
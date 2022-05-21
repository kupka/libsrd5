using System;

namespace srd5 {
    public static class RaceTextResource {
        public static string Name(this Race race) {
            switch (race) {
                case Race.HILL_DWARF:
                    return "Hill Dwarf";
                case Race.HIGH_ELF:
                    return "High Elf";
                default:
                    return Enum.GetName(typeof(Race), race) + ": (Name missing)";
            }
        }

        public static string Description(this Race race) {
            switch (race) {
                case Race.HILL_DWARF:
                    return "Your dwarf character has an assortment of inborn abilities, part and parcel of dwarven nature.\nAs a hill dwarf, you have keen senses, deep intuition, and remarkable resilience.";
                case Race.HIGH_ELF:
                    return "Your elf character has a variety of natural abilities, the result of thousands of years of elven refinement.\nAs a high elf, you have a keen mind and a mastery of at least the basics of magic. In many fantasy gaming worlds, there are two kinds of high elves. One type is haughty and reclusive, believing themselves to be superior to non-elves and even other elves. The other type is more common and more friendly, and often encountered among humans and other races.";
                default:
                    return Enum.GetName(typeof(Race), race) + ": (Description missing)";
            }
        }
    }

    public static class ClassTextResource {
        public static string Name(this Class clazz) {
            switch (clazz) {
                case Class.DRUID:
                    return "Druid";
                case Class.BARBARIAN:
                    return "Barbarian";
                default:
                    return Enum.GetName(typeof(Class), clazz) + ": (Name missing)";
            }
        }
    }

    public static class EffectTextResource {
        public static string Name(this Effect effect) {
            string name = Enum.GetName(typeof(Effect), effect);
            switch (effect) {
                case Effect.RESISTANCE_POISON:
                case Effect.RESISTANCE_COLD:
                    return "Resistance to " + name.Substring(11).ToLower() + " damage";
                case Effect.IMMUNITY_SLEEP:
                    return "Immunity to " + name.Substring(9).ToLower();
                default:
                    return name + ": (Name missing)";
            }
        }
    }

    public static class FeatTextResource {
        public static string Name(this Feat feat) {
            switch (feat) {
                case Feat.DWARVEN_ABILITY_INCREASE:
                case Feat.HILL_DWARVEN_ABILITY_INCREASE:
                case Feat.ELVEN_ABILITY_INCREASE:
                case Feat.HIGH_ELVEN_ABILITY_INCREASE:
                    return "Ability Score Increase";
                case Feat.DWARVEN_DARKVISION:
                case Feat.ELVEN_DARKVISION:
                    return "Darkvision";
                case Feat.DWARVEN_RESILIENCE:
                    return "Dwarven Resilience";
                case Feat.DWARVEN_SMITH:
                case Feat.DWARVEN_BREWER:
                case Feat.DWARVEN_MASON:
                    return "Tool Proficiency";
                case Feat.DWARVEN_COMBAT_TRAINING:
                    return "Dwarven Combat Training";
                case Feat.STONECUNNING:
                    return "Stonecunning";
                case Feat.DWARVEN_TOUGHNESS:
                    return "Dwarven Toughness";
                case Feat.KEEN_SENSES:
                    return "Keen Senses";
                case Feat.FEY_ANCESTRY:
                    return "Fey Ancestry";
                case Feat.HIGH_ELVEN_WEAPON_TRAINING:
                    return "Elf Weapon Training";
                case Feat.HIGH_ELVEN_CANTRIP:
                    return "Cantrip";
                case Feat.RAGE:
                    return "Rage";
                case Feat.UNARMORED_DEFENSE:
                    return "Unarmored Defense";
                case Feat.RECKLESS_ATTACK:
                    return "Reckless Attack";
                case Feat.DANGER_SENSE:
                    return "Danger Sense";
                case Feat.FRENZY:
                    return "Frenzy";
                default:
                    return Enum.GetName(typeof(Feat), feat) + ": (Name missing)";
            }
        }

        public static string Description(this Feat feat) {
            switch (feat) {
                case Feat.DWARVEN_ABILITY_INCREASE:
                    return "Your Constitution score increases by 2.";
                case Feat.HILL_DWARVEN_ABILITY_INCREASE:
                    return "Your Wisdom score increases by 1.";
                case Feat.ELVEN_ABILITY_INCREASE:
                    return "Your Dexterity score increases by 2.";
                case Feat.HIGH_ELVEN_ABILITY_INCREASE:
                    return "Your Intelligence score increases by 1.";
                case Feat.DWARVEN_DARKVISION:
                    return "Accustomed to life underground, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can't discern color in darkness, only shades of gray.";
                case Feat.DWARVEN_RESILIENCE:
                    return "You have advantage on saving throws against poison, and you have resistance against poison damage.";
                case Feat.DWARVEN_SMITH:
                case Feat.DWARVEN_BREWER:
                case Feat.DWARVEN_MASON:
                    return "You gain proficiency with the artisan's tools of your choice: smith's tools, brewer's supplies, or mason's tools.";
                case Feat.DWARVEN_COMBAT_TRAINING:
                    return "You have proficiency with the battleaxe, handaxe, light hammer, and warhammer.";
                case Feat.STONECUNNING:
                    return "Whenever you make an Intelligence (History) check related to the origin of stonework, you are considered proficient in the History skill and add double your proficiency bonus to the check, instead of your normal proficiency bonus.";
                case Feat.DWARVEN_TOUGHNESS:
                    return "Your hit point maximum increases by 1, and it increases by 1 every time you gain a level.";
                case Feat.KEEN_SENSES:
                    return "You have proficiency in the Perception skill.";
                case Feat.FEY_ANCESTRY:
                    return "You have advantage on saving throws against being charmed, and magic can't put you to sleep.";
                case Feat.HIGH_ELVEN_WEAPON_TRAINING:
                    return "You have proficiency with the longsword, shortsword, shortbow, and longbow.";
                case Feat.HIGH_ELVEN_CANTRIP:
                    return "You know one cantrip of your choice from the wizard spell list. Intelligence is your spellcasting ability for it.";
                case Feat.RAGE:
                    return
@"In battle, you fight with primal ferocity. On your turn, you can enter a rage as a bonus action.
While raging, you gain the following benefits if you aren't wearing heavy armor:
    You have advantage on Strength checks and Strength saving throws.
    When you make a melee weapon attack using Strength, you gain a bonus to the damage roll that increases as you gain levels as a barbarian.
    You have resistance to bludgeoning, piercing, and slashing damage.
If you are able to cast spells, you can't cast them or concentrate on them while raging.
Your rage lasts for 1 minute. It ends early if you are knocked unconscious or if your turn ends and you haven't attacked a hostile creature since your last turn or taken damage since then. You can also end your rage on your turn as a bonus action.
Once you have raged the number of times available for your barbarian level, you must finish a long rest before you can rage again";
                case Feat.UNARMORED_DEFENSE:
                    return "While you are not wearing any armor, your Armor Class equals 10 + your Dexterity modifier + your Constitution modifier. You can use a shield and still gain this benefit.";
                case Feat.RECKLESS_ATTACK:
                    return "Starting at 2nd level, you can throw aside all concern for defense to attack with fierce desperation. When you make your first attack on your turn, you can decide to attack recklessly. Doing so gives you advantage on melee weapon attack rolls using Strength during this turn, but attack rolls against you have advantage until your next turn.";
                case Feat.DANGER_SENSE:
                    return "At 2nd level, you gain an uncanny sense of when things nearby aren't as they should be, giving you an edge when you dodge away from danger.\nYou have advantage on Dexterity saving throws against effects that you can see, such as traps and spells. To gain this benefit, you can't be blinded, deafened, or incapacitated.";
                case Feat.FRENZY:
                    return "You can go into a frenzy when you rage. If you do so, for the duration of your rage you can make a single melee weapon attack as a bonus action on each of your turns after this one. When your rage ends, you suffer one level of exhaustion.";
                default:
                    return Enum.GetName(typeof(Feat), feat) + ": (Description missing)";
            }
        }
    }

    public static class SkillTextResource {
        public static string Name(this Skill skill) {
            switch (skill) {
                case Skill.ATHLETICS:
                    return "Athletics";
                case Skill.ACROBATICS:
                    return "Acrobatics";
                case Skill.SLEIGHT_OF_HAND:
                    return "Sleight of Hand";
                case Skill.STEALTH:
                    return "Stealth";
                case Skill.ARCANA:
                    return "Arcana";
                case Skill.HISTORY:
                    return "History";
                case Skill.INVESTIGATION:
                    return "Investigation";
                case Skill.NATURE:
                    return "Nature";
                case Skill.RELIGION:
                    return "Religion";
                case Skill.ANIMAL_HANDLING:
                    return "Animal Handling";
                case Skill.INSIGHT:
                    return "Insight";
                case Skill.MEDICINE:
                    return "Medicine";
                case Skill.PERCEPTION:
                    return "Perception";
                case Skill.SURVIVAL:
                    return "Survival";
                case Skill.DECEPTION:
                    return "Deception";
                case Skill.INTIMIDATION:
                    return "Intimidation";
                case Skill.PERFORMANCE:
                    return "Performance";
                case Skill.PERSUASION:
                    return "Persuasion";
                default:
                    return Enum.GetName(typeof(Skill), skill) + ": (Name missing)";
            }
        }

        public static string Description(this Skill skill) {
            switch (skill) {
                case Skill.ATHLETICS:
                    return "Your Strength (Athletics) check covers difficult situations you encounter while climbing, jumping, or swimming.";
                case Skill.ACROBATICS:
                    return "Your Dexterity (Acrobatics) check covers your attempt to stay on your feet in a tricky situation, such as when you're trying to run across a sheet of ice, balance on a tightrope, or stay upright on a rocking ship's deck.";
                case Skill.SLEIGHT_OF_HAND:
                    return "Whenever you attempt an act of legerdemain or manual trickery, such as planting something on someone else or concealing an object on your person, make a Dexterity (Sleight of Hand) check.";
                case Skill.STEALTH:
                    return "Make a Dexterity (Stealth) check when you attempt to conceal yourself from enemies, slink past guards, slip away without being noticed, or sneak up on someone without being seen or heard.";
                case Skill.ARCANA:
                    return "Your Intelligence (Arcana) check measures your ability to recall lore about spells, magic items, eldritch symbols, magical traditions, the planes of existence, and the inhabitants of those planes.";
                case Skill.HISTORY:
                    return "Your Intelligence (History) check measures your ability to recall lore about historical events, legendary people, ancient kingdoms, past disputes, recent wars, and lost civilizations.";
                case Skill.INVESTIGATION:
                    return "When you look around for clues and make deductions based on those clues, you make an Intelligence (Investigation) check. You might deduce the location of a hidden object, discern from the appearance of a wound what kind of weapon dealt it, or determine the weakest point in a tunnel that could cause it to collapse. Poring through ancient scrolls in search of a hidden fragment of knowledge might also call for an Intelligence (Investigation) check.";
                case Skill.NATURE:
                    return "Your Intelligence (Nature) check measures your ability to recall lore about terrain, plants and animals, the weather, and natural cycles.";
                case Skill.RELIGION:
                    return "Your Intelligence (Religion) check measures your ability to recall lore about deities, rites and prayers, religious hierarchies, holy symbols, and the practices of secret cults.";
                case Skill.ANIMAL_HANDLING:
                    return "When there is any question whether you can calm down a domesticated animal, keep a mount from getting spooked, or intuit an animal's intentions, you need to make a Wisdom (Animal Handling) check. You also make a Wisdom (Animal Handling) check to control your mount when you attempt a risky maneuver.";
                case Skill.INSIGHT:
                    return "Your Wisdom (Insight) check decides whether you can determine the true intentions of a creature, such as when searching out a lie or predicting someone's next move. Doing so involves gleaning clues from body language, speech habits, and changes in mannerisms.";
                case Skill.MEDICINE:
                    return "A Wisdom (Medicine) check lets you try to stabilize a dying companion or diagnose an illness.";
                case Skill.PERCEPTION:
                    return "Your Wisdom (Perception) check lets you spot, hear, or otherwise detect the presence of something. It measures your general awareness of your surroundings and the keenness of your senses. For example, you might try to hear a conversation through a closed door, eavesdrop under an open window, or hear monsters moving stealthily in the forest. Or you might try to spot things that are obscured or easy to miss, whether they are orcs lying in ambush on a road, thugs hiding in the shadows of an alley, or candlelight under a closed secret door.";
                case Skill.SURVIVAL:
                    return "You may need to make a Wisdom (Survival) check to follow tracks, hunt wild game, guide your group through frozen wastelands, identify signs that owlbears live nearby, predict the weather, or avoid quicksand and other natural hazards.";
                case Skill.DECEPTION:
                    return "Your Charisma (Deception) check determines whether you can convincingly hide the truth, either verbally or through your actions. This deception can encompass everything from misleading others through ambiguity to telling outright lies. Typical situations include trying to fast- talk a guard, con a merchant, earn money through gambling, pass yourself off in a disguise, dull someone's suspicions with false assurances, or maintain a straight face while telling a blatant lie.";
                case Skill.INTIMIDATION:
                    return "When you attempt to influence someone through overt threats, hostile actions, and physical violence, you need to make a Charisma (Intimidation) check. Examples include trying to pry information out of a prisoner, convincing street thugs to back down from a confrontation, or using the edge of a broken bottle to convince a sneering vizier to reconsider a decision.";
                case Skill.PERFORMANCE:
                    return "Your Charisma (Performance) check determines how well you can delight an audience with music, dance, acting, storytelling, or some other form of entertainment.";
                case Skill.PERSUASION:
                    return "When you attempt to influence someone or a group of people with tact, social graces, or good nature, the GM might ask you to make a Charisma (Persuasion) check. Typically, you use persuasion when acting in good faith, to foster friendships, make cordial requests, or exhibit proper etiquette. Examples of persuading others include convincing a chamberlain to let your party see the king, negotiating peace between warring tribes, or inspiring a crowd of townsfolk.";
                default:
                    return Enum.GetName(typeof(Skill), skill) + ": (Name missing)";
            }
        }
    }

    public static class ProficiencyTextResource {
        public static string Name(this Proficiency proficiency) {
            switch (proficiency) {
                case Proficiency.LIGHT_ARMOR:
                    return "Light Armor";
                case Proficiency.MEDIUM_ARMOR:
                    return "Medium Armor";
                case Proficiency.HEAVY_ARMOR:
                    return "Heavy Armor";
                case Proficiency.SHIELDS:
                    return "Shields";
                case Proficiency.SIMPLE_MELEE_WEAPONS:
                    return "Simple Melee Weapons";
                case Proficiency.CLUB:
                    return "Club";
                case Proficiency.DAGGER:
                    return "Dagger";
                case Proficiency.GREATCLUB:
                    return "Greatclub";
                case Proficiency.HANDAXE:
                    return "Handaxe";
                case Proficiency.JAVELIN:
                    return "Javelin";
                case Proficiency.LIGHT_HAMMER:
                    return "Light Hammer";
                case Proficiency.MACE:
                    return "Mace";
                case Proficiency.QUARTERSTAFF:
                    return "Quarterstaff";
                case Proficiency.SICKLE:
                    return "Sickle";
                case Proficiency.SPEAR:
                    return "Spear";
                case Proficiency.SIMPLE_RANGED_WEAPONS:
                    return "Simple Ranged Weapons";
                case Proficiency.CROSSBOW_LIGHT:
                    return "Light Crossbow";
                case Proficiency.DARTS:
                    return "Darts";
                case Proficiency.SHORTBOW:
                    return "Shortbow";
                case Proficiency.SLING:
                    return "Sling";
                case Proficiency.MARTIAL_MELEE_WEAPONS:
                    return "Martial Melee Weapons";
                case Proficiency.BATTLEAXE:
                    return "Battleaxe";
                case Proficiency.FLAIL:
                    return "Flail";
                case Proficiency.GLAIVE:
                    return "Glaive";
                case Proficiency.GREATAXE:
                    return "Greataxe";
                case Proficiency.GREATSWORD:
                    return "Greatsword";
                case Proficiency.HALBERD:
                    return "Halberd";
                case Proficiency.LANCE:
                    return "Lance";
                case Proficiency.LONGSWORD:
                    return "Longsword";
                case Proficiency.MAUL:
                    return "Maul";
                case Proficiency.MORNINGSTAR:
                    return "Morningstar";
                case Proficiency.PIKE:
                    return "Pike";
                case Proficiency.RAPIER:
                    return "Rapier";
                case Proficiency.SCIMITAR:
                    return "Scimitar";
                case Proficiency.SHORTSWORD:
                    return "Shortsword";
                case Proficiency.TRIDENT:
                    return "Trident";
                case Proficiency.WAR_PICK:
                    return "War Pick";
                case Proficiency.WARHAMMER:
                    return "Warhammer";
                case Proficiency.WHIP:
                    return "Whip";
                case Proficiency.MARTIAL_RANGED_WEAPONS:
                    return "Martial Ranged Weapons";
                case Proficiency.BLOWGUN:
                    return "Blowgun";
                case Proficiency.CROSSBOW_HAND:
                    return "Hand Crossbow";
                case Proficiency.CROSSBOW_HEAVY:
                    return "Heavy Crossbow";
                case Proficiency.LONGBOW:
                    return "Longbow";
                case Proficiency.NET:
                    return "Net";
                default:
                    return Enum.GetName(typeof(Proficiency), proficiency) + ": (Name missing)";
            }
        }
    }

    public static class SpellTextResource {
        public static string Name(this Spells.ID spell) {
            switch (spell) {
                case Spells.ID.ACID_SPLASH:
                    return "Acid Splash";
                case Spells.ID.CHARM_PERSON:
                    return "Charm Person";
                case Spells.ID.CREATE_OR_DESTROY_WATER:
                    return "Create or Destroy Water";
                case Spells.ID.CURE_WOUNDS:
                    return "Cure Wounds";
                case Spells.ID.DETECT_MAGIC:
                    return "Detect Magic";
                case Spells.ID.DETECT_POISON_AND_DISEASE:
                    return "Detect Poison and Disease";
                case Spells.ID.ENTANGLE:
                    return "Entangle";
                case Spells.ID.FAIRIE_FIRE:
                    return "Fairie Fire";
                case Spells.ID.FOG_CLOUD:
                    return "Fog Cloud";
                case Spells.ID.GUIDANCE:
                    return "Guidance";
                case Spells.ID.HEALING_WORD:
                    return "Healing Word";
                case Spells.ID.HOLD_PERSON:
                    return "Hold Person";
                case Spells.ID.MAGIC_MISSILE:
                    return "Magic Missile";
                case Spells.ID.PRODUCE_FLAME:
                    return "Produce Flame";
                case Spells.ID.RESISTANCE:
                    return "Resistance";
                case Spells.ID.SHILLELAGH:
                    return "Shillelagh";
                default:
                    return Enum.GetName(typeof(Spells.ID), spell) + ": (Name missing)";
            }
        }

        public static string Description(this Spells.ID spell) {
            switch (spell) {
                case Spells.ID.ACID_SPLASH:
                    return "You hurl a bubble of acid. Choose one creature within range, or choose two creatures within range that are within 5 feet of each other. A target must succeed on a Dexterity saving throw or take 1d6 acid damage.\nThis spell's damage increases by 1d6 when you reach 5th level (2d6), 11th level (3d6), and 17th level (4d6).";
                case Spells.ID.CHARM_PERSON:
                    return "You attempt to charm a humanoid you can see within range. It must make a Wisdom saving throw, and does so with advantage if you or your companions are fighting it. If it fails the saving throw, it is charmed by you until the spell ends or until you or your companions do anything harmful to it. The charmed creature regards you as a friendly acquaintance. When the spell ends, the creature knows it was charmed by you.\nWhen you cast this spell using a spell slot of 2nd level or higher, you can target one additional creature for each slot level above 1st. The creatures must be within 30 feet of each other when you target them.";
                case Spells.ID.CREATE_OR_DESTROY_WATER:
                    return "You either create or destroy water.\nCreate Water: You create up to 10 gallons of clean water within range in an open container. Alternatively, the water falls as rain in a 30-foot cube within range, extinguishing exposed flames in the area.\nDestroy Water: You destroy up to 10 gallons of water in an open container within range. Alternatively, you destroy fog in a 30-foot cube within range.\nWhen you cast this spell using a spell slot of 2nd level or higher, you create or destroy 10 additional gallons of water, or the size of the cube increases by 5 feet, for each slot level above 1st.";
                case Spells.ID.CURE_WOUNDS:
                    return "A creature you touch regains a number of hit points equal to 1d8 + your spellcasting ability modifier.\nThis spell has no effect on undead or constructs.\nWhen you cast this spell using a spell slot of 2nd level or higher, the healing increases by 1d8 for each slot level above 1st.";
                case Spells.ID.DETECT_MAGIC:
                    return "For the duration, you sense the presence of magic within 30 feet of you. If you sense magic in this way, you can use your action to see a faint aura around any visible creature or object in the area that bears magic, and you learn its school of magic, if any.\nThe spell can penetrate most barriers, but it is blocked by 1 foot of stone, 1 inch of common metal, a thin sheet of lead, or 3 feet of wood or dirt.";
                case Spells.ID.DETECT_POISON_AND_DISEASE:
                    return "For the duration, you can sense the presence and location of poisons, poisonous creatures, and diseases within 30 feet of you. You also identify the kind of poison, poisonous creature, or disease in each case.\nThe spell can penetrate most barriers, but it is blocked by 1 foot of stone, 1 inch of common metal, a thin sheet of lead, or 3 feet of wood or dirt.";
                case Spells.ID.ENTANGLE:
                    return "Grasping weeds and vines sprout from the ground in a 20-foot square starting from a point within range. For the duration, these plants turn the ground in the area into difficult terrain.\nA creature in the area when you cast the spell must succeed on a Strength saving throw or be restrained by the entangling plants until the spell ends. A creature restrained by the plants can use its action to make a Strength check against your spell save DC. On a success, it frees itself.\nWhen the spell ends, the conjured plants wilt away.";
                case Spells.ID.FAIRIE_FIRE:
                    return "Each object in a 20-foot cube within range is outlined in blue, green, or violet light (your choice). Any creature in the area when the spell is cast is also outlined in light if it fails a Dexterity saving throw.\nFor the duration, objects and affected creatures shed dim light in a 10 - foot radius.\nAny attack roll against an affected creature or object has advantage if the attacker can see it, and the affected creature or object can't benefit from being invisible.";
                case Spells.ID.FOG_CLOUD:
                    return "You create a 20-foot-radius sphere of fog centered on a point within range. The sphere spreads around corners, and its area is heavily obscured. It lasts for the duration or until a wind of moderate or greater speed (at least 10 miles per hour) disperses it.";
                case Spells.ID.GUIDANCE:
                    return "You touch one willing creature. Once before the spell ends, the target can roll a d4 and add the number rolled to one ability check of its choice. It can roll the die before or after making the ability check. The spell then ends.";
                case Spells.ID.HEALING_WORD:
                    return "A creature of your choice that you can see within range regains hit points equal to 1d4 + your spellcasting ability modifier.\nThis spell has no effect on undead or constructs.\nAt Higher Levels: When you cast this spell using a spell slot of 2nd level or higher, the healing increases by 1d4 for each slot level above 1st.";
                case Spells.ID.HOLD_PERSON:
                    return "Choose a humanoid that you can see within range. The target must succeed on a Wisdom saving throw or be paralyzed for the duration. At the end of each of its turns, the target can make another Wisdom saving throw. On a success, the spell ends on the target.\nWhen you cast this spell using a spell slot of 3rd level or higher, you can target one additional humanoid for each slot level above 2nd. The humanoids must be within 30 feet of each other when you target them.";
                case Spells.ID.MAGIC_MISSILE:
                    return "You create three glowing darts of magical force. Each dart hits a creature of your choice that you can see within range. A dart deals 1d4 + 1 force damage to its target. The darts all strike simultaneously, and you can direct them to hit one creature or several.\nWhen you cast this spell using a spell slot of 2nd level or higher, the spell creates one more dart for each slot level above 1st.";
                case Spells.ID.MENDING:
                    return "This spell repairs a single break or tear in an object you touch, such as a broken chain link, two halves of a broken key, a torn cloak, or a leaking wineskin. As long as the break or tear is no larger than 1 foot in any dimension, you mend it, leaving no trace of the former damage.\nThis spell can physically repair a magic item or construct, but the spell can't restore magic to such an object.";
                case Spells.ID.PRODUCE_FLAME:
                    return "A flickering flame appears in your hand. The flame remains there for the duration and harms neither you nor your equipment. The flame sheds bright light in a 10-foot radius and dim light for an additional 10 feet. The spell ends if you dismiss it as an action or if you cast it again.\nYou can also attack with the flame, although doing so ends the spell. When you cast this spell, or as an action on a later turn, you can hurl the flame at a creature within 30 feet of you. Make a ranged spell attack.On a hit, the target takes 1d8 fire damage.\nThis spell's damage increases by 1d8 when you reach 5th level(2d8), 11th level(3d8), and 17th level(4d8).";
                case Spells.ID.RESISTANCE:
                    return "You touch one willing creature. Once before the spell ends, the target can roll a d4 and add the number rolled to one saving throw of its choice. It can roll the die before or after making the saving throw. The spell then ends.";
                case Spells.ID.SHILLELAGH:
                    return "The wood of a club or quarterstaff you are holding is imbued with nature's power. For the duration, you can use your spellcasting ability instead of Strength for the attack and damage rolls of melee attacks using that weapon, and the weapon's damage die becomes a d8. The weapon also becomes magical, if it isn't already. The spell ends if you cast it again or if you let go of the weapon.";
                default:
                    return Enum.GetName(typeof(Spells.ID), spell) + ": (Description missing)";
            }
        }
    }

    public static class MonsterTextResource {
        public static string Name(this MonsterType type) {
            switch (type) {
                case MonsterType.ABERRATION:
                    return "Aberration";
                case MonsterType.BEAST:
                    return "Beast";
                case MonsterType.CELESTIAL:
                    return "Celestial";
                case MonsterType.CONSTRUCT:
                    return "Construct";
                case MonsterType.DRAGON:
                    return "Dragon";
                case MonsterType.ELEMENTAL:
                    return "Elemental";
                case MonsterType.FEY:
                    return "Fey";
                case MonsterType.FIEND:
                    return "Fiend";
                case MonsterType.GIANT:
                    return "Giant";
                case MonsterType.HUMANOID:
                    return "Humanoid";
                case MonsterType.MONSTROSITY:
                    return "Monstrosity";
                case MonsterType.OOZE:
                    return "Ooze";
                case MonsterType.PLANT:
                    return "Plant";
                case MonsterType.UNDEAD:
                    return "Undead";
                default:
                    return Enum.GetName(typeof(MonsterType), type) + ": (Name missing)";
            }
        }

        public static string Description(this MonsterType type) {
            switch (type) {
                case MonsterType.ABERRATION:
                    return "Aberrations are utterly alien beings. Many of them have innate magical abilities drawn from the creature's alien mind rather than the mystical forces of the world.";
                case MonsterType.BEAST:
                    return "Beasts are nonhumanoid creatures that are a natural part of the fantasy ecology. Some of them have magical powers, but most are unintelligent and lack any society or language. Beasts include all varieties of ordinary animals, dinosaurs, and giant versions of animals.";
                case MonsterType.CELESTIAL:
                    return "Celestials are creatures native to the Upper Planes. Many of them are the servants of deities, employed as messengers or agents in the mortal realm and throughout the planes. Celestials are good by nature, so the exceptional celestial who strays from a good alignment is a horrifying rarity. Celestials include angels, couatls, and pegasi.";
                case MonsterType.CONSTRUCT:
                    return "Constructs are made, not born. Some are programmed by their creators to follow a simple set of instructions, while others are imbued with sentience and capable of independent thought. Golems are the iconic constructs. Many creatures native to the outer plane of Mechanus, such as modrons, are constructs shaped from the raw material of the plane by the will of more powerful creatures.";
                case MonsterType.DRAGON:
                    return "Dragons are large reptilian creatures of ancient origin and tremendous power. True dragons, including the good metallic dragons and the evil chromatic dragons, are highly intelligent and have innate magic. Also in this category are creatures distantly related to true dragons, but less powerful, less intelligent, and less magical, such as wyverns and pseudodragons.";
                case MonsterType.ELEMENTAL:
                    return "Elementals are creatures native to the elemental planes. Some creatures of this type are little more than animate masses of their respective elements, including the creatures simply called elementals. Others have biological forms infused with elemental energy. The races of genies, including djinn and efreet, form the most important civilizations on the elemental planes.Other elemental creatures include azers, invisible stalkers, and water weirds.";
                case MonsterType.FEY:
                    return "Fey are magical creatures closely tied to the forces of nature.They dwell in twilight groves and misty forests.In some worlds, they are closely tied to the Plane of Faerie.Some are also found in the Outer Planes, particularly the planes of Arborea and the Beastlands. Fey include dryads, pixies, and satyrs.";
                case MonsterType.FIEND:
                    return "Fiends are creatures of wickedness that are native to the Lower Planes. A few are the servants of deities, but many more labor under the leadership of archdevils and demon princes. Evil priests and mages sometimes summon fiends to the material world to do their bidding. If an evil celestial is a rarity, a good fiend is almost inconceivable. Fiends include demons, devils, hell hounds, rakshasas, and yugoloths.";
                case MonsterType.GIANT:
                    return "Giants tower over humans and their kind.They are humanlike in shape, though some have multiple heads(ettins) or deformities(fomorians). The six varieties of true giant are hill giants, stone giants, frost giants, fire giants, cloud giants, and storm giants. Besides these, creatures such as ogres and trolls are giants.";
                case MonsterType.HUMANOID:
                    return "Humanoids are the main peoples of a fantasy gaming world, both civilized and savage, including humans and a tremendous variety of other species.They have language and culture, few if any innate magical abilities(though most humanoids can learn spellcasting), and a bipedal form. The most common humanoid races are the ones most suitable as player characters: humans, dwarves, elves, and halflings.";
                case MonsterType.MONSTROSITY:
                    return "Monstrosities are monsters in the strictest sense—frightening creatures that are not ordinary, not truly natural, and almost never benign.Some are the results of magical experimentation gone awry(such as owlbears), and others are the product of terrible curses(including minotaurs and yuan-ti). They defy categorization, and in some sense serve as a catch-all category for creatures that don't fit into any other type.";
                case MonsterType.OOZE:
                    return "Oozes are gelatinous creatures that rarely have a fixed shape.They are mostly subterranean, dwelling in caves and dungeons and feeding on refuse, carrion, or creatures unlucky enough to get in their way. Black puddings and gelatinous cubes are among the most recognizable oozes.";
                case MonsterType.PLANT:
                    return "Plants in this context are vegetable creatures, not ordinary flora. Most of them are ambulatory, and some are carnivorous. The quintessential plants are the shambling mound and the treant. Fungal creatures such as the gas spore and the myconid also fall into this category.";
                case MonsterType.UNDEAD:
                    return "Undead are once - living creatures brought to a horrifying state of undeath through the practice of necromantic magic or some unholy curse. Undead include walking corpses, such as vampires and zombies, as well as bodiless spirits, such as ghosts and specters.";
                default:
                    return Enum.GetName(typeof(MonsterType), type) + ": (Description missing)";
            }
        }
    }

    public static class DamageTypeTextResource {
        public static string Name(this DamageType damageType) {
            switch (damageType) {
                case DamageType.ACID:
                    return "Acid";
                case DamageType.BLUDGEONING:
                    return "Bludgeoning";
                case DamageType.COLD:
                    return "Cold";
                case DamageType.FIRE:
                    return "Fire";
                case DamageType.FORCE:
                    return "Force";
                case DamageType.LIGHTNING:
                    return "Lightning";
                case DamageType.NECROTIC:
                    return "Necrotic";
                case DamageType.PIERCING:
                    return "Piercing";
                case DamageType.POISON:
                    return "Poison";
                case DamageType.PSYCHIC:
                    return "Psychic";
                case DamageType.RADIANT:
                    return "Radiant";
                case DamageType.SLASHING:
                    return "Slashing";
                case DamageType.THUNDER:
                    return "Thunder";
                default:
                    return Enum.GetName(typeof(DamageType), damageType) + ": (Name missing)";
            }
        }
    }

    public static class AbilityTextResource {
        public static string Name(this AbilityType ability) {
            switch (ability) {
                case AbilityType.STRENGTH:
                    return "Strength";
                case AbilityType.DEXTERITY:
                    return "Dexterity";
                case AbilityType.CONSTITUTION:
                    return "Constitution";
                case AbilityType.INTELLIGENCE:
                    return "Intelligence";
                case AbilityType.WISDOM:
                    return "Wisdom";
                case AbilityType.CHARISMA:
                    return "Charisma";
                default:
                    return Enum.GetName(typeof(AbilityType), ability) + ": (Name missing)";
            }
        }
        public static string Description(this AbilityType ability) {
            switch (ability) {
                case AbilityType.STRENGTH:
                    return "Strength measures bodily power, athletic training, and the extent to which you can exert raw physical force.";
                case AbilityType.DEXTERITY:
                    return "Dexterity measures agility, reflexes, and balance.";
                case AbilityType.CONSTITUTION:
                    return "Constitution measures health, stamina, and vital force.";
                case AbilityType.INTELLIGENCE:
                    return "Intelligence measures mental acuity, accuracy of recall, and the ability to reason.";
                case AbilityType.WISDOM:
                    return "Wisdom reflects how attuned you are to the world around you and represents perceptiveness and intuition.";
                case AbilityType.CHARISMA:
                    return "Charisma measures your ability to interact effectively with others. It includes such factors as confidence and eloquence, and it can represent a charming or commanding personality.";
                default:
                    return Enum.GetName(typeof(AbilityType), ability) + ": (Description missing)";
            }
        }
    }

    public static class ConditionTypeTextResource {
        public static string Name(this ConditionType condition) {
            switch (condition) {
                case ConditionType.BLINDED:
                    return "blinded";
                case ConditionType.CHARMED:
                    return "charmed";
                case ConditionType.DEAFENED:
                    return "deafened";
                case ConditionType.EXHAUSTED_1:
                    return "lightly exhausted";
                case ConditionType.EXHAUSTED_2:
                    return "somewhat exhausted";
                case ConditionType.EXHAUSTED_3:
                    return "very exhausted";
                case ConditionType.EXHAUSTED_4:
                    return "heavily exhausted";
                case ConditionType.EXHAUSTED_5:
                    return "extremely exhausted";
                case ConditionType.EXHAUSTED_6:
                    return "exhausted to death";
                case ConditionType.FRIGHTENED:
                    return "frightened";
                case ConditionType.GRAPPLED:
                    return "grappled";
                case ConditionType.INCAPACITATED:
                    return "incapacitated";
                case ConditionType.INVISIBLE:
                    return "invisible";
                case ConditionType.PARALYZED:
                    return "paralyzed";
                case ConditionType.PETRIFIED:
                    return "petrified";
                case ConditionType.POISONED:
                    return "poisoned";
                case ConditionType.PRONE:
                    return "prone";
                case ConditionType.RESTRAINED:
                    return "restrained";
                case ConditionType.STUNNED:
                    return "stunned";
                case ConditionType.UNCONSCIOUS:
                    return "unconscious";
                default:
                    return Enum.GetName(typeof(ConditionType), condition) + ": (Name missing)";
            }
        }
        public static string Description(this ConditionType condition) {
            switch (condition) {
                case ConditionType.BLINDED:
                    return "A blinded creature can't see and automatically fails any ability check that requires sight.\nAttack rolls against the creature have advantage, and the creature's attack rolls have disadvantage.";
                case ConditionType.CHARMED:
                    return "A charmed creature can't attack the charmer or target the charmer with harmful abilities or magical effects.\nThe charmer has advantage on any ability check to interact socially with the creature.";
                case ConditionType.DEAFENED:
                    return "A deafened creature can't hear and automatically fails any ability check that requires hearing.";
                case ConditionType.EXHAUSTED_1:
                    return "Disadvantage on ability checks.";
                case ConditionType.EXHAUSTED_2:
                    return "Speed halved.";
                case ConditionType.EXHAUSTED_3:
                    return "Disadvantage on attack rolls and saving throws.";
                case ConditionType.EXHAUSTED_4:
                    return "Hit point maximum halved.";
                case ConditionType.EXHAUSTED_5:
                    return "Speed reduced to 0.";
                case ConditionType.EXHAUSTED_6:
                    return "Death.";
                case ConditionType.FRIGHTENED:
                    return "A frightened creature has disadvantage on ability checks and attack rolls while the source of its fear is within line of sight. The creature can't willingly move closer to the source of its fear.";
                case ConditionType.GRAPPLED:
                    return "A grappled creature's speed becomes 0, and it can't benefit from any bonus to its speed. The condition ends if the grappler is incapacitated. The condition also ends if an effect removes the grappled creature from the reach of the grappler or grappling effect, such as when a creature is forcefully hurled away by a sphere talent or ability.";
                case ConditionType.INCAPACITATED:
                    return "An incapacitated creature can't take actions or reactions.";
                case ConditionType.INVISIBLE:
                    return "An invisible creature is impossible to see without the aid of magic or a special sense. For the purpose of hiding, the creature is heavily obscured. The creature's location can be detected by any noise it makes or any tracks it leaves. Attack rolls against the creature have disadvantage, and the creature's attack rolls have advantage.";
                case ConditionType.PARALYZED:
                    return "A paralyzed creature is incapacitated (see the condition) and can't move or speak.\nThe creature automatically fails Strength and Dexterity saving throws.\nAttack rolls against the creature have advantage.\nAny attack that hits the creature is a critical hit if the attacker is within 5 feet of the creature.\n";
                case ConditionType.PETRIFIED:
                    return "A petrified creature is transformed, along with any nonmagical object it is wearing or carrying, into a solid inanimate substance (usually stone). Its weight increases by a factor of ten, and it ceases aging.\nThe creature is incapacitated (see the condition), can't move or speak, and is unaware of its surroundings.\nAttack rolls against the creature have advantage.\nThe creature automatically fails Strength and Dexterity saving throws.\nThe creature has resistance to all damage.\nThe creature is immune to poison and disease, although a poison or disease already in its system is suspended, not neutralized.\n";
                case ConditionType.POISONED:
                    return "A poisoned creature has disadvantage on attack rolls and ability checks.";
                case ConditionType.PRONE:
                    return "A prone creature's only movement option is to crawl, unless it stands up and thereby ends the condition.\nThe creature has disadvantage on attack rolls.\nAn attack roll against the creature has advantage if the attacker is within 5 feet of the creature. Otherwise, the attack roll has disadvantage.\n";
                case ConditionType.RESTRAINED:
                    return "A restrained creature's speed becomes 0, and it can't benefit from any bonus to its speed.\nAttack rolls against the creature have advantage, and the creature's attack rolls have disadvantage.\nThe creature has disadvantage on Dexterity saving throws.\n";
                case ConditionType.STUNNED:
                    return "A stunned creature is incapacitated (see the condition), can't move, and can speak only falteringly. The creature automatically fails Strength and Dexterity saving throws.\nAttack rolls against the creature have advantage.\n";
                case ConditionType.UNCONSCIOUS:
                    return "An unconscious creature is incapacitated (see the condition), can't move or speak, and is unaware of its surroundings\nThe creature drops whatever it's holding and falls prone.\nThe creature automatically fails Strength and Dexterity saving throws.\nAttack rolls against the creature have advantage. Any attack that hits the creature is a critical hit if the attacker is within 5 feet of the creature.\n";
                default:
                    return Enum.GetName(typeof(ConditionType), condition) + ": (Description missing)";
            }
        }
    }
}
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
                    return "Accustomed to life underground, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can’t discern color in darkness, only shades of gray.";
                case Feat.DWARVEN_RESILIENCE:
                    return "You have advantage on saving throws against poison, and you have resistance against poison damage.";
                case Feat.DWARVEN_SMITH:
                case Feat.DWARVEN_BREWER:
                case Feat.DWARVEN_MASON:
                    return "You gain proficiency with the artisan’s tools of your choice: smith’s tools, brewer’s supplies, or mason’s tools.";
                case Feat.DWARVEN_COMBAT_TRAINING:
                    return "You have proficiency with the battleaxe, handaxe, light hammer, and warhammer.";
                case Feat.STONECUNNING:
                    return "Whenever you make an Intelligence (History) check related to the origin of stonework, you are considered proficient in the History skill and add double your proficiency bonus to the check, instead of your normal proficiency bonus.";
                case Feat.DWARVEN_TOUGHNESS:
                    return "Your hit point maximum increases by 1, and it increases by 1 every time you gain a level.";
                case Feat.KEEN_SENSES:
                    return "You have proficiency in the Perception skill.";
                case Feat.FEY_ANCESTRY:
                    return "You have advantage on saving throws against being charmed, and magic can’t put you to sleep.";
                case Feat.HIGH_ELVEN_WEAPON_TRAINING:
                    return "You have proficiency with the longsword, shortsword, shortbow, and longbow.";
                case Feat.HIGH_ELVEN_CANTRIP:
                    return "You know one cantrip of your choice from the wizard spell list. Intelligence is your spellcasting ability for it.";
                case Feat.RAGE:
                    return
@"In battle, you fight with primal ferocity. On your turn, you can enter a rage as a bonus action.
While raging, you gain the following benefits if you aren’t wearing heavy armor:
    You have advantage on Strength checks and Strength saving throws.
    When you make a melee weapon attack using Strength, you gain a bonus to the damage roll that increases as you gain levels as a barbarian.
    You have resistance to bludgeoning, piercing, and slashing damage.
If you are able to cast spells, you can’t cast them or concentrate on them while raging.
Your rage lasts for 1 minute. It ends early if you are knocked unconscious or if your turn ends and you haven’t attacked a hostile creature since your last turn or taken damage since then. You can also end your rage on your turn as a bonus action.
Once you have raged the number of times available for your barbarian level, you must finish a long rest before you can rage again";
                case Feat.UNARMORED_DEFENSE:
                    return "While you are not wearing any armor, your Armor Class equals 10 + your Dexterity modifier + your Constitution modifier. You can use a shield and still gain this benefit.";
                case Feat.RECKLESS_ATTACK:
                    return "Starting at 2nd level, you can throw aside all concern for defense to attack with fierce desperation. When you make your first attack on your turn, you can decide to attack recklessly. Doing so gives you advantage on melee weapon attack rolls using Strength during this turn, but attack rolls against you have advantage until your next turn.";
                case Feat.DANGER_SENSE:
                    return "At 2nd level, you gain an uncanny sense of when things nearby aren’t as they should be, giving you an edge when you dodge away from danger.\nYou have advantage on Dexterity saving throws against effects that you can see, such as traps and spells. To gain this benefit, you can’t be blinded, deafened, or incapacitated.";
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
                    return "Your Dexterity (Acrobatics) check covers your attempt to stay on your feet in a tricky situation, such as when you’re trying to run across a sheet of ice, balance on a tightrope, or stay upright on a rocking ship’s deck.";
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
                    return "When there is any question whether you can calm down a domesticated animal, keep a mount from getting spooked, or intuit an animal’s intentions, you need to make a Wisdom (Animal Handling) check. You also make a Wisdom (Animal Handling) check to control your mount when you attempt a risky maneuver.";
                case Skill.INSIGHT:
                    return "Your Wisdom (Insight) check decides whether you can determine the true intentions of a creature, such as when searching out a lie or predicting someone’s next move. Doing so involves gleaning clues from body language, speech habits, and changes in mannerisms.";
                case Skill.MEDICINE:
                    return "A Wisdom (Medicine) check lets you try to stabilize a dying companion or diagnose an illness.";
                case Skill.PERCEPTION:
                    return "Your Wisdom (Perception) check lets you spot, hear, or otherwise detect the presence of something. It measures your general awareness of your surroundings and the keenness of your senses. For example, you might try to hear a conversation through a closed door, eavesdrop under an open window, or hear monsters moving stealthily in the forest. Or you might try to spot things that are obscured or easy to miss, whether they are orcs lying in ambush on a road, thugs hiding in the shadows of an alley, or candlelight under a closed secret door.";
                case Skill.SURVIVAL:
                    return "You may need to make a Wisdom (Survival) check to follow tracks, hunt wild game, guide your group through frozen wastelands, identify signs that owlbears live nearby, predict the weather, or avoid quicksand and other natural hazards.";
                case Skill.DECEPTION:
                    return "Your Charisma (Deception) check determines whether you can convincingly hide the truth, either verbally or through your actions. This deception can encompass everything from misleading others through ambiguity to telling outright lies. Typical situations include trying to fast- talk a guard, con a merchant, earn money through gambling, pass yourself off in a disguise, dull someone’s suspicions with false assurances, or maintain a straight face while telling a blatant lie.";
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

    public static class SpellTextResource {
        public static string Name(this Spells.ID spell) {
            switch (spell) {
                case Spells.ID.ACID_SPLASH:
                    return "Acid Splash";
                case Spells.ID.CHARM_PERSON:
                    return "Charm Person";
                case Spells.ID.CURE_WOUNDS:
                    return "Cure Wounds";
                case Spells.ID.HEALING_WORD:
                    return "Healing Word";
                case Spells.ID.HOLD_PERSON:
                    return "Hold Person";
                case Spells.ID.MAGIC_MISSILE:
                    return "Magic Missile";
                case Spells.ID.SHILLELAGH:
                    return "Shillelagh";
                default:
                    return Enum.GetName(typeof(Spells.ID), spell) + ": (Name missing)";
            }
        }

        public static string Description(this Spells.ID spell) {
            switch (spell) {
                case Spells.ID.ACID_SPLASH:
                    return "You hurl a bubble of acid. Choose one creature within range, or choose two creatures within range that are within 5 feet of each other. A target must succeed on a Dexterity saving throw or take 1d6 acid damage.\nThis spell’s damage increases by 1d6 when you reach 5th level (2d6), 11th level (3d6), and 17th level (4d6).";
                case Spells.ID.CHARM_PERSON:
                    return "You attempt to charm a humanoid you can see within range. It must make a Wisdom saving throw, and does so with advantage if you or your companions are fighting it. If it fails the saving throw, it is charmed by you until the spell ends or until you or your companions do anything harmful to it. The charmed creature regards you as a friendly acquaintance. When the spell ends, the creature knows it was charmed by you.\nWhen you cast this spell using a spell slot of 2nd level or higher, you can target one additional creature for each slot level above 1st. The creatures must be within 30 feet of each other when you target them.";
                case Spells.ID.CURE_WOUNDS:
                    return "A creature you touch regains a number of hit points equal to 1d8 + your spellcasting ability modifier.\nThis spell has no effect on undead or constructs.\nWhen you cast this spell using a spell slot of 2nd level or higher, the healing increases by 1d8 for each slot level above 1st.";
                case Spells.ID.HEALING_WORD:
                    return "A creature of your choice that you can see within range regains hit points equal to 1d4 + your spellcasting ability modifier.\nThis spell has no effect on undead or constructs.\nAt Higher Levels: When you cast this spell using a spell slot of 2nd level or higher, the healing increases by 1d4 for each slot level above 1st.";
                case Spells.ID.HOLD_PERSON:
                    return "Choose a humanoid that you can see within range. The target must succeed on a Wisdom saving throw or be paralyzed for the duration. At the end of each of its turns, the target can make another Wisdom saving throw. On a success, the spell ends on the target.\nWhen you cast this spell using a spell slot of 3rd level or higher, you can target one additional humanoid for each slot level above 2nd. The humanoids must be within 30 feet of each other when you target them.";
                case Spells.ID.MAGIC_MISSILE:
                    return "You create three glowing darts of magical force. Each dart hits a creature of your choice that you can see within range. A dart deals 1d4 + 1 force damage to its target. The darts all strike simultaneously, and you can direct them to hit one creature or several.\nWhen you cast this spell using a spell slot of 2nd level or higher, the spell creates one more dart for each slot level above 1st.";
                case Spells.ID.SHILLELAGH:
                    return "The wood of a club or quarterstaff you are holding is imbued with nature’s power. For the duration, you can use your spellcasting ability instead of Strength for the attack and damage rolls of melee attacks using that weapon, and the weapon’s damage die becomes a d8. The weapon also becomes magical, if it isn’t already. The spell ends if you cast it again or if you let go of the weapon.";
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
                    return "Aberrations are utterly alien beings. Many of them have innate magical abilities drawn from the creature’s alien mind rather than the mystical forces of the world.";
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
                    return "Monstrosities are monsters in the strictest sense—frightening creatures that are not ordinary, not truly natural, and almost never benign.Some are the results of magical experimentation gone awry(such as owlbears), and others are the product of terrible curses(including minotaurs and yuan-ti). They defy categorization, and in some sense serve as a catch-all category for creatures that don’t fit into any other type.";
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
}
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
                // Monster Feats
                case Feat.ABERRANT_GROUND:
                    return "Aberrant Ground";
                case Feat.ACID_ABSORPTION:
                    return "Acid Absorption";
                case Feat.ADHESIVE:
                    return "Adhesive (Object Form Only)";
                case Feat.AGGRESSIVE:
                    return "Aggressive";
                case Feat.AIR_FORM:
                    return "Air Form";
                case Feat.AMBUSHER:
                    return "Ambusher";
                case Feat.AMORPHOUS:
                    return "Amorphous";
                case Feat.AMPHIBIOUS:
                    return "Amphibious";
                case Feat.ANGELIC_WEAPONS_4D8:
                case Feat.ANGELIC_WEAPONS_5D8:
                case Feat.ANGELIC_WEAPONS_6D8:
                    return "Angelic Weapons";
                case Feat.ANTIMAGIC_SUSCEPTIBILITY:
                    return "Antimagic Susceptibility";
                case Feat.ASSASSINATE:
                    return "Assassinate";
                case Feat.AVERSION_OF_FIRE:
                    return "Aversion of Fire";
                case Feat.BARBED_HIDE:
                    return "Barbed Hide";
                case Feat.BEAST_OF_BURDEN:
                    return "Beast of Burden";
                case Feat.BERSERK_CLAY_GOLEM:
                case Feat.BERSERK_FLESH_GOLEM:
                    return "Berserk";
                case Feat.BLIND_SENSES:
                    return "Blind Senses";
                case Feat.BLOOD_FRENZY:
                    return "Blood Frenzy";
                case Feat.BOUND:
                    return "Bound";
                case Feat.BRAVE:
                    return "Brave";
                case Feat.BRUTE:
                    return "Brute";
                case Feat.CHARGE_BOAR:
                case Feat.CHARGE_CENTAUR:
                case Feat.CHARGE_ELK:
                case Feat.CHARGE_GIANT_GOAT:
                case Feat.CHARGE_GIANT_SEA_HORSE:
                case Feat.CHARGE_GOAT:
                case Feat.CHARGE_MINOTAUR:
                case Feat.CHARGE_MINOTAUR_SKELETON:
                case Feat.CHARGE_RHINOCEROS:
                case Feat.CHARGE_UNICORN:
                    return "Charge";
                case Feat.CHARGE_WEREBOAR:
                    return "Charge (Boar or Hybrid Form Only)";
                case Feat.CONFER_FIRE_RESISTANCE:
                    return "Confer Fire Resistance";
                case Feat.CONSUME_LIFE:
                    return "Consume Life";
                case Feat.CORRODE_METAL:
                    return "Corrode Metal";
                case Feat.CORROSIVE_FORM:
                    return "Corrosive Form";
                case Feat.CUNNING_ACTION:
                    return "Cunning Action";
                case Feat.DAMAGE_TRANSFER_ATTACHED:
                case Feat.DAMAGE_TRANSFER_GRAPPLING:
                    return "Damage Transfer";
                case Feat.DARK_DEVOTION:
                    return "Dark Devotion";
                case Feat.DEATH_BURST_DUST_MEPHIT:
                case Feat.DEATH_BURST_ICE_MEPHIT:
                case Feat.DEATH_BURST_MAGMA_MEPHIT:
                case Feat.DEATH_BURST_MAGMIN:
                case Feat.DEATH_BURST_STEAM_MEPHIT:
                    return "Death Burst";
                case Feat.DEATH_THROES:
                    return "Death Throes";
                case Feat.DEVILS_SIGHT:
                    return "Devil's Sight";
                case Feat.DIVINE_AWARENESS:
                    return "Divine Awareness";
                case Feat.DIVINE_EMINENCE:
                    return "Divine Eminence";
                case Feat.DUERGAR_RESILIENCE:
                    return "Duergar Resilience";
                case Feat.EARTH_GLIDE:
                    return "Earth Glide";
                case Feat.ECHOLOCATION:
                    return "Echolocation";
                case Feat.ELEMENTAL_DEMISE_DJINNI:
                case Feat.ELEMENTAL_DEMISE_EFREETI:
                    return "Elemental Demise";
                case Feat.EPHEMERAL:
                    return "Ephemeral";
                case Feat.ETHEREAL_JAUNT:
                    return "Ethereal Jaunt";
                case Feat.ETHEREAL_SIGHT:
                    return "Ethereal Sight";
                case Feat.EVASION:
                    return "Evasion";
                case Feat.FALSE_APPEARANCE:
                    return "False Appearance";
                case Feat.FAULTLESS_TRACKER:
                    return "Faultless Tracker";
                case Feat.FEAR_AURA:
                    return "Fear Aura";
                case Feat.FIRE_ABSORPTION:
                    return "Fire Absorption";
                case Feat.FIRE_AURA:
                    return "Fire Aura";
                case Feat.FIRE_FORM:
                    return "Fire Form";
                case Feat.FLYBY:
                    return "Flyby";
                case Feat.FREEDOM_OF_MOVEMENT:
                    return "Freedom of Movement";
                case Feat.FREEZE:
                    return "Freeze";
                case Feat.GIBBERING:
                    return "Gibbering";
                case Feat.GNOME_CUNNING:
                    return "Gnome Cunning";
                case Feat.GRAPPLER:
                    return "Grappler";
                case Feat.GRASPING_TENDRILS:
                    return "Grasping Tendrils";
                case Feat.HEATED_BODY_1D10:
                case Feat.HEATED_BODY_2D6:
                case Feat.HEATED_BODY_3D6:
                    return "Heated Body";
                case Feat.HEATED_WEAPONS:
                    return "Heated Weapons";
                case Feat.HELLISH_REJUVENATION:
                    return "Hellish Rejuvenation";
                case Feat.HELLISH_WEAPONS:
                    return "Hellish Weapons";
                case Feat.HOLD_BREATH_15MIN:
                case Feat.HOLD_BREATH_1HOUR:
                case Feat.HOLD_BREATH_30MIN:
                    return "Hold Breath";
                case Feat.HORRIFIC_APPEARANCE:
                    return "Horrific Appearance";
                case Feat.ICE_WALK:
                    return "Ice Walk";
                case Feat.IGNITED_ILLUMINATION:
                    return "Ignited Illumination";
                case Feat.ILLUMINATION_10FT:
                case Feat.ILLUMINATION_30FT:
                    return "Illumination";
                case Feat.IMMUTABLE_FORM:
                    return "Immutable Form";
                case Feat.INCORPOREAL_MOVEMENT:
                    return "Incorporeal Movement";
                case Feat.INNATE_SPELLCASTING_CLOUD_GIANT:
                case Feat.INNATE_SPELLCASTING_COUATL:
                case Feat.INNATE_SPELLCASTING_DEEP_GNOME:
                case Feat.INNATE_SPELLCASTING_DEVA:
                case Feat.INNATE_SPELLCASTING_DJINNI:
                case Feat.INNATE_SPELLCASTING_DRIDER:
                case Feat.INNATE_SPELLCASTING_DROW:
                case Feat.INNATE_SPELLCASTING_DRYAD:
                case Feat.INNATE_SPELLCASTING_DUST_MEPHIT:
                case Feat.INNATE_SPELLCASTING_EFREETI:
                case Feat.INNATE_SPELLCASTING_GLABREZU:
                case Feat.INNATE_SPELLCASTING_GREEN_HAG:
                case Feat.INNATE_SPELLCASTING_ICE_MEPHIT:
                case Feat.INNATE_SPELLCASTING_LAMIA:
                case Feat.INNATE_SPELLCASTING_MAGMA_MEPHIT:
                case Feat.INNATE_SPELLCASTING_NIGHT_HAG:
                case Feat.INNATE_SPELLCASTING_ONI:
                case Feat.INNATE_SPELLCASTING_PIT_FIEND:
                case Feat.INNATE_SPELLCASTING_PLANETAR:
                case Feat.INNATE_SPELLCASTING_RAKSHASA:
                case Feat.INNATE_SPELLCASTING_SOLAR:
                case Feat.INNATE_SPELLCASTING_STEAM_MEPHIT:
                case Feat.INNATE_SPELLCASTING_STORM_GIANT:
                case Feat.INNATE_SPELLCASTING_UNICORN:
                    return "Innate Spellcasting";
                case Feat.INSCRUTABLE:
                    return "Inscrutable";
                case Feat.INVISIBILITY:
                    return "Invisibility";
                case Feat.IRON_SCENT:
                    return "Iron Scent";
                case Feat.KEEN_HEARING:
                    return "Keen Hearing";
                case Feat.KEEN_HEARING_AND_SIGHT:
                    return "Keen Hearing and Sight";
                case Feat.KEEN_HEARING_AND_SMELL:
                    return "Keen Hearing and Smell";
                case Feat.KEEN_SIGHT:
                    return "Keen Sight";
                case Feat.KEEN_SIGHT_AND_SMELL:
                    return "Keen Sight and Smell";
                case Feat.KEEN_SMELL:
                    return "Keen Smell";
                case Feat.LABYRINTHINE_RECALL:
                    return "Labyrinthine Recall";
                case Feat.LEGENDARY_RESISTANCE:
                    return "Legendary Resistance";
                case Feat.LIGHTNING_ABSORPTION:
                    return "Lightning Absorption";
                case Feat.LIGHT_SENSITIVITY:
                    return "Light Sensitivity";
                case Feat.LIMITED_AMPHIBIOUSNESS:
                    return "Limited Amphibiousness";
                case Feat.LIMITED_MAGIC_IMMUNITY:
                    return "Limited Magic Immunity";
                case Feat.LIMITED_TELEPATHY_OTYUGH:
                case Feat.LIMITED_TELEPATHY_PSEUDODRAGON:
                    return "Limited Telepathy";
                case Feat.MAGIC_RESISTANCE:
                    return "Magic Resistance";
                case Feat.MAGIC_WEAPONS:
                    return "Magic Weapons";
                case Feat.MARTIAL_ADVANTAGE:
                    return "Martial Advantage";
                case Feat.MIMICRY_HAG:
                case Feat.MIMICRY_RAVEN:
                    return "Mimicry";
                case Feat.MISTY_ESCAPE:
                    return "Misty Escape";
                case Feat.MUCOUS_CLOUD:
                    return "Mucous Cloud";
                case Feat.MULTIPLE_HEADS:
                    return "Multiple Heads";
                case Feat.NIGHT_HAG_ITEMS:
                    return "Night Hag Items";
                case Feat.NIMBLE_ESCAPE:
                    return "Nimble Escape";
                case Feat.OOZE_CUBE:
                    return "Ooze Cube";
                case Feat.PACK_TACTICS:
                    return "Pack Tactics";
                case Feat.PETRIFYING_GAZE_BASILISK:
                case Feat.PETRIFYING_GAZE_MEDUSA:
                    return "Petrifying Gaze";
                case Feat.POUNCE_LION:
                case Feat.POUNCE_PANTHER:
                case Feat.POUNCE_TIGER_13:
                case Feat.POUNCE_TIGER_14:
                case Feat.POUNCE_WERETIGER:
                    return "Pounce";
                case Feat.PROBING_TELEPATHY:
                    return "Probing Telepathy";
                case Feat.RAMPAGE:
                    return "Rampage";
                case Feat.REACTIVE:
                    return "Reactive";
                case Feat.REACTIVE_HEADS:
                    return "Reactive Heads";
                case Feat.RECKLESS:
                    return "Reckless";
                case Feat.REFLECTIVE_CARAPACE:
                    return "Reflective Carapace";
                case Feat.REGENERATION:
                    return "Regeneration";
                case Feat.REJUVENATION_LICH:
                case Feat.REJUVENATION_MUMMY_LORD:
                case Feat.REJUVENATION_NAGA:
                    return "Rejuvenation";
                case Feat.RELENTLESS_10:
                case Feat.RELENTLESS_14:
                case Feat.RELENTLESS_7:
                    return "Relentless";
                case Feat.RUNNING_LEAP:
                    return "Running Leap";
                case Feat.RUST_METAL:
                    return "Rust Metal";
                case Feat.SENSE_MAGIC:
                    return "Sense Magic";
                case Feat.SHADOW_STEALTH:
                    return "Shadow Stealth";
                case Feat.SHAPECHANGER_DOPPELGANGER:
                case Feat.SHAPECHANGER_FIEND:
                case Feat.SHAPECHANGER_IMP:
                case Feat.SHAPECHANGER_MIMIC:
                case Feat.SHAPECHANGER_QUASIT:
                case Feat.SHAPECHANGER_VAMPIRE:
                case Feat.SHAPECHANGER_WEREBEAST:
                    return "Shapechanger";
                case Feat.SHARK_TELEPATHY:
                    return "Shark Telepathy";
                case Feat.SHIELDED_MIND:
                    return "Shielded Mind";
                case Feat.SIEGE_MONSTER:
                    return "Siege Monster";
                case Feat.SNEAK_ATTACK_2D6:
                case Feat.SNEAK_ATTACK_4D6:
                    return "Sneak Attack";
                case Feat.SNOW_CAMOUFLAGE:
                    return "Snow Camouflage";
                case Feat.SPEAK_WITH_BEASTS_AND_PLANTS:
                    return "Speak with Beasts and Plants";
                case Feat.SPELLCASTING_ACOLYTE:
                case Feat.SPELLCASTING_ARCHMAGE:
                case Feat.SPELLCASTING_DRUID:
                case Feat.SPELLCASTING_FANATIC:
                case Feat.SPELLCASTING_LICH:
                case Feat.SPELLCASTING_MAGE:
                case Feat.SPELLCASTING_MUMMY_LORD:
                case Feat.SPELLCASTING_NAGA_10:
                case Feat.SPELLCASTING_NAGA_11:
                case Feat.SPELLCASTING_ANDROSPHINX:
                case Feat.SPELLCASTING_GYNOSPHINX:
                    return "Spellcasting";
                case Feat.SPELL_STORING:
                    return "Spell Storing";
                case Feat.SPIDER_CLIMB:
                    return "Spider Climb";
                case Feat.STANDING_LEAP_BULETTE:
                case Feat.STANDING_LEAP_FROG_10FT:
                case Feat.STANDING_LEAP_FROG_20FT:
                case Feat.STANDING_LEAP_TOAD:
                    return "Standing Leap";
                case Feat.STEADFAST:
                    return "Steadfast";
                case Feat.STENCH_GHAST:
                case Feat.STENCH_HEZROU:
                    return "Stench";
                case Feat.STONE_CAMOUFLAGE:
                    return "Stone Camouflage";
                case Feat.SUNLIGHT_SENSITIVITY:
                    return "Sunlight Sensitivity";
                case Feat.SUNLIGHT_WEAKNESS:
                    return "Sunlight Weakness";
                case Feat.SURE_FOOTED:
                    return "Sure-Footed";
                case Feat.SURPRISE_ATTACK_BUGBEAR:
                case Feat.SURPRISE_ATTACK_DOPPELGANGER:
                    return "Surprise Attack";
                case Feat.SWARM:
                    return "Swarm";
                case Feat.TAIL_SPIKE_REGROWTH:
                    return "Tail Spike Regrowth";
                case Feat.TELEPATHIC_BOND_FIEND:
                case Feat.TELEPATHIC_BOND_HOMUNCULUS:
                    return "Telepathic Bond";
                case Feat.TRAMPLING_CHARGE_ELEPHANT:
                case Feat.TRAMPLING_CHARGE_GORGON:
                case Feat.TRAMPLING_CHARGE_HORSE:
                case Feat.TRAMPLING_CHARGE_MAMMOTH:
                case Feat.TRAMPLING_CHARGE_TRICERATOS:
                    return "Trampling Charge";
                case Feat.TRANSPARENT:
                    return "Transparent";
                case Feat.TREASURE_SENSE:
                    return "Treasure Sense";
                case Feat.TREE_STRIDE:
                    return "Tree Stride";
                case Feat.TUNNELER:
                    return "Tunneler";
                case Feat.TURN_DEFIANCE:
                    return "Turn Defiance";
                case Feat.TURN_RESISTANCE:
                    return "Turn Resistance";
                case Feat.TWO_HEADED:
                    return "Two-Headed";
                case Feat.TWO_HEADS:
                    return "Two Heads";
                case Feat.UNDEAD_FORTITUDE:
                    return "Undead Fortitude";
                case Feat.UNDERWATER_CAMOUFLAGE:
                    return "Underwater Camouflage";
                case Feat.VAMPIRE_WEAKNESSES:
                    return "Vampire Weaknesses";
                case Feat.VARIABLE_ILLUMINATION:
                    return "Variable Illumination";
                case Feat.WAKEFUL:
                    return "Wakeful";
                case Feat.WATER_BREATHING:
                    return "Water Breathing";
                case Feat.WATER_FORM:
                    return "Water Form";
                case Feat.WATER_SUSCEPTIBILITY:
                    return "Water Susceptibility";
                case Feat.WEB_SENSE:
                    return "Web Sense";
                case Feat.WEB_WALKER:
                    return "Web Walker";
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
                // Monster Feats
                case Feat.ABERRANT_GROUND:
                    return "The ground in a 10-foot radius around the mouther is doughlike difficult terrain. Each creature that starts its turn in that area must succeed on a DC 10 Strength saving throw or have its speed reduced to 0 until the start of its next turn.";
                case Feat.ACID_ABSORPTION:
                    return "Whenever  subjected to acid damage, it takes no damage and instead regains a number of hit points equal to the acid damage dealt.";
                case Feat.ADHESIVE:
                    return "The mimic adheres to anything that touches it. A Huge or smaller creature adhered to the mimic is also grappled by it (escape DC 13). Ability checks made to escape this grapple have disadvantage.";
                case Feat.AGGRESSIVE:
                    return "As a bonus action, can move up to its speed toward a hostile creature that it can see.";
                case Feat.AIR_FORM:
                    return "Can enter a hostile creature's space and stop there. It can move through a space as narrow as 1 inch wide without squeezing.";
                case Feat.AMBUSHER:
                    return "Has advantage on attack rolls against any creature it has surprised.";
                case Feat.AMORPHOUS:
                    return "Can move through a space as narrow as 1 inch wide without squeezing.";
                case Feat.AMPHIBIOUS:
                    return "Can breathe air and water.";
                case Feat.ANGELIC_WEAPONS_4D8:
                    return "Weapon attacks are magical. When it hits with any weapon, the weapon deals an extra 4d8 radiant damage (included in the attack).";
                case Feat.ANGELIC_WEAPONS_5D8:
                    return "Weapon attacks are magical. When it hits with any weapon, the weapon deals an extra 5d8 radiant damage (included in the attack).";
                case Feat.ANGELIC_WEAPONS_6D8:
                    return "Weapon attacks are magical. When it hits with any weapon, the weapon deals an extra 6d8 radiant damage (included in the attack).";
                case Feat.ANTIMAGIC_SUSCEPTIBILITY:
                    return "Is incapacitated while in the area of an antimagic field. If targeted by dispel magic, it must succeed on a Constitution saving throw against the caster's spell save DC or fall unconscious for 1 minute.";
                case Feat.ASSASSINATE:
                    return "During its first turn, has advantage on attack rolls against any creature that hasn't taken a turn. Any hit it scores against a surprised creature is a critical hit.";
                case Feat.AVERSION_OF_FIRE:
                    return "If it takes fire damage, it has disadvantage on attack rolls and ability checks until the end of its next turn.";
                case Feat.BARBED_HIDE:
                    return "At the start of each of its turns, deals 5 (1d10) piercing damage to any creature grappling it.";
                case Feat.BEAST_OF_BURDEN:
                    return "Is considered to be a Large animal for the purpose of determining its carrying capacity.";
                case Feat.BERSERK_CLAY_GOLEM:
                    return "Whenever the golem starts its turn with 60 hit points or fewer, roll a d6. On a 6, the golem goes berserk. On each of its turns while berserk, the golem attacks the nearest creature it can see. If no creature is near enough to move to and attack, the golem attacks an object, with preference for an object smaller than itself. Once the golem goes berserk, it continues to do so until it is destroyed or regains all its hit points.";
                case Feat.BERSERK_FLESH_GOLEM:
                    return "Whenever the golem starts its turn with 40 hit points or fewer, roll a d6. On a 6, the golem goes berserk. On each of its turns while berserk, the golem attacks the nearest creature it can see. If no creature is near enough to move to and attack, the golem attacks an object, with preference for an object smaller than itself. Once the golem goes berserk, it continues to do so until it is destroyed or regains all its hit points.\nThe golem's creator, if within 60 feet of the berserk golem, can try to calm it by speaking firmly and persuasively. The golem must be able to hear its creator, who must take an action to make a DC 15 Charisma (Persuasion) check. If the check succeeds, the golem ceases being berserk. If it takes damage while still at 40 hit points or fewer, the golem might go berserk again.";
                case Feat.BLIND_SENSES:
                    return "Can't use its blindsight while deafened and unable to smell.";
                case Feat.BLOOD_FRENZY:
                    return "Has advantage on melee attack rolls against any creature that doesn't have all its hit points.";
                case Feat.BOUND:
                    return "The shield guardian is magically bound to an amulet. As long as the guardian and its amulet are on the same plane of existence, the amulet's wearer can telepathically call the guardian to travel to it, and the guardian knows the distance and direction to the amulet. If the guardian is within 60 feet of the amulet's wearer, half of any damage the wearer takes (rounded up) is transferred to the guardian.";
                case Feat.BRAVE:
                    return "Has advantage on saving throws against being frightened.";
                case Feat.BRUTE:
                    return "A wielded melee weapon deals one extra die of its damage when it hits (included in the attack).";
                case Feat.CHARGE_BOAR:
                    return "If the boar moves at least 20 ft. straight toward a target and then hits it with a tusk attack on the same turn, the target takes an extra 3 (1d6) slashing damage. If the target is a creature, it must succeed on a DC 11 Strength saving throw or be knocked prone.";
                case Feat.CHARGE_CENTAUR:
                    return "If the centaur moves at least 30 ft. straight toward a target and then hits it with a pike attack on the same turn, the target takes an extra 10 (3d6) piercing damage.";
                case Feat.CHARGE_ELK:
                    return "If the elk moves at least 20 ft. straight toward a target and then hits it with a ram attack on the same turn, the target takes an extra 7 (2d6) damage. If the target is a creature, it must succeed on a DC 13 Strength saving throw or be knocked prone.";
                case Feat.CHARGE_GIANT_BOAR:
                    return "If the boar moves at least 20 ft. straight toward a target and then hits it with a tusk attack on the same turn, the target takes an extra 7 (2d6) slashing damage. If the target is a creature, it must succeed on a DC 13 Strength saving throw or be knocked prone.";
                case Feat.CHARGE_GIANT_ELK:
                    return "If the elk moves at least 20 ft. straight toward a target and then hits it with a ram attack on the same turn, the target takes an extra 7 (2d6) damage. If the target is a creature, it must succeed on a DC 14 Strength saving throw or be knocked prone.";
                case Feat.CHARGE_GIANT_GOAT:
                    return "If the goat moves at least 20 ft. straight toward a target and then hits it with a ram attack on the same turn, the target takes an extra 5 (2d4) bludgeoning damage. If the target is a creature, it must succeed on a DC 13 Strength saving throw or be knocked prone.";
                case Feat.CHARGE_GIANT_SEA_HORSE:
                    return "If the sea horse moves at least 20 ft. straight toward a target and then hits it with a ram attack on the same turn, the target takes an extra 7 (2d6) bludgeoning damage. If the target is a creature, it must succeed on a DC 11 Strength saving throw or be knocked prone.";
                case Feat.CHARGE_GOAT:
                    return "If the goat moves at least 20 ft. straight toward a target and then hits it with a ram attack on the same turn, the target takes an extra 2 (1d4) bludgeoning damage. If the target is a creature, it must succeed on a DC 10 Strength saving throw or be knocked prone.";
                case Feat.CHARGE_MINOTAUR:
                    return "If the minotaur moves at least 10 ft. straight toward a target and then hits it with a gore attack on the same turn, the target takes an extra 9 (2d8) piercing damage. If the target is a creature, it must succeed on a DC 14 Strength saving throw or be pushed up to 10 ft. away and knocked prone.";
                case Feat.CHARGE_MINOTAUR_SKELETON:
                    return "If the skeleton moves at least 10 feet straight toward a target and then hits it with a gore attack on the same turn, the target takes an extra 9 (2d8) piercing damage. If the target is a creature, it must succeed on a DC 14 Strength saving throw or be pushed up to 10 feet away and knocked prone.";
                case Feat.CHARGE_RHINOCEROS:
                    return "If the rhinoceros moves at least 20 ft. straight toward a target and then hits it with a gore attack on the same turn, the target takes an extra 9 (2d8) bludgeoning damage. If the target is a creature, it must succeed on a DC 15 Strength saving throw or be knocked prone.";
                case Feat.CHARGE_UNICORN:
                    return "If the unicorn moves at least 20 ft. straight toward a target and then hits it with a horn attack on the same turn, the target takes an extra 9 (2d8) piercing damage. If the target is a creature, it must succeed on a DC 15 Strength saving throw or be knocked prone.";
                case Feat.CHARGE_WEREBOAR:
                    return "If the wereboar moves at least 15 feet straight toward a target and then hits it with its tusks on the same turn, the target takes an extra 7 (2d6) slashing damage. If the target is a creature, it must succeed on a DC 13 Strength saving throw or be knocked prone.";
                case Feat.CONFER_FIRE_RESISTANCE:
                    return "Can grant resistance to fire damage to anyone riding it.";
                case Feat.CONSUME_LIFE:
                    return "As a bonus action, can target one creature it can see within 5 ft. of it that has 0 hit points and is still alive. The target must succeed on a DC 10 Constitution saving throw against this magic or die. If its target dies, it regains 10 (3d6) hit points.";
                case Feat.CORRODE_METAL:
                    return "Any nonmagical weapon made of metal that hits the ooze corrodes. After dealing damage, the weapon takes a permanent and cumulative -1 penalty to damage rolls. If its penalty drops to -5, the weapon is destroyed. Nonmagical ammunition made of metal that hits the ooze is destroyed after dealing damage.\nThe ooze can eat through 2-inch-thick, nonmagical metal in 1 round.";
                case Feat.CORROSIVE_FORM:
                    return "A creature that touches the pudding or hits it with a melee attack while within 5 feet of it takes 4 (1d8) acid damage. Any nonmagical weapon made of metal or wood that hits the pudding corrodes. After dealing damage, the weapon takes a permanent and cumulative -1 penalty to damage rolls. If its penalty drops to -5, the weapon is destroyed. Nonmagical ammunition made of metal or wood that hits the pudding is destroyed after dealing damage. The pudding can eat through 2-inch-thick, nonmagical wood or metal in 1 round.";
                case Feat.CUNNING_ACTION:
                    return "On each of its turns, can use a bonus action to take the Dash, Disengage, or Hide action.";
                case Feat.DAMAGE_TRANSFER_ATTACHED:
                    return "While attached to a creature, takes only half the damage dealt to it (rounded down), and that creature takes the other half.";
                case Feat.DAMAGE_TRANSFER_GRAPPLING:
                    return "While it is grappling a creature, takes only half the damage dealt to it, and the creature grappled takes the other half.";
                case Feat.DARK_DEVOTION:
                    return "Has advantage on saving throws against being charmed or frightened.";
                case Feat.DEATH_BURST_DUST_MEPHIT:
                    return "When the mephit dies, it explodes in a burst of dust. Each creature within 5 ft. of it must then succeed on a DC 10 Constitution saving throw or be blinded for 1 minute. A blinded creature can repeat the saving throw on each of its turns, ending the effect on itself on a success.";
                case Feat.DEATH_BURST_ICE_MEPHIT:
                    return "When the mephit dies, it explodes in a burst of jagged ice. Each creature within 5 ft. of it must make a DC 10 Dexterity saving throw, taking 4 (1d8) slashing damage on a failed save, or half as much damage on a successful one.";
                case Feat.DEATH_BURST_MAGMA_MEPHIT:
                    return "When the mephit dies, it explodes in a burst of lava. Each creature within 5 ft. of it must make a DC 11 Dexterity saving throw, taking 7 (2d6) fire damage on a failed save, or half as much damage on a successful one.";
                case Feat.DEATH_BURST_MAGMIN:
                    return "When the magmin dies, it explodes in a burst of fire and magma. Each creature within 10 ft. of it must make a DC 11 Dexterity saving throw, taking 7 (2d6) fire damage on a failed save, or half as much damage on a successful one. Flammable objects that aren't being worn or carried in that area are ignited.";
                case Feat.DEATH_BURST_STEAM_MEPHIT:
                    return "When the mephit dies, it explodes in a cloud of steam. Each creature within 5 ft. of the mephit must succeed on a DC 10 Dexterity saving throw or take 4 (1d8) fire damage.";
                case Feat.DEATH_THROES:
                    return "When the balor dies, it explodes, and each creature within 30 feet of it must make a DC 20 Dexterity saving throw, taking 70 (20d6) fire damage on a failed save, or half as much damage on a successful one. The explosion ignites flammable objects in that area that aren't being worn or carried, and it destroys the balor's weapons.";
                case Feat.DEVILS_SIGHT:
                    return "Magical darkness doesn't impede its darkvision.";
                case Feat.DIVINE_AWARENESS:
                    return "Knows if it hears a lie.";
                case Feat.DIVINE_EMINENCE:
                    return "As a bonus action, the priest can expend a spell slot to cause its melee weapon attacks to magically deal an extra 10 (3d6) radiant damage to a target on a hit. This benefit lasts until the end of the turn. If the priest expends a spell slot of 2nd level or higher, the extra damage increases by 1d6 for each level above 1st.";
                case Feat.DUERGAR_RESILIENCE:
                    return "The duergar has advantage on saving throws against poison, spells, and illusions, as well as to resist being charmed or paralyzed.";
                case Feat.EARTH_GLIDE:
                    return "Can burrow through nonmagical, unworked earth and stone. While doing so, it doesn't disturb the material it moves through.";
                case Feat.ECHOLOCATION:
                    return "Can't use its blindsight while deafened.";
                case Feat.ELEMENTAL_DEMISE_DJINNI:
                    return "If the djinni dies, its body disintegrates into a warm breeze, leaving behind only equipment the djinni was wearing or carrying.";
                case Feat.ELEMENTAL_DEMISE_EFREETI:
                    return "If the efreeti dies, its body disintegrates in a flash of fire and puff of smoke, leaving behind only equipment the djinni was wearing or carrying.";
                case Feat.EPHEMERAL:
                    return "Can't wear or carry anything.";
                case Feat.ETHEREAL_JAUNT:
                    return "As a bonus action, can magically shift from the Material Plane to the Ethereal Plane, or vice versa.";
                case Feat.ETHEREAL_SIGHT:
                    return "Can see 60 ft. into the Ethereal Plane when it is on the Material Plane, and vice versa.";
                case Feat.EVASION:
                    return "If the assassin is subjected to an effect that allows it to make a Dexterity saving throw to take only half damage, the assassin instead takes no damage if it succeeds on the saving throw, and only half damage if it fails.";
                case Feat.FALSE_APPEARANCE:
                    return "While it remains motionless, it is indistinguishable from a normal object.";
                case Feat.FAULTLESS_TRACKER:
                    return "The stalker is given a quarry by its summoner. The stalker knows the direction and distance to its quarry as long as the two of them are on the same plane of existence. The stalker also knows the location of its summoner.";
                case Feat.FEAR_AURA:
                    return "Any creature hostile to the pit fiend that starts its turn within 20 feet of the pit fiend must make a DC 21 Wisdom saving throw, unless the pit fiend is incapacitated. On a failed save, the creature is frightened until the start of its next turn. If a creature's saving throw is successful, the creature is immune to the pit fiend's Fear Aura for the next 24 hours.";
                case Feat.FIRE_ABSORPTION:
                    return "Whenever subjected to fire damage, it takes no damage and instead regains a number of hit points equal to the fire damage dealt.";
                case Feat.FIRE_AURA:
                    return "At the start of each of its turns, each creature within 5 feet of it takes 10 (3d6) fire damage, and flammable objects in the aura that aren't being worn or carried ignite. A creature that touches it or hits it with a melee attack while within 5 feet of it takes 10 (3d6) fire damage.";
                case Feat.FIRE_FORM:
                    return "Can move through a space as narrow as 1 inch wide without squeezing. A creature that touches it or hits it with a melee attack while within 5 ft. of it takes 5 (1d10) fire damage. In addition, it can enter a hostile creature's space and stop there. The first time it enters a creature's space on a turn, that creature takes 5 (1d10) fire damage and catches fire; until someone takes an action to douse the fire, the creature takes 5 (1d10) fire damage at the start of each of its turns.";
                case Feat.FLYBY:
                    return "Doesn't provoke opportunity attacks when it flies out of an enemy's reach.";
                case Feat.FREEDOM_OF_MOVEMENT:
                    return "Ignores difficult terrain, and magical effects can't reduce its speed or cause it to be restrained. It can spend 5 feet of movement to escape from nonmagical restraints or being grappled.";
                case Feat.FREEZE:
                    return "If it takes cold damage, it partially freezes; its speed is reduced by 20 ft. until the end of its next turn.";
                case Feat.GIBBERING:
                    return "The mouther babbles incoherently while it can see any creature and isn't incapacitated. Each creature that starts its turn within 20 feet of the mouther and can hear the gibbering must succeed on a DC 10 Wisdom saving throw. On a failure, the creature can't take reactions until the start of its next turn and rolls a d8 to determine what it does during its turn. On a 1 to 4, the creature does nothing. On a 5 or 6, the creature takes no action or bonus action and uses all its movement to move in a randomly determined direction. On a 7 or 8, the creature makes a melee attack against a randomly determined creature within its reach or does nothing if it can't make such an attack.";
                case Feat.GNOME_CUNNING:
                    return "The gnome has advantage on Intelligence, Wisdom, and Charisma saving throws against magic.";
                case Feat.GRAPPLER:
                    return "Has advantage on attack rolls against any creature grappled by it.";
                case Feat.GRASPING_TENDRILS:
                    return "The roper can have up to six tendrils at a time. Each tendril can be attacked (AC 20; 10 hit points; immunity to poison and psychic damage). Destroying a tendril deals no damage to the roper, which can extrude a replacement tendril on its next turn. A tendril can also be broken if a creature takes an action and succeeds on a DC 15 Strength check against it.";
                case Feat.HEATED_BODY_1D10:
                    return "A creature that touches or hits it with a melee attack while within 5 ft. of it takes 5 (1d10) fire damage.";
                case Feat.HEATED_BODY_2D6:
                    return "A creature that touches or hits it with a melee attack while within 5 ft. of it takes 7 (2d6) fire damage.";
                case Feat.HEATED_BODY_3D6:
                    return "A creature that touches or hits it with a melee attack while within 5 feet of it takes 10 (3d6) fire damage.";
                case Feat.HEATED_WEAPONS:
                    return "When it hits with a metal melee weapon, it deals an extra 3 (1d6) fire damage (included in the attack).";
                case Feat.HELLISH_REJUVENATION:
                    return "A lemure that dies in the Nine Hells comes back to life with all its hit points in 1d10 days unless it is killed by a good-aligned creature with a bless spell cast on that creature or its remains are sprinkled with holy water.";
                case Feat.HELLISH_WEAPONS:
                    return "Weapon attacks are magical and deal an extra 13 (3d8) poison damage on a hit (included in the attacks).";
                case Feat.HOLD_BREATH_15MIN:
                    return "Can hold its breath for 15 minutes.";
                case Feat.HOLD_BREATH_30MIN:
                    return "Can hold its breath for 30 minutes.";
                case Feat.HOLD_BREATH_1HOUR:
                    return "Can hold its breath for 1 hour.";
                case Feat.HORRIFIC_APPEARANCE:
                    return "Any humanoid that starts its turn within 30 feet of the hag and can see the hag's true form must make a DC 11 Wisdom saving throw. On a failed save, the creature is frightened for 1 minute. A creature can repeat the saving throw at the end of each of its turns, with disadvantage if the hag is within line of sight, ending the effect on itself on a success. If a creature's saving throw is successful or the effect ends for it, the creature is immune to the hag's Horrific Appearance for the next 24 hours.\nUnless the target is surprised or the revelation of the hag's true form is sudden, the target can avert its eyes and avoid making the initial saving throw. Until the start of its next turn, a creature that averts its eyes has disadvantage on attack rolls against the hag.";
                case Feat.ICE_WALK:
                    return "Can move across and climb icy surfaces without needing to make an ability check. Additionally, difficult terrain composed of ice or snow doesn't cost it extra moment.";
                case Feat.IGNITED_ILLUMINATION:
                    return "As a bonus action, can set itself ablaze or extinguish its flames. While ablaze, sheds bright light in a 10-foot radius and dim light for an additional 10 ft.";
                case Feat.ILLUMINATION_10FT:
                    return "Sheds bright light in a 10-foot radius and dim light for an additional 10 ft..";
                case Feat.ILLUMINATION_30FT:
                    return "Sheds bright light in a 30-foot radius and dim light in an additional 30 ft..";
                case Feat.IMMUTABLE_FORM:
                    return "Is immune to any spell or effect that would alter its form.";
                case Feat.INCORPOREAL_MOVEMENT:
                    return "Can move through other creatures and objects as if they were difficult terrain. It takes 5 (1d10) force damage if it ends its turn inside an object.";
                case Feat.INNATE_SPELLCASTING_CLOUD_GIANT:
                    return "The giant's innate spellcasting ability is Charisma. It can innately cast the following spells, requiring no material components:\n\nAt will: detect magic, fog cloud, light\n3/day each: feather fall, fly, misty step, telekinesis\n1/day each: control weather, gaseous form";
                case Feat.INNATE_SPELLCASTING_COUATL:
                    return "The couatl's spellcasting ability is Charisma (spell save DC 14). It can innately cast the following spells, requiring only verbal components:\n\nAt will: detect evil and good, detect magic, detect thoughts\n3/day each: bless, create food and water, cure wounds, lesser restoration, protection from poison, sanctuary, shield\n1/day each: dream, greater restoration, scrying";
                case Feat.INNATE_SPELLCASTING_DEEP_GNOME:
                    return "The gnome's innate spellcasting ability is Intelligence (spell save DC 11). It can innately cast the following spells, requiring no material components:\nAt will: nondetection (self only)\n1/day each: blindness/deafness, blur, disguise self";
                case Feat.INNATE_SPELLCASTING_DEVA:
                    return "The deva's spellcasting ability is Charisma (spell save DC 17). The deva can innately cast the following spells, requiring only verbal components:\nAt will: detect evil and good\n1/day each: commune, raise dead";
                case Feat.INNATE_SPELLCASTING_DJINNI:
                    return "The djinni's innate spellcasting ability is Charisma (spell save DC 17, +9 to hit with spell attacks). It can innately cast the following spells, requiring no material components:\n\nAt will: detect evil and good, detect magic, thunderwave\n3/day each: create food and water (can create wine instead of water), tongues, wind walk\n1/day each: conjure elemental (air elemental only), creation, gaseous form, invisibility, major image, plane shift";
                case Feat.INNATE_SPELLCASTING_DRIDER:
                    return "The drider's innate spellcasting ability is Wisdom (spell save DC 13). The drider can innately cast the following spells, requiring no material components:\nAt will: dancing lights\n1/day each: darkness, faerie fire";
                case Feat.INNATE_SPELLCASTING_DROW:
                    return "The drow's spellcasting ability is Charisma (spell save DC 11). It can innately cast the following spells, requiring no material components:\nAt will: dancing lights\n1/day each: darkness, faerie fire";
                case Feat.INNATE_SPELLCASTING_DRYAD:
                    return "The dryad's innate spellcasting ability is Charisma (spell save DC 14). The dryad can innately cast the following spells, requiring no material components:\n\nAt will: druidcraft\n3/day each: entangle, goodberry\n1/day each: barkskin, pass without trace, shillelagh";
                case Feat.INNATE_SPELLCASTING_DUST_MEPHIT:
                    return "The mephit can innately cast sleep, requiring no material components. Its innate spellcasting ability is Charisma.";
                case Feat.INNATE_SPELLCASTING_EFREETI:
                    return "The efreeti's innate spell casting ability is Charisma (spell save DC 15, +7 to hit with spell attacks). It can innately cast the following spells, requiring no material components:\n\nAt will: detect magic\n3/day: enlarge/reduce, tongues\n1/day each: conjure elemental (fire elemental only), gaseous form, invisibility, major image, plane shift, wall of fire";
                case Feat.INNATE_SPELLCASTING_GLABREZU:
                    return "The glabrezu's spellcasting ability is Intelligence (spell save DC 16). The glabrezu can innately cast the following spells, requiring no material components:\nAt will: darkness, detect magic, dispel magic\n1/day each: confusion, fly, power word stun";
                case Feat.INNATE_SPELLCASTING_GREEN_HAG:
                    return "The hag's innate spellcasting ability is Charisma (spell save DC 12). She can innately cast the following spells, requiring no material components:\n\nAt will: dancing lights, minor illusion, vicious mockery";
                case Feat.INNATE_SPELLCASTING_ICE_MEPHIT:
                    return "The mephit can innately cast fog cloud, requiring no material components. Its innate spellcasting ability is Charisma.";
                case Feat.INNATE_SPELLCASTING_LAMIA:
                    return "The lamia's innate spellcasting ability is Charisma (spell save DC 13). It can innately cast the following spells, requiring no material components. At will: disguise self (any humanoid form), major image 3/day each: charm person, mirror image, scrying, suggestion 1/day: geas";
                case Feat.INNATE_SPELLCASTING_MAGMA_MEPHIT:
                    return "The mephit can innately cast heat metal (spell save DC 10), requiring no material components. Its innate spellcasting ability is Charisma.";
                case Feat.INNATE_SPELLCASTING_NIGHT_HAG:
                    return "The hag's innate spellcasting ability is Charisma (spell save DC 14, +6 to hit with spell attacks). She can innately cast the following spells, requiring no material components:\n\nAt will: detect magic, magic missile\n2/day each: plane shift (self only), ray of enfeeblement, sleep";
                case Feat.INNATE_SPELLCASTING_ONI:
                    return "The oni's innate spellcasting ability is Charisma (spell save DC 13). The oni can innately cast the following spells, requiring no material components:\n\nAt will: darkness, invisibility\n1/day each: charm person, cone of cold, gaseous form, sleep";
                case Feat.INNATE_SPELLCASTING_PIT_FIEND:
                    return "The pit fiend's spellcasting ability is Charisma (spell save DC 21). The pit fiend can innately cast the following spells, requiring no material components:\nAt will: detect magic, fireball\n3/day each: hold monster, wall of fire";
                case Feat.INNATE_SPELLCASTING_PLANETAR:
                    return "The planetar's spellcasting ability is Charisma (spell save DC 20). The planetar can innately cast the following spells, requiring no material components:\nAt will: detect evil and good, invisibility (self only)\n3/day each: blade barrier, dispel evil and good, flame strike, raise dead\n1/day each: commune, control weather, insect plague";
                case Feat.INNATE_SPELLCASTING_RAKSHASA:
                    return "The rakshasa's innate spellcasting ability is Charisma (spell save DC 18, +10 to hit with spell attacks). The rakshasa can innately cast the following spells, requiring no material components:\n\nAt will: detect thoughts, disguise self, mage hand, minor illusion\n3/day each: charm person, detect magic, invisibility, major image, suggestion\n1/day each: dominate person, fly, plane shift, true seeing";
                case Feat.INNATE_SPELLCASTING_SOLAR:
                    return "The solar's spell casting ability is Charisma (spell save DC 25). It can innately cast the following spells, requiring no material components:\nAt will: detect evil and good, invisibility (self only)\n3/day each: blade barrier, dispel evil and good, resurrection\n1/day each: commune, control weather";
                case Feat.INNATE_SPELLCASTING_STEAM_MEPHIT:
                    return "The mephit can innately cast blur, requiring no material components. Its innate spellcasting ability is Charisma.";
                case Feat.INNATE_SPELLCASTING_STORM_GIANT:
                    return "The giant's innate spellcasting ability is Charisma (spell save DC 17). It can innately cast the following spells, requiring no material components:\n\nAt will: detect magic, feather fall, levitate, light\n3/day each: control weather, water breathing";
                case Feat.INNATE_SPELLCASTING_UNICORN:
                    return "The unicorn's innate spellcasting ability is Charisma (spell save DC 14). The unicorn can innately cast the following spells, requiring no components:\n\nAt will: detect evil and good, druidcraft, pass without trace\n1/day each: calm emotions, dispel evil and good, entangle";
                case Feat.INSCRUTABLE:
                    return "Is immune to any effect that would sense its emotions or read its thoughts, as well as any divination spell that it refuses. Wisdom (Insight) checks made to ascertain its intentions or sincerity have disadvantage.";
                case Feat.INVISIBILITY:
                    return "Is invisible.";
                case Feat.IRON_SCENT:
                    return "Can pinpoint, by scent, the location of ferrous metal within 30 feet of it.";
                case Feat.KEEN_HEARING:
                    return "Has advantage on Wisdom (Perception) checks that rely on hearing.";
                case Feat.KEEN_HEARING_AND_SIGHT:
                    return "Has advantage on Wisdom (Perception) checks that rely on hearing or sight.";
                case Feat.KEEN_HEARING_AND_SMELL:
                    return "Has advantage on Wisdom (Perception) checks that rely on hearing or smell.";
                case Feat.KEEN_SIGHT:
                    return "Has advantage on Wisdom (Perception) checks that rely on sight.";
                case Feat.KEEN_SIGHT_AND_SMELL:
                    return "Has advantage on Wisdom (Perception) checks that rely on sight or smell.";
                case Feat.KEEN_SMELL:
                    return "Has advantage on Wisdom (Perception) checks that rely on smell.";
                case Feat.LABYRINTHINE_RECALL:
                    return "Can perfectly recall any path it has traveled.";
                case Feat.LEGENDARY_RESISTANCE:
                    return "If it fails a saving throw, it can choose to succeed instead.";
                case Feat.LIGHT_SENSITIVITY:
                    return "While in bright light, has disadvantage on attack rolls and Wisdom (Perception) checks that rely on sight.";
                case Feat.LIGHTNING_ABSORPTION:
                    return "Whenever subjected to lightning damage, it takes no damage and instead regains a number of hit points equal to the lightning damage dealt.";
                case Feat.LIMITED_AMPHIBIOUSNESS:
                    return "Can breathe air and water, but it needs to be submerged at least once every 4 hours to avoid suffocating.";
                case Feat.LIMITED_MAGIC_IMMUNITY:
                    return "Can't be affected or detected by spells of 6th level or lower unless it wishes to be. It has advantage on saving throws against all other spells and magical effects.";
                case Feat.LIMITED_TELEPATHY_OTYUGH:
                    return "The otyugh can magically transmit simple messages and images to any creature within 120 ft. of it that can understand a language. This form of telepathy doesn't allow the receiving creature to telepathically respond.";
                case Feat.LIMITED_TELEPATHY_PSEUDODRAGON:
                    return "The pseudodragon can magically communicate simple ideas, emotions, and images telepathically with any creature within 100 ft. of it that can understand a language.";
                case Feat.MAGIC_RESISTANCE:
                    return "Has advantage on saving throws against spells and other magical effects.";
                case Feat.MAGIC_WEAPONS:
                    return "Its weapon attacks are magical.";
                case Feat.MARTIAL_ADVANTAGE:
                    return "Once per turn, it can deal an extra 7 (2d6) damage to a creature it hits with a weapon attack if that creature is within 5 ft. of an ally that isn't incapacitated.";
                case Feat.MIMICRY_HAG:
                    return "The hag can mimic animal sounds and humanoid voices. A creature that hears the sounds can tell they are imitations with a successful DC 14 Wisdom (Insight) check.";
                case Feat.MIMICRY_RAVEN:
                    return "The raven can mimic simple sounds it has heard, such as a person whispering, a baby crying, or an animal chittering. A creature that hears the sounds can tell they are imitations with a successful DC 10 Wisdom (Insight) check.";
                case Feat.MISTY_ESCAPE:
                    return "When it drops to 0 hit points outside its resting place, the vampire transforms into a cloud of mist (as in the Shapechanger trait) instead of falling unconscious, provided that it isn't in sunlight or running water. If it can't transform, it is destroyed.\nWhile it has 0 hit points in mist form, it can't revert to its vampire form, and it must reach its resting place within 2 hours or be destroyed. Once in its resting place, it reverts to its vampire form. It is then paralyzed until it regains at least 1 hit point. After spending 1 hour in its resting place with 0 hit points, it regains 1 hit point.";
                case Feat.MUCOUS_CLOUD:
                    return "While underwater, it is surrounded by transformative mucus. A creature that touches it or that hits it with a melee attack while within 5 ft. of it must make a DC 14 Constitution saving throw. On a failure, the creature is diseased for 1d4 hours. The diseased creature can breathe only underwater.";
                case Feat.MULTIPLE_HEADS:
                    return "The hydra has five heads. While it has more than one head, the hydra has advantage on saving throws against being blinded, charmed, deafened, frightened, stunned, and knocked unconscious.\nWhenever the hydra takes 25 or more damage in a single turn, one of its heads dies. If all its heads die, the hydra dies.\nAt the end of its turn, it grows two heads for each of its heads that died since its last turn, unless it has taken fire damage since its last turn. The hydra regains 10 hit points for each head regrown in this way.";
                case Feat.NIGHT_HAG_ITEMS:
                    return "A night hag carries two very rare magic items that she must craft for herself If either object is lost, the night hag will go to great lengths to retrieve it, as creating a new tool takes time and effort.\nHeartstone: This lustrous black gem allows a night hag to become ethereal while it is in her possession. The touch of a heartstone also cures any disease. Crafting a heartstone takes 30 days.\nSoul Bag: When an evil humanoid dies as a result of a night hag's Nightmare Haunting, the hag catches the soul in this black sack made of stitched flesh. A soul bag can hold only one evil soul at a time, and only the night hag who crafted the bag can catch a soul with it. Crafting a soul bag takes 7 days and a humanoid sacrifice (whose flesh is used to make the bag).";
                case Feat.NIMBLE_ESCAPE:
                    return "Can take the Disengage or Hide action as a bonus action on each of its turns.";
                case Feat.OOZE_CUBE:
                    return "The cube takes up its entire space. Other creatures can enter the space, but a creature that does so is subjected to the cube's Engulf and has disadvantage on the saving throw.\nCreatures inside the cube can be seen but have total cover.\nA creature within 5 feet of the cube can take an action to pull a creature or object out of the cube. Doing so requires a successful DC 12 Strength check, and the creature making the attempt takes 10 (3d6) acid damage.\nThe cube can hold only one Large creature or up to four Medium or smaller creatures inside it at a time.";
                case Feat.PACK_TACTICS:
                    return "Hhs advantage on an attack roll against a creature if at least one of its allies is within 5 ft. of the creature and the ally isn't incapacitated.";
                case Feat.PETRIFYING_GAZE_BASILISK:
                    return "If a creature starts its turn within 30 ft. of the basilisk and the two of them can see each other, the basilisk can force the creature to make a DC 12 Constitution saving throw if the basilisk isn't incapacitated. On a failed save, the creature magically begins to turn to stone and is restrained. It must repeat the saving throw at the end of its next turn. On a success, the effect ends. On a failure, the creature is petrified until freed by the greater restoration spell or other magic.\nA creature that isn't surprised can avert its eyes to avoid the saving throw at the start of its turn. If it does so, it can't see the basilisk until the start of its next turn, when it can avert its eyes again. If it looks at the basilisk in the meantime, it must immediately make the save.\nIf the basilisk sees its reflection within 30 ft. of it in bright light, it mistakes itself for a rival and targets itself with its gaze.";
                case Feat.PETRIFYING_GAZE_MEDUSA:
                    return "When a creature that can see the medusa's eyes starts its turn within 30 ft. of the medusa, the medusa can force it to make a DC 14 Constitution saving throw if the medusa isn't incapacitated and can see the creature. If the saving throw fails by 5 or more, the creature is instantly petrified. Otherwise, a creature that fails the save begins to turn to stone and is restrained. The restrained creature must repeat the saving throw at the end of its next turn, becoming petrified on a failure or ending the effect on a success. The petrification lasts until the creature is freed by the greater restoration spell or other magic.\nUnless surprised, a creature can avert its eyes to avoid the saving throw at the start of its turn. If the creature does so, it can't see the medusa until the start of its next turn, when it can avert its eyes again. If the creature looks at the medusa in the meantime, it must immediately make the save.\nIf the medusa sees itself reflected on a polished surface within 30 ft. of it and in an area of bright light, the medusa is, due to its curse, affected by its own gaze.";
                case Feat.POUNCE_LION:
                    return "If the lion moves at least 20 ft. straight toward a creature and then hits it with a claw attack on the same turn, that target must succeed on a DC 13 Strength saving throw or be knocked prone. If the target is prone, the lion can make one bite attack against it as a bonus action.";
                case Feat.POUNCE_PANTHER:
                    return "If the panther moves at least 20 ft. straight toward a creature and then hits it with a claw attack on the same turn, that target must succeed on a DC 12 Strength saving throw or be knocked prone. If the target is prone, the panther can make one bite attack against it as a bonus action.";
                case Feat.POUNCE_TIGER_13:
                    return "If the tiger moves at least 20 ft. straight toward a creature and then hits it with a claw attack on the same turn, that target must succeed on a DC 13 Strength saving throw or be knocked prone. If the target is prone, the tiger can make one bite attack against it as a bonus action.";
                case Feat.POUNCE_TIGER_14:
                    return "If the tiger moves at least 20 ft. straight toward a creature and then hits it with a claw attack on the same turn, that target must succeed on a DC 14 Strength saving throw or be knocked prone. If the target is prone, the tiger can make one bite attack against it as a bonus action.";
                case Feat.POUNCE_WERETIGER:
                    return "If the weretiger moves at least 15 feet straight toward a creature and then hits it with a claw attack on the same turn, that target must succeed on a DC 14 Strength saving throw or be knocked prone. If the target is prone, the weretiger can make one bite attack against it as a bonus action.";
                case Feat.PROBING_TELEPATHY:
                    return "If a creature communicates telepathically with it, it learns the creature's greatest desires if it can see the creature.";
                case Feat.RAMPAGE:
                    return "When it reduces a creature to 0 hit points with a melee attack on its turn, it can take a bonus action to move up to half its speed and make a bite attack.";
                case Feat.REACTIVE:
                    return "Can take one reaction on every turn in combat.";
                case Feat.REACTIVE_HEADS:
                    return "For each head it has beyond one, it gets an extra reaction that can be used only for opportunity attacks.";
                case Feat.RECKLESS:
                    return "At the start of its turn, can gain advantage on all melee weapon attack rolls during that turn, but attack rolls against it have advantage until the start of its next turn.";
                case Feat.REFLECTIVE_CARAPACE:
                    return "Any time the tarrasque is targeted by a magic missile spell, a line spell, or a spell that requires a ranged attack roll, roll a d6. On a 1 to 5, the tarrasque is unaffected. On a 6, the tarrasque is unaffected, and the effect is reflected back at the caster as though it originated from the tarrasque, turning the caster into the target.";
                case Feat.REGENERATION:
                    return "Regains 10 hit points at the start of its turn if it has at least 1 hit point.";
                case Feat.REGENERATION_TROLL:
                    return "The troll regains 10 hit points at the start of its turn. If the troll takes acid or fire damage, this trait doesn't function at the start of the troll's next turn. The troll dies only if it starts its turn with 0 hit points and doesn't regenerate.";
                case Feat.REGENERATION_VAMPIRE:
                    return "The vampire regains 20 hit points at the start of its turn if it has at least 1 hit point and isn't in sunlight or running water. If the vampire takes radiant damage or damage from holy water, this trait doesn't function at the start of the vampire's next turn.";
                case Feat.REGENERATION_VAMPIRE_SPAWN:
                    return "The vampire regains 10 hit points at the start of its turn if it has at least 1 hit point and isn't in sunlight or running water. If the vampire takes radiant damage or damage from holy water, this trait doesn't function at the start of the vampire's next turn.";
                case Feat.REJUVENATION_LICH:
                    return "If it has a phylactery, a destroyed lich gains a new body in 1d10 days, regaining all its hit points and becoming active again. The new body appears within 5 feet of the phylactery.";
                case Feat.REJUVENATION_MUMMY_LORD:
                    return "A destroyed mummy lord gains a new body in 24 hours if its heart is intact, regaining all its hit points and becoming active again. The new body appears within 5 feet of the mummy lord's heart.";
                case Feat.REJUVENATION_NAGA:
                    return "If it dies, the naga returns to life in 1d6 days and regains all its hit points. Only a wish spell can prevent this trait from functioning.";
                case Feat.RELENTLESS_7:
                    return "If it takes 7 damage or less that would reduce it to 0 hit points, it is reduced to 1 hit point instead.";
                case Feat.RELENTLESS_10:
                    return "If it takes 10 damage or less that would reduce it to 0 hit points, it is reduced to 1 hit point instead.";
                case Feat.RELENTLESS_14:
                    return "If it takes 14 damage or less that would reduce it to 0 hit points, it is reduced to 1 hit point instead.";
                case Feat.RUNNING_LEAP:
                    return "With a 10-foot running start, the lion can long jump up to 25 ft..";
                case Feat.RUST_METAL:
                    return "Any nonmagical weapon made of metal that hits it corrodes. After dealing damage, the weapon takes a permanent and cumulative -1 penalty to damage rolls. If its penalty drops to -5, the weapon is destroyed. Non magical ammunition made of metal that hits the rust monster is destroyed after dealing damage.";
                case Feat.SENSE_MAGIC:
                    return "Senses magic within 120 feet of it at will. This trait otherwise works like the detect magic spell but isn't itself magical.";
                case Feat.SHADOW_STEALTH:
                    return "While in dim light or darkness, the shadow can take the Hide action as a bonus action. Its stealth bonus is also improved to +6.";
                case Feat.SHAPECHANGER_DOPPELGANGER:
                    return "The doppelganger can use its action to polymorph into a Small or Medium humanoid it has seen, or back into its true form. Its statistics, other than its size, are the same in each form. Any equipment it is wearing or carrying isn't transformed. It reverts to its true form if it dies.";
                case Feat.SHAPECHANGER_FIEND:
                    return "The fiend can use its action to polymorph into a Small or Medium humanoid, or back into its true form. Without wings, the fiend loses its flying speed. Other than its size and speed, its statistics are the same in each form. Any equipment it is wearing or carrying isn't transformed. It reverts to its true form if it dies.";
                case Feat.SHAPECHANGER_IMP:
                    return "The imp can use its action to polymorph into a beast form that resembles a rat (speed 20 ft.), a raven (20 ft., fly 60 ft.), or a spider (20 ft., climb 20 ft.), or back into its true form. Its statistics are the same in each form, except for the speed changes noted. Any equipment it is wearing or carrying isn't transformed. It reverts to its true form if it dies.";
                case Feat.SHAPECHANGER_MIMIC:
                    return "The mimic can use its action to polymorph into an object or back into its true, amorphous form. Its statistics are the same in each form. Any equipment it is wearing or carrying isn 't transformed. It reverts to its true form if it dies.";
                case Feat.SHAPECHANGER_QUASIT:
                    return "The quasit can use its action to polymorph into a beast form that resembles a bat (speed 10 ft. fly 40 ft.), a centipede (40 ft., climb 40 ft.), or a toad (40 ft., swim 40 ft.), or back into its true form . Its statistics are the same in each form, except for the speed changes noted. Any equipment it is wearing or carrying isn't transformed . It reverts to its true form if it dies.";
                case Feat.SHAPECHANGER_VAMPIRE:
                    return "If the vampire isn't in sun light or running water, it can use its action to polymorph into a Tiny bat or a Medium cloud of mist, or back into its true form.\nWhile in bat form, the vampire can't speak, its walking speed is 5 feet, and it has a flying speed of 30 feet. Its statistics, other than its size and speed, are unchanged. Anything it is wearing transforms with it, but nothing it is carrying does. It reverts to its true form if it dies.\nWhile in mist form, the vampire can't take any actions, speak, or manipulate objects. It is weightless, has a flying speed of 20 feet, can hover, and can enter a hostile creature's space and stop there. In addition, if air can pass through a space, the mist can do so without squeezing, and it can't pass through water. It has advantage on Strength, Dexterity, and Constitution saving throws, and it is immune to all nonmagical damage, except the damage it takes from sunlight.";
                case Feat.SHAPECHANGER_WEREBEAST:
                    return "The werebeast can use its action to polymorph into a beast-humanoid hybrid or into a beast, or back into its true form, which is humanoid. Its statistics, other than its AC, are the same in each form. Any equipment it is wearing or carrying isn't transformed. It reverts to its true form if it dies.";
                case Feat.SHARK_TELEPATHY:
                    return "Can magically command any shark within 120 feet of it, using a limited telepathy.";
                case Feat.SHIELDED_MIND:
                    return "Is immune to scrying and to any effect that would sense its emotions, read its thoughts, or detect its location.";
                case Feat.SIEGE_MONSTER:
                    return "Deals double damage to objects and structures.";
                case Feat.SNEAK_ATTACK_2D6:
                    return "Deals an extra 7 (2d6) damage when it hits a target with a weapon attack and has advantage on the attack roll, or when the target is within 5 ft. of an ally that isn't incapacitated and it doesn't have disadvantage on the attack roll.";
                case Feat.SNEAK_ATTACK_4D6:
                    return "Deals an extra 13 (4d6) damage when it hits a target with a weapon attack and has advantage on the attack roll, or when the target is within 5 ft. of an ally that isn't incapacitated and it doesn't have disadvantage on the attack roll.";
                case Feat.SNOW_CAMOUFLAGE:
                    return "Has advantage on Dexterity (Stealth) checks made to hide in snowy terrain.";
                case Feat.SPEAK_WITH_BEASTS_AND_PLANTS:
                    return "Can communicate with beasts and plants as if they shared a language.";
                case Feat.SPELL_STORING:
                    return "A spellcaster who wears the shield guardian's amulet can cause the guardian to store one spell of 4th level or lower. To do so, the wearer must cast the spell on the guardian. The spell has no effect but is stored within the guardian. When commanded to do so by the wearer or when a situation arises that was predefined by the spellcaster, the guardian casts the stored spell with any parameters set by the original caster, requiring no components. When the spell is cast or a new spell is stored, any previously stored spell is lost.";
                case Feat.SPELLCASTING_ACOLYTE:
                    return "The acolyte is a 1st-level spellcaster. Its spellcasting ability is Wisdom (spell save DC 12, +4 to hit with spell attacks). The acolyte has following cleric spells prepared:\n\n- Cantrips (at will): light, sacred flame, thaumaturgy\n- 1st level (3 slots): bless, cure wounds, sanctuary";
                case Feat.SPELLCASTING_ARCHMAGE:
                    return "The archmage is an 18th-level spellcaster. Its spellcasting ability is Intelligence (spell save DC 17, +9 to hit with spell attacks). The archmage can cast disguise self and invisibility at will and has the following wizard spells prepared:\n\n- Cantrips (at will): fire bolt, light, mage hand, prestidigitation, shocking grasp\n- 1st level (4 slots): detect magic, identify, mage armor*, magic missile\n- 2nd level (3 slots): detect thoughts, mirror image, misty step\n- 3rd level (3 slots): counterspell, fly, lightning bolt\n- 4th level (3 slots): banishment, fire shield, stoneskin*\n- 5th level (3 slots): cone of cold, scrying, wall of force\n- 6th level (1 slot): globe of invulnerability\n- 7th level (1 slot): teleport\n- 8th level (1 slot): mind blank*\n- 9th level (1 slot): time stop\n* The archmage casts these spells on itself before combat.";
                case Feat.SPELLCASTING_DRUID:
                    return "The druid is a 4th-level spellcaster. Its spellcasting ability is Wisdom (spell save DC 12, +4 to hit with spell attacks). It has the following druid spells prepared:\n\n- Cantrips (at will): druidcraft, produce flame, shillelagh\n- 1st level (4 slots): entangle, longstrider, speak with animals, thunderwave\n- 2nd level (3 slots): animal messenger, barkskin";
                case Feat.SPELLCASTING_FANATIC:
                    return "The fanatic is a 4th-level spellcaster. Its spell casting ability is Wisdom (spell save DC 11, +3 to hit with spell attacks). The fanatic has the following cleric spells prepared:\n\nCantrips (at will): light, sacred flame, thaumaturgy\n- 1st level (4 slots): command, inflict wounds, shield of faith\n- 2nd level (3 slots): hold person, spiritual weapon";
                case Feat.SPELLCASTING_LICH:
                    return "The lich is an 18th-level spellcaster. Its spellcasting ability is Intelligence (spell save DC 20, +12 to hit with spell attacks). The lich has the following wizard spells prepared:\n\n- Cantrips (at will): mage hand, prestidigitation, ray of frost\n- 1st level (4 slots): detect magic, magic missile, shield, thunderwave\n- 2nd level (3 slots): acid arrow, detect thoughts, invisibility, mirror image\n- 3rd level (3 slots): animate dead, counterspell, dispel magic, fireball\n- 4th level (3 slots): blight, dimension door\n- 5th level (3 slots): cloudkill, scrying\n- 6th level (1 slot): disintegrate, globe of invulnerability\n- 7th level (1 slot): finger of death, plane shift\n- 8th level (1 slot): dominate monster, power word stun\n- 9th level (1 slot): power word kill";
                case Feat.SPELLCASTING_MAGE:
                    return "The mage is a 9th-level spellcaster. Its spellcasting ability is Intelligence (spell save DC 14, +6 to hit with spell attacks). The mage has the following wizard spells prepared:\n\n- Cantrips (at will): fire bolt, light, mage hand, prestidigitation\n- 1st level (4 slots): detect magic, mage armor, magic missile, shield\n- 2nd level (3 slots): misty step, suggestion\n- 3rd level (3 slots): counterspell, fireball, fly\n- 4th level (3 slots): greater invisibility, ice storm\n- 5th level (1 slot): cone of cold";
                case Feat.SPELLCASTING_MUMMY_LORD:
                    return "The mummy lord is a 10th-level spellcaster. Its spellcasting ability is Wisdom (spell save DC 17, +9 to hit with spell attacks). The mummy lord has the following cleric spells prepared:\n\n- Cantrips (at will): sacred flame, thaumaturgy\n- 1st level (4 slots): command, guiding bolt, shield of faith\n- 2nd level (3 slots): hold person, silence, spiritual weapon\n- 3rd level (3 slots): animate dead, dispel magic\n- 4th level (3 slots): divination, guardian of faith\n- 5th level (2 slots): contagion, insect plague\n- 6th level (1 slot): harm";
                case Feat.SPELLCASTING_NAGA_10:
                    return "The naga is a 10th-level spellcaster. Its spellcasting ability is Intelligence (spell save DC 14, +6 to hit with spell attacks), and it needs only verbal components to cast its spells. It has the following wizard spells prepared:\n\n- Cantrips (at will): mage hand, minor illusion, ray of frost\n- 1st level (4 slots): charm person, detect magic, sleep\n- 2nd level (3 slots): detect thoughts, hold person\n- 3rd level (3 slots): lightning bolt, water breathing\n- 4th level (3 slots): blight, dimension door\n- 5th level (2 slots): dominate person";
                case Feat.SPELLCASTING_NAGA_11:
                    return "The naga is an 11th-level spellcaster. Its spellcasting ability is Wisdom (spell save DC 16, +8 to hit with spell attacks), and it needs only verbal components to cast its spells. It has the following cleric spells prepared:\n\n- Cantrips (at will): mending, sacred flame, thaumaturgy\n- 1st level (4 slots): command, cure wounds, shield of faith\n- 2nd level (3 slots): calm emotions, hold person\n- 3rd level (3 slots): bestow curse, clairvoyance\n- 4th level (3 slots): banishment, freedom of movement\n- 5th level (2 slots): flame strike, geas\n- 6th level (1 slot): true seeing";
                case Feat.SPELLCASTING_GYNOSPHINX:
                    return "The sphinx is a 9th-level spellcaster. Its spellcasting ability is Intelligence (spell save DC 16, +8 to hit with spell attacks). It requires no material components to cast its spells. The sphinx has the following wizard spells prepared:\n\n- Cantrips (at will): mage hand, minor illusion, prestidigitation\n- 1st level (4 slots): detect magic, identify, shield\n- 2nd level (3 slots): darkness, locate object, suggestion\n- 3rd level (3 slots): dispel magic, remove curse, tongues\n- 4th level (3 slots): banishment, greater invisibility\n- 5th level (1 slot): legend lore";
                case Feat.SPELLCASTING_ANDROSPHINX:
                    return "The sphinx is a 12th-level spellcaster. Its spellcasting ability is Wisdom (spell save DC 18, +10 to hit with spell attacks). It requires no material components to cast its spells. The sphinx has the following cleric spells prepared:\n\n- Cantrips (at will): sacred flame, spare the dying, thaumaturgy\n- 1st level (4 slots): command, detect evil and good, detect magic\n- 2nd level (3 slots): lesser restoration, zone of truth\n- 3rd level (3 slots): dispel magic, tongues\n- 4th level (3 slots): banishment, freedom of movement\n- 5th level (2 slots): flame strike, greater restoration\n- 6th level (1 slot): heroes' feast";
                case Feat.SPIDER_CLIMB:
                    return "Can climb difficult surfaces, including upside down on ceilings, without needing to make an ability check.";
                case Feat.STANDING_LEAP_BULETTE:
                    return "The bulette's long jump is up to 30 ft. and its high jump is up to 15 ft., with or without a running start.";
                case Feat.STANDING_LEAP_FROG_10FT:
                    return "The frog's long jump is up to 10 ft. and its high jump is up to 5 ft., with or without a running start.";
                case Feat.STANDING_LEAP_FROG_20FT:
                    return "The frog's long jump is up to 20 ft. and its high jump is up to 10 ft., with or without a running start.";
                case Feat.STANDING_LEAP_TOAD:
                    return "The toad's long jump is up to 20 ft. and its high jump is up to 10 ft., with or without a running start.";
                case Feat.STEADFAST:
                    return "The devil can't be frightened while it can see an allied creature within 30 feet of it.";
                case Feat.STENCH_GHAST:
                    return "Any creature that starts its turn within 5 ft. of the ghast must succeed on a DC 10 Constitution saving throw or be poisoned until the start of its next turn. On a successful saving throw, the creature is immune to the ghast's Stench for 24 hours.";
                case Feat.STENCH_HEZROU:
                    return "Any creature that starts its turn within 10 feet of the hezrou must succeed on a DC 14 Constitution saving throw or be poisoned until the start of its next turn. On a successful saving throw, the creature is immune to the hezrou's stench for 24 hours.";
                case Feat.STONE_CAMOUFLAGE:
                    return "Has advantage on Dexterity (Stealth) checks made to hide in rocky terrain.";
                case Feat.SUNLIGHT_SENSITIVITY:
                    return "While in sunlight, has disadvantage on attack rolls, as well as on Wisdom (Perception) checks that rely on sight.";
                case Feat.SUNLIGHT_WEAKNESS:
                    return "While in sunlight, has disadvantage on attack rolls, ability checks, and saving throws.";
                case Feat.SURE_FOOTED:
                    return "Has advantage on Strength and Dexterity saving throws made against effects that would knock it prone.";
                case Feat.SURPRISE_ATTACK_BUGBEAR:
                    return "If the bugbear surprises a creature and hits it with an attack during the first round of combat, the target takes an extra 7 (2d6) damage from the attack.";
                case Feat.SURPRISE_ATTACK_DOPPELGANGER:
                    return "If the doppelganger surprises a creature and hits it with an attack during the first round of combat, the target takes an extra 10 (3d6) damage from the attack.";
                case Feat.SWARM:
                    return "The swarm can occupy another creature's space and vice versa, and the swarm can move through any opening large enough for a Tiny bat. The swarm can't regain hit points or gain temporary hit points.";
                case Feat.TAIL_SPIKE_REGROWTH:
                    return "The manticore has twenty-four tail spikes. Used spikes regrow when the manticore finishes a long rest.";
                case Feat.TELEPATHIC_BOND_HOMUNCULUS:
                    return "While the homunculus is on the same plane of existence as its master, it can magically convey what it senses to its master, and the two can communicate telepathically.";
                case Feat.TELEPATHIC_BOND_FIEND:
                    return "The fiend ignores the range restriction on its telepathy when communicating with a creature it has charmed. The two don't even need to be on the same plane of existence.";
                case Feat.TRAMPLING_CHARGE_ELEPHANT:
                    return "If the elephant moves at least 20 ft. straight toward a creature and then hits it with a gore attack on the same turn, that target must succeed on a DC 12 Strength saving throw or be knocked prone. If the target is prone, the elephant can make one stomp attack against it as a bonus action.";
                case Feat.TRAMPLING_CHARGE_GORGON:
                    return "If the gorgon moves at least 20 feet straight toward a creature and then hits it with a gore attack on the same turn, that target must succeed on a DC 16 Strength saving throw or be knocked prone. If the target is prone, the gorgon can make one attack with its hooves against it as a bonus action.";
                case Feat.TRAMPLING_CHARGE_HORSE:
                    return "If the horse moves at least 20 ft. straight toward a creature and then hits it with a hooves attack on the same turn, that target must succeed on a DC 14 Strength saving throw or be knocked prone. If the target is prone, the horse can make another attack with its hooves against it as a bonus action.";
                case Feat.TRAMPLING_CHARGE_MAMMOTH:
                    return "If the mammoth moves at least 20 ft. straight toward a creature and then hits it with a gore attack on the same turn, that target must succeed on a DC 18 Strength saving throw or be knocked prone. If the target is prone, the mammoth can make one stomp attack against it as a bonus action.";
                case Feat.TRAMPLING_CHARGE_TRICERATOS:
                    return "If the triceratops moves at least 20 ft. straight toward a creature and then hits it with a gore attack on the same turn, that target must succeed on a DC 13 Strength saving throw or be knocked prone. If the target is prone, the triceratops can make one stomp attack against it as a bonus action.";
                case Feat.TRANSPARENT:
                    return "Even when in plain sight, it takes a successful DC 15 Wisdom (Perception) check to spot a cube that has neither moved nor attacked. A creature that tries to enter its space while unaware is surprised.";
                case Feat.TREASURE_SENSE:
                    return "Can pinpoint, by scent, the location of precious metals and stones, such as coins and gems, within 60 ft. of it.";
                case Feat.TREE_STRIDE:
                    return "Once on her turn, it can use 10 ft. of her movement to step magically into one living tree within her reach and emerge from a second living tree within 60 ft. of the first tree, appearing in an unoccupied space within 5 ft. of the second tree. Both trees must be large or bigger.";
                case Feat.TUNNELER:
                    return "Can burrow through solid rock at half its burrow speed and leaves a 10-foot-diameter tunnel in its wake.";
                case Feat.TURN_DEFIANCE:
                    return "Itself and any ghouls within 30 ft. of it have advantage on saving throws against effects that turn undead.";
                case Feat.TURN_RESISTANCE:
                    return "Has advantage on saving throws against any effect that turns undead.";
                case Feat.TWO_HEADED:
                    return "Has advantage on Wisdom (Perception) checks and on saving throws against being blinded, charmed, deafened, frightened, stunned, or knocked unconscious.";
                case Feat.UNDEAD_FORTITUDE:
                    return "If damage reduces the undead to 0 hit points, it must make a Constitution saving throw with a DC of 5+the damage taken, unless the damage is radiant or from a critical hit. On a success, the undead drops to 1 hit point instead.";
                case Feat.UNDERWATER_CAMOUFLAGE:
                    return "Has advantage on Dexterity (Stealth) checks made while underwater.";
                case Feat.VAMPIRE_WEAKNESSES:
                    return "The vampire has the following flaws:\nForbiddance. The vampire can't enter a residence without an invitation from one of the occupants.\nHarmed by Running Water. The vampire takes 20 acid damage if it ends its turn in running water.\nStake to the Heart. If a piercing weapon made of wood is driven into the vampire's heart while the vampire is incapacitated in its resting place, the vampire is paralyzed until the stake is removed.\nSunlight Hypersensitivity. The vampire takes 20 radiant damage when it starts its turn in sunlight. While in sunlight, it has disadvantage on attack rolls and ability checks.";
                case Feat.VARIABLE_ILLUMINATION:
                    return "Sheds bright light in a 5- to 20-foot radius and dim light for an additional number of ft. equal to the chosen radius. Can alter the radius as a bonus action.";
                case Feat.WAKEFUL:
                    return "At least one head is always awake.";
                case Feat.WATER_BREATHING:
                    return "Can breathe only underwater.";
                case Feat.WATER_FORM:
                    return "Can enter a hostile creature's space and stop there. It can move through a space as narrow as 1 inch wide without squeezing.";
                case Feat.WATER_SUSCEPTIBILITY:
                    return "For every 5 ft. it moves in water, or for every gallon of water splashed on it, it takes 1 cold damage.";
                case Feat.WEB_SENSE:
                    return "While in contact with a web, knows the exact location of any other creature in contact with the same web.";
                case Feat.WEB_WALKER:
                    return "Ignores movement restrictions caused by webbing.";
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
                case Spells.ID.ACID_ARROW:
                    return "Acid Arrow";
                case Spells.ID.ACID_SPLASH:
                    return "Acid Splash";
                case Spells.ID.AID:
                    return "Aid";
                case Spells.ID.ALARM:
                    return "Alarm";
                case Spells.ID.ALTER_SELF:
                    return "Alter Self";
                case Spells.ID.ANIMAL_FRIENDSHIP:
                    return "Animal Friendship";
                case Spells.ID.ANIMAL_MESSENGER:
                    return "Animal Messenger";
                case Spells.ID.ANIMAL_SHAPES:
                    return "Animal Shapes";
                case Spells.ID.ANIMATE_DEAD:
                    return "Animate Dead";
                case Spells.ID.ANIMATE_OBJECTS:
                    return "Animate Objects";
                case Spells.ID.ANTILIFE_SHELL:
                    return "Antilife Shell";
                case Spells.ID.ANTIMAGIC_FIELD:
                    return "Antimagic Field";
                case Spells.ID.ANTIPATHY_SYMPATHY:
                    return "Antipathy/Sympathy";
                case Spells.ID.ARCANE_EYE:
                    return "Arcane Eye";
                case Spells.ID.ARCANE_HAND:
                    return "Arcane Hand";
                case Spells.ID.ARCANE_LOCK:
                    return "Arcane Lock";
                case Spells.ID.ARCANE_SWORD:
                    return "Arcane Sword";
                case Spells.ID.ARCANISTS_MAGIC_AURA:
                    return "Arcanist's Magic Aura";
                case Spells.ID.ASTRAL_PROJECTION:
                    return "Astral Projection";
                case Spells.ID.AUGURY:
                    return "Augury";
                case Spells.ID.AWAKEN:
                    return "Awaken";
                case Spells.ID.BANE:
                    return "Bane";
                case Spells.ID.BANISHMENT:
                    return "Banishment";
                case Spells.ID.BARKSKIN:
                    return "Barkskin";
                case Spells.ID.BEACON_OF_HOPE:
                    return "Beacon of Hope";
                case Spells.ID.BESTOW_CURSE:
                    return "Bestow Curse";
                case Spells.ID.BLACK_TENTACLES:
                    return "Black Tentacles";
                case Spells.ID.BLADE_BARRIER:
                    return "Blade Barrier";
                case Spells.ID.BLESS:
                    return "Bless";
                case Spells.ID.BLIGHT:
                    return "Blight";
                case Spells.ID.BLINDNESS_DEAFNESS:
                    return "Blindness/Deafness";
                case Spells.ID.BLINK:
                    return "Blink";
                case Spells.ID.BLUR:
                    return "Blur";
                case Spells.ID.BRANDING_SMITE:
                    return "Branding Smite";
                case Spells.ID.BURNING_HANDS:
                    return "Burning Hands";
                case Spells.ID.CALL_LIGHTNING:
                    return "Call Lightning";
                case Spells.ID.CALM_EMOTIONS:
                    return "Calm Emotions";
                case Spells.ID.CHAIN_LIGHTNING:
                    return "Chain Lightning";
                case Spells.ID.CHARM_PERSON:
                    return "Charm Person";
                case Spells.ID.CHILL_TOUCH:
                    return "Chill Touch";
                case Spells.ID.CIRCLE_OF_DEATH:
                    return "Circle of Death";
                case Spells.ID.CLAIRVOYANCE:
                    return "Clairvoyance";
                case Spells.ID.CLONE:
                    return "Clone";
                case Spells.ID.CLOUDKILL:
                    return "Cloudkill";
                case Spells.ID.COLOR_SPRAY:
                    return "Color Spray";
                case Spells.ID.COMMAND:
                    return "Command";
                case Spells.ID.COMMUNE:
                    return "Commune";
                case Spells.ID.COMMUNE_WITH_NATURE:
                    return "Commune with Nature";
                case Spells.ID.COMPREHEND_LANGUAGES:
                    return "Comprehend Languages";
                case Spells.ID.COMPULSION:
                    return "Compulsion";
                case Spells.ID.CONE_OF_COLD:
                    return "Cone of Cold";
                case Spells.ID.CONFUSION:
                    return "Confusion";
                case Spells.ID.CONJURE_ANIMALS:
                    return "Conjure Animals";
                case Spells.ID.CONJURE_CELESTIAL:
                    return "Conjure Celestial";
                case Spells.ID.CONJURE_ELEMENTAL:
                    return "Conjure Elemental";
                case Spells.ID.CONJURE_FEY:
                    return "Conjure Fey";
                case Spells.ID.CONJURE_MINOR_ELEMENTALS:
                    return "Conjure Minor Elementals";
                case Spells.ID.CONJURE_WOODLAND_BEINGS:
                    return "Conjure Woodland Beings";
                case Spells.ID.CONTACT_OTHER_PLANE:
                    return "Contact Other Plane";
                case Spells.ID.CONTAGION:
                    return "Contagion";
                case Spells.ID.CONTINGENCY:
                    return "Contingency";
                case Spells.ID.CONTINUAL_FLAME:
                    return "Continual Flame";
                case Spells.ID.CONTROL_WATER:
                    return "Control Water";
                case Spells.ID.CONTROL_WEATHER:
                    return "Control Weather";
                case Spells.ID.COUNTERSPELL:
                    return "Counterspell";
                case Spells.ID.CREATE_FOOD_AND_WATER:
                    return "Create Food and Water";
                case Spells.ID.CREATE_UNDEAD:
                    return "Create Undead";
                case Spells.ID.CREATE_OR_DESTROY_WATER:
                    return "Create or Destroy Water";
                case Spells.ID.CREATION:
                    return "Creation";
                case Spells.ID.CURE_WOUNDS:
                    return "Cure Wounds";
                case Spells.ID.DANCING_LIGHTS:
                    return "Dancing Lights";
                case Spells.ID.DARKNESS:
                    return "Darkness";
                case Spells.ID.DARKVISION:
                    return "Darkvision";
                case Spells.ID.DAYLIGHT:
                    return "Daylight";
                case Spells.ID.DEATH_WARD:
                    return "Death Ward";
                case Spells.ID.DELAYED_BLAST_FIREBALL:
                    return "Delayed Blast Fireball";
                case Spells.ID.DEMIPLANE:
                    return "Demiplane";
                case Spells.ID.DETECT_EVIL_AND_GOOD:
                    return "Detect Evil and Good";
                case Spells.ID.DETECT_MAGIC:
                    return "Detect Magic";
                case Spells.ID.DETECT_POISON_AND_DISEASE:
                    return "Detect Poison and Disease";
                case Spells.ID.DETECT_THOUGHTS:
                    return "Detect Thoughts";
                case Spells.ID.DIMENSION_DOOR:
                    return "Dimension Door";
                case Spells.ID.DISGUISE_SELF:
                    return "Disguise Self";
                case Spells.ID.DISINTEGRATE:
                    return "Disintegrate";
                case Spells.ID.DISPEL_EVIL_AND_GOOD:
                    return "Dispel Evil and Good";
                case Spells.ID.DISPEL_MAGIC:
                    return "Dispel Magic";
                case Spells.ID.DIVINATION:
                    return "Divination";
                case Spells.ID.DIVINE_FAVOR:
                    return "Divine Favor";
                case Spells.ID.DIVINE_WORD:
                    return "Divine Word";
                case Spells.ID.DOMINATE_BEAST:
                    return "Dominate Beast";
                case Spells.ID.DOMINATE_MONSTER:
                    return "Dominate Monster";
                case Spells.ID.DOMINATE_PERSON:
                    return "Dominate Person";
                case Spells.ID.DREAM:
                    return "Dream";
                case Spells.ID.DRUIDCRAFT:
                    return "Druidcraft";
                case Spells.ID.EARTHQUAKE:
                    return "Earthquake";
                case Spells.ID.ELDRITCH_BLAST:
                    return "Eldritch Blast";
                case Spells.ID.ENHANCE_ABILITY:
                    return "Enhance Ability";
                case Spells.ID.ENLARGE_REDUCE:
                    return "Enlarge/Reduce";
                case Spells.ID.ENTANGLE:
                    return "Entangle";
                case Spells.ID.ENTHRALL:
                    return "Enthrall";
                case Spells.ID.ETHEREALNESS:
                    return "Etherealness";
                case Spells.ID.EXPEDITIOUS_RETREAT:
                    return "Expeditious Retreat";
                case Spells.ID.EYEBITE:
                    return "Eyebite";
                case Spells.ID.FABRICATE:
                    return "Fabricate";
                case Spells.ID.FAERIE_FIRE:
                    return "Faerie Fire";
                case Spells.ID.FAITHFUL_HOUND:
                    return "Faithful Hound";
                case Spells.ID.FALSE_LIFE:
                    return "False Life";
                case Spells.ID.FEAR:
                    return "Fear";
                case Spells.ID.FEATHER_FALL:
                    return "Feather Fall";
                case Spells.ID.FEEBLEMIND:
                    return "Feeblemind";
                case Spells.ID.FIND_FAMILIAR:
                    return "Find Familiar";
                case Spells.ID.FIND_STEED:
                    return "Find Steed";
                case Spells.ID.FIND_TRAPS:
                    return "Find Traps";
                case Spells.ID.FIND_THE_PATH:
                    return "Find the Path";
                case Spells.ID.FINGER_OF_DEATH:
                    return "Finger of Death";
                case Spells.ID.FIRE_BOLT:
                    return "Fire Bolt";
                case Spells.ID.FIRE_SHIELD:
                    return "Fire Shield";
                case Spells.ID.FIRE_STORM:
                    return "Fire Storm";
                case Spells.ID.FIREBALL:
                    return "Fireball";
                case Spells.ID.FLAME_BLADE:
                    return "Flame Blade";
                case Spells.ID.FLAME_STRIKE:
                    return "Flame Strike";
                case Spells.ID.FLAMING_SPHERE:
                    return "Flaming Sphere";
                case Spells.ID.FLESH_TO_STONE:
                    return "Flesh to Stone";
                case Spells.ID.FLOATING_DISK:
                    return "Floating Disk";
                case Spells.ID.FLY:
                    return "Fly";
                case Spells.ID.FOG_CLOUD:
                    return "Fog Cloud";
                case Spells.ID.FORBIDDANCE:
                    return "Forbiddance";
                case Spells.ID.FORCECAGE:
                    return "Forcecage";
                case Spells.ID.FORESIGHT:
                    return "Foresight";
                case Spells.ID.FREEDOM_OF_MOVEMENT:
                    return "Freedom of Movement";
                case Spells.ID.FREEZING_SPHERE:
                    return "Freezing Sphere";
                case Spells.ID.GASEOUS_FORM:
                    return "Gaseous Form";
                case Spells.ID.GATE:
                    return "Gate";
                case Spells.ID.GEAS:
                    return "Geas";
                case Spells.ID.GENTLE_REPOSE:
                    return "Gentle Repose";
                case Spells.ID.GIANT_INSECT:
                    return "Giant Insect";
                case Spells.ID.GLIBNESS:
                    return "Glibness";
                case Spells.ID.GLOBE_OF_INVULNERABILITY:
                    return "Globe of Invulnerability";
                case Spells.ID.GLYPH_OF_WARDING:
                    return "Glyph of Warding";
                case Spells.ID.GOODBERRY:
                    return "Goodberry";
                case Spells.ID.GREASE:
                    return "Grease";
                case Spells.ID.GREATER_INVISIBILITY:
                    return "Greater Invisibility";
                case Spells.ID.GREATER_RESTORATION:
                    return "Greater Restoration";
                case Spells.ID.GUARDIAN_OF_FAITH:
                    return "Guardian of Faith";
                case Spells.ID.GUARDS_AND_WARDS:
                    return "Guards and Wards";
                case Spells.ID.GUIDANCE:
                    return "Guidance";
                case Spells.ID.GUIDING_BOLT:
                    return "Guiding Bolt";
                case Spells.ID.GUST_OF_WIND:
                    return "Gust of Wind";
                case Spells.ID.HALLOW:
                    return "Hallow";
                case Spells.ID.HALLUCINATORY_TERRAIN:
                    return "Hallucinatory Terrain";
                case Spells.ID.HARM:
                    return "Harm";
                case Spells.ID.HASTE:
                    return "Haste";
                case Spells.ID.HEAL:
                    return "Heal";
                case Spells.ID.HEALING_WORD:
                    return "Healing Word";
                case Spells.ID.HEAT_METAL:
                    return "Heat Metal";
                case Spells.ID.HELLISH_REBUKE:
                    return "Hellish Rebuke";
                case Spells.ID.HEROES_FEAST:
                    return "Heroes' Feast";
                case Spells.ID.HEROISM:
                    return "Heroism";
                case Spells.ID.HIDEOUS_LAUGHTER:
                    return "Hideous Laughter";
                case Spells.ID.HOLD_MONSTER:
                    return "Hold Monster";
                case Spells.ID.HOLD_PERSON:
                    return "Hold Person";
                case Spells.ID.HOLY_AURA:
                    return "Holy Aura";
                case Spells.ID.HUNTERS_MARK:
                    return "Hunter's Mark";
                case Spells.ID.HYPNOTIC_PATTERN:
                    return "Hypnotic Pattern";
                case Spells.ID.ICE_STORM:
                    return "Ice Storm";
                case Spells.ID.IDENTIFY:
                    return "Identify";
                case Spells.ID.ILLUSORY_SCRIPT:
                    return "Illusory Script";
                case Spells.ID.IMPRISONMENT:
                    return "Imprisonment";
                case Spells.ID.INCENDIARY_CLOUD:
                    return "Incendiary Cloud";
                case Spells.ID.INFLICT_WOUNDS:
                    return "Inflict Wounds";
                case Spells.ID.INSECT_PLAGUE:
                    return "Insect Plague";
                case Spells.ID.INSTANT_SUMMONS:
                    return "Instant Summons";
                case Spells.ID.INVISIBILITY:
                    return "Invisibility";
                case Spells.ID.IRRESISTIBLE_DANCE:
                    return "Irresistible Dance";
                case Spells.ID.JUMP:
                    return "Jump";
                case Spells.ID.KNOCK:
                    return "Knock";
                case Spells.ID.LEGEND_LORE:
                    return "Legend Lore";
                case Spells.ID.LESSER_RESTORATION:
                    return "Lesser Restoration";
                case Spells.ID.LEVITATE:
                    return "Levitate";
                case Spells.ID.LIGHT:
                    return "Light";
                case Spells.ID.LIGHTNING_BOLT:
                    return "Lightning Bolt";
                case Spells.ID.LOCATE_ANIMALS_OR_PLANTS:
                    return "Locate Animals or Plants";
                case Spells.ID.LOCATE_CREATURE:
                    return "Locate Creature";
                case Spells.ID.LOCATE_OBJECT:
                    return "Locate Object";
                case Spells.ID.LONGSTRIDER:
                    return "Longstrider";
                case Spells.ID.MAGE_ARMOR:
                    return "Mage Armor";
                case Spells.ID.MAGE_HAND:
                    return "Mage Hand";
                case Spells.ID.MAGIC_CIRCLE:
                    return "Magic Circle";
                case Spells.ID.MAGIC_JAR:
                    return "Magic Jar";
                case Spells.ID.MAGIC_MISSILE:
                    return "Magic Missile";
                case Spells.ID.MAGIC_MOUTH:
                    return "Magic Mouth";
                case Spells.ID.MAGIC_WEAPON:
                    return "Magic Weapon";
                case Spells.ID.MAGNIFICENT_MANSION:
                    return "Magnificent Mansion";
                case Spells.ID.MAJOR_IMAGE:
                    return "Major Image";
                case Spells.ID.MASS_CURE_WOUNDS:
                    return "Mass Cure Wounds";
                case Spells.ID.MASS_HEAL:
                    return "Mass Heal";
                case Spells.ID.MASS_HEALING_WORD:
                    return "Mass Healing Word";
                case Spells.ID.MASS_SUGGESTION:
                    return "Mass Suggestion";
                case Spells.ID.MAZE:
                    return "Maze";
                case Spells.ID.MELD_INTO_STONE:
                    return "Meld into Stone";
                case Spells.ID.MENDING:
                    return "Mending";
                case Spells.ID.MESSAGE:
                    return "Message";
                case Spells.ID.METEOR_SWARM:
                    return "Meteor Swarm";
                case Spells.ID.MIND_BLANK:
                    return "Mind Blank";
                case Spells.ID.MINOR_ILLUSION:
                    return "Minor Illusion";
                case Spells.ID.MIRAGE_ARCANE:
                    return "Mirage Arcane";
                case Spells.ID.MIRROR_IMAGE:
                    return "Mirror Image";
                case Spells.ID.MISLEAD:
                    return "Mislead";
                case Spells.ID.MISTY_STEP:
                    return "Misty Step";
                case Spells.ID.MODIFY_MEMORY:
                    return "Modify Memory";
                case Spells.ID.MOONBEAM:
                    return "Moonbeam";
                case Spells.ID.MOVE_EARTH:
                    return "Move Earth";
                case Spells.ID.NONDETECTION:
                    return "Nondetection";
                case Spells.ID.PASS_WITHOUT_TRACE:
                    return "Pass without Trace";
                case Spells.ID.PASSWALL:
                    return "Passwall";
                case Spells.ID.PHANTASMAL_KILLER:
                    return "Phantasmal Killer";
                case Spells.ID.PHANTOM_STEED:
                    return "Phantom Steed";
                case Spells.ID.PLANAR_ALLY:
                    return "Planar Ally";
                case Spells.ID.PLANAR_BINDING:
                    return "Planar Binding";
                case Spells.ID.PLANE_SHIFT:
                    return "Plane Shift";
                case Spells.ID.PLANT_GROWTH:
                    return "Plant Growth";
                case Spells.ID.POISON_SPRAY:
                    return "Poison Spray";
                case Spells.ID.POLYMORPH:
                    return "Polymorph";
                case Spells.ID.POWER_WORD_KILL:
                    return "Power Word Kill";
                case Spells.ID.POWER_WORD_STUN:
                    return "Power Word Stun";
                case Spells.ID.PRAYER_OF_HEALING:
                    return "Prayer of Healing";
                case Spells.ID.PRESTIDIGITATION:
                    return "Prestidigitation";
                case Spells.ID.PRISMATIC_SPRAY:
                    return "Prismatic Spray";
                case Spells.ID.PRISMATIC_WALL:
                    return "Prismatic Wall";
                case Spells.ID.PRIVATE_SANCTUM:
                    return "Private Sanctum";
                case Spells.ID.PRODUCE_FLAME:
                    return "Produce Flame";
                case Spells.ID.PROGRAMMED_ILLUSION:
                    return "Programmed Illusion";
                case Spells.ID.PROJECT_IMAGE:
                    return "Project Image";
                case Spells.ID.PROTECTION_FROM_ENERGY:
                    return "Protection from Energy";
                case Spells.ID.PROTECTION_FROM_EVIL_AND_GOOD:
                    return "Protection from Evil and Good";
                case Spells.ID.PROTECTION_FROM_POISON:
                    return "Protection from Poison";
                case Spells.ID.PURIFY_FOOD_AND_DRINK:
                    return "Purify Food and Drink";
                case Spells.ID.RAISE_DEAD:
                    return "Raise Dead";
                case Spells.ID.RAY_OF_ENFEEBLEMENT:
                    return "Ray of Enfeeblement";
                case Spells.ID.RAY_OF_FROST:
                    return "Ray of Frost";
                case Spells.ID.REGENERATE:
                    return "Regenerate";
                case Spells.ID.REINCARNATE:
                    return "Reincarnate";
                case Spells.ID.REMOVE_CURSE:
                    return "Remove Curse";
                case Spells.ID.RESILIENT_SPHERE:
                    return "Resilient Sphere";
                case Spells.ID.RESISTANCE:
                    return "Resistance";
                case Spells.ID.RESURRECTION:
                    return "Resurrection";
                case Spells.ID.REVERSE_GRAVITY:
                    return "Reverse Gravity";
                case Spells.ID.REVIVIFY:
                    return "Revivify";
                case Spells.ID.ROPE_TRICK:
                    return "Rope Trick";
                case Spells.ID.SACRED_FLAME:
                    return "Sacred Flame";
                case Spells.ID.SANCTUARY:
                    return "Sanctuary";
                case Spells.ID.SCORCHING_RAY:
                    return "Scorching Ray";
                case Spells.ID.SCRYING:
                    return "Scrying";
                case Spells.ID.SECRET_CHEST:
                    return "Secret Chest";
                case Spells.ID.SEE_INVISIBILITY:
                    return "See Invisibility";
                case Spells.ID.SEEMING:
                    return "Seeming";
                case Spells.ID.SENDING:
                    return "Sending";
                case Spells.ID.SEQUESTER:
                    return "Sequester";
                case Spells.ID.SHAPECHANGE:
                    return "Shapechange";
                case Spells.ID.SHATTER:
                    return "Shatter";
                case Spells.ID.SHIELD:
                    return "Shield";
                case Spells.ID.SHIELD_OF_FAITH:
                    return "Shield of Faith";
                case Spells.ID.SHILLELAGH:
                    return "Shillelagh";
                case Spells.ID.SHOCKING_GRASP:
                    return "Shocking Grasp";
                case Spells.ID.SILENCE:
                    return "Silence";
                case Spells.ID.SILENT_IMAGE:
                    return "Silent Image";
                case Spells.ID.SIMULACRUM:
                    return "Simulacrum";
                case Spells.ID.SLEEP:
                    return "Sleep";
                case Spells.ID.SLEET_STORM:
                    return "Sleet Storm";
                case Spells.ID.SLOW:
                    return "Slow";
                case Spells.ID.SPARE_THE_DYING:
                    return "Spare the Dying";
                case Spells.ID.SPEAK_WITH_ANIMALS:
                    return "Speak with Animals";
                case Spells.ID.SPEAK_WITH_DEAD:
                    return "Speak with Dead";
                case Spells.ID.SPEAK_WITH_PLANTS:
                    return "Speak with Plants";
                case Spells.ID.SPIDER_CLIMB:
                    return "Spider Climb";
                case Spells.ID.SPIKE_GROWTH:
                    return "Spike Growth";
                case Spells.ID.SPIRIT_GUARDIANS:
                    return "Spirit Guardians";
                case Spells.ID.SPIRITUAL_WEAPON:
                    return "Spiritual Weapon";
                case Spells.ID.STINKING_CLOUD:
                    return "Stinking Cloud";
                case Spells.ID.STONE_SHAPE:
                    return "Stone Shape";
                case Spells.ID.STONESKIN:
                    return "Stoneskin";
                case Spells.ID.STORM_OF_VENGEANCE:
                    return "Storm of Vengeance";
                case Spells.ID.SUGGESTION:
                    return "Suggestion";
                case Spells.ID.SUNBEAM:
                    return "Sunbeam";
                case Spells.ID.SUNBURST:
                    return "Sunburst";
                case Spells.ID.SYMBOL:
                    return "Symbol";
                case Spells.ID.TELEKINESIS:
                    return "Telekinesis";
                case Spells.ID.TELEPATHIC_BOND:
                    return "Telepathic Bond";
                case Spells.ID.TELEPORT:
                    return "Teleport";
                case Spells.ID.TELEPORTATION_CIRCLE:
                    return "Teleportation Circle";
                case Spells.ID.THAUMATURGY:
                    return "Thaumaturgy";
                case Spells.ID.THUNDERWAVE:
                    return "Thunderwave";
                case Spells.ID.TIME_STOP:
                    return "Time Stop";
                case Spells.ID.TINY_HUT:
                    return "Tiny Hut";
                case Spells.ID.TONGUES:
                    return "Tongues";
                case Spells.ID.TRANSPORT_VIA_PLANTS:
                    return "Transport via Plants";
                case Spells.ID.TREE_STRIDE:
                    return "Tree Stride";
                case Spells.ID.TRUE_POLYMORPH:
                    return "True Polymorph";
                case Spells.ID.TRUE_RESURRECTION:
                    return "True Resurrection";
                case Spells.ID.TRUE_SEEING:
                    return "True Seeing";
                case Spells.ID.TRUE_STRIKE:
                    return "True Strike";
                case Spells.ID.UNSEEN_SERVANT:
                    return "Unseen Servant";
                case Spells.ID.VAMPIRIC_TOUCH:
                    return "Vampiric Touch";
                case Spells.ID.VICIOUS_MOCKERY:
                    return "Vicious Mockery";
                case Spells.ID.WALL_OF_FIRE:
                    return "Wall of Fire";
                case Spells.ID.WALL_OF_FORCE:
                    return "Wall of Force";
                case Spells.ID.WALL_OF_ICE:
                    return "Wall of Ice";
                case Spells.ID.WALL_OF_STONE:
                    return "Wall of Stone";
                case Spells.ID.WALL_OF_THORNS:
                    return "Wall of Thorns";
                case Spells.ID.WARDING_BOND:
                    return "Warding Bond";
                case Spells.ID.WATER_BREATHING:
                    return "Water Breathing";
                case Spells.ID.WATER_WALK:
                    return "Water Walk";
                case Spells.ID.WEB:
                    return "Web";
                case Spells.ID.WEIRD:
                    return "Weird";
                case Spells.ID.WIND_WALK:
                    return "Wind Walk";
                case Spells.ID.WIND_WALL:
                    return "Wind Wall";
                case Spells.ID.WISH:
                    return "Wish";
                case Spells.ID.WORD_OF_RECALL:
                    return "Word of Recall";
                case Spells.ID.ZONE_OF_TRUTH:
                    return "Zone of Truth";
                default:
                    return Enum.GetName(typeof(Spells.ID), spell) + ": (Name missing)";
            }
        }

        public static string Description(this Spells.ID spell) {
            switch (spell) {
                case Spells.ID.ACID_ARROW:
                    return "A shimmering green arrow streaks toward a target within range and bursts in a spray of acid. Make a ranged spell attack against the target. On a hit, the target takes 4d4 acid damage immediately and 2d4 acid damage at the end of its next turn. On a miss, the arrow splashes the target with acid for half as much of the initial damage and no damage at the end of its next turn.\nWhen you cast this spell using a spell slot of 3rd level or higher, the damage (both initial and later) increases by 1d4 for each slot level above 2nd.";
                case Spells.ID.ACID_SPLASH:
                    return "You hurl a bubble of acid. Choose one creature within range, or choose two creatures within range that are within 5 feet of each other. A target must succeed on a dexterity saving throw or take 1d6 acid damage.\nThis spell's damage increases by 1d6 when you reach 5th level (2d6), 11th level (3d6), and 17th level (4d6).";
                case Spells.ID.AID:
                    return "Your spell bolsters your allies with toughness and resolve. Choose up to three creatures within range. Each target's hit point maximum and current hit points increase by 5 for the duration.\nWhen you cast this spell using a spell slot of 3rd level or higher, a target's hit points increase by an additional 5 for each slot level above 2nd.";
                case Spells.ID.ALARM:
                    return "You set an alarm against unwanted intrusion. Choose a door, a window, or an area within range that is no larger than a 20-foot cube. Until the spell ends, an alarm alerts you whenever a Tiny or larger creature touches or enters the warded area. When you cast the spell, you can designate creatures that won't set off the alarm. You also choose whether the alarm is mental or audible.\nA mental alarm alerts you with a ping in your mind if you are within 1 mile of the warded area. This ping awakens you if you are sleeping.\nAn audible alarm produces the sound of a hand bell for 10 seconds within 60 feet.";
                case Spells.ID.ALTER_SELF:
                    return "You assume a different form. When you cast the spell, choose one of the following options, the effects of which last for the duration of the spell. While the spell lasts, you can end one option as an action to gain the benefits of a different one.\n***Aquatic Adaptation.*** You adapt your body to an aquatic environment, sprouting gills and growing webbing between your fingers. You can breathe underwater and gain a swimming speed equal to your walking speed.\n***Change Appearance.*** You transform your appearance. You decide what you look like, including your height, weight, facial features, sound of your voice, hair length, coloration, and distinguishing characteristics, if any. You can make yourself appear as a member of another race, though none of your statistics change. You also can't appear as a creature of a different size than you, and your basic shape stays the same; if you're bipedal, you can't use this spell to become quadrupedal, for instance. At any time for the duration of the spell, you can use your action to change your appearance in this way again.\n***Natural Weapons.*** You grow claws, fangs, spines, horns, or a different natural weapon of your choice. Your unarmed strikes deal 1d6 bludgeoning, piercing, or slashing damage, as appropriate to the natural weapon you chose, and you are proficient with your unarmed strikes. Finally, the natural weapon is magic and you have a +1 bonus to the attack and damage rolls you make using it.";
                case Spells.ID.ANIMAL_FRIENDSHIP:
                    return "This spell lets you convince a beast that you mean it no harm. Choose a beast that you can see within range. It must see and hear you. If the beast's Intelligence is 4 or higher, the spell fails. Otherwise, the beast must succeed on a wisdom saving throw or be charmed by you for the spell's duration. If you or one of your companions harms the target, the spells ends.";
                case Spells.ID.ANIMAL_MESSENGER:
                    return "By means of this spell, you use an animal to deliver a message. Choose a Tiny beast you can see within range, such as a squirrel, a blue jay, or a bat. You specify a location, which you must have visited, and a recipient who matches a general description, such as \"a man or woman dressed in the uniform of the town guard\" or \"a red-haired dwarf wearing a pointed hat.\" You also speak a message of up to twenty-five words. The target beast travels for the duration of the spell toward the specified location, covering about 50 miles per 24 hours for a flying messenger, or 25 miles for other animals.\nWhen the messenger arrives, it delivers your message to the creature that you described, replicating the sound of your voice. The messenger speaks only to a creature matching the description you gave. If the messenger doesn't reach its destination before the spell ends, the message is lost, and the beast makes its way back to where you cast this spell.\nIf you cast this spell using a spell slot of 3nd level or higher, the duration of the spell increases by 48 hours for each slot level above 2nd.";
                case Spells.ID.ANIMAL_SHAPES:
                    return "Your magic turns others into beasts. Choose any number of willing creatures that you can see within range. You transform each target into the form of a Large or smaller beast with a challenge rating of 4 or lower. On subsequent turns, you can use your action to transform affected creatures into new forms.\nThe transformation lasts for the duration for each target, or until the target drops to 0 hit points or dies. You can choose a different form for each target. A target's game statistics are replaced by the statistics of the chosen beast, though the target retains its alignment and Intelligence, Wisdom, and Charisma scores. The target assumes the hit points of its new form, and when it reverts to its normal form, it returns to the number of hit points it had before it transformed. If it reverts as a result of dropping to 0 hit points, any excess damage carries over to its normal form. As long as the excess damage doesn't reduce the creature's normal form to 0 hit points, it isn't knocked unconscious. The creature is limited in the actions it can perform by the nature of its new form, and it can't speak or cast spells.\nThe target's gear melds into the new form. The target can't activate, wield, or otherwise benefit from any of its equipment.";
                case Spells.ID.ANIMATE_DEAD:
                    return "This spell creates an undead servant. Choose a pile of bones or a corpse of a Medium or Small humanoid within range. Your spell imbues the target with a foul mimicry of life, raising it as an undead creature. The target becomes a skeleton if you chose bones or a zombie if you chose a corpse (the DM has the creature's game statistics).\nOn each of your turns, you can use a bonus action to mentally command any creature you made with this spell if the creature is within 60 feet of you (if you control multiple creatures, you can command any or all of them at the same time, issuing the same command to each one). You decide what action the creature will take and where it will move during its next turn, or you can issue a general command, such as to guard a particular chamber or corridor. If you issue no commands, the creature only defends itself against hostile creatures. Once given an order, the creature continues to follow it until its task is complete.\nThe creature is under your control for 24 hours, after which it stops obeying any command you've given it. To maintain control of the creature for another 24 hours, you must cast this spell on the creature again before the current 24-hour period ends. This use of the spell reasserts your control over up to four creatures you have animated with this spell, rather than animating a new one.\nWhen you cast this spell using a spell slot of 4th level or higher, you animate or reassert control over two additional undead creatures for each slot level above 3rd. Each of the creatures must come from a different corpse or pile of bones.";
                case Spells.ID.ANIMATE_OBJECTS:
                    return "Objects come to life at your command. Choose up to ten nonmagical objects within range that are not being worn or carried. Medium targets count as two objects, Large targets count as four objects, Huge targets count as eight objects. You can't animate any object larger than Huge. Each target animates and becomes a creature under your control until the spell ends or until reduced to 0 hit points.\nAs a bonus action, you can mentally command any creature you made with this spell if the creature is within 500 feet of you (if you control multiple creatures, you can command any or all of them at the same time, issuing the same command to each one). You decide what action the creature will take and where it will move during its next turn, or you can issue a general command, such as to guard a particular chamber or corridor. If you issue no commands, the creature only defends itself against hostile creatures. Once given an order, the creature continues to follow it until its task is complete.\nAn animated object is a construct with AC, hit points, attacks, Strength, and Dexterity determined by its size. Its Constitution is 10 and its Intelligence and Wisdom are 3, and its Charisma is 1. Its speed is 30 feet; if the object lacks legs or other appendages it can use for locomotion, it instead has a flying speed of 30 feet and can hover. If the object is securely attached to a surface or a larger object, such as a chain bolted to a wall, its speed is 0. It has blindsight with a radius of 30 feet and is blind beyond that distance. When the animated object drops to 0 hit points, it reverts to its original object form, and any remaining damage carries over to its original object form.\nIf you command an object to attack, it can make a single melee attack against a creature within 5 feet of it. It makes a slam attack with an attack bonus and bludgeoning damage determined by its size. The DM might rule that a specific object inflicts slashing or piercing damage based on its form.\nIf you cast this spell using a spell slot of 6th level or higher, you can animate two additional objects for each slot level above 5th.";
                case Spells.ID.ANTILIFE_SHELL:
                    return "A shimmering barrier extends out from you in a 10-foot radius and moves with you, remaining centered on you and hedging out creatures other than undead and constructs. The barrier lasts for the duration.\nThe barrier prevents an affected creature from passing or reaching through. An affected creature can cast spells or make attacks with ranged or reach weapons through the barrier.\nIf you move so that an affected creature is forced to pass through the barrier, the spell ends.";
                case Spells.ID.ANTIMAGIC_FIELD:
                    return "A 10-foot-radius invisible sphere of antimagic surrounds you. This area is divorced from the magical energy that suffuses the multiverse. Within the sphere, spells can't be cast, summoned creatures disappear, and even magic items become mundane. Until the spell ends, the sphere moves with you, centered on you.\nSpells and other magical effects, except those created by an artifact or a deity, are suppressed in the sphere and can't protrude into it. A slot expended to cast a suppressed spell is consumed. While an effect is suppressed, it doesn't function, but the time it spends suppressed counts against its duration.\n***Targeted Effects.*** Spells and other magical effects, such as magic missile and charm person, that target a creature or an object in the sphere have no effect on that target.\n***Areas of Magic.*** The area of another spell or magical effect, such as fireball, can't extend into the sphere. If the sphere overlaps an area of magic, the part of the area that is covered by the sphere is suppressed. For example, the flames created by a wall of fire are suppressed within the sphere, creating a gap in the wall if the overlap is large enough.\n***Spells.*** Any active spell or other magical effect on a creature or an object in the sphere is suppressed while the creature or object is in it.\n***Magic Items.*** The properties and powers of magic items are suppressed in the sphere. For example, a +1 longsword in the sphere functions as a nonmagical longsword.\nA magic weapon's properties and powers are suppressed if it is used against a target in the sphere or wielded by an attacker in the sphere. If a magic weapon or a piece of magic ammunition fully leaves the sphere (for example, if you fire a magic arrow or throw a magic spear at a target outside the sphere), the magic of the item ceases to be suppressed as soon as it exits.\n***Magical Travel.*** Teleportation and planar travel fail to work in the sphere, whether the sphere is the destination or the departure point for such magical travel. A portal to another location, world, or plane of existence, as well as an opening to an extradimensional space such as that created by the rope trick spell, temporarily closes while in the sphere.\n***Creatures and Objects.*** A creature or object summoned or created by magic temporarily winks out of existence in the sphere. Such a creature instantly reappears once the space the creature occupied is no longer within the sphere.\n***Dispel Magic.*** Spells and magical effects such as dispel magic have no effect on the sphere. Likewise, the spheres created by different antimagic field spells don't nullify each other.";
                case Spells.ID.ANTIPATHY_SYMPATHY:
                    return "This spell attracts or repels creatures of your choice. You target something within range, either a Huge or smaller object or creature or an area that is no larger than a 200-foot cube. Then specify a kind of intelligent creature, such as red dragons, goblins, or vampires. You invest the target with an aura that either attracts or repels the specified creatures for the duration. Choose antipathy or sympathy as the aura's effect.\n***Antipathy.*** The enchantment causes creatures of the kind you designated to feel an intense urge to leave the area and avoid the target. When such a creature can see the target or comes within 60 feet of it, the creature must succeed on a wisdom saving throw or become frightened. The creature remains frightened while it can see the target or is within 60 feet of it. While frightened by the target, the creature must use its movement to move to the nearest safe spot from which it can't see the target. If the creature moves more than 60 feet from the target and can't see it, the creature is no longer frightened, but the creature becomes frightened again if it regains sight of the target or moves within 60 feet of it.\n***Sympathy.*** The enchantment causes the specified creatures to feel an intense urge to approach the target while within 60 feet of it or able to see it. When such a creature can see the target or comes within 60 feet of it, the creature must succeed on a wisdom saving throw or use its movement on each of its turns to enter the area or move within reach of the target. When the creature has done so, it can't willingly move away from the target.\nIf the target damages or otherwise harms an affected creature, the affected creature can make a wisdom saving throw to end the effect, as described below.\n***Ending the Effect.*** If an affected creature ends its turn while not within 60 feet of the target or able to see it, the creature makes a wisdom saving throw. On a successful save, the creature is no longer affected by the target and recognizes the feeling of repugnance or attraction as magical. In addition, a creature affected by the spell is allowed another wisdom saving throw every 24 hours while the spell persists.\nA creature that successfully saves against this effect is immune to it for 1 minute, after which time it can be affected again.";
                case Spells.ID.ARCANE_EYE:
                    return "You create an invisible, magical eye within range that hovers in the air for the duration.\nYou mentally receive visual information from the eye, which has normal vision and darkvision out to 30 feet. The eye can look in every direction.\nAs an action, you can move the eye up to 30 feet in any direction. There is no limit to how far away from you the eye can move, but it can't enter another plane of existence. A solid barrier blocks the eye's movement, but the eye can pass through an opening as small as 1 inch in diameter.";
                case Spells.ID.ARCANE_HAND:
                    return "You create a Large hand of shimmering, translucent force in an unoccupied space that you can see within range. The hand lasts for the spell's duration, and it moves at your command, mimicking the movements of your own hand.\nThe hand is an object that has AC 20 and hit points equal to your hit point maximum. If it drops to 0 hit points, the spell ends. It has a Strength of 26 (+8) and a Dexterity of 10 (+0). The hand doesn't fill its space.\nWhen you cast the spell and as a bonus action on your subsequent turns, you can move the hand up to 60 feet and then cause one of the following effects with it.\n***Clenched Fist.*** The hand strikes one creature or object within 5 feet of it. Make a melee spell attack for the hand using your game statistics. On a hit, the target takes 4d8 force damage.\n***Forceful Hand.*** The hand attempts to push a creature within 5 feet of it in a direction you choose. Make a check with the hand's Strength contested by the Strength (Athletics) check of the target. If the target is Medium or smaller, you have advantage on the check. If you succeed, the hand pushes the target up to 5 feet plus a number of feet equal to five times your spellcasting ability modifier. The hand moves with the target to remain within 5 feet of it.\n***Grasping Hand.*** The hand attempts to grapple a Huge or smaller creature within 5 feet of it. You use the hand's Strength score to resolve the grapple. If the target is Medium or smaller, you have advantage on the check. While the hand is grappling the target, you can use a bonus action to have the hand crush it. When you do so, the target takes bludgeoning damage equal to 2d6 + your spellcasting ability modifier.\n***Interposing Hand.*** The hand interposes itself between you and a creature you choose until you give the hand a different command. The hand moves to stay between you and the target, providing you with half cover against the target. The target can't move through the hand's space if its Strength score is less than or equal to the hand's Strength score. If its Strength score is higher than the hand's Strength score, the target can move toward you through the hand's space, but that space is difficult terrain for the target.\nWhen you cast this spell using a spell slot of 6th level or higher, the damage from the clenched fist option increases by 2d8 and the damage from the grasping hand increases by 2d6 for each slot level above 5th.";
                case Spells.ID.ARCANE_LOCK:
                    return "You touch a closed door, window, gate, chest, or other entryway, and it becomes locked for the duration. You and the creatures you designate when you cast this spell can open the object normally. You can also set a password that, when spoken within 5 feet of the object, suppresses this spell for 1 minute. Otherwise, it is impassable until it is broken or the spell is dispelled or suppressed. Casting knock on the object suppresses arcane lock for 10 minutes.\nWhile affected by this spell, the object is more difficult to break or force open; the DC to break it or pick any locks on it increases by 10.";
                case Spells.ID.ARCANE_SWORD:
                    return "You create a sword-shaped plane of force that hovers within range. It lasts for the duration.\nWhen the sword appears, you make a melee spell attack against a target of your choice within 5 feet of the sword. On a hit, the target takes 3d10 force damage. Until the spell ends, you can use a bonus action on each of your turns to move the sword up to 20 feet to a spot you can see and repeat this attack against the same target or a different one.";
                case Spells.ID.ARCANISTS_MAGIC_AURA:
                    return "You place an illusion on a creature or an object you touch so that divination spells reveal false information about it. The target can be a willing creature or an object that isn't being carried or worn by another creature.\nWhen you cast the spell, choose one or both of the following effects. The effect lasts for the duration. If you cast this spell on the same creature or object every day for 30 days, placing the same effect on it each time, the illusion lasts until it is dispelled.\n***False Aura.*** You change the way the target appears to spells and magical effects, such as detect magic, that detect magical auras. You can make a nonmagical object appear magical, a magical object appear nonmagical, or change the object's magical aura so that it appears to belong to a specific school of magic that you choose. When you use this effect on an object, you can make the false magic apparent to any creature that handles the item.\n***Mask.*** You change the way the target appears to spells and magical effects that detect creature types, such as a paladin's Divine Sense or the trigger of a symbol spell. You choose a creature type and other spells and magical effects treat the target as if it were a creature of that type or of that alignment.";
                case Spells.ID.ASTRAL_PROJECTION:
                    return "You and up to eight willing creatures within range project your astral bodies into the Astral Plane (the spell fails and the casting is wasted if you are already on that plane). The material body you leave behind is unconscious and in a state of suspended animation; it doesn't need food or air and doesn't age.\nYour astral body resembles your mortal form in almost every way, replicating your game statistics and possessions. The principal difference is the addition of a silvery cord that extends from between your shoulder blades and trails behind you, fading to invisibility after 1 foot. This cord is your tether to your material body. As long as the tether remains intact, you can find your way home. If the cord is cut--something that can happen only when an effect specifically states that it does--your soul and body are separated, killing you instantly.\nYour astral form can freely travel through the Astral Plane and can pass through portals there leading to any other plane. If you enter a new plane or return to the plane you were on when casting this spell, your body and possessions are transported along the silver cord, allowing you to re-enter your body as you enter the new plane. Your astral form is a separate incarnation. Any damage or other effects that apply to it have no effect on your physical body, nor do they persist when you return to it.\nThe spell ends for you and your companions when you use your action to dismiss it. When the spell ends, the affected creature returns to its physical body, and it awakens.\nThe spell might also end early for you or one of your companions. A successful dispel magic spell used against an astral or physical body ends the spell for that creature. If a creature's original body or its astral form drops to 0 hit points, the spell ends for that creature. If the spell ends and the silver cord is intact, the cord pulls the creature's astral form back to its body, ending its state of suspended animation.\nIf you are returned to your body prematurely, your companions remain in their astral forms and must find their own way back to their bodies, usually by dropping to 0 hit points.";
                case Spells.ID.AUGURY:
                    return "By casting gem-inlaid sticks, rolling dragon bones, laying out ornate cards, or employing some other divining tool, you receive an omen from an otherworldly entity about the results of a specific course of action that you plan to take within the next 30 minutes. The DM chooses from the following possible omens:\n- Weal, for good results\n- Woe, for bad results\n- Weal and woe, for both good and bad results\n- Nothing, for results that aren't especially good or bad\nThe spell doesn't take into account any possible circumstances that might change the outcome, such as the casting of additional spells or the loss or gain of a companion.\nIf you cast the spell two or more times before completing your next long rest, there is a cumulative 25 percent chance for each casting after the first that you get a random reading. The DM makes this roll in secret.";
                case Spells.ID.AWAKEN:
                    return "After spending the casting time tracing magical pathways within a precious gemstone, you touch a Huge or smaller beast or plant. The target must have either no Intelligence score or an Intelligence of 3 or less. The target gains an Intelligence of 10. The target also gains the ability to speak one language you know. If the target is a plant, it gains the ability to move its limbs, roots, vines, creepers, and so forth, and it gains senses similar to a human's. Your DM chooses statistics appropriate for the awakened plant, such as the statistics for the awakened shrub or the awakened tree.\nThe awakened beast or plant is charmed by you for 30 days or until you or your companions do anything harmful to it. When the charmed condition ends, the awakened creature chooses whether to remain friendly to you, based on how you treated it while it was charmed.";
                case Spells.ID.BANE:
                    return "Up to three creatures of your choice that you can see within range must make charisma saving throws. Whenever a target that fails this saving throw makes an attack roll or a saving throw before the spell ends, the target must roll a d4 and subtract the number rolled from the attack roll or saving throw.\nWhen you cast this spell using a spell slot of 2nd level or higher, you can target one additional creature for each slot level above 1st.";
                case Spells.ID.BANISHMENT:
                    return "You attempt to send one creature that you can see within range to another plane of existence. The target must succeed on a charisma saving throw or be banished.\nIf the target is native to the plane of existence you're on, you banish the target to a harmless demiplane. While there, the target is incapacitated. The target remains there until the spell ends, at which point the target reappears in the space it left or in the nearest unoccupied space if that space is occupied.\nIf the target is native to a different plane of existence than the one you're on, the target is banished with a faint popping noise, returning to its home plane. If the spell ends before 1 minute has passed, the target reappears in the space it left or in the nearest unoccupied space if that space is occupied. Otherwise, the target doesn't return.\nWhen you cast this spell using a spell slot of 5th level or higher, you can target one additional creature for each slot level above 4th.";
                case Spells.ID.BARKSKIN:
                    return "You touch a willing creature. Until the spell ends, the target's skin has a rough, bark-like appearance, and the target's AC can't be less than 16, regardless of what kind of armor it is wearing.";
                case Spells.ID.BEACON_OF_HOPE:
                    return "This spell bestows hope and vitality. Choose any number of creatures within range. For the duration, each target has advantage on wisdom saving throws and death saving throws, and regains the maximum number of hit points possible from any healing.";
                case Spells.ID.BESTOW_CURSE:
                    return "You touch a creature, and that creature must succeed on a wisdom saving throw or become cursed for the duration of the spell. When you cast this spell, choose the nature of the curse from the following options:\n- Choose one ability score. While cursed, the target has disadvantage on ability checks and saving throws made with that ability score.\n- While cursed, the target has disadvantage on attack rolls against you.\n- While cursed, the target must make a wisdom saving throw at the start of each of its turns. If it fails, it wastes its action that turn doing nothing.\n- While the target is cursed, your attacks and spells deal an extra 1d8 necrotic damage to the target.\nA remove curse spell ends this effect. At the DM's option, you may choose an alternative curse effect, but it should be no more powerful than those described above. The DM has final say on such a curse's effect.\nIf you cast this spell using a spell slot of 4th level or higher, the duration is concentration, up to 10 minutes. If you use a spell slot of 5th level or higher, the duration is 8 hours. If you use a spell slot of 7th level or higher, the duration is 24 hours. If you use a 9th level spell slot, the spell lasts until it is dispelled. Using a spell slot of 5th level or higher grants a duration that doesn't require concentration.";
                case Spells.ID.BLACK_TENTACLES:
                    return "Squirming, ebony tentacles fill a 20-foot square on ground that you can see within range. For the duration, these tentacles turn the ground in the area into difficult terrain.\nWhen a creature enters the affected area for the first time on a turn or starts its turn there, the creature must succeed on a Dexterity saving throw or take 3d6 bludgeoning damage and be restrained by the tentacles until the spell ends. A creature that starts its turn in the area and is already restrained by the tentacles takes 3d6 bludgeoning damage.\nA creature restrained by the tentacles can use its action to make a Strength or Dexterity check (its choice) against your spell save DC. On a success, it frees itself.";
                case Spells.ID.BLADE_BARRIER:
                    return "You create a vertical wall of whirling, razor-sharp blades made of magical energy. The wall appears within range and lasts for the duration. You can make a straight wall up to 100 feet long, 20 feet high, and 5 feet thick, or a ringed wall up to 60 feet in diameter, 20 feet high, and 5 feet thick. The wall provides three-quarters cover to creatures behind it, and its space is difficult terrain.\nWhen a creature enters the wall's area for the first time on a turn or starts its turn there, the creature must make a dexterity saving throw. On a failed save, the creature takes 6d10 slashing damage. On a successful save, the creature takes half as much damage.";
                case Spells.ID.BLESS:
                    return "You bless up to three creatures of your choice within range. Whenever a target makes an attack roll or a saving throw before the spell ends, the target can roll a d4 and add the number rolled to the attack roll or saving throw.\nWhen you cast this spell using a spell slot of 2nd level or higher, you can target one additional creature for each slot level above 1st.";
                case Spells.ID.BLIGHT:
                    return "Necromantic energy washes over a creature of your choice that you can see within range, draining moisture and vitality from it. The target must make a constitution saving throw. The target takes 8d8 necrotic damage on a failed save, or half as much damage on a successful one. The spell has no effect on undead or constructs.\nIf you target a plant creature or a magical plant, it makes the saving throw with disadvantage, and the spell deals maximum damage to it.\nIf you target a nonmagical plant that isn't a creature, such as a tree or shrub, it doesn't make a saving throw; it simply withers and dies.\nWhen you cast this spell using a spell slot of 5th level of higher, the damage increases by 1d8 for each slot level above 4th.";
                case Spells.ID.BLINDNESS_DEAFNESS:
                    return "You can blind or deafen a foe. Choose one creature that you can see within range to make a constitution saving throw. If it fails, the target is either blinded or deafened (your choice) for the duration. At the end of each of its turns, the target can make a constitution saving throw. On a success, the spell ends.\nWhen you cast this spell using a spell slot of 3rd level or higher, you can target one additional creature for each slot level above 2nd.";
                case Spells.ID.BLINK:
                    return "Roll a d20 at the end of each of your turns for the duration of the spell. On a roll of 11 or higher, you vanish from your current plane of existence and appear in the Ethereal Plane (the spell fails and the casting is wasted if you were already on that plane). At the start of your next turn, and when the spell ends if you are on the Ethereal Plane, you return to an unoccupied space of your choice that you can see within 10 feet of the space you vanished from. If no unoccupied space is available within that range, you appear in the nearest unoccupied space (chosen at random if more than one space is equally near). You can dismiss this spell as an action.\nWhile on the Ethereal Plane, you can see and hear the plane you originated from, which is cast in shades of gray, and you can't see anything there more than 60 feet away. You can only affect and be affected by other creatures on the Ethereal Plane. Creatures that aren't there can't perceive you or interact with you, unless they have the ability to do so.";
                case Spells.ID.BLUR:
                    return "Your body becomes blurred, shifting and wavering to all who can see you. For the duration, any creature has disadvantage on attack rolls against you. An attacker is immune to this effect if it doesn't rely on sight, as with blindsight, or can see through illusions, as with truesight.";
                case Spells.ID.BRANDING_SMITE:
                    return "The next time you hit a creature with a weapon attack before this spell ends, the weapon gleams with astral radiance as you strike. The attack deals an extra 2d6 radiant damage to the target, which becomes visible if it's invisible, and the target sheds dim light in a 5-foot radius and can't become invisible until the spell ends.\nWhen you cast this spell using a spell slot of 3rd level or higher, the extra damage increases by 1d6 for each slot level above 2nd.";
                case Spells.ID.BURNING_HANDS:
                    return "As you hold your hands with thumbs touching and fingers spread, a thin sheet of flames shoots forth from your outstretched fingertips. Each creature in a 15-foot cone must make a dexterity saving throw. A creature takes 3d6 fire damage on a failed save, or half as much damage on a successful one.\nThe fire ignites any flammable objects in the area that aren't being worn or carried.\nWhen you cast this spell using a spell slot of 2nd level or higher, the damage increases by 1d6 for each slot level above 1st.";
                case Spells.ID.CALL_LIGHTNING:
                    return "A storm cloud appears in the shape of a cylinder that is 10 feet tall with a 60-foot radius, centered on a point you can see 100 feet directly above you. The spell fails if you can't see a point in the air where the storm cloud could appear (for example, if you are in a room that can't accommodate the cloud).\nWhen you cast the spell, choose a point you can see within range. A bolt of lightning flashes down from the cloud to that point. Each creature within 5 feet of that point must make a dexterity saving throw. A creature takes 3d10 lightning damage on a failed save, or half as much damage on a successful one. On each of your turns until the spell ends, you can use your action to call down lightning in this way again, targeting the same point or a different one.\nIf you are outdoors in stormy conditions when you cast this spell, the spell gives you control over the existing storm instead of creating a new one. Under such conditions, the spell's damage increases by 1d10.\nWhen you cast this spell using a spell slot of 4th or higher level, the damage increases by 1d10 for each slot level above 3rd.";
                case Spells.ID.CALM_EMOTIONS:
                    return "You attempt to suppress strong emotions in a group of people. Each humanoid in a 20-foot-radius sphere centered on a point you choose within range must make a charisma saving throw; a creature can choose to fail this saving throw if it wishes. If a creature fails its saving throw, choose one of the following two effects. You can suppress any effect causing a target to be charmed or frightened. When this spell ends, any suppressed effect resumes, provided that its duration has not expired in the meantime.\nAlternatively, you can make a target indifferent about creatures of your choice that it is hostile toward. This indifference ends if the target is attacked or harmed by a spell or if it witnesses any of its friends being harmed. When the spell ends, the creature becomes hostile again, unless the DM rules otherwise.";
                case Spells.ID.CHAIN_LIGHTNING:
                    return "You create a bolt of lightning that arcs toward a target of your choice that you can see within range. Three bolts then leap from that target to as many as three other targets, each of which must be within 30 feet of the first target. A target can be a creature or an object and can be targeted by only one of the bolts.\nA target must make a dexterity saving throw. The target takes 10d8 lightning damage on a failed save, or half as much damage on a successful one.\nWhen you cast this spell using a spell slot of 7th level or higher, one additional bolt leaps from the first target to another target for each slot level above 6th.";
                case Spells.ID.CHARM_PERSON:
                    return "You attempt to charm a humanoid you can see within range. It must make a wisdom saving throw, and does so with advantage if you or your companions are fighting it. If it fails the saving throw, it is charmed by you until the spell ends or until you or your companions do anything harmful to it. The charmed creature regards you as a friendly acquaintance. When the spell ends, the creature knows it was charmed by you.\nWhen you cast this spell using a spell slot of 2nd level or higher, you can target one additional creature for each slot level above 1st. The creatures must be within 30 feet of each other when you target them.";
                case Spells.ID.CHILL_TOUCH:
                    return "You create a ghostly, skeletal hand in the space of a creature within range. Make a ranged spell attack against the creature to assail it with the chill of the grave. On a hit, the target takes 1d8 necrotic damage, and it can't regain hit points until the start of your next turn. Until then, the hand clings to the target.\nIf you hit an undead target, it also has disadvantage on attack rolls against you until the end of your next turn.\nThis spell's damage increases by 1d8 when you reach 5th level (2d8), 11th level (3d8), and 17th level (4d8).";
                case Spells.ID.CIRCLE_OF_DEATH:
                    return "A sphere of negative energy ripples out in a 60-foot radius sphere from a point within range. Each creature in that area must make a constitution saving throw. A target takes 8d6 necrotic damage on a failed save, or half as much damage on a successful one.\nWhen you cast this spell using a spell slot of 7th level or higher, the damage increases by 2d6 for each slot level above 6th.";
                case Spells.ID.CLAIRVOYANCE:
                    return "You create an invisible sensor within range in a location familiar to you (a place you have visited or seen before) or in an obvious location that is unfamiliar to you (such as behind a door, around a corner, or in a grove of trees). The sensor remains in place for the duration, and it can't be attacked or otherwise interacted with.\nWhen you cast the spell, you choose seeing or hearing. You can use the chosen sense through the sensor as if you were in its space. As your action, you can switch between seeing and hearing.\nA creature that can see the sensor (such as a creature benefiting from see invisibility or truesight) sees a luminous, intangible orb about the size of your fist.";
                case Spells.ID.CLONE:
                    return "This spell grows an inert duplicate of a living creature as a safeguard against death. This clone forms inside a sealed vessel and grows to full size and maturity after 120 days; you can also choose to have the clone be a younger version of the same creature. It remains inert and endures indefinitely, as long as its vessel remains undisturbed.\nAt any time after the clone matures, if the original creature dies, its soul transfers to the clone, provided that the soul is free and willing to return. The clone is physically identical to the original and has the same personality, memories, and abilities, but none of the original's equipment. The original creature's physical remains, if they still exist, become inert and can't thereafter be restored to life, since the creature's soul is elsewhere.";
                case Spells.ID.CLOUDKILL:
                    return "You create a 20-foot-radius sphere of poisonous, yellow-green fog centered on a point you choose within range. The fog spreads around corners. It lasts for the duration or until strong wind disperses the fog, ending the spell. Its area is heavily obscured.\nWhen a creature enters the spell's area for the first time on a turn or starts its turn there, that creature must make a constitution saving throw. The creature takes 5d8 poison damage on a failed save, or half as much damage on a successful one. Creatures are affected even if they hold their breath or don't need to breathe.\nThe fog moves 10 feet away from you at the start of each of your turns, rolling along the surface of the ground. The vapors, being heavier than air, sink to the lowest level of the land, even pouring down openings.\nWhen you cast this spell using a spell slot of 6th level or higher, the damage increases by 1d8 for each slot level above 5th.";
                case Spells.ID.COLOR_SPRAY:
                    return "A dazzling array of flashing, colored light springs from your hand. Roll 6d10; the total is how many hit points of creatures this spell can effect. Creatures in a 15-foot cone originating from you are affected in ascending order of their current hit points (ignoring unconscious creatures and creatures that can't see).\nStarting with the creature that has the lowest current hit points, each creature affected by this spell is blinded until the spell ends. Subtract each creature's hit points from the total before moving on to the creature with the next lowest hit points. A creature's hit points must be equal to or less than the remaining total for that creature to be affected.\nWhen you cast this spell using a spell slot of 2nd level or higher, roll an additional 2d10 for each slot level above 1st.";
                case Spells.ID.COMMAND:
                    return "You speak a one-word command to a creature you can see within range. The target must succeed on a wisdom saving throw or follow the command on its next turn. The spell has no effect if the target is undead, if it doesn't understand your language, or if your command is directly harmful to it.\nSome typical commands and their effects follow. You might issue a command other than one described here. If you do so, the DM determines how the target behaves. If the target can't follow your command, the spell ends.\n***Approach.*** The target moves toward you by the shortest and most direct route, ending its turn if it moves within 5 feet of you.\n***Drop.*** The target drops whatever it is holding and then ends its turn.\n***Flee.*** The target spends its turn moving away from you by the fastest available means.\n***Grovel.*** The target falls prone and then ends its turn.\n***Halt.*** The target doesn't move and takes no actions. A flying creature stays aloft, provided that it is able to do so. If it must move to stay aloft, it flies the minimum distance needed to remain in the air.\nWhen you cast this spell using a spell slot of 2nd level or higher, you can affect one additional creature for each slot level above 1st. The creatures must be within 30 feet of each other when you target them.";
                case Spells.ID.COMMUNE:
                    return "You contact your deity or a divine proxy and ask up to three questions that can be answered with a yes or no. You must ask your questions before the spell ends. You receive a correct answer for each question.\nDivine beings aren't necessarily omniscient, so you might receive \"unclear\" as an answer if a question pertains to information that lies beyond the deity's knowledge. In a case where a one-word answer could be misleading or contrary to the deity's interests, the DM might offer a short phrase as an answer instead.\nIf you cast the spell two or more times before finishing your next long rest, there is a cumulative 25 percent chance for each casting after the first that you get no answer. The DM makes this roll in secret.";
                case Spells.ID.COMMUNE_WITH_NATURE:
                    return "You briefly become one with nature and gain knowledge of the surrounding territory. In the outdoors, the spell gives you knowledge of the land within 3 miles of you. In caves and other natural underground settings, the radius is limited to 300 feet. The spell doesn't function where nature has been replaced by construction, such as in dungeons and towns.\nYou instantly gain knowledge of up to three facts of your choice about any of the following subjects as they relate to the area:\n- terrain and bodies of water\n- prevalent plants, minerals, animals, or peoples\n- powerful celestials, fey, fiends, elementals, or undead\n- influence from other planes of existence\n- buildings\nFor example, you could determine the location of powerful undead in the area, the location of major sources of safe drinking water, and the location of any nearby towns.";
                case Spells.ID.COMPREHEND_LANGUAGES:
                    return "For the duration, you understand the literal meaning of any spoken language that you hear. You also understand any written language that you see, but you must be touching the surface on which the words are written. It takes about 1 minute to read one page of text.\nThis spell doesn't decode secret messages in a text or a glyph, such as an arcane sigil, that isn't part of a written language.";
                case Spells.ID.COMPULSION:
                    return "Creatures of your choice that you can see within range and that can hear you must make a wisdom saving throw. A target automatically succeeds on this saving throw if it can't be charmed. On a failed save, a target is affected by this spell. Until the spell ends, you can use a bonus action on each of your turns to designate a direction that is horizontal to you. Each affected target must use as much of its movement as possible to move in that direction on its next turn. It can take any action before it moves. After moving in this way, it can make another Wisdom save to try to end the effect.\nA target isn't compelled to move into an obviously deadly hazard, such as a fire or a pit, but it will provoke opportunity attacks to move in the designated direction.";
                case Spells.ID.CONE_OF_COLD:
                    return "A blast of cold air erupts from your hands. Each creature in a 60-foot cone must make a constitution saving throw. A creature takes 8d8 cold damage on a failed save, or half as much damage on a successful one.\nA creature killed by this spell becomes a frozen statue until it thaws.\nWhen you cast this spell using a spell slot of 6th level or higher, the damage increases by 1d8 for each slot level above 5th.";
                case Spells.ID.CONFUSION:
                    return "This spell assaults and twists creatures' minds, spawning delusions and provoking uncontrolled action. Each creature in a 10-foot-radius sphere centered on a point you choose within range must succeed on a Wisdom saving throw when you cast this spell or be affected by it.\nAn affected target can't take reactions and must roll a d10 at the start of each of its turns to determine its behavior for that turn.\nAt the end of each of its turns, an affected target can make a Wisdom saving throw. If it succeeds, this effect ends for that target.\nWhen you cast this spell using a spell slot of 5th level or higher, the radius of the sphere increases by 5 feet for each slot level above 4th.";
                case Spells.ID.CONJURE_ANIMALS:
                    return "You summon fey spirits that take the form of beasts and appear in unoccupied spaces that you can see within range. Choose one of the following options for what appears:\n- One beast of challenge rating 2 or lower\n- Two beasts of challenge rating 1 or lower\n- Four beasts of challenge rating 1/2 or lower\n- Eight beasts of challenge rating 1/4 or lower\n- Each beast is also considered fey, and it disappears when it drops to 0 hit points or when the spell ends.\nThe summoned creatures are friendly to you and your companions. Roll initiative for the summoned creatures as a group, which has its own turns. They obey any verbal commands that you issue to them (no action required by you). If you don't issue any commands to them, they defend themselves from hostile creatures, but otherwise take no actions.\nThe DM has the creatures' statistics.\nWhen you cast this spell using certain higher-level spell slots, you choose one of the summoning options above, and more creatures appear: twice as many with a 5th-level slot, three times as many with a 7th-level.";
                case Spells.ID.CONJURE_CELESTIAL:
                    return "You summon a celestial of challenge rating 4 or lower, which appears in an unoccupied space that you can see within range. The celestial disappears when it drops to 0 hit points or when the spell ends.\nThe celestial is friendly to you and your companions for the duration. Roll initiative for the celestial, which has its own turns. It obeys any verbal commands that you issue to it (no action required by you), as long as they don't violate its alignment. If you don't issue any commands to the celestial, it defends itself from hostile creatures but otherwise takes no actions.\nThe DM has the celestial's statistics.\nWhen you cast this spell using a 9th-level spell slot, you summon a celestial of challenge rating 5 or lower.";
                case Spells.ID.CONJURE_ELEMENTAL:
                    return "You call forth an elemental servant. Choose an area of air, earth, fire, or water that fills a 10-foot cube within range. An elemental of challenge rating 5 or lower appropriate to the area you chose appears in an unoccupied space within 10 feet of it. For example, a fire elemental emerges from a bonfire, and an earth elemental rises up from the ground. The elemental disappears when it drops to 0 hit points or when the spell ends.\nThe elemental is friendly to you and your companions for the duration. Roll initiative for the elemental, which has its own turns. It obeys any verbal commands that you issue to it (no action required by you). If you don't issue any commands to the elemental, it defends itself from hostile creatures but otherwise takes no actions.\nIf your concentration is broken, the elemental doesn't disappear. Instead, you lose control of the elemental, it becomes hostile toward you and your companions, and it might attack. An uncontrolled elemental can't be dismissed by you, and it disappears 1 hour after you summoned it.\nThe DM has the elemental's statistics.\nWhen you cast this spell using a spell slot of 6th level or higher, the challenge rating increases by 1 for each slot level above 5th.";
                case Spells.ID.CONJURE_FEY:
                    return "You summon a fey creature of challenge rating 6 or lower, or a fey spirit that takes the form of a beast of challenge rating 6 or lower. It appears in an unoccupied space that you can see within range. The fey creature disappears when it drops to 0 hit points or when the spell ends.\nThe fey creature is friendly to you and your companions for the duration. Roll initiative for the creature, which has its own turns. It obeys any verbal commands that you issue to it (no action required by you), as long as they don't violate its alignment. If you don't issue any commands to the fey creature, it defends itself from hostile creatures but otherwise takes no actions.\nIf your concentration is broken, the fey creature doesn't disappear. Instead, you lose control of the fey creature, it becomes hostile toward you and your companions, and it might attack. An uncontrolled fey creature can't be dismissed by you, and it disappears 1 hour after you summoned it.\nThe DM has the fey creature's statistics.\nWhen you cast this spell using a spell slot of 7th level or higher, the challenge rating increases by 1 for each slot level above 6th.";
                case Spells.ID.CONJURE_MINOR_ELEMENTALS:
                    return "You summon elementals that appear in unoccupied spaces that you can see within range. You choose one the following options for what appears:\n- One elemental of challenge rating 2 or lower\n- Two elementals of challenge rating 1 or lower\n- Four elementals of challenge rating 1/2 or lower\n- Eight elementals of challenge rating 1/4 or lower.\nAn elemental summoned by this spell disappears when it drops to 0 hit points or when the spell ends.\nThe summoned creatures are friendly to you and your companions. Roll initiative for the summoned creatures as a group, which has its own turns. They obey any verbal commands that you issue to them (no action required by you). If you don't issue any commands to them, they defend themselves from hostile creatures, but otherwise take no actions.\nThe DM has the creatures' statistics.\nWhen you cast this spell using certain higher-level spell slots, you choose one of the summoning options above, and more creatures appear: twice as many with a 6th-level slot and three times as many with an 8th-level slot.";
                case Spells.ID.CONJURE_WOODLAND_BEINGS:
                    return "You summon fey creatures that appear in unoccupied spaces that you can see within range. Choose one of the following options for what appears:\n- One fey creature of challenge rating 2 or lower\n- Two fey creatures of challenge rating 1 or lower\n- Four fey creatures of challenge rating 1/2 or lower\n- Eight fey creatures of challenge rating 1/4 or lower\nA summoned creature disappears when it drops to 0 hit points or when the spell ends.\nThe summoned creatures are friendly to you and your companions. Roll initiative for the summoned creatures as a group, which have their own turns. They obey any verbal commands that you issue to them (no action required by you). If you don't issue any commands to them, they defend themselves from hostile creatures, but otherwise take no actions.\nThe DM has the creatures' statistics.\nWhen you cast this spell using certain higher-level spell slots, you choose one of the summoning options above, and more creatures appear: twice as many with a 6th-level slot and three times as many with an 8th-level slot.";
                case Spells.ID.CONTACT_OTHER_PLANE:
                    return "You mentally contact a demigod, the spirit of a long-dead sage, or some other mysterious entity from another plane. Contacting this extraplanar intelligence can strain or even break your mind. When you cast this spell, make a DC 15 intelligence saving throw. On a failure, you take 6d6 psychic damage and are insane until you finish a long rest. While insane, you can't take actions, can't understand what other creatures say, can't read, and speak only in gibberish. A greater restoration spell cast on you ends this effect.\nOn a successful save, you can ask the entity up to five questions. You must ask your questions before the spell ends. The DM answers each question with one word, such as \"yes,\" \"no,\" \"maybe,\" \"never,\" \"irrelevant,\" or \"unclear\" (if the entity doesn't know the answer to the question). If a one-word answer would be misleading, the DM might instead offer a short phrase as an answer.";
                case Spells.ID.CONTAGION:
                    return "Your touch inflicts disease. Make a melee spell attack against a creature within your reach. On a hit, you afflict the creature with a disease of your choice from any of the ones described below.\nAt the end of each of the target's turns, it must make a constitution saving throw. After failing three of these saving throws, the disease's effects last for the duration, and the creature stops making these saves. After succeeding on three of these saving throws, the creature recovers from the disease, and the spell ends.\nSince this spell induces a natural disease in its target, any effect that removes a disease or otherwise ameliorates a disease's effects apply to it.\n***Blinding Sickness.*** Pain grips the creature's mind, and its eyes turn milky white. The creature has disadvantage on wisdom checks and wisdom saving throws and is blinded.\n***Filth Fever.*** A raging fever sweeps through the creature's body. The creature has disadvantage on strength checks, strength saving throws, and attack rolls that use Strength.\n***Flesh Rot.*** The creature's flesh decays. The creature has disadvantage on Charisma checks and vulnerability to all damage.\n***Mindfire.*** The creature's mind becomes feverish. The creature has disadvantage on intelligence checks and intelligence saving throws, and the creature behaves as if under the effects of the confusion spell during combat.\n***Seizure.*** The creature is overcome with shaking. The creature has disadvantage on dexterity checks, dexterity saving throws, and attack rolls that use Dexterity.\n***Slimy Doom.*** The creature begins to bleed uncontrollably. The creature has disadvantage on constitution checks and constitution saving throws. In addition, whenever the creature takes damage, it is stunned until the end of its next turn.";
                case Spells.ID.CONTINGENCY:
                    return "Choose a spell of 5th level or lower that you can cast, that has a casting time of 1 action, and that can target you. You cast that spell--called the contingent spell--as part of casting contingency, expending spell slots for both, but the contingent spell doesn't come into effect. Instead, it takes effect when a certain circumstance occurs. You describe that circumstance when you cast the two spells. For example, a contingency cast with water breathing might stipulate that water breathing comes into effect when you are engulfed in water or a similar liquid.\nThe contingent spell takes effect immediately after the circumstance is met for the first time, whether or not you want it to. and then contingency ends.\nThe contingent spell takes effect only on you, even if it can normally target others. You can use only one contingency spell at a time. If you cast this spell again, the effect of another contingency spell on you ends. Also, contingency ends on you if its material component is ever not on your person.";
                case Spells.ID.CONTINUAL_FLAME:
                    return "A flame, equivalent in brightness to a torch, springs forth from an object that you touch. The effect looks like a regular flame, but it creates no heat and doesn't use oxygen. A continual flame can be covered or hidden but not smothered or quenched.";
                case Spells.ID.CONTROL_WATER:
                    return "Until the spell ends, you control any freestanding water inside an area you choose that is a cube up to 100 feet on a side. You can choose from any of the following effects when you cast this spell. As an action on your turn, you can repeat the same effect or choose a different one.\n***Flood.*** You cause the water level of all standing water in the area to rise by as much as 20 feet. If the area includes a shore, the flooding water spills over onto dry land.\nIf you choose an area in a large body of water, you instead create a 20-foot tall wave that travels from one side of the area to the other and then crashes down. Any Huge or smaller vehicles in the wave's path are carried with it to the other side. Any Huge or smaller vehicles struck by the wave have a 25 percent chance of capsizing.\nThe water level remains elevated until the spell ends or you choose a different effect. If this effect produced a wave, the wave repeats on the start of your next turn while the flood effect lasts.\n***Part Water.*** You cause water in the area to move apart and create a trench. The trench extends across the spell's area, and the separated water forms a wall to either side. The trench remains until the spell ends or you choose a different effect. The water then slowly fills in the trench over the course of the next round until the normal water level is restored.\n***Redirect Flow.*** You cause flowing water in the area to move in a direction you choose, even if the water has to flow over obstacles, up walls, or in other unlikely directions. The water in the area moves as you direct it, but once it moves beyond the spell's area, it resumes its flow based on the terrain conditions. The water continues to move in the direction you chose until the spell ends or you choose a different effect.\n***Whirlpool.*** This effect requires a body of water at least 50 feet square and 25 feet deep. You cause a whirlpool to form in the center of the area. The whirlpool forms a vortex that is 5 feet wide at the base, up to 50 feet wide at the top, and 25 feet tall. Any creature or object in the water and within 25 feet of the vortex is pulled 10 feet toward it. A creature can swim away from the vortex by making a Strength (Athletics) check against your spell save DC.\nWhen a creature enters the vortex for the first time on a turn or starts its turn there, it must make a strength saving throw. On a failed save, the creature takes 2d8 bludgeoning damage and is caught in the vortex until the spell ends. On a successful save, the creature takes half damage, and isn't caught in the vortex. A creature caught in the vortex can use its action to try to swim away from the vortex as described above, but has disadvantage on the Strength (Athletics) check to do so.\nThe first time each turn that an object enters the vortex, the object takes 2d8 bludgeoning damage; this damage occurs each round it remains in the vortex.";
                case Spells.ID.CONTROL_WEATHER:
                    return "You take control of the weather within 5 miles of you for the duration. You must be outdoors to cast this spell. Moving to a place where you don't have a clear path to the sky ends the spell early.\nWhen you cast the spell, you change the current weather conditions, which are determined by the DM based on the climate and season. You can change precipitation, temperature, and wind. It takes 1d4 x 10 minutes for the new conditions to take effect. Once they do so, you can change the conditions again. When the spell ends, the weather gradually returns to normal.\nWhen you change the weather conditions, find a current condition on the following tables and change its stage by one, up or down. When changing the wind, you can change its direction.";
                case Spells.ID.COUNTERSPELL:
                    return "You attempt to interrupt a creature in the process of casting a spell. If the creature is casting a spell of 3rd level or lower, its spell fails and has no effect. If it is casting a spell of 4th level or higher, make an ability check using your spellcasting ability. The DC equals 10 + the spell's level. On a success, the creature's spell fails and has no effect.\nWhen you cast this spell using a spell slot of 4th level or higher, the interrupted spell has no effect if its level is less than or equal to the level of the spell slot you used.";
                case Spells.ID.CREATE_FOOD_AND_WATER:
                    return "You create 45 pounds of food and 30 gallons of water on the ground or in containers within range, enough to sustain up to fifteen humanoids or five steeds for 24 hours. The food is bland but nourishing, and spoils if uneaten after 24 hours. The water is clean and doesn't go bad.";
                case Spells.ID.CREATE_UNDEAD:
                    return "You can cast this spell only at night. Choose up to three corpses of Medium or Small humanoids within range. Each corpse becomes a ghoul under your control. (The DM has game statistics for these creatures.)\nAs a bonus action on each of your turns, you can mentally command any creature you animated with this spell if the creature is within 120 feet of you (if you control multiple creatures, you can command any or all of them at the same time, issuing the same command to each one). You decide what action the creature will take and where it will move during its next turn, or you can issue a general command, such as to guard a particular chamber or corridor. If you issue no commands, the creature only defends itself against hostile creatures. Once given an order, the creature continues to follow it until its task is complete.\nThe creature is under your control for 24 hours, after which it stops obeying any command you have given it. To maintain control of the creature for another 24 hours, you must cast this spell on the creature before the current 24-hour period ends. This use of the spell reasserts your control over up to three creatures you have animated with this spell, rather than animating new ones.\nWhen you cast this spell using a 7th-level spell slot, you can animate or reassert control over four ghouls. When you cast this spell using an 8th-level spell slot, you can animate or reassert control over five ghouls or two ghasts or wights. When you cast this spell using a 9th-level spell slot, you can animate or reassert control over six ghouls, three ghasts or wights, or two mummies.";
                case Spells.ID.CREATE_OR_DESTROY_WATER:
                    return "You either create or destroy water.\n***Create Water.*** You create up to 10 gallons of clean water within range in an open container. Alternatively, the water falls as rain in a 30-foot cube within range.\n***Destroy Water.*** You destroy up to 10 gallons of water in an open container within range. Alternatively, you destroy fog in a 30-foot cube within range.\nWhen you cast this spell using a spell slot of 2nd level or higher, you create or destroy 10 additional gallons of water, or the size of the cube increases by 5 feet, for each slot level above 1st.";
                case Spells.ID.CREATION:
                    return "You pull wisps of shadow material from the Shadowfell to create a nonliving object of vegetable matter within range: soft goods, rope, wood, or something similar. You can also use this spell to create mineral objects such as stone, crystal, or metal. The object created must be no larger than a 5-foot cube, and the object must be of a form and material that you have seen before.\nThe duration depends on the object's material. If the object is composed of multiple materials, use the shortest duration.\nUsing any material created by this spell as another spell's material component causes that spell to fail.\nWhen you cast this spell using a spell slot of 6th level or higher, the cube increases by 5 feet for each slot level above 5th.";
                case Spells.ID.CURE_WOUNDS:
                    return "A creature you touch regains a number of hit points equal to 1d8 + your spellcasting ability modifier. This spell has no effect on undead or constructs.\nWhen you cast this spell using a spell slot of 2nd level or higher, the healing increases by 1d8 for each slot level above 1st.";
                case Spells.ID.DANCING_LIGHTS:
                    return "You create up to four torch-sized lights within range, making them appear as torches, lanterns, or glowing orbs that hover in the air for the duration. You can also combine the four lights into one glowing vaguely humanoid form of Medium size. Whichever form you choose, each light sheds dim light in a 10-foot radius.\nAs a bonus action on your turn, you can move the lights up to 60 feet to a new spot within range. A light must be within 20 feet of another light created by this spell, and a light winks out if it exceeds the spell's range.";
                case Spells.ID.DARKNESS:
                    return "Magical darkness spreads from a point you choose within range to fill a 15-foot-radius sphere for the duration. The darkness spreads around corners. A creature with darkvision can't see through this darkness, and nonmagical light can't illuminate it.\nIf the point you choose is on an object you are holding or one that isn't being worn or carried, the darkness emanates from the object and moves with it. Completely covering the source of the darkness with an opaque object, such as a bowl or a helm, blocks the darkness.\nIf any of this spell's area overlaps with an area of light created by a spell of 2nd level or lower, the spell that created the light is dispelled.";
                case Spells.ID.DARKVISION:
                    return "You touch a willing creature to grant it the ability to see in the dark. For the duration, that creature has darkvision out to a range of 60 feet.";
                case Spells.ID.DAYLIGHT:
                    return "A 60-foot-radius sphere of light spreads out from a point you choose within range. The sphere is bright light and sheds dim light for an additional 60 feet.\nIf you chose a point on an object you are holding or one that isn't being worn or carried, the light shines from the object and moves with it. Completely covering the affected object with an opaque object, such as a bowl or a helm, blocks the light.\nIf any of this spell's area overlaps with an area of darkness created by a spell of 3rd level or lower, the spell that created the darkness is dispelled.";
                case Spells.ID.DEATH_WARD:
                    return "You touch a creature and grant it a measure of protection from death.\nThe first time the target would drop to 0 hit points as a result of taking damage, the target instead drops to 1 hit point, and the spell ends.\nIf the spell is still in effect when the target is subjected to an effect that would kill it instantaneously without dealing damage, that effect is instead negated against the target, and the spell ends.";
                case Spells.ID.DELAYED_BLAST_FIREBALL:
                    return "A beam of yellow light flashes from your pointing finger, then condenses to linger at a chosen point within range as a glowing bead for the duration. When the spell ends, either because your concentration is broken or because you decide to end it, the bead blossoms with a low roar into an explosion of flame that spreads around corners. Each creature in a 20-foot-radius sphere centered on that point must make a dexterity saving throw. A creature takes fire damage equal to the total accumulated damage on a failed save, or half as much damage on a successful one.\nThe spell's base damage is 12d6. If at the end of your turn the bead has not yet detonated, the damage increases by 1d6.\nIf the glowing bead is touched before the interval has expired, the creature touching it must make a dexterity saving throw. On a failed save, the spell ends immediately, causing the bead to erupt in flame. On a successful save, the creature can throw the bead up to 40 feet. When it strikes a creature or a solid object, the spell ends, and the bead explodes.\nThe fire damages objects in the area and ignites flammable objects that aren't being worn or carried.\nWhen you cast this spell using a spell slot of 8th level or higher, the base damage increases by 1d6 for each slot level above 7th.";
                case Spells.ID.DEMIPLANE:
                    return "You create a shadowy door on a flat solid surface that you can see within range. The door is large enough to allow Medium creatures to pass through unhindered. When opened, the door leads to a demiplane that appears to be an empty room 30 feet in each dimension, made of wood or stone. When the spell ends, the door disappears, and any creatures or objects inside the demiplane remain trapped there, as the door also disappears from the other side.\nEach time you cast this spell, you can create a new demiplane, or have the shadowy door connect to a demiplane you created with a previous casting of this spell. Additionally, if you know the nature and contents of a demiplane created by a casting of this spell by another creature, you can have the shadowy door connect to its demiplane instead.";
                case Spells.ID.DETECT_EVIL_AND_GOOD:
                    return "For the duration, you know if there is an aberration, celestial, elemental, fey, fiend, or undead within 30 feet of you, as well as where the creature is located. Similarly, you know if there is a place or object within 30 feet of you that has been magically consecrated or desecrated.\nThe spell can penetrate most barriers, but it is blocked by 1 foot of stone, 1 inch of common metal, a thin sheet of lead, or 3 feet of wood or dirt.";
                case Spells.ID.DETECT_MAGIC:
                    return "For the duration, you sense the presence of magic within 30 feet of you. If you sense magic in this way, you can use your action to see a faint aura around any visible creature or object in the area that bears magic, and you learn its school of magic, if any.\nThe spell can penetrate most barriers, but it is blocked by 1 foot of stone, 1 inch of common metal, a thin sheet of lead, or 3 feet of wood or dirt.";
                case Spells.ID.DETECT_POISON_AND_DISEASE:
                    return "For the duration, you can sense the presence and location of poisons, poisonous creatures, and diseases within 30 feet of you. You also identify the kind of poison, poisonous creature, or disease in each case.\nThe spell can penetrate most barriers, but it is blocked by 1 foot of stone, 1 inch of common metal, a thin sheet of lead, or 3 feet of wood or dirt.";
                case Spells.ID.DETECT_THOUGHTS:
                    return "For the duration, you can read the thoughts of certain creatures. When you cast the spell and as your action on each turn until the spell ends, you can focus your mind on any one creature that you can see within 30 feet of you. If the creature you choose has an Intelligence of 3 or lower or doesn't speak any language, the creature is unaffected.\nYou initially learn the surface thoughts of the creature - what is most on its mind in that moment. As an action, you can either shift your attention to another creature's thoughts or attempt to probe deeper into the same creature's mind. If you probe deeper, the target must make a Wisdom saving throw. If it fails, you gain insight into its reasoning (if any), its emotional state, and something that looms large in its mind (such as something it worries over, loves, or hates). If it succeeds, the spell ends. Either way, the target knows that you are probing into its mind, and unless you shift your attention to another creature's thoughts, the creature can use its action on its turn to make an Intelligence check contested by your Intelligence check; if it succeeds, the spell ends.\nQuestions verbally directed at the target creature naturally shape the course of its thoughts, so this spell is particularly effective as part of an interrogation.\nYou can also use this spell to detect the presence of thinking creatures you can't see. When you cast the spell or as your action during the duration, you can search for thoughts within 30 feet of you. The spell can penetrate barriers, but 2 feet of rock, 2 inches of any metal other than lead, or a thin sheet of lead blocks you. You can't detect a creature with an Intelligence of 3 or lower or one that doesn't speak any language.\nOnce you detect the presence of a creature in this way, you can read its thoughts for the rest of the duration as described above, even if you can't see it, but it must still be within range.";
                case Spells.ID.DIMENSION_DOOR:
                    return "You teleport yourself from your current location to any other spot within range. You arrive at exactly the spot desired. It can be a place you can see, one you can visualize, or one you can describe by stating distance and direction, such as \"200 feet straight downward\" or \"upward to the northwest at a 45-degree angle, 300 feet.\"\nYou can bring along objects as long as their weight doesn't exceed what you can carry. You can also bring one willing creature of your size or smaller who is carrying gear up to its carrying capacity. The creature must be within 5 feet of you when you cast this spell.\nIf you would arrive in a place already occupied by an object or a creature, you and any creature traveling with you each take 4d6 force damage, and the spell fails to teleport you.";
                case Spells.ID.DISGUISE_SELF:
                    return "You make yourself--including your clothing, armor, weapons, and other belongings on your person--look different until the spell ends or until you use your action to dismiss it. You can seem 1 foot shorter or taller and can appear thin, fat, or in between. You can't change your body type, so you must adopt a form that has the same basic arrangement of limbs. Otherwise, the extent of the illusion is up to you.\nThe changes wrought by this spell fail to hold up to physical inspection. For example, if you use this spell to add a hat to your outfit, objects pass through the hat, and anyone who touches it would feel nothing or would feel your head and hair. If you use this spell to appear thinner than you are, the hand of someone who reaches out to touch you would bump into you while it was seemingly still in midair.\nTo discern that you are disguised, a creature can use its action to inspect your appearance and must succeed on an Intelligence (Investigation) check against your spell save DC.";
                case Spells.ID.DISINTEGRATE:
                    return "A thin green ray springs from your pointing finger to a target that you can see within range. The target can be a creature, an object, or a creation of magical force, such as the wall created by wall of force.\nA creature targeted by this spell must make a dexterity saving throw. On a failed save, the target takes 10d6 + 40 force damage. If this damage reduces the target to 0 hit points, it is disintegrated.\nA disintegrated creature and everything it is wearing and carrying, except magic items, are reduced to a pile of fine gray dust. The creature can be restored to life only by means of a true resurrection or a wish spell.\nThis spell automatically disintegrates a Large or smaller nonmagical object or a creation of magical force. If the target is a Huge or larger object or creation of force, this spell disintegrates a 10-foot-cube portion of it. A magic item is unaffected by this spell.\nWhen you cast this spell using a spell slot of 7th level or higher, the damage increases by 3d6 for each slot level above 6th.";
                case Spells.ID.DISPEL_EVIL_AND_GOOD:
                    return "Shimmering energy surrounds and protects you from fey, undead, and creatures originating from beyond the Material Plane. For the duration, celestials, elementals, fey, fiends, and undead have disadvantage on attack rolls against you.\nYou can end the spell early by using either of the following special functions.\n***Break Enchantment.*** As your action, you touch a creature you can reach that is charmed, frightened, or possessed by a celestial, an elemental, a fey, a fiend, or an undead. The creature you touch is no longer charmed, frightened, or possessed by such creatures.\n***Dismissal.*** As your action, make a melee spell attack against a celestial, an elemental, a fey, a fiend, or an undead you can reach. On a hit, you attempt to drive the creature back to its home plane. The creature must succeed on a charisma saving throw or be sent back to its home plane (if it isn't there already). If they aren't on their home plane, undead are sent to the Shadowfell, and fey are sent to the Feywild.";
                case Spells.ID.DISPEL_MAGIC:
                    return "Choose one creature, object, or magical effect within range. Any spell of 3rd level or lower on the target ends. For each spell of 4th level or higher on the target, make an ability check using your spellcasting ability. The DC equals 10 + the spell's level. On a successful check, the spell ends.\nWhen you cast this spell using a spell slot of 4th level or higher, you automatically end the effects of a spell on the target if the spell's level is equal to or less than the level of the spell slot you used.";
                case Spells.ID.DIVINATION:
                    return "Your magic and an offering put you in contact with a god or a god's servants. You ask a single question concerning a specific goal, event, or activity to occur within 7 days. The DM offers a truthful reply. The reply might be a short phrase, a cryptic rhyme, or an omen.\nThe spell doesn't take into account any possible circumstances that might change the outcome, such as the casting of additional spells or the loss or gain of a companion.\nIf you cast the spell two or more times before finishing your next long rest, there is a cumulative 25 percent chance for each casting after the first that you get a random reading. The DM makes this roll in secret.";
                case Spells.ID.DIVINE_FAVOR:
                    return "Your prayer empowers you with divine radiance. Until the spell ends, your weapon attacks deal an extra 1d4 radiant damage on a hit.";
                case Spells.ID.DIVINE_WORD:
                    return "You utter a divine word, imbued with the power that shaped the world at the dawn of creation. Choose any number of creatures you can see within range. Each creature that can hear you must make a Charisma saving throw. On a failed save, a creature suffers an effect based on its current hit points:\n- 50 hit points or fewer: deafened for 1 minute\n- 40 hit points or fewer: deafened and blinded for 10 minutes\n- 30 hit points or fewer: blinded, deafened, and stunned for 1 hour\n- 20 hit points or fewer: killed instantly\nRegardless of its current hit points, a celestial, an elemental, a fey, or a fiend that fails its save is forced back to its plane of origin (if it isn't there already) and can't return to your current plane for 24 hours by any means short of a wish spell.";
                case Spells.ID.DOMINATE_BEAST:
                    return "You attempt to beguile a creature that you can see within range. It must succeed on a wisdom saving throw or be charmed by you for the duration. If you or creatures that are friendly to you are fighting it, it has advantage on the saving throw.\nWhile the creature is charmed, you have a telepathic link with it as long as the two of you are on the same plane of existence. You can use this telepathic link to issue commands to the creature while you are conscious (no action required), which it does its best to obey. You can specify a simple and general course of action, such as \"Attack that creature,\" \"Run over there,\" or \"Fetch that object.\" If the creature completes the order and doesn't receive further direction from you, it defends and preserves itself to the best of its ability.\nYou can use your action to take total and precise control of the target. Until the end of your next turn, the creature takes only the actions you choose, and doesn't do anything that you don't allow it to do. During this time, you can also cause the creature to use a reaction, but this requires you to use your own reaction as well. Each time the target takes damage, it makes a new wisdom saving throw against the spell. If the saving throw succeeds, the spell ends.\nWhen you cast this spell with a 9th level spell slot, the duration is concentration, up to 8 hours.";
                case Spells.ID.DOMINATE_MONSTER:
                    return "You attempt to beguile a creature that you can see within range. It must succeed on a wisdom saving throw or be charmed by you for the duration. If you or creatures that are friendly to you are fighting it, it has advantage on the saving throw.\nWhile the creature is charmed, you have a telepathic link with it as long as the two of you are on the same plane of existence. You can use this telepathic link to issue commands to the creature while you are conscious (no action required), which it does its best to obey. You can specify a simple and general course of action, such as \"Attack that creature,\" \"Run over there,\" or \"Fetch that object.\" If the creature completes the order and doesn't receive further direction from you, it defends and preserves itself to the best of its ability.\nYou can use your action to take total and precise control of the target. Until the end of your next turn, the creature takes only the actions you choose, and doesn't do anything that you don't allow it to do. During this time, you can also cause the creature to use a reaction, but this requires you to use your own reaction as well.\nEach time the target takes damage, it makes a new wisdom saving throw against the spell. If the saving throw succeeds, the spell ends.\nWhen you cast this spell with a 9th-level spell slot, the duration is concentration, up to 8 hours.";
                case Spells.ID.DOMINATE_PERSON:
                    return "You attempt to beguile a humanoid that you can see within range. It must succeed on a wisdom saving throw or be charmed by you for the duration. If you or creatures that are friendly to you are fighting it, it has advantage on the saving throw.\nWhile the target is charmed, you have a telepathic link with it as long as the two of you are on the same plane of existence. You can use this telepathic link to issue commands to the creature while you are conscious (no action required), which it does its best to obey. You can specify a simple and general course of action, such as \"Attack that creature,\" \"Run over there,\" or \"Fetch that object.\" If the creature completes the order and doesn't receive further direction from you, it defends and preserves itself to the best of its ability.\nYou can use your action to take total and precise control of the target. Until the end of your next turn, the creature takes only the actions you choose, and doesn't do anything that you don't allow it to do. During this time you can also cause the creature to use a reaction, but this requires you to use your own reaction as well.\nEach time the target takes damage, it makes a new wisdom saving throw against the spell. If the saving throw succeeds, the spell ends.\nWhen you cast this spell using a 6th-level spell slot, the duration is concentration, up to 10 minutes. When you use a 7th-level spell slot, the duration is concentration, up to 1 hour. When you use a spell slot of 8th level or higher, the duration is concentration, up to 8 hours.";
                case Spells.ID.DREAM:
                    return "This spell shapes a creature's dreams. Choose a creature known to you as the target of this spell. The target must be on the same plane of existence as you. Creatures that don't sleep, such as elves, can't be contacted by this spell. You, or a willing creature you touch, enters a trance state, acting as a messenger.\nWhile in the trance, the messenger is aware of his or her surroundings, but can't take actions or move.\nIf the target is asleep, the messenger appears in the target's dreams and can converse with the target as long as it remains asleep, through the duration of the spell. The messenger can also shape the environment of the dream, creating landscapes, objects, and other images. The messenger can emerge from the trance at any time, ending the effect of the spell early. The target recalls the dream perfectly upon waking. If the target is awake when you cast the spell, the messenger knows it, and can either end the trance (and the spell) or wait for the target to fall asleep, at which point the messenger appears in the target's dreams.\nYou can make the messenger appear monstrous and terrifying to the target. If you do, the messenger can deliver a message of no more than ten words and then the target must make a wisdom saving throw. On a failed save, echoes of the phantasmal monstrosity spawn a nightmare that lasts the duration of the target's sleep and prevents the target from gaining any benefit from that rest. In addition, when the target wakes up, it takes 3d6 psychic damage.\nIf you have a body part, lock of hair, clipping from a nail, or similar portion of the target's body, the target makes its saving throw with disadvantage.";
                case Spells.ID.DRUIDCRAFT:
                    return "Whispering to the spirits of nature, you create one of the following effects within 'range':\n- You create a tiny, harmless sensory effect that predicts what the weather will be at your location for the next 24 hours. The effect might manifest as a golden orb for clear skies, a cloud for rain, falling snowflakes for snow, and so on. This effect persists for 1 round.\n- You instantly make a flower bloom, a seed pod open, or a leaf bud bloom.\n- You create an instantaneous, harmless sensory effect, such as falling leaves, a puff of wind, the sound of a small animal, or the faint order of skunk. The effect must fit in a 5-foot cube.\n- You instantly light or snuff out a candle, a torch, or a small campfire.";
                case Spells.ID.EARTHQUAKE:
                    return "You create a seismic disturbance at a point on the ground that you can see within range. For the duration, an intense tremor rips through the ground in a 100-foot-radius circle centered on that point and shakes creatures and structures in contact with the ground in that area.\nThe ground in the area becomes difficult terrain. Each creature on the ground that is concentrating must make a constitution saving throw. On a failed save, the creature's concentration is broken.\nWhen you cast this spell and at the end of each turn you spend concentrating on it, each creature on the ground in the area must make a dexterity saving throw. On a failed save, the creature is knocked prone.\nThis spell can have additional effects depending on the terrain in the area, as determined by the DM.\nFissures. Fissures open throughout the spell's area at the start of your next turn after you cast the spell. A total of 1d6 such fissures open in locations chosen by the DM. Each is 1d10 x 10 feet deep, 10 feet wide, and extends from one edge of the spell's area to the opposite side. A creature standing on a spot where a fissure opens must succeed on a dexterity saving throw or fall in. A creature that successfully saves moves with the fissure's edge as it opens.\nA fissure that opens beneath a structure causes it to automatically collapse (see below).\nStructures. The tremor deals 50 bludgeoning damage to any structure in contact with the ground in the area when you cast the spell and at the start of each of your turns until the spell ends. If a structure drops to 0 hit points, it collapses and potentially damages nearby creatures. A creature within half the distance of a structure's height must make a dexterity saving throw. On a failed save, the creature takes 5d6 bludgeoning damage, is knocked prone, and is buried in the rubble, requiring a DC 20 Strength (Athletics) check as an action to escape. The DM can adjust the DC higher or lower, depending on the nature of the rubble. On a successful save, the creature takes half as much damage and doesn't fall prone or become buried.";
                case Spells.ID.ELDRITCH_BLAST:
                    return "A beam of crackling energy streaks toward a creature within range. Make a ranged spell attack against the target. On a hit, the target takes 1d10 force damage. The spell creates more than one beam when you reach higher levels: two beams at 5th level, three beams at 11th level, and four beams at 17th level. You can direct the beams at the same target or at different ones. Make a separate attack roll for each beam.";
                case Spells.ID.ENHANCE_ABILITY:
                    return "You touch a creature and bestow upon it a magical enhancement. Choose one of the following effects; the target gains that effect until the spell ends.\n***Bear's Endurance.*** The target has advantage on constitution checks. It also gains 2d6 temporary hit points, which are lost when the spell ends.\n***Bull's Strength.*** The target has advantage on strength checks, and his or her carrying capacity doubles.\n***Cat's Grace.*** The target has advantage on dexterity checks. It also doesn't take damage from falling 20 feet or less if it isn't incapacitated.\n***Eagle's Splendor.*** The target has advantage on Charisma checks.\n***Fox's Cunning.*** The target has advantage on intelligence checks.\n***Owl's Wisdom.*** The target has advantage on wisdom checks.\nWhen you cast this spell using a spell slot of 3rd level or higher, you can target one additional creature for each slot level above 2nd.";
                case Spells.ID.ENLARGE_REDUCE:
                    return "You cause a creature or an object you can see within range to grow larger or smaller for the duration. Choose either a creature or an object that is neither worn nor carried. If the target is unwilling, it can make a Constitution saving throw. On a success, the spell has no effect.\nIf the target is a creature, everything it is wearing and carrying changes size with it. Any item dropped by an affected creature returns to normal size at once.\n***Enlarge.*** The target's size doubles in all dimensions, and its weight is multiplied by eight. This growth increases its size by one category-from Medium to Large, for example. If there isn't enough room for the target to double its size, the creature or object attains the maximum possible size in the space available. Until the spell ends, the target also has advantage on Strength checks and Strength saving throws. The target's weapons also grow to match its new size. While these weapons are enlarged, the target's attacks with them deal 1d4 extra damage.\n***Reduce.*** The target's size is halved in all dimensions, and its weight is reduced to one-eighth of normal. This reduction decreases its size by one category-from Medium to Small, for example. Until the spell ends, the target also has disadvantage on Strength checks and Strength saving throws. The target's weapons also shrink to match its new size. While these weapons are reduced, the target's attacks with them deal 1d4 less damage (this can't reduce the damage below 1).";
                case Spells.ID.ENTANGLE:
                    return "Grasping weeds and vines sprout from the ground in a 20-foot square starting form a point within range. For the duration, these plants turn the ground in the area into difficult terrain.\nA creature in the area when you cast the spell must succeed on a strength saving throw or be restrained by the entangling plants until the spell ends. A creature restrained by the plants can use its action to make a Strength check against your spell save DC. On a success, it frees itself.\nWhen the spell ends, the conjured plants wilt away.";
                case Spells.ID.ENTHRALL:
                    return "You weave a distracting string of words, causing creatures of your choice that you can see within range and that can hear you to make a wisdom saving throw. Any creature that can't be charmed succeeds on this saving throw automatically, and if you or your companions are fighting a creature, it has advantage on the save. On a failed save, the target has disadvantage on Wisdom (Perception) checks made to perceive any creature other than you until the spell ends or until the target can no longer hear you. The spell ends if you are incapacitated or can no longer speak.";
                case Spells.ID.ETHEREALNESS:
                    return "You step into the border regions of the Ethereal Plane, in the area where it overlaps with your current plane. You remain in the Border Ethereal for the duration or until you use your action to dismiss the spell. During this time, you can move in any direction. If you move up or down, every foot of movement costs an extra foot. You can see and hear the plane you originated from, but everything there looks gray, and you can't see anything more than 60 feet away.\nWhile on the Ethereal Plane, you can only affect and be affected by other creatures on that plane. Creatures that aren't on the Ethereal Plane can't perceive you and can't interact with you, unless a special ability or magic has given them the ability to do so.\nYou ignore all objects and effects that aren't on the Ethereal Plane, allowing you to move through objects you perceive on the plane you originated from.\nWhen the spell ends, you immediately return to the plane you originated from in the spot you currently occupy. If you occupy the same spot as a solid object or creature when this happens, you are immediately shunted to the nearest unoccupied space that you can occupy and take force damage equal to twice the number of feet you are moved.\nThis spell has no effect if you cast it while you are on the Ethereal Plane or a plane that doesn't border it, such as one of the Outer Planes.\nWhen you cast this spell using a spell slot of 8th level or higher, you can target up to three willing creatures (including you) for each slot level above 7th. The creatures must be within 10 feet of you when you cast the spell.";
                case Spells.ID.EXPEDITIOUS_RETREAT:
                    return "This spell allows you to move at an incredible pace. When you cast this spell, and then as a bonus action on each of your turns until the spell ends, you can take the Dash action.";
                case Spells.ID.EYEBITE:
                    return "For the spell's duration, your eyes become an inky void imbued with dread power. One creature of your choice within 60 feet of you that you can see must succeed on a wisdom saving throw or be affected by one of the following effects of your choice for the duration. On each of your turns until the spell ends, you can use your action to target another creature but can't target a creature again if it has succeeded on a saving throw against this casting of eyebite.\n***Asleep.*** The target falls unconscious. It wakes up if it takes any damage or if another creature uses its action to shake the sleeper awake.\n***Panicked.*** The target is frightened of you. On each of its turns, the frightened creature must take the Dash action and move away from you by the safest and shortest available route, unless there is nowhere to move. If the target moves to a place at least 60 feet away from you where it can no longer see you, this effect ends.\n***Sickened.*** The target has disadvantage on attack rolls and ability checks. At the end of each of its turns, it can make another wisdom saving throw. If it succeeds, the effect ends.";
                case Spells.ID.FABRICATE:
                    return "You convert raw materials into products of the same material. For example, you can fabricate a wooden bridge from a clump of trees, a rope from a patch of hemp, and clothes from flax or wool.\nChoose raw materials that you can see within range. You can fabricate a Large or smaller object (contained within a 10-foot cube, or eight connected 5-foot cubes), given a sufficient quantity of raw material. If you are working with metal, stone, or another mineral substance, however, the fabricated object can be no larger than Medium (contained within a single 5-foot cube). The quality of objects made by the spell is commensurate with the quality of the raw materials.\nCreatures or magic items can't be created or transmuted by this spell. You also can't use it to create items that ordinarily require a high degree of craftsmanship, such as jewelry, weapons, glass, or armor, unless you have proficiency with the type of artisan's tools used to craft such objects.";
                case Spells.ID.FAERIE_FIRE:
                    return "Each object in a 20-foot cube within range is outlined in blue, green, or violet light (your choice). Any creature in the area when the spell is cast is also outlined in light if it fails a dexterity saving throw. For the duration, objects and affected creatures shed dim light in a 10-foot radius.\nAny attack roll against an affected creature or object has advantage if the attacker can see it, and the affected creature or object can't benefit from being invisible.";
                case Spells.ID.FAITHFUL_HOUND:
                    return "You conjure a phantom watchdog in an unoccupied space that you can see within range, where it remains for the duration, until you dismiss it as an action, or until you move more than 100 feet away from it.\nThe hound is invisible to all creatures except you and can't be harmed. When a Small or larger creature comes within 30 feet of it without first speaking the password that you specify when you cast this spell, the hound starts barking loudly. The hound sees invisible creatures and can see into the Ethereal Plane. It ignores illusions.\nAt the start of each of your turns, the hound attempts to bite one creature within 5 feet of it that is hostile to you. The hound's attack bonus is equal to your spellcasting ability modifier + your proficiency bonus. On a hit, it deals 4d8 piercing damage.";
                case Spells.ID.FALSE_LIFE:
                    return "Bolstering yourself with a necromantic facsimile of life, you gain 1d4 + 4 temporary hit points for the duration.\nWhen you cast this spell using a spell slot of 2nd level or higher, you gain 5 additional temporary hit points for each slot level above 1st.";
                case Spells.ID.FEAR:
                    return "You project a phantasmal image of a creature's worst fears. Each creature in a 30-foot cone must succeed on a wisdom saving throw or drop whatever it is holding and become frightened for the duration.\nWhile frightened by this spell, a creature must take the Dash action and move away from you by the safest available route on each of its turns, unless there is nowhere to move. If the creature ends its turn in a location where it doesn't have line of sight to you, the creature can make a wisdom saving throw. On a successful save, the spell ends for that creature.";
                case Spells.ID.FEATHER_FALL:
                    return "Choose up to five falling creatures within range. A falling creature's rate of descent slows to 60 feet per round until the spell ends. If the creature lands before the spell ends, it takes no falling damage and can land on its feet, and the spell ends for that creature.";
                case Spells.ID.FEEBLEMIND:
                    return "You blast the mind of a creature that you can see within range, attempting to shatter its intellect and personality. The target takes 4d6 psychic damage and must make an intelligence saving throw.\nOn a failed save, the creature's Intelligence and Charisma scores become 1. The creature can't cast spells, activate magic items, understand language, or communicate in any intelligible way. The creature can, however, identify its friends, follow them, and even protect them.\nAt the end of every 30 days, the creature can repeat its saving throw against this spell. If it succeeds on its saving throw, the spell ends.\nThe spell can also be ended by greater restoration, heal, or wish.";
                case Spells.ID.FIND_FAMILIAR:
                    return "You gain the service of a familiar, a spirit that takes an animal form you choose: bat, cat, crab, frog (toad), hawk, lizard, octopus, owl, poisonous snake, fish (quipper), rat, raven, sea horse, spider, or weasel. Appearing in an unoccupied space within range, the familiar has the statistics of the chosen form, though it is a celestial, fey, or fiend (your choice) instead of a beast.\nYour familiar acts independently of you, but it always obeys your commands. In combat, it rolls its own initiative and acts on its own turn. A familiar can't attack, but it can take other actions as normal.\nWhen the familiar drops to 0 hit points, it disappears, leaving behind no physical form. It reappears after you cast this spell again.\nWhile your familiar is within 100 feet of you, you can communicate with it telepathically. Additionally, as an action, you can see through your familiar's eyes and hear what it hears until the start of your next turn, gaining the benefits of any special senses that the familiar has. During this time, you are deaf and blind with regard to your own senses.\nAs an action, you can temporarily dismiss your familiar. It disappears into a pocket dimension where it awaits your summons. Alternatively, you can dismiss it forever. As an action while it is temporarily dismissed, you can cause it to reappear in any unoccupied space within 30 feet of you.\nYou can't have more than one familiar at a time. If you cast this spell while you already have a familiar, you instead cause it to adopt a new form. Choose one of the forms from the above list. Your familiar transforms into the chosen creature.\nFinally, when you cast a spell with a range of touch, your familiar can deliver the spell as if it had cast the spell. Your familiar must be within 100 feet of you, and it must use its reaction to deliver the spell when you cast it. If the spell requires an attack roll, you use your action modifier for the roll.";
                case Spells.ID.FIND_STEED:
                    return "You summon a spirit that assumes the form of an unusually intelligent, strong, and loyal steed, creating a long-lasting bond with it. Appearing in an unoccupied space within range, the steed takes on a form that you choose, such as a warhorse, a pony, a camel, an elk, or a mastiff. (Your DM might allow other animals to be summoned as steeds.) The steed has the statistics of the chosen form, though it is a celestial, fey, or fiend (your choice) instead of its normal type. Additionally, if your steed has an Intelligence of 5 or less, its Intelligence becomes 6, and it gains the ability to understand one language of your choice that you speak.\nYour steed serves you as a mount, both in combat and out, and you have an instinctive bond with it that allows you to fight as a seamless unit. While mounted on your steed, you can make any spell you cast that targets only you also target your steed.\nWhen the steed drops to 0 hit points, it disappears, leaving behind no physical form. You can also dismiss your steed at any time as an action, causing it to disappear. In either case, casting this spell again summons the same steed, restored to its hit point maximum.\nWhile your steed is within 1 mile of you, you can communicate with it telepathically.\nYou can't have more than one steed bonded by this spell at a time. As an action, you can release the steed from its bond at any time, causing it to disappear.";
                case Spells.ID.FIND_TRAPS:
                    return "You sense the presence of any trap within range that is within line of sight. A trap, for the purpose of this spell, includes anything that would inflict a sudden or unexpected effect you consider harmful or undesirable, which was specifically intended as such by its creator. Thus, the spell would sense an area affected by the alarm spell, a glyph of warding, or a mechanical pit trap, but it would not reveal a natural weakness in the floor, an unstable ceiling, or a hidden sinkhole.\nThis spell merely reveals that a trap is present. You don't learn the location of each trap, but you do learn the general nature of the danger posed by a trap you sense.";
                case Spells.ID.FIND_THE_PATH:
                    return "This spell allows you to find the shortest, most direct physical route to a specific fixed location that you are familiar with on the same plane of existence. If you name a destination on another plane of existence, a destination that moves (such as a mobile fortress), or a destination that isn't specific (such as \"a green dragon's lair\"), the spell fails.\nFor the duration, as long as you are on the same plane of existence as the destination, you know how far it is and in what direction it lies. While you are traveling there, whenever you are presented with a choice of paths along the way, you automatically determine which path is the shortest and most direct route (but not necessarily the safest route) to the destination.";
                case Spells.ID.FINGER_OF_DEATH:
                    return "You send negative energy coursing through a creature that you can see within range, causing it searing pain. The target must make a constitution saving throw. It takes 7d8 + 30 necrotic damage on a failed save, or half as much damage on a successful one.\nA humanoid killed by this spell rises at the start of your next turn as a zombie that is permanently under your command, following your verbal orders to the best of its ability.";
                case Spells.ID.FIRE_BOLT:
                    return "You hurl a mote of fire at a creature or object within range. Make a ranged spell attack against the target. On a hit, the target takes 1d10 fire damage. A flammable object hit by this spell ignites if it isn't being worn or carried.\nThis spell's damage increases by 1d10 when you reach 5th level (2d10), 11th level (3d10), and 17th level (4d10).";
                case Spells.ID.FIRE_SHIELD:
                    return "Thin and vaporous flame surround your body for the duration of the spell, radiating a bright light bright light in a 10-foot radius and dim light for an additional 10 feet. You can end the spell using an action to make it disappear.\nThe flames are around you a heat shield or cold, your choice. The heat shield gives you cold damage resistance and the cold resistance to fire damage.\nIn addition, whenever a creature within 5 feet of you hits you with a melee attack, flames spring from the shield. The attacker then suffers 2d8 points of fire damage or cold, depending on the model.";
                case Spells.ID.FIRE_STORM:
                    return "A storm made up of sheets of roaring flame appears in a location you choose within range. The area of the storm consists of up to ten 10-foot cubes, which you can arrange as you wish. Each cube must have at least one face adjacent to the face of another cube. Each creature in the area must make a dexterity saving throw. It takes 7d10 fire damage on a failed save, or half as much damage on a successful one.\nThe fire damages objects in the area and ignites flammable objects that aren't being worn or carried. If you choose, plant life in the area is unaffected by this spell.";
                case Spells.ID.FIREBALL:
                    return "A bright streak flashes from your pointing finger to a point you choose within range and then blossoms with a low roar into an explosion of flame. Each creature in a 20-foot-radius sphere centered on that point must make a dexterity saving throw. A target takes 8d6 fire damage on a failed save, or half as much damage on a successful one.\nThe fire spreads around corners. It ignites flammable objects in the area that aren't being worn or carried.\nWhen you cast this spell using a spell slot of 4th level or higher, the damage increases by 1d6 for each slot level above 3rd.";
                case Spells.ID.FLAME_BLADE:
                    return "You evoke a fiery blade in your free hand. The blade is similar in size and shape to a scimitar, and it lasts for the duration. If you let go of the blade, it disappears, but you can evoke the blade again as a bonus action.\nYou can use your action to make a melee spell attack with the fiery blade. On a hit, the target takes 3d6 fire damage.\nThe flaming blade sheds bright light in a 10-foot radius and dim light for an additional 10 feet.\nWhen you cast this spell using a spell slot of 4th level or higher, the damage increases by 1d6 for every two slot levels above 2nd.";
                case Spells.ID.FLAME_STRIKE:
                    return "A vertical column of divine fire roars down from the heavens in a location you specify. Each creature in a 10-foot-radius, 40-foot-high cylinder centered on a point within range must make a dexterity saving throw. A creature takes 4d6 fire damage and 4d6 radiant damage on a failed save, or half as much damage on a successful one.\nWhen you cast this spell using a spell slot of 6th level or higher, the fire damage or the radiant damage (your choice) increases by 1d6 for each slot level above 5th.";
                case Spells.ID.FLAMING_SPHERE:
                    return "A 5-foot-diameter sphere of fire appears in an unoccupied space of your choice within range and lasts for the duration. Any creature that ends its turn within 5 feet of the sphere must make a dexterity saving throw. The creature takes 2d6 fire damage on a failed save, or half as much damage on a successful one.\nAs a bonus action, you can move the sphere up to 30 feet. If you ram the sphere into a creature, that creature must make the saving throw against the sphere's damage, and the sphere stops moving this turn.\nWhen you move the sphere, you can direct it over barriers up to 5 feet tall and jump it across pits up to 10 feet wide. The sphere ignites flammable objects not being worn or carried, and it sheds bright light in a 20-foot radius and dim light for an additional 20 feet.\nWhen you cast this spell using a spell slot of 3rd level or higher, the damage increases by 1d6 for each slot level above 2nd.";
                case Spells.ID.FLESH_TO_STONE:
                    return "You attempt to turn one creature that you can see within range into stone. If the target's body is made of flesh, the creature must make a constitution saving throw. On a failed save, it is restrained as its flesh begins to harden. On a successful save, the creature isn't affected.\nA creature restrained by this spell must make another constitution saving throw at the end of each of its turns. If it successfully saves against this spell three times, the spell ends. If it fails its saves three times, it is turned to stone and subjected to the petrified condition for the duration. The successes and failures don't need to be consecutive; keep track of both until the target collects three of a kind.\nIf the creature is physically broken while petrified, it suffers from similar deformities if it reverts to its original state.\nIf you maintain your concentration on this spell for the entire possible duration, the creature is turned to stone until the effect is removed.";
                case Spells.ID.FLOATING_DISK:
                    return "This spell creates a circular, horizontal plane of force, 3 feet in diameter and 1 inch thick, that floats 3 feet above the ground in an unoccupied space of your choice that you can see within range. The disk remains for the duration, and can hold up to 500 pounds. If more weight is placed on it, the spell ends, and everything on the disk falls to the ground.\nThe disk is immobile while you are within 20 feet of it. If you move more than 20 feet away from it, the disk follows you so that it remains within 20 feet of you. If can move across uneven terrain, up or down stairs, slopes and the like, but it can't cross an elevation change of 10 feet or more. For example, the disk can't move across a 10-foot-deep pit, nor could it leave such a pit if it was created at the bottom.\nIf you move more than 100 feet away from the disk (typically because it can't move around an obstacle to follow you), the spell ends.";
                case Spells.ID.FLY:
                    return "You touch a willing creature. The target gains a flying speed of 60 feet for the duration. When the spell ends, the target falls if it is still aloft, unless it can stop the fall.\nWhen you cast this spell using a spell slot of 4th level or higher, you can target one additional creature for each slot level above 3rd.";
                case Spells.ID.FOG_CLOUD:
                    return "You create a 20-foot-radius sphere of fog centered on a point within range. The sphere spreads around corners, and its area is heavily obscured. It lasts for the duration or until a wind of moderate or greater speed (at least 10 miles per hour) disperses it.\nWhen you cast this spell using a spell slot of 2nd level or higher, the radius of the fog increases by 20 feet for each slot level above 1st.";
                case Spells.ID.FORBIDDANCE:
                    return "You create a ward against magical travel that protects up to 40,000 square feet of floor space to a height of 30 feet above the floor. For the duration, creatures can't teleport into the area or use portals, such as those created by the gate spell, to enter the area. The spell proofs the area against planar travel, and therefore prevents creatures from accessing the area by way of the Astral Plane, Ethereal Plane, Feywild, Shadowfell, or the plane shift spell.\nIn addition, the spell damages types of creatures that you choose when you cast it. Choose one or more of the following: celestials, elementals, fey, fiends, and undead. When a chosen creature enters the spell's area for the first time on a turn or starts its turn there, the creature takes 5d10 radiant or necrotic damage (your choice when you cast this spell).\nWhen you cast this spell, you can designate a password. A creature that speaks the password as it enters the area takes no damage from the spell.\nThe spell's area can't overlap with the area of another forbiddance spell. If you cast forbiddance every day for 30 days in the same location, the spell lasts until it is dispelled, and the material components are consumed on the last casting.";
                case Spells.ID.FORCECAGE:
                    return "An immobile, invisible, cube-shaped prison composed of magical force springs into existence around an area you choose within range. The prison can be a cage or a solid box, as you choose.\nA prison in the shape of a cage can be up to 20 feet on a side and is made from 1/2-inch diameter bars spaced 1/2 inch apart.\nA prison in the shape of a box can be up to 10 feet on a side, creating a solid barrier that prevents any matter from passing through it and blocking any spells cast into or out from the area.\nWhen you cast the spell, any creature that is completely inside the cage's area is trapped. Creatures only partially within the area, or those too large to fit inside the area, are pushed away from the center of the area until they are completely outside the area.\nA creature inside the cage can't leave it by nonmagical means. If the creature tries to use teleportation or interplanar travel to leave the cage, it must first make a charisma saving throw. On a success, the creature can use that magic to exit the cage. On a failure, the creature can't exit the cage and wastes the use of the spell or effect. The cage also extends into the Ethereal Plane, blocking ethereal travel.\nThis spell can't be dispelled by dispel magic.";
                case Spells.ID.FORESIGHT:
                    return "You touch a willing creature and bestow a limited ability to see into the immediate future. For the duration, the target can't be surprised and has advantage on attack rolls, ability checks, and saving throws. Additionally, other creatures have disadvantage on attack rolls against the target for the duration.\nThis spell immediately ends if you cast it again before its duration ends.";
                case Spells.ID.FREEDOM_OF_MOVEMENT:
                    return "You touch a willing creature. For the duration, the target's movement is unaffected by difficult terrain, and spells and other magical effects can neither reduce the target's speed nor cause the target to be paralyzed or restrained.\nThe target can also spend 5 feet of movement to automatically escape from nonmagical restraints, such as manacles or a creature that has it grappled. Finally, being underwater imposes no penalties on the target's movement or attacks.";
                case Spells.ID.FREEZING_SPHERE:
                    return "A frigid globe of cold energy streaks from your fingertips to a point of your choice within range, where it explodes in a 60-foot-radius sphere. Each creature within the area must make a constitution saving throw. On a failed save, a creature takes 10d6 cold damage. On a successful save, it takes half as much damage.\nIf the globe strikes a body of water or a liquid that is principally water (not including water-based creatures), it freezes the liquid to a depth of 6 inches over an area 30 feet square. This ice lasts for 1 minute. Creatures that were swimming on the surface of frozen water are trapped in the ice. A trapped creature can use an action to make a Strength check against your spell save DC to break free.\nYou can refrain from firing the globe after completing the spell, if you wish. A small globe about the size of a sling stone, cool to the touch, appears in your hand. At any time, you or a creature you give the globe to can throw the globe (to a range of 40 feet) or hurl it with a sling (to the sling's normal range). It shatters on impact, with the same effect as the normal casting of the spell. You can also set the globe down without shattering it. After 1 minute, if the globe hasn't already shattered, it explodes.\nWhen you cast this spell using a spell slot of 7th level or higher, the damage increases by 1d6 for each slot level above 6th.";
                case Spells.ID.GASEOUS_FORM:
                    return "You transform a willing creature you touch, along with everything it's wearing and carrying, into a misty cloud for the duration. The spell ends if the creature drops to 0 hit points. An incorporeal creature isn't affected.\nWhile in this form, the target's only method of movement is a flying speed of 10 feet. The target can enter and occupy the space of another creature. The target has resistance to nonmagical damage, and it has advantage on Strength, Dexterity, and constitution saving throws. The target can pass through small holes, narrow openings, and even mere cracks, though it treats liquids as though they were solid surfaces. The target can't fall and remains hovering in the air even when stunned or otherwise incapacitated.\nWhile in the form of a misty cloud, the target can't talk or manipulate objects, and any objects it was carrying or holding can't be dropped, used, or otherwise interacted with. The target can't attack or cast spells.";
                case Spells.ID.GATE:
                    return "You conjure a portal linking an unoccupied space you can see within range to a precise location on a different plane of existence. The portal is a circular opening, which you can make 5 to 20 feet in diameter. You can orient the portal in any direction you choose. The portal lasts for the duration.\nThe portal has a front and a back on each plane where it appears. Travel through the portal is possible only by moving through its front. Anything that does so is instantly transported to the other plane, appearing in the unoccupied space nearest to the portal.\nDeities and other planar rulers can prevent portals created by this spell from opening in their presence or anywhere within their domains.\nWhen you cast this spell, you can speak the name of a specific creature (a pseudonym, title, or nickname doesn't work). If that creature is on a plane other than the one you are on, the portal opens in the named creature's immediate vicinity and draws the creature through it to the nearest unoccupied space on your side of the portal. You gain no special power over the creature, and it is free to act as the DM deems appropriate. It might leave, attack you, or help you.";
                case Spells.ID.GEAS:
                    return "You place a magical command on a creature that you can see within range, forcing it to carry out some service or refrain from some action or course of activity as you decide. If the creature can understand you, it must succeed on a wisdom saving throw or become charmed by you for the duration. While the creature is charmed by you, it takes 5d10 psychic damage each time it acts in a manner directly counter to your instructions, but no more than once each day. A creature that can't understand you is unaffected by the spell.\nYou can issue any command you choose, short of an activity that would result in certain death. Should you issue a suicidal command, the spell ends.\nYou can end the spell early by using an action to dismiss it. A remove curse, greater restoration, or wish spell also ends it.\nWhen you cast this spell using a spell slot of 7th or 8th level, the duration is 1 year. When you cast this spell using a spell slot of 9th level, the spell lasts until it is ended by one of the spells mentioned above.";
                case Spells.ID.GENTLE_REPOSE:
                    return "You touch a corpse or other remains. For the duration, the target is protected from decay and can't become undead.\nThe spell also effectively extends the time limit on raising the target from the dead, since days spent under the influence of this spell don't count against the time limit of spells such as raise dead.";
                case Spells.ID.GIANT_INSECT:
                    return "You transform up to ten centipedes, three spiders, five wasps, or one scorpion within range into giant versions of their natural forms for the duration. A centipede becomes a giant centipede, a spider becomes a giant spider, a wasp becomes a giant wasp, and a scorpion becomes a giant scorpion.\nEach creature obeys your verbal commands, and in combat, they act on your turn each round. The DM has the statistics for these creatures and resolves their actions and movement.\nA creature remains in its giant size for the duration, until it drops to 0 hit points, or until you use an action to dismiss the effect on it.\nThe DM might allow you to choose different targets. For example, if you transform a bee, its giant version might have the same statistics as a giant wasp.";
                case Spells.ID.GLIBNESS:
                    return "Until the spell ends, when you make a Charisma check, you can replace the number you roll with a 15. Additionally, no matter what you say, magic that would determine if you are telling the truth indicates that you are being truthful.";
                case Spells.ID.GLOBE_OF_INVULNERABILITY:
                    return "An immobile, faintly shimmering barrier springs into existence in a 10-foot radius around you and remains for the duration.\nAny spell of 5th level or lower cast from outside the barrier can't affect creatures or objects within it, even if the spell is cast using a higher level spell slot. Such a spell can target creatures and objects within the barrier, but the spell has no effect on them. Similarly, the area within the barrier is excluded from the areas affected by such spells.\nWhen you cast this spell using a spell slot of 7th level or higher, the barrier blocks spells of one level higher for each slot level above 6th.";
                case Spells.ID.GLYPH_OF_WARDING:
                    return "When you cast this spell, you inscribe a glyph that harms other creatures, either upon a surface (such as a table or a section of floor or wall) or within an object that can be closed (such as a book, a scroll, or a treasure chest) to conceal the glyph. If you choose a surface, the glyph can cover an area of the surface no larger than 10 feet in diameter. If you choose an object, that object must remain in its place; if the object is moved more than 10 feet from where you cast this spell, the glyph is broken, and the spell ends without being triggered.\nThe glyph is nearly invisible and requires a successful Intelligence (Investigation) check against your spell save DC to be found.\nYou decide what triggers the glyph when you cast the spell. For glyphs inscribed on a surface, the most typical triggers include touching or standing on the glyph, removing another object covering the glyph, approaching within a certain distance of the glyph, or manipulating the object on which the glyph is inscribed. For glyphs inscribed within an object, the most common triggers include opening that object, approaching within a certain distance of the object, or seeing or reading the glyph. Once a glyph is triggered, this spell ends.\nYou can further refine the trigger so the spell activates only under certain circumstances or according to physical characteristics (such as height or weight), creature kind (for example, the ward could be set to affect aberrations or drow), or alignment. You can also set conditions for creatures that don't trigger the glyph, such as those who say a certain password.\nWhen you inscribe the glyph, choose *explosive runes* or a *spell glyph*.\n***Explosive Runes.*** When triggered, the glyph erupts with magical energy in a 20-foot-radius sphere centered on the glyph. The sphere spreads around corners. Each creature in the area must make a Dexterity saving throw. A creature takes 5d8 acid, cold, fire, lightning, or thunder damage on a failed saving throw (your choice when you create the glyph), or half as much damage on a successful one.\n***Spell Glyph.*** You can store a prepared spell of 3rd level or lower in the glyph by casting it as part of creating the glyph. The spell must target a single creature or an area. The spell being stored has no immediate effect when cast in this way. When the glyph is triggered, the stored spell is cast. If the spell has a target, it targets the creature that triggered the glyph. If the spell affects an area, the area is centered on that creature. If the spell summons hostile creatures or creates harmful objects or traps, they appear as close as possible to the intruder and attack it. If the spell requires concentration, it lasts until the end of its full duration.\nWhen you cast this spell using a spell slot of 4th level or higher, the damage of an explosive runes glyph increases by 1d8 for each slot level above 3rd. If you create a spell glyph, you can store any spell of up to the same level as the slot you use for the glyph of warding.";
                case Spells.ID.GOODBERRY:
                    return "Up to ten berries appear in your hand and are infused with magic for the duration. A creature can use its action to eat one berry. Eating a berry restores 1 hit point, and the berry provides enough nourishment to sustain a creature for a day.\nThe berries lose their potency if they have not been consumed within 24 hours of the casting of this spell.";
                case Spells.ID.GREASE:
                    return "Slick grease covers the ground in a 10-foot square centered on a point within range and turns it into difficult terrain for the duration.\nWhen the grease appears, each creature standing in its area must succeed on a dexterity saving throw or fall prone. A creature that enters the area or ends its turn there must also succeed on a dexterity saving throw or fall prone.";
                case Spells.ID.GREATER_INVISIBILITY:
                    return "You or a creature you touch becomes invisible until the spell ends. Anything the target is wearing or carrying is invisible as long as it is on the target's person.";
                case Spells.ID.GREATER_RESTORATION:
                    return "You imbue a creature you touch with positive energy to undo a debilitating effect. You can reduce the target's exhaustion level by one, or end one of the following effects on the target:\n- One effect that charmed or petrified the target\n- One curse, including the target's attunement to a cursed magic item\n- Any reduction to one of the target's ability scores\n- One effect reducing the target's hit point maximum";
                case Spells.ID.GUARDIAN_OF_FAITH:
                    return "A Large spectral guardian appears and hovers for the duration in an unoccupied space of your choice that you can see within range. The guardian occupies that space and is indistinct except for a gleaming sword and shield emblazoned with the symbol of your deity.\nAny creature hostile to you that moves to a space within 10 feet of the guardian for the first time on a turn must succeed on a dexterity saving throw. The creature takes 20 radiant damage on a failed save, or half as much damage on a successful one. The guardian vanishes when it has dealt a total of 60 damage.";
                case Spells.ID.GUARDS_AND_WARDS:
                    return "You create a ward that protects up to 2,500 square feet of floor space (an area 50 feet square, or one hundred 5-foot squares or twenty-five 10-foot squares). The warded area can be up to 20 feet tall, and shaped as you desire. You can ward several stories of a stronghold by dividing the area among them, as long as you can walk into each contiguous area while you are casting the spell.\nWhen you cast this spell, you can specify individuals that are unaffected by any or all of the effects that you choose. You can also specify a password that, when spoken aloud, makes the speaker immune to these effects.\nGuards and wards creates the following effects within the warded area.\n***Corridors.*** Fog fills all the warded corridors, making them heavily obscured. In addition, at each intersection or branching passage offering a choice of direction, there is a 50 percent chance that a creature other than you will believe it is going in the opposite direction from the one it chooses.\n***Doors.*** All doors in the warded area are magically locked, as if sealed by an arcane lock spell. In addition, you can cover up to ten doors with an illusion (equivalent to the illusory object function of the minor illusion spell) to make them appear as plain sections of wall.\n***Stairs.*** Webs fill all stairs in the warded area from top to bottom, as the web spell. These strands regrow in 10 minutes if they are burned or torn away while guards and wards lasts.\n***Other Spell Effect.*** You can place your choice of one of the following magical effects within the warded area of the stronghold.\n- Place dancing lights in four corridors. You can designate a simple program that the lights repeat as long as guards and wards lasts.\n- Place magic mouth in two locations.\n- Place stinking cloud in two locations. The vapors appear in the places you designate; they return within 10 minutes if dispersed by wind while guards and wards lasts.\n- Place a constant gust of wind in one corridor or room.\n- Place a suggestion in one location. You select an area of up to 5 feet square, and any creature that enters or passes through the area receives the suggestion mentally.\nThe whole warded area radiates magic. A dispel magic cast on a specific effect, if successful, removes only that effect.\nYou can create a permanently guarded and warded structure by casting this spell there every day for one year.";
                case Spells.ID.GUIDANCE:
                    return "You touch one willing creature. Once before the spell ends, the target can roll a d4 and add the number rolled to one ability check of its choice. It can roll the die before or after making the ability check. The spell then ends.";
                case Spells.ID.GUIDING_BOLT:
                    return "A flash of light streaks toward a creature of your choice within range. Make a ranged spell attack against the target. On a hit, the target takes 4d6 radiant damage, and the next attack roll made against this target before the end of your next turn has advantage, thanks to the mystical dim light glittering on the target until then.\nWhen you cast this spell using a spell slot of 2nd level or higher, the damage increases by 1d6 for each slot level above 1st.";
                case Spells.ID.GUST_OF_WIND:
                    return "A line of strong wind 60 feet long and 10 feet wide blasts from you in a direction you choose for the spell's duration. Each creature that starts its turn in the line must succeed on a strength saving throw or be pushed 15 feet away from you in a direction following the line.\nAny creature in the line must spend 2 feet of movement for every 1 foot it moves when moving closer to you.\nThe gust disperses gas or vapor, and it extinguishes candles, torches, and similar unprotected flames in the area. It causes protected flames, such as those of lanterns, to dance wildly and has a 50 percent chance to extinguish them.\nAs a bonus action on each of your turns before the spell ends, you can change the direction in which the line blasts from you.";
                case Spells.ID.HALLOW:
                    return "You touch a point and infuse an area around it with holy (or unholy) power. The area can have a radius up to 60 feet, and the spell fails if the radius includes an area already under the effect a hallow spell. The affected area is subject to the following effects.\nFirst, celestials, elementals, fey, fiends, and undead can't enter the area, nor can such creatures charm, frighten, or possess creatures within it. Any creature charmed, frightened, or possessed by such a creature is no longer charmed, frightened, or possessed upon entering the area. You can exclude one or more of those types of creatures from this effect.\nSecond, you can bind an extra effect to the area. Choose the effect from the following list, or choose an effect offered by the DM. Some of these effects apply to creatures in the area; you can designate whether the effect applies to all creatures, creatures that follow a specific deity or leader, or creatures of a specific sort, such as ores or trolls. When a creature that would be affected enters the spell's area for the first time on a turn or starts its turn there, it can make a charisma saving throw. On a success, the creature ignores the extra effect until it leaves the area.\n***Courage.*** Affected creatures can't be frightened while in the area.\n***Darkness.*** Darkness fills the area. Normal light, as well as magical light created by spells of a lower level than the slot you used to cast this spell, can't illuminate the area.\n***Daylight.*** Bright light fills the area. Magical darkness created by spells of a lower level than the slot you used to cast this spell can't extinguish the light.\n***Energy Protection.*** Affected creatures in the area have resistance to one damage type of your choice, except for bludgeoning, piercing, or slashing.\n***Energy Vulnerability.*** Affected creatures in the area have vulnerability to one damage type of your choice, except for bludgeoning, piercing, or slashing.\n***Everlasting Rest.*** Dead bodies interred in the area can't be turned into undead.\n***Extradimensional Interference.*** Affected creatures can't move or travel using teleportation or by extradimensional or interplanar means.\n***Fear.*** Affected creatures are frightened while in the area.\n***Silence.*** No sound can emanate from within the area, and no sound can reach into it.\n***Tongues.*** Affected creatures can communicate with any other creature in the area, even if they don't share a common language.";
                case Spells.ID.HALLUCINATORY_TERRAIN:
                    return "You make natural terrain in a 150-foot cube in range look, sound, and smell like some other sort of natural terrain. Thus, open fields or a road can be made to resemble a swamp, hill, crevasse, or some other difficult or impassable terrain. A pond can be made to seem like a grassy meadow, a precipice like a gentle slope, or a rock-strewn gully like a wide and smooth road. Manufactured structures, equipment, and creatures within the area aren't changed in appearance.\nThe tactile characteristics of the terrain are unchanged, so creatures entering the area are likely to see through the illusion. If the difference isn't obvious by touch, a creature carefully examining the illusion can attempt an Intelligence (Investigation) check against your spell save DC to disbelieve it. A creature who discerns the illusion for what it is, sees it as a vague image superimposed on the terrain.";
                case Spells.ID.HARM:
                    return "You unleash a virulent disease on a creature that you can see within range. The target must make a constitution saving throw. On a failed save, it takes 14d6 necrotic damage, or half as much damage on a successful save. The damage can't reduce the target's hit points below 1. If the target fails the saving throw, its hit point maximum is reduced for 1 hour by an amount equal to the necrotic damage it took. Any effect that removes a disease allows a creature's hit point maximum to return to normal before that time passes.";
                case Spells.ID.HASTE:
                    return "Choose a willing creature that you can see within range. Until the spell ends, the target's speed is doubled, it gains a +2 bonus to AC, it has advantage on dexterity saving throws, and it gains an additional action on each of its turns. That action can be used only to take the Attack (one weapon attack only), Dash, Disengage, Hide, or Use an Object action.\nWhen the spell ends, the target can't move or take actions until after its next turn, as a wave of lethargy sweeps over it.";
                case Spells.ID.HEAL:
                    return "Choose a creature that you can see within range. A surge of positive energy washes through the creature, causing it to regain 70 hit points. This spell also ends blindness, deafness, and any diseases affecting the target. This spell has no effect on constructs or undead.\nWhen you cast this spell using a spell slot of 7th level or higher, the amount of healing increases by 10 for each slot level above 6th.";
                case Spells.ID.HEALING_WORD:
                    return "A creature of your choice that you can see within range regains hit points equal to 1d4 + your spellcasting ability modifier. This spell has no effect on undead or constructs.\nWhen you cast this spell using a spell slot of 2nd level or higher, the healing increases by 1d4 for each slot level above 1st.";
                case Spells.ID.HEAT_METAL:
                    return "Choose a manufactured metal object, such as a metal weapon or a suit of heavy or medium metal armor, that you can see within range. You cause the object to glow red-hot. Any creature in physical contact with the object takes 2d8 fire damage when you cast the spell. Until the spell ends, you can use a bonus action on each of your subsequent turns to cause this damage again.\nIf a creature is holding or wearing the object and takes the damage from it, the creature must succeed on a constitution saving throw or drop the object if it can. If it doesn't drop the object, it has disadvantage on attack rolls and ability checks until the start of your next turn.\nWhen you cast this spell using a spell slot of 3rd level or higher, the damage increases by 1d8 for each slot level above 2nd.";
                case Spells.ID.HELLISH_REBUKE:
                    return "You point your finger, and the creature that damaged you is momentarily surrounded by hellish flames. The creature must make a dexterity saving throw. It takes 2d10 fire damage on a failed save, or half as much damage on a successful one.";
                case Spells.ID.HEROES_FEAST:
                    return "You bring forth a great feast, including magnificent food and drink. The feast takes 1 hour to consume and disappears at the end of that time, and the beneficial effects don't set in until this hour is over. Up to twelve other creatures can partake of the feast.\nA creature that partakes of the feast gains several benefits. The creature is cured of all diseases and poison, becomes immune to poison and being frightened, and makes all wisdom saving throws with advantage. Its hit point maximum also increases by 2d10, and it gains the same number of hit points. These benefits last for 24 hours.";
                case Spells.ID.HEROISM:
                    return "A willing creature you touch is imbued with bravery. Until the spell ends, the creature is immune to being frightened and gains temporary hit points equal to your spellcasting ability modifier at the start of each of its turns. When the spell ends, the target loses any remaining temporary hit points from this spell.";
                case Spells.ID.HIDEOUS_LAUGHTER:
                    return "A creature of your choice that you can see within range perceives everything as hilariously funny and falls into fits of laughter if this spell affects it. The target must succeed on a wisdom saving throw or fall prone, becoming incapacitated and unable to stand up for the duration. A creature with an Intelligence score of 4 or less isn't affected.\nAt the end of each of its turns, and each time it takes damage, the target can make another wisdom saving throw. The target had advantage on the saving throw if it's triggered by damage. On a success, the spell ends.";
                case Spells.ID.HOLD_MONSTER:
                    return "Choose a creature you can see and reach. The target must make a saving throw of Wisdom or be paralyzed for the duration of the spell. This spell has no effect against the undead. At the end of each round, the target can make a new saving throw of Wisdom. If successful, the spell ends for the creature.\nWhen you cast this spell using a level 6 or higher location, you can target an additional creature for each level of location beyond the fifth. The creatures must be within 30 feet o f each other when you target them.";
                case Spells.ID.HOLD_PERSON:
                    return "Choose a humanoid that you can see within range. The target must succeed on a wisdom saving throw or be paralyzed for the duration. At the end of each of its turns, the target can make another wisdom saving throw. On a success, the spell ends on the target.\nWhen you cast this spell using a spell slot of 3rd level or higher, you can target one additional humanoid for each slot level above 2nd. The humanoids must be within 30 feet of each other when you target them.";
                case Spells.ID.HOLY_AURA:
                    return "Divine light washes out from you and coalesces in a soft radiance in a 30-foot radius around you. Creatures of your choice in that radius when you cast this spell shed dim light in a 5-foot radius and have advantage on all saving throws, and other creatures have disadvantage on attack rolls against them until the spell ends. In addition, when a fiend or an undead hits an affected creature with a melee attack, the aura flashes with brilliant light. The attacker must succeed on a constitution saving throw or be blinded until the spell ends.";
                case Spells.ID.HUNTERS_MARK:
                    return "You choose a creature you can see within range and mystically mark it as your quarry. Until the spell ends, you deal an extra 1d6 damage to the target whenever you hit it with a weapon attack, and you have advantage on any Wisdom (Perception) or Wisdom (Survival) check you make to find it. If the target drops to 0 hit points before this spell ends, you can use a bonus action on a subsequent turn of yours to mark a new creature.\nWhen you cast this spell using a spell slot of 3rd or 4th level, you can maintain your concentration on the spell for up to 8 hours. When you use a spell slot of 5th level or higher, you can maintain your concentration on the spell for up to 24 hours.";
                case Spells.ID.HYPNOTIC_PATTERN:
                    return "You create a twisting pattern of colors that weaves through the air inside a 30-foot cube within range. The pattern appears for a moment and vanishes. Each creature in the area who sees the pattern must make a wisdom saving throw. On a failed save, the creature becomes charmed for the duration. While charmed by this spell, the creature is incapacitated and has a speed of 0.\nThe spell ends for an affected creature if it takes any damage or if someone else uses an action to shake the creature out of its stupor.";
                case Spells.ID.ICE_STORM:
                    return "A hail of rock-hard ice pounds to the ground in a 20-foot-radius, 40-foot-high cylinder centered on a point within range. Each creature in the cylinder must make a dexterity saving throw. A creature takes 2d8 bludgeoning damage and 4d6 cold damage on a failed save, or half as much damage on a successful one.\nHailstones turn the storm's area of effect into difficult terrain until the end of your next turn.\nWhen you cast this spell using a spell slot of 5th level or higher, the bludgeoning damage increases by 1d8 for each slot level above 4th.";
                case Spells.ID.IDENTIFY:
                    return "You choose one object that you must touch throughout the casting of the spell. If it is a magic item or some other magic-imbued object, you learn its properties and how to use them, whether it requires attunement to use, and how many charges it has, if any. You learn whether any spells are affecting the item and what they are. If the item was created by a spell, you learn which spell created it.\nIf you instead touch a creature throughout the casting, you learn what spells, if any, are currently affecting it.";
                case Spells.ID.ILLUSORY_SCRIPT:
                    return "You write on parchment, paper, or some other suitable writing material and imbue it with a potent illusion that lasts for the duration.\nTo you and any creatures you designate when you cast the spell, the writing appears normal, written in your hand, and conveys whatever meaning you intended when you wrote the text. To all others, the writing appears as if it were written in an unknown or magical script that is unintelligible. Alternatively, you can cause the writing to appear to be an entirely different message, written in a different hand and language, though the language must be one you know.\nShould the spell be dispelled, the original script and the illusion both disappear.\nA creature with truesight can read the hidden message.";
                case Spells.ID.IMPRISONMENT:
                    return "You create a magical restraint to hold a creature that you can see within range. The target must succeed on a wisdom saving throw or be bound by the spell; if it succeeds, it is immune to this spell if you cast it again. While affected by this spell, the creature doesn't need to breathe, eat, or drink, and it doesn't age. Divination spells can't locate or perceive the target.\nWhen you cast the spell, you choose one of the following forms of imprisonment.\n***Burial.*** The target is entombed far beneath the earth in a sphere of magical force that is just large enough to contain the target. Nothing can pass through the sphere, nor can any creature teleport or use planar travel to get into or out of it.\nThe special component for this version of the spell is a small mithral orb.\n***Chaining.*** Heavy chains, firmly rooted in the ground, hold the target in place. The target is restrained until the spell ends, and it can't move or be moved by any means until then.\nThe special component for this version of the spell is a fine chain of precious metal.\n***Hedged Prison.*** The spell transports the target into a tiny demiplane that is warded against teleportation and planar travel. The demiplane can be a labyrinth, a cage, a tower, or any similar confined structure or area of your choice.\nThe special component for this version of the spell is a miniature representation of the prison made from jade.\n***Minimus Containment.*** The target shrinks to a height of 1 inch and is imprisoned inside a gemstone or similar object. Light can pass through the gemstone normally (allowing the target to see out and other creatures to see in), but nothing else can pass through, even by means of teleportation or planar travel. The gemstone can't be cut or broken while the spell remains in effect.\nThe special component for this version of the spell is a large, transparent gemstone, such as a corundum, diamond, or ruby.\n***Slumber.*** The target falls asleep and can't be awoken.\nThe special component for this version of the spell consists of rare soporific herbs.\n***Ending the Spell.*** During the casting of the spell, in any of its versions, you can specify a condition that will cause the spell to end and release the target. The condition can be as specific or as elaborate as you choose, but the DM must agree that the condition is reasonable and has a likelihood of coming to pass. The conditions can be based on a creature's name, identity, or deity but otherwise must be based on observable actions or qualities and not based on intangibles such as level, class, or hit points.\nA dispel magic spell can end the spell only if it is cast as a 9th-level spell, targeting either the prison or the special component used to create it.\nYou can use a particular special component to create only one prison at a time. If you cast the spell again using the same component, the target of the first casting is immediately freed from its binding.";
                case Spells.ID.INCENDIARY_CLOUD:
                    return "A swirling cloud of smoke shot through with white-hot embers appears in a 20-foot-radius sphere centered on a point within range. The cloud spreads around corners and is heavily obscured. It lasts for the duration or until a wind of moderate or greater speed (at least 10 miles per hour) disperses it.\nWhen the cloud appears, each creature in it must make a dexterity saving throw. A creature takes 10d8 fire damage on a failed save, or half as much damage on a successful one. A creature must also make this saving throw when it enters the spell's area for the first time on a turn or ends its turn there.\nThe cloud moves 10 feet directly away from you in a direction that you choose at the start of each of your turns.";
                case Spells.ID.INFLICT_WOUNDS:
                    return "Make a melee spell attack against a creature you can reach. On a hit, the target takes 3d10 necrotic damage.\nWhen you cast this spell using a spell slot of 2nd level or higher, the damage increases by 1d10 for each slot level above 1st.";
                case Spells.ID.INSECT_PLAGUE:
                    return "Swarming, biting locusts fill a 20-foot-radius sphere centered on a point you choose within range. The sphere spreads around corners. The sphere remains for the duration, and its area is lightly obscured. The sphere's area is difficult terrain.\nWhen the area appears, each creature in it must make a constitution saving throw. A creature takes 4d10 piercing damage on a failed save, or half as much damage on a successful one. A creature must also make this saving throw when it enters the spell's area for the first time on a turn or ends its turn there.\nWhen you cast this spell using a spell slot of 6th level or higher, the damage increases by 1d10 for each slot level above 5th.";
                case Spells.ID.INSTANT_SUMMONS:
                    return "You touch an object weighing 10 pounds or less whose longest dimension is 6 feet or less. The spell leaves an invisible mark on its surface and invisibly inscribes the name of the item on the sapphire you use as the material component. Each time you cast this spell, you must use a different sapphire.\nAt any time thereafter, you can use your action to speak the item's name and crush the sapphire. The item instantly appears in your hand regardless of physical or planar distances, and the spell ends.\nIf another creature is holding or carrying the item, crushing the sapphire doesn't transport the item to you, but instead you learn who the creature possessing the object is and roughly where that creature is located at that moment.\nDispel magic or a similar effect successfully applied to the sapphire ends this spell's effect.";
                case Spells.ID.INVISIBILITY:
                    return "A creature you touch becomes invisible until the spell ends. Anything the target is wearing or carrying is invisible as long as it is on the target's person. The spell ends for a target that attacks or casts a spell.\nWhen you cast this spell using a spell slot of 3rd level or higher, you can target one additional creature for each slot level above 2nd.";
                case Spells.ID.IRRESISTIBLE_DANCE:
                    return "Choose one creature that you can see within range. The target begins a comic dance in place: shuffling, tapping its feet, and capering for the duration. Creatures that can't be charmed are immune to this spell.\nA dancing creature must use all its movement to dance without leaving its space and has disadvantage on dexterity saving throws and attack rolls. While the target is affected by this spell, other creatures have advantage on attack rolls against it. As an action, a dancing creature makes a wisdom saving throw to regain control of itself. On a successful save, the spell ends.";
                case Spells.ID.JUMP:
                    return "You touch a creature. The creature's jump distance is tripled until the spell ends.";
                case Spells.ID.KNOCK:
                    return "Choose an object that you can see within range. The object can be a door, a box, a chest, a set of manacles, a padlock, or another object that contains a mundane or magical means that prevents access.\nA target that is held shut by a mundane lock or that is stuck or barred becomes unlocked, unstuck, or unbarred. If the object has multiple locks, only one of them is unlocked.\nIf you choose a target that is held shut with arcane lock, that spell is suppressed for 10 minutes, during which time the target can be opened and shut normally.\nWhen you cast the spell, a loud knock, audible from as far away as 300 feet, emanates from the target object.";
                case Spells.ID.LEGEND_LORE:
                    return "Name or describe a person, place, or object. The spell brings to your mind a brief summary of the significant lore about the thing you named. The lore might consist of current tales, forgotten stories, or even secret lore that has never been widely known. If the thing you named isn't of legendary importance, you gain no information. The more information you already have about the thing, the more precise and detailed the information you receive is.\nThe information you learn is accurate but might be couched in figurative language. For example, if you have a mysterious magic axe on hand the spell might yield this information: \"Woe to the evildoer whose hand touches the axe, for even the haft slices the hand of the evil ones. Only a true Child of Stone, lover and beloved of Moradin, may awaken the true powers of the axe, and only with the sacred word *Rudnogg* on the lips.\"";
                case Spells.ID.LESSER_RESTORATION:
                    return "You touch a creature and can end either one disease or one condition afflicting it. The condition can be blinded, deafened, paralyzed, or poisoned.";
                case Spells.ID.LEVITATE:
                    return "One creature or object of your choice that you can see within range rises vertically, up to 20 feet, and remains suspended there for the duration. The spell can levitate a target that weighs up to 500 pounds. An unwilling creature that succeeds on a constitution saving throw is unaffected.\nThe target can move only by pushing or pulling against a fixed object or surface within reach (such as a wall or a ceiling), which allows it to move as if it were climbing. You can change the target's altitude by up to 20 feet in either direction on your turn. If you are the target, you can move up or down as part of your move. Otherwise, you can use your action to move the target, which must remain within the spell's range.\nWhen the spell ends, the target floats gently to the ground if it is still aloft.";
                case Spells.ID.LIGHT:
                    return "You touch one object that is no larger than 10 feet in any dimension. Until the spell ends, the object sheds bright light in a 20-foot radius and dim light for an additional 20 feet. The light can be colored as you like. Completely covering the object with something opaque blocks the light. The spell ends if you cast it again or dismiss it as an action.\nIf you target an object held or worn by a hostile creature, that creature must succeed on a dexterity saving throw to avoid the spell.";
                case Spells.ID.LIGHTNING_BOLT:
                    return "A stroke of lightning forming a line 100 feet long and 5 feet wide blasts out from you in a direction you choose. Each creature in the line must make a dexterity saving throw. A creature takes 8d6 lightning damage on a failed save, or half as much damage on a successful one.\nThe lightning ignites flammable objects in the area that aren't being worn or carried.\nWhen you cast this spell using a spell slot of 4th level or higher, the damage increases by 1d6 for each slot level above 3rd.";
                case Spells.ID.LOCATE_ANIMALS_OR_PLANTS:
                    return "Describe or name a specific kind of beast or plant. Concentrating on the voice of nature in your surroundings, you learn the direction and distance to the closest creature or plant of that kind within 5 miles, if any are present.";
                case Spells.ID.LOCATE_CREATURE:
                    return "Describe or name a creature that is familiar to you. You sense the direction to the creature's location, as long as that creature is within 1,000 feet of you. If the creature is moving, you know the direction of its movement.\nThe spell can locate a specific creature known to you, or the nearest creature of a specific kind (such as a human or a unicorn), so long as you have seen such a creature up close--within 30 feet--at least once. If the creature you described or named is in a different form, such as being under the effects of a polymorph spell, this spell doesn't locate the creature.\nThis spell can't locate a creature if running water at least 10 feet wide blocks a direct path between you and the creature.";
                case Spells.ID.LOCATE_OBJECT:
                    return "Describe or name an object that is familiar to you. You sense the direction to the object's location, as long as that object is within 1,000 feet of you. If the object is in motion, you know the direction of its movement.\nThe spell can locate a specific object known to you, as long as you have seen it up close--within 30 feet--at least once. Alternatively, the spell can locate the nearest object of a particular kind, such as a certain kind of apparel, jewelry, furniture, tool, or weapon.\nThis spell can't locate an object if any thickness of lead, even a thin sheet, blocks a direct path between you and the object.";
                case Spells.ID.LONGSTRIDER:
                    return "You touch a creature. The target's speed increases by 10 feet until the spell ends.\nWhen you cast this spell using a spell slot of 2nd level or higher, you can target one additional creature for each spell slot above 1st.";
                case Spells.ID.MAGE_ARMOR:
                    return "You touch a willing creature who isn't wearing armor, and a protective magical force surrounds it until the spell ends. The target's base AC becomes 13 + its Dexterity modifier. The spell ends if the target dons armor or if you dismiss the spell as an action.";
                case Spells.ID.MAGE_HAND:
                    return "A spectral, floating hand appears at a point you choose within range. The hand lasts for the duration or until you dismiss it as an action. The hand vanishes if it is ever more than 30 feet away from you or if you cast this spell again.\nYou can use your action to control the hand. You can use the hand to manipulate an object, open an unlocked door or container, stow or retrieve an item from an open container, or pour the contents out of a vial. You can move the hand up to 30 feet each time you use it.\nThe hand can't attack, activate magic items, or carry more than 10 pounds.";
                case Spells.ID.MAGIC_CIRCLE:
                    return "You create a 10-foot radius, 20-foot-tall cylinder of magical energy centered on a point on the ground that you can see within range. Glowing runes appear whetever the cylinder intersects with the floor or other surface.\nChoose one or more of the following types of creatures: celestials, elementals, fey, fiends, or undead. The circle affects a creature of the chosen type in the following ways:\n- The creature can't willingly enter the cylinder by nonmagical means. If the creature tries to use teleportation or interplanar travel to do so, it must first succeed on a charisma saving throw.\n- The creature has disadvantage on attack rolls against targets within the cylinder.\n- Targets within the cylinder can't be charmed, frightened, or possessed by the creature.\nWhen you cast this spell, you can elect to cause its magic to operate in the reverse direction, preventing a creature of the specified type from leaving the cylinder and protecting targets outside it.\nWhen you cast this spell using a spell slot of 4th level or higher, the duration increases by 1 hour for each slot level above 3rd.";
                case Spells.ID.MAGIC_JAR:
                    return "Your body falls into a catatonic state as your soul leaves it and enters the container you used for the spell's material component. While your soul inhabits the container, you are aware of your surroundings as if you were in the container's space. You can't move or use reactions. The only action you can take is to project your soul up to 100 feet out of the container, either returning to your living body (and ending the spell) or attempting to possess a humanoids body.\nYou can attempt to possess any humanoid within 100 feet of you that you can see (creatures warded by a protection from evil and good or magic circle spell can't be possessed). The target must make a charisma saving throw. On a failure, your soul moves into the target's body, and the target's soul becomes trapped in the container. On a success, the target resists your efforts to possess it, and you can't attempt to possess it again for 24 hours.\nOnce you possess a creature's body, you control it. Your game statistics are replaced by the statistics of the creature, though you retain your alignment and your Intelligence, Wisdom, and Charisma scores. You retain the benefit of your own class features. If the target has any class levels, you can't use any of its class features.\nMeanwhile, the possessed creature's soul can perceive from the container using its own senses, but it can't move or take actions at all.\nWhile possessing a body, you can use your action to return from the host body to the container if it is within 100 feet of you, returning the host creature's soul to its body. If the host body dies while you're in it, the creature dies, and you must make a charisma saving throw against your own spellcasting DC. On a success, you return to the container if it is within 100 feet of you. Otherwise, you die.\nIf the container is destroyed or the spell ends, your soul immediately returns to your body. If your body is more than 100 feet away from you or if your body is dead when you attempt to return to it, you die. If another creature's soul is in the container when it is destroyed, the creature's soul returns to its body if the body is alive and within 100 feet. Otherwise, that creature dies.\nWhen the spell ends, the container is destroyed.";
                case Spells.ID.MAGIC_MISSILE:
                    return "You create three glowing darts of magical force. Each dart hits a creature of your choice that you can see within range. A dart deals 1d4 + 1 force damage to its target. The darts all strike simultaneously, and you can direct them to hit one creature or several.\nWhen you cast this spell using a spell slot of 2nd level or higher, the spell creates one more dart for each slot level above 1st.";
                case Spells.ID.MAGIC_MOUTH:
                    return "You plant a message to an object in the range of the spell. The message is verbalized when the trigger conditions are met. Choose an object that you see, and that is not worn or carried by another creature. Then say the message, which should not exceed 25 words but listening can take up to 10 minutes. Finally, establish the circumstances that trigger the spell to deliver your message.\nWhen these conditions are satisfied, a magical mouth appears on the object and it articulates the message imitating your voice, the same tone used during implantation of the message. If the selected object has a mouth or something that approaches such as the mouth of a statue, the magic mouth come alive at this point, giving the illusion that the words come from the mouth of the object.\nWhen you cast this spell, you may decide that the spell ends when the message is delivered or it can persist and repeat the message whenever circumstances occur.\nThe triggering circumstance can be as general or as detailed as you like, though it must be based on visual or audible conditions that occur within 30 feet of the object. For example, you could instruct the mouth to speak when any creature moves within 30 feet of the object or when a silver bell rings within 30 feet of it.";
                case Spells.ID.MAGIC_WEAPON:
                    return "You touch a nonmagical weapon. Until the spell ends, that weapon becomes a magic weapon with a +1 bonus to attack rolls and damage rolls.\nWhen you cast this spell using a spell slot of 4th level or higher, the bonus increases to +2. When you use a spell slot of 6th level or higher, the bonus increases to +3.";
                case Spells.ID.MAGNIFICENT_MANSION:
                    return "You conjure an extradimensional dwelling in range that lasts for the duration. You choose where its one entrance is located. The entrance shimmers faintly and is 5 feet wide and 10 feet tall. You and any creature you designate when you cast the spell can enter the extradimensional dwelling as long as the portal remains open. You can open or close the portal if you are within 30 feet of it. While closed, the portal is invisible.\nBeyond the portal is a magnificent foyer with numerous chambers beyond. The atmosphere is clean, fresh, and warm.\nYou can create any floor plan you like, but the space can't exceed 50 cubes, each cube being 10 feet on each side. The place is furnished and decorated as you choose. It contains sufficient food to serve a nine course banquet for up to 100 people. A staff of 100 near-transparent servants attends all who enter. You decide the visual appearance of these servants and their attire. They are completely obedient to your orders. Each servant can perform any task a normal human servant could perform, but they can't attack or take any action that would directly harm another creature. Thus the servants can fetch things, clean, mend, fold clothes, light fires, serve food, pour wine, and so on. The servants can go anywhere in the mansion but can't leave it. Furnishings and other objects created by this spell dissipate into smoke if removed from the mansion. When the spell ends, any creatures inside the extradimensional space are expelled into the open spaces nearest to the entrance.";
                case Spells.ID.MAJOR_IMAGE:
                    return "You create the image of an object, a creature, or some other visible phenomenon that is no larger than a 20-foot cube. The image appears at a spot that you can see within range and lasts for the duration. It seems completely real, including sounds, smells, and temperature appropriate to the thing depicted. You can't create sufficient heat or cold to cause damage, a sound loud enough to deal thunder damage or deafen a creature, or a smell that might sicken a creature (like a troglodyte's stench).\nAs long as you are within range of the illusion, you can use your action to cause the image to move to any other spot within range. As the image changes location, you can alter its appearance so that its movements appear natural for the image. For example, if you create an image of a creature and move it, you can alter the image so that it appears to be walking. Similarly, you can cause the illusion to make different sounds at different times, even making it carry on a conversation, for example.\nPhysical interaction with the image reveals it to be an illusion, because things can pass through it. A creature that uses its action to examine the image can determine that it is an illusion with a successful Intelligence (Investigation) check against your spell save DC. If a creature discerns the illusion for what it is, the creature can see through the image, and its other sensory qualities become faint to the creature.\nWhen you cast this spell using a spell slot of 6th level or higher, the spell lasts until dispelled, without requiring your concentration.";
                case Spells.ID.MASS_CURE_WOUNDS:
                    return "A wave of healing energy washes out from a point of your choice within range. Choose up to six creatures in a 30-foot-radius sphere centered on that point. Each target regains hit points equal to 3d8 + your spellcasting ability modifier. This spell has no effect on undead or constructs.\nWhen you cast this spell using a spell slot of 6th level or higher, the healing increases by 1d8 for each slot level above 5th.";
                case Spells.ID.MASS_HEAL:
                    return "A flood of healing energy flows from you into injured creatures around you. You restore up to 700 hit points, divided as you choose among any number of creatures that you can see within range. Creatures healed by this spell are also cured of all diseases and any effect making them blinded or deafened. This spell has no effect on undead or constructs.";
                case Spells.ID.MASS_HEALING_WORD:
                    return "As you call out words of restoration, up to six creatures of your choice that you can see within range regain hit points equal to 1d4 + your spellcasting ability modifier. This spell has no effect on undead or constructs.\nWhen you cast this spell using a spell slot of 4th level or higher, the healing increases by 1d4 for each slot level above 3rd.";
                case Spells.ID.MASS_SUGGESTION:
                    return "You suggest a course of activity (limited to a sentence or two) and magically influence up to twelve creatures of your choice that you can see within range and that can hear and understand you. Creatures that can't be charmed are immune to this effect. The suggestion must be worded in such a manner as to make the course of action sound reasonable. Asking the creature to stab itself, throw itself onto a spear, immolate itself, or do some other obviously harmful act automatically negates the effect of the spell.\nEach target must make a wisdom saving throw. On a failed save, it pursues the course of action you described to the best of its ability. The suggested course of action can continue for the entire duration. If the suggested activity can be completed in a shorter time, the spell ends when the subject finishes what it was asked to do.\nYou can also specify conditions that will trigger a special activity during the duration. For example, you might suggest that a group of soldiers give all their money to the first beggar they meet. If the condition isn't met before the spell ends, the activity isn't performed.\nIf you or any of your companions damage a creature affected by this spell, the spell ends for that creature.\nWhen you cast this spell using a 7th-level spell slot, the duration is 10 days. When you use an 8th-level spell slot, the duration is 30 days. When you use a 9th-level spell slot, the duration is a year and a day.";
                case Spells.ID.MAZE:
                    return "You banish a creature that you can see within range into a labyrinthine demiplane. The target remains there for the duration or until it escapes the maze.\nThe target can use its action to attempt to escape. When it does so, it makes a DC 20 Intelligence check. If it succeeds, it escapes, and the spell ends (a minotaur or goristro demon automatically succeeds).\nWhen the spell ends, the target reappears in the space it left or, if that space is occupied, in the nearest unoccupied space.";
                case Spells.ID.MELD_INTO_STONE:
                    return "You step into a stone object or surface large enough to fully contain your body, melding yourself and all the equipment you carry with the stone for the duration. Using your movement, you step into the stone at a point you can touch. Nothing of your presence remains visible or otherwise detectable by nonmagical senses.\nWhile merged with the stone, you can't see what occurs outside it, and any Wisdom (Perception) checks you make to hear sounds outside it are made with disadvantage. You remain aware of the passage of time and can cast spells on yourself while merged in the stone. You can use your movement to leave the stone where you entered it, which ends the spell. You otherwise can't move.\nMinor physical damage to the stone doesn't harm you, but its partial destruction or a change in its shape (to the extent that you no longer fit within it) expels you and deals 6d6 bludgeoning damage to you. The stone's complete destruction (or transmutation into a different substance) expels you and deals 50 bludgeoning damage to you. If expelled, you fall prone in an unoccupied space closest to where you first entered.";
                case Spells.ID.MENDING:
                    return "This spell repairs a single break or tear in an object you touch, such as a broken key, a torn cloak, or a leaking wineskin. As long as the break or tear is no longer than 1 foot in any dimension, you mend it, leaving no trace of the former damage.\nThis spell can physically repair a magic item or construct, but the spell can't restore magic to such an object.";
                case Spells.ID.MESSAGE:
                    return "You point your finger toward a creature within range and whisper a message. The target (and only the target) hears the message and can reply in a whisper that only you can hear.\nYou can cast this spell through solid objects if you are familiar with the target and know it is beyond the barrier. Magical silence, 1 foot of stone, 1 inch of common metal, a thin sheet of lead, or 3 feet of wood blocks the spell. The spell doesn't have to follow a straight line and can travel freely around corners or through openings.";
                case Spells.ID.METEOR_SWARM:
                    return "Blazing orbs of fire plummet to the ground at four different points you can see within range. Each creature in a 40-foot-radius sphere centered on each point you choose must make a dexterity saving throw. The sphere spreads around corners. A creature takes 20d6 fire damage and 20d6 bludgeoning damage on a failed save, or half as much damage on a successful one. A creature in the area of more than one fiery burst is affected only once.\nThe spell damages objects in the area and ignites flammable objects that aren't being worn or carried.";
                case Spells.ID.MIND_BLANK:
                    return "Until the spell ends, one willing creature you touch is immune to psychic damage, any effect that would sense its emotions or read its thoughts, divination spells, and the charmed condition. The spell even foils wish spells and spells or effects of similar power used to affect the target's mind or to gain information about the target.";
                case Spells.ID.MINOR_ILLUSION:
                    return "You create a sound or an image of an object within range that lasts for the duration. The illusion also ends if you dismiss it as an action or cast this spell again.\nIf you create a sound, its volume can range from a whisper to a scream. It can be your voice, someone else's voice, a lion's roar, a beating of drums, or any other sound you choose. The sound continues unabated throughout the duration, or you can make discrete sounds at different times before the spell ends.\nIf you create an image of an object--such as a chair, muddy footprints, or a small chest--it must be no larger than a 5-foot cube. The image can't create sound, light, smell, or any other sensory effect. Physical interaction with the image reveals it to be an illusion, because things can pass through it.\nIf a creature uses its action to examine the sound or image, the creature can determine that it is an illusion with a successful Intelligence (Investigation) check against your spell save DC. If a creature discerns the illusion for what it is, the illusion becomes faint to the creature.";
                case Spells.ID.MIRAGE_ARCANE:
                    return "You make terrain in an area up to 1 mile square look, sound, smell, and even feel like some other sort of terrain. The terrain's general shape remains the same, however. Open fields or a road could be made to resemble a swamp, hill, crevasse, or some other difficult or impassable terrain. A pond can be made to seem like a grassy meadow, a precipice like a gentle slope, or a rock-strewn gully like a wide and smooth road.\nSimilarly, you can alter the appearance of structures, or add them where none are present. The spell doesn't disguise, conceal, or add creatures.\nThe illusion includes audible, visual, tactile, and olfactory elements, so it can turn clear ground into difficult terrain (or vice versa) or otherwise impede movement through the area. Any piece of the illusory terrain (such as a rock or stick) that is removed from the spell's area disappears immediately.\nCreatures with truesight can see through the illusion to the terrain's true form; however, all other elements of the illusion remain, so while the creature is aware of the illusion's presence, the creature can still physically interact with the illusion.";
                case Spells.ID.MIRROR_IMAGE:
                    return "Three illusory duplicates of yourself appear in your space. Until the spell ends, the duplicates move with you and mimic your actions, shifting position so it's impossible to track which image is real. You can use your action to dismiss the illusory duplicates.\nEach time a creature targets you with an attack during the spell's duration, roll a d20 to determine whether the attack instead targets one of your duplicates.\nIf you have three duplicates, you must roll a 6 or higher to change the attack's target to a duplicate. With two duplicates, you must roll an 8 or higher. With one duplicate, you must roll an 11 or higher.\nA duplicate's AC equals 10 + your Dexterity modifier. If an attack hits a duplicate, the duplicate is destroyed. A duplicate can be destroyed only by an attack that hits it. It ignores all other damage and effects. The spell ends when all three duplicates are destroyed.\nA creature is unaffected by this spell if it can't see, if it relies on senses other than sight, such as blindsight, or if it can perceive illusions as false, as with truesight.";
                case Spells.ID.MISLEAD:
                    return "You become invisible at the same time that an illusory double of you appears where you are standing. The double lasts for the duration, but the invisibility ends if you attack or cast a spell.\nYou can use your action to move your illusory double up to twice your speed and make it gesture, speak, and behave in whatever way you choose.\nYou can see through its eyes and hear through its ears as if you were located where it is. On each of your turns as a bonus action, you can switch from using its senses to using your own, or back again. While you are using its senses, you are blinded and deafened in regard to your own surroundings.";
                case Spells.ID.MISTY_STEP:
                    return "Briefly surrounded by silvery mist, you teleport up to 30 feet to an unoccupied space that you can see.";
                case Spells.ID.MODIFY_MEMORY:
                    return "You attempt to reshape another creature's memories. One creature that you can see must make a wisdom saving throw. If you are fighting the creature, it has advantage on the saving throw. On a failed save, the target becomes charmed by you for the duration. The charmed target is incapacitated and unaware of its surroundings, though it can still hear you. If it takes any damage or is targeted by another spell, this spell ends, and none of the target's memories are modified.\nWhile this charm lasts, you can affect the target's memory of an event that it experienced within the last 24 hours and that lasted no more than 10 minutes. You can permanently eliminate all memory of the event, allow the target to recall the event with perfect clarity and exacting detail, change its memory of the details of the event, or create a memory of some other event.\nYou must speak to the target to describe how its memories are affected, and it must be able to understand your language for the modified memories to take root. Its mind fills in any gaps in the details of your description. If the spell ends before you have finished describing the modified memories, the creature's memory isn't altered. Otherwise, the modified memories take hold when the spell ends.\nA modified memory doesn't necessarily affect how a creature behaves, particularly if the memory contradicts the creature's natural inclinations, alignment, or beliefs. An illogical modified memory, such as implanting a memory of how much the creature enjoyed dousing itself in acid, is dismissed, perhaps as a bad dream. The DM might deem a modified memory too nonsensical to affect a creature in a significant manner.\nA remove curse or greater restoration spell cast on the target restores the creature's true memory.\nIf you cast this spell using a spell slot of 6th level or higher, you can alter the target's memories of an event that took place up to 7 days ago (6th level), 30 days ago (7th level), 1 year ago (8th level), or any time in the creature's past (9th level).";
                case Spells.ID.MOONBEAM:
                    return "A silvery beam of pale light shines down in a 5-foot radius, 40-foot-high cylinder centered on a point within range. Until the spell ends, dim light fills the cylinder.\nWhen a creature enters the spell's area for the first time on a turn or starts its turn there, it is engulfed in ghostly flames that cause searing pain, and it must make a constitution saving throw. It takes 2d10 radiant damage on a failed save, or half as much damage on a successful one.\nA shapechanger makes its saving throw with disadvantage. If it fails, it also instantly reverts to its original form and can't assume a different form until it leaves the spell's light.\nOn each of your turns after you cast this spell, you can use an action to move the beam 60 feet in any direction.\nWhen you cast this spell using a spell slot of 3rd level or higher, the damage increases by 1dl0 for each slot level above 2nd.";
                case Spells.ID.MOVE_EARTH:
                    return "Choose an area of terrain no larger than 40 feet on a side within range. You can reshape dirt, sand, or clay in the area in any manner you choose for the duration. You can raise or lower the area's elevation, create or fill in a trench, erect or flatten a wall, or form a pillar. The extent of any such changes can't exceed half the area's largest dimension. So, if you affect a 40-foot square, you can create a pillar up to 20 feet high, raise or lower the square's elevation by up to 20 feet, dig a trench up to 20 feet deep, and so on. It takes 10 minutes for these changes to complete.\nAt the end of every 10 minutes you spend concentrating on the spell, you can choose a new area of terrain to affect.\nBecause the terrain's transformation occurs slowly, creatures in the area can't usually be trapped or injured by the ground's movement.\nThis spell can't manipulate natural stone or stone construction. Rocks and structures shift to accommodate the new terrain. If the way you shape the terrain would make a structure unstable, it might collapse.\nSimilarly, this spell doesn't directly affect plant growth. The moved earth carries any plants along with it.";
                case Spells.ID.NONDETECTION:
                    return "For the duration, you hide a target that you touch from divination magic. The target can be a willing creature or a place or an object no larger than 10 feet in any dimension. The target can't be targeted by any divination magic or perceived through magical scrying sensors.";
                case Spells.ID.PASS_WITHOUT_TRACE:
                    return "A veil of shadows and silence radiates from you, masking you and your companions from detection. For the duration, each creature you choose within 30 feet of you (including you) has a +10 bonus to Dexterity (Stealth) checks and can't be tracked except by magical means. A creature that receives this bonus leaves behind no tracks or other traces of its passage.";
                case Spells.ID.PASSWALL:
                    return "A passage appears at a point of your choice that you can see on a wooden, plaster, or stone surface (such as a wall, a ceiling, or a floor) within range, and lasts for the duration. You choose the opening's dimensions: up to 5 feet wide, 8 feet tall, and 20 feet deep. The passage creates no instability in a structure surrounding it.\nWhen the opening disappears, any creatures or objects still in the passage created by the spell are safely ejected to an unoccupied space nearest to the surface on which you cast the spell.";
                case Spells.ID.PHANTASMAL_KILLER:
                    return "You tap into the nightmares of a creature you can see within range and create an illusory manifestation of its deepest fears, visible only to that creature. The target must make a wisdom saving throw. On a failed save, the target becomes frightened for the duration. At the start of each of the target's turns before the spell ends, the target must succeed on a wisdom saving throw or take 4d10 psychic damage. On a successful save, the spell ends.\nWhen you cast this spell using a spell slot of 5th level or higher, the damage increases by 1d10 for each slot level above 4th.";
                case Spells.ID.PHANTOM_STEED:
                    return "A Large quasi-real, horselike creature appears on the ground in an unoccupied space of your choice within range. You decide the creature's appearance, but it is equipped with a saddle, bit, and bridle. Any of the equipment created by the spell vanishes in a puff of smoke if it is carried more than 10 feet away from the steed.\nFor the duration, you or a creature you choose can ride the steed. The creature uses the statistics for a riding horse, except it has a speed of 100 feet and can travel 10 miles in an hour, or 13 miles at a fast pace. When the spell ends, the steed gradually fades, giving the rider 1 minute to dismount. The spell ends if you use an action to dismiss it or if the steed takes any damage.";
                case Spells.ID.PLANAR_ALLY:
                    return "You beseech an otherworldly entity for aid. The being must be known to you: a god, a primordial, a demon prince, or some other being of cosmic power. That entity sends a celestial, an elemental, or a fiend loyal to it to aid you, making the creature appear in an unoccupied space within range. If you know a specific creature's name, you can speak that name when you cast this spell to request that creature, though you might get a different creature anyway (DM's choice).\nWhen the creature appears, it is under no compulsion to behave in any particular way. You can ask the creature to perform a service in exchange for payment, but it isn't obliged to do so. The requested task could range from simple (fly us across the chasm, or help us fight a battle) to complex (spy on our enemies, or protect us during our foray into the dungeon). You must be able to communicate with the creature to bargain for its services.\nPayment can take a variety of forms. A celestial might require a sizable donation of gold or magic items to an allied temple, while a fiend might demand a living sacrifice or a gift of treasure. Some creatures might exchange their service for a quest undertaken by you.\nAs a rule of thumb, a task that can be measured in minutes requires a payment worth 100 gp per minute. A task measured in hours requires 1,000 gp per hour. And a task measured in days (up to 10 days) requires 10,000 gp per day. The DM can adjust these payments based on the circumstances under which you cast the spell. If the task is aligned with the creature's ethos, the payment might be halved or even waived. Nonhazardous tasks typically require only half the suggested payment, while especially dangerous tasks might require a greater gift. Creatures rarely accept tasks that seem suicidal.\nAfter the creature completes the task, or when the agreed-upon duration of service expires, the creature returns to its home plane after reporting back to you, if appropriate to the task and if possible. If you are unable to agree on a price for the creature's service, the creature immediately returns to its home plane.\nA creature enlisted to join your group counts as a member of it, receiving a full share of experience points awarded.";
                case Spells.ID.PLANAR_BINDING:
                    return "With this spell, you attempt to bind a celestial, an elemental, a fey, or a fiend to your service. The creature must be within range for the entire casting of the spell. (Typically, the creature is first summoned into the center of an inverted magic circle in order to keep it trapped while this spell is cast.) At the completion of the casting, the target must make a charisma saving throw. On a failed save, it is bound to serve you for the duration. If the creature was summoned or created by another spell, that spell's duration is extended to match the duration of this spell.\nA bound creature must follow your instructions to the best of its ability. You might command the creature to accompany you on an adventure, to guard a location, or to deliver a message. The creature obeys the letter of your instructions, but if the creature is hostile to you, it strives to twist your words to achieve its own objectives. If the creature carries out your instructions completely before the spell ends, it travels to you to report this fact if you are on the same plane of existence. If you are on a different plane of existence, it returns to the place where you bound it and remains there until the spell ends.\nWhen you cast this spell using a spell slot of a higher level, the duration increases to 10 days with a 6th-level slot, to 30 days with a 7th-level slot, to 180 days with an 8th-level slot, and to a year and a day with a 9th-level spell slot.";
                case Spells.ID.PLANE_SHIFT:
                    return "You and up to eight willing creatures who link hands in a circle are transported to a different plane of existence. You can specify a target destination in general terms, such as the City of Brass on the Elemental Plane of Fire or the palace of Dispater on the second level of the Nine Hells, and you appear in or near that destination. If you are trying to reach the City of Brass, for example, you might arrive in its Street of Steel, before its Gate of Ashes, or looking at the city from across the Sea of Fire, at the DM's discretion.\nAlternatively, if you know the sigil sequence of a teleportation circle on another plane of existence, this spell can take you to that circle. If the teleportation circle is too small to hold all the creatures you transported, they appear in the closest unoccupied spaces next to the circle.\nYou can use this spell to banish an unwilling creature to another plane. Choose a creature within your reach and make a melee spell attack against it. On a hit, the creature must make a charisma saving throw. If the creature fails this save, it is transported to a random location on the plane of existence you specify. A creature so transported must find its own way back to your current plane of existence.";
                case Spells.ID.PLANT_GROWTH:
                    return "This spell channels vitality into plants within a specific area. There are two possible uses for the spell, granting either immediate or long-term benefits.\nIf you cast this spell using 1 action, choose a point within range. All normal plants in a 100-foot radius centered on that point become thick and overgrown. A creature moving through the area must spend 4 feet of movement for every 1 foot it moves.\nYou can exclude one or more areas of any size within the spell's area from being affected.\nIf you cast this spell over 8 hours, you enrich the land. All plants in a half-mile radius centered on a point within range become enriched for 1 year. The plants yield twice the normal amount of food when harvested.";
                case Spells.ID.POISON_SPRAY:
                    return "You extend your hand toward a creature you can see within range and project a puff of noxious gas from your palm. The creature must succeed on a constitution saving throw or take 1d12 poison damage.\nThis spell's damage increases by 1d12 when you reach 5th level (2d12), 11th level (3d12), and 17th level (4d12).";
                case Spells.ID.POLYMORPH:
                    return "This spell transforms a creature that you can see within range into a new form. An unwilling creature must make a wisdom saving throw to avoid the effect. A shapechanger automatically succeeds on this saving throw.\nThe transformation lasts for the duration, or until the target drops to 0 hit points or dies. The new form can be any beast whose challenge rating is equal to or less than the target's (or the target's level, if it doesn't have a challenge rating). The target's game statistics, including mental ability scores, are replaced by the statistics of the chosen beast. It retains its alignment and personality.\nThe target assumes the hit points of its new form. When it reverts to its normal form, the creature returns to the number of hit points it had before it transformed. If it reverts as a result of dropping to 0 hit points, any excess damage carries over to its normal form. As long as the excess damage doesn't reduce the creature's normal form to 0 hit points, it isn't knocked unconscious.\nThe creature is limited in the actions it can perform by the nature of its new form, and it can't speak, cast spells, or take any other action that requires hands or speech.\nThe target's gear melds into the new form. The creature can't activate, use, wield, or otherwise benefit from any of its equipment.";
                case Spells.ID.POWER_WORD_KILL:
                    return "You utter a word of power that can compel one creature you can see within range to die instantly. If the creature you choose has 100 hit points or fewer, it dies. Otherwise, the spell has no effect.";
                case Spells.ID.POWER_WORD_STUN:
                    return "You speak a word of power that can overwhelm the mind of one creature you can see within range, leaving it dumbfounded. If the target has 150 hit points or fewer, it is stunned. Otherwise, the spell has no effect.\nThe stunned target must make a constitution saving throw at the end of each of its turns. On a successful save, this stunning effect ends.";
                case Spells.ID.PRAYER_OF_HEALING:
                    return "Up to six creatures of your choice that you can see within range each regain hit points equal to 2d8 + your spellcasting ability modifier. This spell has no effect on undead or constructs.\nWhen you cast this spell using a spell slot of 3rd level or higher, the healing increases by 1d8 for each slot level above 2nd.";
                case Spells.ID.PRESTIDIGITATION:
                    return "This spell is a minor magical trick that novice spellcasters use for practice. You create one of the following magical effects within 'range':\nYou create an instantaneous, harmless sensory effect, such as a shower of sparks, a puff of wind, faint musical notes, or an odd odor.\nYou instantaneously light or snuff out a candle, a torch, or a small campfire.\nYou instantaneously clean or soil an object no larger than 1 cubic foot.\nYou chill, warm, or flavor up to 1 cubic foot of nonliving material for 1 hour.\nYou make a color, a small mark, or a symbol appear on an object or a surface for 1 hour.\nYou create a nonmagical trinket or an illusory image that can fit in your hand and that lasts until the end of your next turn.\nIf you cast this spell multiple times, you can have up to three of its non-instantaneous effects active at a time, and you can dismiss such an effect as an action.";
                case Spells.ID.PRISMATIC_SPRAY:
                    return "Eight multicolored rays of light flash from your hand. Each ray is a different color and has a different power and purpose. Each creature in a 60-foot cone must make a dexterity saving throw. For each target, roll a d8 to determine which color ray affects it.\n***1. Red.*** The target takes 10d6 fire damage on a failed save, or half as much damage on a successful one.\n***2. Orange.*** The target takes 10d6 acid damage on a failed save, or half as much damage on a successful one.\n***3. Yellow.*** The target takes 10d6 lightning damage on a failed save, or half as much damage on a successful one.\n***4. Green.*** The target takes 10d6 poison damage on a failed save, or half as much damage on a successful one.\n***5. Blue.*** The target takes 10d6 cold damage on a failed save, or half as much damage on a successful one.\n***6. Indigo.*** On a failed save, the target is restrained. It must then make a constitution saving throw at the end of each of its turns. If it successfully saves three times, the spell ends. If it fails its save three times, it permanently turns to stone and is subjected to the petrified condition. The successes and failures don't need to be consecutive; keep track of both until the target collects three of a kind.\n***7. Violet.*** On a failed save, the target is blinded. It must then make a wisdom saving throw at the start of your next turn. A successful save ends the blindness. If it fails that save, the creature is transported to another plane of existence of the DM's choosing and is no longer blinded. (Typically, a creature that is on a plane that isn't its home plane is banished home, while other creatures are usually cast into the Astral or Ethereal planes.)\n***8. Special.*** The target is struck by two rays. Roll twice more, rerolling any 8.";
                case Spells.ID.PRISMATIC_WALL:
                    return "A shimmering, multicolored plane of light forms a vertical opaque wall--up to 90 feet long, 30 feet high, and 1 inch thick--centered on a point you can see within range. Alternatively, you can shape the wall into a sphere up to 30 feet in diameter centered on a point you choose within range. The wall remains in place for the duration. If you position the wall so that it passes through a space occupied by a creature, the spell fails, and your action and the spell slot are wasted.\nThe wall sheds bright light out to a range of 100 feet and dim light for an additional 100 feet. You and creatures you designate at the time you cast the spell can pass through and remain near the wall without harm. If another creature that can see the wall moves to within 20 feet of it or starts its turn there, the creature must succeed on a constitution saving throw or become blinded for 1 minute.\nThe wall consists of seven layers, each with a different color. When a creature attempts to reach into or pass through the wall, it does so one layer at a time through all the wall's layers. As it passes or reaches through each layer, the creature must make a dexterity saving throw or be affected by that layer's properties as described below.\nThe wall can be destroyed, also one layer at a time, in order from red to violet, by means specific to each layer. Once a layer is destroyed, it remains so for the duration of the spell. A rod of cancellation destroys a prismatic wall, but an antimagic field has no effect on it.\n***1. Red.*** The creature takes 10d6 fire damage on a failed save, or half as much damage on a successful one. While this layer is in place, nonmagical ranged attacks can't pass through the wall. The layer can be destroyed by dealing at least 25 cold damage to it.\n***2. Orange.*** The creature takes 10d6 acid damage on a failed save, or half as much damage on a successful one. While this layer is in place, magical ranged attacks can't pass through the wall. The layer is destroyed by a strong wind.\n***3. Yellow.*** The creature takes 10d6 lightning damage on a failed save, or half as much damage on a successful one. This layer can be destroyed by dealing at least 60 force damage to it.\n***4. Green.*** The creature takes 10d6 poison damage on a failed save, or half as much damage on a successful one. A passwall spell, or another spell of equal or greater level that can open a portal on a solid surface, destroys this layer.\n***5. Blue.*** The creature takes 10d6 cold damage on a failed save, or half as much damage on a successful one. This layer can be destroyed by dealing at least 25 fire damage to it.\n***6. Indigo.*** On a failed save, the creature is restrained. It must then make a constitution saving throw at the end of each of its turns. If it successfully saves three times, the spell ends. If it fails its save three times, it permanently turns to stone and is subjected to the petrified condition. The successes and failures don't need to be consecutive; keep track of both until the creature collects three of a kind.\nWhile this layer is in place, spells can't be cast through the wall. The layer is destroyed by bright light shed by a daylight spell or a similar spell of equal or higher level.\n***7. Violet.*** On a failed save, the creature is blinded. It must then make a wisdom saving throw at the start of your next turn. A successful save ends the blindness. If it fails that save, the creature is transported to another plane of the DM's choosing and is no longer blinded. (Typically, a creature that is on a plane that isn't its home plane is banished home, while other creatures are usually cast into the Astral or Ethereal planes.) This layer is destroyed by a dispel magic spell or a similar spell of equal or higher level that can end spells and magical effects.";
                case Spells.ID.PRIVATE_SANCTUM:
                    return "You make an area within range magically secure. The area is a cube that can be as small as 5 feet to as large as 100 feet on each side. The spell lasts for the duration or until you use an action to dismiss it.\nWhen you cast the spell, you decide what sort of security the spell provides, choosing any or all of the following properties:\n- Sound can't pass through the barrier at the edge of the warded area.\n- The barrier of the warded area appears dark and foggy, preventing vision (including darkvision) through it.\n- Sensors created by divination spells can't appear inside the protected area or pass through the barrier at its perimeter.\n- Creatures in the area can't be targeted by divination spells.\n- Nothing can teleport into or out of the warded area.\n- Planar travel is blocked within the warded area.\nCasting this spell on the same spot every day for a year makes this effect permanent.\nWhen you cast this spell using a spell slot of 5th level or higher, you can increase the size of the cube by 100 feet for each slot level beyond 4th. Thus you could protect a cube that can be up to 200 feet on one side by using a spell slot of 5th level.";
                case Spells.ID.PRODUCE_FLAME:
                    return "A flickering flame appears in your hand. The flame remains there for the duration and harms neither you nor your equipment. The flame sheds bright light in a 10-foot radius and dim light for an additional 10 feet. The spell ends if you dismiss it as an action or if you cast it again.\nYou can also attack with the flame, although doing so ends the spell. When you cast this spell, or as an action on a later turn, you can hurl the flame at a creature within 30 feet of you. Make a ranged spell attack. On a hit, the target takes 1d8 fire damage.\nThis spell's damage increases by 1d8 when you reach 5th level (2d8), 11th level (3d8), and 17th level (4d8).";
                case Spells.ID.PROGRAMMED_ILLUSION:
                    return "You create an illusion of an object, a creature, or some other visible phenomenon within range that activates when a specific condition occurs. The illusion is imperceptible until then. It must be no larger than a 30-foot cube, and you decide when you cast the spell how the illusion behaves and what sounds it makes. This scripted performance can last up to 5 minutes.\nWhen the condition you specify occurs, the illusion springs into existence and performs in the manner you described. Once the illusion finishes performing, it disappears and remains dormant for 10 minutes. After this time, the illusion can be activated again.\nThe triggering condition can be as general or as detailed as you like, though it must be based on visual or audible conditions that occur within 30 feet of the area. For example, you could create an illusion of yourself to appear and warn off others who attempt to open a trapped door, or you could set the illusion to trigger only when a creature says the correct word or phrase.\nPhysical interaction with the image reveals it to be an illusion, because things can pass through it. A creature that uses its action to examine the image can determine that it is an illusion with a successful Intelligence (Investigation) check against your spell save DC. If a creature discerns the illusion for what it is, the creature can see through the image, and any noise it makes sounds hollow to the creature.";
                case Spells.ID.PROJECT_IMAGE:
                    return "You create an illusory copy of yourself that lasts for the duration. The copy can appear at any location within range that you have seen before, regardless of intervening obstacles. The illusion looks and sounds like you but is intangible. If the illusion takes any damage, it disappears, and the spell ends.\nYou can use your action to move this illusion up to twice your speed, and make it gesture, speak, and behave in whatever way you choose. It mimics your mannerisms perfectly.\nYou can see through its eyes and hear through its ears as if you were in its space. On your turn as a bonus action, you can switch from using its senses to using your own, or back again. While you are using its senses, you are blinded and deafened in regard to your own surroundings.\nPhysical interaction with the image reveals it to be an illusion, because things can pass through it. A creature that uses its action to examine the image can determine that it is an illusion with a successful Intelligence (Investigation) check against your spell save DC. If a creature discerns the illusion for what it is, the creature can see through the image, and any noise it makes sounds hollow to the creature.";
                case Spells.ID.PROTECTION_FROM_ENERGY:
                    return "For the duration, the willing creature you touch has resistance to one damage type of your choice: acid, cold, fire, lightning, or thunder.";
                case Spells.ID.PROTECTION_FROM_EVIL_AND_GOOD:
                    return "Until the spell ends, one willing creature you touch is protected against certain types of creatures: aberrations, celestials, elementals, fey, fiends, and undead.\nThe protection grants several benefits. Creatures of those types have disadvantage on attack rolls against the target. The target also can't be charmed, frightened, or possessed by them. If the target is already charmed, frightened, or possessed by such a creature, the target has advantage on any new saving throw against the relevant effect.";
                case Spells.ID.PROTECTION_FROM_POISON:
                    return "You touch a creature. If it is poisoned, you neutralize the poison. If more than one poison afflicts the target, you neutralize one poison that you know is present, or you neutralize one at random.\nFor the duration, the target has advantage on saving throws against being poisoned, and it has resistance to poison damage.";
                case Spells.ID.PURIFY_FOOD_AND_DRINK:
                    return "All nonmagical food and drink within a 5-foot radius sphere centered on a point of your choice within range is purified and rendered free of poison and disease.";
                case Spells.ID.RAISE_DEAD:
                    return "You return a dead creature you touch to life, provided that it has been dead no longer than 10 days. If the creature's soul is both willing and at liberty to rejoin the body, the creature returns to life with 1 hit point.\nThis spell also neutralizes any poisons and cures nonmagical diseases that affected the creature at the time it died. This spell doesn't, however, remove magical diseases, curses, or similar effects; if these aren't first removed prior to casting the spell, they take effect when the creature returns to life. The spell can't return an undead creature to life.\nThis spell closes all mortal wounds, but it doesn't restore missing body parts. If the creature is lacking body parts or organs integral for its survival--its head, for instance--the spell automatically fails.\nComing back from the dead is an ordeal. The target takes a -4 penalty to all attack rolls, saving throws, and ability checks. Every time the target finishes a long rest, the penalty is reduced by 1 until it disappears.";
                case Spells.ID.RAY_OF_ENFEEBLEMENT:
                    return "A black beam of enervating energy springs from your finger toward a creature within range. Make a ranged spell attack against the target. On a hit, the target deals only half damage with weapon attacks that use Strength until the spell ends.\nAt the end of each of the target's turns, it can make a constitution saving throw against the spell. On a success, the spell ends.";
                case Spells.ID.RAY_OF_FROST:
                    return "A frigid beam of blue-white light streaks toward a creature within range. Make a ranged spell attack against the target. On a hit, it takes 1d8 cold damage, and its speed is reduced by 10 feet until the start of your next turn.\nThe spell's damage increases by 1d8 when you reach 5th level (2d8), 11th level (3d8), and 17th level (4d8).";
                case Spells.ID.REGENERATE:
                    return "You touch a creature and stimulate its natural healing ability. The target regains 4d8 + 15 hit points. For the duration of the spell, the target regains 1 hit point at the start of each of its turns (10 hit points each minute).\nThe target's severed body members (fingers, legs, tails, and so on), if any, are restored after 2 minutes. If you have the severed part and hold it to the stump, the spell instantaneously causes the limb to knit to the stump.";
                case Spells.ID.REINCARNATE:
                    return "You touch a dead humanoid or a piece of a dead humanoid. Provided that the creature has been dead no longer than 10 days, the spell forms a new adult body for it and then calls the soul to enter that body. If the target's soul isn't free or willing to do so, the spell fails.\nThe magic fashions a new body for the creature to inhabit, which likely causes the creature's race to change. The DM rolls a d 100 and consults the following table to determine what form the creature takes when restored to life, or the DM chooses a form.\nThe reincarnated creature recalls its former life and experiences. It retains the capabilities it had in its original form, except it exchanges its original race for the new one and changes its racial traits accordingly.";
                case Spells.ID.REMOVE_CURSE:
                    return "At your touch, all curses affecting one creature or object end. If the object is a cursed magic item, its curse remains, but the spell breaks its owner's attunement to the object so it can be removed or discarded.";
                case Spells.ID.RESILIENT_SPHERE:
                    return "A sphere of shimmering force encloses a creature or object of Large size or smaller within range. An unwilling creature must make a dexterity saving throw. On a failed save, the creature is enclosed for the duration.\nNothing--not physical objects, energy, or other spell effects--can pass through the barrier, in or out, though a creature in the sphere can breathe there. The sphere is immune to all damage, and a creature or object inside can't be damaged by attacks or effects originating from outside, nor can a creature inside the sphere damage anything outside it.\nThe sphere is weightless and just large enough to contain the creature or object inside. An enclosed creature can use its action to push against the sphere's walls and thus roll the sphere at up to half the creature's speed. Similarly, the globe can be picked up and moved by other creatures.\nA disintegrate spell targeting the globe destroys it without harming anything inside it.";
                case Spells.ID.RESISTANCE:
                    return "You touch one willing creature. Once before the spell ends, the target can roll a d4 and add the number rolled to one saving throw of its choice. It can roll the die before or after making the saving throw. The spell then ends.";
                case Spells.ID.RESURRECTION:
                    return "You touch a dead creature that has been dead for no more than a century, that didn't die of old age, and that isn't undead. If its soul is free and willing, the target returns to life with all its hit points.\nThis spell neutralizes any poisons and cures normal diseases afflicting the creature when it died. It doesn't, however, remove magical diseases, curses, and the like; if such effects aren't removed prior to casting the spell, they afflict the target on its return to life.\nThis spell closes all mortal wounds and restores any missing body parts.\nComing back from the dead is an ordeal. The target takes a -4 penalty to all attack rolls, saving throws, and ability checks. Every time the target finishes a long rest, the penalty is reduced by 1 until it disappears.\nCasting this spell to restore life to a creature that has been dead for one year or longer taxes you greatly. Until you finish a long rest, you can't cast spells again, and you have disadvantage on all attack rolls, ability checks, and saving throws.";
                case Spells.ID.REVERSE_GRAVITY:
                    return "This spell reverses gravity in a 50-foot-radius, 100-foot high cylinder centered on a point within range. All creatures and objects that aren't somehow anchored to the ground in the area fall upward and reach the top of the area when you cast this spell. A creature can make a dexterity saving throw to grab onto a fixed object it can reach, thus avoiding the fall.\nIf some solid object (such as a ceiling) is encountered in this fall, falling objects and creatures strike it just as they would during a normal downward fall. If an object or creature reaches the top of the area without striking anything, it remains there, oscillating slightly, for the duration.\nAt the end of the duration, affected objects and creatures fall back down.";
                case Spells.ID.REVIVIFY:
                    return "You touch a creature that has died within the last minute. That creature returns to life with 1 hit point. This spell can't return to life a creature that has died of old age, nor can it restore any missing body parts.";
                case Spells.ID.ROPE_TRICK:
                    return "You touch a length of rope that is up to 60 feet long. One end of the rope then rises into the air until the whole rope hangs perpendicular to the ground. At the upper end of the rope, an invisible entrance opens to an extradimensional space that lasts until the spell ends.\nThe extradimensional space can be reached by climbing to the top of the rope. The space can hold as many as eight Medium or smaller creatures. The rope can be pulled into the space, making the rope disappear from view outside the space.\nAttacks and spells can't cross through the entrance into or out of the extradimensional space, but those inside can see out of it as if through a 3-foot-by-5-foot window centered on the rope.\nAnything inside the extradimensional space drops out when the spell ends.";
                case Spells.ID.SACRED_FLAME:
                    return "Flame-like radiance descends on a creature that you can see within range. The target must succeed on a dexterity saving throw or take 1d8 radiant damage. The target gains no benefit from cover for this saving throw.\nThe spell's damage increases by 1d8 when you reach 5th level (2d8), 11th level (3d8), and 17th level (4d8).";
                case Spells.ID.SANCTUARY:
                    return "You ward a creature within range against attack. Until the spell ends, any creature who targets the warded creature with an attack or a harmful spell must first make a wisdom saving throw. On a failed save, the creature must choose a new target or lose the attack or spell. This spell doesn't protect the warded creature from area effects, such as the explosion of a fireball.\nIf the warded creature makes an attack or casts a spell that affects an enemy creature, this spell ends.";
                case Spells.ID.SCORCHING_RAY:
                    return "You create three rays of fire and hurl them at targets within range. You can hurl them at one target or several.\nMake a ranged spell attack for each ray. On a hit, the target takes 2d6 fire damage.\nWhen you cast this spell using a spell slot of 3rd level or higher, you create one additional ray for each slot level above 2nd.";
                case Spells.ID.SCRYING:
                    return "You can see and hear a particular creature you choose that is on the same plane of existence as you. The target must make a wisdom saving throw, which is modified by how well you know the target and the sort of physical connection you have to it. If a target knows you're casting this spell, it can fail the saving throw voluntarily if it wants to be observed.\nOn a successful save, the target isn't affected, and you can't use this spell against it again for 24 hours.\nOn a failed save, the spell creates an invisible sensor within 10 feet of the target. You can see and hear through the sensor as if you were there. The sensor moves with the target, remaining within 10 feet of it for the duration. A creature that can see invisible objects sees the sensor as a luminous orb about the size of your fist.\nInstead of targeting a creature, you can choose a location you have seen before as the target of this spell. When you do, the sensor appears at that location and doesn't move.";
                case Spells.ID.SECRET_CHEST:
                    return "You hide a chest, and all its contents, on the Ethereal Plane. You must touch the chest and the miniature replica that serves as a material component for the spell. The chest can contain up to 12 cubic feet of nonliving material (3 feet by 2 feet by 2 feet).\nWhile the chest remains on the Ethereal Plane, you can use an action and touch the replica to recall the chest. It appears in an unoccupied space on the ground within 5 feet of you. You can send the chest back to the Ethereal Plane by using an action and touching both the chest and the replica.\nAfter 60 days, there is a cumulative 5 percent chance per day that the spell's effect ends. This effect ends if you cast this spell again, if the smaller replica chest is destroyed, or if you choose to end the spell as an action. If the spell ends and the larger chest is on the Ethereal Plane, it is irretrievably lost.";
                case Spells.ID.SEE_INVISIBILITY:
                    return "For the duration of the spell, you see invisible creatures and objects as if they were visible, and you can see through Ethereal. The ethereal objects and creatures appear ghostly translucent.";
                case Spells.ID.SEEMING:
                    return "This spell allows you to change the appearance of any number of creatures that you can see within range. You give each target you choose a new, illusory appearance. An unwilling target can make a charisma saving throw, and if it succeeds, it is unaffected by this spell.\nThe spell disguises physical appearance as well as clothing, armor, weapons, and equipment. You can make each creature seem 1 foot shorter or taller and appear thin, fat, or in between. You can't change a target's body type, so you must choose a form that has the same basic arrangement of limbs. Otherwise, the extent of the illusion is up to you. The spell lasts for the duration, unless you use your action to dismiss it sooner.\nThe changes wrought by this spell fail to hold up to physical inspection. For example, if you use this spell to add a hat to a creature's outfit, objects pass through the hat, and anyone who touches it would feel nothing or would feel the creature's head and hair. If you use this spell to appear thinner than you are, the hand of someone who reaches out to touch you would bump into you while it was seemingly still in midair.\nA creature can use its action to inspect a target and make an Intelligence (Investigation) check against your spell save DC. If it succeeds, it becomes aware that the target is disguised.";
                case Spells.ID.SENDING:
                    return "You send a short message of twenty-five words or less to a creature with which you are familiar. The creature hears the message in its mind, recognizes you as the sender if it knows you, and can answer in a like manner immediately. The spell enables creatures with Intelligence scores of at least 1 to understand the meaning of your message.\nYou can send the message across any distance and even to other planes of existence, but if the target is on a different plane than you, there is a 5 percent chance that the message doesn't arrive.";
                case Spells.ID.SEQUESTER:
                    return "By means of this spell, a willing creature or an object can be hidden away, safe from detection for the duration. When you cast the spell and touch the target, it becomes invisible and can't be targeted by divination spells or perceived through scrying sensors created by divination spells.\nIf the target is a creature, it falls into a state of suspended animation. Time ceases to flow for it, and it doesn't grow older.\nYou can set a condition for the spell to end early. The condition can be anything you choose, but it must occur or be visible within 1 mile of the target. Examples include \"after 1,000 years\" or \"when the tarrasque awakens.\" This spell also ends if the target takes any damage.";
                case Spells.ID.SHAPECHANGE:
                    return "You assume the form of a different creature for the duration. The new form can be of any creature with a challenge rating equal to your level or lower. The creature can't be a construct or an undead, and you must have seen the sort of creature at least once. You transform into an average example of that creature, one without any class levels or the Spellcasting trait.\nYour game statistics are replaced by the statistics of the chosen creature, though you retain your alignment and Intelligence, Wisdom, and Charisma scores. You also retain all of your skill and saving throw proficiencies, in addition to gaining those of the creature. If the creature has the same proficiency as you and the bonus listed in its statistics is higher than yours, use the creature's bonus in place of yours. You can't use any legendary actions or lair actions of the new form.\nYou assume the hit points and Hit Dice of the new form. When you revert to your normal form, you return to the number of hit points you had before you transformed. If you revert as a result of dropping to 0 hit points, any excess damage carries over to your normal form. As long as the excess damage doesn't reduce your normal form to 0 hit points, you aren't knocked unconscious.\nYou retain the benefit of any features from your class, race, or other source and can use them, provided that your new form is physically capable of doing so. You can't use any special senses you have (for example, darkvision) unless your new form also has that sense. You can only speak if the creature can normally speak.\nWhen you transform, you choose whether your equipment falls to the ground, merges into the new form, or is worn by it. Worn equipment functions as normal. The DM determines whether it is practical for the new form to wear a piece of equipment, based on the creature's shape and size. Your equipment doesn't change shape or size to match the new form, and any equipment that the new form can't wear must either fall to the ground or merge into your new form. Equipment that merges has no effect in that state.\nDuring this spell's duration, you can use your action to assume a different form following the same restrictions and rules for the original form, with one exception: if your new form has more hit points than your current one, your hit points remain at their current value.";
                case Spells.ID.SHATTER:
                    return "A sudden loud ringing noise, painfully intense, erupts from a point of your choice within range. Each creature in a 10-foot-radius sphere centered on that point must make a Constitution saving throw. A creature takes 3d8 thunder damage on a failed save, or half as much damage on a successful one. A creature made of inorganic material such as stone, crystal, or metal has disadvantage on this saving throw.\nA non-magical item that is not worn or carried also suffers damage if it is in the area of the spell.\nWhen you cast this spell using a 3 or higher level spell slot, the damage of the spell increases by 1d8 for each level of higher spell slot 2.";
                case Spells.ID.SHIELD:
                    return "An invisible barrier of magical force appears and protects you. Until the start of your next turn, you have a +5 bonus to AC, including against the triggering attack, and you take no damage from magic missile.";
                case Spells.ID.SHIELD_OF_FAITH:
                    return "A shimmering field appears and surrounds a creature of your choice within range, granting it a +2 bonus to AC for the duration.";
                case Spells.ID.SHILLELAGH:
                    return "The wood of a club or a quarterstaff you are holding is imbued with nature's power. For the duration, you can use your spellcasting ability instead of Strength for the attack and damage rolls of melee attacks using that weapon, and the weapon's damage die becomes a d8. The weapon also becomes magical, if it isn't already. The spell ends if you cast it again or if you let go of the weapon.";
                case Spells.ID.SHOCKING_GRASP:
                    return "Lightning springs from your hand to deliver a shock to a creature you try to touch. Make a melee spell attack against the target. You have advantage on the attack roll if the target is wearing armor made of metal. On a hit, the target takes 1d8 lightning damage, and it can't take reactions until the start of its next turn.\nThe spell's damage increases by 1d8 when you reach 5th level (2d8), 11th level (3d8), and 17th level (4d8).";
                case Spells.ID.SILENCE:
                    return "For the duration, no sound can be created within or pass through a 20-foot-radius sphere centered on a point you choose within range. Any creature or object entirely inside the sphere is immune to thunder damage, and creatures are deafened while entirely inside it.\nCasting a spell that includes a verbal component is impossible there.";
                case Spells.ID.SILENT_IMAGE:
                    return "You create the image of an object, a creature, or some other visible phenomenon that is no larger than a 15-foot cube. The image appears at a spot within range and lasts for the duration. The image is purely visual; it isn't accompanied by sound, smell, or other sensory effects.\nYou can use your action to cause the image to move to any spot within range. As the image changes location, you can alter its appearance so that its movements appear natural for the image. For example, if you create an image of a creature and move it, you can alter the image so that it appears to be walking.\nPhysical interaction with the image reveals it to be an illusion, because things can pass through it. A creature that uses its action to examine the image can determine that it is an illusion with a successful Intelligence (Investigation) check against your spell save DC. If a creature discerns the illusion for what it is, the creature can see through the image.";
                case Spells.ID.SIMULACRUM:
                    return "You shape an illusory duplicate of one beast or humanoid that is within range for the entire casting time of the spell. The duplicate is a creature, partially real and formed from ice or snow, and it can take actions and otherwise be affected as a normal creature. It appears to be the same as the original, but it has half the creature's hit point maximum and is formed without any equipment. Otherwise, the illusion uses all the statistics of the creature it duplicates.\nThe simulacrum is friendly to you and creatures you designate. It obeys your spoken commands, moving and acting in accordance with your wishes and acting on your turn in combat. The simulacrum lacks the ability to learn or become more powerful, so it never increases its level or other abilities, nor can it regain expended spell slots.\nIf the simulacrum is damaged, you can repair it in an alchemical laboratory, using rare herbs and minerals worth 100 gp per hit point it regains. The simulacrum lasts until it drops to 0 hit points, at which point it reverts to snow and melts instantly.\nIf you cast this spell again, any currently active duplicates you created with this spell are instantly destroyed.";
                case Spells.ID.SLEEP:
                    return "This spell sends creatures into a magical slumber. Roll 5d8; the total is how many hit points of creatures this spell can affect. Creatures within 20 feet of a point you choose within range are affected in ascending order of their current hit points (ignoring unconscious creatures).\nStarting with the creature that has the lowest current hit points, each creature affected by this spell falls unconscious until the spell ends, the sleeper takes damage, or someone uses an action to shake or slap the sleeper awake. Subtract each creature's hit points from the total before moving on to the creature with the next lowest hit points. A creature's hit points must be equal to or less than the remaining total for that creature to be affected.\nUndead and creatures immune to being charmed aren't affected by this spell.\nWhen you cast this spell using a spell slot of 2nd level or higher, roll an additional 2d8 for each slot level above 1st.";
                case Spells.ID.SLEET_STORM:
                    return "Until the spell ends, freezing rain and sleet fall in a 20-foot-tall cylinder with a 40-foot radius centered on a point you choose within range. The area is heavily obscured, and exposed flames in the area are doused.\nThe ground in the area is covered with slick ice, making it difficult terrain. When a creature enters the spell's area for the first time on a turn or starts its turn there, it must make a dexterity saving throw. On a failed save, it falls prone.\nIf a creature is concentrating in the spell's area, the creature must make a successful constitution saving throw against your spell save DC or lose concentration.";
                case Spells.ID.SLOW:
                    return "You alter time around up to six creatures of your choice in a 40-foot cube within range. Each target must succeed on a wisdom saving throw or be affected by this spell for the duration.\nAn affected target's speed is halved, it takes a -2 penalty to AC and dexterity saving throws, and it can't use reactions. On its turn, it can use either an action or a bonus action, not both. Regardless of the creature's abilities or magic items, it can't make more than one melee or ranged attack during its turn.\nIf the creature attempts to cast a spell with a casting time of 1 action, roll a d20. On an 11 or higher, the spell doesn't take effect until the creature's next turn, and the creature must use its action on that turn to complete the spell. If it can't, the spell is wasted.\nA creature affected by this spell makes another wisdom saving throw at the end of its turn. On a successful save, the effect ends for it.";
                case Spells.ID.SPARE_THE_DYING:
                    return "You touch a living creature that has 0 hit points. The creature becomes stable. This spell has no effect on undead or constructs.";
                case Spells.ID.SPEAK_WITH_ANIMALS:
                    return "You gain the ability to comprehend and verbally communicate with beasts for the duration. The knowledge and awareness of many beasts is limited by their intelligence, but at a minimum, beasts can give you information about nearby locations and monsters, including whatever they can perceive or have perceived within the past day. You might be able to persuade a beast to perform a small favor for you, at the DM's discretion.";
                case Spells.ID.SPEAK_WITH_DEAD:
                    return "You grant the semblance of life and intelligence to a corpse of your choice within range, allowing it to answer the questions you pose. The corpse must still have a mouth and can't be undead. The spell fails if the corpse was the target of this spell within the last 10 days.\nUntil the spell ends, you can ask the corpse up to five questions. The corpse knows only what it knew in life, including the languages it knew. Answers are usually brief, cryptic, or repetitive, and the corpse is under no compulsion to offer a truthful answer if you are hostile to it or it recognizes you as an enemy. This spell doesn't return the creature's soul to its body, only its animating spirit. Thus, the corpse can't learn new information, doesn't comprehend anything that has happened since it died, and can't speculate about future events.";
                case Spells.ID.SPEAK_WITH_PLANTS:
                    return "You imbue plants within 30 feet of you with limited sentience and animation, giving them the ability to communicate with you and follow your simple commands. You can question plants about events in the spell's area within the past day, gaining information about creatures that have passed, weather, and other circumstances.\nYou can also turn difficult terrain caused by plant growth (such as thickets and undergrowth) into ordinary terrain that lasts for the duration. Or you can turn ordinary terrain where plants are present into difficult terrain that lasts for the duration, causing vines and branches to hinder pursuers, for example.\nPlants might be able to perform other tasks on your behalf, at the DM's discretion. The spell doesn't enable plants to uproot themselves and move about, but they can freely move branches, tendrils, and stalks.\nIf a plant creature is in the area, you can communicate with it as if you shared a common language, but you gain no magical ability to influence it.\nThis spell can cause the plants created by the entangle spell to release a restrained creature.";
                case Spells.ID.SPIDER_CLIMB:
                    return "Until the spell ends, one willing creature you touch gains the ability to move up, down, and across vertical surfaces and upside down along ceilings, while leaving its hands free. The target also gains a climbing speed equal to its walking speed.";
                case Spells.ID.SPIKE_GROWTH:
                    return "The ground in a 20-foot radius centered on a point within range twists and sprouts hard spikes and thorns. The area becomes difficult terrain for the duration. When a creature moves into or within the area, it takes 2d4 piercing damage for every 5 feet it travels.\nThe transformation of the ground is camouflaged to look natural. Any creature that can't see the area at the time the spell is cast can make a Wisdom (Perciption) check against your spell save DC to recognize the terrain as hazardous before entering it.";
                case Spells.ID.SPIRIT_GUARDIANS:
                    return "You call forth spirits to protect you. They flit around you to a distance of 15 feet for the duration. If you are good or neutral, their spectral form appears angelic or fey (your choice). If you are evil, they appear fiendish.\nWhen you cast this spell, you can designate any number of creatures you can see to be unaffected by it. An affected creature's speed is halved in the area, and when the creature enters the area for the first time on a turn or starts its turn there, it must make a wisdom saving throw. On a failed save, the creature takes 3d8 radiant damage (if you are good or neutral) or 3d8 necrotic damage (if you are evil). On a successful save, the creature takes half as much damage.\nWhen you cast this spell using a spell slot of 4th level or higher, the damage increases by 1d8 for each slot level above 3rd.";
                case Spells.ID.SPIRITUAL_WEAPON:
                    return "You create a floating, spectral weapon within range that lasts for the duration or until you cast this spell again. When you cast the spell, you can make a melee spell attack against a creature within 5 feet of the weapon. On a hit, the target takes force damage equal to 1d8 + your spellcasting ability modifier.\nAs a bonus action on your turn, you can move the weapon up to 20 feet and repeat the attack against a creature within 5 feet of it.\nThe weapon can take whatever form you choose. Clerics of deities who are associated with a particular weapon (as St. Cuthbert is known for his mace and Thor for his hammer) make this spell's effect resemble that weapon.\nWhen you cast this spell using a spell slot of 3rd level or higher, the damage increases by 1d8 for every two slot levels above the 2nd.";
                case Spells.ID.STINKING_CLOUD:
                    return "You create a 20-foot-radius sphere of yellow, nauseating gas centered on a point within range. The cloud spreads around corners, and its area is heavily obscured. The cloud lingers in the air for the duration.\nEach creature that is completely within the cloud at the start of its turn must make a constitution saving throw against poison. On a failed save, the creature spends its action that turn retching and reeling. Creatures that don't need to breathe or are immune to poison automatically succeed on this saving throw.\nA moderate wind (at least 10 miles per hour) disperses the cloud after 4 rounds. A strong wind (at least 20 miles per hour) disperses it after 1 round.";
                case Spells.ID.STONE_SHAPE:
                    return "You touch a stone object of Medium size or smaller or a section of stone no more than 5 feet in any dimension and form it into any shape that suits your purpose. So, for example, you could shape a large rock into a weapon, idol, or coffer, or make a small passage through a wall, as long as the wall is less than 5 feet thick. You could also shape a stone door or its frame to seal the door shut. The object you create can have up to two hinges and a latch, but finer mechanical detail isn't possible.";
                case Spells.ID.STONESKIN:
                    return "This spell turns the flesh of a willing creature you touch as hard as stone. Until the spell ends, the target has resistance to nonmagical bludgeoning, piercing, and slashing damage.";
                case Spells.ID.STORM_OF_VENGEANCE:
                    return "A churning storm cloud forms, centered on a point you can see and spreading to a radius of 360 feet. Lightning flashes in the area, thunder booms, and strong winds roar. Each creature under the cloud (no more than 5,000 feet beneath the cloud) when it appears must make a constitution saving throw. On a failed save, a creature takes 2d6 thunder damage and becomes deafened for 5 minutes.\nEach round you maintain concentration on this spell, the storm produces additional effects on your turn.\n***Round 2.*** Acidic rain falls from the cloud. Each creature and object under the cloud takes 1d6 acid damage.\n***Round 3.*** You call six bolts of lightning from the cloud to strike six creatures or objects of your choice beneath the cloud. A given creature or object can't be struck by more than one bolt. A struck creature must make a dexterity saving throw. The creature takes 10d6 lightning damage on a failed save, or half as much damage on a successful one.\n***Round 4.*** Hailstones rain down from the cloud. Each creature under the cloud takes 2d6 bludgeoning damage.\n***Round 5-10.*** Gusts and freezing rain assail the area under the cloud. The area becomes difficult terrain and is heavily obscured. Each creature there takes 1d6 cold damage. Ranged weapon attacks in the area are impossible. The wind and rain count as a severe distraction for the purposes of maintaining concentration on spells. Finally, gusts of strong wind (ranging from 20 to 50 miles per hour) automatically disperse fog, mists, and similar phenomena in the area, whether mundane or magical.";
                case Spells.ID.SUGGESTION:
                    return "You suggest a course of activity (limited to a sentence or two) and magically influence a creature you can see within range that can hear and understand you. Creatures that can't be charmed are immune to this effect. The suggestion must be worded in such a manner as to make the course of action sound reasonable. Asking the creature to stab itself, throw itself onto a spear, immolate itself, or do some other obviously harmful act ends the spell.\nThe target must make a wisdom saving throw. On a failed save, it pursues the course of action you described to the best of its ability. The suggested course of action can continue for the entire duration. If the suggested activity can be completed in a shorter time, the spell ends when the subject finishes what it was asked to do.\nYou can also specify conditions that will trigger a special activity during the duration. For example, you might suggest that a knight give her warhorse to the first beggar she meets. If the condition isn't met before the spell expires, the activity isn't performed.\nIf you or any of your companions damage the target, the spell ends.";
                case Spells.ID.SUNBEAM:
                    return "A beam of brilliant light flashes out from your hand in a 5-foot-wide, 60-foot-long line. Each creature in the line must make a constitution saving throw. On a failed save, a creature takes 6d8 radiant damage and is blinded until your next turn. On a successful save, it takes half as much damage and isn't blinded by this spell. Undead and oozes have disadvantage on this saving throw.\nYou can create a new line of radiance as your action on any turn until the spell ends.\nFor the duration, a mote of brilliant radiance shines in your hand. It sheds bright light in a 30-foot radius and dim light for an additional 30 feet. This light is sunlight.";
                case Spells.ID.SUNBURST:
                    return "Brilliant sunlight flashes in a 60-foot radius centered on a point you choose within range. Each creature in that light must make a constitution saving throw. On a failed save, a creature takes 12d6 radiant damage and is blinded for 1 minute. On a successful save, it takes half as much damage and isn't blinded by this spell. Undead and oozes have disadvantage on this saving throw.\nA creature blinded by this spell makes another constitution saving throw at the end of each of its turns. On a successful save, it is no longer blinded.\nThis spell dispels any darkness in its area that was created by a spell.";
                case Spells.ID.SYMBOL:
                    return "When you cast this spell, you inscribe a harmful glyph either on a surface (such as a section of floor, a wall, or a table) or within an object that can be closed to conceal the glyph (such as a book, a scroll, or a treasure chest). If you choose a surface, the glyph can cover an area of the surface no larger than 10 feet in diameter. If you choose an object, that object must remain in its place; if the object is moved more than 10 feet from where you cast this spell, the glyph is broken, and the spell ends without being triggered.\nThe glyph is nearly invisible, requiring an Intelligence (Investigation) check against your spell save DC to find it.\nYou decide what triggers the glyph when you cast the spell. For glyphs inscribed on a surface, the most typical triggers include touching or stepping on the glyph, removing another object covering it, approaching within a certain distance of it, or manipulating the object that holds it. For glyphs inscribed within an object, the most common triggers are opening the object, approaching within a certain distance of it, or seeing or reading the glyph.\nYou can further refine the trigger so the spell is activated only under certain circumstances or according to a creature's physical characteristics (such as height or weight), or physical kind (for example, the ward could be set to affect hags or shapechangers). You can also specify creatures that don't trigger the glyph, such as those who say a certain password.\nWhen you inscribe the glyph, choose one of the options below for its effect. Once triggered, the glyph glows, filling a 60-foot-radius sphere with dim light for 10 minutes, after which time the spell ends. Each creature in the sphere when the glyph activates is targeted by its effect, as is a creature that enters the sphere for the first time on a turn or ends its turn there.\n***Death.*** Each target must make a constitution saving throw, taking 10d 10 necrotic damage on a failed save, or half as much damage on a successful save.\n***Discord.*** Each target must make a constitution saving throw. On a failed save, a target bickers and argues with other creatures for 1 minute. During this time, it is incapable of meaningful communication and has disadvantage on attack rolls and ability checks.\n***Fear.*** Each target must make a wisdom saving throw and becomes frightened for 1 minute on a failed save. While frightened, the target drops whatever it is holding and must move at least 30 feet away from the glyph on each of its turns, if able.\n***Hopelessness.*** Each target must make a charisma saving throw. On a failed save, the target is overwhelmed with despair for 1 minute. During this time, it can't attack or target any creature with harmful abilities, spells, or other magical effects.\n***Insanity.*** Each target must make an intelligence saving throw. On a failed save, the target is driven insane for 1 minute. An insane creature can't take actions, can't understand what other creatures say, can't read, and speaks only in gibberish. The DM controls its movement, which is erratic.\n***Pain.*** Each target must make a constitution saving throw and becomes incapacitated with excruciating pain for 1 minute on a failed save.\n***Sleep.*** Each target must make a wisdom saving throw and falls unconscious for 10 minutes on a failed save. A creature awakens if it takes damage or if someone uses an action to shake or slap it awake.\n***Stunning.*** Each target must make a wisdom saving throw and becomes stunned for 1 minute on a failed save.";
                case Spells.ID.TELEKINESIS:
                    return "You gain the ability to move or manipulate creatures or objects by thought. When you cast the spell, and as your action each round for the duration, you can exert your will on one creature or object that you can see within range, causing the appropriate effect below. You can affect the same target round after round, or choose a new one at any time. If you switch targets, the prior target is no longer affected by the spell.\n***Creature.*** You can try to move a Huge or smaller creature. Make an ability check with your spellcasting ability contested by the creature's Strength check. If you win the contest, you move the creature up to 30 feet in any direction, including upward but not beyond the range of this spell. Until the end of your next turn, the creature is restrained in your telekinetic grip. A creature lifted upward is suspended in mid-air.\nOn subsequent rounds, you can use your action to attempt to maintain your telekinetic grip on the creature by repeating the contest.\n***Object.*** You can try to move an object that weighs up to 1,000 pounds. If the object isn't being worn or carried, you automatically move it up to 30 feet in any direction, but not beyond the range of this spell.\nIf the object is worn or carried by a creature, you must make an ability check with your spellcasting ability contested by that creature's Strength check. If you succeed, you pull the object away from that creature and can move it up to 30 feet in any direction but not beyond the range of this spell.\nYou can exert fine control on objects with your telekinetic grip, such as manipulating a simple tool, opening a door or a container, stowing or retrieving an item from an open container, or pouring the contents from a vial.";
                case Spells.ID.TELEPATHIC_BOND:
                    return "You forge a telepathic link among up to eight willing creatures of your choice within range, psychically linking each creature to all the others for the duration. Creatures with Intelligence scores of 2 or less aren't affected by this spell.\nUntil the spell ends, the targets can communicate telepathically through the bond whether or not they have a common language. The communication is possible over any distance, though it can't extend to other planes of existence.";
                case Spells.ID.TELEPORT:
                    return "This spell instantly transports you and up to eight willing creatures of your choice that you can see within range, or a single object that you can see within range, to a destination you select. If you target an object, it must be able to fit entirely inside a 10-foot cube, and it can't be held or carried by an unwilling creature.\nThe destination you choose must be known to you, and it must be on the same plane of existence as you. Your familiarity with the destination determines whether you arrive there successfully.";
                case Spells.ID.TELEPORTATION_CIRCLE:
                    return "As you cast the spell, you draw a 10-foot-diameter circle on the ground inscribed with sigils that link your location to a permanent teleportation circle of your choice whose sigil sequence you know and that is on the same plane of existence as you. A shimmering portal opens within the circle you drew and remains open until the end of your next turn. Any creature that enters the portal instantly appears within 5 feet of the destination circle or in the nearest unoccupied space if that space is occupied.\nMany major temples, guilds, and other important places have permanent teleportation circles inscribed somewhere within their confines. Each such circle includes a unique sigil sequence--a string of magical runes arranged in a particular pattern. When you first gain the ability to cast this spell, you learn the sigil sequences for two destinations on the Material Plane, determined by the DM. You can learn additional sigil sequences during your adventures. You can commit a new sigil sequence to memory after studying it for 1 minute.\nYou can create a permanent teleportation circle by casting this spell in the same location every day for one year. You need not use the circle to teleport when you cast the spell in this way.";
                case Spells.ID.THAUMATURGY:
                    return "You manifest a minor wonder, a sign of supernatural power, within range. You create one of the following magical effects within range.\n- Your voice booms up to three times as loud as normal for 1 minute.\n- You cause flames to flicker, brighten, dim, or change color for 1 minute.\n- You cause harmless tremors in the ground for 1 minute.\n- You create an instantaneous sound that originates from a point of your choice within range, such as a rumble of thunder, the cry of a raven, or ominous whispers.\n- You instantaneously cause an unlocked door or window to fly open or slam shut.\n- You alter the appearance of your eyes for 1 minute.\nIf you cast this spell multiple times, you can have up to three of its 1-minute effects active at a time, and you can dismiss such an effect as an action.";
                case Spells.ID.THUNDERWAVE:
                    return "A wave of thunderous force sweeps out from you. Each creature in a 15-foot cube originating from you must make a constitution saving throw. On a failed save, a creature takes 2d8 thunder damage and is pushed 10 feet away from you. On a successful save, the creature takes half as much damage and isn't pushed.\nIn addition, unsecured objects that are completely within the area of effect are automatically pushed 10 feet away from you by the spell's effect, and the spell emits a thunderous boom audible out to 300 feet.\nWhen you cast this spell using a spell slot of 2nd level or higher, the damage increases by 1d8 for each slot level above 1st.";
                case Spells.ID.TIME_STOP:
                    return "You briefly stop the flow of time for everyone but yourself. No time passes for other creatures, while you take 1d4 + 1 turns in a row, during which you can use actions and move as normal.\nThis spell ends if one of the actions you use during this period, or any effects that you create during this period, affects a creature other than you or an object being worn or carried by someone other than you. In addition, the spell ends if you move to a place more than 1,000 feet from the location where you cast it.";
                case Spells.ID.TINY_HUT:
                    return "A 10-foot-radius immobile dome of force springs into existence around and above you and remains stationary for the duration. The spell ends if you leave its area.\nNine creatures of Medium size or smaller can fit inside the dome with you. The spell fails if its area includes a larger creature or more than nine creatures. Creatures and objects within the dome when you cast this spell can move through it freely. All other creatures and objects are barred from passing through it. Spells and other magical effects can't extend through the dome or be cast through it. The atmosphere inside the space is comfortable and dry, regardless of the weather outside.\nUntil the spell ends, you can command the interior to become dimly lit or dark. The dome is opaque from the outside, of any color you choose, but it is transparent from the inside.";
                case Spells.ID.TONGUES:
                    return "This spell grants the creature you touch the ability to understand any spoken language it hears. Moreover, when the target speaks, any creature that knows at least one language and can hear the target understands what it says.";
                case Spells.ID.TRANSPORT_VIA_PLANTS:
                    return "This spell creates a magical link between a Large or larger inanimate plant within range and another plant, at any distance, on the same plane of existence. You must have seen or touched the destination plant at least once before. For the duration, any creature can step into the target plant and exit from the destination plant by using 5 feet of movement.";
                case Spells.ID.TREE_STRIDE:
                    return "You gain the ability to enter a tree and move from inside it to inside another tree of the same kind within 500 feet. Both trees must be living and at least the same size as you. You must use 5 feet of movement to enter a tree. You instantly know the location of all other trees of the same kind within 500 feet and, as part of the move used to enter the tree, can either pass into one of those trees or step out of the tree you're in. You appear in a spot of your choice within 5 feet of the destination tree, using another 5 feet of movement. If you have no movement left, you appear within 5 feet of the tree you entered.\nYou can use this transportation ability once per round for the duration. You must end each turn outside a tree.";
                case Spells.ID.TRUE_POLYMORPH:
                    return "Choose one creature or nonmagical object that you can see within range. You transform the creature into a different creature, the creature into an object, or the object into a creature (the object must be neither worn nor carried by another creature). The transformation lasts for the duration, or until the target drops to 0 hit points or dies. If you concentrate on this spell for the full duration, the transformation becomes permanent.\nShapechangers aren't affected by this spell. An unwilling creature can make a wisdom saving throw, and if it succeeds, it isn't affected by this spell.\n***Creature into Creature.*** If you turn a creature into another kind of creature, the new form can be any kind you choose whose challenge rating is equal to or less than the target's (or its level, if the target doesn't have a challenge rating). The target's game statistics, including mental ability scores, are replaced by the statistics of the new form. It retains its alignment and personality.\nThe target assumes the hit points of its new form, and when it reverts to its normal form, the creature returns to the number of hit points it had before it transformed. If it reverts as a result of dropping to 0 hit points, any excess damage carries over to its normal form. As long as the excess damage doesn't reduce the creature's normal form to 0 hit points, it isn't knocked unconscious.\nThe creature is limited in the actions it can perform by the nature of its new form, and it can't speak, cast spells, or take any other action that requires hands or speech unless its new form is capable of such actions.\nThe target's gear melds into the new form. The creature can't activate, use, wield, or otherwise benefit from any of its equipment.\n***Object into Creature.*** You can turn an object into any kind of creature, as long as the creature's size is no larger than the object's size and the creature's challenge rating is 9 or lower. The creature is friendly to you and your companions. It acts on each of your turns. You decide what action it takes and how it moves. The DM has the creature's statistics and resolves all of its actions and movement.\nIf the spell becomes permanent, you no longer control the creature. It might remain friendly to you, depending on how you have treated it.\n***Creature into Object.*** If you turn a creature into an object, it transforms along with whatever it is wearing and carrying into that form. The creature's statistics become those of the object, and the creature has no memory of time spent in this form, after the spell ends and it returns to its normal form.";
                case Spells.ID.TRUE_RESURRECTION:
                    return "You touch a creature that has been dead for no longer than 200 years and that died for any reason except old age. If the creature's soul is free and willing, the creature is restored to life with all its hit points.\nThis spell closes all wounds, neutralizes any poison, cures all diseases, and lifts any curses affecting the creature when it died. The spell replaces damaged or missing organs and limbs.\nThe spell can even provide a new body if the original no longer exists, in which case you must speak the creature's name. The creature then appears in an unoccupied space you choose within 10 feet of you.";
                case Spells.ID.TRUE_SEEING:
                    return "This spell gives the willing creature you touch the ability to see things as they actually are. For the duration, the creature has truesight, notices secret doors hidden by magic, and can see into the Ethereal Plane, all out to a range of 120 feet.";
                case Spells.ID.TRUE_STRIKE:
                    return "You extend your hand and point a finger at a target in range. Your magic grants you a brief insight into the target's defenses. On your next turn, you gain advantage on your first attack roll against the target, provided that this spell hasn't ended.";
                case Spells.ID.UNSEEN_SERVANT:
                    return "This spell creates an invisible, mindless, shapeless force that performs simple tasks at your command until the spell ends. The servant springs into existence in an unoccupied space on the ground within range. It has AC 10, 1 hit point, and a Strength of 2, and it can't attack. If it drops to 0 hit points, the spell ends.\nOnce on each of your turns as a bonus action, you can mentally command the servant to move up to 15 feet and interact with an object. The servant can perform simple tasks that a human servant could do, such as fetching things, cleaning, mending, folding clothes, lighting fires, serving food, and pouring wine. Once you give the command, the servant performs the task to the best of its ability until it completes the task, then waits for your next command.\nIf you command the servant to perform a task that would move it more than 60 feet away from you, the spell ends.";
                case Spells.ID.VAMPIRIC_TOUCH:
                    return "The touch of your shadow-wreathed hand can siphon life force from others to heal your wounds. Make a melee spell attack against a creature within your reach. On a hit, the target takes 3d6 necrotic damage, and you regain hit points equal to half the amount of necrotic damage dealt. Until the spell ends, you can make the attack again on each of your turns as an action.\nWhen you cast this spell using a spell slot of 4th level or higher, the damage increases by 1d6 for each slot level above 3rd.";
                case Spells.ID.VICIOUS_MOCKERY:
                    return "You unleash a string of insults laced with subtle enchantments at a creature you can see within range. If the target can hear you (though it need not understand you), it must succeed on a wisdom saving throw or take 1d4 psychic damage and have disadvantage on the next attack roll it makes before the end of its next turn.\nThis spell's damage increases by 1d4 when you reach 5th level (2d4), 11th level (3d4), and 17th level (4d4).";
                case Spells.ID.WALL_OF_FIRE:
                    return "You create a wall of fire on a solid surface within range. You can make the wall up to 60 feet long, 20 feet high, and 1 foot thick, or a ringed wall up to 20 feet in diameter, 20 feet high, and 1 foot thick. The wall is opaque and lasts for the duration.\nWhen the wall appears, each creature within its area must make a Dexterity saving throw. On a failed save, a creature takes 5d8 fire damage, or half as much damage on a successful save.\nOne side of the wall, selected by you when you cast this spell, deals 5d8 fire damage to each creature that ends its turn within 10 feet o f that side or inside the wall. A creature takes the same damage when it enters the wall for the first time on a turn or ends its turn there. The other side of the wall deals no damage.\nThe other side of the wall deals no damage.\nWhen you cast this spell using a spell slot of 5th level or higher, the damage increases by 1d8 for each slot level above 4th.";
                case Spells.ID.WALL_OF_FORCE:
                    return "An invisible wall of force springs into existence at a point you choose within range. The wall appears in any orientation you choose, as a horizontal or vertical barrier or at an angle. It can be free floating or resting on a solid surface. You can form it into a hemispherical dome or a sphere with a radius of up to 10 feet, or you can shape a flat surface made up of ten 10-foot-by-10-foot panels. Each panel must be contiguous with another panel. In any form, the wall is 1/4 inch thick. It lasts for the duration. If the wall cuts through a creature's space when it appears, the creature is pushed to one side of the wall (your choice which side).\nNothing can physically pass through the wall. It is immune to all damage and can't be dispelled by dispel magic. A disintegrate spell destroys the wall instantly, however. The wall also extends into the Ethereal Plane, blocking ethereal travel through the wall.";
                case Spells.ID.WALL_OF_ICE:
                    return "You create a wall of ice on a solid surface within range. You can form it into a hemispherical dome or a sphere with a radius of up to 10 feet, or you can shape a flat surface made up of ten 10-foot-square panels. Each panel must be contiguous with another panel. In any form, the wall is 1 foot thick and lasts for the duration.\nIf the wall cuts through a creature's space when it appears, the creature within its area is pushed to one side of the wall and must make a dexterity saving throw. On a failed save, the creature takes 10d6 cold damage, or half as much damage on a successful save.\nThe wall is an object that can be damaged and thus breached. It has AC 12 and 30 hit points per 10-foot section, and it is vulnerable to fire damage. Reducing a 10-foot section of wall to 0 hit points destroys it and leaves behind a sheet of frigid air in the space the wall occupied. A creature moving through the sheet of frigid air for the first time on a turn must make a constitution saving throw. That creature takes 5d6 cold damage on a failed save, or half as much damage on a successful one.\nWhen you cast this spell using a spell slot of 7th level or higher, the damage the wall deals when it appears increases by 2d6, and the damage from passing through the sheet of frigid air increases by 1d6, for each slot level above 6th.";
                case Spells.ID.WALL_OF_STONE:
                    return "A nonmagical wall of solid stone springs into existence at a point you choose within range. The wall is 6 inches thick and is composed of ten 10-foot-by-10-foot panels. Each panel must be contiguous with at least one other panel. Alternatively, you can create 10-foot-by-20-foot panels that are only 3 inches thick.\nIf the wall cuts through a creature's space when it appears, the creature is pushed to one side of the wall (your choice). If a creature would be surrounded on all sides by the wall (or the wall and another solid surface), that creature can make a dexterity saving throw. On a success, it can use its reaction to move up to its speed so that it is no longer enclosed by the wall.\nThe wall can have any shape you desire, though it can't occupy the same space as a creature or object. The wall doesn't need to be vertical or rest on any firm foundation. It must, however, merge with and be solidly supported by existing stone. Thus, you can use this spell to bridge a chasm or create a ramp.\nIf you create a span greater than 20 feet in length, you must halve the size of each panel to create supports. You can crudely shape the wall to create crenellations, battlements, and so on.\nThe wall is an object made of stone that can be damaged and thus breached. Each panel has AC 15 and 30 hit points per inch of thickness. Reducing a panel to 0 hit points destroys it and might cause connected panels to collapse at the DM's discretion.\nIf you maintain your concentration on this spell for its whole duration, the wall becomes permanent and can't be dispelled. Otherwise, the wall disappears when the spell ends.";
                case Spells.ID.WALL_OF_THORNS:
                    return "You create a wall of tough, pliable, tangled brush bristling with needle-sharp thorns. The wall appears within range on a solid surface and lasts for the duration. You choose to make the wall up to 60 feet long, 10 feet high, and 5 feet thick or a circle that has a 20-foot diameter and is up to 20 feet high and 5 feet thick. The wall blocks line of sight.\nWhen the wall appears, each creature within its area must make a dexterity saving throw. On a failed save, a creature takes 7d8 piercing damage, or half as much damage on a successful save.\nA creature can move through the wall, albeit slowly and painfully. For every 1 foot a creature moves through the wall, it must spend 4 feet of movement. Furthermore, the first time a creature enters the wall on a turn or ends its turn there, the creature must make a dexterity saving throw. It takes 7d8 slashing damage on a failed save, or half as much damage on a successful one.\nWhen you cast this spell using a spell slot of 7th level or higher, both types of damage increase by 1d8 for each slot level above 6th.";
                case Spells.ID.WARDING_BOND:
                    return "This spell wards a willing creature you touch and creates a mystic connection between you and the target until the spell ends. While the target is within 60 feet of you, it gains a +1 bonus to AC and saving throws, and it has resistance to all damage. Also, each time it takes damage, you take the same amount of damage.\nThe spell ends if you drop to 0 hit points or if you and the target become separated by more than 60 feet.\nIt also ends if the spell is cast again on either of the connected creatures. You can also dismiss the spell as an action.";
                case Spells.ID.WATER_BREATHING:
                    return "This spell gives a maximum of ten willing creatures within range and you can see, the ability to breathe underwater until the end of its term. Affected creatures also retain their normal breathing pattern.";
                case Spells.ID.WATER_WALK:
                    return "This spell grants the ability to move across any liquid surface--such as water, acid, mud, snow, quicksand, or lava--as if it were harmless solid ground (creatures crossing molten lava can still take damage from the heat). Up to ten willing creatures you can see within range gain this ability for the duration.\nIf you target a creature submerged in a liquid, the spell carries the target to the surface of the liquid at a rate of 60 feet per round.";
                case Spells.ID.WEB:
                    return "You conjure a mass of thick, sticky webbing at a point of your choice within range. The webs fill a 20-foot cube from that point for the duration. The webs are difficult terrain and lightly obscure their area.\nIf the webs aren't anchored between two solid masses (such as walls or trees) or layered across a floor, wall, or ceiling, the conjured web collapses on itself, and the spell ends at the start of your next turn. Webs layered over a flat surface have a depth of 5 feet.\nEach creature that starts its turn in the webs or that enters them during its turn must make a dexterity saving throw. On a failed save, the creature is restrained as long as it remains in the webs or until it breaks free.\nA creature restrained by the webs can use its action to make a Strength check against your spell save DC. If it succeeds, it is no longer restrained.\nThe webs are flammable. Any 5-foot cube of webs exposed to fire burns away in 1 round, dealing 2d4 fire damage to any creature that starts its turn in the fire.";
                case Spells.ID.WEIRD:
                    return "Drawing on the deepest fears of a group of creatures, you create illusory creatures in their minds, visible only to them. Each creature in a 30-foot-radius sphere centered on a point of your choice within range must make a wisdom saving throw. On a failed save, a creature becomes frightened for the duration. The illusion calls on the creature's deepest fears, manifesting its worst nightmares as an implacable threat. At the start of each of the frightened creature's turns, it must succeed on a wisdom saving throw or take 4d10 psychic damage. On a successful save, the spell ends for that creature.";
                case Spells.ID.WIND_WALK:
                    return "You and up to ten willing creatures you can see within range assume a gaseous form for the duration, appearing as wisps of cloud. While in this cloud form, a creature has a flying speed of 300 feet and has resistance to damage from nonmagical weapons. The only actions a creature can take in this form are the Dash action or to revert to its normal form. Reverting takes 1 minute, during which time a creature is incapacitated and can't move. Until the spell ends, a creature can revert to cloud form, which also requires the 1-minute transformation.\nIf a creature is in cloud form and flying when the effect ends, the creature descends 60 feet per round for 1 minute until it lands, which it does safely. If it can't land after 1 minute, the creature falls the remaining distance.";
                case Spells.ID.WIND_WALL:
                    return "A wall of strong wind rises from the ground at a point you choose within range. You can make the wall up to 50 feet long, 15 feet high, and 1 foot thick. You can shape the wall in any way you choose so long as it makes one continuous path along the ground. The wall lasts for the duration.\nWhen the wall appears, each creature within its area must make a strength saving throw. A creature takes 3d8 bludgeoning damage on a failed save, or half as much damage on a successful one.\nThe strong wind keeps fog, smoke, and other gases at bay. Small or smaller flying creatures or objects can't pass through the wall. Loose, lightweight materials brought into the wall fly upward. Arrows, bolts, and other ordinary projectiles launched at targets behind the wall are deflected upward and automatically miss. (Boulders hurled by giants or siege engines, and similar projectiles, are unaffected.) Creatures in gaseous form can't pass through it.";
                case Spells.ID.WISH:
                    return "Wish is the mightiest spell a mortal creature can cast. By simply speaking aloud, you can alter the very foundations of reality in accord with your desires.\nThe basic use of this spell is to duplicate any other spell of 8th level or lower. You don't need to meet any requirements in that spell, including costly components. The spell simply takes effect.\nAlternatively, you can create one of the following effects of your choice:\n- You create one object of up to 25,000 gp in value that isn't a magic item. The object can be no more than 300 feet in any dimension, and it appears in an unoccupied space you can see on the ground.\n- You allow up to twenty creatures that you can see to regain all hit points, and you end all effects on them described in the greater restoration spell.\n- You grant up to ten creatures that you can see resistance to a damage type you choose.\n- You grant up to ten creatures you can see immunity to a single spell or other magical effect for 8 hours. For instance, you could make yourself and all your companions immune to a lich's life drain attack.\n- You undo a single recent event by forcing a reroll of any roll made within the last round (including your last turn). Reality reshapes itself to accommodate the new result. For example, a wish spell could undo an opponent's successful save, a foe's critical hit, or a friend's failed save. You can force the reroll to be made with advantage or disadvantage, and you can choose whether to use the reroll or the original roll.\nYou might be able to achieve something beyond the scope of the above examples. State your wish to the GM as precisely as possible. The GM has great latitude in ruling what occurs in such an instance; the greater the wish, the greater the likelihood that something goes wrong. This spell might simply fail, the effect you desire might only be partly achieved, or you might suffer some unforeseen consequence as a result of how you worded the wish. For example, wishing that a villain were dead might propel you forward in time to a period when that villain is no longer alive, effectively removing you from the game. Similarly, wishing for a legendary magic item or artifact might instantly transport you to the presence of the item's current owner.\nThe stress of casting this spell to produce any effect other than duplicating another spell weakens you. After enduring that stress, each time you cast a spell until you finish a long rest, you take 1d10 necrotic damage per level of that spell. This damage can't be reduced or prevented in any way. In addition, your Strength drops to 3, if it isn't 3 or lower already, for 2d4 days. For each of those days that you spend resting and doing nothing more than light activity, your remaining recovery time decreases by 2 days. Finally, there is a 33 percent chance that you are unable to cast wish ever again if you suffer this stress.";
                case Spells.ID.WORD_OF_RECALL:
                    return "You and up to five willing creatures within 5 feet of you instantly teleport to a previously designated sanctuary. You and any creatures that teleport with you appear in the nearest unoccupied space to the spot you designated when you prepared your sanctuary (see below). If you cast this spell without first preparing a sanctuary, the spell has no effect.\nYou must designate a sanctuary by casting this spell within a location, such as a temple, dedicated to or strongly linked to your deity. If you attempt to cast the spell in this manner in an area that isn't dedicated to your deity, the spell has no effect.";
                case Spells.ID.ZONE_OF_TRUTH:
                    return "You create a magical zone that guards against deception in a 15-foot-radius sphere centered on a point of your choice within range. Until the spell ends, a creature that enters the spell's area for the first time on a turn or starts its turn there must make a Charisma saving throw. On a failed save, a creature can't speak a deliberate lie while in the radius. You know whether each creature succeeds or fails on its saving throw.\nAn affected creature is aware of the spell and can thus avoid answering questions to which it would normally respond with a lie. Such a creature can remain evasive in its answers as long as it remains within the boundaries of the truth.";
                default:
                    return Enum.GetName(typeof(Spells.ID), spell) + ": (Description missing)";
            }


        }
    }

    public static class MonsterTextResource {
        public static string Name(this Monsters.ID monster) {
            switch (monster) {
                case Monsters.ID.ABOLETH:
                    return "Aboleth";
                case Monsters.ID.ACOLYTE:
                    return "Acolyte";
                case Monsters.ID.ADULT_BLACK_DRAGON:
                    return "Adult Black Dragon";
                case Monsters.ID.ADULT_BLUE_DRAGON:
                    return "Adult Blue Dragon";
                case Monsters.ID.ADULT_BRASS_DRAGON:
                    return "Adult Brass Dragon";
                case Monsters.ID.ADULT_BRONZE_DRAGON:
                    return "Adult Bronze Dragon";
                case Monsters.ID.ADULT_COPPER_DRAGON:
                    return "Adult Copper Dragon";
                case Monsters.ID.ADULT_GOLD_DRAGON:
                    return "Adult Gold Dragon";
                case Monsters.ID.ADULT_GREEN_DRAGON:
                    return "Adult Green Dragon";
                case Monsters.ID.ADULT_RED_DRAGON:
                    return "Adult Red Dragon";
                case Monsters.ID.ADULT_SILVER_DRAGON:
                    return "Adult Silver Dragon";
                case Monsters.ID.ADULT_WHITE_DRAGON:
                    return "Adult White Dragon";
                case Monsters.ID.AIR_ELEMENTAL:
                    return "Air Elemental";
                case Monsters.ID.ANCIENT_BLACK_DRAGON:
                    return "Ancient Black Dragon";
                case Monsters.ID.ANCIENT_BLUE_DRAGON:
                    return "Ancient Blue Dragon";
                case Monsters.ID.ANCIENT_BRASS_DRAGON:
                    return "Ancient Brass Dragon";
                case Monsters.ID.ANCIENT_BRONZE_DRAGON:
                    return "Ancient Bronze Dragon";
                case Monsters.ID.ANCIENT_COPPER_DRAGON:
                    return "Ancient Copper Dragon";
                case Monsters.ID.ANCIENT_GOLD_DRAGON:
                    return "Ancient Gold Dragon";
                case Monsters.ID.ANCIENT_GREEN_DRAGON:
                    return "Ancient Green Dragon";
                case Monsters.ID.ANCIENT_RED_DRAGON:
                    return "Ancient Red Dragon";
                case Monsters.ID.ANCIENT_SILVER_DRAGON:
                    return "Ancient Silver Dragon";
                case Monsters.ID.ANCIENT_WHITE_DRAGON:
                    return "Ancient White Dragon";
                case Monsters.ID.ANDROSPHINX:
                    return "Androsphinx";
                case Monsters.ID.ANIMATED_ARMOR:
                    return "Animated Armor";
                case Monsters.ID.ANKHEG:
                    return "Ankheg";
                case Monsters.ID.APE:
                    return "Ape";
                case Monsters.ID.ARCHMAGE:
                    return "Archmage";
                case Monsters.ID.ASSASSIN:
                    return "Assassin";
                case Monsters.ID.AWAKENED_SHRUB:
                    return "Awakened Shrub";
                case Monsters.ID.AWAKENED_TREE:
                    return "Awakened Tree";
                case Monsters.ID.AXE_BEAK:
                    return "Axe Beak";
                case Monsters.ID.AZER:
                    return "Azer";
                case Monsters.ID.BABOON:
                    return "Baboon";
                case Monsters.ID.BADGER:
                    return "Badger";
                case Monsters.ID.BALOR:
                    return "Balor";
                case Monsters.ID.BANDIT:
                    return "Bandit";
                case Monsters.ID.BANDIT_CAPTAIN:
                    return "Bandit Captain";
                case Monsters.ID.BARBED_DEVIL:
                    return "Barbed Devil";
                case Monsters.ID.BASILISK:
                    return "Basilisk";
                case Monsters.ID.BAT:
                    return "Bat";
                case Monsters.ID.BEARDED_DEVIL:
                    return "Bearded Devil";
                case Monsters.ID.BEHIR:
                    return "Behir";
                case Monsters.ID.BERSERKER:
                    return "Berserker";
                case Monsters.ID.BLACK_BEAR:
                    return "Black Bear";
                case Monsters.ID.BLACK_DRAGON_WYRMLING:
                    return "Black Dragon Wyrmling";
                case Monsters.ID.BLACK_PUDDING:
                    return "Black Pudding";
                case Monsters.ID.BLINK_DOG:
                    return "Blink Dog";
                case Monsters.ID.BLOOD_HAWK:
                    return "Blood Hawk";
                case Monsters.ID.BLUE_DRAGON_WYRMLING:
                    return "Blue Dragon Wyrmling";
                case Monsters.ID.BOAR:
                    return "Boar";
                case Monsters.ID.BONE_DEVIL:
                    return "Bone Devil";
                case Monsters.ID.BRASS_DRAGON_WYRMLING:
                    return "Brass Dragon Wyrmling";
                case Monsters.ID.BRONZE_DRAGON_WYRMLING:
                    return "Bronze Dragon Wyrmling";
                case Monsters.ID.BROWN_BEAR:
                    return "Brown Bear";
                case Monsters.ID.BUGBEAR:
                    return "Bugbear";
                case Monsters.ID.BULETTE:
                    return "Bulette";
                case Monsters.ID.CAMEL:
                    return "Camel";
                case Monsters.ID.CAT:
                    return "Cat";
                case Monsters.ID.CENTAUR:
                    return "Centaur";
                case Monsters.ID.CHAIN_DEVIL:
                    return "Chain Devil";
                case Monsters.ID.CHIMERA:
                    return "Chimera";
                case Monsters.ID.CHUUL:
                    return "Chuul";
                case Monsters.ID.CLAY_GOLEM:
                    return "Clay Golem";
                case Monsters.ID.CLOAKER:
                    return "Cloaker";
                case Monsters.ID.CLOUD_GIANT:
                    return "Cloud Giant";
                case Monsters.ID.COCKATRICE:
                    return "Cockatrice";
                case Monsters.ID.COMMONER:
                    return "Commoner";
                case Monsters.ID.CONSTRICTOR_SNAKE:
                    return "Constrictor Snake";
                case Monsters.ID.COPPER_DRAGON_WYRMLING:
                    return "Copper Dragon Wyrmling";
                case Monsters.ID.COUATL:
                    return "Couatl";
                case Monsters.ID.CRAB:
                    return "Crab";
                case Monsters.ID.CROCODILE:
                    return "Crocodile";
                case Monsters.ID.CULT_FANATIC:
                    return "Cult Fanatic";
                case Monsters.ID.CULTIST:
                    return "Cultist";
                case Monsters.ID.DARKMANTLE:
                    return "Darkmantle";
                case Monsters.ID.DEATH_DOG:
                    return "Death Dog";
                case Monsters.ID.DEEP_GNOME__SVIRFNEBLIN:
                    return "Deep Gnome (Svirfneblin)";
                case Monsters.ID.DEER:
                    return "Deer";
                case Monsters.ID.DEVA:
                    return "Deva";
                case Monsters.ID.DIRE_WOLF:
                    return "Dire Wolf";
                case Monsters.ID.DJINNI:
                    return "Djinni";
                case Monsters.ID.DOPPELGANGER:
                    return "Doppelganger";
                case Monsters.ID.DRAFT_HORSE:
                    return "Draft Horse";
                case Monsters.ID.DRAGON_TURTLE:
                    return "Dragon Turtle";
                case Monsters.ID.DRETCH:
                    return "Dretch";
                case Monsters.ID.DRIDER:
                    return "Drider";
                case Monsters.ID.DROW:
                    return "Drow";
                case Monsters.ID.DRUID:
                    return "Druid";
                case Monsters.ID.DRYAD:
                    return "Dryad";
                case Monsters.ID.DUERGAR:
                    return "Duergar";
                case Monsters.ID.DUST_MEPHIT:
                    return "Dust Mephit";
                case Monsters.ID.EAGLE:
                    return "Eagle";
                case Monsters.ID.EARTH_ELEMENTAL:
                    return "Earth Elemental";
                case Monsters.ID.EFREETI:
                    return "Efreeti";
                case Monsters.ID.ELEPHANT:
                    return "Elephant";
                case Monsters.ID.ELK:
                    return "Elk";
                case Monsters.ID.ERINYES:
                    return "Erinyes";
                case Monsters.ID.ETTERCAP:
                    return "Ettercap";
                case Monsters.ID.ETTIN:
                    return "Ettin";
                case Monsters.ID.FIRE_ELEMENTAL:
                    return "Fire Elemental";
                case Monsters.ID.FIRE_GIANT:
                    return "Fire Giant";
                case Monsters.ID.FLESH_GOLEM:
                    return "Flesh Golem";
                case Monsters.ID.FLYING_SNAKE:
                    return "Flying Snake";
                case Monsters.ID.FLYING_SWORD:
                    return "Flying Sword";
                case Monsters.ID.FROG:
                    return "Frog";
                case Monsters.ID.FROST_GIANT:
                    return "Frost Giant";
                case Monsters.ID.GARGOYLE:
                    return "Gargoyle";
                case Monsters.ID.GELATINOUS_CUBE:
                    return "Gelatinous Cube";
                case Monsters.ID.GHAST:
                    return "Ghast";
                case Monsters.ID.GHOST:
                    return "Ghost";
                case Monsters.ID.GHOUL:
                    return "Ghoul";
                case Monsters.ID.GIANT_APE:
                    return "Giant Ape";
                case Monsters.ID.GIANT_BADGER:
                    return "Giant Badger";
                case Monsters.ID.GIANT_BAT:
                    return "Giant Bat";
                case Monsters.ID.GIANT_BOAR:
                    return "Giant Boar";
                case Monsters.ID.GIANT_CENTIPEDE:
                    return "Giant Centipede";
                case Monsters.ID.GIANT_CONSTRICTOR_SNAKE:
                    return "Giant Constrictor Snake";
                case Monsters.ID.GIANT_CRAB:
                    return "Giant Crab";
                case Monsters.ID.GIANT_CROCODILE:
                    return "Giant Crocodile";
                case Monsters.ID.GIANT_EAGLE:
                    return "Giant Eagle";
                case Monsters.ID.GIANT_ELK:
                    return "Giant Elk";
                case Monsters.ID.GIANT_FIRE_BEETLE:
                    return "Giant Fire Beetle";
                case Monsters.ID.GIANT_FROG:
                    return "Giant Frog";
                case Monsters.ID.GIANT_GOAT:
                    return "Giant Goat";
                case Monsters.ID.GIANT_HYENA:
                    return "Giant Hyena";
                case Monsters.ID.GIANT_LIZARD:
                    return "Giant Lizard";
                case Monsters.ID.GIANT_OCTOPUS:
                    return "Giant Octopus";
                case Monsters.ID.GIANT_OWL:
                    return "Giant Owl";
                case Monsters.ID.GIANT_POISONOUS_SNAKE:
                    return "Giant Poisonous Snake";
                case Monsters.ID.GIANT_RAT:
                    return "Giant Rat";
                case Monsters.ID.GIANT_RAT__DISEASED:
                    return "Giant Rat (Diseased)";
                case Monsters.ID.GIANT_SCORPION:
                    return "Giant Scorpion";
                case Monsters.ID.GIANT_SEA_HORSE:
                    return "Giant Sea Horse";
                case Monsters.ID.GIANT_SHARK:
                    return "Giant Shark";
                case Monsters.ID.GIANT_SPIDER:
                    return "Giant Spider";
                case Monsters.ID.GIANT_TOAD:
                    return "Giant Toad";
                case Monsters.ID.GIANT_VULTURE:
                    return "Giant Vulture";
                case Monsters.ID.GIANT_WASP:
                    return "Giant Wasp";
                case Monsters.ID.GIANT_WEASEL:
                    return "Giant Weasel";
                case Monsters.ID.GIANT_WOLF_SPIDER:
                    return "Giant Wolf Spider";
                case Monsters.ID.GIBBERING_MOUTHER:
                    return "Gibbering Mouther";
                case Monsters.ID.GLABREZU:
                    return "Glabrezu";
                case Monsters.ID.GLADIATOR:
                    return "Gladiator";
                case Monsters.ID.GNOLL:
                    return "Gnoll";
                case Monsters.ID.GOAT:
                    return "Goat";
                case Monsters.ID.GOBLIN:
                    return "Goblin";
                case Monsters.ID.GOLD_DRAGON_WYRMLING:
                    return "Gold Dragon Wyrmling";
                case Monsters.ID.GORGON:
                    return "Gorgon";
                case Monsters.ID.GRAY_OOZE:
                    return "Gray Ooze";
                case Monsters.ID.GREEN_DRAGON_WYRMLING:
                    return "Green Dragon Wyrmling";
                case Monsters.ID.GREEN_HAG:
                    return "Green Hag";
                case Monsters.ID.GRICK:
                    return "Grick";
                case Monsters.ID.GRIFFON:
                    return "Griffon";
                case Monsters.ID.GRIMLOCK:
                    return "Grimlock";
                case Monsters.ID.GUARD:
                    return "Guard";
                case Monsters.ID.GUARDIAN_NAGA:
                    return "Guardian Naga";
                case Monsters.ID.GYNOSPHINX:
                    return "Gynosphinx";
                case Monsters.ID.HALF_RED_DRAGON_VETERAN:
                    return "Half-Red Dragon Veteran";
                case Monsters.ID.HARPY:
                    return "Harpy";
                case Monsters.ID.HAWK:
                    return "Hawk";
                case Monsters.ID.HELL_HOUND:
                    return "Hell Hound";
                case Monsters.ID.HEZROU:
                    return "Hezrou";
                case Monsters.ID.HILL_GIANT:
                    return "Hill Giant";
                case Monsters.ID.HIPPOGRIFF:
                    return "Hippogriff";
                case Monsters.ID.HOBGOBLIN:
                    return "Hobgoblin";
                case Monsters.ID.HOMUNCULUS:
                    return "Homunculus";
                case Monsters.ID.HORNED_DEVIL:
                    return "Horned Devil";
                case Monsters.ID.HUNTER_SHARK:
                    return "Hunter Shark";
                case Monsters.ID.HYDRA:
                    return "Hydra";
                case Monsters.ID.HYENA:
                    return "Hyena";
                case Monsters.ID.ICE_DEVIL:
                    return "Ice Devil";
                case Monsters.ID.ICE_MEPHIT:
                    return "Ice Mephit";
                case Monsters.ID.IMP:
                    return "Imp";
                case Monsters.ID.INVISIBLE_STALKER:
                    return "Invisible Stalker";
                case Monsters.ID.IRON_GOLEM:
                    return "Iron Golem";
                case Monsters.ID.JACKAL:
                    return "Jackal";
                case Monsters.ID.KILLER_WHALE:
                    return "Killer Whale";
                case Monsters.ID.KNIGHT:
                    return "Knight";
                case Monsters.ID.KOBOLD:
                    return "Kobold";
                case Monsters.ID.KRAKEN:
                    return "Kraken";
                case Monsters.ID.LAMIA:
                    return "Lamia";
                case Monsters.ID.LEMURE:
                    return "Lemure";
                case Monsters.ID.LICH:
                    return "Lich";
                case Monsters.ID.LION:
                    return "Lion";
                case Monsters.ID.LIZARD:
                    return "Lizard";
                case Monsters.ID.LIZARDFOLK:
                    return "Lizardfolk";
                case Monsters.ID.MAGE:
                    return "Mage";
                case Monsters.ID.MAGMA_MEPHIT:
                    return "Magma Mephit";
                case Monsters.ID.MAGMIN:
                    return "Magmin";
                case Monsters.ID.MAMMOTH:
                    return "Mammoth";
                case Monsters.ID.MANTICORE:
                    return "Manticore";
                case Monsters.ID.MARILITH:
                    return "Marilith";
                case Monsters.ID.MASTIFF:
                    return "Mastiff";
                case Monsters.ID.MEDUSA:
                    return "Medusa";
                case Monsters.ID.MERFOLK:
                    return "Merfolk";
                case Monsters.ID.MERROW:
                    return "Merrow";
                case Monsters.ID.MIMIC:
                    return "Mimic";
                case Monsters.ID.MINOTAUR:
                    return "Minotaur";
                case Monsters.ID.MINOTAUR_SKELETON:
                    return "Minotaur Skeleton";
                case Monsters.ID.MULE:
                    return "Mule";
                case Monsters.ID.MUMMY:
                    return "Mummy";
                case Monsters.ID.MUMMY_LORD:
                    return "Mummy Lord";
                case Monsters.ID.NALFESHNEE:
                    return "Nalfeshnee";
                case Monsters.ID.NIGHT_HAG:
                    return "Night Hag";
                case Monsters.ID.NIGHTMARE:
                    return "Nightmare";
                case Monsters.ID.NOBLE:
                    return "Noble";
                case Monsters.ID.OCHRE_JELLY:
                    return "Ochre Jelly";
                case Monsters.ID.OCTOPUS:
                    return "Octopus";
                case Monsters.ID.OGRE:
                    return "Ogre";
                case Monsters.ID.OGRE_ZOMBIE:
                    return "Ogre Zombie";
                case Monsters.ID.ONI:
                    return "Oni";
                case Monsters.ID.ORC:
                    return "Orc";
                case Monsters.ID.OTYUGH:
                    return "Otyugh";
                case Monsters.ID.OWL:
                    return "Owl";
                case Monsters.ID.OWLBEAR:
                    return "Owlbear";
                case Monsters.ID.PANTHER:
                    return "Panther";
                case Monsters.ID.PEGASUS:
                    return "Pegasus";
                case Monsters.ID.PHASE_SPIDER:
                    return "Phase Spider";
                case Monsters.ID.PIT_FIEND:
                    return "Pit Fiend";
                case Monsters.ID.PLANETAR:
                    return "Planetar";
                case Monsters.ID.PLESIOSAURUS:
                    return "Plesiosaurus";
                case Monsters.ID.POISONOUS_SNAKE:
                    return "Poisonous Snake";
                case Monsters.ID.POLAR_BEAR:
                    return "Polar Bear";
                case Monsters.ID.PONY:
                    return "Pony";
                case Monsters.ID.PRIEST:
                    return "Priest";
                case Monsters.ID.PSEUDODRAGON:
                    return "Pseudodragon";
                case Monsters.ID.PURPLE_WORM:
                    return "Purple Worm";
                case Monsters.ID.QUASIT:
                    return "Quasit";
                case Monsters.ID.QUIPPER:
                    return "Quipper";
                case Monsters.ID.RAKSHASA:
                    return "Rakshasa";
                case Monsters.ID.RAT:
                    return "Rat";
                case Monsters.ID.RAVEN:
                    return "Raven";
                case Monsters.ID.RED_DRAGON_WYRMLING:
                    return "Red Dragon Wyrmling";
                case Monsters.ID.REEF_SHARK:
                    return "Reef Shark";
                case Monsters.ID.REMORHAZ:
                    return "Remorhaz";
                case Monsters.ID.RHINOCEROS:
                    return "Rhinoceros";
                case Monsters.ID.RIDING_HORSE:
                    return "Riding Horse";
                case Monsters.ID.ROC:
                    return "Roc";
                case Monsters.ID.ROPER:
                    return "Roper";
                case Monsters.ID.RUG_OF_SMOTHERING:
                    return "Rug of Smothering";
                case Monsters.ID.RUST_MONSTER:
                    return "Rust Monster";
                case Monsters.ID.SABER_TOOTHED_TIGER:
                    return "Saber-Toothed Tiger";
                case Monsters.ID.SAHUAGIN:
                    return "Sahuagin";
                case Monsters.ID.SALAMANDER:
                    return "Salamander";
                case Monsters.ID.SATYR:
                    return "Satyr";
                case Monsters.ID.SCORPION:
                    return "Scorpion";
                case Monsters.ID.SCOUT:
                    return "Scout";
                case Monsters.ID.SEA_HAG:
                    return "Sea Hag";
                case Monsters.ID.SEA_HORSE:
                    return "Sea Horse";
                case Monsters.ID.SHADOW:
                    return "Shadow";
                case Monsters.ID.SHAMBLING_MOUND:
                    return "Shambling Mound";
                case Monsters.ID.SHIELD_GUARDIAN:
                    return "Shield Guardian";
                case Monsters.ID.SHRIEKER:
                    return "Shrieker";
                case Monsters.ID.SILVER_DRAGON_WYRMLING:
                    return "Silver Dragon Wyrmling";
                case Monsters.ID.SKELETON:
                    return "Skeleton";
                case Monsters.ID.SOLAR:
                    return "Solar";
                case Monsters.ID.SPECTER:
                    return "Specter";
                case Monsters.ID.SPIDER:
                    return "Spider";
                case Monsters.ID.SPIRIT_NAGA:
                    return "Spirit Naga";
                case Monsters.ID.SPRITE:
                    return "Sprite";
                case Monsters.ID.SPY:
                    return "Spy";
                case Monsters.ID.STEAM_MEPHIT:
                    return "Steam Mephit";
                case Monsters.ID.STIRGE:
                    return "Stirge";
                case Monsters.ID.STONE_GIANT:
                    return "Stone Giant";
                case Monsters.ID.STONE_GOLEM:
                    return "Stone Golem";
                case Monsters.ID.STORM_GIANT:
                    return "Storm Giant";
                case Monsters.ID.SUCCUBUS_INCUBUS:
                    return "Succubus/Incubus";
                case Monsters.ID.SWARM_OF_BATS:
                    return "Swarm of Bats";
                case Monsters.ID.SWARM_OF_BEETLES:
                    return "Swarm of Beetles";
                case Monsters.ID.SWARM_OF_CENTIPEDES:
                    return "Swarm of Centipedes";
                case Monsters.ID.SWARM_OF_INSECTS:
                    return "Swarm of Insects";
                case Monsters.ID.SWARM_OF_POISONOUS_SNAKES:
                    return "Swarm of Poisonous Snakes";
                case Monsters.ID.SWARM_OF_QUIPPERS:
                    return "Swarm of Quippers";
                case Monsters.ID.SWARM_OF_RATS:
                    return "Swarm of Rats";
                case Monsters.ID.SWARM_OF_RAVENS:
                    return "Swarm of Ravens";
                case Monsters.ID.SWARM_OF_SPIDERS:
                    return "Swarm of Spiders";
                case Monsters.ID.SWARM_OF_WASPS:
                    return "Swarm of Wasps";
                case Monsters.ID.TARRASQUE:
                    return "Tarrasque";
                case Monsters.ID.THUG:
                    return "Thug";
                case Monsters.ID.TIGER:
                    return "Tiger";
                case Monsters.ID.TREANT:
                    return "Treant";
                case Monsters.ID.TRIBAL_WARRIOR:
                    return "Tribal Warrior";
                case Monsters.ID.TRICERATOPS:
                    return "Triceratops";
                case Monsters.ID.TROLL:
                    return "Troll";
                case Monsters.ID.TYRANNOSAURUS_REX:
                    return "Tyrannosaurus Rex";
                case Monsters.ID.UNICORN:
                    return "Unicorn";
                case Monsters.ID.VAMPIRE_VAMPIRE_FORM:
                    return "Vampire, Vampire Form";
                case Monsters.ID.VAMPIRE_BAT_FORM:
                    return "Vampire, Bat Form";
                case Monsters.ID.VAMPIRE_MIST_FORM:
                    return "Vampire, Mist Form";
                case Monsters.ID.VAMPIRE_SPAWN:
                    return "Vampire Spawn";
                case Monsters.ID.VETERAN:
                    return "Veteran";
                case Monsters.ID.VIOLET_FUNGUS:
                    return "Violet Fungus";
                case Monsters.ID.VROCK:
                    return "Vrock";
                case Monsters.ID.VULTURE:
                    return "Vulture";
                case Monsters.ID.WARHORSE:
                    return "Warhorse";
                case Monsters.ID.WARHORSE_SKELETON:
                    return "Warhorse Skeleton";
                case Monsters.ID.WATER_ELEMENTAL:
                    return "Water Elemental";
                case Monsters.ID.WEASEL:
                    return "Weasel";
                case Monsters.ID.WEREBEAR_BEAR_FORM:
                    return "Werebear, Bear Form";
                case Monsters.ID.WEREBEAR_HUMAN_FORM:
                    return "Werebear, Human Form";
                case Monsters.ID.WEREBEAR_HYBRID_FORM:
                    return "Werebear, Hybrid Form";
                case Monsters.ID.WEREBOAR_BOAR_FORM:
                    return "Wereboar, Boar Form";
                case Monsters.ID.WEREBOAR_HUMAN_FORM:
                    return "Wereboar, Human Form";
                case Monsters.ID.WEREBOAR_HYBRID_FORM:
                    return "Wereboar, Hybrid Form";
                case Monsters.ID.WERERAT_HUMAN_FORM:
                    return "Wererat, Human Form";
                case Monsters.ID.WERERAT_HYBRID_FORM:
                    return "Wererat, Hybrid Form";
                case Monsters.ID.WERERAT_RAT_FORM:
                    return "Wererat, Rat Form";
                case Monsters.ID.WERETIGER_HUMAN_FORM:
                    return "Weretiger, Human Form";
                case Monsters.ID.WERETIGER_HYBRID_FORM:
                    return "Weretiger, Hybrid Form";
                case Monsters.ID.WERETIGER_TIGER_FORM:
                    return "Weretiger, Tiger Form";
                case Monsters.ID.WEREWOLF_HUMAN_FORM:
                    return "Werewolf, Human Form";
                case Monsters.ID.WEREWOLF_HYBRID_FORM:
                    return "Werewolf, Hybrid Form";
                case Monsters.ID.WEREWOLF_WOLF_FORM:
                    return "Werewolf, Wolf Form";
                case Monsters.ID.WHITE_DRAGON_WYRMLING:
                    return "White Dragon Wyrmling";
                case Monsters.ID.WIGHT:
                    return "Wight";
                case Monsters.ID.WILL_O_WISP:
                    return "Will-o'-Wisp";
                case Monsters.ID.WINTER_WOLF:
                    return "Winter Wolf";
                case Monsters.ID.WOLF:
                    return "Wolf";
                case Monsters.ID.WORG:
                    return "Worg";
                case Monsters.ID.WRAITH:
                    return "Wraith";
                case Monsters.ID.WYVERN:
                    return "Wyvern";
                case Monsters.ID.XORN:
                    return "Xorn";
                case Monsters.ID.YOUNG_BLACK_DRAGON:
                    return "Young Black Dragon";
                case Monsters.ID.YOUNG_BLUE_DRAGON:
                    return "Young Blue Dragon";
                case Monsters.ID.YOUNG_BRASS_DRAGON:
                    return "Young Brass Dragon";
                case Monsters.ID.YOUNG_BRONZE_DRAGON:
                    return "Young Bronze Dragon";
                case Monsters.ID.YOUNG_COPPER_DRAGON:
                    return "Young Copper Dragon";
                case Monsters.ID.YOUNG_GOLD_DRAGON:
                    return "Young Gold Dragon";
                case Monsters.ID.YOUNG_GREEN_DRAGON:
                    return "Young Green Dragon";
                case Monsters.ID.YOUNG_RED_DRAGON:
                    return "Young Red Dragon";
                case Monsters.ID.YOUNG_SILVER_DRAGON:
                    return "Young Silver Dragon";
                case Monsters.ID.YOUNG_WHITE_DRAGON:
                    return "Young White Dragon";
                case Monsters.ID.ZOMBIE:
                    return "Zombie";
                default:
                    return Enum.GetName(typeof(Monsters.ID), monster) + ": (Name missing)";
            }
        }

        public static string Description(this Monsters.ID monster) {
            switch (monster) {
                case Monsters.ID.ACOLYTE:
                    return "Acolytes are junior members of a clergy, usually answerable to a priest. They perform a variety of functions in a temple and are granted minor spellcasting power by their deities.";
                case Monsters.ID.ARCHMAGE:
                    return "Archmages are powerful (and usually quite old) spellcasters dedicated to the study of the arcane arts. Benevolent ones counsel kings and queens, while evil ones rule as tyrants and pursue lichdom. Those who are neither good nor evil sequester themselves in remote towers to practice their magic without interruption. \n\nAn archmage typically has one or more apprentice mages, and an archmage’s abode has numerous magical wards and guardians to discourage interlopers.";
                case Monsters.ID.ASSASSIN:
                    return "Trained in the use of poison, assassins are remorseless killers who work for nobles, guildmasters, sovereigns, and anyone else who can afford them.";
                case Monsters.ID.AWAKENED_SHRUB:
                    return "An awakened shrub is an ordinary shrub given sentience and mobility by the awaken spell or similar magic.";
                case Monsters.ID.AWAKENED_TREE:
                    return "An awakened tree is an ordinary tree given sentience and mobility by the awaken spell or similar magic.";
                case Monsters.ID.AXE_BEAK:
                    return "An axe beak is a tall flightless bird with strong legs and a heavy, wedge-shaped beak. It has a nasty disposition and tends to attack any unfamiliar creature that wanders too close.";
                case Monsters.ID.BANDIT:
                    return "**Bandits** rove in gangs and are sometimes led by thugs, veterans, or spellcasters. Not all bandits are evil. Oppression, drought, disease, or famine can often drive otherwise honest folk to a life of banditry.\n\n**Pirates** are bandits of the high seas. They might be freebooters interested only in treasure and murder, or they might be privateers sanctioned by the crown to attack and plunder an enemy nation’s vessels.";
                case Monsters.ID.BANDIT_CAPTAIN:
                    return "It takes a strong personality, ruthless cunning, and a silver tongue to keep a gang of bandits in line. The **bandit captain** has these qualities in spades.\n\nIn addition to managing a crew of selfish malcontents, the **pirate captain** is a variation of the bandit captain, with a ship to protect and command. To keep the crew in line, the captain must mete out rewards and punishment on a regular basis.\n\nMore than treasure, a bandit captain or pirate captain craves infamy. A prisoner who appeals to the captain’s vanity or ego is more likely to be treated fairly than a prisoner who does not or claims not to know anything of the captain’s colorful reputation.";
                case Monsters.ID.BLINK_DOG:
                    return "A blink dog takes its name from its ability to blink in and out of existence, a talent it uses to aid its attacks and to avoid harm.";
                case Monsters.ID.BLOOD_HAWK:
                    return "Taking its name from its crimson feathers and aggressive nature, the blood hawk fearlessly attacks almost any animal, stabbing it with its daggerlike beak. Blood hawks flock together in large numbers, attacking as a pack to take down prey.";
                case Monsters.ID.COMMONER:
                    return "Commoners include peasants, serfs, slaves, servants, pilgrims, merchants, artisans, and hermits.";
                case Monsters.ID.CULT_FANATIC:
                    return "Fanatics are often part of a cult's leadership, using their charisma and dogma to influence and prey on those of weak will. Most are interested in personal power above all else.";
                case Monsters.ID.CULTIST:
                    return "Cultists swear allegiance to dark powers such as elemental princes, demon lords, or archdevils. Most conceal their loyalties to avoid being ostracized, imprisoned, or executed for their beliefs. Unlike evil acolytes, cultists often show signs of insanity in their beliefs and practices.";
                case Monsters.ID.DEATH_DOG:
                    return "A death dog is an ugly two-headed hound that roams plains, and deserts. Hate burns in a death dog's heart, and a taste for humanoid flesh drives it to attack travelers and explorers. Death dog saliva carries a foul disease that causes a victim’s flesh to slowly rot off the bone.";
                case Monsters.ID.DRUID:
                    return "**Druids** dwell in forests and other secluded wilderness locations, where they protect the natural world from monsters and the encroachment of civilization. Some are **tribal shamans** who heal the sick, pray to animal spirits, and provide spiritual guidance.";
                case Monsters.ID.FLYING_SNAKE:
                    return "A flying snake is a brightly colored, winged serpent found in remote jungles. Tribespeople and cultists sometimes domesticate flying snakes to serve as messengers that deliver scrolls wrapped in their coils.";
                case Monsters.ID.FROG:
                    return "A frog has no effective attacks. It feeds on small insects and typically dwells near water, in trees, or underground. The frog's statistics can also be used to represent a toad.";
                case Monsters.ID.GIANT_EAGLE:
                    return "A giant eagle is a noble creature that speaks its own language and understands speech in the Common tongue. A mated pair of giant eagles typically has up to four eggs or young in their nest (treat the young as normal eagles).";
                case Monsters.ID.GIANT_ELK:
                    return "The majestic giant elk is rare to the point that its appearance is often taken as a foreshadowing of an important event, such as the birth of a king. Legends tell of gods that take the form of giant elk when visiting the Material Plane. Many cultures therefore believe that to hunt these creatures is to invite divine wrath.";
                case Monsters.ID.GIANT_FIRE_BEETLE:
                    return "A giant fire beetle is a nocturnal creature that takes its name from a pair of glowing glands that give off light. Miners and adventurers prize these creatures, for a giant fire beetle's glands continue to shed light for 1d6 days after the beetle dies. Giant fire beetles are most commonly found underground and in dark forests.";
                case Monsters.ID.GIANT_LIZARD:
                    return "A giant lizard can be ridden or used as a draft animal. Lizardfolk also keep them as pets, and subterranean giant lizards are used as mounts and pack animals by drow, duergar, and others.";
                case Monsters.ID.GIANT_SEA_HORSE:
                    return "Like their smaller kin, giant sea horses are shy, colorful fish with elongated bodies and curled tails. Aquatic elves train them as mounts.";
                case Monsters.ID.GIANT_SHARK:
                    return "A giant shark is 30 feet long and normally found in deep oceans. Utterly fearless, it preys on anything that crosses its path, including whales and ships.";
                case Monsters.ID.GIANT_SPIDER:
                    return "To snare its prey, a giant spider spins elaborate webs or shoots sticky strands of webbing from its abdomen. Giant spiders are most commonly found underground, making their lairs on ceilings or in dark, web-filled crevices. Such lairs are often festooned with web cocoons holding past victims.";
                case Monsters.ID.GIANT_VULTURE:
                    return "A giant vulture has advanced intelligence and a malevolent bent. Unlike its smaller kin, it will attack a wounded creature to hasten its end. Giant vultures have been known to haunt a thirsty, starving creature for days to enjoy its suffering.";
                case Monsters.ID.GIANT_WOLF_SPIDER:
                    return "Smaller than a giant spider, a giant wolf spider hunts prey across open ground or hides in a burrow or crevice, or in a hidden cavity beneath debris.";
                case Monsters.ID.GLADIATOR:
                    return "Gladiators battle for the entertainment of raucous crowds. Some gladiators are brutal pit fighters who treat each match as a life-or-death struggle, while others are professional duelists who command huge fees but rarely fight to the death.";
                case Monsters.ID.GUARD:
                    return "Guards include members of a city watch, sentries in a citadel or fortified town, and the bodyguards of merchants and nobles.";
                case Monsters.ID.HUNTER_SHARK:
                    return "Smaller than a giant shark but larger and fiercer than a reef shark, a hunter shark haunts deep waters. It usually hunts alone, but multiple hunter sharks might feed in the same area. A fully grown hunter shark is 15 to 20 feet long.";
                case Monsters.ID.KNIGHT:
                    return "Knights are warriors who pledge service to rulers, religious orders, and noble causes. A knight's alignment determines the extent to which a pledge is honored. Whether undertaking a quest or patrolling a realm, a knight often travels with an entourage that includes squires and hirelings who are commoners.";
                case Monsters.ID.MAGE:
                    return "Mages spend their lives in the study and practice of magic. Good-aligned mages offer counsel to nobles and others in power, while evil mages dwell in isolated sites to perform unspeakable experiments without interference.";
                case Monsters.ID.MAMMOTH:
                    return "A mammoth is an elephantine creature with thick fur and long tusks. Stockier and fiercer than normal elephants, mammoths inhabit a wide range of climes, from subarctic to subtropical.";
                case Monsters.ID.MASTIFF:
                    return "Mastiffs are impressive hounds prized by humanoids for their loyalty and keen senses. Mastiffs can be trained as guard dogs, hunting dogs, and war dogs. Halflings and other Small humanoids ride them as mounts.";
                case Monsters.ID.NOBLE:
                    return "**Nobles** wield great authority and influence as members of the upper class, possessing wealth and connections that can make them as powerful as monarchs and generals. A noble often travels in the company of guards, as well as servants who are commoners.\n\nThe noble’s statistics can also be used to represent **courtiers** who aren’t of noble birth.";
                case Monsters.ID.PHASE_SPIDER:
                    return "A phase spider possesses the magical ability to phase in and out of the Ethereal Plane. It seems to appear out of nowhere and quickly vanishes after attacking. Its movement on the Ethereal Plane before coming back to the Material Plane makes it seem like it can teleport.";
                case Monsters.ID.PRIEST:
                    return "Priests bring the teachings of their gods to the common folk. They are the spiritual leaders of temples and shrines and often hold positions of influence in their communities. Evil priests might work openly under a tyrant, or they might be the leaders of religious sects hidden in the shadows of good society, overseeing depraved rites.\n\nA priest typically has one or more acolytes to help with religious ceremonies and other sacred duties.";
                case Monsters.ID.QUIPPER:
                    return "A quipper is a carnivorous fish with sharp teeth. Quippers can adapt to any aquatic environment, including cold subterranean lakes. They frequently gather in swarms; the statistics for a swarm of quippers appear later in this appendix.";
                case Monsters.ID.REEF_SHARK:
                    return "Smaller than giant sharks and hunter sharks, reef sharks inhabit shallow waters and coral reefs, gathering in small packs to hunt. A full-grown specimen measures 6 to 10 feet long.";
                case Monsters.ID.SCOUT:
                    return "Scouts are skilled hunters and trackers who offer their services for a fee. Most hunt wild game, but a few work as bounty hunters, serve as guides, or provide military reconnaissance.";
                case Monsters.ID.SPY:
                    return "Rulers, nobles, merchants, guildmasters, and other wealthy individuals use spies to gain the upper hand in a world of cutthroat politics. A spy is trained to secretly gather information. Loyal spies would rather die than divulge information that could compromise them or their employers.";
                case Monsters.ID.THUG:
                    return "Thugs are ruthless enforcers skilled at intimidation and violence. They work for money and have few scruples.";
                case Monsters.ID.TRIBAL_WARRIOR:
                    return "Tribal warriors live beyond civilization, most often subsisting on fishing and hunting. Each tribe acts in accordance with the wishes of its chief, who is the greatest or oldest warrior of the tribe or a tribe member blessed by the gods.";
                case Monsters.ID.VETERAN:
                    return "Veterans are professional fighters that take up arms for pay or to protect something they believe in or value. Their ranks include soldiers retired from long service and warriors who never served anyone but themselves.";
                case Monsters.ID.WINTER_WOLF:
                    return "The arctic-dwelling winter wolf is as large as a dire wolf but has snow-white fur and pale blue eyes. Frost giants use these evil creatures as guards and hunting companions, putting the wolves’ deadly breath weapon to use against their foes. Winter wolves communicate with one another using growls and barks, but they speak Common and Giant well enough to follow simple conversations.";
                case Monsters.ID.WORG:
                    return "A worg is an evil predator that delights in hunting and devouring creatures weaker than itself. Cunning and malevolent, worgs roam across the remote wilderness or are raised by goblins and hobgoblins. Those creatures use worgs as mounts, but a worg will turn on its rider if it feels mistreated or malnourished. Worgs speak in their own language and Goblin, and a few learn to speak Common as well.";
                default:
                    return ""; // only a few monsters have a description in the SRD
            }
        }
        public static string Name(this Monsters.Type type) {
            switch (type) {
                case Monsters.Type.ABERRATION:
                    return "Aberration";
                case Monsters.Type.BEAST:
                    return "Beast";
                case Monsters.Type.CELESTIAL:
                    return "Celestial";
                case Monsters.Type.CONSTRUCT:
                    return "Construct";
                case Monsters.Type.DRAGON:
                    return "Dragon";
                case Monsters.Type.ELEMENTAL:
                    return "Elemental";
                case Monsters.Type.FEY:
                    return "Fey";
                case Monsters.Type.FIEND:
                    return "Fiend";
                case Monsters.Type.GIANT:
                    return "Giant";
                case Monsters.Type.HUMANOID:
                    return "Humanoid";
                case Monsters.Type.MONSTROSITY:
                    return "Monstrosity";
                case Monsters.Type.OOZE:
                    return "Ooze";
                case Monsters.Type.PLANT:
                    return "Plant";
                case Monsters.Type.UNDEAD:
                    return "Undead";
                default:
                    return Enum.GetName(typeof(Monsters.Type), type) + ": (Name missing)";
            }
        }

        public static string Description(this Monsters.Type type) {
            switch (type) {
                case Monsters.Type.ABERRATION:
                    return "Aberrations are utterly alien beings. Many of them have innate magical abilities drawn from the creature's alien mind rather than the mystical forces of the world.";
                case Monsters.Type.BEAST:
                    return "Beasts are nonhumanoid creatures that are a natural part of the fantasy ecology. Some of them have magical powers, but most are unintelligent and lack any society or language. Beasts include all varieties of ordinary animals, dinosaurs, and giant versions of animals.";
                case Monsters.Type.CELESTIAL:
                    return "Celestials are creatures native to the Upper Planes. Many of them are the servants of deities, employed as messengers or agents in the mortal realm and throughout the planes. Celestials are good by nature, so the exceptional celestial who strays from a good alignment is a horrifying rarity. Celestials include angels, couatls, and pegasi.";
                case Monsters.Type.CONSTRUCT:
                    return "Constructs are made, not born. Some are programmed by their creators to follow a simple set of instructions, while others are imbued with sentience and capable of independent thought. Golems are the iconic constructs. Many creatures native to the outer plane of Mechanus, such as modrons, are constructs shaped from the raw material of the plane by the will of more powerful creatures.";
                case Monsters.Type.DRAGON:
                    return "Dragons are large reptilian creatures of ancient origin and tremendous power. True dragons, including the good metallic dragons and the evil chromatic dragons, are highly intelligent and have innate magic. Also in this category are creatures distantly related to true dragons, but less powerful, less intelligent, and less magical, such as wyverns and pseudodragons.";
                case Monsters.Type.ELEMENTAL:
                    return "Elementals are creatures native to the elemental planes. Some creatures of this type are little more than animate masses of their respective elements, including the creatures simply called elementals. Others have biological forms infused with elemental energy. The races of genies, including djinn and efreet, form the most important civilizations on the elemental planes.Other elemental creatures include azers, invisible stalkers, and water weirds.";
                case Monsters.Type.FEY:
                    return "Fey are magical creatures closely tied to the forces of nature.They dwell in twilight groves and misty forests.In some worlds, they are closely tied to the Plane of Faerie.Some are also found in the Outer Planes, particularly the planes of Arborea and the Beastlands. Fey include dryads, pixies, and satyrs.";
                case Monsters.Type.FIEND:
                    return "Fiends are creatures of wickedness that are native to the Lower Planes. A few are the servants of deities, but many more labor under the leadership of archdevils and demon princes. Evil priests and mages sometimes summon fiends to the material world to do their bidding. If an evil celestial is a rarity, a good fiend is almost inconceivable. Fiends include demons, devils, hell hounds, rakshasas, and yugoloths.";
                case Monsters.Type.GIANT:
                    return "Giants tower over humans and their kind.They are humanlike in shape, though some have multiple heads(ettins) or deformities(fomorians). The six varieties of true giant are hill giants, stone giants, frost giants, fire giants, cloud giants, and storm giants. Besides these, creatures such as ogres and trolls are giants.";
                case Monsters.Type.HUMANOID:
                    return "Humanoids are the main peoples of a fantasy gaming world, both civilized and savage, including humans and a tremendous variety of other species.They have language and culture, few if any innate magical abilities(though most humanoids can learn spellcasting), and a bipedal form. The most common humanoid races are the ones most suitable as player characters: humans, dwarves, elves, and halflings.";
                case Monsters.Type.MONSTROSITY:
                    return "Monstrosities are monsters in the strictest sense—frightening creatures that are not ordinary, not truly natural, and almost never benign.Some are the results of magical experimentation gone awry(such as owlbears), and others are the product of terrible curses(including minotaurs and yuan-ti). They defy categorization, and in some sense serve as a catch-all category for creatures that don't fit into any other type.";
                case Monsters.Type.OOZE:
                    return "Oozes are gelatinous creatures that rarely have a fixed shape.They are mostly subterranean, dwelling in caves and dungeons and feeding on refuse, carrion, or creatures unlucky enough to get in their way. Black puddings and gelatinous cubes are among the most recognizable oozes.";
                case Monsters.Type.PLANT:
                    return "Plants in this context are vegetable creatures, not ordinary flora. Most of them are ambulatory, and some are carnivorous. The quintessential plants are the shambling mound and the treant. Fungal creatures such as the gas spore and the myconid also fall into this category.";
                case Monsters.Type.UNDEAD:
                    return "Undead are once - living creatures brought to a horrifying state of undeath through the practice of necromantic magic or some unholy curse. Undead include walking corpses, such as vampires and zombies, as well as bodiless spirits, such as ghosts and specters.";
                default:
                    return Enum.GetName(typeof(Monsters.Type), type) + ": (Description missing)";
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
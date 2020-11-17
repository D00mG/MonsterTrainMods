using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Trainworks.Builders;
using Trainworks.Constants;
using Trainworks.Utilities;
using static Trainworks.Constants.VanillaCardPoolIDs;

namespace GraveshackledClan_Main
{
    class UnitGraveshackledMenhirOfMemories
    {
        public static void Make()
        {
            CardDataBuilder cardmenhirofmemories = new CardDataBuilder
            {
                Cost = 1,
                Rarity = CollectableRarity.Rare,
                CardType = CardType.Monster,
                ClanID = "GraveshackledClanDefine_ID",
                CardPoolIDs = new List<string>
                    {
                        VanillaCardPoolIDs.MegaPool,
//                        VanillaCardPoolIDs.MegaPool,
// Replace this second MegaPool with the Clan Pool once it is made
                    },
                CardID = "CardGraveshackledMenhirOfMemories_ID",
                Name = "Menhir of Memories",
                AssetPath = "assets/CardArt/img_unit_menhir_of_memories.png",
                TargetsRoom = true,

                EffectBuilders = new List<CardEffectDataBuilder>
                    {
                        new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectSpawnMonster),
                                TargetMode = TargetMode.DropTargetCharacter,
                                ParamCharacterDataBuilder = new CharacterDataBuilder
                                    {
                                        CharacterID = "UnitGraveshackledMenhirOfMemories_ID",
                                        Name = "Menhir of Memories",
                                        SubtypeKeys = new List<string> { SubtypeGraveshackledMenhir.Key },
                                        Size = 1,
                                        Health = 5,
                                        AttackDamage = 0,
                                        AssetPath = "assets/UnitArt/img_character_MenhirOfMemories.png",
                                        StartingStatusEffects = new StatusEffectStackData[]
                                            {
                                                new StatusEffectStackData
                                                    {
                                                        count = 1, statusId = "endless"
                                                    }
                                            },
                                        TriggerBuilders = new List<CharacterTriggerDataBuilder>
                                            {
                                                new CharacterTriggerDataBuilder
                                                    {
                                                        Trigger = CharacterTriggerData.Trigger.OnSpawn,
                                                        Description = "Apply <nobr><b>Stealth</b> <b>{[effect0.status0.power]}</b></nobr> to allies.",
                                                        EffectBuilders = new List<CardEffectDataBuilder>
                                                            {
                                                                new CardEffectDataBuilder
                                                                    {
                                                                        EffectStateType = VanillaCardEffectTypes.CardEffectAddStatusEffect,
                                                                        TargetMode = TargetMode.Room,
                                                                        TargetTeamType = Team.Type.Monsters,
                                                                        // Figure out how to filter self as target or, if that fails, filter out mehir subtypes
                                                                        // TargetModeStatusEffectsFilter = new string[] { VanillaStatusEffectIDs.Inert },
                                                                        ParamStatusEffects = new StatusEffectStackData[]
                                                                            {
                                                                                new StatusEffectStackData
                                                                                    {
                                                                                        count = 1,
                                                                                        statusId = VanillaStatusEffectIDs.Stealth
                                                                                    }
                                                                            }
                                                                    }
                                                            }
                                                    }
                                            }
                                    }
                            }
                    }
            };
            cardmenhirofmemories.BuildAndRegister();
        }
    }
}

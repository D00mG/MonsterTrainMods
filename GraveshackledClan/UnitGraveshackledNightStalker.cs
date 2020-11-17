using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Trainworks.Builders;
using Trainworks.Constants;
using Trainworks.Managers;
using Trainworks.Utilities;
using static Trainworks.Constants.VanillaCardPoolIDs;

namespace GraveshackledClan_Main
{
    class UnitGraveshackledNightStalker
    {
        public static void Make()
        {
            CardData spawnCardData = ProviderManager.SaveManager.GetAllGameData().FindCardData("CardGraveshackledWretchedSpawn_ID");
            CharacterData spawnUnitData = spawnCardData.GetSpawnCharacterData();
            CardDataBuilder cardnightstalker = new CardDataBuilder
            {
                Cost = 1,
                Rarity = CollectableRarity.Common,
                CardType = CardType.Monster,
                ClanID = "GraveshackledClanDefine_ID",
                CardPoolIDs = new List<string>
                    {
                        VanillaCardPoolIDs.MegaPool,
//                        VanillaCardPoolIDs.MegaPool,
// Replace this second MegaPool with the Clan Pool once it is made
                    },
                CardID = "CardGraveshackledNightStalker_ID",
                Name = "Night Stalker",
                AssetPath = "assets/CardArt/img_unit_night_stalker.png",
                TargetsRoom = true,

                EffectBuilders = new List<CardEffectDataBuilder>
                    {
                        new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectSpawnMonster),
                                TargetMode = TargetMode.DropTargetCharacter,
                                ParamCharacterDataBuilder = new CharacterDataBuilder
                                    {
                                        CharacterID = "UnitGraveshackledNightStalker_ID",
                                        Name = "Night Stalker",
                                        SubtypeKeys = new List<string> { SubtypeGraveshackledRevenant.Key },
                                        Size = 2,
                                        Health = 20,
                                        AttackDamage = 5,
                                        AssetPath = "assets/UnitArt/img_character_NightStalker.png",
                                        TriggerBuilders = new List<CharacterTriggerDataBuilder>
                                            {
                                                new CharacterTriggerDataBuilder
                                                    {
                                                        Trigger = CharacterTriggerData.Trigger.OnAttacking,
                                                        Description = "Gain <nobr>+{[effect0.power]} [attack].</nobr>",
                                                        EffectBuilders = new List<CardEffectDataBuilder>
                                                            {
                                                                new CardEffectDataBuilder
                                                                {
                                                                    EffectStateType = VanillaCardEffectTypes.CardEffectBuffDamage,
                                                                    TargetMode = TargetMode.Self,
                                                                    ParamInt = 2,
                                                                    TargetTeamType = Team.Type.Monsters
                                                                }
                                                            }
                                                    },
                                                new CharacterTriggerDataBuilder
                                                    {
                                                        Trigger = CharacterTriggerData.Trigger.OnKill,
                                                        EffectBuilders = new List<CardEffectDataBuilder>
                                                            {
                                                                new CardEffectDataBuilder
                                                                    {
                                                                        EffectStateType = VanillaCardEffectTypes.CardEffectSpawnMonster,
                                                                        TargetMode = TargetMode.Room,
                                                                        TargetTeamType = Team.Type.None,
                                                                        ParamInt = 1,
                                                                        ParamCharacterData = spawnUnitData
                                                                    }
                                                                // Wanted this to trigger off a collected Soul threshold. Will try again another time with a custom trigger.
                                                                //,
                                                                //new CardEffectDataBuilder
                                                                //{
                                                                //    EffectStateType = VanillaCardEffectTypes.CardEffectRemoveStatusEffectOnStatusThreshold,
                                                                //    TargetMode = TargetMode.Self,
                                                                //    TargetTeamType = Team.Type.Monsters,
                                                                //    ParamStatusEffects = new StatusEffectStackData[]
                                                                //            {
                                                                //                new StatusEffectStackData
                                                                //                    {
                                                                //                        count = 4,
                                                                //                        statusId = VanillaStatusEffectIDs.Soul
                                                                //                    },
                                                                //            }
                                                                //}
                                                            }
                                                    }
                                            }
                                    }
                            }
                    }
            };
            cardnightstalker.BuildAndRegister();
        }
    }
}
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
        CardData spawnCardData = ProviderManager.SaveManager.GetAllGameData().FindCardData("CardGraveshackledWretchedSpawn_ID");
        CharacterData spawnUnitData = spawnCardData.GetSpawnCharacterData();
        public static void Make()
        {
            CardDataBuilder card = new CardDataBuilder
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
                                        Size = 1,
                                        Health = 20,
                                        AttackDamage = 5,
                                        AssetPath = "assets/UnitArt/img_character_NightStalker.png",
                                        TriggerBuilders = new List<CharacterTriggerDataBuilder>
                                            {
                                                new CharacterTriggerDataBuilder
                                                    {
                                                        Trigger = CharacterTriggerData.Trigger.OnAttacking,
                                                        Description = "Gain <nobr><b>Soul {[effect0.status0.power]}.</b></nobr>",
                                                        EffectBuilders = new List<CardEffectDataBuilder>
                                                            {
                                                                new CardEffectDataBuilder
                                                                    {
                                                                        EffectStateType = VanillaCardEffectTypes.CardEffectAddStatusEffect,
                                                                        TargetMode = TargetMode.Self,
                                                                        TargetTeamType = Team.Type.Monsters,
                                                                        ParamStatusEffects = new StatusEffectStackData[]
                                                                            {
                                                                                new StatusEffectStackData
                                                                                    {
                                                                                        count = 1,
                                                                                        statusId = VanillaStatusEffectIDs.Soul
                                                                                    }
                                                                            }
                                                                    }
                                                            }
                                                    },
                                                new CharacterTriggerDataBuilder
                                                    {
                                                        Trigger = CharacterTriggerData.Trigger.EndTurnPreHandDiscard,
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
                                                                //,
                                                                //new CardEffectDataBuilder
                                                                //    {
                                                                //        EffectStateType = VanillaCardEffectTypes.CardEffectRemoveStatusEffectOnStatusThreshold,
                                                                //        TargetMode = TargetMode.Self,
                                                                //        TargetTeamType = Team.Type.Monsters,
                                                                //        ParamStatusEffects = new StatusEffectStackData[]
                                                                //            {
                                                                //                new StatusEffectStackData
                                                                //                    {
                                                                //                        count = 4,
                                                                //                        statusId = VanillaStatusEffectIDs.Soul
                                                                //                    },
                                                                //            }
                                                                //    }
                                                            }
                                                    }
                                            }
                                    }
                            }
                    }
            };
            card.BuildAndRegister();
        }
    }
}
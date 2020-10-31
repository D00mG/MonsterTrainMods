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
    class UnitGraveshackledCharnelSlab
    {
        public static void Make()
        {
            CardDataBuilder cardcharnelslab = new CardDataBuilder
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
                CardID = "CardGraveshackledCharnelSlab_ID",
                Name = "Charnel Slab",
                AssetPath = "assets/CardArt/img_unit_charnel_slab.png",
                TargetsRoom = true,

                EffectBuilders = new List<CardEffectDataBuilder>
                    {
                        new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectSpawnMonster),
                                TargetMode = TargetMode.DropTargetCharacter,
                                ParamCharacterDataBuilder = new CharacterDataBuilder
                                    {
                                        CharacterID = "UnitGraveshackledCharnelSlab",
                                        Name = "Charnel Slab",
                                        SubtypeKeys = new List<string> { SubtypeGraveshackledRevenant.Key },
                                        Size = 1,
                                        Health = 20,
                                        AttackDamage = 5,
                                        AssetPath = "assets/UnitArt/img_character_CharnelSlab.png",
                                        StartingStatusEffects = new StatusEffectStackData[]
                                            {
                                                new StatusEffectStackData
                                                    {
                                                        count = 1, statusId = "inert"
                                                    },
                                                new StatusEffectStackData
                                                    {
                                                        count = 1, statusId = "endless"
                                                    }
                                            },
                                        TriggerBuilders = new List<CharacterTriggerDataBuilder>
                                            {
                                                new CharacterTriggerDataBuilder
                                                    {
                                                        Trigger = CharacterTriggerData.Trigger.OnAnyUnitDeathOnFloor,
                                                        Description = "Gain <nobr><b>Soul</b> <b>{[effect0.status0.power]}</b></nobr>",
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
                                                        Trigger = CharacterTriggerData.Trigger.OnFeed,
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
                                                                                        statusId = VanillaStatusEffectIDs.Fuel
                                                                                    },
                                                                            }
                                                                    }
                                                            }
                                                    }
                                            }
                                    }
                            }
                    }
            };
                cardcharnelslab.BuildAndRegister();
        }
    }
}
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
        class UnitGraveshackledSeaOfMaggots
        {
            public static void Make()
            {
                CardDataBuilder cardseaofmaggots = new CardDataBuilder
                {
                    Cost = 2,
                    Rarity = CollectableRarity.Common,
                    CardType = CardType.Monster,
                    ClanID = "GraveshackledClanDefine_ID",
                    CardPoolIDs = new List<string>
                    {
                        VanillaCardPoolIDs.MegaPool,
//                        VanillaCardPoolIDs.MegaPool,
// Replace this second MegaPool with the Clan Pool once it is made
                    },
                    CardID = "CardGraveshackledSeaOfMaggots_ID",
                    Name = "Sea of Maggots",
                    AssetPath = "assets/CardArt/img_unit_sea_of_maggots.png",
                    TargetsRoom = true,

                    EffectBuilders = new List<CardEffectDataBuilder>
                    {
                        new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectSpawnMonster),
                                TargetMode = TargetMode.DropTargetCharacter,
                                ParamCharacterDataBuilder = new CharacterDataBuilder
                                    {
                                        CharacterID = "UnitGraveshackledSeaOfMaggots_ID",
                                        Name = "Sea of Maggots",
                                        SubtypeKeys = new List<string> { SubtypeGraveshackledRevenant.Key },
                                        Size = 2,
                                        Health = 45,
                                        AttackDamage = 5,
                                        AssetPath = "assets/UnitArt/img_character_SeaOfMaggots.png",
                                        TriggerBuilders = new List<CharacterTriggerDataBuilder>
                                            {
                                                new CharacterTriggerDataBuilder
                                                    {
                                                        Trigger = CharacterTriggerData.Trigger.OnAnyUnitDeathOnFloor,
                                                        Description = "Gain <nobr><b>Soul</b> <b>{[effect0.status0.power]}</b></nobr>. Gain <nobr><b>Multistrike {[effect0.status1.power]}</b></nobr>.",
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
                                                                    },
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
                                                                                        statusId = VanillaStatusEffectIDs.Multistrike
                                                                                    }
                                                                            }
                                                                    }
                                                            }
                                                    },
                                                new CharacterTriggerDataBuilder
                                                    {
                                                        Trigger = CharacterTriggerData.Trigger.OnFeed,
                                                        Description = "Gain +<nobr>{[effect0.power]}[health].</nobr>",
                                                        EffectBuilders = new List<CardEffectDataBuilder>
                                                            {
                                                                new CardEffectDataBuilder
                                                                    {
                                                                        EffectStateType = VanillaCardEffectTypes.CardEffectBuffMaxHealth,
                                                                        TargetMode = TargetMode.Self,
                                                                        ParamInt = 5,
                                                                        TargetTeamType = Team.Type.Monsters
                                                                    }
                                                            }
                                                    },
                                                new CharacterTriggerDataBuilder
                                                    {
                                                        Trigger = CharacterTriggerData.Trigger.OnAttacking,
                                                        Description = "Gain +<nobr>{[effect0.power]}[attack]</nobr>.",
                                                        EffectBuilders = new List<CardEffectDataBuilder>
                                                            {
                                                                new CardEffectDataBuilder
                                                                    {
                                                                        EffectStateType = VanillaCardEffectTypes.CardEffectBuffDamage,
                                                                        TargetMode = TargetMode.Self,
                                                                        ParamInt = 1,
                                                                        TargetTeamType = Team.Type.Monsters
                                                                    }
                                                            }
                                                    }
                                            }
                                    }
                            }
                    }
                };
                cardseaofmaggots.BuildAndRegister();
            }
        }
    }
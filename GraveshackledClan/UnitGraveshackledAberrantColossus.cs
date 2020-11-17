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
    class UnitGraveshackledAberrantColossus
    {
        public static void Make()
        {
            CardDataBuilder cardaberrantcolossus = new CardDataBuilder
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
                CardID = "CardGraveshackledAberrantColossus_ID",
                Name = "Aberrant Colossus",
                AssetPath = "assets/CardArt/img_unit_aberrant_colossus.png",
                TargetsRoom = true,

                EffectBuilders = new List<CardEffectDataBuilder>
                    {
                        new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectSpawnMonster),
                                TargetMode = TargetMode.DropTargetCharacter,
                                ParamCharacterDataBuilder = new CharacterDataBuilder
                                    {
                                        CharacterID = "UnitGraveshackledAberrantColossus_ID",
                                        Name = "Aberrant Colossus",
                                        SubtypeKeys = new List<string> { SubtypeGraveshackledRevenant.Key },
                                        Size = 2,
                                        Health = 5,
                                        AttackDamage = 1,
                                        AssetPath = "assets/UnitArt/img_character_AberrantColossus.png",
                                        StartingStatusEffects = new StatusEffectStackData[]
                                            {
                                                new StatusEffectStackData
                                                    {
                                                        count = 1, statusId = "inert"
                                                    },
                                                new StatusEffectStackData
                                                    {
                                                        //count = 2, statusId = "fuel"
                                                        count = 1, statusId = "endless"
                                                    }
                                            },
                                        TriggerBuilders = new List<CharacterTriggerDataBuilder>
                                            {
                                                new CharacterTriggerDataBuilder
                                                    {
                                                        Trigger = CharacterTriggerData.Trigger.OnAttacking,
                                                        Description = "Gain +<nobr>{[effect0.power]}[health].</nobr>",
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
                                                                                new StatusEffectStackData
                                                                                    {
                                                                                        count = 1,
                                                                                        statusId = VanillaStatusEffectIDs.Lifesteal
                                                                                    }
                                                                            }
                                                                    },
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
                                                        Trigger = CharacterTriggerData.Trigger.OnSpawn,
                                                        Description = "Gain <nobr><b>Fuel {[effect0.power]}</b>.</nobr>",
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
                                                                                        count = 2,
                                                                                        statusId = VanillaStatusEffectIDs.Fuel
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
            cardaberrantcolossus.BuildAndRegister();
        }
    }
}
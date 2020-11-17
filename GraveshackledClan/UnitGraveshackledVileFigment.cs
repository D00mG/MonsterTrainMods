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
    class UnitGraveshackledVileFigment
    {
        public static void Make()
        {
            CardDataBuilder cardvilefigment = new CardDataBuilder
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
                CardID = "CardGraveshackledVileFigment_ID",
                Name = "Vile Figment",
                AssetPath = "assets/CardArt/img_unit_vile_figment.png",
                TargetsRoom = true,

                EffectBuilders = new List<CardEffectDataBuilder>
                    {
                        new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectSpawnMonster),
                                TargetMode = TargetMode.DropTargetCharacter,
                                ParamCharacterDataBuilder = new CharacterDataBuilder
                                    {
                                        CharacterID = "UnitGraveshackledVileFigment_ID",
                                        Name = "Vile Figment",
                                        SubtypeKeys = new List<string> { SubtypeGraveshackledPhantasm.Key },
                                        Size = 2,
                                        Health = 5,
                                        AttackDamage = 1,
                                        AssetPath = "assets/UnitArt/img_character_VileFigment.png",
                                        StartingStatusEffects = new StatusEffectStackData[]
                                            {
                                                new StatusEffectStackData
                                                    {
                                                        count = 2, statusId = "stealth"
                                                    },
                                                new StatusEffectStackData
                                                    {
                                                        count = 1, statusId = "ambush"
                                                    },
                                                new StatusEffectStackData
                                                    {
                                                        count = 1, statusId = "heal immunity"
                                                    }
                                            },
                                        TriggerBuilders = new List<CharacterTriggerDataBuilder>
                                            {
                                                new CharacterTriggerDataBuilder
                                                    {
                                                        Trigger = CharacterTriggerData.Trigger.OnKill,
                                                        Description = "Gain <nobr><b>Stealth</b> <b>{[effect0.status0.power]}</b>.</nobr>",
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
            cardvilefigment.BuildAndRegister();
        }
    }
}
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
    class UnitGraveshackledMarrowFiend
    {
        public static void Make()
        {
            CardDataBuilder cardmarrowfiend = new CardDataBuilder
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
                CardID = "CardGraveshackledMarrowFiend_ID",
                Name = "Marrow Fiend",
                AssetPath = "assets/CardArt/img_unit_marrow_fiend.png",
                TargetsRoom = true,

                EffectBuilders = new List<CardEffectDataBuilder>
                    {
                        new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectSpawnMonster),
                                TargetMode = TargetMode.DropTargetCharacter,
                                ParamCharacterDataBuilder = new CharacterDataBuilder
                                    {
                                        CharacterID = "UnitGraveshackledMarrowFiend_ID",
                                        Name = "Marrow Fiend",
                                        SubtypeKeys = new List<string> { SubtypeGraveshackledRevenant.Key },
                                        Size = 1,
                                        Health = 20,
                                        AttackDamage = 5,
                                        AssetPath = "assets/UnitArt/img_character_MarrowFiend.png",
                                        TriggerBuilders = new List<CharacterTriggerDataBuilder>
                                            {
                                                new CharacterTriggerDataBuilder
                                                    {
                                                        Trigger = CharacterTriggerData.Trigger.OnAttacking,
                                                        Description = "Gain <nobr><b>Rage {[effect0.status0.power]}.</b></nobr>",
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
                                                                                        count = 3,
                                                                                        statusId = VanillaStatusEffectIDs.Rage
                                                                                    }
                                                                            }
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
                                                                    EffectStateType = VanillaCardEffectTypes.CardEffectBuffMaxHealth,
                                                                    TargetMode = TargetMode.Self,
                                                                    ParamInt = 10,
                                                                    TargetTeamType = Team.Type.Monsters
                                                                }
                                                            }
                                                    }
                                            }
                                    }
                            }
                    }
            };
            cardmarrowfiend.BuildAndRegister();
        }
    }
}
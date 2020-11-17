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
    class UnitGraveshackledWretchedSpawn
    {
        public static void Make()
        {
            CardDataBuilder cardwretchedspawn = new CardDataBuilder
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
                CardID = "CardGraveshackledWretchedSpawn_ID",
                Name = "Wretched Spawn",
                AssetPath = "assets/CardArt/img_unit_wretched_spawn.png",
                TargetsRoom = true,

                EffectBuilders = new List<CardEffectDataBuilder>
                    {
                        new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectSpawnMonster),
                                TargetMode = TargetMode.DropTargetCharacter,
                                ParamCharacterDataBuilder = new CharacterDataBuilder
                                    {
                                        CharacterID = "UnitGraveshackledWretchedSpawn_ID",
                                        Name = "Wretched Spawn",
                                        SubtypeKeys = new List<string> { SubtypeGraveshackledRevenant.Key },
                                        Size = 1,
                                        Health = 10,
                                        AttackDamage = 2,
                                        AssetPath = "assets/UnitArt/img_character_WretchedSpawn.png",
                                        StartingStatusEffects = new StatusEffectStackData[]
                                            {
                                                new StatusEffectStackData
                                                    {
                                                        count = 2, statusId = "stealth"
                                                    }
                                            },
                                        TriggerBuilders = new List<CharacterTriggerDataBuilder>
                                            {
                                                new CharacterTriggerDataBuilder
                                                    {
                                                        Trigger = CharacterTriggerData.Trigger.OnAttacking,
                                                        Description = "Gain <nobr><b>Soul</b> <b>{[effect0.status0.power]}</b></nobr>. Gain +<nobr>{[effect1.power]}[Attack].</nobr>",
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
            cardwretchedspawn.BuildAndRegister();
        }
    }
}
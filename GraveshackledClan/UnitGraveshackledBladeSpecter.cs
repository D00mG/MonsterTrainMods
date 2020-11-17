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
    class UnitGraveshackledBladeSpecter
    {
        public static void Make()
        {
            CardDataBuilder cardbladespecter = new CardDataBuilder
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
                CardID = "CardGraveshackledBladeSpecter_ID",
                Name = "Blade Specter",
                AssetPath = "assets/CardArt/img_unit_blade_specter.png",
                TargetsRoom = true,

                EffectBuilders = new List<CardEffectDataBuilder>
                    {
                        new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectSpawnMonster),
                                TargetMode = TargetMode.DropTargetCharacter,
                                ParamCharacterDataBuilder = new CharacterDataBuilder
                                    {
                                        CharacterID = "UnitGraveshackledBladeSpecter_ID",
                                        Name = "Blade Specter",
                                        SubtypeKeys = new List<string> { SubtypeGraveshackledPhantasm.Key },
                                        Size = 2,
                                        Health = 5,
                                        AttackDamage = 20,
                                        AssetPath = "assets/UnitArt/img_character_BladeSpecter.png",
                                        StartingStatusEffects = new StatusEffectStackData[]
                                            {
                                                new StatusEffectStackData
                                                    {
                                                        count = 2, statusId = "stealth"
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
                                                        Trigger = CharacterTriggerData.Trigger.OnAttacking,
                                                        Description = "Apply <nobr><b>Sap</b> <b>{[effect0.status0.power]}</b></nobr> to target enemy.",
                                                        EffectBuilders = new List<CardEffectDataBuilder>
                                                            {
                                                                new CardEffectDataBuilder
                                                                    {
                                                                        EffectStateType = VanillaCardEffectTypes.CardEffectAddStatusEffect,
                                                                        TargetMode = TargetMode.LastDamagedCharacters,
                                                                        TargetTeamType = Team.Type.Heroes,
                                                                        ParamStatusEffects = new StatusEffectStackData[]
                                                                            {
                                                                                new StatusEffectStackData
                                                                                    {
                                                                                        count = 1,
                                                                                        statusId = VanillaStatusEffectIDs.Sap
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
            cardbladespecter.BuildAndRegister();
        }
    }
}
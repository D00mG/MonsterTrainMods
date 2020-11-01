using BepInEx;
using HarmonyLib;
using Trainworks.Interfaces;
using Trainworks.Managers;
using Trainworks.Builders;
using System.Collections.Generic;
using Trainworks.Constants;

namespace GraveshackledClan_Main
{
    class InevitableWarBasic
    {
        public static string IDName = "InevitableWarUpgradeBasic";

        public static CardUpgradeDataBuilder Builder()
        {
            CardUpgradeDataBuilder railtie = new CardUpgradeDataBuilder
            {
                UpgradeTitleKey = IDName + "_Name",
                UpgradeDescriptionKey = IDName + "_Desc",
                UseUpgradeHighlightTextTags = true,
                BonusDamage = 5,
                BonusHP = 5,

                TriggerUpgradeBuilders = new List<CharacterTriggerDataBuilder>
                {
                    new CharacterTriggerDataBuilder
                    {
                        Trigger = CharacterTriggerData.Trigger.PostCombat,
                        DescriptionKey = IDName + "_Desc",
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = VanillaCardEffectTypes.CardEffectAddStatusEffect,
                                ParamStatusEffects = new StatusEffectStackData[]
                                {
                                    new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.Fuel,
                                        count = 2
                                    }
                                },
                            TriggerUpgradeBuilders = new List<CharacterTriggerDataBuilder>
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
                                    }
                                }
                            }
                        }
                    }
                }
            };

            return railtie;
        }
        public static CardUpgradeData Make() { return Builder().Build(); }
    }
}
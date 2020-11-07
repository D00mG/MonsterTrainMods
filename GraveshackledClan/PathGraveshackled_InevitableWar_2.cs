using BepInEx;
using HarmonyLib;
using Trainworks.Interfaces;
using Trainworks.Managers;
using Trainworks.Builders;
using System.Collections.Generic;
using Trainworks.Constants;

namespace GraveshackledClan_Main
{
    class InevitableWarAdvanced
    {
        public static string IDName = "InevitableWarUpgradeAdvanced";

        public static CardUpgradeDataBuilder Builder()
        {
            CardUpgradeDataBuilder railtie = new CardUpgradeDataBuilder
            {
                UpgradeTitle = "Herald of War II",
                UpgradeDescriptionKey = IDName + "_Desc",
                UseUpgradeHighlightTextTags = true,
                BonusDamage = 10,
                BonusHP = 10,

                TriggerUpgradeBuilders = new List<CharacterTriggerDataBuilder>
                {
                    new CharacterTriggerDataBuilder
                    {
                        Trigger = CharacterTriggerData.Trigger.OnAnyUnitDeathOnFloor,
                        Description = "Gain <nobr><b>Soul</b> <b>{[effect0.status0.power]}</b></nobr>. Gain +<nobr>{[effect1.power]}<sprite name=\"Attack\"></nobr>.",
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
                                            ParamInt = 4,
                                            TargetTeamType = Team.Type.Monsters
                                        }
                                    }
                    },
                    new CharacterTriggerDataBuilder
                    {
                        Trigger = CharacterTriggerData.Trigger.OnDeath,
                        Description = "Deal damage to the enemy units equal to <nobr>[effect0.power]x</nobr> the Soul count.",
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                            new CardEffectDataBuilder
                            {
                                    EffectStateType = VanillaCardEffectTypes.CardEffectDamage,
                                    TargetMode = TargetMode.Room,
                                    TargetTeamType = Team.Type.Heroes,
                                    UseStatusEffectStackMultiplier = true,
                                    StatusEffectStackMultiplier = VanillaStatusEffectIDs.Soul,
                                    ParamInt = 20,
                            },
                        }
                    },
                },
            };

            return railtie;
        }
        public static CardUpgradeData Make() { return Builder().Build(); }
    }
}
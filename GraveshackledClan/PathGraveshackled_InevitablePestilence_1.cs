﻿using BepInEx;
using HarmonyLib;
using Trainworks.Interfaces;
using Trainworks.Managers;
using Trainworks.Builders;
using System.Collections.Generic;
using Trainworks.Constants;

namespace GraveshackledClan_Main
{
    class InevitablePestilenceBasic
    {
        public static string IDName = "InevitablePestilenceUpgradeBasic";

        public static CardUpgradeDataBuilder Builder()
        {
            CardUpgradeDataBuilder railtie = new CardUpgradeDataBuilder
            {
                UpgradeTitleKey = IDName + "_Title",
                UpgradeDescription = IDName + "_Desc",
                UseUpgradeHighlightTextTags = true,
                BonusDamage = 0,
                BonusHP = 10,

                TriggerUpgradeBuilders = new List<CharacterTriggerDataBuilder>
                {
                    new CharacterTriggerDataBuilder
                    {
                        Trigger = CharacterTriggerData.Trigger.OnAnyUnitDeathOnFloor,
                        //Description = "Gain <nobr><b>Soul</b> <b>{[effect0.status0.power]}</b></nobr>.",
                        DescriptionKey = IDName + "_Desc",
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
                                    }
                    },
                    new CharacterTriggerDataBuilder
                    {
                        Trigger = CharacterTriggerData.Trigger.OnHit,
                        //Description = "Apply <nobr><b>Frostbite {[effect0.status0.power]}</b></nobr> per Soul to enemy units.",
                        //DescriptionKey = IDName + "_Desc1",
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = VanillaCardEffectTypes.CardEffectAddStatusEffect,
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Heroes,
                                UseStatusEffectStackMultiplier = true,
                                StatusEffectStackMultiplier = VanillaStatusEffectIDs.Soul,
                                ParamStatusEffects = new StatusEffectStackData[]
                                {
                                    new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.Frostbite,
                                        count = 2
                                    }
                            }
                    }

                        }
                    },
                },
            };

            return railtie;
        }
        public static CardUpgradeData Make() { return Builder().Build(); }
    }
}
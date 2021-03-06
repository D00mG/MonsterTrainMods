﻿using BepInEx;
using HarmonyLib;
using Trainworks.Interfaces;
using Trainworks.Managers;
using Trainworks.Builders;
using System.Collections.Generic;
using Trainworks.Constants;

namespace GraveshackledClan_Main
{
    class InevitableFamineBasic
    {
        public static string IDName = "InevitableFamineUpgradeBasic";

        public static CardUpgradeDataBuilder Builder()
        {
            CardUpgradeDataBuilder railtie = new CardUpgradeDataBuilder
            {
                UpgradeTitleKey = IDName + "_Title",
                UpgradeDescription = IDName + "_Desc",
                UseUpgradeHighlightTextTags = true,
                BonusDamage = 10,
                BonusHP = 15,

                TriggerUpgradeBuilders = new List<CharacterTriggerDataBuilder>
                {
                    new CharacterTriggerDataBuilder
                    {
                        Trigger = CharacterTriggerData.Trigger.OnHit,
                        DescriptionKey = IDName + "_Desc",
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = VanillaCardEffectTypes.CardEffectAddStatusEffect,
                                TargetMode = TargetMode.Room,
                                TargetTeamType = Team.Type.Heroes,
                                ParamStatusEffects = new StatusEffectStackData[]
                                {
                                    new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.Sap,
                                        count = 1
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
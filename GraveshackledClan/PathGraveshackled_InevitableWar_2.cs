﻿using BepInEx;
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
                UpgradeTitleKey = IDName + "_Name",
                UpgradeDescriptionKey = IDName + "_Desc",
                UseUpgradeHighlightTextTags = true,
                BonusDamage = 10,
                BonusHP = 10,

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
                                        statusId = VanillaStatusEffectIDs.Lifesteal,
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
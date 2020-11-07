using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.Builders;
using Trainworks.Constants;
using Trainworks.Utilities;
using static Trainworks.Constants.VanillaCardPoolIDs;

namespace GraveshackledClan_Main
{
    class SpellGraveshackledBloodHarvest
    {
        public static void Make()
        {
            CardDataBuilder card = new CardDataBuilder
            {
                Cost = 1,
                CardID = "SpellGraveshackledBloodHarvest_ID",
                Name = "Blood Harvest",
                Description = "Restore [effect0.power] health and apply <nobr><b>Fuel</b> <b>{[effect2.status0.power]}</b></nobr> to friendly units. Deal [effect1.power] damage to enemy units.",
                AssetPath = "assets/CardArt/img_spell_blood_harvest.png",
                Rarity = CollectableRarity.Common,
                ClanID = "GraveshackledClanDefine_ID",

                CardPoolIDs = new List<string> { MegaPool },
                TargetsRoom = true,
                Targetless = true,

                EffectBuilders = new List<CardEffectDataBuilder>
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectHeal),
                        TargetMode = TargetMode.Room,
                        TargetTeamType = Team.Type.Monsters,
                        ParamInt = 3,
                    },
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectDamage),
                        TargetMode = TargetMode.Room,
                        TargetTeamType = Team.Type.Heroes,
                        ParamInt = 3,
                    },
                    new CardEffectDataBuilder
                    {
                        EffectStateType = VanillaCardEffectTypes.CardEffectAddStatusEffect,
                        TargetMode = TargetMode.Room,
                        TargetTeamType = Team.Type.Monsters | Team.Type.Heroes,
                        TargetModeStatusEffectsFilter = new string[] { VanillaStatusEffectIDs.Inert },
                        ParamStatusEffects = new StatusEffectStackData[]
                            {
                                new StatusEffectStackData
                                    {
                                        statusId = VanillaStatusEffectIDs.Fuel,
                                        count = 2
                                    }
                            }
                    }
                },

                TraitBuilders = new List<CardTraitDataBuilder>
                {
                    new CardTraitDataBuilder
                    {
                        TraitStateType = typeof(CardTraitIgnoreArmor)
                    }
                }
            };

            card.BuildAndRegister();
        }
    }
}
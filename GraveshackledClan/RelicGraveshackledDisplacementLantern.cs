using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.Builders;
using Trainworks.Constants;

namespace GraveshackledClan_Main
{
    class RelicGraveshackledDisplacementLantern
    {
        public static void Make()
        {
            new CollectableRelicDataBuilder
            {
                CollectableRelicID = "RelicGraveshackledDisplacementLantern_ID",
                Name = "Displacement Lantern",
                Description = "Add +1 stack of Stealth whenever it is applied (Temporarily adds on monster spawn).",
                ClanID = "GraveshackledClanDefine_ID",
                RelicPoolIDs = new List<string> 
                    { 
                        VanillaRelicPoolIDs.MegaRelicPool
                    },
                IconPath = "assets/RelicArt/img_relic_DisplacementLantern.png",
                EffectBuilders = new List<RelicEffectDataBuilder>
            {
                new RelicEffectDataBuilder
                    {
                        RelicEffectClassName = "RelicEffectAddStatusEffectOnSpawn",
                        ParamInt = 1,
                        ParamTrigger = CharacterTriggerData.Trigger.OnSpawn,
                        ParamTargetMode = TargetMode.Room,
                        ParamSourceTeam = Team.Type.Monsters,
                        ParamStatusEffects = new StatusEffectStackData[] 
                            { 
                                new StatusEffectStackData 
                                    { 
                                        statusId = VanillaStatusEffectIDs.Stealth, count = 1 
                                    } 
                            },
                    }

                         //ParamStatusEffects = new StatusEffectStackData[] { new StatusEffectStackData { statusId = "loaded", count = 5 } },
                         //ParamSourceTeam = Team.Type.Heroes,
                         //ParamBool = false,
                         //ParamTargetMode = TargetMode.FrontInRoom,
                         //ParamCardType = CardType.Monster,
                         //ParamCharacterSubtype = "SubtypesData_None",

            },
                Rarity = CollectableRarity.Common
            }
        .BuildAndRegister();
        }
    }
}

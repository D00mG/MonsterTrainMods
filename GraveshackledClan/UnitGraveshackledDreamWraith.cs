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
    class UnitGraveshackledDreamWraith
    {
        public static void Make()
        {
            CardDataBuilder carddreamwraith = new CardDataBuilder
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
                CardID = "CardGraveshackledDreamWraith_ID",
                Name = "Dream Wraith",
                AssetPath = "assets/CardArt/img_unit_dream_wraith.png",
                TargetsRoom = true,

                EffectBuilders = new List<CardEffectDataBuilder>
                    {
                        new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectSpawnMonster),
                                TargetMode = TargetMode.DropTargetCharacter,
                                ParamCharacterDataBuilder = new CharacterDataBuilder
                                    {
                                        CharacterID = "UnitGraveshackledDreamWraith_ID",
                                        Name = "Dream Wraith",
                                        SubtypeKeys = new List<string> { SubtypeGraveshackledPhantasm.Key },
                                        Size = 2,
                                        Health = 5,
                                        AttackDamage = 10,
                                        AssetPath = "assets/UnitArt/img_character_DreamWraith.png",
                                        StartingStatusEffects = new StatusEffectStackData[]
                                            {
                                                new StatusEffectStackData
                                                    {
                                                        count = 2, statusId = "stealth"
                                                    },
                                                new StatusEffectStackData
                                                    {
                                                        count = 1, statusId = "multistrike"
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
                                                        Description = "Gain <nobr><b>+</b><b>{[effect0.status0.power]}[ember]</b></nobr>",
                                                        EffectBuilders = new List<CardEffectDataBuilder>
                                                            {
                                                                new CardEffectDataBuilder
                                                                    {
                                                                        EffectStateType = VanillaCardEffectTypes.CardEffectGainEnergy,
                                                                        TargetMode = TargetMode.Self,
                                                                        TargetTeamType = Team.Type.None,
                                                                        ParamInt = 1
                                                                    }
                                                            }
                                                    }
                                            }
                                    }
                            }
                    }
            };
            carddreamwraith.BuildAndRegister();
        }
    }
}
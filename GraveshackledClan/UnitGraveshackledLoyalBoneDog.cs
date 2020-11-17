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
    class UnitGraveshackledLoyalBoneDog
    {
        public static void Make()
        {
            CardDataBuilder cardloyalbonedog = new CardDataBuilder
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
                CardID = "CardGraveshackledLoyalBoneDog_ID",
                Name = "Loyal Bone Dog",
                AssetPath = "assets/CardArt/img_unit_loyal_bone_dog.png",
                TargetsRoom = true,

                EffectBuilders = new List<CardEffectDataBuilder>
                    {
                        new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectSpawnMonster),
                                TargetMode = TargetMode.DropTargetCharacter,
                                ParamCharacterDataBuilder = new CharacterDataBuilder
                                    {
                                        CharacterID = "UnitGraveshackledLoyalBoneDog_ID",
                                        Name = "Loyal Bone Dog",
                                        SubtypeKeys = new List<string> { SubtypeGraveshackledRevenant.Key },
                                        Size = 1,
                                        Health = 1,
                                        AttackDamage = 0,
                                        AssetPath = "assets/UnitArt/img_character_LoyalBoneDog.png",
                                        StartingStatusEffects = new StatusEffectStackData[]
                                            {
                                                new StatusEffectStackData
                                                    {
                                                        count = 1, statusId = "inert"
                                                    },
                                                new StatusEffectStackData
                                                    {
                                                        count = 1, statusId = "endless"
                                                    }
                                            },
                                        TriggerBuilders = new List<CharacterTriggerDataBuilder>
                                            {
                                                new CharacterTriggerDataBuilder
                                                    {
                                                        Trigger = CharacterTriggerData.Trigger.EndTurnPreHandDiscard,
                                                        Description = "Apply <nobr><b>Armor {[effect0.status0.power]}</b></nobr> to allies.",
                                                        EffectBuilders = new List<CardEffectDataBuilder>
                                                            {
                                                                new CardEffectDataBuilder
                                                                    {
                                                                        EffectStateType = VanillaCardEffectTypes.CardEffectAddStatusEffect,
                                                                        TargetMode = TargetMode.Room,
                                                                        TargetTeamType = Team.Type.Monsters,
                                                                        ParamStatusEffects = new StatusEffectStackData[]
                                                                            {
                                                                                new StatusEffectStackData
                                                                                    {
                                                                                        count = 1,
                                                                                        statusId = VanillaStatusEffectIDs.Armor
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
            cardloyalbonedog.BuildAndRegister();
        }
    }
}
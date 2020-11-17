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
    class UnitGraveshackledMenhirOfSouls
    {
        public static void Make()
        {
            CardDataBuilder cardmenhirofsouls = new CardDataBuilder
            {
                Cost = 1,
                Rarity = CollectableRarity.Uncommon,
                CardType = CardType.Monster,
                ClanID = "GraveshackledClanDefine_ID",
                CardPoolIDs = new List<string>
                    {
                        VanillaCardPoolIDs.MegaPool,
//                        VanillaCardPoolIDs.MegaPool,
// Replace this second MegaPool with the Clan Pool once it is made
                    },
                CardID = "CardGraveshackledMenhirOfSouls_ID",
                Name = "Menhir of Souls",
                AssetPath = "assets/CardArt/img_unit_menhir_of_souls.png",
                TargetsRoom = true,

                EffectBuilders = new List<CardEffectDataBuilder>
                    {
                        new CardEffectDataBuilder
                            {
                                EffectStateType = typeof(CardEffectSpawnMonster),
                                TargetMode = TargetMode.DropTargetCharacter,
                                ParamCharacterDataBuilder = new CharacterDataBuilder
                                    {
                                        CharacterID = "UnitGraveshackledMenhirOfSouls_ID",
                                        Name = "Menhir of Souls",
                                        SubtypeKeys = new List<string> { SubtypeGraveshackledMenhir.Key },
                                        Size = 1,
                                        Health = 10,
                                        AttackDamage = 0,
                                        AssetPath = "assets/UnitArt/img_character_MenhirOfSouls.png",
                                        TriggerBuilders = new List<CharacterTriggerDataBuilder>
                                            {
                                                new CharacterTriggerDataBuilder
                                                    {
                                                        Trigger = CharacterTriggerData.Trigger.EndTurnPreHandDiscard,
                                                        Description = "Apply <nobr><b>Soul</b> <b>{[effect0.status0.power]}</b></nobr> to allies.",
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
                                                                                        statusId = VanillaStatusEffectIDs.Soul
                                                                                    }
                                                                            }
                                                                    }
                                                            }
                                                    },
                                                                new CharacterTriggerDataBuilder
                                                                {
                                                                    Trigger = CharacterTriggerData.Trigger.OnDeath,
                                                                    // Description = "Heal allies equal to <nobr>[effect0.power]x</nobr> the Soul count.",
                                                                        EffectBuilders = new List<CardEffectDataBuilder>
                                                                        {
                                                                            new CardEffectDataBuilder
                                                                            {
                                                                                EffectStateType = VanillaCardEffectTypes.CardEffectHeal,
                                                                                TargetMode = TargetMode.Room,
                                                                                TargetTeamType = Team.Type.Monsters,
                                                                                UseStatusEffectStackMultiplier = true,
                                                                                StatusEffectStackMultiplier = VanillaStatusEffectIDs.Soul,
                                                                                ParamInt = 3,
                                                                            },
                                                                        }
                                                                },
                                            }
                                    }
                            }
                    }
            };
            cardmenhirofsouls.BuildAndRegister();
        }
    }
}
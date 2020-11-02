using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.Builders;
using Trainworks.Constants;
using Trainworks.Managers;

namespace GraveshackledClan_Main
{
    class RewardNodeGraveshackled
    {
        public static void Make()
        {
            CardPool cardPool = UnityEngine.ScriptableObject.CreateInstance<CardPool>();
            var cardDataList = (Malee.ReorderableArray<CardData>)AccessTools.Field(typeof(CardPool), "cardDataList").GetValue(cardPool);
            // Starter cards don't work here.
            cardDataList.Add(CustomCardManager.GetCardDataByID("SpellGraveshackledBloodHarvest_ID"));
            cardDataList.Add(CustomCardManager.GetCardDataByID("CardGraveshackledCharnelSlab_ID"));

            new RewardNodeDataBuilder()
            {
                RewardNodeID = "RewardNode_ClanBanner_ID",
                MapNodePoolIDs = new List<string>
                    {
                        VanillaMapNodePoolIDs.RandomChosenMainClassUnit,
                        VanillaMapNodePoolIDs.RandomChosenSubClassUnit
                    },
                Name = "Graveshackled Clan Banner",
                Description = "Gain a Graveshackled unit.",
                RequiredClass = CustomClassManager.GetClassDataByID("GraveshackledClanDefine_ID"),
                FrozenSpritePath = "assets/ClanArt/img_clan_graveshackled_banner_frozen.png",
                EnabledSpritePath = "assets/ClanArt/img_clan_graveshackled_banner_enabled.png",
                DisabledSpritePath = "assets/ClanArt/img_clan_graveshackled_banner_disabled.png",
                DisabledVisitedSpritePath = "assets/ClanArt/img_clan_graveshackled_banner_visitdisabled.png",
                GlowSpritePath = "assets/ClanArt/img_clan_graveshackled_banner_glow.png",
                MapIconPath = "assets/ClanArt/img_clan_graveshackled_banner_enabled.png",
                MinimapIconPath = "assets/ClanArt/img_clan_graveshackled_banner_minimap.png",
                SkipCheckInBattleMode = true,
                OverrideTooltipTitleBody = false,
                NodeSelectedSfxCue = "Node_Banner",
                RewardBuilders = new List<IRewardDataBuilder>
                    {
                        new DraftRewardDataBuilder()
                    {
                    DraftRewardID = "rewardclangraveshackleddraft_ID",
                    _RewardSpritePath = "assets/ClanArt/img_clan_graveshackled_banner_enabled.png",
                    _RewardTitleKey = "Graveshackled Clan Banner",
                    _RewardDescriptionKey = "Choose a card!",
                    Costs = new int[] { 100 },
                    _IsServiceMerchantReward = false,
                    DraftPool = cardPool,
                    ClassType = (RunState.ClassType)7,
                    DraftOptionsCount = 2,
                    RarityFloorOverride = CollectableRarity.Uncommon
                    }
                }
            }.BuildAndRegister();
        }
    }
}

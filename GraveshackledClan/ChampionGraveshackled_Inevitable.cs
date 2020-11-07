using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Trainworks.Builders;
using Trainworks.Constants;
using Trainworks.Managers;
using Trainworks.Utilities;
using static Trainworks.Constants.VanillaCardPoolIDs;

namespace GraveshackledClan_Main
{
    class ChampionGraveshackled_Inevitable
    {
        public static void Make()
        {
            var championCharacterBuilder = new CharacterDataBuilder
            {
                CharacterID = "UnitGravshackledChampionInevitable_ID",
                Name = "Inevitable",
                Size = 2,
                Health = 10,
                AttackDamage = 5,
                AssetPath = "assets/UnitArt/img_character_inevitable.png"
            };
            new ChampionCardDataBuilder
            {
                Champion = championCharacterBuilder,
                ChampionIconPath = "assets/UnitArt/img_icon_inevitable.png",
                StarterCardData = CustomCardManager.GetCardDataByID("SpellGraveshackledBloodHarvest_ID"),
                CardID = "CardGravshackledChampionInevitable_ID",
                Name = "Inevitable",
                ClanID = "GraveshackledClanDefine_ID",
                AssetPath = "assets/CardArt/img_unit_inevitable.png",
                UpgradeTree = new CardUpgradeTreeDataBuilder
                {
                    UpgradeTrees = new List<List<CardUpgradeDataBuilder>>
                    {
                        new List<CardUpgradeDataBuilder>
                        {
                            InevitableWarBasic.Builder(),
                            InevitableWarAdvanced.Builder(),
                            InevitableWarMaster.Builder(),
                        },
                        new List<CardUpgradeDataBuilder>
                        {
                            InevitableFamineBasic.Builder(),
                            InevitableFamineAdvanced.Builder(),
                            InevitableFamineMaster.Builder(),
                        },
                        new List<CardUpgradeDataBuilder>
                        {
                            InevitablePestilenceBasic.Builder(),
                            InevitablePestilenceAdvanced.Builder(),
                            InevitablePestilenceMaster.Builder(),
                        },
                    },
                },
            }
            .BuildAndRegister();
        }
    }
}
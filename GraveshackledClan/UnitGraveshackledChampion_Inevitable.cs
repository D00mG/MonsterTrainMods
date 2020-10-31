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
    class UnitGraveshackledChampion_Inevitable
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
                StarterCardData = CustomCardManager.GetCardDataByID(VanillaCardIDs.Torch),
                CardID = "CardGravshackledChampionInevitable_ID",
                Name = "K.Aqua",
                ClanID = "GraveshackledClanDefine_ID",
                AssetPath = "assets/CardArt/img_unit_inevitable.png"
            }
            .BuildAndRegister();
        }
    }
}
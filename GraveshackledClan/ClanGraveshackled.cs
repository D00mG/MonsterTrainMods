using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.Builders;
using Trainworks.Constants;
using Trainworks.Managers;

namespace GraveshackledClan_Main
{
    class ClanGraveshackled
    {
        public static readonly string ID = "GraveshackledClanDefine_ID";

        public static void Make()
        {
            new ClassDataBuilder
            {
                ClassID = ID,
                Name = "Graveshackled Clan",
                Description = "Raise the restless dead of the Graveshackled Clan. Draw sustenance from your enemy's forces and defeat them with afflictions and trickery.",
                SubclassDescription = "Ally with sturdy Revenants and etherial Phantasms of the Graveshackled Clan.",
                DraftIconPath = "assets/ClanArt/img_clan_graveshackled_cardback.png",
                CardFrameUnitPath = "assets/CardArt/cardframeGraveshackledUnit.png",
                CardFrameSpellPath = "assets/CardArt/cardframeGraveshackledSpell.png",
                IconAssetPaths = new List<string>
                    {
                        "assets/ClanArt/img_clan_graveshackled_small.png",
                        "assets/ClanArt/img_clan_graveshackled_medium.png",
                        "assets/ClanArt/img_clan_graveshackled_large.png",
                        "assets/ClanArt/img_clan_graveshackled_silhouette.png"
                    },
                UiColor = new UnityEngine.Color(0.1f, 0.8f, 0.8f, 1f),
                UiColorDark = new UnityEngine.Color(0.05f, 0.5f, 0.5f, 1f),
            }.BuildAndRegister();
        }
    }
}

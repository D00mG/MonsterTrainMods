using BepInEx;
using HarmonyLib;
using Trainworks.Interfaces;
using Trainworks.Managers;
using System;

namespace GraveshackledClan_Main
{
    [BepInPlugin("doomg.mod.graveshackledclan", "Graveshackled Clan", "1.0.0")]
    [BepInDependency("tools.modding.trainworks")]
    public class GraveshackledClan_Main : BaseUnityPlugin, IInitializable
    {
        public void Initialize()
        {
            ClanGraveshackled.Make();
            SubtypeGraveshackledRevenant.RegisterSubtypes();
            RelicGraveshackledDisplacementLantern.Make();
            SpellGraveshackledBloodHarvest.Make();
            UnitGraveshackledCharnelSlab.Make();
            ChampionGraveshackled_Inevitable.Make();
            RewardNodeGraveshackled.Make();
        }
        void Awake()
        {
            var harmony = new Harmony("doomg.mod.graveshackledclan");
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(SaveManager), "SetupRun")]
        class AddToStartingDeck
        {
            static void Postfix(ref SaveManager __instance)
            {
                __instance.AddCardToDeck(CustomCardManager.GetCardDataByID("SpellGraveshackledBloodHarvest_ID"));
                __instance.AddCardToDeck(CustomCardManager.GetCardDataByID("CardGraveshackledCharnelSlab_ID"));
            }
        }

        //[HarmonyPatch(typeof(SaveManager), "SetupRun")]
        //class AddRelicAtStartOfRunPatch
        //{
        //    static void Postfix(ref SaveManager __instance)
        //    {
        //        __instance.AddRelic(CustomCollectableRelicManager.GetRelicDataByID("RelicGraveshackledDisplacementLantern_ID"));
        //    }
        //}

        // Logbook set up I think?
        //[HarmonyPatch(typeof(MetagameSaveData), "HasDiscoveredCard", new Type[] { typeof(CardData) })]
        //class ShowAllLogbookCardsPatch
        //{
        //    static bool Prefix(ref bool __result)
        //    {
        //        __result = true;
        //        return false;
        //    }
        //}

        //[HarmonyPatch(typeof(MetagameSaveData), "HasDiscoveredCard", new Type[] { typeof(string) })]
        //class ShowAllLogbookCardsPatch2
        //{
        //    static bool Prefix(ref bool __result)
        //    {
        //        __result = true;
        //        return false;
        //    }
        //}

        // Register Relics to the Logbook
        //[HarmonyPatch(typeof(CompendiumRelicUI), "SetLocked")]
        //class RevealAllRelics
        //{
        //    // Creates and registers card data for each card class
        //    static bool Prefix(CompendiumRelicUI __instance)
        //    {
        //        return false;
        //    }
        //}

    }
}

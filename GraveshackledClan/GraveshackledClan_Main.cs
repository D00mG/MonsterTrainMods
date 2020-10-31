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
            UnitGraveshackledChampion_Inevitable.Make();
            SpellGraveshackledBloodHarvest.Make();
            UnitGraveshackledCharnelSlab.Make();
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
    }
}

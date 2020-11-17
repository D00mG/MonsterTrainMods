using BepInEx;
using HarmonyLib;
using Trainworks.Interfaces;
using Trainworks.Managers;
using System;
using I2.Loc;

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
            SubtypeGraveshackledMenhir.RegisterSubtypes();
            SubtypeGraveshackledPhantasm.RegisterSubtypes();
            RelicGraveshackledDisplacementLantern.Make();
            SpellGraveshackledBloodHarvest.Make();
            UnitGraveshackledAberrantColossus.Make();
            UnitGraveshackledBladeSpecter.Make();
            UnitGraveshackledCharnelSlab.Make();
            UnitGraveshackledDreamWraith.Make();
            UnitGraveshackledFrightShade.Make();
            UnitGraveshackledLoyalBoneDog.Make();
            UnitGraveshackledMarrowFiend.Make();
            UnitGraveshackledMenhirOfMemories.Make();
            UnitGraveshackledMenhirOfSouls.Make();
            UnitGraveshackledPaleWorm.Make();
            UnitGraveshackledSeaOfMaggots.Make();
            UnitGraveshackledVileFigment.Make();
            UnitGraveshackledWretchedSpawn.Make();
            UnitGraveshackledNightStalker.Make(); // needs to initialize after UnitGraveshackledWretchedSpawn
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
                //__instance.AddCardToDeck(CustomCardManager.GetCardDataByID("SpellGraveshackledBloodHarvest_ID"));
                //__instance.AddCardToDeck(CustomCardManager.GetCardDataByID("CardGraveshackledCharnelSlab_ID"));
                //__instance.AddCardToDeck(CustomCardManager.GetCardDataByID("CardGraveshackledMenhirOfMemories_ID"));
                //__instance.AddCardToDeck(CustomCardManager.GetCardDataByID("CardGraveshackledMenhirOfSouls_ID"));
                //__instance.AddCardToDeck(CustomCardManager.GetCardDataByID("CardGraveshackledSeaOfMaggots_ID"));
                //__instance.AddCardToDeck(CustomCardManager.GetCardDataByID("CardGraveshackledDreamWraith_ID"));
                //__instance.AddCardToDeck(CustomCardManager.GetCardDataByID("CardGraveshackledPaleWorm_ID"));
                //__instance.AddCardToDeck(CustomCardManager.GetCardDataByID("CardGraveshackledBladeSpecter_ID"));
                //__instance.AddCardToDeck(CustomCardManager.GetCardDataByID("CardGraveshackledWretchedSpawn_ID"));
                //__instance.AddCardToDeck(CustomCardManager.GetCardDataByID("CardGraveshackledFrightShade_ID"));
                //__instance.AddCardToDeck(CustomCardManager.GetCardDataByID("CardGraveshackledVileFigment_ID"));
                //__instance.AddCardToDeck(CustomCardManager.GetCardDataByID("CardGraveshackledAberrantColossus_ID"));
                //__instance.AddCardToDeck(CustomCardManager.GetCardDataByID("CardGraveshackledMarrowFiend_ID"));
                //__instance.AddCardToDeck(CustomCardManager.GetCardDataByID("CardGraveshackledLoyalBoneDog_ID"));

            }
        }

        [HarmonyPatch(typeof(LocalizationManager), "UpdateSources")]
        class RegisterLocalizationStrings
        {
            static void Postfix()
            {
                CustomLocalizationManager.ImportCSV("loc/localization.csv");
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

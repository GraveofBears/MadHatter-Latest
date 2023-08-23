using System;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using UnityEngine;
using ServerSync;
using HarmonyLib;
using ItemManager;


namespace MadHatter
{
    [BepInPlugin(ModGUID, ModName, ModVersion)]


    public class GoodestBoy : BaseUnityPlugin
    {
        private const string ModName = "MadHatter";
        private const string ModVersion = "0.1.10";
        private const string ModGUID = "odinplus.plugins.madhatter";



        private static readonly ConfigSync configSync = new(ModName) { DisplayName = ModName, CurrentVersion = ModVersion, MinimumRequiredVersion = ModVersion };

        private static ConfigEntry<Toggle> serverConfigLocked = null!;


        private ConfigEntry<T> config<T>(string group, string name, T value, ConfigDescription description, bool synchronizedSetting = true)
        {
            ConfigEntry<T> configEntry = Config.Bind(group, name, value, description);

            SyncedConfigEntry<T> syncedConfigEntry = configSync.AddConfigEntry(configEntry);
            syncedConfigEntry.SynchronizedConfig = synchronizedSetting;

            return configEntry;
        }


        private ConfigEntry<T> config<T>(string group, string name, T value, string description, bool synchronizedSetting = true) => config(group, name, value, new ConfigDescription(description), synchronizedSetting);

        private enum Toggle
        {
            On = 1,
            Off = 0
        }

        public void Awake()
        {

            Item Catears = new Item("hats", "Catears", "Hatter");
            Catears.Crafting.Add(CraftingTable.Workbench, 3);
            Catears.RequiredItems.Add("TrophyWolf", 4);
            Catears.RequiredItems.Add("LinenThread", 4);
            Catears.RequiredItems.Add("LeatherScraps", 4);
            Catears.RequiredUpgradeItems.Add("TrophyWolf", 2);
            Catears.Configurable = Configurability.Full;
            Catears.CraftAmount = 1;

            Item CatTail = new Item("hats", "CatTail", "Hatter");
            CatTail.Crafting.Add(CraftingTable.Workbench, 3);
            CatTail.RequiredItems.Add("TrophySerpent", 1);
            CatTail.RequiredItems.Add("LinenThread", 4);
            CatTail.RequiredItems.Add("LeatherScraps", 4);
            CatTail.RequiredUpgradeItems.Add("TrophySerpent", 2);
            CatTail.Configurable = Configurability.Full;
            CatTail.CraftAmount = 1;

            Item DarkRavenCowl = new Item("hats", "DarkRavenCowl", "Hatter");
            DarkRavenCowl.Crafting.Add(CraftingTable.Workbench, 3);
            DarkRavenCowl.RequiredItems.Add("TrophySurtling", 4);
            DarkRavenCowl.RequiredItems.Add("LinenThread", 4);
            DarkRavenCowl.RequiredItems.Add("LeatherScraps", 4);
            DarkRavenCowl.RequiredUpgradeItems.Add("TrophySurtling", 2);
            DarkRavenCowl.CraftAmount = 1;

            Item DemonMask = new Item("hats", "DemonMask", "Hatter");
            DemonMask.Crafting.Add(CraftingTable.Workbench, 3);
            DemonMask.RequiredItems.Add("TrophySkeleton", 6);
            DemonMask.RequiredItems.Add("LinenThread", 4);
            DemonMask.RequiredItems.Add("LeatherScraps", 4);
            DemonMask.RequiredUpgradeItems.Add("TrophySkeleton", 2);
            DemonMask.Configurable = Configurability.Full;
            DemonMask.CraftAmount = 1;

            Item GrimAgeWarlord = new Item("hats", "GrimAgeWarlord", "Hatter");
            GrimAgeWarlord.Crafting.Add(CraftingTable.Workbench, 3);
            GrimAgeWarlord.RequiredItems.Add("TrophySurtling", 4);
            GrimAgeWarlord.RequiredItems.Add("LinenThread", 4);
            GrimAgeWarlord.RequiredItems.Add("LeatherScraps", 4);
            GrimAgeWarlord.RequiredUpgradeItems.Add("TrophySurtling", 2);
            GrimAgeWarlord.Configurable = Configurability.Full;
            GrimAgeWarlord.CraftAmount = 1;

            Item HoodofYggdrasil = new Item("hats", "HoodofYggdrasil", "Hatter");
            HoodofYggdrasil.Crafting.Add(CraftingTable.Workbench, 3);
            HoodofYggdrasil.RequiredItems.Add("TrophyEikthyr", 2);
            HoodofYggdrasil.RequiredItems.Add("LinenThread", 4);
            HoodofYggdrasil.RequiredItems.Add("LeatherScraps", 4);
            HoodofYggdrasil.RequiredUpgradeItems.Add("TrophyEikthyr", 2);
            HoodofYggdrasil.Configurable = Configurability.Full;
            HoodofYggdrasil.CraftAmount = 1;

            Item Catmask = new Item("hats", "Catmask", "Hatter");
            Catmask.Crafting.Add(CraftingTable.Workbench, 3);
            Catmask.RequiredItems.Add("TrophyEikthyr", 2);
            Catmask.RequiredItems.Add("LinenThread", 4);
            Catmask.RequiredItems.Add("LeatherScraps", 4);
            Catmask.RequiredUpgradeItems.Add("TrophyEikthyr", 2);
            Catmask.Configurable = Configurability.Full;
            Catmask.CraftAmount = 1;

            Item wolfhead = new Item("hats", "wolfhead", "Hatter");
            wolfhead.Crafting.Add(CraftingTable.Workbench, 3);
            wolfhead.RequiredItems.Add("TrophyWolf", 4);
            wolfhead.RequiredItems.Add("LinenThread", 4);
            wolfhead.RequiredItems.Add("LeatherScraps", 4);
            wolfhead.RequiredUpgradeItems.Add("TrophyWolf", 2);
            wolfhead.Configurable = Configurability.Full;
            wolfhead.CraftAmount = 1;

            Item Neckhead = new Item("hats", "Neckhead", "Hatter");
            Neckhead.Crafting.Add(CraftingTable.Workbench, 3);
            Neckhead.RequiredItems.Add("TrophyNeck", 4);
            Neckhead.RequiredItems.Add("LinenThread", 4);
            Neckhead.RequiredItems.Add("LeatherScraps", 4);
            Neckhead.RequiredUpgradeItems.Add("TrophyNeck", 2);
            Neckhead.Configurable = Configurability.Full;
            Neckhead.CraftAmount = 1;

            Item Magehat = new Item("hats", "Magehat", "Hatter");
            Magehat.Crafting.Add(CraftingTable.Workbench, 3);
            Magehat.RequiredItems.Add("TrophyGreydwarfShaman", 4);
            Magehat.RequiredItems.Add("LinenThread", 4);
            Magehat.RequiredItems.Add("LeatherScraps", 4);
            Magehat.RequiredUpgradeItems.Add("TrophyGreydwarfShaman", 2);
            Magehat.Configurable = Configurability.Full;
            Magehat.CraftAmount = 1;

            Item Greydwarfhat = new Item("hats", "Greydwarfhat", "Hatter");
            Greydwarfhat.Crafting.Add(CraftingTable.Workbench, 3);
            Greydwarfhat.RequiredItems.Add("TrophyGreydwarfShaman", 4);
            Greydwarfhat.RequiredItems.Add("LinenThread", 4);
            Greydwarfhat.RequiredItems.Add("LeatherScraps", 4);
            Greydwarfhat.RequiredUpgradeItems.Add("TrophyGreydwarfShaman", 2);
            Greydwarfhat.Configurable = Configurability.Full;
            Greydwarfhat.CraftAmount = 1;

            Item Sheida = new Item("hats", "Sheida", "Hatter");
            Sheida.Crafting.Add(CraftingTable.Workbench, 3);
            Sheida.RequiredItems.Add("TrophySurtling", 3);
            Sheida.RequiredItems.Add("LinenThread", 4);
            Sheida.RequiredItems.Add("LeatherScraps", 4);
            Sheida.RequiredUpgradeItems.Add("TrophySurtling", 2);
            Sheida.Configurable = Configurability.Full;
            Sheida.CraftAmount = 1;

            Item GrimAgeHornedHelm = new Item("hats", "GrimAgeHornedHelm", "Hatter");
            GrimAgeHornedHelm.Crafting.Add(CraftingTable.Workbench, 3);
            GrimAgeHornedHelm.RequiredItems.Add("TrophySerpent", 2);
            GrimAgeHornedHelm.RequiredItems.Add("LinenThread", 4);
            GrimAgeHornedHelm.RequiredItems.Add("LeatherScraps", 4);
            GrimAgeHornedHelm.RequiredUpgradeItems.Add("TrophySerpent", 2);
            GrimAgeHornedHelm.Configurable = Configurability.Full;
            GrimAgeHornedHelm.CraftAmount = 1;

            Item GrimAgeChaosWarrior = new Item("hats", "GrimAgeChaosWarrior", "Hatter");
            GrimAgeChaosWarrior.Crafting.Add(CraftingTable.Workbench, 3);
            GrimAgeChaosWarrior.RequiredItems.Add("TrophyDragonQueen", 1);
            GrimAgeChaosWarrior.RequiredItems.Add("LinenThread", 4);
            GrimAgeChaosWarrior.RequiredItems.Add("LeatherScraps", 4);
            GrimAgeChaosWarrior.Configurable = Configurability.Full;
            GrimAgeChaosWarrior.CraftAmount = 1;

            Item LunarCrown = new Item("hats", "LunarCrown", "Hatter");
            LunarCrown.Crafting.Add(CraftingTable.Workbench, 3);
            LunarCrown.RequiredItems.Add("TrophyDeer", 6);
            LunarCrown.RequiredItems.Add("LinenThread", 4);
            LunarCrown.RequiredItems.Add("LeatherScraps", 4);
            LunarCrown.RequiredUpgradeItems.Add("TrophyDeer", 2);
            LunarCrown.Configurable = Configurability.Full;
            LunarCrown.CraftAmount = 1;

            Item MerchantsHat = new Item("hats", "MerchantsHat", "Hatter");
            MerchantsHat.Crafting.Add(CraftingTable.Workbench, 3);
            MerchantsHat.RequiredItems.Add("TrophyDraugr", 3);
            MerchantsHat.RequiredItems.Add("LinenThread", 4);
            MerchantsHat.RequiredItems.Add("LeatherScraps", 4);
            MerchantsHat.RequiredUpgradeItems.Add("TrophyDraugr", 2);
            MerchantsHat.Configurable = Configurability.Full;
            MerchantsHat.CraftAmount = 1;

            Item EphemeralHelm = new Item("hats", "EphemeralHelm", "Hatter");
            EphemeralHelm.Crafting.Add(CraftingTable.Workbench, 3);
            EphemeralHelm.RequiredItems.Add("TrophySkeleton", 4);
            EphemeralHelm.RequiredItems.Add("LinenThread", 4);
            EphemeralHelm.RequiredItems.Add("LeatherScraps", 4);
            EphemeralHelm.RequiredUpgradeItems.Add("TrophySkeleton", 2);
            EphemeralHelm.Configurable = Configurability.Full;
            EphemeralHelm.CraftAmount = 1;

            Item SGTLShogunHat = new Item("hats", "SGTLShogunHat", "Hatter");
            SGTLShogunHat.Crafting.Add(CraftingTable.Workbench, 3);
            SGTLShogunHat.RequiredItems.Add("TrophyBoar", 4);
            SGTLShogunHat.RequiredItems.Add("LinenThread", 4);
            SGTLShogunHat.RequiredItems.Add("LeatherScraps", 4);
            SGTLShogunHat.RequiredUpgradeItems.Add("TrophyBoar", 2);
            SGTLShogunHat.Configurable = Configurability.Full;
            SGTLShogunHat.CraftAmount = 1;

            Item DeathKnightHelm = new Item("hats", "DeathKnightHelm", "Hatter");
            DeathKnightHelm.Crafting.Add(CraftingTable.Workbench, 3);
            DeathKnightHelm.RequiredItems.Add("TrophyDeathsquito", 2);
            DeathKnightHelm.RequiredItems.Add("LinenThread", 4);
            DeathKnightHelm.RequiredItems.Add("LeatherScraps", 4);
            DeathKnightHelm.Configurable = Configurability.Full;
            DeathKnightHelm.CraftAmount = 1;

            Item FallenWarriorHelm = new Item("hats", "FallenWarriorHelm", "Hatter");
            FallenWarriorHelm.Crafting.Add(CraftingTable.Workbench, 3);
            FallenWarriorHelm.RequiredItems.Add("TrophySkeleton", 4);
            FallenWarriorHelm.RequiredItems.Add("LinenThread", 4);
            FallenWarriorHelm.RequiredItems.Add("LeatherScraps", 4);
            FallenWarriorHelm.RequiredUpgradeItems.Add("TrophySkeleton", 2);
            FallenWarriorHelm.Configurable = Configurability.Full;
            FallenWarriorHelm.CraftAmount = 1;

            Item Goblinhat = new Item("hats", "Goblinhat", "Hatter");
            Goblinhat.Crafting.Add(CraftingTable.Workbench, 3);
            Goblinhat.RequiredItems.Add("TrophyGoblin", 4);
            Goblinhat.RequiredItems.Add("LinenThread", 4);
            Goblinhat.RequiredItems.Add("LeatherScraps", 4);
            Goblinhat.RequiredUpgradeItems.Add("TrophyGoblin", 2);
            Goblinhat.Configurable = Configurability.Full;
            Goblinhat.CraftAmount = 1;

            Item SamuraiHelm = new Item("hats", "SamuraiHelm", "Hatter");
            SamuraiHelm.Crafting.Add(CraftingTable.Workbench, 3);
            SamuraiHelm.RequiredItems.Add("TrophyBonemass", 1);
            SamuraiHelm.RequiredItems.Add("LinenThread", 4);
            SamuraiHelm.RequiredItems.Add("LeatherScraps", 4);
            SamuraiHelm.RequiredUpgradeItems.Add("TrophyBonemass", 2);
            SamuraiHelm.Configurable = Configurability.Full;
            SamuraiHelm.CraftAmount = 1;

            Item DragonHeaddress = new Item("hats", "DragonHeaddress", "Hatter");
            DragonHeaddress.Crafting.Add(CraftingTable.Workbench, 3);
            DragonHeaddress.RequiredItems.Add("TrophyDragonQueen", 1);
            DragonHeaddress.RequiredItems.Add("LinenThread", 4);
            DragonHeaddress.RequiredItems.Add("LeatherScraps", 4);
            DragonHeaddress.RequiredUpgradeItems.Add("TrophyDragonQueen", 2);
            DragonHeaddress.Configurable = Configurability.Full;
            DragonHeaddress.CraftAmount = 1;

            Assembly assembly = Assembly.GetExecutingAssembly();
            Harmony harmony = new(ModGUID);
            harmony.PatchAll(assembly);
        }
    }
}
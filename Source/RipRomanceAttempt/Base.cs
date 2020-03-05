using RimWorld;
using Verse;

namespace RipRomanceAttempt
{
    [StaticConstructorOnStartup]
    public static class Initialization
    {
        static Initialization()
        {
            HarmonyPatches.HPatcher.Init();
        }
    }
}


/*using UnityEngine;
using Verse;
using System;
using System.Collections.Generic;
using HugsLib;
using HugsLib.Settings;

namespace RipRomanceAttempt
{
    internal class RipRomanceAttempt : ModBase
    {
        public static Settings settings;

        public override string ModIdentifier {
            get {
                return "RipRomanceAttempt";
            }
        }

        public override void Initialize()
        {
            HarmonyPatches.HPatcher.Init();
        }

        public override void DefsLoaded()
        {
            settings = new Settings(Settings);
        }
    }

    internal class Settings
    {
        public static SettingHandle<bool> no_romance_attempt;

        public static bool no_romance_attempt_if_relationship_stable = true;
        public static bool no_romance_attempt_if_recently_rebuffed = true;

        public static bool psychopath_no_romance_attempt = false;
        public static bool psychopath_no_beauty_opinion_impact = true;
        public static bool psychopath_no_romance_opinion_and_mood_impact = true;

        public Settings(ModSettingsPack settings)
        {
            no_romance_attempt = settings.GetHandle("no_romance_attempt", "RRA.no_romance_attempt".Translate(), "RRA.no_romance_attempt_desc".Translate(), false);
        }

        private static SettingHandle.ValueIsValid AtLeast(int amount)
        {
            return delegate(string value)
            {
                int actual;
                return int.TryParse(value, out actual) && actual >= amount;
            };
        }
    }
}
*/
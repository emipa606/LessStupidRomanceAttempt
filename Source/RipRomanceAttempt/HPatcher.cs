using System;
using System.Reflection;
using HarmonyLib;
using Verse;

namespace RipRomanceAttempt;

[StaticConstructorOnStartup]
internal static class HPatcher
{
    static HPatcher()
    {
        try
        {
            new Harmony("Harmony_RipRomanceAttempt").PatchAll(Assembly.GetExecutingAssembly());
        }
        catch (Exception e)
        {
            Log.Error($"RipRomanceAttempt Mod Exception, failed to proceed harmony patches: {e.Message}");
        }
    }
}
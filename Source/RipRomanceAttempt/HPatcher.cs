using System.Reflection;
using HarmonyLib;
using Verse;

namespace RipRomanceAttempt;

[StaticConstructorOnStartup]
internal static class HPatcher
{
    static HPatcher()
    {
        new Harmony("Harmony_RipRomanceAttempt").PatchAll(Assembly.GetExecutingAssembly());
    }
}
using HarmonyLib;
using RimWorld;
using Verse;

namespace RipRomanceAttempt;

[HarmonyPatch(typeof(InteractionWorker_RomanceAttempt), "SuccessChance")]
public static class RRA_RA_SuccessChance
{
    public static void Postfix(ref float __result, Pawn initiator, Pawn recipient)
    {
        // more likely to rebuff non-ideal gender
        if (initiator.gender == recipient.gender != recipient.story.traits.HasTrait(TraitDefOf.Gay))
        {
            __result *= 0.6f;
        }
    }
}
using HarmonyLib;
using RimWorld;
using Verse;

namespace RipRomanceAttempt;

[HarmonyPatch(typeof(InteractionWorker_MarriageProposal), "RandomSelectionWeight")]
public static class RRA_MP_RandomSelectionWeight
{
    public static void Postfix(ref float __result, Pawn initiator, Pawn recipient)
    {
        // never get married with non-ideal gender
        if (initiator.gender == recipient.gender != initiator.story.traits.HasTrait(TraitDefOf.Gay))
        {
            __result = 0f;
        }
    }
}
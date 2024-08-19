using HarmonyLib;
using RimWorld;
using Verse;

namespace RipRomanceAttempt;

[HarmonyPatch(typeof(InteractionWorker_MarriageProposal), nameof(InteractionWorker_MarriageProposal.AcceptanceChance))]
public static class InteractionWorker_MarriageProposal_AcceptanceChance
{
    public static void Postfix(ref float __result, Pawn initiator, Pawn recipient)
    {
        if (recipient.story.traits.HasTrait(TraitDefOf.Bisexual))
        {
            return;
        }

        // always reject marrage proposal if non-ideal gender
        if (initiator.gender == recipient.gender != recipient.story.traits.HasTrait(TraitDefOf.Gay))
        {
            __result = 0f;
        }
    }
}
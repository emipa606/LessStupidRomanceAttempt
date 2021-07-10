using HarmonyLib;
using RimWorld;
using Verse;

namespace RipRomanceAttempt.HarmonyPatches
{
    [HarmonyPatch(typeof(InteractionWorker_MarriageProposal), "AcceptanceChance")]
    public static class RRA_MP_AcceptanceChance
    {
        public static void Postfix(ref float __result, Pawn initiator, Pawn recipient)
        {
            // always reject marrage proposal if non-ideal gender
            if (initiator.gender == recipient.gender != recipient.story.traits.HasTrait(TraitDefOf.Gay))
            {
                __result = 0f;
            }
        }
    }
}
using HarmonyLib;
using RimWorld;
using Verse;

namespace RipRomanceAttempt;

[HarmonyPatch(typeof(InteractionWorker_Breakup), "RandomSelectionWeight")]
public static class RRA_B_RandomSelectionWeight
{
    public static void Postfix(ref float __result, Pawn initiator, Pawn recipient)
    {
        // more likely to breakup with non-ideal gender
        if (initiator.gender == recipient.gender != initiator.story.traits.HasTrait(TraitDefOf.Gay))
        {
            __result *= 2f;
        }
    }
}
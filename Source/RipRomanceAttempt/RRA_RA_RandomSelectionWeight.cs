using HarmonyLib;
using RimWorld;
using Verse;

namespace RipRomanceAttempt;

[HarmonyPatch(typeof(InteractionWorker_RomanceAttempt), "RandomSelectionWeight")]
public static class RRA_RA_RandomSelectionWeight
{
    public static void Postfix(ref float __result, Pawn initiator, Pawn recipient)
    {
        // one in mental break OR is already lover of the initiator can't be targeted
        if (recipient.InMentalState || LovePartnerRelationUtility.LovePartnerRelationExists(initiator, recipient))
        {
            __result = 0f;
            return;
        }

        // one can't perform romance atempt if recently rebuffed
        if (initiator.needs.mood.thoughts.memories.NumMemoriesOfDef(ThoughtDefOf.RebuffedMyRomanceAttempt) > 0)
        {
            __result = 0f;
            return;
        }

        // one can't target other people if current lover is good enough
        var initiator_partner = LovePartnerRelationUtility.ExistingMostLikedLovePartner(initiator, false);
        if (initiator_partner != null && initiator.relations.OpinionOf(initiator_partner) >= 25)
        {
            __result = 0f;
            return;
        }

        // one can't be targeted if current lover is good enough
        var recipient_partner = LovePartnerRelationUtility.ExistingMostLikedLovePartner(recipient, false);
        if (recipient_partner != null && recipient.relations.OpinionOf(recipient_partner) >= 25)
        {
            __result = 0f;
        }
    }
}
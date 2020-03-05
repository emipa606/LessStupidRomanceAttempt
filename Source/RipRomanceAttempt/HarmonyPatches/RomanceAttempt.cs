using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using UnityEngine;
using Verse;
using RimWorld;
using HarmonyLib;

namespace RipRomanceAttempt.HarmonyPatches
{
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
            Pawn initiator_partner = LovePartnerRelationUtility.ExistingMostLikedLovePartner(initiator, false);
            if (initiator_partner != null && initiator.relations.OpinionOf(initiator_partner) >= 25)
            {
                __result = 0f;
                return;
            }

            // one can't be targeted if current lover is good enough
            Pawn recipient_partner = LovePartnerRelationUtility.ExistingMostLikedLovePartner(recipient, false);
            if (recipient_partner != null && recipient.relations.OpinionOf(recipient_partner) >= 25)
            {
                __result = 0f;
                return;
            }
        }
    }

    [HarmonyPatch(typeof(InteractionWorker_RomanceAttempt), "SuccessChance")]
    public static class RRA_RA_SuccessChance
    {
        public static void Postfix(ref float __result, Pawn initiator, Pawn recipient)
        {
            // more likely to rebuff non-ideal gender
            if ((initiator.gender == recipient.gender) != (recipient.story.traits.HasTrait(TraitDefOf.Gay)))
            {
                __result *= 0.6f;
                return;
            }
        }
    }
    
    [HarmonyPatch(typeof(InteractionWorker_Breakup), "RandomSelectionWeight")]
    public static class RRA_B_RandomSelectionWeight
    {
        public static void Postfix(ref float __result, Pawn initiator, Pawn recipient)
        {
            // more likely to breakup with non-ideal gender
            if ((initiator.gender == recipient.gender) != (initiator.story.traits.HasTrait(TraitDefOf.Gay)))
            {
                __result *= 2f;
                return;
            }
        }
    }

    [HarmonyPatch(typeof(InteractionWorker_MarriageProposal), "RandomSelectionWeight")]
    public static class RRA_MP_RandomSelectionWeight
    {
        public static void Postfix(ref float __result, Pawn initiator, Pawn recipient)
        {
            // never get married with non-ideal gender
            if ((initiator.gender == recipient.gender) != (initiator.story.traits.HasTrait(TraitDefOf.Gay)))
            {
                __result = 0f;
                return;
            }
        }
    }

    [HarmonyPatch(typeof(InteractionWorker_MarriageProposal), "AcceptanceChance")]
    public static class RRA_MP_AcceptanceChance
    {
        public static void Postfix(ref float __result, Pawn initiator, Pawn recipient)
        {
            // always reject marrage proposal if non-ideal gender
            if ((initiator.gender == recipient.gender) != (recipient.story.traits.HasTrait(TraitDefOf.Gay)))
            {
                __result = 0f;
                return;
            }
        }
    }
}

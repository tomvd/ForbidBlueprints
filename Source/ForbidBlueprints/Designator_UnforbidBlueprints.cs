using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;
using UnityEngine;

namespace ForbidBlueprints
{
    class Designator_UnforbidBlueprints : Designator_Unforbid
    {
        public Designator_UnforbidBlueprints()
        {
            this.defaultLabel = "Unforbid Blueprint";
            this.defaultDesc = "Unforbids blueprints and frames.";
            this.icon = ContentFinder<Texture2D>.Get("UI/Designators/blueprintUnforbid", true);
            this.soundDragSustain = SoundDefOf.Designate_DragStandard;
            this.soundDragChanged = SoundDefOf.Designate_DragStandard_Changed;
            this.useMouseIcon = true;
            this.soundSucceeded = SoundDefOf.Designate_Claim;
            //this.hotKey = KeyBindingDefOf.Command_ItemForbid;
            this.hasDesignateAllFloatMenuOption = true;
            this.designateAllLabel = "Unforbid all blueprints";
        }

        public override AcceptanceReport CanDesignateThing(Thing t)
        {
            bool validBlueprint = (t.def.IsBlueprint || t.def.IsFrame) && t.Faction == Faction.OfPlayer;
            if (!validBlueprint)
            {
                return false;
            }

            CompForbiddable compForbiddable = t.TryGetComp<CompForbiddable>();
            return compForbiddable != null && compForbiddable.Forbidden;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;
using UnityEngine;

namespace ForbidBlueprints
{
    class Designator_ForbidBlueprints : Designator_Forbid
    {
        public Designator_ForbidBlueprints()
        {
            this.defaultLabel = "Forbid Blueprint";
            this.defaultDesc = "Forbids blueprints and frames.";
            this.icon = ContentFinder<Texture2D>.Get("UI/Designators/blueprintForbid", true);
            this.soundDragSustain = SoundDefOf.Designate_DragStandard;
            this.soundDragChanged = SoundDefOf.Designate_DragStandard_Changed;
            this.useMouseIcon = true;
            this.soundSucceeded = SoundDefOf.Designate_Claim;
            //this.hotKey = KeyBindingDefOf.Command_ItemForbid;
            this.hasDesignateAllFloatMenuOption = true;
            this.designateAllLabel = "Forbid all blueprints";
        }

        public override AcceptanceReport CanDesignateThing(Thing t)
        {
            bool validBlueprint = (t.def.IsBlueprint || t.def.IsFrame) && t.Faction == Faction.OfPlayer;
            if (!validBlueprint)
            {
                return false;
            }

            CompForbiddable compForbiddable = t.TryGetComp<CompForbiddable>();
            return compForbiddable != null && !compForbiddable.Forbidden;
        }
    }
}

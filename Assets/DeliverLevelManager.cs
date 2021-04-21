using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverLevelManager : CollectLevelManager
{
    public override void Start()
    {
        base.Start();

        levelName = Dialogs.deliverLevelName;
        hud.updateTarget (Dialogs.deliverLevelName, string.Format(Dialogs.deliverLevelTarget, levelTargetValue,currentCollectValue),
            string.Format(Dialogs.deliverLevelIntroduction, levelTargetValue),0);
    }

    protected override void updateTarget()
    {
        hud.updateTargetOnly(string.Format(Dialogs.deliverLevelTarget, levelTargetValue, currentCollectValue));
    }
}

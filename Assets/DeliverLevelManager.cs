using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverLevelManager : CollectLevelManager
{
    public override void Start()
    {
        base.Start();

        levelName = Dialogs.deliverLevelName;
        hud.updateTarget(string.Format(Dialogs.deliverLevelTarget, levelTargetValue),
            string.Format(Dialogs.deliverLevelIntroduction, levelTargetValue));
    }
}

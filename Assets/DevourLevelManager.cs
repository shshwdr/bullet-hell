using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevourLevelManager : CollectLevelManager
{
    public override void Start()
    {
        base.Start();

        levelTargetValue = GameManager.Instance.difficulty + 1;
        levelName = Dialogs.devourLevelName;
        hud.updateTarget(Dialogs.devourLevelName,string.Format(Dialogs.devourLevelTarget, levelTargetValue,currentCollectValue),
            string.Format(Dialogs.devourLevelIntroduction, levelTargetValue),1);
    }
    protected override void updateTarget()
    {
        hud.updateTargetOnly(string.Format(Dialogs.devourLevelTarget, levelTargetValue, currentCollectValue));
    }
}

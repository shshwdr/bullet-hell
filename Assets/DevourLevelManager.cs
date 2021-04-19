using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevourLevelManager : CollectLevelManager
{
    public override void Start()
    {
        base.Start();

        levelName = Dialogs.devourLevelName;
        hud.updateTarget(string.Format(Dialogs.devourLevelTarget, currentCollectValue),
            string.Format(Dialogs.devourLevelIntroduction, currentCollectValue));
        currentCollectValue = GameManager.Instance.difficulty+1;
    }
}

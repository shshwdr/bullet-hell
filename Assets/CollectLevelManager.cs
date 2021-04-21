using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectLevelManager : LevelManager
{
    protected int currentCollectValue = 0;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        levelName = Dialogs.collectLevelName;
        hud.updateTarget(Dialogs.collectLevelName, string.Format(Dialogs.collectLevelTarget, levelTargetValue, currentCollectValue),
            string.Format(Dialogs.collectLevelIntroduction, levelTargetValue), 2);
    }

    protected virtual void updateTarget()
    {
        hud.updateTargetOnly(string.Format(Dialogs.collectLevelTarget, levelTargetValue, currentCollectValue));
    }
    public void collect()
    {
        currentCollectValue++;
        updateTarget();
        GameManager.Instance.player.collect(currentCollectValue/(float)levelTargetValue);
        if (currentCollectValue>=levelTargetValue)
        {
            succeedLevel();
        }
    }

}

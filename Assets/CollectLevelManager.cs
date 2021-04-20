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
        hud.updateTarget(string.Format(Dialogs.collectLevelTarget, levelTargetValue),
            string.Format(Dialogs.collectLevelIntroduction, levelTargetValue),2);
    }

    public void collect()
    {
        currentCollectValue++;
        GameManager.Instance.player.collect(currentCollectValue/(float)levelTargetValue);
        if (currentCollectValue>=levelTargetValue)
        {
            succeedLevel();
        }
    }

}

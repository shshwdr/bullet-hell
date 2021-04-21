using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killEnemyLevelManager : CollectLevelManager
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        levelName = "Kill Enemy";
        currentCollectValue = 0;
        levelName = Dialogs.shootLevelName;
        hud.updateTarget(Dialogs.shootLevelName, string.Format(Dialogs.shootLevelTarget, levelTargetValue,currentCollectValue),
            string.Format(Dialogs.shootLevelIntroduction, levelTargetValue),4);
    }
    protected override void updateTarget()
    {
        hud.updateTargetOnly(string.Format(Dialogs.shootLevelTarget, levelTargetValue, currentCollectValue));
    }

    //public void kill()
    //{
    //    currentCollectValue++;
    //    if (currentCollectValue >= levelTargetValue)
    //    {
    //        succeedLevel();
    //    }
    //}

    // Update is called once per frame

}

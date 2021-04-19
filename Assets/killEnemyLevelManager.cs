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
        hud.updateTarget(string.Format(Dialogs.shootLevelTarget, currentCollectValue),
            string.Format(Dialogs.shootLevelIntroduction, currentCollectValue));
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

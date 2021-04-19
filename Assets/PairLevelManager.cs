using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PairLevelManager : LevelManager
{
    public override void Start()
    {
        base.Start();
        levelName = Dialogs.fixLevelName;
        hud.updateTarget(string.Format(Dialogs.fixLevelTarget, levelTime),
            string.Format(Dialogs.fixLevelIntroduction, levelTime));
    }
    public void pair()
    {
        succeedLevel();
    }
}

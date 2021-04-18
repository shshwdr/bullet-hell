using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PairLevelManager : LevelManager
{
    public override void Start()
    {
        base.Start();
        levelName = "Pair";
        hud.updateTarget("Pair to another");
    }
    public void pair()
    {
        succeedLevel();
    }
}

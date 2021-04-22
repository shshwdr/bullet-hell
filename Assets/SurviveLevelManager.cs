using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurviveLevelManager : LevelManager
{

    AudioSource audioSource;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        levelName = Dialogs.surviveLevelName;
        hud.updateTarget(Dialogs.surviveLevelName,string.Format(Dialogs.surviveLevelTarget, levelTime),
            string.Format(Dialogs.surviveLevelIntroduction, levelTime),3);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    protected override void timeFinished()
    {
        audioSource.Play();
        succeedLevel();

    }
}

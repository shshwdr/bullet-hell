using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : Singleton<TutorialManager>
{
    public bool isInTutorial = true;
    public List<GameMode> tutorialOrder = new List<GameMode>(){ GameMode.collect, GameMode.killEnemy, GameMode.devour, GameMode.fixWound };
    static List<string> tutorialString = Dialogs.tutorialStrings;
    public int currentTutorialId;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void leftClick()
    {
        if (currentTutorialId ==0)
        {
            HUD.Instance.clearTutorialMessage();
            currentTutorialId++;
        }
        if(currentTutorialId == 1)
        {

        }
        else
        {

            HUD.Instance.clearTutorialMessage();
        }
    }
    public void rightClick()
    {
        if (currentTutorialId == 1)
        {

            HUD.Instance.clearTutorialMessage();
            currentTutorialId++;
        }
    }

    public void finishLevel()
    {
        if (GameManager.Instance.currentLevel is DevourLevelManager && currentTutorialId == 2)
        {

            HUD.Instance.clearTutorialMessage();
            currentTutorialId++;
        }
        else if (GameManager.Instance.currentLevel is PairLevelManager && currentTutorialId == 3)
        {

            HUD.Instance.clearTutorialMessage();
            currentTutorialId++;

            isInTutorial = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

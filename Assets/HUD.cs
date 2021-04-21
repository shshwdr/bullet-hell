using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : Singleton<HUD>
{
    [SerializeField] TMP_Text timeLabel;
    [SerializeField] TMP_Text healthLabel;
    [SerializeField] TMP_Text targetLabel;
    [SerializeField] TMP_Text scoreLabel;
    float levelTime = 10f;
    float currentTime = 0f;
    bool startTime;
    public DSPlayerController player;
    public LevelManager levelManager;

    [SerializeField] TMP_Text tutorialLabel;

    //for new level

    [SerializeField] TMP_Text intervalAfterTitle;
    [SerializeField] TMP_Text intervalAfterLabel;
    [SerializeField] TMP_Text intervalAfterLabelObstacle;
    [SerializeField] Image levelIcon;
    [SerializeField] List<Sprite> levelIcons;

    //for level finish

    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject lossMenu;
    [SerializeField] TMP_Text intervalLabel;
    [SerializeField] TMP_Text difficultyLabel;

    int currentPunch = 5;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void StartLevelMove()
    {
        startTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime)
        {
            updateTimer(levelManager.currentTime);
        }
    }


    public void updateTimer(float currentTime)
    {
        if (timeLabel)
        {
            timeLabel.text = "Timer: " + currentTime.ToString("F2");
            //if(currentTime<= currentPunch && currentPunch>=0.5f)
            //{

            //    timeLabel.transform.DOPunchScale(new Vector3(0.4f, 0.2f, 0.2f),0.2f).SetUpdate(true);
            //    currentPunch -= 1;
            //}

        }
        else
        {
            //Debug.Log("Timer: " + currentTime);
        }
    }

    public void updateHealth(int currentTime)
    {
        if (healthLabel)
        {
            healthLabel.text = "Health: " + currentTime;
            healthLabel.transform.DOPunchScale(new Vector3(0.5f, 0.2f, 0.2f), 0.2f).SetUpdate(true);

        }
        else
        {
            //Debug.Log("Timer: " + currentTime);
        }
    }


    public void updateScore(float currentTime)
    {
        if (scoreLabel)
        {
            scoreLabel.text = "Score: " + currentTime;

            scoreLabel.transform.DOPunchScale(new Vector3(0.5f, 0.2f, 0.2f), 0.2f).SetUpdate(true);
        }
        else
        {
            //Debug.Log("Timer: " + currentTime);
        }
    }

    public void updateTargetOnly(string target)
    {
        if (targetLabel)
        {
            targetLabel.text = target;
        }
    }

    public void updateTarget(string title, string target, string introduction, int spriteId)
    {
        if (targetLabel)
        {
            targetLabel.text = target;
            intervalAfterTitle.text = title;
            intervalAfterLabel.text = introduction;
            levelIcon.sprite = levelIcons[spriteId];

        }
        else
        {
            //Debug.Log("Timer: " + currentTime);
        }
    }

    public void updateObstacleLabel(string obstacle)
    {
        if (intervalAfterLabelObstacle)
        {
            intervalAfterLabelObstacle.text = obstacle;

        }
        else
        {
            //Debug.Log("Timer: " + currentTime);
        }
    }

    public void updateIntervalLevel()
    {
        //if (intervalLabel)
        //{
        //    if (GameManager.Instance.success)
        //    {

        //        intervalLabel.text = "You SUCCEED in " + levelManager.levelName + " level";
        //    }
        //    else
        //    {
        //        intervalLabel.text = "You FAILED in " + levelManager.levelName + " level";

        //    }
        //}


    }


    public void updateDifficulty()
    {
        if (difficultyLabel)
        {

            difficultyLabel.text = Dialogs.difficultyIncrease;
            
        }
    }

    public void resetDifficulty()
    {
        if (difficultyLabel)
        {

            difficultyLabel.text = "";

        }
    }


    public void setHpRemaining(int hp)
    {
        if (difficultyLabel)
        {

            difficultyLabel.text = string.Format( Dialogs.remainHP, hp);

        }
    }

    public void winLoss(bool isWin)
    {
        currentPunch = 5;
        if (!winMenu)
        {
            return;
        }
        winMenu.SetActive(false);

        lossMenu.SetActive(false);
        if (isWin)
        {
            winMenu.SetActive(true);
            intervalLabel.text = Dialogs.succeed;
        }
        else
        {
            lossMenu.SetActive(true);
            intervalLabel.text = Dialogs.failed;
        }
    }

    public void clearTutorialMessage()
    {
        if (tutorialLabel)
        {

            tutorialLabel.text = "";

        }
    }
    public void showTutorialMessage()
    {
        if (tutorialLabel)
        {
            if (TutorialManager.Instance.isInTutorial)
            {

                tutorialLabel.text = Dialogs.tutorialStrings[TutorialManager.Instance.currentTutorialId];
            }


        }
    }
}

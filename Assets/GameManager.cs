using Doozy.Engine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameMode { survive };//,collect,killEnemy, mirror}
public class GameManager : Singleton<GameManager>
{

    public int playerHealth;
    public int currentPlayerHealth;
    public float score;
    public GameMode gameMode;
    public DSPlayerController player;
    public LevelManager currentLevel;
    public bool success;
    public bool finishedLevel;
    public LeaderBoard leaderBoard;

    int successedLevel = 0;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);   
    }


    public void RestartLevel()
    {
        player.restart();
    }

    public void FinishInvertal()
    {
        SelectLevelAndStart();
    }


    private void OnDestroy()
    {
        Debug.Log("destory");
    }

    public void StartGame()
    {
        currentPlayerHealth = playerHealth;
        score = 0;
        successedLevel = 0;
        SelectLevelAndStart();
        finishedLevel = true;
        HUD.Instance.updateHealth(currentPlayerHealth);
        HUD.Instance.updateScore(score);
    }

    public void SelectLevelAndStart()
    {

        //if (gameMode == GameMode.survive)
        {

            //gameMode = GameMode.killEnemy;
        }
        //else
        {

           // gameMode = GameMode.collect;
        }
        if (CheatManager.Instance.turnedOnCheat && CheatManager.Instance.nextLevel > 0)
        {

            // SceneManager.LoadScene(CheatManager.Instance.nextLevel);

            SceneManager.LoadScene(CheatManager.Instance.nextLevel);
            //StartCoroutine(test(CheatManager.Instance.nextLevel));
        }
        else
        {
            int rand = UnityEngine.Random.Range(1, Enum.GetValues(typeof(GameMode)).Length+1);
            //SceneManager.LoadScene(rand);
            //SceneManager.LoadScene((int)gameMode + 1);
            //StartCoroutine(test(rand)); 
            SceneManager.LoadScene(rand);
        }

        //finishedInterval();
        GameEventMessage.SendEvent("LevelStart");
    }

    //IEnumerator test(int level)
    //{
    //    yield return new WaitForSecondsRealtime(0.1f);
    //    SceneManager.LoadScene(level);
    //    GameEventMessage.SendEvent("LevelStart");
    //}

    public void finishedInterval()
    {
        finishedLevel = false;
    }


    public void StartLevelMove()
    {
        HUD.Instance.StartLevelMove();
    }

    public void SucceedLevel()
    {
        if (finishedLevel)
        {
            return;
        }
        successedLevel++;
        score += 1;
        HUD.Instance.updateScore(score);
        GameEventMessage.SendEvent("finishLevel");

        success = true;
        //SelectLevelAndStart();
        finishLevel();
    }

    public void FailedLevel()
    {
        if (finishedLevel)
        {
            return;
        }
        currentPlayerHealth -= 1;
        HUD.Instance.updateHealth(currentPlayerHealth);

        success = false;
        if (currentPlayerHealth == 0)
        {
            Debug.Log("gameover");
            leaderBoard.fetchScore();
            GameEventMessage.SendEvent("gameover");
        }
        else
        {

            GameEventMessage.SendEvent("finishLevel");
            //SelectLevelAndStart();
        }
        finishLevel();
    }


    public virtual void finishLevel()
    {
        //yield some time
        finishedLevel = true;
        BulletHell.ProjectileManager.Instance.ClearEmitters();
        HUD.Instance.updateIntervalLevel();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

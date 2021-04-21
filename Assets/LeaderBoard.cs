using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderBoard : Singleton<LeaderBoard>
{
    //http://dreamlo.com/lb/FypLq87WY0CBxXK7les98QbtaRJWGT5Uq_9fUJoB_pbQ
    [SerializeField] Transform leaderboardList;
    [SerializeField] GameObject leaderboardRow;
    [SerializeField] TMP_InputField inputName;
    [SerializeField] TMP_Text score;

    public GameObject submitButton;

    //dreamloLeaderBoard dl;
    // Start is called before the first frame update
    void Start()
    {
        //dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();

        //fetchScore();
        LB_Controller.OnUpdatedScores += OnLeaderboardUpdated;
        LB_Controller.instance.ReloadLeaderboard();

    }

    
    private void OnDestroy()
    {
        LB_Controller.OnUpdatedScores -= OnLeaderboardUpdated;
    }



    string playerName = "";

    public void submitName()
    {
        playerName = inputName.text;

        //if (dl.publicCode == "") Debug.LogError("You forgot to set the publicCode variable");
        //if (dl.privateCode == "") Debug.LogError("You forgot to set the privateCode variable");
        if(playerName == "")
        {
            return;
        }
        if(GameManager.Instance.score == 0)
        {
            return;
        }
        submitButton.SetActive(false);
        LB_Controller.instance.StoreScore((int)GameManager.Instance.score * 10, playerName);
        //LB_Controller.instance.ReloadLeaderboard();
        //dl.AddScore(playerName, (int)GameManager.Instance.score*10);
    }

    public void showButton()
    {
        submitButton.SetActive(true);
    }

    public void fetchScore()
    {
        if (score)
        {
            score.text = string.Format("Congratualtion, you helped the human to survive {0} seconds! May he live longer!", 10 * GameManager.Instance.score);

        }
        LB_Controller.instance.ReloadLeaderboard();
        //    //if (!dl)
        //    //{

        //    //    dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();
        //    //}
        //    //dl.GetScores();
        }

        private void OnLeaderboardUpdated(LB_Entry[] entries)
    {
        foreach (LB_Entry entry in entries)
        {
            // here you can fill your List on your UI
           // Debug.Log("Rank: " + entry.rank + "; Name: " + entry.name + "; Points: " + entry.points);
        }

        foreach (Transform child in leaderboardList)
        {
            child.gameObject.SetActive(false);
            // GameObject.Destroy(child.gameObject);
        }
        int maxToDisplay = leaderboardList.childCount;
        int count = 0;
        foreach (LB_Entry entry in entries)
        {
            var row = leaderboardList.GetChild(count).gameObject;
            row.SetActive(true);
            row.GetComponent<LeaderBoardRow>().score.text = entry.points.ToString();
            row.GetComponent<LeaderBoardRow>().Name.text = entry.name;


            count++;
            //GUILayout.BeginHorizontal();
            //GUILayout.Label(currentScore.playerName, width200);
            //GUILayout.Label(currentScore.score.ToString(), width200);
            //GUILayout.EndHorizontal();

            if (count >= maxToDisplay) break;
        }
    }

    //public void updateLeaderBoardList()
    //{
    //    List<dreamloLeaderBoard.Score> scoreList = dl.ToListHighToLow();
    //    if (scoreList == null)
    //    {
    //        //GUILayout.Label("(loading...)");
    //    }
    //    else
    //    {
    //        foreach (Transform child in leaderboardList)
    //        {
    //            child.gameObject.SetActive(false);
    //           // GameObject.Destroy(child.gameObject);
    //        }
    //        int maxToDisplay = leaderboardList.childCount;
    //        int count = 0;
    //        foreach (dreamloLeaderBoard.Score currentScore in scoreList)
    //        {
    //            var row = leaderboardList.GetChild(count).gameObject;
    //            row.SetActive(true);
    //            row.GetComponent<LeaderBoardRow>().score.text = currentScore.score.ToString();
    //            row.GetComponent<LeaderBoardRow>().Name.text = currentScore.playerName;


    //            count++;
    //            //GUILayout.BeginHorizontal();
    //            //GUILayout.Label(currentScore.playerName, width200);
    //            //GUILayout.Label(currentScore.score.ToString(), width200);
    //            //GUILayout.EndHorizontal();

    //            if (count >= maxToDisplay) break;
    //        }
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}

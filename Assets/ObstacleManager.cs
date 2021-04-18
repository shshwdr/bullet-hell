using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    List<string> obstacleIntroduce = new List<string>()
    {
        "",
        "Take care! Blood blobs will fly around!",
        "Take care! Cholesterol will slow down the cell!",
        "Take care! Alcohol will make your move not accurate!",
    };
    public List<GameObject> obstacles;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            //if (i == rand)
            {
                obstacles[i].SetActive(false);
            }
        }
        if (CheatManager.Instance.turnedOnObstacle|| GameManager.Instance.havePlayedLevel())
        {
            int rand = UnityEngine.Random.Range(0, obstacles.Count);
            if (CheatManager.Instance.obstacleValue >= 0)
            {
                rand = CheatManager.Instance.obstacleValue;
            }
            HUD.Instance.updateObstacleLabel(obstacleIntroduce[rand]);
            for(int i = 0;i< obstacles.Count; i++)
            {
                if (i == rand)
                {
                    obstacles[i].SetActive(true);
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

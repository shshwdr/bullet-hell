using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatManager : Singleton<CheatManager>
{
    public bool turnedOnCheat = true;
    public int nextLevel = -1;
    public bool infiniteHP = false;
    public bool infiniteHPInLevel = false;
    public bool turnedOnObstacle = false;
    public int obstacleValue = -1;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 1; i < 10; ++i)
        {
            if (Input.GetKeyDown("" + i))
            {
                nextLevel = i;
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameManager.Instance.currentPlayerHealth += 1;
            HUD.Instance.updateHealth(GameManager.Instance.currentPlayerHealth);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            infiniteHPInLevel = true;
        }
    }
}

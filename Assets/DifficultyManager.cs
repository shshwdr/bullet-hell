using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] List<GameObject> difficultySet;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject go in difficultySet)
        {
            go.SetActive(false);
        }
        if (CheatManager.Instance.difficulty >= 0)
        {

            setDiffculty(CheatManager.Instance.difficulty);
        }
        else
        {
            setDiffculty(GameManager.Instance.difficulty);
        }
    }

    public void setDiffculty(int i)
    {
        i = Mathf.Min(i, difficultySet.Count-1);
        for(int j = 0; j <= i; j++)
        {

            difficultySet[j].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

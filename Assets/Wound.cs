using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wound : MonoBehaviour
{

    int needed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GameManager.Instance.currentLevel is PairLevelManager)
        {
            needed--;
            //((PairLevelManager)GameManager.Instance.currentLevel).pair();
        }
        if(needed == 0)
        {
            ((PairLevelManager)GameManager.Instance.currentLevel).pair();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GameManager.Instance.currentLevel is PairLevelManager)
        {
            needed++;
            //((PairLevelManager)GameManager.Instance.currentLevel).pair();
        }
    }
}

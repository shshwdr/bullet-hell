using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wound : MonoBehaviour
{
    [SerializeField] SpriteRenderer renderer;
    [SerializeField] GameObject deathAnim;


    AudioSource audioSource;

    int needed = 2;
    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
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

            renderer.enabled = false;
            deathAnim.SetActive(true);
            audioSource.Play();
           // deathAnim.transform.position = renderer.gameObject.transform.position;
            //deathAnim.transform.rotation = renderer.transform.rotation;
            //deathAnim.transform.localScale = renderer.transform.localScale;
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

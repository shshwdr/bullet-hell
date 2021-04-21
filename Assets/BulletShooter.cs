using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    AudioSource audioSource;
    DevourLevelManager manager;
    [SerializeField] GameObject live;
    [SerializeField] GameObject deathAnim;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<DevourLevelManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && manager)
        {
            manager.collect();
            GetComponent<BulletFury.BulletManager>().isStopped = true;
            GetComponent<BulletFury.BulletManager>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
            audioSource.Play();

            live.SetActive(false);
            deathAnim.SetActive(true);
            deathAnim.transform.position = live.gameObject.transform.position;
            deathAnim.transform.rotation = live.transform.rotation;
            deathAnim.transform.localScale = live.transform.localScale;


        }
    }
}

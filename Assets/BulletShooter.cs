using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    DevourLevelManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<DevourLevelManager>();
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
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}

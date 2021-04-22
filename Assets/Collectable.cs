using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    float currentTime;
    Vector3 pos;
    [SerializeField] float moveSpeed = 1;
    [SerializeField] float frequency = 1;
    [SerializeField] float magnitude = 1;
    [SerializeField] bool shouldDestory = true;
    bool hasTriggered = false;

    AudioSource audioSource;

    [SerializeField] SpriteRenderer renderer;
    [SerializeField] GameObject deathAnim;

    int dir = 1;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentTime = 0;
        pos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime += Time.deltaTime* dir;
        //if (currentTime <= 0)
        {
            //start Moving
            pos += transform.right * Time.deltaTime * moveSpeed * dir;
            rb.MovePosition(pos - transform.up * Mathf.Sin((currentTime) * frequency) * magnitude);
            if (currentTime >= 3.14f)
            {
                dir = -dir;
                currentTime = 3.14f;
            }
            if (currentTime <=0)
            {
                dir = -dir;
                currentTime = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !hasTriggered)
        {
            hasTriggered = true;
            CollectionGeneration.Instance.generate();
            CollectionGeneration.Instance.collect();
            if (shouldDestory)
            {

                GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {

                if (deathAnim)
                {
                    renderer.enabled = false;
                    deathAnim.SetActive(true);
                    deathAnim.transform.position = renderer.gameObject.transform.position;
                    deathAnim.transform.rotation = renderer.transform.rotation;
                    deathAnim.transform.localScale = renderer.transform.localScale;
                }

                GetComponent<SpriteRenderer>().color = Color.white;
                this.enabled = false;


            }
            if (audioSource)
            {
                audioSource.Play();
            }
        }
    }


}

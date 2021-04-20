using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    float currentTime;
    Vector3 pos;
    [SerializeField] float moveSpeed = 1;
    [SerializeField] float frequency = 1;
    [SerializeField] float magnitude = 1;
    [SerializeField] bool shouldDestory = true;
    bool hasTriggered = false;


    int dir = 1;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        pos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime += Time.deltaTime * dir;
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
            if (currentTime <= 0)
            {
                dir = -dir;
                currentTime = 0;
            }
        }
    }



}

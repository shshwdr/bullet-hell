using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TendrilChild : MonoBehaviour
{
    float currentTime;
    float moveSpeed = 0.3f;
    float frequency = 0.3f;
    float magnitude = 0.3f;
    Rigidbody2D rb;
    Vector3 pos;
    float startTime;
    bool isRight;
    public void init(float time, float m, float f, float ma,bool r)
    {
        currentTime = time;
        moveSpeed = m;
        frequency = f;
        magnitude = ma;
        startTime = Time.time + currentTime;
        isRight = r;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            //start Moving
            pos += transform.right * Time.deltaTime * moveSpeed * (isRight?1:-1);
            rb.MovePosition(pos+ transform.up*Mathf.Sin((Time.time- startTime )* frequency)*magnitude);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DSPlayerController>())
        {
            collision.GetComponent<DSPlayerController>().getDamage(1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingRock : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector3 dir;
    [SerializeField]float  speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    void FixedUpdate()
    {
        //Store user input as a movement vector

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        rb.MovePosition(transform.position + dir * Time.deltaTime * speed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Transform target;
    [SerializeField] float speed;
    Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 diff = target.position - lastPosition;
        transform.Translate(diff * speed);
        lastPosition = target.transform.position;
    }
}

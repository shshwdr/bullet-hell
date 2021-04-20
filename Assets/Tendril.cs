using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tendril : MonoBehaviour
{
    [SerializeField] GameObject childPrefab;
    public int childNumber;
    [SerializeField] float waitTime = 0.3f;
    [SerializeField] float moveSpeed = 0.3f;
    [SerializeField] float frequency = 0.3f;
    [SerializeField] float magnitude = 0.3f;
    [SerializeField] bool isRight = true;
    float scale;
    public void init(int c, float s, bool r)
    {
        childNumber = c;
        scale = s;
        isRight = r;
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < childNumber; i++)
        {
            GameObject child = Instantiate(childPrefab, transform.position, transform.rotation,transform);
            child.GetComponent<TendrilChild>().init(i* waitTime/ scale, moveSpeed * scale, frequency * scale, magnitude * scale, isRight);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TendrilGeneration : MonoBehaviour
{
    [SerializeField] Transform upRight;
    [SerializeField] Transform bottomLeft;

    [SerializeField] GameObject childPrefab;

    [SerializeField] float generationTime = 1.5f;
    float currentTime = 0f;

    [SerializeField] int minCount = 4;
    [SerializeField] int maxCount = 9;
    [SerializeField] float minScale = 0.8f;
    [SerializeField] float maxScale = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = generationTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= generationTime)
        {
            currentTime = 0;
            bool isRight = (Random.Range(0, 2) == 0);
            Vector3 pos = new Vector3((isRight ? bottomLeft.position.x : upRight.position.x), Random.Range(bottomLeft.position.y, upRight.position.y), 0);
            GameObject go = Instantiate(childPrefab, pos, Quaternion.identity,transform);
            go.GetComponent<Tendril>().init(Random.Range(minCount, maxCount), Random.Range(minScale, maxScale), isRight);
        }
    }
}

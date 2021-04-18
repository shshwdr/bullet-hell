using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyRockGenerator : MonoBehaviour
{
    [SerializeField] GameObject rockPrefab;
    [SerializeField] Transform startTransforms;
    [SerializeField] Transform endTransforms;

    [SerializeField] float generateTime = 2f;
    float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = generateTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= generateTime)
        {
            currentTime = 0;
            int startPositionId = Random.Range(0, startTransforms.childCount);
            int endPositionId = Random.Range(0, endTransforms.childCount);
            Vector3 startPosition = startTransforms.GetChild(startPositionId).position;
            Vector3 endPosition = endTransforms.GetChild(endPositionId).position;
            var rand = Random.Range(0, 2);
            if(rand == 1)
            {
                var t = startPosition;
                startPosition = endPosition;
                endPosition = t;

            }

            GameObject ob = Instantiate(rockPrefab, startPosition, rockPrefab.transform.rotation);
            FlyingRock fr = ob.GetComponent<FlyingRock>();
            fr.dir = (endPosition - startPosition).normalized;
            

        }
    }
}

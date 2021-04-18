using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionGeneration : Singleton<CollectionGeneration>
{
    [SerializeField] GameObject collectionItem;
    CollectLevelManager levelManager;
    [SerializeField] Transform topRight;
    [SerializeField] Transform bottomLeft;
    [SerializeField] float playerDistance = 1;
    // Start is called before the first frame update
    void Start()
    {
        generate();
        levelManager = GameObject.FindObjectOfType<CollectLevelManager>();
        if (!levelManager)
        {
            Debug.LogError("collect level manager does not exist");
        }
    }

    public void generate()
    {
        Vector3 position = new Vector3(Random.Range(bottomLeft.position.x, topRight.position.x), Random.Range(bottomLeft.position.y, topRight.position.y), 0);
        //if position too close to player, retry
        while((position - GameManager.Instance.player.transform.position).magnitude <= playerDistance)
        {
            position = new Vector3(Random.Range(bottomLeft.position.x, topRight.position.x), Random.Range(bottomLeft.position.y, topRight.position.y), 0);
        }
        GameObject collection = Instantiate(collectionItem, position, Quaternion.identity);
    }
    public void collect()
    {
        if (levelManager)
        {
            levelManager.collect();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

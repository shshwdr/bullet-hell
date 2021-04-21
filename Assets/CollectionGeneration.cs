using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionGeneration : Singleton<CollectionGeneration>
{
    [SerializeField] GameObject collectionItem;
    CollectLevelManager levelManager;
    [SerializeField] Transform topRight;
    [SerializeField] Transform bottomLeft;
     float playerDistance = 5;
    [SerializeField] int generateNumber = -1;
    // Start is called before the first frame update
    void Start()
    {
        if(generateNumber == -1)
        {

            generate();
            generate();
        }
        else
        {

            generateMulti();
        }
        levelManager = GameObject.FindObjectOfType<CollectLevelManager>();
        if (!levelManager)
        {
            Debug.LogError("collect level manager does not exist");
        }
    }
    bool isValidPosition(Vector3 position, List<Vector3> positions)
    {
        if((position - GameManager.Instance.player.transform.position).magnitude <= playerDistance)
        {
            return false;
        }

        foreach(BulletFury.BulletManager m in GameManager.Instance.player.GetComponent<BulletFury.BulletCollider>().hitByBullets)
        {
            if ((position - m.transform.position).magnitude <= playerDistance)
            {
                return false;
            }
        }

        foreach(Vector3 newp in positions)
        {
            if((position - newp).magnitude <= playerDistance)
            {
                return false;
            }
        }
        return true;
    }
    public void generateMulti()
    {
        List<Vector3> positions = new List<Vector3>();
        for(int i = 0;i< generateNumber; i++)
        {
            Vector3 position = new Vector3(Random.Range(bottomLeft.position.x, topRight.position.x), Random.Range(bottomLeft.position.y, topRight.position.y), 0);
            int loopTime = 100;
            //if position too close to player, retry
            while (!isValidPosition(position, positions) && loopTime>=0)
            {
                position = new Vector3(Random.Range(bottomLeft.position.x, topRight.position.x), Random.Range(bottomLeft.position.y, topRight.position.y), 0);
                loopTime--;
            }
            positions.Add(position);
            GameObject collection = Instantiate(collectionItem, position, Quaternion.identity);
        }
    }
    public void generate()
    {
        if (generateNumber != -1)
        {
            return;
        }
            Vector3 position = new Vector3(Random.Range(bottomLeft.position.x, topRight.position.x), Random.Range(bottomLeft.position.y, topRight.position.y), 0);
        //if position too close to player, retry
        while (!isValidPosition(position,new List<Vector3>()))
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

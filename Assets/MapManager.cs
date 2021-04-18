using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{

    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform playerSpawnPositions;
    [SerializeField] Transform bulletManagers;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] ParallaxEffect parallax;
    // Start is called before the first frame update
    void Awake()
    {
        var rand = Random.Range(0,playerSpawnPositions.childCount);
        GameObject player =  Instantiate(playerPrefab, playerSpawnPositions.GetChild(rand).transform.position, Quaternion.identity);
        foreach(Transform trans in bulletManagers)
        {
            BulletFury.BulletManager bulletManager = trans.GetComponent<BulletFury.BulletManager>();
            if (bulletManager)
            {

                player.GetComponent<BulletFury.BulletCollider>().AddManagerToBullets(bulletManager);
            }
        }
        virtualCamera.Follow = player.transform;
        parallax.target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

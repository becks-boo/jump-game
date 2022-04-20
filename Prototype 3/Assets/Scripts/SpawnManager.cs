using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject paperPrefab;
    private Vector3 spawnPos = new Vector3(30, 0, 0);
    private Vector3 paperSpawnPos = new Vector3(16, 1, 0);
    private float paperSpawnRangeY;
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        InvokeRepeating("SpawnPaper", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false) 
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }

    void SpawnPaper()
    {
        if (playerControllerScript.gameOver == false) 
        {
            paperSpawnPos = new Vector3(16, Random.Range(1, 10), 0);
            Instantiate(paperPrefab, paperSpawnPos, paperPrefab.transform.rotation);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    float spawnRangeZ = 33;
    float spawnRangeYMax = 60f;
    float spawnRangeYMin = 31f;
    float spawnRangeX = 1.8f;
    [SerializeField] GameObject spherePrefab;
    [SerializeField] GameObject bigSpherePrefab;
    [SerializeField] GameObject MegaSpherePrefab;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject box;
    float spawnDelay = 4.5f;
    float spawnInterval;

    void Start()
    {
        gameManager.GetComponent<GameManager>();

        // Spawn Sphere
        InvokeRepeating("SpawnSphere", spawnDelay, SpawnInterval());

        // Spawn Sphere In Player
        InvokeRepeating("SpawnSphereEasy", spawnDelay, 0.65f);

        // Spawn  Big Sphere
        InvokeRepeating("SpawnBigSphere", 60f, 3f);

        // Spawn Mega Sphere
        InvokeRepeating("SpawnMegaSphere", 120f, 7.5f);
        
    }

    float SpawnInterval()
    {
        spawnInterval = Random.Range(0.2f, 0.3f);
        return spawnInterval;
    }


    // NORMAL SPAWN
    void SpawnSphere()
    {
        if (gameManager.gameIsOn)
        {
            Instantiate(spherePrefab, GenerateRandomPosition(), spherePrefab.transform.rotation);
        }
    }
    Vector3 GenerateRandomPosition()
    {
        float spawnPosX = Random.Range(spawnRangeX, -spawnRangeX);
        float spawnPosY = Random.Range(spawnRangeYMin, spawnRangeYMax);
        float spawnPosZ = Random.Range(spawnRangeZ, -spawnRangeZ);

        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
        return spawnPos;
    }


    // EASY SPAWN
    void SpawnSphereEasy()
    {
        if (gameManager.gameIsOn)
        {
            Instantiate(spherePrefab, GenerateRandomPositionEasy(), spherePrefab.transform.rotation);
        }
    }
    Vector3 GenerateRandomPositionEasy()
    {
        float spawnPosX = Random.Range(spawnRangeX, -spawnRangeX);
        float spawnPosY = Random.Range(spawnRangeYMin, spawnRangeYMax);
        float spawnPosZ = box.transform.position.z + Random.Range(2f, -2f);

        Vector3 spawnPosEasy = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
        return spawnPosEasy;
    }


    // HARD SPAWN
    void SpawnBigSphere()
    {
        if (gameManager.gameIsOn)
        {
            Instantiate(bigSpherePrefab, GenerateRandomPosition(), spherePrefab.transform.rotation);
        }
    }


    // VERY HARD SPAWN
    void SpawnMegaSphere()
    {
        if (gameManager.gameIsOn)
        {
            Instantiate(MegaSpherePrefab, GenerateRandomPosition(), spherePrefab.transform.rotation);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerUp;

    private float zEnemySpawn = 18.0f;
    private float xEnemyRange = 40.0f;
    private float zPowerupRange = 10.0f;
    private float xPowerupRange = 35.0f;
    private float ySpawn = 0.75f;

    private float startDelay = 2.5f;
    private float enemySpawnTime = 3.5f;
    private float powerupSpawnTime = 15.0f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
    }


    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-xEnemyRange, xEnemyRange);

        int randomEnemy = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);

        Instantiate(enemies[randomEnemy], spawnPos, enemies[randomEnemy].gameObject.transform.rotation);
    }

    void SpawnPowerup()
    {
        float randomX = Random.Range(-xPowerupRange, xPowerupRange);
        float randomZ = Random.Range(-zPowerupRange, zPowerupRange);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, randomZ);

        Instantiate(powerUp, spawnPos, powerUp.transform.rotation);
    }
}

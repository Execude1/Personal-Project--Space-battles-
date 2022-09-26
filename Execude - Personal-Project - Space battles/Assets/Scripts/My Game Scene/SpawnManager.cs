using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemiesStandard;
    public List<GameObject> powerUps;
    public GameObject[] enemiesWave;

    private PlayerController playerControllerScript;

    private float zEnemySpawn = 45.0f;
    private float xEnemyRange = 25.0f;
    private float zPowerup = 41.0f;
    private float xPowerupRange = 30.0f;
    private float ySpawn = 2f;

    private float startDelay = 2.5f;
    private float enemySpawnTime = 3.5f;
    private float powerupSpawnTime = 15.0f;

    private bool isGameActive = true;
    private bool isBossWave = false;
    public int numWave = 1;

    void Start()
    {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        InvokeRepeating("SpawnEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
        StartCoroutine(EnemyWave());
    }

    void Update()
    {     
            
    }

    void SpawnEnemy()
    {
        int randomEnemy = Random.Range(0, enemiesStandard.Length);
        Instantiate(enemiesStandard[randomEnemy], RandomEnemyPosition(), enemiesStandard[randomEnemy].gameObject.transform.rotation);

        if (playerControllerScript.delayFire <= 0.2 && powerUps.Count == 3)
        {
            powerUps.RemoveAt(powerUps.Count - 1);
        }
    }

    IEnumerator EnemyWave()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(10);

            numWave += 1;

            if (numWave == 3)
                Instantiate(enemiesWave[0], RandomEnemyPosition(), Quaternion.identity);
            if (numWave == 5)
                Instantiate(enemiesWave[1], RandomEnemyPosition(), Quaternion.identity);
            if (numWave == 8)
                Instantiate(enemiesWave[2], RandomEnemyPosition(), Quaternion.identity);
            if (numWave == 10)
                Instantiate(enemiesWave[3], RandomEnemyPosition(), Quaternion.identity);
            if (numWave == 12)
                Instantiate(enemiesWave[4], RandomEnemyPosition(), Quaternion.identity);
            if (numWave == 15)
                Instantiate(enemiesWave[5], RandomEnemyPosition(), Quaternion.identity);
            if (numWave == 18)
                Instantiate(enemiesWave[6], RandomEnemyPosition(), Quaternion.identity);
            if(numWave == 20)
            {
                isBossWave = true;
                Instantiate(enemiesWave[7], enemiesWave[7].transform.position, Quaternion.identity);
            }
        }    
    }

    Vector3 RandomEnemyPosition()
    {
        float randomX = Random.Range(-xEnemyRange, xEnemyRange);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);

        return spawnPos;
    }

    void SpawnPowerup()
    {
        int randomPowerUp = Random.Range(0, powerUps.Count);
        float randomX = Random.Range(-xPowerupRange, xPowerupRange);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, zPowerup);

        Instantiate(powerUps[randomPowerUp], spawnPos, powerUps[randomPowerUp].transform.rotation);
    }
}

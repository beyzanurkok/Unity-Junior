using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerupPrefab;
    private float zEnemySpawn = 20.0f;
    private float xSpawnRange=14.0f;
    private float zPowerupSpawnRange=14.0f;
    private float startDelay = 1.0f;
    private float enemySpawnTime = 1.0f;
    private float powerupSpawnTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnRandomPowerup", startDelay, powerupSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void SpawnRandomEnemy()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, 0.75f, zEnemySpawn);

        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    }
    private void SpawnRandomPowerup()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(-zPowerupSpawnRange, zPowerupSpawnRange);

        Vector3 spawnPos = new Vector3(randomX,0.75f,randomZ);

        Instantiate(powerupPrefab, spawnPos, powerupPrefab.transform.rotation);
    }
}

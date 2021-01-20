using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;
    private int waveNumber = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnpowerupWave();
    }

  

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;             // Finds the enemy number

        if (enemyCount==0)                                          // If there are no enemies on the platform
        {
            waveNumber++;                                           //increase parameter
            SpawnpowerupWave();                                     // create a powerup
            SpawnEnemyWave(waveNumber);                             //  create enemies as many parameters

        }
   
    }
    private void SpawnpowerupWave()                                 // Method of creating enemies
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    private void SpawnEnemyWave(int enemiesToSpawn)                 //method of creating powerup
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    private Vector3 GenerateSpawnPosition()                         
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }



 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    int enemyCount;
    int wave = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void SpawnNewWave()
    {
        for (int i = 0; i < wave; i++)
        {
            Instantiate(enemyPrefab, generateSpawnPosition(), enemyPrefab.transform.rotation);
        }
        Instantiate(powerupPrefab, generateSpawnPosition(), enemyPrefab.transform.rotation);
        wave++;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0)
        {
            SpawnNewWave();
        }
    }

    private Vector3 generateSpawnPosition()
    {
        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPositionX, 0, spawnPositionZ);
        return randomPos;
    }
}

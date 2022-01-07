using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    float spawnRangePos = 9;
    float spawnRangeNeg = -9;
    float randoSpawnX;
    float randoSpawnZ;

    int spawns;
    public int enemyCount;
    public int waveNumb = 1;

    Vector3 randomPosition;

    //game object
    public GameObject enemyPrefab;
    public GameObject powerUp;


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumb);
        Instantiate(powerUp, generateSpawn(), powerUp.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0)
        {
            waveNumb++;
            SpawnEnemyWave(waveNumb);
            Instantiate(powerUp, generateSpawn(), powerUp.transform.rotation);
        }
    }

    Vector3 generateSpawn()
    {
        randoSpawnX = Random.Range(spawnRangeNeg,spawnRangePos);
        randoSpawnZ = Random.Range(spawnRangeNeg,spawnRangePos);

        randomPosition = new Vector3(randoSpawnX, 0, randoSpawnZ);
        return randomPosition;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (spawns = 0; spawns < enemiesToSpawn; spawns++)
        {
            Instantiate(enemyPrefab, generateSpawn(), enemyPrefab.transform.rotation);
        }
    }





}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    float spawnRangePos = 9;
    float spawnRangeNeg = -9;
    float randoSpawnX;
    float randoSpawnZ;
    Vector3 randomPosition;

    //game object
    public GameObject enemyPrefab;


    // Start is called before the first frame update
    void Start()
    {
        

        Instantiate(enemyPrefab, generateSpawn(), enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 generateSpawn()
    {
        randoSpawnX = Random.Range(spawnRangeNeg,spawnRangePos);
        randoSpawnZ = Random.Range(spawnRangeNeg,spawnRangePos);

        randomPosition = new Vector3(randoSpawnX, 0, randoSpawnZ);
        return randomPosition;
    }






}

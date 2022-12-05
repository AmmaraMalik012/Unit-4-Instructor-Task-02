using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    public int spawnPos = 8;
    public GameObject objectToSpawn;
    public float spawnInterval = 2.5f;
    private float startDelay = 2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
    }

    void SpawnRandomEnemy()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnPos, spawnPos), 0f, Random.Range(-spawnPos, spawnPos));
        Instantiate(objectToSpawn, spawnPosition, objectToSpawn.transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject Target;
    [SerializeField] Vector3 spawnAreaCenter; // Center of the spawn area
    [SerializeField] Vector3 spawnAreaSize;   // Size of the spawn area
    [SerializeField] float spawnInterval = 2f; // Time interval between spawns in seconds

    void Start()
    {
        // Start spawning the prefab objects at intervals
        InvokeRepeating("SpawnPrefab", 0f, spawnInterval);
    }

    void SpawnPrefab()
    {
        // Calculate a random position within the specified spawn area
        Vector3 randomSpawnPosition = new Vector3(
            Random.Range(spawnAreaCenter.x - spawnAreaSize.x / 2, spawnAreaCenter.x + spawnAreaSize.x / 2),
            Random.Range(spawnAreaCenter.y - spawnAreaSize.y / 2, spawnAreaCenter.y + spawnAreaSize.y / 2),
            Random.Range(spawnAreaCenter.z - spawnAreaSize.z / 2, spawnAreaCenter.z + spawnAreaSize.z / 2)
        );

        // Instantiate the prefab at the random position
        Instantiate(Target, randomSpawnPosition, Quaternion.identity);
    }
}

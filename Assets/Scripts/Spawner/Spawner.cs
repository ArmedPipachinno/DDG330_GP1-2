using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    //[SerializeField] private GameObject Target;
    [SerializeField] private int SpawnAmt = 10;
    [SerializeField] private Vector3 SpawnAreaCenter; // Center of the spawn area
    [SerializeField] private Vector3 SpawnAreaSize;   // Size of the spawn area
    [SerializeField] private float SpawnInterval = 5f; // Time interval between spawns in seconds
    [SerializeField] private Normal_Target_Manager NormalTarget;

    private TargetObjectPool NormalTargetPool;

    void Start()
    {
        // Start spawning the prefab objects at intervals
        //InvokeRepeating("SpawnPrefab", 0f, SpawnInterval);
       NormalTargetPool = new TargetObjectPool(NormalTarget, SpawnAmt * 10);//NormalTargetPool = new TargetObjectPool(NormalTargetPrefab, 10);
        StartCoroutine(SpawnCorutine());
    }
    
    IEnumerator SpawnCorutine() 
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnInterval);
            SpawnPrefab();

        }
        
    }
    private void KillTarget(Normal_Target_Manager target)
    {
        Debug.Log(target.gameObject.name);
        //Destroy(box.gameObject);
        NormalTargetPool.ReturnToPool(target);
        //UnityPool.Release(box);
    }
    void SpawnPrefab()
    {
        // Calculate a random position within the specified spawn area
        Vector3 randomSpawnPosition = new Vector3(
            Random.Range(SpawnAreaCenter.x - SpawnAreaSize.x / 2, SpawnAreaCenter.x + SpawnAreaSize.x / 2),
            Random.Range(SpawnAreaCenter.y - SpawnAreaSize.y / 2, SpawnAreaCenter.y + SpawnAreaSize.y / 2),
            Random.Range(SpawnAreaCenter.z - SpawnAreaSize.z / 2, SpawnAreaCenter.z + SpawnAreaSize.z / 2)
        );

        // Instantiate the prefab at the random position
        //Instantiate(Target, randomSpawnPosition, Quaternion.identity);
        Normal_Target_Manager spawnedTarget = NormalTargetPool.Get();
        spawnedTarget.transform.position = randomSpawnPosition;
        spawnedTarget.transform.rotation = Quaternion.identity;
        NormalTarget.Init(KillTarget);
    }

    public void SpawnMoretarget()
    {
        SpawnInterval = 1.5f;
    }
}

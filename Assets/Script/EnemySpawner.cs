using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public  static EnemySpawner Instance;
    private void Awake()
    {
        Instance = this;
    }
    public List<GameObject> prefabs;
    public List<Transform> spawnPoints;
    public float spawnInterval=20f;
    public int spawntime=0;
    void Start()
    {
        StartCoroutine(SpawnDelay());
    }
    IEnumerator SpawnDelay()
    {
        while (true) 
        {
            if(spawntime <= 0)
            {
                break;
            }
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy();
            spawntime--;

        }
        

    }
    void SpawnEnemy()
    {
        int randomEnemyPrefabID=Random.Range(0, prefabs.Count);
        int randomEnemySpawnPointID = Random.Range(0, spawnPoints.Count);
        GameObject spawnedEnemy = Instantiate(prefabs[randomEnemyPrefabID], spawnPoints[randomEnemySpawnPointID]);
    }
}

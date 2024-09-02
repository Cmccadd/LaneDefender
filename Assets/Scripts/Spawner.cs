using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public float minSpawnTime = 1f; 
    public float maxSpawnTime = 5f; 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Wait for a random time before spawning the next enemy
            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);

            // Select a random enemy prefab and spawn point
            int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
            int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);

            GameObject enemyPrefab = enemyPrefabs[randomEnemyIndex];
            Transform spawnPoint = spawnPoints[randomSpawnPointIndex];

            // Instantiate the enemy at the chosen spawn point
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}

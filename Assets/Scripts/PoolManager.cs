using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //[SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<GameObject> enemyPrefabs = new List<GameObject>();
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] List<GameObject> pooledEnemies = new List<GameObject>();
    public int waveNumber = 3;
    public int activeCount;




    void Start()
    {
        InstancePool(5);
        SpawnEnemyWave(waveNumber);
    }

    void Update()
    {
        activeCount = CountActiveEnemies();

        if (activeCount < 3)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    void InstancePool(int numberEnemies)
    {
        for (int i = 0; i < numberEnemies; i++)
        {
            int randomSpawnIndex = Random.Range(0, spawnPoints.Count);
            Transform spawnPoint = spawnPoints[randomSpawnIndex];

            foreach (var prefab in enemyPrefabs)
            {
                GameObject spawnEnemy = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
                pooledEnemies.Add(spawnEnemy);
                spawnEnemy.SetActive(false);
                spawnEnemy.transform.SetParent(transform);
            }
        }
    }

    GameObject CallEnemy()
    {
        foreach (var enemy in pooledEnemies)
        {
            if (!enemy.activeInHierarchy)
            {
                return enemy;
            }
        }
        return null;
    }

    int CountActiveEnemies()
    {
        activeCount = 0;
        foreach (var enemy in pooledEnemies)
        {
            if (enemy.activeInHierarchy)
            {
                activeCount++;
            }
        }
        return activeCount;
    }

    void SpawnEnemyWave(int numberEnemies)
    {
        for (int i = 0; i < numberEnemies; i++)
        {
            GameObject selectedEnemy = CallEnemy();

            if (selectedEnemy != null)
            {
                int randomSpawnIndex = Random.Range(0, spawnPoints.Count);
                Transform spawnPoint = spawnPoints[randomSpawnIndex];

                selectedEnemy.transform.position = spawnPoint.position;
                selectedEnemy.SetActive(true);
            }
        }
    }
}

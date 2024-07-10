using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //[SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<GameObject> enemyPrefabs = new List<GameObject>();
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] List<GameObject> pooledEnemies = new List<GameObject>();



    void Start()
    {
        // Instanciar 5 enemigos al inicio
        InstancePool(7);

        // Asegurar que siempre haya al menos 3 enemigos activos inicialmente
        EnsureMinimumEnemies(5);

        // Usar un enemigo al inicio (esto no es necesario si usamos EnsureMinimumEnemies)
        // UseEnemy();
        //EnsureMinimumEnemies(3);
    }

    void EnsureMinimumEnemies(int minimumCount)
    {
        // Contar y activar enemigos hasta alcanzar el mínimo deseado
        while (CountActiveEnemies() < minimumCount)
        {
            GameObject enemy = CallEnemy();
            if (enemy != null)
            {
                enemy.SetActive(true);
            }

        }
    }
    int CountActiveEnemies()
    {
        // Contar enemigos activos en la escena
        int activeCount = 0;
        foreach (var enemy in pooledEnemies)
        {
            if (enemy.activeInHierarchy)
            {
                activeCount++;
            }
        }
        return activeCount;
    }

    void InstancePool(int numberEnemies)
    {

        // Instanciar enemigos hasta alcanzar el número deseado
        for (int i = 0; i < numberEnemies; i++)
        {
            // Seleccionar un punto de spawn aleatorio
            int randomSpawnIndex = Random.Range(0, spawnPoints.Count);
            Transform spawnPoint = spawnPoints[randomSpawnIndex];

            // Instanciar enemigos usando los diferentes prefabs
            foreach (var prefab in enemyPrefabs)
            {
                GameObject spawnEnemy = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
                pooledEnemies.Add(spawnEnemy);
                spawnEnemy.SetActive(false);
                spawnEnemy.transform.SetParent(transform); // Opcional: establecer como hijo de este objeto
            }
        }
    }

    GameObject CallEnemy()
    {
        // Buscar un enemigo inactivo en el pool y devolverlo
        foreach (var enemy in pooledEnemies)
        {
            if (!enemy.activeInHierarchy)
            {
                return enemy;
            }
        }

        return null; // Devolver null si no hay enemigos disponibles en el pool
    }

    public void UseEnemy()
    {
        // Verificar si hay menos de 3 enemigos activos
        if (CountActiveEnemies() < 3)
        {
            // Asegurar que haya al menos 3 enemigos activos
            EnsureMinimumEnemies(5);
        }

        // Seleccionar un punto de spawn aleatorio para este uso
        int randomSpawnIndex = Random.Range(0, spawnPoints.Count);
        Transform spawnPoint = spawnPoints[randomSpawnIndex];

        // Obtener un enemigo del pool
        GameObject selectedEnemy = CallEnemy();

        if (selectedEnemy != null)
        {
            // Posicionar el enemigo en el punto de spawn seleccionado
            selectedEnemy.transform.position = spawnPoint.position;
            selectedEnemy.SetActive(true);
        }
    }
}

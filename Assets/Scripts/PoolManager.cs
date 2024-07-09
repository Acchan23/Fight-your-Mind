using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    //[SerializeField] private Transform spawnPoint;
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] List<GameObject> pooledEnemies = new List<GameObject>();


    void Start()
    {
        InstancePool(2);

        UseEnemy();
    }

    void InstancePool(int numberEnemies)
    {
        for (int i = 0; i < numberEnemies; i++)
        {
            GameObject spawnEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            pooledEnemies.Add(spawnEnemy);
        }

        foreach (var enemy in pooledEnemies)
        {
            enemy.SetActive(false);
            enemy.transform.SetParent(this.transform);   
        }
    }

    GameObject CallEnemy()
    {
        for (int i = 0; i < pooledEnemies.Count; i++)
        {
            //Usamos una condición donde preguntamos si el clon actual NO está activado
            if (!pooledEnemies[i].activeInHierarchy)
            {
                //si NO está activado, lo va a dar como resultado (lo retorna)
                return pooledEnemies[i];
            }
        }
        
        return null;
    }

    public void UseEnemy()
    {
        int randomIndex = Random.Range(0, spawnPoints.Count);

        GameObject firstOffObject = CallEnemy();

        firstOffObject.transform.position = spawnPoints[randomIndex].position;

        firstOffObject.SetActive(true);
    }
}

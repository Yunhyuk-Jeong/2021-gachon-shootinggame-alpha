using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int poolSize = 10;

    public List<GameObject> enemyObjectPool;

    public Transform[] spawnPoints;

    public GameObject enemyFactory;

    public float minTime = 0.5f;

    public float maxTime = 1.5f;

    float creatTime;
    float currentTime = 0;

    void Start()
    {
        creatTime = Random.Range(minTime, maxTime);

        enemyObjectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);

            enemyObjectPool.Add(enemy);

            enemy.SetActive(false);
        }
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > creatTime)
        {
            if (enemyObjectPool.Count > 0)
            {
                GameObject enemy = enemyObjectPool[0];

                enemyObjectPool.Remove(enemy);

                int index = Random.Range(0, spawnPoints.Length);

                enemy.transform.position = spawnPoints[index].position;
                
                enemy.SetActive(true);
            }

            creatTime = Random.Range(minTime, maxTime);
            currentTime = 0;
        }
    }
}

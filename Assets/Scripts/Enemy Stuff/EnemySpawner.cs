using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyFactory enemyFactory;

    public void SpawnEnemy()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 0);
        EnemyType randomType = (EnemyType)Random.Range(0, 2);
        enemyFactory.CreateEnemy(randomType, randomPosition);
    }

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, 4f);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyFactory enemyFactory;
    public float spawnInterval = 5f;

    private void OnEnable()
    {
        MessageManager.Instance.spawnMessenger.Subscribe(StartSpawning);
    }

    private void OnDisable()
    {
        MessageManager.Instance.spawnMessenger.Unsubscribe(StartSpawning);
    }

    void StartSpawning(SpawnMessage msg)
    {
        StartCoroutine(SpawnWave(msg.waveNumber));
    }

    IEnumerator SpawnWave(int waveNumber)
    {
        for (int i = 0; i < waveNumber + 4; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 0);
            EnemyType randomType = (EnemyType)Random.Range(0, 2);
            enemyFactory.CreateEnemy(randomType, spawnPosition);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
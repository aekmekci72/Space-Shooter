using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyFactory enemyFactory;
    public float spawnInterval = 5f;
    private int currentWave;

    private void OnEnable()
    {
        MessageManager.Instance.levelMessenger.Subscribe(StartWave);
    }

    private void OnDisable()
    {
        MessageManager.Instance.levelMessenger.Unsubscribe(StartWave);
    }

    void StartWave(LevelMessage msg)
    {
        currentWave = msg.waveNumber;
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < currentWave + 4; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 0);
            EnemyType randomType = (EnemyType)Random.Range(0, 2);
            
            MessageManager.Instance.spawnMessenger.SendMessage(new SpawnMessage(randomType));

            enemyFactory.CreateEnemy(randomType, spawnPosition);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
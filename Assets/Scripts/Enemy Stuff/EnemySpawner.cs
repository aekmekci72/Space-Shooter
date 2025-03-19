using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyFactory enemyFactory;
    public float spawnInterval = 5f;
    public WaveManager waveManager;

    private void OnEnable()
    {
        MessageManager.Instance.levelMessenger.Subscribe(StartWave);
    }

    private void OnDisable()
    {
        MessageManager.Instance.levelMessenger.Unsubscribe(StartWave);
    }

    public void StartWave(LevelMessage msg)
    {
        Debug.Log("Starting wave " + msg.waveNumber);
        // currentWave = msg.waveNumber;
        StartCoroutine(SpawnWave(msg.waveNumber));
    }

    IEnumerator SpawnWave(int currentWave)
    {
        spawnInterval--;
        int enemiesToSpawn = Mathf.RoundToInt((currentWave + 4) * 1.3f);
        Debug.Log("spawning " + enemiesToSpawn + " enemies");

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 0);
            EnemyType randomType = (EnemyType)Random.Range(0, 1);
            
            // MessageManager.Instance.spawnMessenger.SendMessage(new SpawnMessage(randomType));
            // Debug.Log("Spawning enemy " + randomType + " at position " + spawnPosition);

            enemyFactory.CreateEnemy(randomType, spawnPosition);

            yield return new WaitForSeconds(spawnInterval);
        }

        Debug.Log("done spawning enemies");

        waveManager.EndWave();

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    public int currentWave = 1;
    public int enemiesPerWave = 5;
    private int enemiesRemaining;
    private bool waveActive = false;

    void OnEnable()
    {
        MessageManager.Instance.killMessenger.Subscribe(EnemyDefeated);
    }

    private void OnDisable()
    {
        MessageManager.Instance.killMessenger.Unsubscribe(EnemyDefeated);
    }

    private void Start()
    {
        StartWave();
    }

    void StartWave()
    {
        waveActive = true;
        enemiesRemaining = enemiesPerWave;
        MessageManager.Instance.spawnMessenger.SendMessage(new SpawnMessage(currentWave));
    }

    void EnemyDefeated(KillMessage msg)
    {
        enemiesRemaining--;
        if (enemiesRemaining <= 0)
        {
            EndWave();
        }
    }

    void EndWave()
    {
        if (!waveActive) return;
        waveActive = false;
        MessageManager.Instance.levelMessenger.SendMessage(new LevelMessage(currentWave));
        Invoke(nameof(NextWave), 3f);
    }

    void NextWave()
    {
        currentWave++;
        Debug.Log(currentWave);
        enemiesPerWave += 3;
        StartWave();
    }
}

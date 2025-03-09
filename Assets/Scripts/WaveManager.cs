using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    public int currentWave = 1;
    public int enemiesPerWave = 5;
    public EnemySpawner enemySpawner;
    private bool waveActive = false;

    void OnEnable()
    {
        MessageManager.Instance.levelMessenger.Subscribe(StartWave);
    }

    private void OnDisable()
    {
        MessageManager.Instance.levelMessenger.Unsubscribe(StartWave);
    }

    private void Start()
    {
        StartWave(new LevelMessage(currentWave));
    }

    void StartWave(LevelMessage msg)
    {
        if (!waveActive)
        {
            waveActive = true;
            currentWave = msg.waveNumber;
            enemySpawner.StartWave(msg);
        }
    }

    void EndWave()
    {
        waveActive = false;
        MessageManager.Instance.levelMessenger.SendMessage(new LevelMessage(currentWave));
        Invoke(nameof(NextWave), 3f);
    }

    void NextWave()
    {
        currentWave++;
        Debug.Log(currentWave);
        enemiesPerWave += 3;
        StartWave(new LevelMessage(currentWave));
    }
}

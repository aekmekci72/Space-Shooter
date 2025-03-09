using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    public int currentWave = 1;
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
            // MessageManager.Instance.levelMessenger.SendMessage(new LevelMessage(currentWave));
        }
    }

    public void EndWave()
    {
        Debug.Log("Ending wave " + currentWave);
        waveActive = false;
        Invoke(nameof(NextWave), 3f);
    }

    void NextWave()
    {
        currentWave++;
        StartWave(new LevelMessage(currentWave));
    }
}

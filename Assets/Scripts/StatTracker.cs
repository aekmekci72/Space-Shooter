using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTracker : Singleton<StatTracker>
{    
    public int EnemiesSpawned { get; private set; }
    public int PowerupsGained { get; private set; }
    public int EnemiesKilled { get; private set; }
    public int CurrentWave { get; set; }

    public void Start()
    {
        MessageManager.Instance.killMessenger.Subscribe(KilledEvent);
        MessageManager.Instance.spawnMessenger.Subscribe(SpawnEvent);
        MessageManager.Instance.powerupMessenger.Subscribe(PowerupEvent);
        // MessageManager.Instance.levelMessenger.Subscribe(LevelClearedEvent);
    }


    public void KilledEvent(KillMessage message)
    {
        EnemiesKilled++;
    }


    public void SpawnEvent(SpawnMessage message)
    {
        EnemiesSpawned++;
    }

    public void PowerupEvent(PowerupMessage message)
    {
        PowerupsGained++;
    }


    // public void LevelClearedEvent(LevelMessage message)
    // {
    //     // if (message.Level > HighestLevelReached)
    //     // {
    //     //     HighestLevelReached = message.Level;
    //     // }

    //     LevelsCleared++;
    // }
}
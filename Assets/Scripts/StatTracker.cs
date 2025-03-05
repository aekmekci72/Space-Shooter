using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTracker : Singleton<StatTracker>
{
    // add more here
    public int EnemiesKilled { get; private set; }

    public void Start()
    {
        // MessageManager.Instance.killMessenger.Subscribe(KilledEvent);
        // MessageManager.Instance.spawnMessenger.Subscribe(SpawnEvent);
        // MessageManager.Instance.levelMessenger.Subscribe(LevelClearedEvent);
    }


    // public void KilledEvent(KillMessage message)
    // {
        // if (message.creatureKilled == Actor.actorType.worker)
        // {
        //     WorkersKilled++;
        // }
        // else if (message.creatureKilled == Actor.actorType.zombie)
        // {
        //     ZombiesKilled++;
        // }
        // else if (message.creatureKilled == Actor.actorType.graveyard)
        // {
        //     GraveyardsKilled++;
        // }
        // else
        // {
        //     Debug.Log("Invalid state " + message + "received in KillEvent");
        // }
    // }


    // public void SpawnEvent(SpawnMessage message)
    // {
        // if (message.creatureSpawned == Actor.actorType.worker)
        // {
        //     WorkersSpawned++;
        // }
        // else if (message.creatureSpawned == Actor.actorType.zombie)
        // {
        //     ZombiesSpawned++;
        // }
        // else
        // {
        //     Debug.Log("Invalid state " + message + "received in SpawnEvent");
        // }
    // }


    // public void LevelClearedEvent(LevelClearedMessage message)
    // {
        // if (message.Level > HighestLevelReached)
        // {
        //     HighestLevelReached = message.Level;
        // }

        // LevelsCleared++;
    // }
}
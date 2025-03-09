using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMessage : Message
{
    public EnemyType enemySpawned;

    public SpawnMessage(EnemyType enemySpawned)
    {
        this.enemySpawned = enemySpawned;
    }

    public override string ToString()
    {
        return this.GetType().Name + ": " + enemySpawned;
    }
}

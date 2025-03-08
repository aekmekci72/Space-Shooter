using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMessage : Message
{
    public Enemy enemySpawned;

    public SpawnMessage(Enemy enemySpawned)
    {
        this.enemySpawned = enemySpawned;
    }

    public override string ToString()
    {
        return this.GetType().Name + ": " + enemySpawned;
    }
}
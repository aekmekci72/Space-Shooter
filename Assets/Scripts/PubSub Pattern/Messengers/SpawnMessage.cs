using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMessage : MonoBehaviour
{
    public EnemyType enemySpawned;

    public SpawnMessage(EnemyType enemySpawned)
    {
        this.enemySpawned = enemySpawned;
    }
}

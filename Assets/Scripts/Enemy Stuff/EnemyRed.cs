using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRed : Enemy
{
    public void Initialize()
    {
        // MessageManager.Instance.spawnMessenger.SendMessage(new SpawnMessage(this));
        Debug.Log("EnemyRed Spawned");
    }
}

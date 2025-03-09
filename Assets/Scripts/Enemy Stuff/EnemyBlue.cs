using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlue : Enemy
{
    public void Initialize()
    {
        MessageManager.Instance.spawnMessenger.SendMessage(new SpawnMessage(this));
        Debug.Log("EnemyBlue Spawned");
    }
}
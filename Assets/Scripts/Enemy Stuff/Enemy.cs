using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour 
{
    public EnemyType enemyType; // Assign this in Inspector

    public void Die()
    {
        MessageManager.Instance.killMessenger.SendMessage(new KillMessage(enemyType));
        Destroy(gameObject);
    }
}
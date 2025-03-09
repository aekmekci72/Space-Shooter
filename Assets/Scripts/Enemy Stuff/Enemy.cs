using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour 
{
    public EnemyType enemyType; // Assign this in Inspector
    private PowerupSpawner powerupSpawner;

    void Start()
    {
        // MessageManager.Instance.spawnMessenger.SendMessage(new SpawnMessage(enemyType));
        powerupSpawner = FindObjectOfType<PowerupSpawner>();
    }
    public void Die()
    {
        MessageManager.Instance.killMessenger.SendMessage(new KillMessage(enemyType));
        if (powerupSpawner != null)
        {
            Debug.Log("here4");
            powerupSpawner.SpawnPowerup(transform.position);
        }
        Destroy(gameObject);
    }
}
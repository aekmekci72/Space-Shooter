using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerupSpawner : MonoBehaviour
{
    [System.Serializable]
    public class PowerupDrop
    {
        public GameObject powerupPrefab;
        [Range(0f, 100f)]
        public float dropChance;
    }

    public PowerupDrop[] powerups;
    public float fallSpeed = 2f;

    public void SpawnPowerup(Vector3 position)
    {
        Debug.Log("SpawnPowerup called at position: " + position);
        float randomValue = Random.Range(0f, 100f);
        float cumulativeChance = 0f;

        foreach (PowerupDrop powerup in powerups)
        {
            cumulativeChance += powerup.dropChance;
            Debug.Log($"Checking powerup: {powerup.powerupPrefab.name}, Chance: {cumulativeChance}, Random: {randomValue}");
            if (randomValue <= cumulativeChance)
            {
                Debug.Log($"Spawning powerup: {powerup.powerupPrefab.name}");
                GameObject spawnedPowerup = Instantiate(powerup.powerupPrefab, position, Quaternion.identity);
                Rigidbody2D rb = spawnedPowerup.GetComponent<Rigidbody2D>();
                if (rb == null)
                {
                    rb = spawnedPowerup.AddComponent<Rigidbody2D>();
                }
                rb.gravityScale = 0;
                rb.velocity = Vector2.down * fallSpeed;
                return;
            }
        }

        Debug.Log("No powerup spawned");
    }
}

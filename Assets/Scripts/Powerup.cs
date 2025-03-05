using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
    public abstract void ApplyEffect(PlayerController player);
    public abstract void RemoveEffect(PlayerController player);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.AddPowerup(this);
                gameObject.SetActive(false);
            }
        }
    }
}

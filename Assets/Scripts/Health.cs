using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Powerup
{
    public float healthIncrease = 0.25f; 

    public override void ApplyEffect(PlayerController player)
    {
        player.health = Mathf.Min(player.health + healthIncrease, 20f);
        Destroy(gameObject); 
    }

    public override void RemoveEffect(PlayerController player)
    {
        // Health increase is permanent, nothing to remove
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpeed : Powerup
{
    public float newFireRate = 0.25f;
    public float duration = 5f;
    private float originalFireRate; 

    public override void ApplyEffect(PlayerController player)
    {
        originalFireRate = player.fireRate; 
        player.fireRate = newFireRate; 
        player.StartCoroutine(RemoveRapidFireAfterDuration(player));
        HidePowerup(); 
    }

    private IEnumerator RemoveRapidFireAfterDuration(PlayerController player)
    {
        yield return new WaitForSeconds(duration);
        player.fireRate = originalFireRate; 
        Destroy(gameObject); 
    }

    public override void RemoveEffect(PlayerController player)
    {
        player.fireRate = originalFireRate;
    }

    private void HidePowerup()
    {
        GetComponent<SpriteRenderer>().enabled = false; 
        GetComponent<Collider2D>().enabled = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : Powerup
{
    public float speedMultiplier = 2f; 
    public float duration = 7.5f;

    public override void ApplyEffect(PlayerController player)
    {
        player.moveSpeed *= speedMultiplier; 
        player.StartCoroutine(RemoveSpeedAfterDuration(player));
        HidePowerup(); 
    }

    private IEnumerator RemoveSpeedAfterDuration(PlayerController player)
    {
        yield return new WaitForSeconds(duration);
        player.moveSpeed /= speedMultiplier; 
        Destroy(gameObject); 
    }

    public override void RemoveEffect(PlayerController player)
    {
        player.moveSpeed /= speedMultiplier; 
    }

    private void HidePowerup()
    {
        GetComponent<SpriteRenderer>().enabled = false; 
        GetComponent<Collider2D>().enabled = false; 
    }
}

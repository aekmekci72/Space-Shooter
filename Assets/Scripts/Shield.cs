using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Powerup
{
    public float shieldDuration = 5f;
    private Coroutine shieldCoroutine;

    public override void ApplyEffect(PlayerController player)
    {
        player.takingDamage = false;
        player.StartCoroutine(DeactivateShieldAfterDuration(player));
    }

    private IEnumerator DeactivateShieldAfterDuration(PlayerController player)
    {
        yield return new WaitForSeconds(shieldDuration);
        player.takingDamage = true;
        Destroy(gameObject);
    }
    public override void RemoveEffect(PlayerController player)
    {
        if (shieldCoroutine != null)
        {
            StopCoroutine(shieldCoroutine);
        }
        Debug.Log("here2");
        DeactivateShield(player);
    }
    private void DeactivateShield(PlayerController player)
    {
        player.takingDamage = true;
        Destroy(gameObject);
    }
}

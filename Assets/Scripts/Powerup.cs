using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
    public abstract void ApplyEffect(PlayerController player);
    public abstract void RemoveEffect(PlayerController player);

    private void OnTriggerEnter2D(Collider2D other)
    {
        PowerupHandler powerupManager = other.GetComponent<PowerupHandler>(); 

        if (powerupManager != null)
        {
            powerupManager.AddPowerup(this);
            Hide();
        }
    }
    private void Hide()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }
}

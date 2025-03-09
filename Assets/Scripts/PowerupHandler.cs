using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHandler : MonoBehaviour
{
    private PlayerController player; 
    private List<Powerup> activePowerups = new List<Powerup>();

    void Start()
    {
        player = GetComponent<PlayerController>(); 
    }

    public void AddPowerup(Powerup powerup)
    {
        activePowerups.Add(powerup);
        powerup.ApplyEffect(player);
    }

    public void RemovePowerup(Powerup powerup)
    {
        if (activePowerups.Contains(powerup))
        {
            activePowerups.Remove(powerup);
            powerup.RemoveEffect(player);
        }
    }

    public virtual void OnDestroy()
    {
        foreach (Powerup powerup in activePowerups)
        {
            powerup.RemoveEffect(player);
        }
        activePowerups.Clear();
    }

    public List<Powerup> GetActivePowerups()
    {
        return new List<Powerup>(activePowerups);
    }
}
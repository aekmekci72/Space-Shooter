using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupMessage : Message
{
    public Powerup powerupSpawned;

    public PowerupMessage(Powerup powerupSpawned)
    {
        this.powerupSpawned = powerupSpawned;
    }

    // public override string ToString()
    // {
    //     return this.GetType().Name + ": " + powerupSpawned;
    // }
}

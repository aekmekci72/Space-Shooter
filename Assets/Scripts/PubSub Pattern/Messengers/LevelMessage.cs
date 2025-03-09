using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMessage : Message
{
    public int waveNumber;

    public LevelMessage(int waveNumber)
    {
        this.waveNumber = waveNumber;
    }
}

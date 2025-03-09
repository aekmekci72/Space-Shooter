using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMessage : Message
{
    public EnemyType enemyKilled;

    public KillMessage(EnemyType enemyKilled)
    {
        this.enemyKilled = enemyKilled;
    }
}

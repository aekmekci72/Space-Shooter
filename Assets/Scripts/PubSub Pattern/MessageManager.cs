using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MessageManager : Singleton<MessageManager>
{
    // public KillMessenger killMessenger = new KillMessenger();
    public SpawnMessenger spawnMessenger = new SpawnMessenger();
    // public HitMessenger hitMessenger = new HitMessenger(); // for later when we add sound
    // public LevelMessenger levelMessenger = new LevelMessenger();
    // public UpgradeMessenger upgradeMessenger = new UpgradeMessenger();

}

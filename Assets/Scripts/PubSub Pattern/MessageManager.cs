using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MessageManager : Singleton<MessageManager>
{
    public SpawnMessenger spawnMessenger = new SpawnMessenger();
    public KillMessenger killMessenger = new KillMessenger();
    public PowerupMessenger powerupMessenger = new PowerupMessenger();
    // public HitMessenger hitMessenger = new HitMessenger(); // for later when we add sound
    public LevelMessenger levelMessenger = new LevelMessenger();
    // public UpgradeMessenger upgradeMessenger = new UpgradeMessenger();
}
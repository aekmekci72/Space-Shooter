using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMessenger : Messenger<SpawnMessage>
{
    private passMessage receivers;
    
    public override void SendMessage(SpawnMessage m)
    {
        receivers?.Invoke(m);
    }

    public override void Subscribe(passMessage method)
    {
        receivers += method;
    }

    public override void Unsubscribe(passMessage method)
    {
        receivers -= method;
    }
}

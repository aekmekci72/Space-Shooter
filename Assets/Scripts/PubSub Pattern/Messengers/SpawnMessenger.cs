using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMessenger : Messenger<SpawnMessage>
{
    private passMessage receivers;
    
    public override void SendMessage(SpawnMessage m)
    {
        receivers?.Invoke(m);
        subscribers.Invoke(m);
    }

    private event passMessage subscribers;

    public override void Subscribe(passMessage method)
    {
        subscribers += method;
    }

    public override void Unsubscribe(passMessage method)
    {
        subscribers -= method;
    }

}

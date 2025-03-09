using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMessenger : Messenger<SpawnMessage>
{
    private event passMessage subscribers;

    public override void Subscribe(passMessage method)
    {
        subscribers += method;
    }

    public override void Unsubscribe(passMessage method)
    {
        subscribers -= method;
    }

    public override void SendMessage(SpawnMessage m)
    {
        subscribers.Invoke(m);
    }

}

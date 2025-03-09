using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupMessenger : Messenger<PowerupMessage>
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

    public override void SendMessage(PowerupMessage m)
    {
        subscribers.Invoke(m);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMessenger  : Messenger<LevelMessage>
{
    private passMessage receivers;
    
    public override void SendMessage(LevelMessage m)
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

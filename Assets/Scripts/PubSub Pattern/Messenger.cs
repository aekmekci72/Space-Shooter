using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class is part of the Publisher/Subscriber (pubsub) pattern, not the traditional
 * Observer Pattern.  In Observer, the Publisher speaks directly to the Subscriber.
 * This is typically a one-to-one or one-to-many relationship.
 * 
 * By contrast, in pubsub, there is an intermediate class (defined below) to help 
 * facilitate a many-to-many relationship.
 * 
 * Under pubsub, the publishers and subscribers are not directly aware of one another, as
 * they only pass messages through the intermediary.
 * 
 * Intermediary classes like this one are more often called "Brokers", or "Message 
 * Brokers", though I liked the clarity of calling this a "Messenger" class, since 
 * it simply exists to pass messages.
 */

public abstract class Messenger<T> where T : Message
{
    public delegate void passMessage(T m);

    public abstract void Subscribe(passMessage method);

    public abstract void Unsubscribe(passMessage method);

    public abstract void SendMessage(T m);
}

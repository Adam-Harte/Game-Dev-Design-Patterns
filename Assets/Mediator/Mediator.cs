using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Mediator pattern is all about having a middle man between objects handling communication and knowledge of eachother
// The Mediator handles communication between objects via message and broadcast systems and knowledge of objects by holding them togetehr in a list
public abstract class Mediator<T> : MonoBehaviour where T : Component
{
    readonly List<T> entities = new List<T>();

    public void Register(T entity)
    {
        if (!entities.Contains(entity))
        {
            entities.Add(entity);
        }
    }

    public void Deregister(T entity)
    {
        if (entities.Contains(entity))
        {
            entities.Remove(entity);
        }
    }

    public void Message(T source, T target, string message)
    {
        var entity = entities.Find(entity => entity.Equals(target));
        Debug.Log("Message: " + message + "Sent to: " + entity);
    }

    public void Broadcast(T source, string message)
    {
        entities.FindAll(target => source != target).ForEach(target => Debug.Log("Message: " + message + "Broadcasted to target: " + target));
    }
}

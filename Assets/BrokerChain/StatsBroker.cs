using System;
using System.Collections.Generic;
using UnityEngine;

// The broker chain pain is used to handle a list of objects/events
// The broker chain pattern is a combination of the chain of responsibility pattern and mediator pattern
// The chain of responsibility is your chain/modifiers that have a handle function to be used for the event callback and the mediator is the broker that sits in between
// to handle the list of modifiers and communication of events to be handled by them
// The Broker Chain pattern is a variation on the Chain Of Responsibility pattern instead of handling a linear chain of objects/events a Broker sits inbetween to
// manage event distribution reducing direct dependancies among objects
public class StatsBroker : MonoBehaviour
{
    readonly LinkedList<StatModifier> modifiers = new();

    public EventHandler<Query> Queries;

    public void PerformQuery(object sender, Query query){
        // This way involves invoking the Queries events so that all objects handling it with its callback are called
        Queries?.Invoke(sender, query);

        // This way involves looping through all the chain/modifiers and calling their handler
        foreach (var modifier in modifiers) {
            modifier.Handle(sender, query);
        }

        // This way involves going through the chain of nodes in the LinkedList using built in LinkedList properties First and Next
        var node = modifiers.First;
        while (node != null) {
            var modifier = node.Value;
            modifier.Handle(sender, query);
            node = node.Next;
        }

        // All these methods achieve the same goal in different ways
    }

    public void AddModifier(StatModifier modifier) {
        // Add modifier to list of list loop approach
        modifiers.AddLast(modifier);
        // Add modifer Handle to Queries event as a callback for event approach
        Queries += modifier.Handle;
    }
}

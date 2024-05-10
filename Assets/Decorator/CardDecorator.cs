using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardDecorator : ICard
{
    // abstract class defines the decorator pattern where we get the object we want to wrap/decorate
    // in this case ICard card by calling the Decorate method. We then have the matching method of the interface
    // in this case ICard Play where we can add our own additional logic to decorate/wwrap the object
    protected ICard card;
    protected readonly int value;

    protected CardDecorator(int value)
    {
        this.value = value;
    }

    public void Decorate(ICard card)
    {
        this.card = card;
    }

    public virtual int Play()
    {
        return card?.Play() + value ?? value;
    }
}

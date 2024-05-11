using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaComponent : MonoBehaviour, IVisitable
{
    // Defines Visitable Accept method to handle the object being visited
    public int mana = 100;

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memento : MonoBehaviour
{
    // The Memento patterns holds some object data that can be created, stored and updated.
    // Useful when creating configs for players such as loadouts, hotbars etc.
    // Other objects/classes can then create an instance of a Memento to create, store and update persistent data
    List<int> values { get; }

    public Memento(List<int> values)
    {
        this.values = values;   
    }

    public List<int> GetValues => values;
}

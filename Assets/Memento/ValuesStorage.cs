using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValuesStorage : MonoBehaviour
{
    // Example storage where we create a Memento instance and add methods to interact with it
    private List<int> values;
    public Memento CreateMemento(List<int> values) => new Memento(new List<int>(values));

    public void SetMemento(Memento memento)
    {
        values = memento.GetValues;
    }
}

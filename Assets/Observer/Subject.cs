using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the traditional Observer pattern using the 2 main components of Subject and Observer
// The Subject is responsible for managing the observers and notifying them of changes
// The Observer is responsible for reacting to changes when notified
// This pattern just holds a list of observers to be notified instead of firing c# or Unity events
public abstract class Subject : MonoBehaviour
{
    private List<IObserver> observers = new List<IObserver>();

    public void AddObserver(IObserver observer) {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer) {
        observers.Remove(observer);
    }

    protected void NotifyObservers() {
        observers.ForEach((observer) => {
            observer.OnNotify();
        });
    }
}

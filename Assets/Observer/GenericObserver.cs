using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

// The observer pattern allows you to communicate changes to its data to other objects so they can react to it
// This creates a one-to-many relationship between objects where the one Subject can broadcast changes to many different Observers
// The common setup for this is to setup an event to be triggered whenever the observer value or values change
// Then other classes/components can register callbacks to fire on this event whenever the values change
// This allows you to decouple objects from eachother so they can react to events without needing references to eachother

public class GenericObserver<T> : MonoBehaviour
{
    [SerializeField] T value;
    [SerializeField] UnityEvent<T> onValueChanged;

    public T Value {
        get => value;
        set => Set(value);
    }

    public GenericObserver(T value, UnityAction<T> callback = null) {
        this.value = value;
        onValueChanged = new UnityEvent<T>();
        if (callback != null) onValueChanged.AddListener(callback);
    }

    public void Set(T value) {
        if (Equals(this.value, value)) return;
        this.value = value;
        Invoke();
    }

    public void Invoke() {
        Debug.Log("Invoking " + onValueChanged.GetPersistentEventCount() + " listeners");
        onValueChanged.Invoke(value);
    }

    public void AddListener(UnityAction<T> callback) {
        if (callback == null) return;
        if (onValueChanged == null) onValueChanged = new UnityEvent<T>();

        onValueChanged.AddListener(callback);
    }

    public void RemoveListener(UnityAction<T> callback) {
        if (callback == null) return;
        if (onValueChanged == null) onValueChanged = new UnityEvent<T>();

        onValueChanged.RemoveListener(callback);
    }

    public void RemoveAllListeners() {
        if (onValueChanged == null) return;

        onValueChanged.RemoveAllListeners();
    }

    public void Dispose() {
        RemoveAllListeners();
        onValueChanged = null;
        value = default;
    }
}

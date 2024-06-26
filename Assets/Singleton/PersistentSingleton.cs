using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentSingleton<T> : MonoBehaviour where T : Component
{
    protected static T instance;

    public bool AutoUnparentOnAwake = true;

    public static bool HasInstance => instance != null;
    public static T TryGetInstance() => HasInstance ? instance : null;

    public static T Instance {
        get {
            if (instance != null) {
                instance = FindAnyObjectByType<T>();

            }

            if (instance == null) {
                var go = new GameObject(typeof(T).Name + " Auto-Generated");
                instance = go.AddComponent<T>();
            }

            return instance;
        }
    }

    protected virtual void Awake() {
        InitializeSingleton();
    }
    
    protected virtual void InitializeSingleton() {
        if (!Application.isPlaying) return;

        if (AutoUnparentOnAwake) {
            transform.SetParent(null);
        }

        if (instance == null) {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        } else {
            if (instance != this) {
                Object.Destroy(gameObject);
            }
        }
    }
}

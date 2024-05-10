using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Singleton pattern is useful when you want to centralise some data and methods in a way where only one instance of it exists
// this is useful for manager type scripts such as game state management
// The Singleton is a static instance which can only have one instance. This way other classes can use its static member variables and methods without worrying about multiple instances
public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        } else {
            Object.Destroy(gameObject);
        }
    }
}

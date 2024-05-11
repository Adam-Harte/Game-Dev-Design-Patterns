using UnityEngine;

public class ServiceB {
    public void Initialize(string message = null) {
        Debug.Log($"ServiceB.Intialize({message})");
    }
}

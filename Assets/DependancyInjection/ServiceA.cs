using UnityEngine;

public class ServiceA {
    public void Initialize(string message = null) {
        Debug.Log($"ServiceA.Intialize({message})");
    }
}

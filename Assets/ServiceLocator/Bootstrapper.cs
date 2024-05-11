using UnityEngine;

// Bootstrapper configures our serviceLocator with certain scopes e.g. Global, Scene, MonoBehaviour
[DisallowMultipleComponent]
[RequireComponent(typeof(ServiceLocator))]
public abstract class Bootstrapper : MonoBehaviour {
    ServiceLocator container;
    internal ServiceLocator Container => container ? container : (container  = GetComponent<ServiceLocator>());

    bool hasBeenBootstrapped;

    void Awake() => BootstrapOnDemand();

    public void BootstrapOnDemand() {
        if (hasBeenBootstrapped) return;

        hasBeenBootstrapped = true;
        Bootstrap();
    }

    protected abstract void Bootstrap();
}
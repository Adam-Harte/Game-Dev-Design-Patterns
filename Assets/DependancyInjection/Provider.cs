using UnityEngine;

// Example case of a Provider class using the [provide] marker to set dependancies to provide and be injected by the Injector class
public class Provider : MonoBehaviour, IDependancyProvider {
    [Provide]
    public ServiceA ProvideServiceA() {
        return new ServiceA();
    }

    [Provide]
    public ServiceB ProvideServiceB() {
        return new ServiceB();
    }

    [Provide]
    public FactoryA ProvideFactoryA() {
        return new FactoryA();
    }
}

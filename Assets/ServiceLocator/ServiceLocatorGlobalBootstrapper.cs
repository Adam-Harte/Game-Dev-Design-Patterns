using UnityEngine;

[AddComponentMenu("ServiceLocator/ServiceLocator Global")]
public class ServiceLocatorGlobalBootstrapper : Bootstrapper {
    [SerializeField]
    bool dontDestroyOnLoad = true;

    protected override void Bootstrap()
    {
        Container.ConfigureAsGlobal(dontDestroyOnLoad);
    }
}

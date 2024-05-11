using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// Service Locator acts as a central repository for all references to services that other classes can/need to use
// This is a from of inversion of control
// With the ServiceLocator we can also set different/reference access levels for services e.g. global level, scene level
// This decouples our services from our other classes as now instead of needing to create instances of
// services you need in a class you can instead get a refercne to a service from the ServiceLocator class
// The ServiceLocator uses the ServiceManager class to handle registering and getting the different services
public class ServiceLocator : MonoBehaviour {
    static ServiceLocator global;
    static Dictionary<Scene, ServiceLocator> sceneContainers;
    static List<GameObject> tmpSceneGameObjects;

    readonly ServiceManager services = new ServiceManager();

    const string k_globalServiceLocatorName = "ServiceLocator [global]";
    const string k_sceneServiceLocatorName = "ServiceLocator [scene]";

    internal void ConfigureAsGlobal(bool dontDestroyOnLoad) {
            if (global == this) {
                Debug.LogWarning("ServiceLocator.ConfigureAsGlobal: Already configured as global", this);
            } else if (global != null) {
                Debug.LogError("ServiceLocator.ConfigureAsGlobal: Another ServiceLocator is already configured as global", this);
            } else {
                global = this;
                if (dontDestroyOnLoad) DontDestroyOnLoad(gameObject);
            }
        }

        internal void ConfigureForScene() {
            Scene scene = gameObject.scene;

            if (sceneContainers.ContainsKey(scene)) {
                Debug.LogError("ServiceLocator.ConfigureForScene: Another ServiceLocator is already configured for this scene", this);
                return;
            }
            
            sceneContainers.Add(scene, this);
        }

    public static ServiceLocator Global {
        get {
            if (global != null) return global;

            // bootstrap or initialize  the new instance of global as necessary
            if (FindFirstObjectByType<ServiceLocatorGlobalBootstrapper>() is { } found) {
                found.BootstrapOnDemand();
                return global;
            }

            var container = new GameObject(k_globalServiceLocatorName, typeof(ServiceLocator));
            container.AddComponent<ServiceLocatorGlobalBootstrapper>().BootstrapOnDemand();

            return global;
        }
    }

    public static ServiceLocator For(MonoBehaviour mb) {
        return mb.GetComponentInParent<ServiceLocator>() ? ForSceneOf(mb) : global;
    }

    public static ServiceLocator ForSceneOf(MonoBehaviour mb) {
        Scene scene = mb.gameObject.scene;

        if (sceneContainers.TryGetValue(scene, out ServiceLocator container) && container != mb) {
            return container;
        }

        tmpSceneGameObjects.Clear();
        scene.GetRootGameObjects(tmpSceneGameObjects);

        foreach(GameObject go in tmpSceneGameObjects.Where(go => go.GetComponent<ServiceLocatorSceneBootstrapper>() != null) ) {
            if (go.TryGetComponent(out ServiceLocatorSceneBootstrapper bootstrapper)) {
                bootstrapper.BootstrapOnDemand();
                return bootstrapper.Container;
            }
        }

        return global;
    }

    public ServiceLocator Register<T>(T service) {
        services.Register(service);
        return this;
    }

    public ServiceLocator Register(Type type, object service) {
        services.Register(type, service);
        return this;
    }

    public ServiceLocator Get<T>(out T service) where T : class {
        if (TryGetService(out service)) return this;

        if (TryGetNextInHeirarchy(out ServiceLocator container)) {
            container.Get(out service);
            return this;
        }

        throw new ArgumentException($"ServiceLocator.Get: service of type {typeof(T).FullName} not registered");
    }

    bool TryGetService<T>(out T service) where T : class {
        return services.TryGet(out service);
    }

    bool TryGetNextInHeirarchy(out ServiceLocator container) {
        if (this == global) {
            container = null;
            return false;
        }

        var parentServiceLocator = transform.parent ? transform.parent.GetComponentInParent<ServiceLocator>() : null;
        container = parentServiceLocator ? parentServiceLocator : ForSceneOf(this);

        return container != null;
    }

    #if UNITY_EDITOR
        [MenuItem("GameObject/ServiceLocator/Add Global")]
        static void AddGlobal() {
            var go = new GameObject(k_globalServiceLocatorName, typeof(ServiceLocatorGlobalBootstrapper));
        }

        [MenuItem("GameObject/ServiceLocator/Add Scene")]
        static void AddScene() {
            var go = new GameObject(k_sceneServiceLocatorName, typeof(ServiceLocatorSceneBootstrapper));
        }
    #endif
}

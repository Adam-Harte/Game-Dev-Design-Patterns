using System;
using System.Collections.Generic;
using UnityEngine;

// The ServiceManager handles registering and getting services for the ServiceLocator

public class ServiceManager {
    readonly Dictionary<Type, object> services = new Dictionary<Type, object>();
    public IEnumerable<object> RegisteredServices => services.Values;

    public bool TryGet<T>(out T service) where T : class {
        Type type = typeof(T);

        if (services.TryGetValue(type, out object serviceObj)) {
            service = serviceObj as T;
            return true;
        }

        service = null;
        return false;
    }

    public T Get<T>() where T : class {
        Type type = typeof(T);

        if (services.TryGetValue(type, out object obj)) {
            return obj as T;
        }

        throw new ArgumentException($"ServiceManager.Get: service of type {type.FullName} not registered");
    }

    public ServiceManager Register<T>(T service) {
        Type type = typeof(T);

        if (!services.TryAdd(type, service)) {
            Debug.LogError($"ServiceManager.Register: service of type {type.FullName} already registered");
        }

        return this;
    }

    public ServiceManager Register(Type type, object service) {
        if (!type.IsInstanceOfType(service)) {
            throw new ArgumentException("Type of service does not match type of service interface", nameof(service));
        }

        if (!services.TryAdd(type, service)) {
            Debug.LogError($"ServiceManager.Register: service of type {type.FullName} already registered");
        }

        return this;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

// Dependancy injection allows you to decouple classes from other subsytems they rely on. This is a from of inversion of control.
// Instead of classes having to instantiate instances of other systems they need we instead use an Injector class that injects any dependancies/systems needed by the class
// This gives us decoupling as we now have one Injector class responsible for managing and injecting dependancies to other classes that need them

[DefaultExecutionOrder(-1000)]
public class Injector {
    const BindingFlags k_bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

    readonly Dictionary<Type, object> registry = new Dictionary<Type, object>();

    private void Awake() {
        // Find all modules implementing IDependancyProvider
        var providers = FindMonoBehaviours().OfType<IDependancyProvider>();

        foreach (var provider in providers) {
            RegisterProvider(provider);
        }

        // Find all injectable objects and inject their dependancies
        var injectables = FindMonoBehaviours().Where(IsInjectable);

        foreach (var injectable in injectables) {
            Inject(injectable);
        }
    }

    void Inject(object instance) {
        var type = instance.GetType();

        // inject fields
        var injectableFields = type.GetFields(k_bindingFlags).Where(member => Attribute.IsDefined(member, typeof(InjectAttribute)));

        foreach (var injectableField in injectableFields) {
            var fieldType = injectableField.FieldType;
            var resolvedInstance = Resolve(fieldType);

            if (resolvedInstance == null) {
                throw new Exception($"Failed to resolve {fieldType.Name} for {type.Name}");
            }

            injectableField.SetValue(instance, resolvedInstance);
            Debug.Log($"Injected {fieldType.Name} into {type.Name}");
        }

        // inject methods
        var injectableMethods = type.GetMethods(k_bindingFlags).Where(member => Attribute.IsDefined(member, typeof(InjectAttribute)));

        foreach (var injectableMethod in injectableMethods) {
            var requiredParameters = injectableMethod.GetParameters().Select(parameter => parameter.ParameterType).ToArray();
            var resolvedInstances = requiredParameters.Select(Resolve).ToArray();

            if (resolvedInstances.Any(resolvedInstance => resolvedInstance == null)) {
                throw new Exception($"Failed to inject {type.Name} . {injectableMethod.Name}");
            }

            injectableMethod.Invoke(instance, resolvedInstances);
            Debug.Log($"Method injected {type.Name} . {injectableMethod.Name}");
        }
    }

    object Resolve(Type type) {
        registry.TryGetValue(type, out var resolvedInstance);

        return resolvedInstance;
    }

    static bool IsInjectable(MonoBehaviour obj) {
        var members = obj.GetType().GetMembers(k_bindingFlags);

        return members.Any(member => Attribute.IsDefined(member, typeof(InjectAttribute)));
    }

    void RegisterProvider(IDependancyProvider provider) {
        var methods = provider.GetType().GetMethods(k_bindingFlags);
        
        foreach (var method in methods) {
            if (!Attribute.IsDefined(method, typeof(ProvideAttribute))) continue;

            var returnType = method.ReturnType;
            var providedInstance = method.Invoke(provider, null);

            if (providedInstance != null) {
                registry.Add(returnType, providedInstance);
                Debug.Log($"Registered {returnType.Name} from {provider.GetType().Name}");
            } else {
                throw new Exception($"Provider {provider.GetType().Name} returned null for {returnType.Name}");
            }
        }
    }

    static MonoBehaviour[] FindMonoBehaviours() {
        return GameObject.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.InstanceID);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

// The flyweight pattern aims to share or reuse as much data as possible between similar objects
// This can offer great performance boosts as you arent recreating the same variables or objects for each instance of an object
// when they are all sharing some data from the Flyweight
// An example of data sharing between objects would be creating a scriptable object to hold all the shared data
// An example of data/object reuse for games would be Object Pooling
public class FlyweightFactory : MonoBehaviour
{
    [SerializeField] bool collectionCheck = true;
    [SerializeField] int defaultCapacity = 10;
    [SerializeField] int maxPoolSize = 100;
    static FlyweightFactory instance;
    readonly Dictionary<FlyweightType, IObjectPool<Flyweight>> pools = new();

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public static Flyweight Spawn(FlyweightSettings s) => instance.GetPoolFor(s)?.Get();
    public static void ReturnToPool(Flyweight f) => instance.GetPoolFor(f.settings)?.Release(f);

    IObjectPool<Flyweight> GetPoolFor(FlyweightSettings settings) {
        IObjectPool<Flyweight> pool;

        if (pools.TryGetValue(settings.type, out pool)) return pool;

        pool = new ObjectPool<Flyweight>(
            settings.Create,
            settings.OnGet,
            settings.OnRelease,
            settings.OnDestroyPoolObject,
            collectionCheck,
            defaultCapacity,
            maxPoolSize
        );

        return pool;
    }
}

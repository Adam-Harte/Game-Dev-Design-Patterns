using UnityEngine;

[CreateAssetMenu(menuName = "Flyweight/Flyweight Settings")]
public class FlyweightSettings : ScriptableObject
{
    public GameObject prefab;
    public FlyweightType type;

    public virtual Flyweight Create() {
        var go = Object.Instantiate(prefab);
        go.SetActive(false);
        go.name = prefab.name;

        var flyweight = go.AddComponent<Flyweight>();
        flyweight.settings = this;

        return flyweight;
    }

    public void OnGet(Flyweight f) => f.gameObject.SetActive(true);
    public void OnRelease(Flyweight f) => f.gameObject.SetActive(false);
    public void OnDestroyPoolObject(Flyweight f) => Object.Destroy(f.gameObject);
}

public enum FlyweightType { Enemy, Projectile }

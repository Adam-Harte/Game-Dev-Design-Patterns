using UnityEngine;

[CreateAssetMenu(menuName = "Flyweight/Flyweight Projectile Settings")]
public class FlyweightProjectileSettings : FlyweightSettings
{
    public float despawnDelay = 5f;
    public int speed = 5;
    public int damage = 5;

    public override Flyweight Create() {
        var go = Object.Instantiate(prefab);
        go.SetActive(false);
        go.name = prefab.name;

        var flyweight = go.AddComponent<FlyweightProjectile>();
        flyweight.settings = this;

        return flyweight;
    }
}

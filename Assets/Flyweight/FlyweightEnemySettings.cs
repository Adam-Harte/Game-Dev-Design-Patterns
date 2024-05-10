using UnityEngine;

[CreateAssetMenu(menuName = "Flyweight/Flyweight Enemy Settings")]
public class FlyweightEnemySettings : FlyweightSettings
{
    public int speed = 5;

    public override Flyweight Create() {
        var go = Object.Instantiate(prefab);
        go.SetActive(false);
        go.name = prefab.name;

        var flyweight = go.AddComponent<FlyweightEnemy>();
        flyweight.settings = this;

        return flyweight;
    }
}

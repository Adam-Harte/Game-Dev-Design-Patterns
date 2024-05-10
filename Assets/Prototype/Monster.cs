using UnityEngine;

// The Prototyep pattern is a crreational pattern that allows us to clone duplicate objects of the same typre within that class
// This is a great way to quickly create similar objects without adding code in other classes
// For this pattern we expose either an abstract class or interface with the Clone methosd then any other objects that want to be prototypes implement their own clone method
public abstract class Monster : MonoBehaviour
{
    private int health;
    private int speed;

    public abstract Monster Clone();
}

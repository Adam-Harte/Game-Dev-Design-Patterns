using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    private int Damage { get; set; }

    public Weapon(int damage)
    {
        this.Damage = damage;
    }

    public void Attack()
    {
        Debug.Log("attacked dealing :" + this.Damage + " damage");
    }
}

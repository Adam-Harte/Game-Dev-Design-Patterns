using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Factories are useful when you need to handle many different object creation subtypes
// This helps follow the single responsibility principle as you now have one class in charge of handling object creation
// Factories are also useful to remove code smells where you are conditionally creating lots of different objects in if/else or switch statements
public class WeaponFactory : MonoBehaviour
{
    public Sword CreateSword(int damage)
    {
        return new Sword(damage);
    }

    public Shield CreateShield(int damage, int defense)
    {
        return new Shield(damage, defense);
    }

    public Bow CreateBow(int damage, int range, int fireRate)
    {
        return new Bow(damage, range, fireRate);
    }

    public Axe CreateAxe(int damage)
    {
        return new Axe(damage);
    }
}

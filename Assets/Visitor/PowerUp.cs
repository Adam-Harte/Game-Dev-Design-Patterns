using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour, IVisitor
{
    // Defines IVisitor Visit methods with different argument signatures to handle different functionality
    public int healthBonus = 10;
    public int manaBonus = 10;

    public void Visit(HealthComponent healthComponent)
    {
        healthComponent.health += healthBonus;
    }

    public void Visit(ManaComponent manaComponent)
    {
        manaComponent.mana += manaBonus;
    }
}

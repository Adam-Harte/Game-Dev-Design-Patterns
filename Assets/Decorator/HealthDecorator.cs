using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDecorator : CardDecorator
{
    public HealthDecorator(int value) : base(value) { }

    public override int Play()
    {
        HealPlayer();
        return card?.Play() ?? 0;
    }

    private void HealPlayer()
    {

    }
}

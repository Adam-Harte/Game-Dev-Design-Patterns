using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCard : ICard
{
    readonly int value;

    public int Play()
    {
        return value;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpellStrategy : SpellStrategy
{
    public GameObject shieldPrefab;
    public float duration = 10f;

    public override void CastSpell(Transform origin)
    {
        var shield = Object.Instantiate(shieldPrefab, origin.position, Quaternion.identity, origin);
        Object.Destroy(shield, duration);
    }
}

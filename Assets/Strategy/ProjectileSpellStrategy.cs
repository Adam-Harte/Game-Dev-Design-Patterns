using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpellStrategy : SpellStrategy
{
    public GameObject projectilePrefab;
    public float speed = 10f;

    public override void CastSpell(Transform origin)
    {
        GameObject fireball = Object.Instantiate(projectilePrefab, origin.position, Quaternion.identity);
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        rb.velocity = origin.forward * speed;
    }
}

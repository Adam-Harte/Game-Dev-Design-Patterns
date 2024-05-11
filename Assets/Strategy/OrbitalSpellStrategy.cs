using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalSpellStrategy : SpellStrategy
{
    public GameObject orbPrefab;
    public int numberOfOrbs = 3;
    public float radius = 3f;
    public float duration = 5f;

    public Transform CreateOrbParent(Transform origin)
    {
        var orbParent = new GameObject("OrbParent").transform;
        orbParent.position = origin.position;
        orbParent.rotation = origin.rotation;
        orbParent.SetParent(origin);
        return orbParent.transform;
    }

    public void SpawnOrb(Transform origin, Transform orbParent, int i)
    {
        var orb = Object.Instantiate(orbPrefab, CalculateSpawnPosition(origin, i), Quaternion.identity, orbParent);
    }

    public Vector3 CalculateSpawnPosition(Transform origin, int i)
    {
        float angle = i * 2f * Mathf.PI / numberOfOrbs;
        return origin.position + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
    }

    public override void CastSpell(Transform origin)
    {
        Transform orbParent = CreateOrbParent(origin);

        for (int i = 0; i < numberOfOrbs; i++)
        {
            SpawnOrb(origin, orbParent, i);
        }

        Object.Destroy(orbParent.gameObject, duration);
    }
}

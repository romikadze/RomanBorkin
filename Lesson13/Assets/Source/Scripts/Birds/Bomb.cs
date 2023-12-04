using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Bomb : Bird
{
    [SerializeField] private float _explosionDamageForce;
    [SerializeField] private float _explosionRadius = 2f;
    [SerializeField] private float _explosionPushForce = 100f;

    private protected override void UseAbility()
    {
        Explode();
    }

    private void Explode()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);
        List<GameObject> hitObjects = new ();
        foreach (var hit in hits)
        {
            if (!hitObjects.Contains(hit.gameObject))
                hitObjects.Add(hit.gameObject);
        }

        foreach (var hit in hitObjects)
        {
            if (hit.GetComponent<Collider2D>().isTrigger) continue;
            if (hit.TryGetComponent(out IDamageable damageable))
            {
                Vector2 positionDifference = hit.GetComponent<Collider2D>().ClosestPoint(transform.position) - (Vector2)transform.position;
                float multiplier = (_explosionRadius - positionDifference.magnitude) / _explosionRadius;
                damageable.Push(positionDifference.normalized, _explosionPushForce * multiplier);
                damageable.Damage(_explosionDamageForce * multiplier);
            }
        }

        _isCanUseAbility = false;
    }
}

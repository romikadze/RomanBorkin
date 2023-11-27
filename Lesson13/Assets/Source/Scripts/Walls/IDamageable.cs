using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void Damage(float hitForce, float damageMultiplier = 1);

    void Push(Vector2 direction, float force);
    void Destroy();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IDamageable
{
    [SerializeField] private protected float _hitPoints;
    private protected float _collideForce;
    private protected Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }


    public void Damage(float hitForce, float damageMultiplier = 1)
    {
        if (damageMultiplier <= 0) return;

        float damage = (hitForce * hitForce) / 2 * damageMultiplier;
        print(damage);
        _hitPoints -= damage;
        if (_hitPoints <= 0)
            Destroy();
    }

    public void Push(Vector2 direction, float force)
    {
        _rigidbody2D.AddForce(direction * force, ForceMode2D.Impulse);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private protected virtual void Hit(Collision2D collision)
    {
        Damage(_collideForce);
    }

    private protected virtual void CalculateCollideForce(Collider2D collision)
    {
        if (collision == this) return;
        if (collision.TryGetComponent(out Rigidbody2D rigidbody))
        {
            _collideForce = (rigidbody.velocity - _rigidbody2D.velocity).magnitude;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CalculateCollideForce(collision);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Hit(collision);
    }


}

using System;
using UnityEngine;

namespace Source.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Obstacle : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _hp;
        private float _speed;

        private void Start()
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left * _speed;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(1);
            }
        }

        public void TakeDamage(float value)
        {
            if (value < 0) return;
            if (_hp <= value)
                Die();
        }

        public void Die()
        {
            Destroy(gameObject);
        }

        public void Setup(float speed)
        {
            _speed = speed;
        }
    }
}
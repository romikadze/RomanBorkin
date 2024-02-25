using System;
using UnityEngine;

namespace Source.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private float _verticalForce;
        [SerializeField] private float _punchForce;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.velocity = Vector2.down * _verticalForce;
        }
    
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent(out Player player))
            {
                Vector2 punchDirection = (player.transform.position - transform.position).normalized;
                player.Punch(punchDirection, _punchForce);
            }
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
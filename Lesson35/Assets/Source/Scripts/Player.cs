using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Scripts
{
    [RequireComponent(typeof(KeyboardInput))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour, IDamageable
    {
        public Action OnDie;

        [SerializeField] private float _hp = 3;
        [SerializeField] private float _invulnerabilityDuration = 3;

        private Collider2D _attackArea;
        private KeyboardInput _input;
        private Rigidbody2D _rigidbody2D;
        private float _jumpForce;
        private bool _isGrounded;
        private bool _canAttack = true;

        private void Awake()
        {
            _input = GetComponent<KeyboardInput>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _attackArea = GetComponentInChildren<PolygonCollider2D>();
            _attackArea.gameObject.SetActive(false);
            _input.OnJumpClicked += Jump;
            _input.OnAttackClicked += Attack;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(1);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _isGrounded = true;
            if (other.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.Die();
                StartCoroutine(InvulnerabilityTick(gameObject.layer, other.gameObject.layer));
            }
        }

        private void Jump()
        {
            if (!_isGrounded) return;
            _isGrounded = false;
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }

        private void Attack()
        {
            if (!_canAttack) return;
            _canAttack = false;
            _attackArea.gameObject.SetActive(true);
            StartCoroutine(AttackCooldown());
        }

        private IEnumerator AttackCooldown()
        {
            yield return new WaitForSeconds(0.1f);
            _attackArea.gameObject.SetActive(false);
            yield return new WaitForSeconds(1f);
            _canAttack = true;
        }
        
        private IEnumerator InvulnerabilityTick(int playerLayer, int obstacleLayer)
        {
            Physics2D.IgnoreLayerCollision(playerLayer, obstacleLayer, true);
            yield return new WaitForSeconds(_invulnerabilityDuration);
            Physics2D.IgnoreLayerCollision(playerLayer, obstacleLayer, false);
        }

        public void TakeDamage(float value)
        {
            if (value < 0) return;
            _hp -= value;
            if (_hp <= 0)
                Die();
        }

        public void Die()
        {
            OnDie?.Invoke();
            _input.OnJumpClicked -= Jump;
            _input.OnAttackClicked -= Attack;
            Destroy(gameObject);
        }

        public void Setup(float jumpForce)
        {
            _jumpForce = jumpForce;
        }
    }
}
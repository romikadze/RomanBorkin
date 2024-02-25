using System.Collections;
using UnityEngine;

namespace Source.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        private const float MAX_X = 2.5f;
        private const float MAX_Y = 2.5f;
        private const float RAY_Y_OFFSET = 0.5f;
        private const float SHOOT_DISTANCE = 10f;

        private float _horizontalInput;
        private Rigidbody2D _rigidbody2D;
        private bool _canShoot = true;
        private float _verticalForce = 0.05f;
        private float _horizontalForce = 2f;
        private float _shootCooldown = 2f;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            if (Input.GetKeyDown(KeyCode.Space) && _canShoot)
                Shoot();
        }

        private void FixedUpdate()
        {
            _rigidbody2D.AddForce(new Vector2(_horizontalForce * _horizontalInput, 0), ForceMode2D.Force);
            _rigidbody2D.AddForce(new Vector2(0, _verticalForce), ForceMode2D.Force);

            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -MAX_X, MAX_X),
                Mathf.Clamp(transform.position.y, -Mathf.Infinity, MAX_Y));
        }

        private IEnumerator ShootTick()
        {
            yield return new WaitForSeconds(_shootCooldown);
            _canShoot = true;
        }

        private void Shoot()
        {
            _canShoot = false;
            StartCoroutine(ShootTick());
        
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + RAY_Y_OFFSET),
                Vector2.up, SHOOT_DISTANCE);

            if (hit)
            {
                Destroy(hit.transform.gameObject);
            }
        }

        public void Punch(Vector2 direction, float punchForce)
        {
            _rigidbody2D.AddForce(punchForce * direction, ForceMode2D.Impulse);
        }

        public void Die()
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }
}
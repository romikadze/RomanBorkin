using System;
using System.Collections;
using UnityEngine;

namespace Source.Scripts
{
    public class Locator : MonoBehaviour
    {
        private CircleCollider2D _circleCollider2D;
        private Coroutine _locatorTick;

        private const float SEARCH_TIMER = 3f;
        private const float MAX_SEARCH_RADIUS = 15;

        public Action<Enemy> OnEnemyFound;

        private void Awake()
        {
            _circleCollider2D = GetComponent<CircleCollider2D>();
        }

        private void OnEnable()
        {
            _locatorTick = StartCoroutine(FindNearestEnemy());
            _circleCollider2D.radius = 0.5f;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                if (_locatorTick != null)
                    StopCoroutine(_locatorTick);
                _locatorTick = null;
                OnEnemyFound?.Invoke(enemy);
                enabled = false;
            }
        }

        private IEnumerator FindNearestEnemy()
        {
            if(_circleCollider2D.radius < MAX_SEARCH_RADIUS)
            {
                _circleCollider2D.radius += 0.1f;
                yield return null;
                _locatorTick = StartCoroutine(FindNearestEnemy());
            }
            else
            {
                yield return new WaitForSeconds(SEARCH_TIMER);
                _circleCollider2D.radius = 0.5f;
                _locatorTick = StartCoroutine(FindNearestEnemy());
            }
        }
    }
}
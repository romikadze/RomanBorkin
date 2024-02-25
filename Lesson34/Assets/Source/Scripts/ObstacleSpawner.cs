using System.Collections;
using UnityEngine;

namespace Source.Scripts
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] private Obstacle _obstacle;
        [SerializeField] private float _spawnY;

        private const float MAX_X = 2.5f;

        private float _spawnRate = 1f;
        private Coroutine _spawnTick;

        public void StartSpawn()
        {
            _spawnTick = StartCoroutine(SpawnTick());
        }

        private IEnumerator SpawnTick()
        {
            while (true)
            {
                Vector2 position = new Vector3(Random.Range(-MAX_X, MAX_X), _spawnY);
                Instantiate(_obstacle, position, Quaternion.identity);
                yield return new WaitForSeconds(_spawnRate);
            }
        }

        public void StopSpawn()
        {
            if (_spawnTick != null)
            {
                StopCoroutine(_spawnTick);
                _spawnTick = null;
            }
        }
    }
}
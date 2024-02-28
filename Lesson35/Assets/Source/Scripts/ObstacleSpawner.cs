using System.Collections;
using System.Linq;
using UnityEngine;

namespace Source.Scripts
{
    public class ObstacleSpawner : MonoBehaviour
    {
        private float _spawnRate;
        private float _obstaclesSpeed;
        private Obstacle[] _obstacles;
        private Coroutine _spawnTick;

        private Obstacle SelectRandomObstacle()
        {
            return _obstacles[Random.Range(0, _obstacles.Length)];
        }

        private IEnumerator SpawnTick()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnRate);
                Instantiate(SelectRandomObstacle()).Setup(_obstaclesSpeed);
            }
        }

        public void StartSpawn(Obstacle[] obstacles, float spawnRate, float obstaclesSpeed)
        {
            if (_spawnTick != null)
            {
                StopCoroutine(_spawnTick);
            }

            _obstaclesSpeed = obstaclesSpeed;
            _obstacles = obstacles;
            _spawnRate = spawnRate;
            _spawnTick = StartCoroutine(SpawnTick());
        }

        public void StopSpawn()
        {
            if (_spawnTick != null)
            {
                StopCoroutine(_spawnTick);
            }
        }
    }
}
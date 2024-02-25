using UnityEngine;

namespace Source.Scripts
{
    public class Judge : MonoBehaviour
    {
        [SerializeField] private DestroyLine _destroyLine;
        [SerializeField] private ObstacleSpawner _obstacleSpawner;
        [SerializeField] private Player _player;

        private void Start()
        {
            StartLevel();
            _destroyLine.OnPlayerDie += StopLevel;
        }

        private void StartLevel()
        {
            Instantiate(_player);
            _obstacleSpawner.StartSpawn();
        }

        private void StopLevel()
        {
            _obstacleSpawner.StopSpawn();
        }
    }
}
using System;
using UnityEngine;

namespace Source.Scripts
{
    public class LevelEnter : MonoBehaviour
    {
        [SerializeField] private ObstacleSpawner _obstacleSpawner;
        [SerializeField] private Obstacle[] _obstacles;
        [SerializeField] private Player _player;
        [SerializeField] private float _obstaclesSpeed;
        [SerializeField] private float _obstaclesSpawnRate;
        [SerializeField] private float _playerJumpForce;

        private void Start()
        {
            StartLevel();
        }

        private void StartLevel()
        {
            Player player = Instantiate(_player);
            player.OnDie += StopLevel;
            player.Setup(_playerJumpForce);
            
            _obstacleSpawner.StartSpawn(_obstacles, _obstaclesSpawnRate, _obstaclesSpeed);
        }

        private void StopLevel()
        {
            _obstacleSpawner.StopSpawn();
        }
    }
}
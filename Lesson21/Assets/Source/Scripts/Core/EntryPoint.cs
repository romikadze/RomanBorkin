using System;
using UnityEngine;

namespace Source.Scripts.Core
{
    public class EntryPoint : MonoBehaviour
    {
        private Enemy _basicEnemy;
        private PlayerMovement _player;

        [SerializeField] private CameraMovement _camera;
        
        [Header("Start points")] 
        [SerializeField] private Transform _playerStartPoint;
        [SerializeField] private Transform[] _enemyStartPoints;
        

        private void Awake()
        {
            _basicEnemy = Resources.Load<Enemy>("Enemy");
            _player = Resources.Load<PlayerMovement>("Player");
        }

        private void Start()
        {
            CreatePlayer();
            CreateEnemies();
        }

        private void CreatePlayer()
        {
            _player = Instantiate(_player, _playerStartPoint.position, Quaternion.identity);
            _camera.SetPlayer(_player);
        }

        private void CreateEnemies()
        {
            foreach (var startPoint in _enemyStartPoints)
            {
                IEntryPointSetupPlayer enemy = Instantiate(_basicEnemy, startPoint.position, Quaternion.identity);
                enemy.Setup(_player);
            }
        }
    }

    public interface IEntryPointSetupPlayer
    {
        public void Setup(PlayerMovement player);
    }
}
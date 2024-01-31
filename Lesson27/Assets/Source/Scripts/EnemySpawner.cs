using UnityEngine;

namespace Source.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyGroup _enemyGroup;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private int _enemiesCount;

        private void Start()
        {
            SpawnEnemies();
        }

        private void SpawnEnemies()
        {
            for (int i = 0; i < _enemiesCount; i++)
            {
                _enemyGroup.AddEnemy(Instantiate(_enemy));
            }
        }
    }
}
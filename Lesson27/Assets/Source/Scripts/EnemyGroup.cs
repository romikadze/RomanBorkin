using System.Collections.Generic;
using UnityEngine;


namespace Source.Scripts
{
    public class EnemyGroup : MonoBehaviour
    {
        private List<Enemy> _enemies = new();

        public void AddEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
        }

        public void TryToKillRandomEnemy()
        {
            if (Random.Range(0f, 1f) > 0.3f) return;
            Enemy enemyToKill = _enemies[Random.Range(0, _enemies.Count)];
            _enemies.Remove(enemyToKill);
            enemyToKill.Kill();
        }

        public void KillOddEnemies()
        {
            List<Enemy> enemiesTemp = new List<Enemy>(_enemies);
            foreach (var enemy in _enemies)
            {
                if (enemy.GetId() % 2 != 0)
                {
                    enemiesTemp.Remove(enemy);
                    enemy.Kill();
                }
            }

            _enemies = enemiesTemp;
        }
    }
}
using System;
using UnityEngine;

namespace Source.Scripts
{
    [RequireComponent(typeof(EnemyGroup))]
    public class KeyboardInput : MonoBehaviour
    {
        private EnemyGroup _enemyGroup;

        private void Awake()
        {
            _enemyGroup = GetComponent<EnemyGroup>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _enemyGroup.KillOddEnemies();
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                _enemyGroup.TryToKillRandomEnemy();
            }
        }
    }
}
using System;
using UnityEngine;

namespace Source.Scripts
{
    public class DestroyLine : MonoBehaviour
    {
        public Action OnPlayerDie;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Obstacle obstacle))
            {
                obstacle.Destroy();
            }
            else if (other.TryGetComponent(out Player player))
            {
                OnPlayerDie?.Invoke();
                player.Die();
            }
        }
    }
}
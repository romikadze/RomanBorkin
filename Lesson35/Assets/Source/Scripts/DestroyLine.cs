using UnityEngine;

namespace Source.Scripts
{
    public class DestroyLine : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable damageable))
            {
                damageable.Die();
            }
        }
    }
}
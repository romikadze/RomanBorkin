using UnityEngine;

namespace Source.Scripts
{
    public class Enemy : MonoBehaviour
    {
        private int _id;

        private void Awake()
        {
            _id = Random.Range(0, 10000);
        }

        public void Kill()
        {
            Destroy(gameObject);
        }

        public int GetId()
        {
            return _id;
        }
    }
}

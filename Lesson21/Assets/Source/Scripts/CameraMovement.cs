using UnityEngine;

namespace Source.Scripts
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        private PlayerMovement _playerMovement;
        private Vector3 lastPoint;
        
        private void MoveCamera(Vector3 position, Vector3 velocity)
        {
            Vector3 newPosition = position + _offset;
            Vector3 newPoint = position + velocity;

            newPosition = Lerp(transform.position, newPosition, 0.05f);
            newPoint = Lerp(lastPoint, newPoint, 0.05f);
            
            transform.LookAt(newPoint);
            transform.position = newPosition;
            
            lastPoint = newPoint;
        }

        private Vector3 Lerp(Vector3 start, Vector3 end, float t)
        {
            Vector3 lerp;
            lerp.x = Mathf.Lerp(start.x, end.x, t);
            lerp.y = Mathf.Lerp(start.y, end.y, t);
            lerp.z = Mathf.Lerp(start.z, end.z, t);

            return lerp;
        }

        public void SetPlayer(PlayerMovement player)
        {
            _playerMovement = player;
            _playerMovement.OnMove = MoveCamera;
            lastPoint = transform.position + _offset;
        }
    }
}

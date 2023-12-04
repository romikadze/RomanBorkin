using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _force;
    private Coroutine _moveTick;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void StartMove(Transform target, float step)
    {
        if (_moveTick != null) StopMove();

        _moveTick = StartCoroutine(MoveTick(target, step));
    }

    public void StopMove()
    {
        if (_moveTick == null) return;

        StopCoroutine(_moveTick);
        _moveTick = null;
    }

    private void Move(Vector3 direction)
    {
        _rigidbody.AddForce(direction * _force, ForceMode.Impulse);
        direction = new Vector3(direction.z, 0, -direction.x);
        _rigidbody.AddTorque(direction * _force, ForceMode.Impulse);
    }

    private Vector3 CalculateDirection(Vector3 targetPosition, out bool isDiagonal)
    {
        Vector3 positionDifference = (targetPosition - transform.position).normalized;


        if (Mathf.Abs(Mathf.Abs(positionDifference.x) - Mathf.Abs(positionDifference.z)) < 0.015f)
            isDiagonal = true;
        else
            isDiagonal = false;

        return Mathf.Abs(positionDifference.x) > Mathf.Abs(positionDifference.z) ? (Vector3.right * positionDifference.x).normalized : (Vector3.forward * positionDifference.z).normalized;
    }

    private IEnumerator MoveTick(Transform target, float step)
    {
        float stepMultiplier = 1;
        while (true)
        {
            yield return new WaitForSeconds(step * stepMultiplier);

            Move(CalculateDirection(target.position, out bool isDiagonal));
            if (isDiagonal)
            {
                stepMultiplier = 0.3f;
            }
            else
            {
                stepMultiplier = 1f;
            }
        }
    }
}

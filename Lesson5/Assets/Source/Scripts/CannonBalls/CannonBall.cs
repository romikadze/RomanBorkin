using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private float _shootForce;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(transform.forward * _shootForce, ForceMode.Impulse);
    }

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    public void SetShootForce(float value)
    {
        _shootForce = value;
    }
}

using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public Action<Vector3, Vector3> OnMove;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private Rigidbody _rigidbody;
    Vector3 moveDirection = Vector3.zero;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        OnMove?.Invoke(transform.position, _rigidbody.velocity);
    }

    private void Move()
    {
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.z = Input.GetAxis("Vertical");
        moveDirection *= _speed;
        
        _rigidbody.velocity = new Vector3(moveDirection.x, _rigidbody.velocity.y, moveDirection.z);
        OnMove?.Invoke(transform.position, _rigidbody.velocity);
    }
}

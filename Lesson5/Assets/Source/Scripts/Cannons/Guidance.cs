using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guidance : MonoBehaviour
{
    [SerializeField] private Transform _gunBarrel;
    [SerializeField] private float _rotationSpeed = 0.2f;
    private float _rotationX = 0;
    private float _rotationY = 0;
    private float _rotationMultiplier = 1;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        _rotationX += Input.GetAxis("Horizontal") * _rotationSpeed * _rotationMultiplier;
        _rotationY += Input.GetAxis("Vertical") * _rotationSpeed * _rotationMultiplier;
        _rotationX = Mathf.Clamp(_rotationX, -45f, 45f);
        _rotationY = Mathf.Clamp(_rotationY, -5f, 15f);

        _gunBarrel.Rotate(_rotationX, _rotationY, 0);
        _gunBarrel.rotation = Quaternion.Euler(-_rotationY, _rotationX, 0);
    }

    public void InverseRotation()
    {
        _rotationMultiplier *= -1;
    }
}

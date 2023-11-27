using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotRubber : MonoBehaviour
{
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _launchForce;
    private Bird _bird;
    private Vector2 _startPosition;
    private Camera _camera;
    private bool _isCanShoot;

    public Action OnShoot;

    private void Awake()
    {
        _camera = Camera.main;
        _startPosition = transform.position;
    }

    public void UpdateBird(Bird bird)
    {
        _bird = bird;
        _bird.OnReadyToLaunch += () => _isCanShoot = true;
    }

    private void OnMouseDrag()
    {
        if (!_isCanShoot)
            return;
        {

        }
        Vector2 target = _camera.ScreenToWorldPoint(Input.mousePosition);

        if (Vector2.Distance(_startPosition, target) < _maxDistance)
        {
            transform.position = target;
        }
        else
        {
            Vector2 direction = (target - _startPosition).normalized * _maxDistance;
            transform.position = _startPosition + direction;
        }
    }

    private void OnMouseUp()
    {
        if (!_isCanShoot)
            return;
        _isCanShoot = false;
        Vector2 releasePosition = transform.position;
        transform.position = _startPosition;
        Vector2 delta = _startPosition - releasePosition;
        _bird.Launch(delta * _launchForce);
        _bird = null;
        OnShoot?.Invoke();
    }
}

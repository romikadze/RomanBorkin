using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCannon : MonoBehaviour
{
    [SerializeField] private protected Transform _shotPoint;
    [SerializeField] private protected GameObject _cannonBall;

    [Header("Fire Options")]
    [SerializeField] private protected float _reloadDelay;
    [SerializeField] private protected float _fireDelay;
    [SerializeField] private protected int _maxAmmo;

    private protected int _currentAmmo;
    private protected bool _isReadyToFire = true;
    private protected Coroutine _reloading;

    public Action<int, int> OnAmmoChange;

    private void Awake()
    {
        _currentAmmo = _maxAmmo;
    }

    private void OnEnable()
    {
        OnAmmoChange?.Invoke(_currentAmmo, _maxAmmo);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && _isReadyToFire && _currentAmmo > 0)
            Shoot();

        if (Input.GetKey(KeyCode.R) && _reloading == null)
            _reloading = StartCoroutine(Reloading());
    }

    private protected virtual void Shoot()
    {
        Instantiate(_cannonBall, _shotPoint.position, _shotPoint.rotation);
        _isReadyToFire = false;
        _currentAmmo--;
        OnAmmoChange?.Invoke(_currentAmmo, _maxAmmo);
        StartCoroutine(FireDelay());
    }

    private protected IEnumerator FireDelay()
    {

        yield return new WaitForSeconds(_fireDelay);
        _isReadyToFire = true;
    }

    private IEnumerator Reloading()
    {
        while (_currentAmmo < _maxAmmo)
        {
            yield return new WaitForSeconds(_reloadDelay);
            _currentAmmo++;
            OnAmmoChange?.Invoke(_currentAmmo, _maxAmmo);
        }
        _reloading = null;
    }
}

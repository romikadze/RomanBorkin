using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperCannon : BasicCannon
{
    private protected override void Shoot()
    {
        Instantiate(_cannonBall, _shotPoint.position, _shotPoint.rotation);
        _isReadyToFire = false;
        _currentAmmo--;
        OnAmmoChange?.Invoke(_currentAmmo, _maxAmmo);
        StartCoroutine(FireDelay());
    }
}

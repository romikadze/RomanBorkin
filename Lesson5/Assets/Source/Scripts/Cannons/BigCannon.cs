using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCannon : BasicCannon
{
    private protected override void Shoot()
    {
        GameObject cannonBall = Instantiate(_cannonBall, _shotPoint.position, _shotPoint.rotation);
        cannonBall.transform.localScale = Vector3.one * 3;
        _isReadyToFire = false;
        _currentAmmo--;
        _cannonUI.UpdateAmmo(_currentAmmo, _maxAmmo);
        StartCoroutine(FireDelay());
    }
}

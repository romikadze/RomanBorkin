using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperCannon : BasicCannon
{
    private protected override void Shoot()
    {
        GameObject cannonBall = Instantiate(_cannonBall, _shotPoint.position, _shotPoint.rotation);
        cannonBall.transform.localScale = Vector3.one * 0.75f;
        cannonBall.GetComponent<Rigidbody>().AddForce(Vector3.forward * 30, ForceMode.Impulse);
        _isReadyToFire = false;
        _currentAmmo--;
        _cannonUI.UpdateAmmo(_currentAmmo, _maxAmmo);
        StartCoroutine(FireDelay());
    }
}

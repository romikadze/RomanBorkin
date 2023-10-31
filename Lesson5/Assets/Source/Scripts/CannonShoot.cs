using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private GameObject _cannonBall;
    [SerializeField] private int _maxAmmo = 5;
    private int _currentAmmo = 0;
    private bool _isReadyToFire = true;
    private bool _isReadyToReload = true;

    private void Start()
    {
        ChangeAmmo(_maxAmmo);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && _isReadyToFire && _currentAmmo > 0)
            Shot();

        if (Input.GetKey(KeyCode.R) && _isReadyToReload)
            StartCoroutine(Reload());
    }

    private void Shot()
    {
        Instantiate(_cannonBall, _shotPoint.position, _shotPoint.rotation);
        _isReadyToFire = false;
        StartCoroutine(ShotCooldown());
    }

    private void ChangeAmmo(int increment)
    {
        _currentAmmo += increment;
        UIManager.Instance.UpdateAmmoText(_currentAmmo, _maxAmmo);
    }

    private IEnumerator ShotCooldown()
    {
        ChangeAmmo(-1);
        yield return new WaitForSeconds(0.5f);
        _isReadyToFire = true;
    }

    private IEnumerator Reload()
    {
        _isReadyToReload = false;
        _isReadyToFire = false;
        while (_currentAmmo < _maxAmmo)
        {
            yield return new WaitForSeconds(1);
            ChangeAmmo(1);
        }
        _isReadyToFire = true;
        _isReadyToReload = true;
    }
}

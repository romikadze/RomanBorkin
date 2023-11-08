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
    private Coroutine _reloading;
    private CannonUI _cannonUI;

    private void Awake()
    {
        _cannonUI = FindObjectOfType<CannonUI>();
    }
    private void Start()
    {
        _currentAmmo = _maxAmmo;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && _isReadyToFire && _currentAmmo > 0)
            Shot();

        if (Input.GetKey(KeyCode.R) && _reloading == null)
            _reloading = StartCoroutine(Reloading());
    }

    private void Shot()
    {
        Instantiate(_cannonBall, _shotPoint.position, _shotPoint.rotation);
        _isReadyToFire = false;
        _currentAmmo--;
        _cannonUI.UpdateAmmo(_currentAmmo, _maxAmmo); 
        StartCoroutine(FireDelay());
    }


    private IEnumerator FireDelay()
    {
        
        yield return new WaitForSeconds(0.5f);
        _isReadyToFire = true;
    }

    private IEnumerator Reloading()
    {
        while (_currentAmmo < _maxAmmo)
        {
            yield return new WaitForSeconds(1);
            _currentAmmo++;
            _cannonUI.UpdateAmmo(_currentAmmo, _maxAmmo);
        }
        _reloading = null;
    }
}

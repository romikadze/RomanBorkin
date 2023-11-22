using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSwitcher : MonoBehaviour
{
    [SerializeField] private BasicCannon _basicCannon;
    [SerializeField] private SniperCannon _sniperCannon;
    [SerializeField] private BigCannon _bigCannon;

    private BasicCannon _currentCannon;

    public Action<int, int> OnAmmoChange;

    private void Awake()
    {
        _currentCannon = _basicCannon;
        _basicCannon.OnAmmoChange += AmmoChange;
        _sniperCannon.OnAmmoChange += AmmoChange;
        _bigCannon.OnAmmoChange += AmmoChange;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _currentCannon.gameObject.SetActive(false);
            _currentCannon = _basicCannon;
            _currentCannon.gameObject.SetActive(true);
        }   
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _currentCannon.gameObject.SetActive(false);
            _currentCannon = _sniperCannon;
            _currentCannon.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _currentCannon.gameObject.SetActive(false); 
            _currentCannon = _bigCannon;
            _currentCannon.gameObject.SetActive(true);
        }
    }

    private void AmmoChange(int currentAmmo, int maxAmmo)
    {
        OnAmmoChange?.Invoke(currentAmmo, maxAmmo);
    }
}

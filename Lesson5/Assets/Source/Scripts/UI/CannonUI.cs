using System;
using TMPro;
using UnityEngine;

public class CannonUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _targetHitsText;
    [SerializeField] private TextMeshProUGUI _ammoText;
    [SerializeField] private TargetSpawner _targetSpawner;
    [SerializeField] private CannonSwitcher _cannonSwitcher;

    private int _points = 0;

    private void Awake()
    {
        _cannonSwitcher.OnAmmoChange += UpdateAmmo;
        _targetSpawner.OnTargetHit += UpdateTargetHits;
    }
    public void UpdateTargetHits(int points)
    {
        _points+= points;
        _targetHitsText.text = "Points: " + _points;
    }

    public void UpdateAmmo(int currentAmmo, int maxAmmo)
    {
        _ammoText.text = "Ammo: " + currentAmmo + "/" + maxAmmo;
    }
}

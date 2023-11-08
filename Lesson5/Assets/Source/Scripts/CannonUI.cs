using System;
using TMPro;
using UnityEngine;

public class CannonUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _targetHitsText;
    [SerializeField] private TextMeshProUGUI _ammoText;
    private int _hits = 0;

    public void UpdateTargetHits()
    {
        _hits++;
        _targetHitsText.text = "Hits: " + _hits;
    }

    public void UpdateAmmo(int currentAmmo, int maxAmmo)
    {
        _ammoText.text = "Ammo: " + currentAmmo + "/" + maxAmmo;
    }
}

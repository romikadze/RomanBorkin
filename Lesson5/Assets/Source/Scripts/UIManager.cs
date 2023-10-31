using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TextMeshProUGUI _targetHitsText;
    [SerializeField] private TextMeshProUGUI _ammoText;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateTargetHitsText()
    {
        _targetHitsText.text = "Hits: " + SceneData.Instance.GetHitsCount().ToString();
    }

    public void UpdateAmmoText(int currentAmmo, int maxAmmo)
    {
        _ammoText.text = "Ammo: " + currentAmmo + "/" + maxAmmo;
    }
}

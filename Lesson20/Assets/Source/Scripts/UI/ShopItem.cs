using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Source.Scripts.UI
{
    public class ShopItem : MonoBehaviour
    {
        public Action OnUpgrade;
        [SerializeField] private TextMeshProUGUI _upgradeCostText;
        [SerializeField] private TextMeshProUGUI _upgradeIncrementText;
        [SerializeField] private Button _upgradeButton;
        private float _upgradeCost;
        private float _upgradeIncrement;

        private float UpgradeCost
        {
            get => _upgradeCost;
            set
            {
                value = Mathf.Round(value * 100) / 100f;
                _upgradeCost = value;
            }
        }

        private float UpgradeIncrement
        {
            get => _upgradeIncrement;
            set
            {
                value = Mathf.Round(value * 100) / 100f;
                _upgradeIncrement = value;
            }
        }

        private int _upgradeItemLevel = 0;
        private int _itemTier;
        private bool _isAuto;

        private ClickerStats _clickerStats;

        private void Upgrade()
        {
            if (!_clickerStats.ReduceMoney(UpgradeCost)) return;

            _upgradeItemLevel++;
            UpgradeIncrement *= 1.1f;
            UpgradeCost *= 1.15f;

            if (_isAuto)
                _clickerStats.AddDamagePerSecond(UpgradeIncrement);
            else
                _clickerStats.AddDamagePerClick(UpgradeIncrement);

            if (_upgradeItemLevel == 10)
                OnUpgrade?.Invoke();
            
            UpdateUI();
        }

        private void UpdateUI()
        {
            _upgradeCostText.text = UpgradeCost.ToString();
            _upgradeIncrementText.text = UpgradeIncrement.ToString();
        }

        public void SetupShopItem(ClickerStats clickerStats, int itemTier, bool isAuto)
        {
            _isAuto = isAuto;
            _clickerStats = clickerStats;
            _itemTier = itemTier;
            if (_isAuto)
            {
                UpgradeIncrement = (_itemTier * _itemTier) / 3f;
                UpgradeCost = 25 * _itemTier;
            }
            else
            {
                UpgradeIncrement = _itemTier * _itemTier;
                UpgradeCost = 15 * _itemTier;
            }

            _upgradeButton.onClick.AddListener(Upgrade);
            UpdateUI();
        }
    }
}
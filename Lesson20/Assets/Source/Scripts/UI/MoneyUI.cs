using System;
using TMPro;
using UnityEngine;

namespace Source.Scripts.UI
{
    public class MoneyUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyText;
        [SerializeField] private ClickerStats _clickerStats;
        private void Awake()
        {
            _clickerStats.OnMoneyChange += UpdateMoneyText; 
        }

        public void UpdateMoneyText(float money)
        {
            _moneyText.text = money.ToString();
        }
    }
}

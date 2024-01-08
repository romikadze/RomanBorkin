using System;
using UnityEngine;

namespace Source.Scripts.UI
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private ShopItem _shopItem;
        [SerializeField] private Transform _scrollViewContent;
        [SerializeField] private ClickerStats _clickerStats;
        private int _shopItemTier = 1;
        private bool _isNextShopItemAuto = false;
        private void Start()
        {
            CreateShopItem();
        }

        private void CreateShopItem()
        {
            ShopItem shopItem = Instantiate(_shopItem, _scrollViewContent);
            shopItem.SetupShopItem(_clickerStats, _shopItemTier, _isNextShopItemAuto);
            shopItem.OnUpgrade += CreateShopItem;
            _isNextShopItemAuto = !_isNextShopItemAuto;
            _shopItemTier++;
        }
    }
}

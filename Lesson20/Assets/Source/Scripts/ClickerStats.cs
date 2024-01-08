using System;
using UnityEngine;

namespace Source.Scripts
{
    public class ClickerStats : MonoBehaviour
    {
        public Action<float> OnMoneyChange;
        public Action<float> OnDamagePerClickChange;
        public Action<float> OnDamagePerSecondChange;
        [field: SerializeField] public float DamagePerClick { get; private set; }
        [field: SerializeField] public float DamagePerSecond { get; private set; }
        [field: SerializeField] public float DifficultyMultiplier { get; private set; }
        [field: SerializeField] public float Money { get; private set; }

        private float ChangeFloorValue(float value, float amount)
        {
            return Mathf.Round((value + amount) * 100) / 100f;
        }

        public void AddDamagePerClick(float amount)
        {
            DamagePerClick = ChangeFloorValue(DamagePerClick, amount);
            OnDamagePerClickChange?.Invoke(DamagePerClick);
        }
    
        public void AddDamagePerSecond(float amount)
        {
            DamagePerSecond = ChangeFloorValue(DamagePerSecond, amount);
            OnDamagePerSecondChange?.Invoke(DamagePerSecond);
        }
    
        public void AddDifficultyMultiplier(float amount)
        {
            if(amount < 0) return;
            DifficultyMultiplier = ChangeFloorValue(DifficultyMultiplier, amount);
        } 
        
        public void AddMoney(float amount)
        {
            if(amount < 0) return;
            Money = ChangeFloorValue(Money, amount);
            OnMoneyChange?.Invoke(Money);
        } 
        
        public bool ReduceMoney(float amount)
        {
            if(amount < 0 || amount > Money) return false;
            Money = ChangeFloorValue(Money, -amount);
            OnMoneyChange?.Invoke(Money);
            return true;
        } 
    }
}

using System;
using UnityEngine;

namespace Source.Scripts
{
    public class ClickBody : MonoBehaviour
    {
        public Action<float, float> OnHpChanged;
        public Action OnDestroyed;
        
        [SerializeField] private float _scaleDownFactor = 0.95f;
        [SerializeField] private float _baseHp;
        [SerializeField] private float _baseDestroyMoney;
        [SerializeField] private float _baseDamageMoney;
        private Vector3 _originalScale;
        private float _destroyMoney;
        private float _damageMoney;
        private float _maxHp;
        private float _currentHp;
        
        private float Destroy()
        {
            OnDestroyed?.Invoke();
            Destroy(gameObject, Time.deltaTime);
            return _destroyMoney;
        }
        
        public float Damage(float damage)
        {
            if (damage <= 0) return 0;
            
            _currentHp -= damage;
            if (_currentHp <= 0) return Destroy();
            
            transform.localScale = _originalScale * _scaleDownFactor;
            OnHpChanged?.Invoke(_currentHp, _maxHp);
            return _damageMoney;
        }
        
        public void EndClick()
        {
            transform.localScale = _originalScale;
        }
        
        public void SetClickerStats(ClickerStats clickerStats)
        {
            _maxHp = _baseHp * clickerStats.DifficultyMultiplier;
            _destroyMoney = _baseDestroyMoney * clickerStats.DifficultyMultiplier/10f;
            _damageMoney = _baseDamageMoney * clickerStats.DifficultyMultiplier/10f;
            _currentHp = _maxHp;
            _originalScale = transform.localScale;
            
            OnHpChanged?.Invoke(_currentHp, _maxHp);
        }
    }
}

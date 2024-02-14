using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 0.5f;
    private float _hp = 10f;
    public Player _player;
    public Action OnDie;

    private void Update()
    {
        Move((_player.transform.position - transform.position).normalized);
    }

    private void Move(Vector2 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime);
    }
    
    public Enemy Setup(Player player)
    {
        _player = player;
        return this;
    }

    public void TakeDamage(float amount)
    {
        _hp -= amount;

        if (_hp <= 0)
        {
            OnDie?.Invoke();
            Destroy(gameObject);
        }
    }
}
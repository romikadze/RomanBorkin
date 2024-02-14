using System.Collections;
using UnityEngine;
using Source.Scripts;

public class Player : MonoBehaviour
{
    private float _speed = 5;
    private float _attackRadius = 5;
    private Vector2 _input;
    public Enemy _enemy;
    private Locator _locator;

    private void Awake()
    {
        _locator = GetComponentInChildren<Locator>();
        _locator.OnEnemyFound += SetEnemy;
    }

    private void Start()
    {
        _locator.enabled = true;
    }

    private void Update()
    {
        _input.x = Input.GetAxis("Horizontal");
        _input.y = Input.GetAxis("Vertical");

        Move(_input);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shot();
        }
    }

    private void Move(Vector2 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void SetEnemy(Enemy enemy)
    {
        _enemy = enemy;
        _enemy.OnDie += FindNewEnemy;
    }

    private void FindNewEnemy()
    {
        _locator.enabled = true;
    }

    private void Shot()
    {
        if (_enemy)
            _enemy.TakeDamage(5f);
    }
}
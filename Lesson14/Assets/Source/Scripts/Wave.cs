using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private float _enemyMoveTick;
    [SerializeField] private Transform _player;

    private UnitFabric _unitFabric;
    private List<Enemy> _enemies = new List<Enemy>();


    private int _spawnSquareLenght = 40;

    private void Awake()
    {
        _unitFabric = GetComponent<UnitFabric>();
    }

    private void Start()
    {
        CreateWave();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            StartMoveEnemies();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StopMoveEnemies();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateWave();
        }
    }

    private void CreateWave()
    {
        for (int i = 0; i < 30; i++)
        {
            _enemies.Add(_unitFabric.CreateNewEnemy(GetRandomPosition()));
        }
    }

    private void StartMoveEnemies()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.StartMove(_player, _enemyMoveTick + Random.Range(-0.2f, 0.2f));
        }
    }

    private void StopMoveEnemies()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.StopMove();
        }
    }

    private Vector3 GetRandomPosition()
    {
        int isHorizontal = Random.Range(0, 2);
        int xPosition = _spawnSquareLenght * isHorizontal + Random.Range(0, _spawnSquareLenght + 1) * (1 - isHorizontal);
        xPosition *= Random.Range(0, 2) == 0 ? 1 : -1;
        int zPosition = _spawnSquareLenght * (1 - isHorizontal) + Random.Range(0, _spawnSquareLenght + 1) * isHorizontal;
        zPosition *= Random.Range(0, 2) == 0 ? 1 : -1;

        return new Vector3(xPosition, 0.5f, zPosition);
    }
}

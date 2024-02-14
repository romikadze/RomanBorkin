using UnityEngine;

public class Entry : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private EnemyFactory _enemyFactory;
    
    private void Start()
    {
        _enemyFactory.Setup(_enemyPrefab, Instantiate(_playerPrefab));
    }
}
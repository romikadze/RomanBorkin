using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    private Enemy _enemy;
    private Player _player;
    private int _maxSpawned = 10;

    private void Spawn()
    {
        Instantiate(_enemy, GetRandomSpawnPosition(), Quaternion.identity)
            .Setup(_player)
            .OnDie += Spawn;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0);
    }

    public void Setup(Enemy enemy, Player player)
    {
        _enemy = enemy;
        _player = player;

        for (int i = 0; i < _maxSpawned; i++)
        {
            Spawn();
        }
    }
}
using UnityEngine;

public class UnitFabric : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    public Enemy CreateNewEnemy(Vector3 position)
    {
        return Instantiate(_enemy, position, Quaternion.identity);
    }
}

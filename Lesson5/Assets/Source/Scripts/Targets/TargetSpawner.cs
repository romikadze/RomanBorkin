using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private Transform _targetPositions;
    [SerializeField] private Transform[] _targetTranforms;

    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            SpawnTarget();
        }
    }

    public void SpawnTarget()
    {
        int row, column, depth;
        do
        {
            depth = Random.Range(0, 2);
            column = Random.Range(0, 3);
            row = Random.Range(0, 3);
        }
        while (_targetPositions.GetChild(depth).GetChild(column * 3 + row).childCount != 0);

        Instantiate(_targetTranforms[Random.Range(0, _targetTranforms.Length)], _targetPositions.GetChild(depth).GetChild(column * 3 + row));
    }
}

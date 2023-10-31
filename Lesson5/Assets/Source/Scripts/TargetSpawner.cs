using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private Transform _targetPositions;
    [SerializeField] private Transform _targetTranform;

    private void Start()
    {
        SpawnTargetInRandomPosition();
        SpawnTargetInRandomPosition();
        SpawnTargetInRandomPosition();
        SpawnTargetInRandomPosition();
    }

    public void SpawnTargetInRandomPosition()
    {
        int row, column, depth;
        do
        {
            depth = Random.Range(0, 2);
            column = Random.Range(0, 3);
            row = Random.Range(0, 3);
        }
        while (_targetPositions.GetChild(depth).GetChild(column * 3 + row).childCount != 0);

        Instantiate(_targetTranform, _targetPositions.GetChild(depth).GetChild(column * 3 + row));
    }
}

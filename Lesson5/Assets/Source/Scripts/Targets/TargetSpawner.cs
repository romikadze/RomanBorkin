using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private Transform _targetPositions;
    [Header("Target prefabs")]
    [SerializeField] private GameObject _basicTargetTranform;
    [SerializeField] private GameObject _colorTargetTranform;
    [SerializeField] private GameObject _inverseTargetTranform;

    public Action<int> OnTargetHit;

    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            SpawnRandomTarget();
        }
    }

    public void SpawnRandomTarget()
    {
        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0: SpawnBasicTarget(); break;
            case 1: SpawnColorTarget(); break;
            case 2: SpawnInverseTarget(); break;
        }
    }

    public void SpawnBasicTarget()
    {
        SpawnTarget(_basicTargetTranform);
    }

    public void SpawnColorTarget()
    {
        SpawnTarget(_colorTargetTranform);
    }

    public void SpawnInverseTarget()
    {
        SpawnTarget(_inverseTargetTranform);
    }

    private void SpawnTarget(GameObject target)
    {
        GetAvaiblePosition(out int xy, out int z);
        BasicTarget newTarget = Instantiate(target, _targetPositions.GetChild(z).GetChild(xy)).GetComponent<BasicTarget>();
        newTarget.OnTargetHit += TargetHit;
        newTarget.OnTargetDestroy += SpawnRandomTarget;
    }

    private void GetAvaiblePosition(out int xy, out int z)
    {
        do
        {
            z = UnityEngine.Random.Range(0, 2);
            xy = UnityEngine.Random.Range(0, 3);
        }
        while (_targetPositions.GetChild(z).GetChild(xy).childCount != 0);
    }

    private void TargetHit(int points)
    {
        OnTargetHit?.Invoke(points);
    }
}

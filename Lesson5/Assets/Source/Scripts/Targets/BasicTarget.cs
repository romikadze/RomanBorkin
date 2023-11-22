using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTarget : MonoBehaviour
{
    [SerializeField] private int _hitsToDestroy;
    [SerializeField] private int _points;

    public Action<int> OnTargetHit;
    public Action OnTargetDestroy;

    private protected virtual void Hit()
    {
        OnTargetHit?.Invoke(_points);
    }

    private void DestroyTarget()
    {
        OnTargetDestroy?.Invoke();
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Hit();
        _hitsToDestroy--;
        if (_hitsToDestroy == 0)
            DestroyTarget();
    }
}

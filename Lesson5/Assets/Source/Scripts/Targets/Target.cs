using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int _hitsToDestroy;
    private TargetSpawner _spawner;
    private CannonUI _cannonUI;


    private void Awake()
    {
        _spawner = FindObjectOfType<TargetSpawner>();
        _cannonUI = FindObjectOfType<CannonUI>();
    }

    private protected virtual void Hit()
    {
        _cannonUI.UpdateTargetHits();
        _hitsToDestroy--;
        if (_hitsToDestroy == 0)
            Respawn();

    }

    private void Respawn()
    {
        _spawner.SpawnTarget();
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Hit();
    }
}

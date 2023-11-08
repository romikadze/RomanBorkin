using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private TargetSpawner _spawner;
    private CannonUI _cannonUI;

    private void Awake()
    {
        _spawner = FindObjectOfType<TargetSpawner>();
        _cannonUI = FindObjectOfType<CannonUI>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _cannonUI.UpdateTargetHits();
        _spawner.SpawnTargetInRandomPosition();
        Destroy(gameObject);  
    }
}

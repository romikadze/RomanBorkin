using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private TargetSpawner _spawner;

    private void Start()
    {
        _spawner = FindObjectOfType<TargetSpawner>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        SceneData.Instance.IncreaseHitsCount();
        _spawner.SpawnTargetInRandomPosition();
        Destroy(gameObject);  
    }
}

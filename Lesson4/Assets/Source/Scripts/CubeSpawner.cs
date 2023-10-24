using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Transform _cubePrefab;
    [SerializeField] private float _mapSizeXZ = 20;
    [SerializeField] private int _maxEnemies = 3;

    //Game starts with player and 3 enemies
    private void Start()
    {
        SpawnCube(true);
        SpawnCube(true);
        SpawnCube(true);
        SpawnCube(false);
        StartCoroutine(SpawnCoroutine());
    }

    //Spawn new cube in random position
    private void SpawnCube(bool isEnemy)
    {
        float x = Random.Range(-_mapSizeXZ, _mapSizeXZ);
        float z = Random.Range(-_mapSizeXZ, _mapSizeXZ);

        Transform cube = Instantiate(_cubePrefab, new Vector3(x, 0.5f, z), Quaternion.identity);

        if (isEnemy) 
            cube.AddComponent<EnemyController>();
        else
        {
            cube.AddComponent<PlayerController>();
            cube.AddComponent<CameraController>();
            cube.GetComponent<MeshRenderer>().material.color = new Color(0.5f, 0.25f, 0.5f);
        }
    }

    //Every 10 seconds checks for player and enemies. Spawn if someone dies
    private IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(10);
        StartCoroutine(SpawnCoroutine());

        if (FindObjectsOfType<PlayerController>().Length == 0)
            SpawnCube(false);
        if (FindObjectsOfType<EnemyController>().Length < _maxEnemies)
            SpawnCube(true);
    }
}

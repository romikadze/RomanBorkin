using System.Collections;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private Transform _foodPrefab;
    [SerializeField] private float _spawnRate = 2.5f;

    private void Start()
    {
        StartCoroutine(SpawnFoodCoroutine());
    }

    //Spawn timer
    private IEnumerator SpawnFoodCoroutine()
    {
        yield return new WaitForSeconds(_spawnRate);
        SpawnFood();
        StartCoroutine(SpawnFoodCoroutine());
    }

    //Spawn food in random position on the map
    private void SpawnFood()
    {
        float x = Random.Range(-25, 25);
        float z = Random.Range(-25, 25);

        Instantiate(_foodPrefab, new Vector3(x, 0.25f, z), Quaternion.identity);
    }
}

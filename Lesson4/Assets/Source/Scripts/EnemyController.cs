using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private List<Transform> foodTargets = new List<Transform>();
    private List<Transform> enemyTargets = new List<Transform>();
    private Vector3 direction = Vector3.zero;
    private float _speed;
    private float _enemyBrainSpeed = 0.8f;

    private void Start()
    {
        UpdateSpeed();
        StartCoroutine(UpdateTargetsCoroutine());
        GetComponent<Cube>().scoreChanged += UpdateSpeed;
    }

    //Movement
    private void Update()
    {
        Move(direction);

        if (transform.position.y < -5)
        {
            float x = Random.Range(-15, 15);
            float z = Random.Range(-15, 15);

            transform.position = new Vector3(x, 1, z);
        }
    }

    //Update cube speed
    private void UpdateSpeed()
    {
        _speed = GetComponent<Cube>().GetSpeed();
    }
    
    //Move cube in necessary direction
    private void Move(Vector3 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
    }

    //Enemy brain is working with constant speed
    private IEnumerator UpdateTargetsCoroutine()
    {
        yield return new WaitForSeconds(_enemyBrainSpeed);
        UpdateTargets();
        StartCoroutine(UpdateTargetsCoroutine());

    }

    //Update food and enemies data
    private void UpdateTargets()
    {
        var food = FindObjectsOfType<Food>();
        var enemies = FindObjectsOfType<Cube>();
        foodTargets.Clear();
        foreach (var item in food)
        {
            foodTargets.Add(item.transform);
        }

        enemyTargets.Clear();
        foreach (var item in enemies)
        {
            if(item.gameObject != gameObject)
            enemyTargets.Add(item.transform);
        }

        CalculateDistances();
    }

    //Calculate distances and set target
    private void CalculateDistances()
    {
        float distance = 100;
        Vector3 nearestTargetDirection = Vector3.zero;

        //Find food
        foreach (var target in foodTargets)
        {
            if (distance > (target.position - transform.position).magnitude)
            {
                nearestTargetDirection = target.position - transform.position;
                distance = nearestTargetDirection.magnitude;
            }
        }
        //Find enemies (priority)
        foreach (var target in enemyTargets)
        {
            if (distance > (target.position - transform.position).magnitude)
            {
                //If enemy is weak => chase
                nearestTargetDirection = target.position - transform.position;
                distance = nearestTargetDirection.magnitude;
                //If enemy is strong => run away
                if (target.GetComponent<Cube>().GetScore() > GetComponent<Cube>().GetScore())
                    nearestTargetDirection *= -1;
            }
        }
        direction = nearestTargetDirection.normalized;
    }
}

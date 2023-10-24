using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _enemyColorUpdateRate = 2f;
    private float _inputX;
    private float _inputZ;
    private float _speed;

    private void Start()
    {
        UpdateSpeed();
        GetComponent<Cube>().scoreChanged += UpdateSpeed;
        StartCoroutine(UpdateEnemyColorsCoroutine());
    }

    //Keyboard movement
    private void FixedUpdate()
    {
        _inputX = Input.GetAxis("Horizontal");
        _inputZ = Input.GetAxis("Vertical");
        Vector3 translation = new Vector3(_inputX, 0, _inputZ) * _speed * Time.deltaTime;
        transform.Translate(translation, Space.World);

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

    //Update enemy colors timer
    private IEnumerator UpdateEnemyColorsCoroutine()
    {
        yield return new WaitForSeconds(_enemyColorUpdateRate);
        UpdateEnemyColors();
        StartCoroutine(UpdateEnemyColorsCoroutine());
    }

    //Change enemy color using player/enemy score ratio
    private void UpdateEnemyColors()
    {
        Cube playerCube = GetComponent<Cube>();
        var enemies = FindObjectsOfType<Cube>();
        foreach (var enemy in enemies)
        {
            if (enemy.gameObject == gameObject) continue;

            if (enemy.GetScore() < playerCube.GetScore() - 0.15)
                enemy.GetComponent<MeshRenderer>().material.color = new Color(0.15f, 0.55f, 0.25f);
            else if(enemy.GetScore() > playerCube.GetScore() + 0.15)
                enemy.GetComponent<MeshRenderer>().material.color = new Color(0.55f, 0.15f, 0.15f);
            else
                enemy.GetComponent<MeshRenderer>().material.color = new Color(0.55f, 0.4f, 0.15f);

        }
    }
}

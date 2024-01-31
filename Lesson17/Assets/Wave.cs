using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private Material _wave;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            _wave.SetFloat("Speed", 50);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            _wave.SetFloat("Speed", 1);
        }
    }
}

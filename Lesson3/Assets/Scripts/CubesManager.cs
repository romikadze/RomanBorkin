using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesManager : MonoBehaviour
{
    private CubeController[] _cubeControllers;

    // Start is called before the first frame update
    void Start()
    {
        _cubeControllers = FindObjectsOfType<CubeController>();
        StartCoroutine(JumpCoroutine());
    }

    private IEnumerator JumpCoroutine()
    {
        yield return new WaitForSeconds(1);
        foreach (CubeController c in _cubeControllers)
        {
            if (Random.Range(0, 2) == 1)
            {
                c.Jump();
                c.ChangeColor();
            }

        }
        StartCoroutine(JumpCoroutine());
    }
}

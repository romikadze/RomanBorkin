using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public void Jump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * 3, ForceMode.VelocityChange);
    }

    public void ChangeColor()
    {
        Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
        GetComponent<MeshRenderer>().material.color = color;
    }
}

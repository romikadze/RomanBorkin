using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private float _scoreIncrease = 0.01f;

    //Increase cube score and destroy food gameObject
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            collision.gameObject.GetComponent<Cube>().ChangeScore(_scoreIncrease);
            Destroy(gameObject);
        }
    }
}

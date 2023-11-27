using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Wall
{
    private protected override void CalculateCollideForce(Collider2D collision)
    {
        base.CalculateCollideForce(collision);
        if (collision.gameObject.GetComponent<Chuck>())
        {
            Damage(_collideForce, 2);
            collision.attachedRigidbody.AddForce(-collision.attachedRigidbody.velocity * 1.2f, ForceMode2D.Impulse);
        }
    }
}

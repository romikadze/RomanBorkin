using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : Wall
{
    private protected override void Hit(Collision2D collision)
    {
        Damage(_collideForce, 0.8f);
    }
}

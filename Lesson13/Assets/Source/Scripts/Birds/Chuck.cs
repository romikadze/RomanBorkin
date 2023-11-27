using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chuck : Bird
{
    [SerializeField] private float _speedUpForce = 40f;

    private protected override void UseAbility()
    {
        SpeedUp();
    }

    private void SpeedUp()
    {
        _rigidbody2D.AddForce(_rigidbody2D.velocity.normalized * _speedUpForce, ForceMode2D.Impulse);
        _isCanUseAbility = false;
    }
}

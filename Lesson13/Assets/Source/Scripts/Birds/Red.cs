using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : Bird
{
    private protected override void UseAbility()
    {
        GetAngry();
    }

    private void GetAngry()
    {
        _rigidbody2D.mass *= 1.25f;
        _isCanUseAbility = false;
    }
}

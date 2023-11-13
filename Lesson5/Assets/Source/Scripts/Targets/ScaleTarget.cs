using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTarget : Target
{
    private protected override void Hit()
    {
        base.Hit();
        StartCoroutine(HitEffectTick());
    }

    private IEnumerator HitEffectTick()
    {
        transform.localScale = Vector3.one * 1.25f;
        yield return new WaitForSeconds(0.2f);
        transform.localScale = Vector3.one;
    }
}

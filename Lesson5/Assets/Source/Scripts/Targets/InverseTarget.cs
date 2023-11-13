using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseTarget : Target
{
    private protected override void Hit()
    {
        base.Hit();
        GetComponent<Renderer>().material.color = GetRandomColor();
        InversePlayerRotation();
    }

    private Color GetRandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
    }

    private void InversePlayerRotation()
    {
        Guidance playerCannon = FindObjectOfType<Guidance>();
        playerCannon.InverseRotation();

    }
}

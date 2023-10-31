using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour
{
    public static SceneData Instance;

    private int _targetHits = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void IncreaseHitsCount()
    {
        _targetHits++;
        UIManager.Instance.UpdateTargetHitsText();
    }

    public int GetHitsCount()
    {
        return _targetHits;
    }
}

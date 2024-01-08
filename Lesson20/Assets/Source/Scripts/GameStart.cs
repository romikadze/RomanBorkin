using System;
using System.Collections;
using System.Collections.Generic;
using Source.Scripts;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private ClickFactory _clickFactory;
    [SerializeField] private ClickerStats _clickerStats;
    [SerializeField] private Clicker _clicker;

    private void Start()
    {
        StartGame();
        _clickerStats.AddDifficultyMultiplier(1);
    }

    private void StartGame()
    {
        _clickFactory.StartFactory(_clickerStats);
        _clicker.StartClicker(_clickerStats);
    }
}

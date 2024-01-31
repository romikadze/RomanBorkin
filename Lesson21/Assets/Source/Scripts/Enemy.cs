using System;
using System.Collections;
using System.Collections.Generic;
using Source.Scripts.Core;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IEntryPointSetupPlayer
{
    private Transform _player;
    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_player == null)
            return;
        _navMeshAgent.SetDestination(_player.position);
    }

    public void Setup(PlayerMovement player)
    {
        _player = player.transform;
    }
}

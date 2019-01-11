using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class UnitMotor : MonoBehaviour
{
    public bool IsWalk { get; set; }
    public NavMeshAgent Agent { get; set; }

    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToPoint(Vector3 point)
    {
        Agent.SetDestination(point);
    }

    public void SetSpeed(float speed)
    {
        Agent.speed = speed;
    }
}

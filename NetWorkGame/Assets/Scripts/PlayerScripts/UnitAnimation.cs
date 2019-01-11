using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitAnimation : MonoBehaviour
{
    private Animator _animator;
    private UnitMotor _motor;

    private int _walk;
    private int _run;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _motor = GetComponent<UnitMotor>();

        _walk = Animator.StringToHash("Walk");
        _run = Animator.StringToHash("Run");
    }

    private void FixedUpdate()
    {
        MoveAnimation();
    }

    private void MoveAnimation()
    {
        if (_motor.Agent.hasPath)
        {
            if (_motor.IsWalk)
                _animator.SetBool(_walk, true);
            else
                _animator.SetBool(_run, true);
        }
        else
        {
            _animator.SetBool(_walk, false);
            _animator.SetBool(_run, false);
        }
    }
}

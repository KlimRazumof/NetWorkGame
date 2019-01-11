using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [Range(0, 10)]
    [SerializeField] private float _walkSpeed;
    [Range(0, 10)]
    [SerializeField] private float _runSpeed;


    private Camera _camera;
    private UnitMotor _motor;
    


    private void Start()
    {
        _camera = Camera.main;
        _motor = GetComponent<UnitMotor>();
    }
    
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (InputManager.Instance.GetMouseButtonPosition(MouseButton.Left) != Vector3.zero)
        {
            _motor.SetSpeed(_walkSpeed);
            _motor.IsWalk = true;
            _motor.MoveToPoint(InputManager.Instance.GetMouseButtonPosition(MouseButton.Left));
        }
        else if (InputManager.Instance.GetMouseButtonPosition(MouseButton.Right) != Vector3.zero)
        {
            _motor.SetSpeed(_runSpeed);
            _motor.IsWalk = false;
            _motor.MoveToPoint(InputManager.Instance.GetMouseButtonPosition(MouseButton.Right));
        }
    }
}


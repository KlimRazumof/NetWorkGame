using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [Range(0, 5)]
    [SerializeField] private float _pitch;
    [Range(0, 20)]
    [SerializeField] private float _maxZoom;
    [Range(-5, 10)]
    [SerializeField] private float _minZoom;
    [Range(0, 10)]
    [SerializeField] private float _zoomSpeed;

    private float _currentZoom = 10f;
    private float _currentRotation = 0;
    private float _prevMouseX;

    public Transform Target { get; set; }
    private Transform _camFirstPosition;

    private void Start()
    {
        _camFirstPosition = transform;
    }

    private void Update()
    {
        if (Target)
        {
            _currentZoom -= InputManager.GesScrollIndex() * _zoomSpeed;
            _currentZoom = Mathf.Clamp(_currentZoom, _minZoom, _maxZoom);

            if (InputManager.GetButtonMiddleDown())
            {
                _currentRotation += InputManager.GetMousePosition().x - _prevMouseX;
            }
        }
    }

    private void LateUpdate()
    {
        if (Target)
        {
            transform.position = Target.position - _offset * _currentZoom;
            transform.LookAt(Target.position + Vector3.up * _pitch);
            transform.RotateAround(Target.position, Vector3.up, _currentRotation);
        }
    }
}

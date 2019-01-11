using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    private static InputManager _instance;
    private Camera _mainCamera;
    private LayerMask _groundLayer;

    public InputManager()
    {
        _mainCamera = Camera.main;
        _groundLayer = LayerMask.NameToLayer("Ground");
    }

    public static InputManager Instance
    {
        get
        {
            if (_instance == null)
            {
                return _instance = new InputManager();
            }
            else
            {
                return _instance;
            }
        }
    }

    public Vector3 GetMouseButtonPosition(MouseButton mouse)
    {
        var result = Vector3.zero;
        RaycastHit hit;

        if (Input.GetMouseButtonDown((int)mouse))
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit, 100, 1 << _groundLayer))
            {
                return result = hit.point;
            }
            else
            {
                return result;
            }
        }
        else
        {
            return result;
        }
    }
}

public enum MouseButton
{
    Left,
    Right,
    Midle
}


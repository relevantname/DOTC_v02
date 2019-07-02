using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputManager : MonoBehaviour
{
    protected float _horizontalInput;
    protected float _verticalInput;
    
    protected bool _shoot;
    protected bool _cast;

    public float HorizontalInput
    {
        get { return _horizontalInput; }
    }
    public float VerticalInput
    {
        get { return _verticalInput; }
    }

    public bool Shoot
    {
        get { return _shoot; }
    }
    public bool Cast
    {
        get { return _cast; }
    }

    protected virtual void Update()
    {
        if (_shoot)
            _shoot = false;

        if (_cast)
            _cast = false;
    }
}

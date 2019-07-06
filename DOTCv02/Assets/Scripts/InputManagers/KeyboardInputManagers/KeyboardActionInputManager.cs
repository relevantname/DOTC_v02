using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardActionInputManager : MonoBehaviour, IInputManager, IActionsInputManager
{
    private bool _shoot;
    private bool _cast;

    private void FixedUpdate()
    {
        GetInputs();
        ResetShoot();
        ResetCast();
    }

    public void GetInputs()
    {
        _shoot = Input.GetKeyDown(KeyCode.Mouse0);
        _cast = Input.GetKeyDown(KeyCode.Mouse1);
    }

    public bool GetShoot()
    {
        return _shoot;
    }
    public bool GetCast()
    {
        return _cast;
    }

    public void ResetShoot()
    {
        if (_shoot) _shoot = false;
    }
    public void ResetCast()
    {
        if (_cast) _cast = false;
    }
}

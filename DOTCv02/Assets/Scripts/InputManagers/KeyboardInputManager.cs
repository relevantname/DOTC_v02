using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputManager : InputManager
{
    protected override void Update()
    {
        base.Update();

        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        _shoot = Input.GetKeyDown(KeyCode.Mouse0);
        _cast = Input.GetKeyDown(KeyCode.Mouse1);
    }
}

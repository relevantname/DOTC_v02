using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputManager : InputManager
{
    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        _shoot = Input.GetKey(KeyCode.Mouse0);
        _cast = Input.GetKey(KeyCode.Mouse1);
    }
}

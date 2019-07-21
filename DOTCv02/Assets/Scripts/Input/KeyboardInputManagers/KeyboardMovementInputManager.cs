using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovementInputManager : MovementInputManager, IInputManager
{
    private void Update()
    {
        GetInputs();
    }

    public void GetInputs()
    {
        float horizontalInput = _unityServices.GetAxisRaw("Horizontal");
        float verticalInput = _unityServices.GetAxisRaw("Vertical");
        moveDirection = _movement.GetMovementVector(horizontalInput, verticalInput);
    }
}

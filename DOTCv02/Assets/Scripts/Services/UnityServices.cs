using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityServices : IUnityServices
{
    public float GetAxisRaw(string axisName)
    {
        return Input.GetAxisRaw(axisName);
    }

    public bool GetKeyDown(KeyCode keyCode)
    {
        return Input.GetKeyDown(keyCode);
    }
}

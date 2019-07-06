using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityServices : IUnityServices
{
    public float GetAxisRaw(string axisName)
    {
        return Input.GetAxisRaw(axisName);
    }
}

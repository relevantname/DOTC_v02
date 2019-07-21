using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputManager : MonoBehaviour
{
    public IUnityServices _unityServices;
    
    public virtual void Start()
    {
        if (_unityServices == null)
            _unityServices = new UnityServices();
    }
}

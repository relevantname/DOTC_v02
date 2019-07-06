using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementInputManager : MonoBehaviour
{
    [HideInInspector]
    public Vector3 moveDirection;

    private PlayerData playerData;
    protected IMovement _movement;
    public IUnityServices _unityServices;

    public virtual void Start()
    {
        playerData = GetComponent<PlayerData>();
        _movement = new Movement(playerData.characterSpeed);
        if (_unityServices == null)
            _unityServices = new UnityServices();
    }
}

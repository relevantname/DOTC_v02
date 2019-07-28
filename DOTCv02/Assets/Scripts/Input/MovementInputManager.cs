using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementInputManager : InputManager
{
    [HideInInspector]
    public Vector3 moveDirection;

    private PlayerStats _playerData;
    protected IMovement _movement;

    public override void Start()
    {
        base.Start();

        _playerData = GetComponent<PlayerStats>();
        _movement = new Movement(_playerData);
    }
}

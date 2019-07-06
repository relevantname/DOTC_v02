using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovementController : MonoBehaviour
{
    private MovementInputManager _movementInputManager;
    private Rigidbody _characterRigidbody;

    private void Start()
    {
        _movementInputManager = GetComponent<MovementInputManager>();
        _characterRigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        _characterRigidbody.velocity =
            _movementInputManager.moveDirection;
    }
}

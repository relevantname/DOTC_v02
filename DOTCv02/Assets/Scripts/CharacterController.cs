using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager), typeof(Rigidbody))]
public class CharacterController : MonoBehaviour
{
    public float characterSpeed;
    private Vector3 moveDirection;
    private float moveAmount;

    private Rigidbody characterRigidbody;
    private CapsuleCollider characterCollider;
    private Animator characterAnimator;
    private InputManager inputManager;

    private void Awake()
    {
        characterRigidbody = GetComponent<Rigidbody>();
        characterCollider = GetComponent<CapsuleCollider>();
        characterAnimator = GetComponentInChildren<Animator>();
        inputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        ProcessInputs();
    }

    private void ProcessInputs()
    {
        moveDirection = new Vector3(inputManager.HorizontalInput, 0, inputManager.VerticalInput).normalized;
        moveAmount = Mathf.Clamp01(Mathf.Abs(inputManager.HorizontalInput) + Mathf.Abs(inputManager.VerticalInput));
        
        characterRigidbody.velocity = moveDirection * characterSpeed;

        characterAnimator.SetFloat("Horizontal", inputManager.HorizontalInput);
        characterAnimator.SetFloat("Vertical", inputManager.VerticalInput);
        
        if (inputManager.Shoot == true)
            characterAnimator.SetTrigger("Shoot");

        if (inputManager.Cast == true)
            characterAnimator.SetTrigger("Cast");
    }
}

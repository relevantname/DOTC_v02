using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager), typeof(Rigidbody))]
public class CharacterController : MonoBehaviour
{
    public float characterSpeed;

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
        characterAnimator.SetFloat("Horizontal", inputManager.HorizontalInput);
        characterRigidbody.AddForce(new Vector3(inputManager.HorizontalInput,0,0).normalized*characterSpeed);
        characterAnimator.SetFloat("Vertical", inputManager.VericalInput);
        characterRigidbody.AddForce(new Vector3(0, 0, inputManager.VericalInput).normalized * characterSpeed);

        if (inputManager.HorizontalInput == 0 && inputManager.VericalInput == 0)
        {
            characterRigidbody.velocity = Vector3.zero;
            characterRigidbody.angularVelocity = Vector3.zero;
        }

        if (inputManager.Shoot == true)
            characterAnimator.SetTrigger("Shoot");

        if (inputManager.Cast == true)
            characterAnimator.SetTrigger("Cast");
    }
}

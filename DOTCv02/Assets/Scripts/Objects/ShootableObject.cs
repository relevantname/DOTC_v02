using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObject : MonoBehaviour, IShootableObject
{
    protected Rigidbody rigidbody;

    protected float heal_damageAmount;
    protected float shootSpeed;

    public void Initialize(float heal_damageAmount, float shootSpeed)
    {
        rigidbody = GetComponent<Rigidbody>();
        this.heal_damageAmount = heal_damageAmount;
        this.shootSpeed = shootSpeed;

        rigidbody.AddForce(transform.forward * shootSpeed);
    }
}

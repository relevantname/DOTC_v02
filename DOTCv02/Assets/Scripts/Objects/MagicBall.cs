using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour, IShootableObject
{
    private Rigidbody magicBallRigidbody;


    private float damage;
    private float moveSpeed;

    public void Initialize(float damage, float moveSpeed)
    {
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : IMovement
{
    private float speed;

    public Movement(float speed)
    {
        this.speed = speed;
    }

    public Vector3 GetMovementVector(float horizontal, float vertical)
    {
        return new Vector3(horizontal*speed, 0, vertical*speed);
    }
}

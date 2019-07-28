using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : IMovement
{
    private PlayerStats playerData;

    public Movement(PlayerStats playerData)
    {
        this.playerData = playerData;
    }

    public Vector3 GetMovementVector(float horizontal, float vertical)
    {
        return new Vector3(horizontal* playerData.playerStats.movementSpeed, 0, vertical* playerData.playerStats.movementSpeed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour, IPlayerDataContainer
{
    public PlayerDefaultData playerDefaultData;
    //private List<Buff> playerBuffs = new List<Buff>();
    
    public float GetMovementSpeed()
    {
        return playerDefaultData.movementSpeed;
    }
}

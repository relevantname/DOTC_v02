using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InitialBuff : MonoBehaviour, IInitialBuff
{
    public virtual void Execute(PlayerStats stats)
    {
        throw new System.NotImplementedException();
    }
}

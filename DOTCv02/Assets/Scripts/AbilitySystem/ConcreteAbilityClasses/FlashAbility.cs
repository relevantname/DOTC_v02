using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashAbility : Ability
{
    public float flashAmount = 5.0f;

    public override void Execute()
    {
        base.Execute();

        transform.parent.position += transform.forward * flashAmount;
    }
}

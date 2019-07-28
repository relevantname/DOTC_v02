using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootAbility_HealDamageMaker : HealDamageMakerAbility
{
    public virtual GameObject GetShootableObject()
    {
        return ((ShootAbility_HealDamageMakerAbilityData)abilityData).gameObjectToShoot;
    }
    public virtual float GetShootableObjectSpeed()
    {
        return ((ShootAbility_HealDamageMakerAbilityData)abilityData).shootableObjectSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootAbility_AreaHealDamageMaker : AreaHealDamageMakerAbility
{
    public virtual GameObject GetShootableObject()
    {
        return ((ShootAbility_AreaHealDamageMakerAbilityData) abilityData).gameObjectToShoot;
    }

    public virtual float GetShootableObjectSpeed()
    {
        return ((ShootAbility_AreaHealDamageMakerAbilityData)abilityData).shootableObjectSpeed;
    }
}

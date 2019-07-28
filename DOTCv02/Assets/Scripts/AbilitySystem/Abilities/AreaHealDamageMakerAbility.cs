using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AreaHealDamageMakerAbility : HealDamageMakerAbility
{
    public virtual float GetAreaDamage()
    {
        return ((AreaHealDamageMakerAbilityData) abilityData).areaHealDamageAmount;
    }
}

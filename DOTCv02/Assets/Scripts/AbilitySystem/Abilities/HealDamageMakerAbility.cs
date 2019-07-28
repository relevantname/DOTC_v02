using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealDamageMakerAbility : Ability
{
    public virtual float GetDamage()
    {
        return ((HealDamageMakerAbilityData) abilityData).heal_damageAmount;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMagicBallAbility : Ability
{
    public override void Execute()
    {
        base.Execute();

        Transform shootPos = this.transform.parent.Find("ShootPosition");
        ShootAbility_HealDamageMakerAbilityData aData = abilityData as ShootAbility_HealDamageMakerAbilityData;
        GameObject go = Instantiate(aData.gameObjectToShoot, shootPos.position, shootPos.rotation);
        go.GetComponent<IShootableObject>().Initialize(aData.heal_damageAmount, aData.shootableObjectSpeed);

        remainingCooldownDuration = aData.cooldownDuration;
        isInCooldown = true;
    }
}

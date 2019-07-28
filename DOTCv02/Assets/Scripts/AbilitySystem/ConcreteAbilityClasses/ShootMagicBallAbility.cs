using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMagicBallAbility : ShootAbility_HealDamageMaker
{
    public override void Execute()
    {
        base.Execute();

        Transform shootPos = this.transform.parent.Find("ShootPosition");
        GameObject go = Instantiate(GetShootableObject(), shootPos.position, shootPos.rotation);
        go.GetComponent<IShootableObject>().Initialize(GetDamage(), GetShootableObjectSpeed());
    }

    public override float GetDamage()
    {
        float baseDamage = base.GetDamage();
        float damageIncreaseAmount = baseDamage * (this.GetComponentInParent<PlayerStats>().playerStats.damageIncreasePercentage / 100);
        return baseDamage + damageIncreaseAmount;
    }
}

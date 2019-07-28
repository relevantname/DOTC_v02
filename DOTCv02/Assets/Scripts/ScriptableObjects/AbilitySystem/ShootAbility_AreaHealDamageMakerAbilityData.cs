using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootAbility_AreaHealDamageMakerAbilityData", menuName = "Ability Data/ShootAbility_AreaHealDamageMakerAbilityData")]
public class ShootAbility_AreaHealDamageMakerAbilityData : AreaHealDamageMakerAbilityData
{
    public GameObject gameObjectToShoot;
    public float shootableObjectSpeed;
}

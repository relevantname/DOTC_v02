using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootAbility_AreaHealDamageMakerAbility", menuName = "Ability Data/ShootAbility_AreaHealDamageMakerAbility")]
public class ShootAbility_AreaHealDamageMakerAbility : AreaHealDamageMakerAbilityData
{
    public GameObject gameObjectToShoot;
    public float shootableObjectSpeed;
}

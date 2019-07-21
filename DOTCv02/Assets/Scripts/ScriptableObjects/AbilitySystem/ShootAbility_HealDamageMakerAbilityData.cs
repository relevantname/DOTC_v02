using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootAbility_HealDamageMakerAbilityData", menuName = "Ability Data/ShootAbility_HealDamageMakerAbilityData")]
public class ShootAbility_HealDamageMakerAbilityData : HealDamageMakerAbilityData
{
    public GameObject gameObjectToShoot;
    public float shootableObjectSpeed;
}

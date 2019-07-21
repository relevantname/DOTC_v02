using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "AbilityBaseData", menuName = "Ability Data/AbilityBaseData")]
public class AbilityData : ScriptableObject, IAbilityData
{
    public string abilityName;
    public float cooldownDuration;
    public Sprite abilityImage;
    public string animationName;
    public GameObject particleEffect;
    public AudioSource audio;
    public bool waitForExecute;
}

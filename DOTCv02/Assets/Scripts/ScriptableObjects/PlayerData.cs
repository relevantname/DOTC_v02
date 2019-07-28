using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "GameData/PlayerData")]
public class PlayerData : ScriptableObject
{
    public float health;
    public float movementSpeed;
    public float cooldownReductionPercentage;
    public float damageIncreasePercentage;
}

using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDefaultData", menuName = "GameData/PlayerData")]
public class PlayerDefaultData : ScriptableObject
{
    public float movementSpeed;
    public float skillCooldownDuration;
    public float damage_magicBall;
    public float damage_magicNova;
}

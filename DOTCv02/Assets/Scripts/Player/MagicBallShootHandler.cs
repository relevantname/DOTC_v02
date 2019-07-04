using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBallShootHandler : MonoBehaviour, IHandleShoot
{
    public GameObject magicBall;
    public Transform magicBallShootPoint;
    private PlayerData playerData;

    private void Start()
    {
        playerData = GetComponent<PlayerData>();
    }
    public void Shoot()
    {
        GameObject magicBallGO = Instantiate(magicBall, magicBallShootPoint.position, transform.rotation);
        magicBallGO.GetComponent<IShootableObject>().Initialize(playerData.magicBallDamage, playerData.magicBallSpeed);
    }
}

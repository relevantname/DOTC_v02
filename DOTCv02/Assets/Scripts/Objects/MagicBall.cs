using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : ShootableObject
{
    public GameObject blowEffect;
    
    private void OnCollisionEnter(Collision collision)
    {
        IDamagable damagable = collision.collider.GetComponent<IDamagable>();
        damagable?.GetDamage(heal_damageAmount);

        if(blowEffect != null)Instantiate(blowEffect, collision.transform.position, Quaternion.identity);
    }
}

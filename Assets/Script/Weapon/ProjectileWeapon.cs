using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapon
{
    public EnemyDamager damager;
    public Projectile projectile;
    private float shootCounter;
    public  float weaponRange;
    public LayerMask whatIsEnemy;

    void Start()
    {
        SetState();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(stateUpdated == true)
        {
            stateUpdated = false;
            SetState();
        }
        
    }
    public void SetState()
    {
        damager.damageAmount = state[weaponLevel].damage;
        damager.maxCount = state[weaponLevel].duration;
        transform.localScale = Vector3.one * state[weaponLevel].range;
        shootCounter = 0f;
        projectile.moveSpeed = state[weaponLevel].speed;

    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
        shootCounter -= Time.deltaTime;
        if(shootCounter <= 0)
        {
            shootCounter = state[weaponLevel].timeBetweenAttacks;
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, weaponRange * state[weaponLevel].range, whatIsEnemy); 
            if(enemies.Length > 0)
            {
                for(int i = 0; i < state[weaponLevel].amount; i++)
                {
                    /*Vector3 direction = enemies[i].transform.position - transform.position;
                    Instantiate(projectile, transform.position, direction)*/
                    Vector3 targetPosition = enemies[UnityEngine.Random.Range(0,enemies.Length)].transform.position;
                    Vector3 direction = targetPosition - transform.position;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    angle -= 90;
                    projectile.transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
                    Instantiate(projectile, transform.position, projectile.transform.rotation).gameObject.SetActive(true);

                }
            }
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

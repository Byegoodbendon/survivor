using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ZoneWeapon : Weapon
{
    public EnemyDamager damager;
    private float spawnTime, spawnCounter;
    public GameObject zoneWeapon;
    void Start()
    {
        SetState();
        zoneWeapon.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHealthController.instance.gameObject.activeSelf == true)
        {
            if(stateUpdated == true)
            {
                stateUpdated = false;
                SetState();
            }
            if(zoneWeapon.activeInHierarchy == false)
            {
                spawnCounter += Time.deltaTime;
                if(spawnCounter >= spawnTime)
                {
                    zoneWeapon.SetActive(true);
                // transform.gameObject.SetActive(true);
                    
                    spawnCounter = 0;
                }
                
            }
            /*spawnCounter -= Time.deltaTime;
            if(spawnCounter <= 0f)
            {
                spawnCounter = spawnTime;
                Instantiate(damager,damager.transform.position,quaternion.identity,transform).gameObject.SetActive(true);

            }*/
        }
        
    }
    void SetState()
    {
        damager.damageAmount = state[weaponLevel].damage;
        transform.localScale = Vector3.one * state[weaponLevel].range;
        spawnTime = state[weaponLevel].timeBetweenAttacks;
        damager.timeBetweenDamage = state[weaponLevel].speed;
        spawnCounter = 0f;
        damager.maxCount = state[weaponLevel].duration;
    }
}

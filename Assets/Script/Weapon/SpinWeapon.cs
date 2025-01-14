using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class SpinWeapon : Weapon
{
    public float rotateSpeed;
    public float timeToSpawn = 3f;
    public Transform oringinalPoint;
    public GameObject spinWeapon;
    private float recoverTime;
    public EnemyDamager damager;
    void Start()
    {
        SetState();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(oringinalPoint.position,new Vector3(0f,0f,1f),rotateSpeed * Time.deltaTime * state[weaponLevel].speed);
        //transform.rotation = Quaternion.Euler(0f,0f,transform.rotation.eulerAngles.z * rotateSpeed * Time.deltaTime);
        if(spinWeapon.activeInHierarchy == false)
        {
            recoverTime += Time.deltaTime;
            if(recoverTime >= timeToSpawn)
            {
                spinWeapon.SetActive(true);
                recoverTime = 0;
            }
            
        }
        if(stateUpdated == true)
        {
            stateUpdated = false;
            SetState();
        }

    }
    public void SetState()
    {
        damager.damageAmount = state[weaponLevel].damage;
        transform.localScale = Vector3.one * state[weaponLevel].range;
        timeToSpawn = state[weaponLevel].timeBetweenAttacks;
        damager.maxCount = state[weaponLevel].duration;
        

        


    }
    
}

using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CloseAttackWeapon : Weapon
{
    public EnemyDamager damager;
    private float attackCounter, direction;
    public GameObject closeWeapon;
    void Start()
    {
        SetState();
        //transform.localScale = Vector3.one;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(stateUpdated == true)
        {
            stateUpdated = false;
            SetState();
        }
        attackCounter -= Time.deltaTime;
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"),1,1);
        }
        if(attackCounter <= 0)
        {
            attackCounter = state[weaponLevel].timeBetweenAttacks;
            /*if(Input.GetAxisRaw("Horizontal") != 0)
            {
                if(Input.GetAxisRaw("Horizontal") > 0)
                {
                    damager.transform.rotation = Quaternion.identity;
                }else{
                    damager.transform.rotation = Quaternion.Euler(0f,0f,180f);
                }
                
                
            }*/
            DeleteChildren(transform);
            float wl = state[weaponLevel].amount;
            for(int i = 0; i< wl; i++)
            {
                float rot = 360f / wl * i;
                GameObject obj = Instantiate(closeWeapon,closeWeapon.transform.position, quaternion.identity, transform);
                obj.SetActive(true);
                obj.transform.RotateAround(transform.position, new Vector3(0,0,1), rot);

            }
        }

        
    }
     public void SetState()
    {
        damager.damageAmount = state[weaponLevel].damage;
        damager.maxCount = state[weaponLevel].duration;
        Vector3 localPosition = closeWeapon.transform.localPosition;
        localPosition.x += state[weaponLevel].range;
        closeWeapon.transform.localPosition = localPosition;
        //state[weaponLevel].range;
        attackCounter = 0f;
    }
    public void DeleteChildren(Transform father)
    {
        // 遍历当前物件的所有子物件
        for (int i = father.childCount - 1; i >= 1; i--)
        {
            // 获取子物件
            Transform child = father.GetChild(i);

            // 删除子物件
            Destroy(child.gameObject);
        }
    }
}

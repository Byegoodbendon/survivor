using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WeaponThrower : Weapon
{
    public EnemyDamager damager;
    private float throwCounter;
    public Transform point;
    void Start()
    {
        SetState();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.instance.gameObject.activeSelf == false)
        {
            gameObject.SetActive(false);
        }else
        {
            if(stateUpdated == true)
            {
                stateUpdated = false;
                SetState();
            }
            throwCounter -= Time.deltaTime;
            if(throwCounter <= 0)
            {
                throwCounter = state[weaponLevel].timeBetweenAttacks;
                for(int i = 0; i < state[weaponLevel].amount; i++)
                {
                    Instantiate(damager,damager.transform.position,quaternion.identity,point).gameObject.SetActive(true);
                }
                DeleteChildren(point);
            }
        }

        
    }
    public void SetState()
    {
        damager.damageAmount = state[weaponLevel].damage;
        damager.maxCount = state[weaponLevel].duration;
        point.localScale = Vector3.one * state[weaponLevel].range;
        throwCounter = 0f;
        

    }
    
    public void DeleteChildren(Transform father)
    {
        // 遍历当前物件的所有子物件
        for (int i = father.childCount - 1; i >= 1; i--)
        {
            // 获取子物件
            Transform child = father.GetChild(i);
            if (child.gameObject.activeSelf == false)
            {

                // 删除子物件
                Destroy(child.gameObject);
            }
        }
    }
}

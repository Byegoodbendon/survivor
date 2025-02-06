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
    private int spawnCount = 1;
    void Start()
    {
        SetState();
        //UiController.instance.levelUpBottons[0].UpdateBottonDisplay(this);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHealthController.instance.gameObject.activeSelf == true)
        {
            if(spawnCount < state[weaponLevel].amount)
            {
                float wl = state[weaponLevel].amount;
                
                Vector3 startPosition = oringinalPoint.position + new Vector3(state[weaponLevel].range,0,0);
                DeleteChildren(this.gameObject.transform);
                
            for(int i=1; i< wl; i++)
            {
                float rot = 360f / wl * i;
                //Instantiate(spinWeapon,oringinalPoint.position,quaternion.Euler(0f,0f,rot),oringinalPoint);
                GameObject obj = Instantiate(spinWeapon, spinWeapon.transform.position, quaternion.identity,this.gameObject.transform);
                obj.transform.RotateAround(oringinalPoint.position, new Vector3(0,0,1), rot);
            
                spawnCount += 1;

            }
            spinWeapon.GetComponent<EnemyDamager>().damageTime = 0;
            }
            transform.RotateAround(oringinalPoint.position,new Vector3(0f,0f,1f),rotateSpeed * Time.deltaTime * state[weaponLevel].speed);
            
            //transform.rotation = Quaternion.Euler(0f,0f,transform.rotation.eulerAngles.z * rotateSpeed * Time.deltaTime);
            
            if(spinWeapon.activeInHierarchy == false)
            {
                recoverTime += Time.deltaTime;
                if(recoverTime >= timeToSpawn)
                {
                    //spinWeapon.SetActive(true);
                    foreach(Transform children in gameObject.transform)
                    {
                        children.gameObject.SetActive(true);
                    }
                    recoverTime = 0;
                }
                
            }
            if(stateUpdated == true)
            {
                stateUpdated = false;
                SetState();
            }
        }

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
    public void SetState()
    {
        damager.damageAmount = state[weaponLevel].damage;
        transform.localScale = Vector3.one * state[weaponLevel].range;
        timeToSpawn = state[weaponLevel].timeBetweenAttacks;
        damager.maxCount = state[weaponLevel].duration;
        

        


    }
    
}

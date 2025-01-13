using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class SpinWeapon : MonoBehaviour
{
    public float rotateSpeed;
    public Transform oringinalPoint;
    public GameObject spinWeapon;
    private float recoverTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(oringinalPoint.position,new Vector3(0f,0f,1f),rotateSpeed * Time.deltaTime);
        //transform.rotation = Quaternion.Euler(0f,0f,transform.rotation.eulerAngles.z * rotateSpeed * Time.deltaTime);
        if(spinWeapon.activeInHierarchy == false)
        {
            recoverTime += Time.deltaTime;
            if(recoverTime >= 3f)
            {
                spinWeapon.SetActive(true);
                recoverTime = 0;
            }
            
        }

    }
    
}

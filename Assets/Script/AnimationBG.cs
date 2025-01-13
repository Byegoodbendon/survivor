using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Material material;
    Vector2 movement;
    public Vector2 speed;

    void Start()
    {
        material=GetComponent<Renderer>().material;

        
    }

    // Update is called once per frame
    void Update()
    {
        movement += speed * Time.deltaTime;    //Time.deltaTime 是一秒鐘運行50次的參數 也就是每次0.02秒
        material.mainTextureOffset = movement;
        
    }
}

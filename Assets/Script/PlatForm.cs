using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatForm : MonoBehaviour
{
   Vector3 movement;
   public float speed;
   GameObject topLine;
    void Start()
    {
        movement.y = speed;
        topLine = GameObject.Find("TopLine");
        
    }

    // Update is called once per frame
    void Update()
    {
        PlatForm_Movement();
    }

    void PlatForm_Movement()
    {
        transform.position += movement * Time.deltaTime;

        if(transform.position.y >= topLine.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}

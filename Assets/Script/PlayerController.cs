using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Animator anim;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
        
    
    
       /* if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(0,speed * Time.deltaTime,0);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime,0,0);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(0,-speed * Time.deltaTime,0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime,0,0);
        }*/
        Vector3 moveInput = new Vector3(0,0,0);
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        if(moveInput.x != 0)
        {
            transform.localScale = new Vector3(moveInput.x,1,1);
        }
        moveInput.Normalize();
        transform.position += speed* moveInput * Time.deltaTime;
        
        
        
        if(moveInput != Vector3.zero)
        {
            anim.SetBool("isMoving", true);

        }else
        { 
            anim.SetBool("isMoving", false);
        }
        
    }
}
    
   
       
    



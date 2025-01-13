using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public float speed;
    float xVelocity;

    public bool isOnGround;
    public float checkRadious;
    public LayerMask Platform;
    public GameObject groundCheck;
    public bool playerDead;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        isOnGround = Physics2D.OverlapCircle(groundCheck.transform.position, checkRadious, Platform);
        anim.SetBool("isOnGround",isOnGround);
    }

    void Movement()
    {
        xVelocity = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);

        anim.SetFloat("speed",Mathf.Abs(rb.velocity.x));
        
        if (xVelocity != 0)
        {
            transform.localScale = new Vector3(xVelocity,1,1);
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Fan"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 8f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Spike"))
        {
            anim.SetTrigger("dead");

        }
        
    }
    public void PlayerDead()
    {
        playerDead = true;
    }
    private void OnDrawGizmosSelected()
     {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.transform.position, checkRadious);
        
    }
}

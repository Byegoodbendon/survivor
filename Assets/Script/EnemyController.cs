using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform target;
    public Rigidbody2D enemyRB;
    public Animator eneyAnim;
    public float moveSpeed;
    private float heartCount;
    private float heartWaitTime = 2.0f;
    public float health;
    public float knockBackTime = 0.5f;
    private float knockBackCount;
    public int expToGive;
    void Start()
    {
       //target = FindObjectOfType<PlayerController>().transform;
       target= PlayerHealthController.instance.transform;
       moveSpeed = moveSpeed * UnityEngine.Random.Range(0.75f,1.25f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(knockBackCount >0)
        {
            knockBackCount -= Time.deltaTime;
            eneyAnim.SetBool("hurt",true);
            if(moveSpeed > 0)
            {
                
                moveSpeed = -moveSpeed;
            }
            if(knockBackCount <= 0)
            {
                moveSpeed = Mathf.Abs(moveSpeed);
                eneyAnim.SetBool("hurt",false);
            }

        }
        


       enemyRB.velocity = (target.position-transform.position).normalized * moveSpeed;
       if(target.position.x <= transform.position.x)
       {
        transform.localScale = new Vector3(-1,1,1);
       }else
       {
        transform.localScale = new Vector3(1,1,1);
       }
       if (heartCount >= 0f)
       {
        heartCount -= Time.deltaTime;
       }
       
        
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player" && heartCount <= 0)
        {
            PlayerHealthController.instance.GetHeart(5f);
            heartCount = heartWaitTime;

        }
        
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
       {
        Destroy(gameObject);
        ExperienceLevelController.instance.SpawnExp(transform.position, expToGive);
       }

    }
    public void TakeDamage(float damage,bool knockBack)
    {
        TakeDamage(damage);
        if(knockBack == true)
        {
            knockBackCount = knockBackTime;
        }
    }
}

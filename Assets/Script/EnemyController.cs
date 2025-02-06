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
    public float coinDropRate = 0.1f;
    public float magnetDropRate = 0.1f;
    public int coinValue = 1;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float flashDuration = 0.15f;
    void Start()
    {
       
       target= PlayerHealthController.instance.transform;
       moveSpeed = moveSpeed * UnityEngine.Random.Range(0.75f,1.25f);
       spriteRenderer = GetComponent<SpriteRenderer>();
       originalColor = spriteRenderer.color;
    
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.instance.gameObject.activeSelf == true)
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
        }else
        {
            enemyRB.velocity = Vector2.zero;
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
        TakeDamageEffect();
        if(health <= 0)
       {
        StartCoroutine(Die());
        
       }
       DamageNumberController.instance.SpawnDamage(damage, transform.position);

    }
    public void TakeDamage(float damage,bool knockBack)
    {
        TakeDamage(damage);
        if(knockBack == true)
        {
            knockBackCount = knockBackTime;
        }
    }
    public void TakeDamageEffect()
    {
        StartCoroutine(FlashRed());
    }

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = new Color(1f, 0.5f, 0.5f, 1f); // 变红
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor; // 恢复原始颜色
    }
    private IEnumerator Die()
    {
        eneyAnim.SetBool("dead",true);
        enemyRB.velocity = Vector2.zero;
        enemyRB.bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;
        for(float i = 1f;  i > 0; i -=0.1f)
        {
            spriteRenderer.color = new Color(1f,1f,1f,i);
            yield return new WaitForSeconds(0.06f);
        }
        
        
        
        ExperienceLevelController.instance.SpawnExp(transform.position, expToGive);
        if(UnityEngine.Random.value <= coinDropRate)
        {
            CoinController.instance.DropCoin(transform.position, coinValue);
        }
        if(UnityEngine.Random.value <= magnetDropRate)
        {
            ItemController.instance.DropItem(ItemController.instance.magnet, transform.position);
        }
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float damageAmount;
    private float damageTime;
    public float maxCount;
    private float recoverTime;
    private Vector3 targetSize;
    public float growSpeed;
    public bool knockBack;

    void Start()
    {
        targetSize = transform.localScale;
        transform.localScale = Vector3.zero;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(damageTime < maxCount)
        {   
            transform.localScale = Vector3.MoveTowards(transform.localScale, targetSize, growSpeed * Time.deltaTime);
        }
        else if(damageTime >= maxCount)
        {
            
            
            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, growSpeed * Time.deltaTime);
        
            if(transform.localScale.x == 0)
            {
                damageTime = 0;
                gameObject.SetActive(false);

            }
        }
        damageTime += Time.deltaTime;
        
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().TakeDamage(damageAmount,knockBack);
        }
    }
}

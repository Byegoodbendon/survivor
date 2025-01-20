using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float damageAmount;
    public float damageTime;
    public float maxCount;
    private float recoverTime;
    private Vector3 targetSize;
    public float growSpeed;
    public bool knockBack;
    public bool damageOverTime;
    public bool destroyOnImpact;
    public float timeBetweenDamage;
    public float timeCounter;
    private List<EnemyController> enemysInRange = new List<EnemyController>();
    public GameObject spinHolder;

    void Start()
    {
        targetSize = transform.localScale;
       // targetSize = transform.parent.GetComponent<Weapon>().state[weaponlevel].range * transform.localScale;
        transform.localScale = Vector3.zero;
        damageTime = 0f;

        
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
        if(damageOverTime == true)
        {
            timeCounter -= Time.deltaTime;
            if(timeCounter <= 0)
            {
                 timeCounter = timeBetweenDamage;
                for(int i = 0; i< enemysInRange.Count; i++)
                {
                    if(enemysInRange[i] != null)
                    {
                        enemysInRange[i].TakeDamage(damageAmount,knockBack);
                    }else{
                        enemysInRange.RemoveAt(i);
                        i--;
                    }   
                } 
            }
        }
        damageTime += Time.deltaTime;
        
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(damageOverTime == false)
        {
            if(other.tag == "Enemy")
            {
                other.GetComponent<EnemyController>().TakeDamage(damageAmount,knockBack);
                if(destroyOnImpact == true)
                {
                    Destroy(gameObject);
                }

            }
        }else
        {
            if(other.tag =="Enemy")
            {
                enemysInRange.Add(other.GetComponent<EnemyController>()); 
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(damageOverTime == true)
        {
            if(other.tag == "Enemy")
            {
                enemysInRange.Remove(other.GetComponent<EnemyController>());
            }
        }
    }
    
}

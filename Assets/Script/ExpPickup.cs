using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExpPickup : MonoBehaviour
{
    public int expAmount;
    public float moveSpeed;
    private bool rangeActive;
    public GameObject pickRange;
    private float moveCount = 0.4f;
    
    
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PickRange.move == true && pickRange.activeSelf ==false)
        {
            moveCount -= Time.deltaTime;
            if(moveCount <= 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, PlayerHealthController.instance.transform.position, moveSpeed * Time.deltaTime);
                
            }
            
        }

        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            ExperienceLevelController.instance.getExp(expAmount);
            Destroy(gameObject);
        }
        
    }
}

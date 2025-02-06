using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExpPickup : MonoBehaviour
{
    public int expAmount;
    public float moveSpeed;
    
    public GameObject pickRange;
    
    private bool canMove;
    
    
    void Start()
    {
        StartCoroutine(DelayMove());
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove && pickRange.activeSelf ==false)
        {
            
            
                transform.position = Vector3.MoveTowards(transform.position, PlayerHealthController.instance.transform.position, moveSpeed * Time.deltaTime);
            
            
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
    private IEnumerator DelayMove()
    {
        yield return new WaitForSeconds(0.5f); 
        canMove = true; // 允許移動
    }
}

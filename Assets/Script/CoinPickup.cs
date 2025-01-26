using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinAmount;
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
            CoinController.instance.addCoin(coinAmount);
            Destroy(gameObject);
        }
        
    }
    private IEnumerator DelayMove()
    {
        yield return new WaitForSeconds(1f); // 等待 1 秒
        canMove = true; // 允許移動
    }
}

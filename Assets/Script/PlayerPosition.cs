using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public Transform player;
    void Start()
    {
        transform.position = player.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Exp")
        {
            
        }
        
    }
}

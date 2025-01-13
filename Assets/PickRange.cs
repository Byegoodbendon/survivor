using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickRange : MonoBehaviour
{
    static public bool move = false;
    public static PickRange instance;
    private void Awake() 
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            move = true;
            gameObject.SetActive(false);
            
        }
        
    }
    
}

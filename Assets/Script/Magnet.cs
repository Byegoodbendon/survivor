using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            PlayerController.instance.ActivateMagnetEffect(50,0.5f);
            Destroy(gameObject);
        }
    }
    
}

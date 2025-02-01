using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCollider : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Wall")
        {
            PlayerController.instance.topCollider = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Wall")
        {
            PlayerController.instance.topCollider = false;
        }
    }
}

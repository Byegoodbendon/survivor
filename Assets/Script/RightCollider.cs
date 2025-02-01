using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCollider : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Wall")
        {
            if(PlayerController.instance.transform.localScale.x < 0 )
            {
                PlayerController.instance.leftCollider = true;
            }else
            {
                PlayerController.instance.rightCollider = true;
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Wall")
        {
            if(PlayerController.instance.transform.localScale.x < 0 )
            {
                PlayerController.instance.rightCollider = false;
            }else
            {
                PlayerController.instance.leftCollider = false;
            }
        }
    }
}

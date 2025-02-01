using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomCollider : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Wall")
        {
            PlayerController.instance.bottomCollider = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Wall")
        {
            PlayerController.instance.bottomCollider = false;
        }
    }
}

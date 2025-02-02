using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(StartAttract()); 
            Destroy(gameObject);
        }
    }
    private IEnumerator StartAttract()
    {
        PlayerController.instance.pickupRange.radius += 50;
        yield return new WaitForSeconds(1.5f);
        PlayerController.instance.pickupRange.radius -= 50;

    }
}

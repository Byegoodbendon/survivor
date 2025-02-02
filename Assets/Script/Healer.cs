using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{
    public float healingAmount;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            PlayerHealthController.instance.GetHeal(healingAmount);
            Destroy(gameObject);
        }
        

    }
}

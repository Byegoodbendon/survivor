using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthController : MonoBehaviour
{

    public static PlayerHealthController instance;
    public float currentHealth, maxHealth;
    public Slider healthSlider;
    
    private void Awake() 
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
        
        healthSlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void GetHeart(float damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth;
        
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}

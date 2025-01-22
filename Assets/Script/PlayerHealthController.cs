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
    public Gradient gradient;
    public Image fill;
    
    private void Awake() 
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        
        healthSlider.value = currentHealth;
        //fill.color = gradient.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void GetHeart(float damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth;
        //fill.color = gradient.Evaluate(healthSlider.normalizedValue);
        
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}

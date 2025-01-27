using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthController : MonoBehaviour
{

    public static PlayerHealthController instance;
    public float currentHealth, maxHealth;
    public Slider healthSlider;
    //public Gradient gradient;
    
    public GameObject playerDeathEffect;
    
    private void Awake() 
    {
        instance = this;
    }
    void Start()
    {
        maxHealth = PlayerStatController.instance.health[0].value;
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
            LevelManager.instance.EndLevel();
            Instantiate(playerDeathEffect,transform.position,transform.rotation);
        }
    }
}

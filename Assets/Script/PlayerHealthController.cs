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
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float flashDuration = 0.15f;
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
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        //fill.color = gradient.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void TakeDamageEffect()
    {
        StartCoroutine(FlashRed());
    }

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = new Color(1f, 0.5f, 0.5f, 1f); // 变红
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor; // 恢复原始颜色
    }

    public void GetHeart(float damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth;
        TakeDamageEffect();

        //fill.color = gradient.Evaluate(healthSlider.normalizedValue);
        
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
            LevelManager.instance.EndLevel();
            Instantiate(playerDeathEffect,transform.position,transform.rotation);
        }
    }
    public void GetHeal(float healingAmount)
    {
        currentHealth += healingAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthSlider.value = currentHealth;
    }
}

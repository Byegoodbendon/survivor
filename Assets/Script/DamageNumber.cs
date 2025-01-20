using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    public float lifeTime;
    private float lifeCounter;
    private float fadeDuration = 0.3f;
    public TMP_Text damageText;
    public float floatSpeed = 10f;
    
     
    
    void Update()
    {
        if(lifeCounter > 0)
        {
            lifeCounter -= Time.deltaTime;
            Color originalColor = damageText.color;
            
            if(lifeCounter <= fadeDuration)
            {
                float alpha = Mathf.Lerp(0, 1, lifeCounter / fadeDuration);
                damageText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            }
            if(lifeCounter <= 0)
            {
           
                Destroy(gameObject);
            }
        }
        transform.position += Vector3.up * Mathf.Lerp(floatSpeed, 1, lifeCounter) * Time.deltaTime;
       
    }
    public void SetUp(int damageDisplay)
    {
        lifeCounter = lifeTime;
        damageText.text = damageDisplay.ToString();
    }
}

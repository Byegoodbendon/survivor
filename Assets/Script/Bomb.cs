using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float damageAmount;
    public float explosionRadius = 10f;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            EnemyController[] enemies = FindObjectsOfType<EnemyController>();
            foreach (EnemyController enemy in enemies)
            {
            // 检查敌人是否在爆炸范围内
                float distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance <= explosionRadius)
                {
                    enemy.TakeDamage(damageAmount); // 造成伤害
                }
            }
            Destroy(gameObject);

        }
    }
}

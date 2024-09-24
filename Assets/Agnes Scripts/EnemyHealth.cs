using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 2;
    public string bulletTag = "Egg";
    
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (spriteRenderer != null && collision.gameObject.CompareTag(bulletTag))
        {
            EnemyDamage(1f);
        }
    }

    public void EnemyDamage(float damage)
    {
        enemyHealth -= damage;
    }
}

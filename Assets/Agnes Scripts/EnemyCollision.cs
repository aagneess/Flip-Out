using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCollision : MonoBehaviour
{
    public float speed;
    //Change to private after testing is done
    //private float speed = 0.5f;
    public Color normalColor = Color.white;
    public Color collisionColor = Color.red;
    public string enemyTag = "Enemy";
    public Image flipOutBar;
    
    public float healthAmount = 100f;
    public float maxHealth = 100f;
    public float damage = 0.5f;
    public float damageInterval = 0.05f;
    
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;
    private float lastDamageTime;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        flipOutBar.fillAmount = 0;
        spriteRenderer.color = normalColor;
    }
		
    void Update ()
    {
		rb2D.velocity = new Vector2 (speed, 0);
                
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.Lerp(normalColor, collisionColor, flipOutBar.fillAmount);
        }
	}


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (spriteRenderer != null && collision.gameObject.CompareTag(enemyTag))
        {
            if (Time.time - lastDamageTime >= damageInterval)
            {
                TakeDamage(damage);
                lastDamageTime = Time.time;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;

        if (flipOutBar != null)
        {
            flipOutBar.fillAmount = (maxHealth - healthAmount) / maxHealth;

            if (flipOutBar.fillAmount >= 1f)
            {
                Debug.Log("Player has lost!");
                // Add game over logic here
            }
        }
    }
}

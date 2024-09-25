using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{
    public Color normalColor = Color.white;
    public Color collisionColor = Color.red;
    public string enemyTag = "Enemy";
    public string obstacleTag = "Obstacle";
    public Image flipOutBar;
    public Animator animator;
    
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
        Debug.Log(spriteRenderer.name);
    }
		
    void Update ()
    {          
        if (spriteRenderer)
        {
            spriteRenderer.color = Color.Lerp(normalColor, collisionColor, flipOutBar.fillAmount);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag) || collision.gameObject.CompareTag(obstacleTag))
        {
            // Add bump-into-something animation
            //animator.SetFloat("Speed", x);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag) || collision.gameObject.CompareTag(obstacleTag))
        {
            if (spriteRenderer && Time.time - lastDamageTime >= damageInterval)
            {
                TakeDamage(damage);
                lastDamageTime = Time.time;
            }
        }
    }

    // private void OnCollisionStay2D(Collision2D collision)
    // {
    //     if (spriteRenderer && collision.gameObject.CompareTag(enemyTag) || spriteRenderer && collision.gameObject.CompareTag(obstacleTag))
    //     {
    //         if (Time.time - lastDamageTime >= damageInterval)
    //         {
    //             TakeDamage(damage);
    //             lastDamageTime = Time.time;
    //         }
    //     }
    // }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;

        if (flipOutBar)
        {
            flipOutBar.fillAmount = (maxHealth - healthAmount) / maxHealth;

            if (flipOutBar.fillAmount >= 1f)
            {
                animator.SetBool("IsFlippingOut", true);
                Debug.Log("Player has lost!");
                // Add game over logic here
            }
        }
    }
    // public void IsFlippingOut()
    // {
    //     animator.SetBool("IsFlippingOut", true);
    // }
}

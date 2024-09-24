using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Sprite flippedSprite;
    public int health = 2;
    
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void Damage(int dmg) 
    {
        health -= dmg;

        if (health <= 0)
        {
            FlipEnemy();
            RemoveBoxCollider();
            RemoveRigidBody();
        }
    }

    public void FlipEnemy()
    {
        spriteRenderer.sprite = flippedSprite;
    }

    public void RemoveBoxCollider()
    {
        if (boxCollider != null)
        {
            Destroy(boxCollider);
            Debug.Log("BoxCollider2D removed");
        }
    }
    public void RemoveRigidBody()
    {
        if (rb2D != null)
        {
            Destroy(rb2D);
            Debug.Log("rb2D removed");
        }
    }


}
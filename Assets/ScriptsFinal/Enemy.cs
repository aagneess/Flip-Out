using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Sprite flippedSprite;
    public int health;
    public float enemySpeed;
    
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;
    private Animator animator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        transform.Translate(Vector3.right * enemySpeed * Time.deltaTime);
    }

    public void Damage(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            FlipEnemy();
            RemoveBoxCollider();
            RemoveRigidBody();
            RemoveAnimator();

            enemySpeed = 0;
            //rb2D.velocity = Vector2.zero;
            //Debug.Log(transform.position);
        }
    }

    public void FlipEnemy()
    {
        spriteRenderer.sprite = flippedSprite;
    }

    public void RemoveBoxCollider()
    {
        if (boxCollider)
        {
            Destroy(boxCollider);
            Debug.Log("BoxCollider2D removed");
        }
    }

    public void RemoveRigidBody()
    {
        if (rb2D)
        {
            Destroy(rb2D);
            Debug.Log("Rigidbody removed");
        }
    }

    public void RemoveAnimator()
    {
        if (animator)
        {
            Destroy(animator);
            Debug.Log("Animator removed");
        }
    }
}
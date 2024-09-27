using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movement_Player : MonoBehaviour
{
    //public variables
    public float Speed = 1f;
    public float acceleration = 1f;
    public float maxSpeed;
    public Animator animator;
    //public SpriteRenderer spriteRenderer;

    //WINPNG
    //to make the png work have it as a child on the characters house.
    //put it a but above the house and it will appear when you get to the house.
    private string winpngName = "you_win_!";
    private GameObject winpng;
    private bool isWinPngActive = false; // Track if the PNG has been activated
    private bool canCheckForInput = false;  // Track when to allow input

    //private Vector3 targetScale = new Vector3(2f, 2f, 0); // twice the size of the original spritesize

    //private variables
    private Rigidbody2D rb2D;
    private float lanePosition;
    private float limitPosition;

    // Start is called before the first frame update
    void Start()
    {
        limitPosition = transform.position.y;
        lanePosition = limitPosition;
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
    
        //search for winpng
        winpng = GameObject.Find(winpngName);

        //makes sure winpng is inactive at first
        if (winpng != null)
        {
            winpng.SetActive(false);//hide the png
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        // Once input is allowed, check for key presses and go to MAIN MENU
        if (canCheckForInput && Input.anyKeyDown)
        {
            SceneManager.LoadScene("Main Menu"); // Change scene when any key is pressed
        }
    }

    public void Movement()
    {

        //speed and acceleration
        Speed = Mathf.Clamp(Speed, 0, maxSpeed);
        //g�ra s� det g�r snabbare och snabbare ju mer tiden g�r. 
        Speed += acceleration * Time.deltaTime;


        // Lane code 
        rb2D.velocity = new Vector2(Speed, rb2D.velocity.y);

        float xAxis = transform.position.x; // x axis
        //startpos of player y AXIS

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            lanePosition += 1;
            lanePosition = Mathf.Clamp(lanePosition, limitPosition - 1, limitPosition);
            //  Camera.main.transform.position= new Vector3(xAxis, 0, 0);

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            lanePosition -= 1;
            lanePosition = Mathf.Clamp(lanePosition, limitPosition - 1, limitPosition);
            // Camera.main.transform.position = new Vector3(xAxis, 0, 0);
        }

        //update movement
        transform.position = new Vector2(xAxis, lanePosition);

    }

    private void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.CompareTag("Home"))
        {
            ActivateWinpng();
            IsWinning();
            // if (spriteRenderer)
            // {
            //     spriteRenderer.color = Color.white;
            // }
        }
    }



    private void ActivateWinpng()
    {
        if (winpng != null && !isWinPngActive)
        {
            winpng.SetActive(true); // Show the PNG object
            isWinPngActive = true;
            Invoke("EnableInputCheck", 3f);

        }
    }

    private void EnableInputCheck()
    {
        canCheckForInput = true;
    }

    public void IsWinning()
    {
        animator.SetBool("IsWinning", true);
        //transform.localScale = targetScale;
    }
}


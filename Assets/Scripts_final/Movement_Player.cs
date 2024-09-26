using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement_Player : MonoBehaviour
{
    //public variables
    public float Speed = 1f;
    public float acceleration = 1f;
    public float maxSpeed;
    public Animator animator;

    //WINPNG
    //to make the png work have it as a child on the characters house.
    //put it a but above the house and it will appear when you get to the house.
    private string winpngName = "you_win_!";
    private GameObject winpng;

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
        }
    }

    private void ActivateWinpng()
    {
        if (winpng != null)
        {
            winpng.SetActive(true); // Show the PNG object
        }
    }

        public void IsWinning()
    {
        animator.SetBool("IsWinning", true);
        //transform.localScale = targetScale;
    }
}


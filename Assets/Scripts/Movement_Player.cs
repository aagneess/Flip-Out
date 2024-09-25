using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Player : MonoBehaviour
{
    public float Speed = 1f;
    public float acceleration = 1f;
    public float Maxspeed;
    private Rigidbody2D rb2D;
    private float Startpos;
   

    //Change to private after testing is done
    //private float speed = 1f; (test what speed is best)

    // Start is called before the first frame update
    void Start()
    {
        Startpos = transform.position.y;
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }

    public void Movement()
    {
        
        //speed and acceleration
        Speed = Mathf.Clamp(Speed, 0, Maxspeed);
        //göra så det går snabbare och snabbare ju mer tiden går. 
        Speed += acceleration * Time.deltaTime;


        // Lane code 
        rb2D.velocity = new Vector2(Speed, rb2D.velocity.y);

        float xAxis = transform.position.x; // x axis
        float yAxis = transform.position.y; //y axis

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            yAxis += 1;
            yAxis = Mathf.Clamp(yAxis, Startpos, Startpos + 1);
            //  Camera.main.transform.position= new Vector3(xAxis, 0, 0);

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            yAxis -= 1;
            yAxis = Mathf.Clamp(yAxis, Startpos, Startpos + 1);
            // Camera.main.transform.position = new Vector3(xAxis, 0, 0);
        }

        //update movement
        transform.position = new Vector2(xAxis, yAxis);

    }

    private void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.CompareTag("Home"))
        {
            Debug.Log("You are home. Congratz");
        }
    }
}

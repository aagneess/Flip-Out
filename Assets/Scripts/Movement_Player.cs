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
    private float lanePosition;
    private float limitPosition;



    //Change to private after testing is done
    //private float speed = 1f; (test what speed is best)

    // Start is called before the first frame update
    void Start()
    {
        limitPosition = transform.position.y;
        lanePosition = limitPosition;
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
            Debug.Log("You are home. Congratz");
        }
    }
}
